using System;
using MySql.Data.MySqlClient;
using LoginServer.Server;
using LoginServer.Common;

namespace LoginServer.Database {
    public static class AccountDB {
        const byte expired = 1;

        /// <summary>
        /// Obtém o ID de usuário.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static int GetID(string username) {
            var connection = new MySQL().CreateConnection();
            var query = "SELECT id FROM accounts WHERE account=?username";
            var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("?username", username);
            var reader = cmd.ExecuteReader();

            if (!reader.Read()) {
                reader.Close();
                connection.Close();
                return 0;
            }

            var id = (int)reader["id"];

            reader.Close();
            connection.Close();

            return id;
        }

        /// <summary>
        /// Obtém informações básicas da conta de usuário.
        /// </summary>
        /// <param name="pData"></param>
        /// <returns></returns>
        public static void LoadAccountData(PlayerData pData) {
            var connection = new MySQL().CreateConnection();
            var query = "SELECT id, pin, cash, language_id, access_level, pin_attempt, date_last_login FROM accounts WHERE account=?username";
            var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("?username", pData.Account);
            var reader = cmd.ExecuteReader();

            if (!reader.Read()) {
                connection.Close();
                reader.Close();
                return;
            }

            pData.ID = (int)reader["id"];
            pData.Pin = (string)reader["pin"];
            pData.Cash = (int)reader["cash"];
            pData.LanguageID = Convert.ToByte(reader["language_id"]);
            pData.AccessLevel = Convert.ToByte(reader["access_level"]);
            pData.PinAttempt = Convert.ToByte(reader["pin_attempt"]);
            pData.LastLogin = Convert.ToDateTime(reader["date_last_login"]);

            reader.Close();
            connection.Close();
        }

        /// <summary>
        /// Verifica e obtem as informações do serviço.
        /// </summary>
        /// <param name="pData"></param>
        public static void LoadAccountService(PlayerData pData) {
            var connection = new MySQL().CreateConnection();
            var query = "SELECT service_id, end_time, expired FROM account_service WHERE account_id=?id";
            var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("?id", pData.ID);
            var reader = cmd.ExecuteReader();

            var value = 0;
            var serviceID = 0;
            var end_time = new DateTime();

            while (reader.Read()) {
                value = Convert.ToByte(reader["expired"]);

                //se o valor já está expirado, continua para o próximo
                if (value == expired)
                    continue;

                end_time = Convert.ToDateTime(reader["end_time"]);
                serviceID = (int)reader["service_id"];           

                //adiciona o serviço à lista do jogador
                pData.Service.Add(serviceID, end_time);
            }

            reader.Close();
            connection.Close();
        }

        /// <summary>
        /// Altera as informações do serviço.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        public static void UpdateService(int accountID, int serviceID, int updateValue) {
            var connection = new MySQL().CreateConnection();
            var query = "UPDATE account_service SET expired=?updateValue WHERE account_id=?accountID and service_id=?serviceID";
            var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("?updateValue", updateValue);
            cmd.Parameters.AddWithValue("?accountID", accountID);
            cmd.Parameters.AddWithValue("?serviceID", serviceID);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        /// <summary>
        /// Adiciona um usuário à lista de banidos.
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="minutes"></param>
        /// <param name="reason"></param>
        public static void BanAccount(int accountID, short minutes, string reason) {
            var connection = new MySQL().CreateConnection();
            var query = "INSERT INTO account_ban (account_id, start_time, end_time, reason, expired) ";
            query += "VALUES (?id, ?start, ?end, ?reason, ?expired)";
            var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("?id", accountID);
            cmd.Parameters.AddWithValue("?start", DateTime.Now);
            cmd.Parameters.AddWithValue("?end", DateTime.Now.AddMinutes(minutes));
            cmd.Parameters.AddWithValue("?reason", reason);
            cmd.Parameters.AddWithValue("?expired",  0);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        /// <summary>
        /// Verifica se o id está na lista de banidos.
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        public static bool IsBanned(int accountID) {
            var connection = new MySQL().CreateConnection();
            var query = "SELECT id, expired, end_time FROM account_ban WHERE account_id=?id";
            var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("?id", accountID);
            var reader = cmd.ExecuteReader();

            if (!reader.Read()) {
                reader.Close();
                connection.Close();
                return false;
            }

            var value = Convert.ToByte(reader["expired"]);

            // 1 = expirado
            // 0 = ainda ativo
            //Se o tempo já expirou, retorna falso
            if (value == expired) {
                reader.Close();
                connection.Close();
                return false;
            }

            var end_time = Convert.ToDateTime(reader["end_time"]);

            //Se expirou, atualiza o valor no registro da db.  
            if (DateTime.Now.CompareTo(end_time) == expired) {
                var ban_id = (int)reader["id"];
                reader.Close();
                connection.Close();
                UpdateBan(ban_id, expired);
                return false;
            }

            reader.Close();
            connection.Close();
            return true;
        }

        /// <summary>
        /// Atualiza o status do ban (usado para removação).
        /// </summary>
        /// <param name="banID"></param>
        /// <param name="value"></param>
        public static void UpdateBan(int banID, byte value) {
            var connection = new MySQL().CreateConnection();
            var query = "UPDATE account_ban SET expired=?value WHERE id=?banID";
            var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("?value", value);
            cmd.Parameters.AddWithValue("?banID", banID);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        /// <summary>
        /// Adiciona um ip à lista de banidos.
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <param name="value"></param>
        public static void AddBannedIp(string ipAddress, DateTime value) {
            var connection = new MySQL().CreateConnection();
            var query = "INSERT INTO banned_ip (address, start_time, end_time) VALUES (?address, ?start_time, ?end_time)";
            var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("?address", ipAddress);
            cmd.Parameters.AddWithValue("?start_time", DateTime.Now);
            cmd.Parameters.AddWithValue("?end_time", value);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        /// <summary>
        /// Verifica se o ip já está na lista de banidos.
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <returns></returns>
        public static bool IsBannedIp(string ipAddress) {
            var connection = new MySQL().CreateConnection();
            var query = "SELECT id, end_time FROM banned_ip WHERE address=?address";
            var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("?address", ipAddress);
            var reader = cmd.ExecuteReader();

            if (!reader.Read()) {
                reader.Close();
                connection.Close();
                return false;
            }
            
            var end_time = Convert.ToDateTime(reader["end_time"]);

            //Compara as datas, Se expirou, atualiza o registro na db.
            if (DateTime.Now.CompareTo(end_time) == expired) {
                var ban_id = (int)reader["id"];
                reader.Close();
                connection.Close();

                //retira o ban se expirado
                RemoveBannedIP(ban_id);
                return false;
            }

            reader.Close();
            connection.Close();
            return true;
        }

        /// <summary>
        /// Atualiza o status do ban (normalmente usado para remoção).
        /// </summary>
        /// <param name="banID"></param>
        private static void RemoveBannedIP(int banID) {
            var connection = new MySQL().CreateConnection();
            var query = "DELETE from banned_ip WHERE id=?banID";
            var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("?banID", banID);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        /// <summary>
        /// Verifica se a conta de usuário existe.
        /// </summary>
        /// <param name="username">nome de usuário</param>
        /// <returns></returns>
        public static bool ExistAccount(string username) {
            var connection = new MySQL().CreateConnection();
            var query = "SELECT id FROM accounts WHERE account=?username";
            var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("?username", username);
            var reader = cmd.ExecuteReader();
            var tempvar = reader.Read();

            reader.Close();
            connection.Close();

            return tempvar;
        }

        /// <summary>
        /// Verifica a senha da conta.
        /// </summary>
        /// <param name="username">nome de usuário</param>
        /// <param name="password">senha de usuário</param>
        /// <returns></returns>
        public static bool ExistPassword(string username, string password) {
            var connection = new MySQL().CreateConnection();
            var query = "SELECT id FROM accounts WHERE account =?username AND password=?password";
            var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("?username", username);
            cmd.Parameters.AddWithValue("?password", Hash.Compute(password));
            var reader = cmd.ExecuteReader();
            var tempvar = reader.Read();

            reader.Close();
            connection.Close();

            return tempvar;
        }

        /// <summary>
        /// Atualiza o pin da conta.
        /// </summary>
        /// <param name="username">nome de usuário</param>
        /// <param name="password">pin de usuário</param>
        public static void UpdatePin(int accountID, string password) {
            var connection = new MySQL().CreateConnection();
            var query = "UPDATE accounts SET pin=?password WHERE id=?accountID";
            var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("?password", password);
            cmd.Parameters.AddWithValue("?accountID", accountID);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        /// <summary>
        /// Atualiza o contador de tentativas.
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="value"></param>
        public static void UpdatePinAttempt(int accountID, byte value) {
            var connection = new MySQL().CreateConnection();
            var query = "UPDATE accounts SET pin_attempt=?value WHERE id=?accountID";
            var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("?accountID", accountID);
            cmd.Parameters.AddWithValue("?value", value);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        /// <summary>
        /// Atualiza o valor caso o jogador esteja conectado.
        /// </summary>
        /// <param name="username">nome de usuário</param>
        /// <param name="updateValue"></param>
        public static void UpdateLoggedIn(int accountID, byte value) {
            var connection = new MySQL().CreateConnection();
            var query = "UPDATE accounts SET logged_in=?value WHERE id=?accountID";
            var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("?accountID", accountID);
            cmd.Parameters.AddWithValue("?value", value);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        /// <summary>
        /// Atualiza com a data do último acesso. 
        /// </summary>
        /// <param name="username"></param>
        public static void UpdateDateLasteLogin(int accountID) {
            var connection = new MySQL().CreateConnection();
            var query = "UPDATE accounts SET date_last_login=?date WHERE id=?accountID";
            var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("?date", DateTime.Now); //.ToString("yyyy/M/d hh:mm:ss")
            cmd.Parameters.AddWithValue("?accountID", accountID);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        /// <summary>
        /// Atualiza com o ip do último acesso.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="ip"></param>
        public static void UpdateLastIP(int accountID, string ip) {
            var connection = new MySQL().CreateConnection();
            var query = "UPDATE accounts SET last_ip=?ip, current_ip='' WHERE id=?accountID";
            var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("?ip", ip);
            cmd.Parameters.AddWithValue("?accountID", accountID);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        /// <summary>
        /// Atualiza com o ip do atual acesso.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="ip"></param>
        public static void UpdateCurrentIP(int accountID, string ip) {
            var connection = new MySQL().CreateConnection();
            var query = "UPDATE accounts SET current_ip=?ip WHERE id=?accountID";
            var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("?ip", ip);
            cmd.Parameters.AddWithValue("?accountID", accountID);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        /// <summary>
        /// Verifica se a conta está ativa.
        /// </summary>
        /// <param name="username">nome de usuário</param>
        /// <returns></returns>
        public static bool IsActive(string username) {
            var connection = new MySQL().CreateConnection();
            var query = "SELECT active FROM accounts WHERE account=?username";
            var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("?username", username);
            var reader = cmd.ExecuteReader();

            if (!reader.Read()) {
                reader.Close();
                connection.Close();
                return false;
            }

            var result = Convert.ToBoolean(reader["active"]);
            
            reader.Close();
            connection.Close();

            return result;
        }

        /// <summary>
        /// Atualiza a quantidade de cash.
        /// </summary>
        /// <param name="username">nome de usuário</param>
        /// <param name="value">valor</param>
        public static void UpdateCash(int accountID, int value) {
            var connection = new MySQL().CreateConnection();
            var query = "UPDATE accounts SET cash=?value WHERE id=?accountID";
            var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("?value", value);
            cmd.Parameters.AddWithValue("?accountID", accountID);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        /// <summary>
        /// Adiciona um novo serviço à conta de usuário.
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="serviceID"></param>
        /// <param name="days"></param>
        public static void InsertService(int accountID, int serviceID, int days) {
            var connection = new MySQL().CreateConnection();
            var query = "INSERT INTO account_service (account_id, service_id, start_time, end_time) VALUES (?accountID, ?serviceID, ?start_time, ?end_time)";
            var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("?accountID", accountID);
            cmd.Parameters.AddWithValue("?serviceID", serviceID);
            cmd.Parameters.AddWithValue("?start_time", DateTime.Now);
            cmd.Parameters.AddWithValue("?end_time", DateTime.Now.AddDays(days));
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}
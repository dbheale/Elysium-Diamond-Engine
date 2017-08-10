using System;
using Lidgren.Network;
using LoginServer.Common;
using LoginServer.Database;
using Elysium.Service;

namespace LoginServer.Server {
    public sealed class PlayerData {
        /// <summary>
        /// Referência da conexão.
        /// </summary>
        public NetConnection Connection { get; set; }

        /// <summary>
        /// IP de usuário.
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// ID de conexão em Hexadecimal.
        /// </summary>
        public string HexID { get; set; }

        /// <summary>
        /// ID de usuário.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Nome de usuário.
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// Nome de usuário temporario.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Senha de usuário.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Quantidade de tentativas de login.
        /// </summary>
        public byte LoginAttempt { get; set; }

        /// <summary>
        /// Quantidade de tentaivas com pin incorreto.
        /// </summary>
        public byte PinAttempt { get; set; }

        /// <summary>
        /// ID de idioma.
        /// </summary>
        public byte LanguageID { get; set; }

        /// <summary>
        /// Nível de acesso ao sistema.
        /// </summary>
        public byte AccessLevel { get; set; }

        /// <summary>
        /// Quantidade de cash.
        /// </summary>
        public int Cash { get; set; }

        /// <summary>
        /// Senha de personagens.
        /// </summary>
        public string Pin { get; set; }

        /// <summary>
        /// Ultima data de login.
        /// </summary>
        public DateTime LastLogin { get; set; }
      
        /// <summary>
        /// Pacote de serviços de usuário.
        /// </summary>
        public PlayerService Service { get; set; }

        /// <summary>
        /// Indica se está conectado em algum world server.
        /// </summary>
        public bool IsWorldConnected { get; set; }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="hexID"></param>
        /// <param name="ip"></param>
        public PlayerData(NetConnection connection, string hexID, string ip) {
            Connection = connection;
            HexID = hexID;
            IP = ip;
            Account = string.Empty;
            Password = string.Empty;
            Username = string.Empty;
            Service = new PlayerService();   
        }

        /// <summary>
        /// Verifica a lista de serviços e atualiza no DB.
        /// </summary>
        public void VerifyServices() {
            const byte expired = 1;
            var services = Service.GetServicesID();

            foreach (var serviceID in services) {
                if (Service.IsServiceExpired(serviceID)) {
                    AccountDB.UpdateService(ID, serviceID, expired);
                    Service.Remove(serviceID);
                }
            }
        }

        /// <summary>
        /// Limpa os dados para permitir um novo login.
        /// </summary>  
        public void Clear() {
            //não deve limpar o hexid e o ip, pois ainda é necessário na conexão.
            ID = 0;
            LoginAttempt = 0;
            Password = string.Empty;
            Account = string.Empty;
            Username = string.Empty;
            Service.Clear();
        }
    }
}
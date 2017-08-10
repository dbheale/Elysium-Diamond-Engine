using System;
using System.Drawing;
using Lidgren.Network;
using LoginServer.Database;
using LoginServer.Network;
using LoginServer.Common;
using Elysium.Logs;

namespace LoginServer.Server {
    public static partial class Authentication {
        /// <summary>
        /// Inicia o processo de login, verificando usuário, versão e checksum.
        /// </summary>
        /// <param name="hexID"></param>
        /// <param name="data"></param>
        public static void Login(PlayerData pData, NetIncomingMessage data) {
            // se o bloqueio de login estiver ativo, envia mensagem de erro para o cliente
            if (Configuration.IsLoginDisabled) {
                LoginPacket.Message(pData.Connection, (short)PacketList.LS_CL_Maintenance);
                return;
            }

            // verifica a versão do jogo; se invalido, envia mensagem de erro
            var version = data.ReadString();
            if (Configuration.Version.CompareTo(version) != 0) {
                LoginPacket.Message(pData.Connection, (short)PacketList.InvalidVersion);
                return;
            }

            // verifica o checksum do cliente; se invalido, envia mensagem de erro
            var checksum = data.ReadString();
            if (CheckSum.Enabled) {
                if (!CheckSum.Compare(version, checksum)) {
                    LoginPacket.Message(pData.Connection, (short)PacketList.CantConnectNow);
                    return;
                }
            }

            pData.Username = data.ReadString().ToLower(); //lê o nome de usuário em uma variavel temporaria para distinguir do 'account
            pData.Password = data.ReadString();             

            // verifica se o usuário está na lista de banidos, caso verdadeiro, envia mensagem de erro
            if (AccountDB.IsBanned(AccountDB.GetID(pData.Username))) {
                LoginPacket.Message(pData.Connection, (short)PacketList.AccountBanned);
                return;
            }

            // verifica se o nome existe no banco de dados, caso falso, envia a mensagem de erro
            if (!AccountDB.ExistAccount(pData.Username)) {
                LoginPacket.Message(pData.Connection, (short)PacketList.LS_CL_InvalidNamePass);
                return;
            }

            // verifica se o usuário está ativo, caso falso, envia mensagem de erro
            if (!AccountDB.IsActive(pData.Username)) { 
                LoginPacket.Message(pData.Connection, (short)PacketList.LS_CL_AccountDisabled);
                return;
            }

            //Envia mensagem para outros servidores para saber se há algum usuario com o mesmo nome online
            ConnectPacket.IsPlayerConnected(pData.Username);
        }

        /// <summary>
        /// Por fim, verifica a senha de usuário e garante acesso ao sistema.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="username"></param>
        public static void Login(bool result, string username) {
            var pData = FindByUsername(username);
  
            if (!result) { //se falso, verifica se o usuário está conectado no login server
                //Verifica se o usuário já está conectado, caso verdadeiro, envia mensagem de erro
                if (Authentication.IsConnected(pData.Username)) {
                    pData.LoginAttempt++;
                    TryingToAccess(pData);
                    return;
                }
            }
            else {
                pData.LoginAttempt++;
                TryingToAccess(pData);
                return;
            }

            //Verifica se os campos estão corretos, caso falso, envia mensagem de erro
            if (!AccountDB.ExistPassword(pData.Username, pData.Password)) {
                LoginPacket.Message(pData.Connection, (short)PacketList.LS_CL_InvalidNamePass);
                return;
            }

            //muda o nome de usuario para o campo oficial de usuario e limpar o campo temporario
            pData.Account = pData.Username;
            pData.Username = string.Empty;

            Log.Write($"User Login: {pData.Account} {pData.IP} {pData.HexID}", Color.Black); 

            //carrega as informações da conta
            AccountDB.LoadAccountData(pData);
            AccountDB.LoadAccountService(pData);

            //Verifica as tentativas de PIN e reseta se necessário
            CheckPinAttemptTime(pData);

            //remove os serviços expirados
            pData.VerifyServices();

            AccountDB.UpdateDateLasteLogin(pData.ID);
            AccountDB.UpdateCurrentIP(pData.ID, pData.IP); 
            AccountDB.UpdateLoggedIn(pData.ID, 1);  //1 = ativo

            //envia a lista de servidores e muda a tela no cliente
            LoginPacket.ServerList(pData.Connection);
            LoginPacket.GameState(pData.Connection, GameState.Server);   
        }

        /// <summary>
        /// Verifica se o tempo expirou e reseta o número de tentativas.
        /// </summary>
        /// <param name="pData"></param>
        private static void CheckPinAttemptTime(PlayerData pData) {
            //obtem a quantidade total de minutos desde o último login
            var minutes = DateTime.Now.Subtract(pData.LastLogin).TotalMinutes;
            
            //se exceder o limite, reseta
            if (Math.Round(minutes) >= Configuration.PinCheckTime) {
                pData.PinAttempt = 0;
                AccountDB.UpdatePinAttempt(pData.ID, 0);
            }     
        }

        /// <summary>
        /// Verifica o número de tentativas e envia mensagens de erro.
        /// </summary>
        /// <param name="pData"></param>
        public static void TryingToAccess(PlayerData pData) {               
            // se realizar 3 tentativas de login, desconecta o usuário que já está logado e permite que o novo se conecte
            if (pData.LoginAttempt >= Constants.MaxAttempt) {

                // desconecta o usuario em todos os servidores, (se houver)
                ConnectPacket.DisconnectPlayer(pData.Username);

                // desconecta o usuario no servidor de login (se houver) pelo cliente
                var cPlayer = Authentication.FindByAccount(pData.Username);

                if (cPlayer != null) { 
                    LoginPacket.Message(cPlayer.Connection, (short)PacketList.Disconnect);
                }

                // se conectado ao login server, limpa os dados do usuario conectado na lista para o novo login
                if (Authentication.IsConnected(pData.Username)) {
                    Authentication.FindByAccount(pData.Username)?.Clear();
                }                

                // reseta o contador
                pData.LoginAttempt = 0;

                // envia mensagem que o usuário já está conectado
                LoginPacket.Message(pData.Connection, (short)PacketList.LS_CL_AlreadyLoggedIn);
            }
            else {
                // envia mensagem que o usuário já está conectado
                LoginPacket.Message(pData.Connection, (short)PacketList.LS_CL_AlreadyLoggedIn);
            }
        }

        /// <summary>
        /// Limpa os dados de usuário para voltar a tela de login
        /// </summary>
        /// <param name="index"></param>
        public static void BackToLoginScreen(PlayerData pData) {
            AccountDB.UpdateLastIP(pData.ID, pData.IP);
            AccountDB.UpdateLoggedIn(pData.ID, 0); //0 = false

            pData.Clear();
        }
    }
}
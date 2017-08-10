using System.Drawing;
using Lidgren.Network;
using ConnectServer.Server;
using Elysium.Logs;

namespace ConnectServer.Network {
    /// <summary>
    /// Dados que são recebidos pelo login server enviados de outros servidores.
    /// </summary>
    public static class LoginData {
        /// <summary>
        /// Recebe os dados do usuário e direciona para o servidor escolhido.
        /// </summary>
        /// <param name="msg"></param>
        public static void ReceivePlayerData(NetIncomingMessage msg) {
            var pData = new PlayerData();
            int worldID;
            int service;

            pData.HexID = msg.ReadString();
            pData.Account = msg.ReadString();
            pData.AccountID = msg.ReadInt32();
            pData.LanguageID = msg.ReadByte();
            pData.AccessLevel = msg.ReadByte();
            pData.Cash = msg.ReadInt32();
            pData.Pin = msg.ReadString();
            pData.PinAttempt = msg.ReadByte();
            worldID = msg.ReadInt32();
            service = msg.ReadInt32();

            for (var n = 0; n < service; n++) {
                pData.Service.Add(msg.ReadString());
            }

            Log.Write($"Data from login server account: {pData.Account} {pData.HexID}", Color.Black);

            WorldPacket.PlayerLogin(pData, worldID);
        }

        /// <summary>
        /// Verifica se o usuário está conectado em algum servidor.
        /// </summary>
        /// <param name="msg"></param>
        public static void IsUserConnected(NetIncomingMessage msg) {
            var account = msg.ReadString();
            var user = Authentication.FindUserByAccount(account);
            var result = false;

            if (user == null) {
                result = false;
            }
            else {
                result = (user?.AccountID == 0) ? false : true;
            }

            LoginPacket.ConnectedResult(msg.SenderConnection, result, account);
        }

        /// <summary>
        /// Realiza a desconexão do usuário nos servidores.
        /// </summary>
        /// <param name="msg"></param>
        public static void DisconnectPlayer(NetIncomingMessage msg) {
            var account = msg.ReadString();
            var user = Authentication.FindUserByAccount(account);

            if (user == null) {
                return;
            }

            Authentication.RemoveAccount(user.AccountID);
            LoginPacket.DisconnectPlayer(user.AccountID);         
        }

        /// <summary>
        /// Atualiza o PIN do usuário.
        /// </summary>
        /// <param name="msg"></param>
        public static void UpdateUserPin(NetIncomingMessage msg) {
            var id = msg.ReadInt32();
            var pin = msg.ReadString();

            LoginPacket.UpdatePin(id, pin);
        }

        /// <summary>
        /// Atualiza o número de tentativas PIN.
        /// </summary>
        /// <param name="msg"></param>
        public static void UpdateUserPinAttempt(NetIncomingMessage msg) {
            var id = msg.ReadInt32();
            var value = msg.ReadByte();

            LoginPacket.UpdatePinAttempt(id, value);
        }

        /// <summary>
        /// Bloqueia o usuário por determinado tempo.
        /// </summary>
        /// <param name="msg"></param>
        public static void UpdateUserBan(NetIncomingMessage msg) {
            var id = msg.ReadInt32();
            var minutes = msg.ReadInt16();
            var reason = msg.ReadString();

            LoginPacket.UpdateBanAccount(id, minutes, reason);
        }

        /// <summary>
        /// Altera o cash do usuário.
        /// </summary>
        /// <param name="msg"></param>
        public static void UpdateUserCash(NetIncomingMessage msg) {
            var id = msg.ReadInt32();
            var value = msg.ReadInt32();

            LoginPacket.UpdateCash(id, value);
        }

        /// <summary>
        /// Indica que o usuário se desconectou.
        /// </summary>
        /// <param name="msg"></param>
        public static void UpdateUserDisconnect(NetIncomingMessage msg) {
            var id = msg.ReadInt32();
            var username = msg.ReadString();
            var ip = msg.ReadString();

            Authentication.RemoveAccount(id);

            LoginPacket.UpdateUserDisconnect(id, ip);
        }

        /// <summary>
        /// Indica que o usuário conectou ao world server.
        /// </summary>
        /// <param name="msg"></param>
        public static void UpdateUserStatus(NetIncomingMessage msg) {
            var accountID = msg.ReadInt32();
            var username = msg.ReadString();
            var server = Authentication.FindByConnection(msg.SenderConnection);
            int worldID = 0;

            if (server != null) {
                worldID = server.ID;
            }

            Authentication.AddAccount(accountID, username, worldID);

            LoginPacket.UpdateUserConnected(accountID);
        }

        /// <summary>
        /// Adiciona um novo serviço à conta de usuário.
        /// </summary>
        /// <param name="msg"></param>
        public static void InsertUserService(NetIncomingMessage msg) {
            var accountID = msg.ReadInt32();
            var serviceID = msg.ReadInt32();
            var days = msg.ReadInt32();

            LoginPacket.InsertUserService(accountID, serviceID, days);
        }
    }
}
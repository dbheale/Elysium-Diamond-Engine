using WorldServer.Common;
using WorldServer.Server;
using Lidgren.Network;

namespace WorldServer.Network {
    public static class LoginPacket {
        /// <summary>
        /// Envia a resposta para o login server se o usuario foi encontrado.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="value"></param>
        /// <param name="username"></param>
        public static void ConnectedResult(NetConnection connection, bool value, string username) {
            var buffer = WorldNetwork.CreateMessage();
            buffer.Write((short)PacketList.LS_WS_IsPlayerConnected);
            buffer.Write(value);
            buffer.Write(username);

            WorldNetwork.SendDataTo(connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Adiciona um novo serviço à conta de usuário.
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="serviceID"></param>
        /// <param name="days"></param>
        public static void InsertUserService(int accountID, int serviceID, int days) {
            var pData = Authentication.FindByAccountID(Configuration.LoginID);

            if (pData == null) return;

            var buffer = WorldNetwork.CreateMessage(14);
            buffer.Write((short)PacketList.WS_LS_InsertService);
            buffer.Write(accountID);
            buffer.Write(serviceID);
            buffer.Write(days);
            WorldNetwork.SendDataTo(pData.Connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Envia a mensagem, confirmar a conexão do usuário.
        /// </summary>
        /// <param name="accountID"></param>
        public static void UpdateUserConnected(int accountID) {
            var pData = Authentication.FindByAccountID(Configuration.LoginID);

            if (pData == null) return;

            var buffer = WorldNetwork.CreateMessage(6);
            buffer.Write((short)PacketList.WS_LS_UpdateUserStatus);
            buffer.Write(accountID);
            WorldNetwork.SendDataTo(pData.Connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Envia a mensagem que o usuario foi desconectado.
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="ip"></param>
        public static void UpdateUserDisconnect(int accountID, string ip) {
            var pData = Authentication.FindByAccountID(Configuration.LoginID);

            if (pData == null) return;

            var buffer = WorldNetwork.CreateMessage();
            buffer.Write((short)PacketList.WS_LS_UpdateDisconnect);
            buffer.Write(accountID);
            buffer.Write(ip);
            WorldNetwork.SendDataTo(pData.Connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Atualiva o cash do usuário na DB.
        /// </summary>
        /// <param name="value"></param>
        public static void UpdateCash(int accountID, int value) {
            var pData = Authentication.FindByAccountID(Configuration.LoginID);

            if (pData == null) return;

            var buffer = WorldNetwork.CreateMessage(10);
            buffer.Write((short)PacketList.WS_LS_UpdateCash);
            buffer.Write(accountID);
            buffer.Write(value);
            WorldNetwork.SendDataTo(pData.Connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Atualiza o PIN do usuário.
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="pin"></param>
        public static void UpdatePin(int accountID, string pin) {
            var pData = Authentication.FindByAccountID(Configuration.LoginID);

            if (pData == null) return;

            var buffer = WorldNetwork.CreateMessage();
            buffer.Write((short)PacketList.WS_LS_UpdatePin);
            buffer.Write(accountID);
            buffer.Write(pin);
            WorldNetwork.SendDataTo(pData.Connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Atualiza o número de tentativas do usuário.
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="attempt"></param>
        public static void UpdatePinAttempt(int accountID, byte attempt) {
            var pData = Authentication.FindByAccountID(Configuration.LoginID);

            if (pData == null) return;

            var buffer = WorldNetwork.CreateMessage(7);
            buffer.Write((short)PacketList.WS_LS_UpdatePinAttempt);
            buffer.Write(accountID);
            buffer.Write(attempt);
            WorldNetwork.SendDataTo(pData.Connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Bloqueia um usuário.
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="minutes"></param>
        /// <param name="reason"></param>
        public static void UpdateBanAccount(int accountID, short minutes, string reason) {
            var pData = Authentication.FindByAccountID(Configuration.LoginID);

            if (pData == null) return;

            var buffer = WorldNetwork.CreateMessage(8);
            buffer.Write((short)PacketList.WS_LS_UpdateBan);
            buffer.Write(accountID);
            buffer.Write(minutes);
            buffer.Write(reason);
            WorldNetwork.SendDataTo(pData.Connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }
    }
}

using Lidgren.Network;
using ConnectServer.Server;

namespace ConnectServer.Network {
    /// <summary>
    /// Dados que são enviados para o login server.
    /// </summary>
    public static class LoginPacket {
        /// <summary>
        /// Envia a resposta para o login server se o usuario foi encontrado.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="value"></param>
        /// <param name="username"></param>
        public static void ConnectedResult(NetConnection connection, bool value, string username) {
            var buffer = NetworServer.CreateMessage();
            buffer.Write((short)PacketList.LS_WS_IsPlayerConnected);
            buffer.Write(value);
            buffer.Write(username);

            NetworServer.SendDataTo(connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Desconecta o usuário em todos os servidores.
        /// </summary>
        /// <param name="username"></param>
        public static void DisconnectPlayer(int accountID) {
            var buffer = NetworServer.CreateMessage(6);
            buffer.Write((short)PacketList.CS_DisconnectPlayer);
            buffer.Write(accountID);
            NetworServer.SendDataToAll(buffer, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Adiciona um novo serviço à conta de usuário.
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="serviceID"></param>
        /// <param name="days"></param>
        public static void InsertUserService(int accountID, int serviceID, int days) {
            var server = Authentication.FindByName("Login Server");

            if (server == null) return;

            var buffer = NetworServer.CreateMessage(14);
            buffer.Write((short)PacketList.WS_LS_InsertService);
            buffer.Write(accountID);
            buffer.Write(serviceID);
            buffer.Write(days);
            NetworServer.SendDataTo(server.Connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Envia a mensagem, confirmar a conexão do usuário.
        /// </summary>
        /// <param name="accountID"></param>
        public static void UpdateUserConnected(int accountID) {
            var server = Authentication.FindByName("Login Server");

            if (server == null) return;

            var buffer = NetworServer.CreateMessage(6);
            buffer.Write((short)PacketList.WS_LS_UpdateUserStatus);
            buffer.Write(accountID);
            NetworServer.SendDataTo(server.Connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Envia a mensagem que o usuario foi desconectado.
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="ip"></param>
        public static void UpdateUserDisconnect(int accountID, string ip) {
            var server = Authentication.FindByName("Login Server");

            if (server == null) return;

            var buffer = NetworServer.CreateMessage(6);
            buffer.Write((short)PacketList.WS_LS_UpdateDisconnect);
            buffer.Write(accountID);
            buffer.Write(ip);
            NetworServer.SendDataTo(server.Connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Atualiva o cash do usuário na DB.
        /// </summary>
        /// <param name="value"></param>
        public static void UpdateCash(int accountID, int value) {
            var server = Authentication.FindByName("Login Server");

            if (server == null) return;

            var buffer = NetworServer.CreateMessage(10);
            buffer.Write((short)PacketList.WS_LS_UpdateCash);
            buffer.Write(accountID);
            buffer.Write(value);
            NetworServer.SendDataTo(server.Connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Atualiza o PIN do usuário.
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="pin"></param>
        public static void UpdatePin(int accountID, string pin) {
            var server = Authentication.FindByName("Login Server");

            if (server == null) return;

            var buffer = NetworServer.CreateMessage(6);
            buffer.Write((short)PacketList.WS_LS_UpdatePin);
            buffer.Write(accountID);
            buffer.Write(pin);
            NetworServer.SendDataTo(server.Connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Atualiza o número de tentativas do usuário.
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="attempt"></param>
        public static void UpdatePinAttempt(int accountID, byte attempt) {
            var server = Authentication.FindByName("Login Server");

            if (server == null) return;

            var buffer = NetworServer.CreateMessage(7);
            buffer.Write((short)PacketList.WS_LS_UpdatePinAttempt);
            buffer.Write(accountID);
            buffer.Write(attempt);
            NetworServer.SendDataTo(server.Connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Bloqueia um usuário.
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="minutes"></param>
        /// <param name="reason"></param>
        public static void UpdateBanAccount(int accountID, short minutes, string reason) {
            var server = Authentication.FindByName("Login Server");

            if (server == null) return;

            var buffer = NetworServer.CreateMessage(8);
            buffer.Write((short)PacketList.WS_LS_UpdateBan);
            buffer.Write(accountID);
            buffer.Write(minutes);
            buffer.Write(reason);
            NetworServer.SendDataTo(server.Connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }
    }
}
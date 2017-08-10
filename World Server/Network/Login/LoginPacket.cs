namespace WorldServer.Network {
    public static class LoginPacket {
        /// <summary>
        /// Adiciona um novo serviço à conta de usuário.
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="serviceID"></param>
        /// <param name="days"></param>
        public static void InsertUserService(int accountID, int serviceID, int days) {
            var buffer = NetworkClient.CreateMessage(14);
            buffer.Write((short)PacketList.WS_LS_InsertService);
            buffer.Write(accountID);
            buffer.Write(serviceID);
            buffer.Write(days);
            NetworkClient.SendData(buffer);
        }

        /// <summary>
        /// Envia a mensagem, confirmar a conexão do usuário.
        /// </summary>
        /// <param name="accountID"></param>
        public static void UpdateUserStatus(int accountID, string account) {
            var buffer = WorldNetwork.CreateMessage(6);
            buffer.Write((short)PacketList.WS_LS_UpdateUserStatus);
            buffer.Write(accountID);
            buffer.Write(account);
            NetworkClient.SendData(buffer);
        }

        /// <summary>
        /// Envia a mensagem que o usuario foi desconectado.
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="ip"></param>
        public static void UpdateUserDisconnect(int accountID, string account, string ip) {
            var buffer = WorldNetwork.CreateMessage();
            buffer.Write((short)PacketList.WS_LS_UpdateDisconnect);
            buffer.Write(accountID);
            buffer.Write(account);
            buffer.Write(ip);
            NetworkClient.SendData(buffer);
        }

        /// <summary>
        /// Atualiva o cash do usuário na DB.
        /// </summary>
        /// <param name="value"></param>
        public static void UpdateCash(int accountID, int value) {
            var buffer = WorldNetwork.CreateMessage(10);
            buffer.Write((short)PacketList.WS_LS_UpdateCash);
            buffer.Write(accountID);
            buffer.Write(value);
            NetworkClient.SendData(buffer);
        }

        /// <summary>
        /// Atualiza o PIN do usuário.
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="pin"></param>
        public static void UpdatePin(int accountID, string pin) {
            var buffer = WorldNetwork.CreateMessage();
            buffer.Write((short)PacketList.WS_LS_UpdatePin);
            buffer.Write(accountID);
            buffer.Write(pin);
            NetworkClient.SendData(buffer);
        }

        /// <summary>
        /// Atualiza o número de tentativas do usuário.
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="attempt"></param>
        public static void UpdatePinAttempt(int accountID, byte attempt) {
            var buffer = WorldNetwork.CreateMessage(7);
            buffer.Write((short)PacketList.WS_LS_UpdatePinAttempt);
            buffer.Write(accountID);
            buffer.Write(attempt);
            NetworkClient.SendData(buffer);
        }

        /// <summary>
        /// Bloqueia um usuário.
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="minutes"></param>
        /// <param name="reason"></param>
        public static void UpdateBanAccount(int accountID, short minutes, string reason) {
            var buffer = WorldNetwork.CreateMessage(8);
            buffer.Write((short)PacketList.WS_LS_UpdateBan);
            buffer.Write(accountID);
            buffer.Write(minutes);
            buffer.Write(reason);
            NetworkClient.SendData(buffer);
        }
    }
}
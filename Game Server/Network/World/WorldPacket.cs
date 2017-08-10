using GameServer.Common;

namespace GameServer.Network {
    public static class WorldPacket {
        /// <summary>
        /// Envia a mensagem, confirmar a conexão do usuário.
        /// </summary>
        /// <param name="accountID"></param>
        public static void UpdatePlayerStatus(int accountID) {
            var buffer = GameNetwork.CreateMessage(6);
            buffer.Write((short)PacketList.GS_WS_UpdateUserStatus);
            buffer.Write(accountID);
            buffer.Write(Configuration.ID);
            NetworkClient.SendData(buffer);
        }

        /// <summary>
        /// Envia a quantidade de conexões.
        /// </summary>
        public static void UpdateUserCount() {           
            var buffer = GameNetwork.CreateMessage(6);
            buffer.Write((short)PacketList.GS_WS_UpdateUserCount);
            buffer.Write(GameNetwork.ConnectionsCount);
            NetworkClient.SendData(buffer);
        }
    }
}
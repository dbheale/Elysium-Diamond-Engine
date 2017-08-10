using GameServer.Common;

namespace GameServer.Network {
    public static class ConnectPacket {
        /// <summary>
        /// Envia a identificação para o connect server.
        /// </summary>
        public static void ConnectionID() {
            var buffer = NetworkClient.CreateMessage(17);
            buffer.Write((short)PacketList.CS_ServerID);
            buffer.Write(Configuration.ID);
            buffer.Write("Game Server");
            NetworkClient.SendData(buffer);
        }
    }
}
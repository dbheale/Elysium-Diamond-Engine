using WorldServer.Common;

namespace WorldServer.Network {
    public static class ConnectPacket {
        /// <summary>
        /// Envia a identificação para o connect server.
        /// </summary>
        public static void ConnectionID() {
            var buffer = NetworkClient.CreateMessage(18);
            buffer.Write((short)PacketList.CS_ServerID);
            buffer.Write(Configuration.ID);
            buffer.Write("World Server");
            NetworkClient.SendData(buffer);
        }

        /// <summary>
        /// Envia os dados para selecionar o servidor.
        /// </summary>
        /// <param name="account"></param>
        /// <param name="regionID"></param>
        public static void SelectGameServer(int accountID, int regionID) {
            var buffer = NetworkClient.CreateMessage(10);
            buffer.Write((short)PacketList.CS_SelectServer);
            buffer.Write(accountID);
            buffer.Write(regionID);

            NetworkClient.SendData(buffer);
        }
    }
}
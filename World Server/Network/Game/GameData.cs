using Lidgren.Network;

namespace WorldServer.Network {

    public class GameData {
        public static void HandleData(int index, NetIncomingMessage msg) {
            if (msg.LengthBytes < 4) { return; }
            // Packet Header //
            var header = msg.ReadInt32();

            // Check Packet Header Number //
            if (header < 0) { return; }

            // Handle Incoming Message //
            switch (header) {
                case (int)PacketList.None: break;
                case (int)PacketList.CL_WS_SendPlayerHexID: GamePacket.HexID(index); break;
            }
        }
    }
}

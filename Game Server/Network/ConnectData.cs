using GameServer.Server;
using Lidgren.Network;

namespace GameServer.Network {
    public static class ConnectData {
        public static void HandleData(NetIncomingMessage msg) {
            if (msg.LengthBytes < 2) { return; }

            var header = msg.ReadInt16();

            if (header < 0) { return; }

            switch(header) {
                case (short)PacketList.WS_GS_UserLogin: Authentication.AddHexID(msg); break;
            }
        }
    }
}
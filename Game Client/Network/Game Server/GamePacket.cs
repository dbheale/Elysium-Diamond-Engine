using System;
using Elysium_Diamond.Common;
using Elysium_Diamond.DirectX;
using Lidgren.Network;

namespace Elysium_Diamond.Network {
    public static class GamePacket {
        /// <summary>
        /// Envia o hexid para o game server.
        /// </summary>
        public static void GameServerHexID() {
            var buffer = NetworkSocket.CreateMessage();
            buffer.Write((int)PacketList.Client_GameServer_SendPlayerHexID);
            buffer.Write(Configuration.HexID);
            NetworkSocket.SendData(SocketEnum.GameServer, buffer, NetDeliveryMethod.Unreliable);
        }

        /// <summary>
        /// Envia o movimento do personagem.
        /// </summary>
        /// <param name="dir"></param>
        public static void PlayerMove(EngineCharacter.Direction dir) {
            var buffer = NetworkSocket.CreateMessage();
            buffer.Write((int)PacketList.Client_GameServer_PlayerMove);
            buffer.Write(EngineCharacter.GetDir(dir));
            NetworkSocket.SendData(SocketEnum.GameServer, buffer, NetDeliveryMethod.Unreliable);
        }

        public static void RequestPing() {
            var buffer = NetworkSocket.CreateMessage();
            buffer.Write((int)PacketList.Ping);

            NetworkSocket.SendData(SocketEnum.GameServer, buffer, NetDeliveryMethod.Unreliable);
            Common.Configuration.PingStart = Environment.TickCount;
        }
    }
}

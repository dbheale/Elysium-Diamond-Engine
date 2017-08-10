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
            buffer.Write((short)PacketList.Client_GameServer_SendPlayerHexID);
            buffer.Write(Configuration.HexID);
            NetworkSocket.SendData(SocketEnum.GameServer, buffer);
        }

        /// <summary>
        /// Envia o movimento do personagem.
        /// </summary>
        /// <param name="dir"></param>
        public static void PlayerMove(EngineCharacter.Direction dir) {
            var buffer = NetworkSocket.CreateMessage();
            buffer.Write((short)PacketList.Client_GameServer_PlayerMove);
            buffer.Write(EngineCharacter.GetDir(dir));
            NetworkSocket.SendData(SocketEnum.GameServer, buffer);
        }

        public static void RequestPing() {
            var buffer = NetworkSocket.CreateMessage();
            buffer.Write((short)PacketList.Ping);

            NetworkSocket.SendData(SocketEnum.GameServer, buffer);
            Configuration.PingStart = Environment.TickCount;
        }

        public static void IncrementStat(byte stat) {
            var buffer = NetworkSocket.CreateMessage();
            buffer.Write((short)PacketList.CL_GS_IncrementStat);
            buffer.Write(stat);

            NetworkSocket.SendData(SocketEnum.GameServer, buffer);
        }
    }
}

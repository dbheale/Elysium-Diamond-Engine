using GameServer.Server;
using GameServer.Common;
using GameServer.GameLogic;
using GameServer.Player;
using GameServer.Administrator;
using Lidgren.Network;

namespace GameServer.Network {
    public class GameData {
        public static void HandleData(NetConnection connection, NetIncomingMessage msg) {
            if (msg.LengthBytes < 2) { return; }

            var msgType = msg.ReadInt16();

            // Check Packet Number
            if (msgType < 0) { return; }

            switch (msgType) {
                case (short)PacketList.None: break;
                case (short)PacketList.Ping: Ping(connection); break;
                case (short)PacketList.Client_GameServer_SendPlayerHexID: Authentication.ReceiveHexID(connection, msg.ReadString()); break;
                case (short)PacketList.Client_GameServer_PlayerMove: PlayerMove(connection, msg.ReadByte()); break;
                case (short)PacketList.CL_GS_IncrementStat: IncrementStat(connection, msg.ReadByte()); break;
                case (short)PacketList.CL_GS_UseInventoryItem: InventoryData.UseInventoryItem(connection, msg); break;
                case (short)PacketList.CL_GS_SwapInventoryItem: InventoryData.SwapInventoryItem(connection, msg); break;
                case (short)PacketList.CL_GS_UnequipItem: InventoryData.UnequipItem(connection, msg); break;
                case (short)PacketList.CL_GS_AdminTool: Command.ParseCommand(connection, msg); break;
            }
        }

        public static void Ping(NetConnection connection) {
            var buffer = GameNetwork.CreateMessage();
            buffer.Write((short)PacketList.Ping);
            GameNetwork.SendDataTo(connection, buffer, NetDeliveryMethod.ReliableUnordered);
        }

        /// <summary>
        /// Envia o movimento do jogador pelo mapa.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="dir"></param>
        public static void PlayerMove(NetConnection connection, byte dir) {
            var pData = Authentication.FindByConnection(connection);

            pData.Direction = dir;

            switch (dir) {
                case (int)Direction.Up:
                    pData.Y--;
                    break;
                case (int)Direction.Down:
                    pData.Y++;
                    break;
                case (int)Direction.Left:
                    pData.X--;
                    break;
                case (int)Direction.Right:
                    pData.X++;
                    break;
            }

            Maps.MapManager.FindMapByID(pData.WorldID).SendPlayerMove(pData, dir);
        }


        public static void IncrementStat(NetConnection connection, byte stat) {
            var pData = Authentication.FindByConnection(connection);

            if (pData.StatPoints == 0) { return; }

            switch (stat) {
                case 0:
                    pData.Strenght++;
                    break;
                case 1:
                    pData.Dexterity++;
                    break;
                case 2:
                    pData.Agility++;
                    break;
                case 3:
                    pData.Constitution++;
                    break;
                case 4:
                    pData.Intelligence++;
                    break;
                case 5:
                    pData.Wisdom++;
                    break;
                case 6:
                    pData.Will++;
                    break;
                case 7:
                    pData.Mind++;
                    break;
            }

            pData.StatPoints--;
            CharacterLogic.UpdateCharacterStats(pData);
            CharacterLogic.SendCharacterStats(pData);
        }
    }
}

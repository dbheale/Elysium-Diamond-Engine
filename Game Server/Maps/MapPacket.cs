using System;
using Lidgren.Network;
using GameServer.Network;
using GameServer.Server;

namespace GameServer.Maps {
    public partial class Map {
        /// <summary>
        /// Envia o npc do mapa para o jogador.
        /// </summary>
        /// <param name="connection"></param>
        public static void SendNpc(PlayerData pData) {
            var npcData = MapManager.FindMapByID(pData.WorldID).Npcs;

            var buffer = GameNetwork.CreateMessage();
            buffer.Write((int)PacketList.GameServer_SendNpc);
            buffer.Write(npcData.Count);

            foreach(var npc in npcData) {
                buffer.Write(npc.ID);
                buffer.Write(npc.UniqueID);
                buffer.Write(npc.HP);
                buffer.Write(npc.MaxHP);
                buffer.Write(npc.X);
                buffer.Write(npc.Y);
                buffer.Write((byte)npc.Direction);
            }

            GameNetwork.SendDataTo(pData.Connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Envia o movimento do npc para o mapa.
        /// </summary>
        /// <param name="pData"></param>
        /// <param name="npc"></param>
        public void SendNpcMove(MapNpcData npc) {
            var buffer = GameNetwork.CreateMessage();
            buffer.Write((int)PacketList.GameServer_NpcMove);
            buffer.Write(npc.UniqueID);
            buffer.Write((byte)npc.Direction);

            SendDataToAll(buffer);
        }

        /// <summary>
        /// Envia dados para todos do mapa.
        /// </summary>
        /// <param name="msg"></param>
        public void SendDataToAll(NetOutgoingMessage msg) {
            var saved = new byte[msg.LengthBytes];
            Buffer.BlockCopy(msg.Data, 0, saved, 0, msg.LengthBytes);
            var savedBitLength = msg.LengthBits;

            foreach (var playerID in CharacterID) {
                var pData = Authentication.FindByCharacterID(playerID);

                var another = GameNetwork.CreateMessage();
                another.Write(saved);
                another.LengthBits = savedBitLength;

                GameNetwork.SendDataTo(pData.Connection, another, NetDeliveryMethod.ReliableOrdered);
            }
        }


        public static void SendPlayerMapMove(NetConnection connection, int playerID, byte direction) {
            var buffer = GameNetwork.CreateMessage();
            buffer.Write((int)PacketList.GameServer_Client_PlayerMapMove);
            buffer.Write(playerID);
            buffer.Write(direction);

            GameNetwork.SendDataTo(connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        public static void SendMapPlayer(NetConnection connection, int playerID, string name, short sprite, byte direction, short x, short y) {
            var buffer = GameNetwork.CreateMessage();
            buffer.Write((int)PacketList.GameServer_Client_GetMapPlayer);
            buffer.Write(playerID);
            buffer.Write(name);
            buffer.Write(sprite);
            buffer.Write(direction);
            buffer.Write(x);
            buffer.Write(y);

            GameNetwork.SendDataTo(connection, buffer, NetDeliveryMethod.ReliableOrdered);

        }

        public static void RemovePlayerOnMap(NetConnection connection, int playerID) {
            var buffer = GameNetwork.CreateMessage();
            buffer.Write((int)PacketList.GameServer_Client_RemovePlayerFromMap);
            buffer.Write(playerID);

            GameNetwork.SendDataTo(connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }
    }
}

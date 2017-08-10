using System;
using Lidgren.Network;
using WorldServer.Server;
using WorldServer.Common;

namespace WorldServer.Network {
    public static class WorldPacket {
        /// <summary>
        /// Envia o cash para o client.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="cash"></param>
        public static void SendCash(NetConnection connection, int cash) {
            var buffer = WorldNetwork.CreateMessage(10);
            buffer.Write((short)PacketList.WS_CL_Cash);
            buffer.Write(cash);
            WorldNetwork.SendDataTo(connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Envia a mensagem da programação de exclusão.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="time"></param>
        /// <param name="slot"></param>
        public static void AlertDeleteCharacter(NetConnection connection, short time, DateTime date, byte slot) {
            var timespan = DateTime.Now.Subtract(date);
            var buffer = WorldNetwork.CreateMessage(10);

            buffer.Write((short)PacketList.WS_CL_AlertDeleteCharacter);
            buffer.Write(time);
            buffer.Write(slot);
            buffer.Write((byte)(timespan.Hours * -1)); //multiplica por -1 para transformar em positivo
            buffer.Write((byte)(timespan.Minutes * -1));
            buffer.Write((byte)(timespan.Seconds * -1));

            WorldNetwork.SendDataTo(connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Remove
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="slot"></param>
        public static void RemovePendingDelete(NetConnection connection, byte slot) {
            var buffer = WorldNetwork.CreateMessage(5);
            buffer.Write((short)PacketList.WS_CL_RemovePendingDelete);
            buffer.Write(slot);

            WorldNetwork.SendDataTo(connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Envia o pedido de hexid para o cliente.
        /// </summary>
        /// <param name="index"></param>
        public static void NeedHexID(NetConnection connection) {
            var buffer = WorldNetwork.CreateMessage(4);
            buffer.Write((short)PacketList.WS_CL_NeedPlayerHexID);
            WorldNetwork.SendDataTo(connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Envia mensagens sem conteúdo.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public static void Message(string hexID, int value) {
            var buffer = WorldNetwork.CreateMessage(4);
            buffer.Write(value);
            WorldNetwork.SendDataTo(hexID, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Envia mensagens sem conteudo.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="value"></param>
        public static void Message(NetConnection connection, int value) {
            var buffer = WorldNetwork.CreateMessage(4);
            buffer.Write(value);
            WorldNetwork.SendDataTo(connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Envia a alteração de 'GameState'.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public static void GameState(string hexID, GameState state) {
            var buffer = WorldNetwork.CreateMessage(5);
            buffer.Write((short)PacketList.ChangeGameState);
            buffer.Write((byte)state);
            WorldNetwork.SendDataTo(hexID, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Envia os dados básico dos personagens.
        /// </summary>
        /// <param name="hexID"></param>
        public static void PreLoad(PlayerData pData) {
            TimeSpan date;

            var buffer = WorldNetwork.CreateMessage();
            buffer.Write((short)PacketList.WS_CL_CharacterPreLoad);

            for (var n = 0; n < Constants.MaxCharacter; n++) {
                buffer.Write(pData.Character[n].Name);
                buffer.Write(pData.Character[n].Class);
                buffer.Write(pData.Character[n].Sprite);
                buffer.Write(pData.Character[n].Level);
                buffer.Write(pData.Character[n].PendingDeletion);

                if (pData.Character[n].PendingDeletion) {
                    date = DateTime.Now.Subtract(pData.Character[n].DeletionTime);

                    //multiplica por -1 para transformar em positivo
                    buffer.Write((byte)(date.Hours * -1));
                    buffer.Write((byte)(date.Minutes * -1));
                    buffer.Write((byte)(date.Seconds * -1));
                }
            }
 
            WorldNetwork.SendDataTo(pData.HexID, buffer, NetDeliveryMethod.ReliableOrdered);
        }
    
        /// <summary>
        /// Envia os dados do game server para o cliente.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="hexID"></param>
        public static void GameServerData(NetConnection connection, string ip, int port) {
            var buffer = WorldNetwork.CreateMessage();
            buffer.Write((short)PacketList.WS_CL_GameServerData);
            buffer.Write(ip);
            buffer.Write(port);

            WorldNetwork.SendDataTo(connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }            
    }
}
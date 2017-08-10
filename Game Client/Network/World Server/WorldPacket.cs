using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Elysium_Diamond.Common;
using Elysium_Diamond.DirectX;
using Lidgren.Network;

namespace Elysium_Diamond.Network {
    public class WorldPacket {
        /// <summary>
        /// Envia o HexID 
        /// </summary>
        public static void WorldServerHexID() {
            var buffer = NetworkSocket.CreateMessage();
            buffer.Write((short)PacketList.CL_WS_SendPlayerHexID);
            buffer.Write(Configuration.HexID);

            NetworkSocket.SendData(SocketEnum.WorldServer, buffer);
        }

        public static void RequestPreLoad() {
            var buffer = NetworkSocket.CreateMessage(4);
            buffer.Write((short)PacketList.CL_WS_RequestPreLoad);
            NetworkSocket.SendData(SocketEnum.WorldServer, buffer);
        }

        public static void DeleteCharacter(byte slot) {
            var buffer = NetworkSocket.CreateMessage();
            buffer.Write((short)PacketList.CL_WS_DeleteCharacter);
            buffer.Write(slot);
            NetworkSocket.SendData(SocketEnum.WorldServer, buffer);
        }

        public static void CreateCharacter(byte gender, int classe, byte slot, int sprite, string name) {
            var buffer = NetworkSocket.CreateMessage();
            buffer.Write((short)PacketList.CL_WS_CreateCharacter);
            buffer.Write(name);
            buffer.Write(slot);
            buffer.Write(classe);
            buffer.Write(gender);
            buffer.Write(sprite);
            NetworkSocket.SendData(SocketEnum.WorldServer, buffer);
        }

        public static void StartGame(byte slot) {
            var buffer = NetworkSocket.CreateMessage();
            buffer.Write((short)PacketList.CL_WS_EnterInGame);
            buffer.Write(slot);
            NetworkSocket.SendData(SocketEnum.WorldServer, buffer);
        }

        public static void GlobalChat(string text) {
            var buffer = NetworkSocket.CreateMessage();
            buffer.Write((short)PacketList.CL_WS_ChatMessage);
            buffer.Write((byte)4); //msg type, global = 4
            buffer.Write((byte)2); //msg channel, trade = 2
            buffer.Write(string.Empty.Trim()); //user target, in case of private message
            buffer.Write(text.Trim()); // message
            NetworkSocket.SendData(SocketEnum.WorldServer, buffer);
        }

        /// <summary>
        /// Envia o pin para o servidor
        /// </summary>
        /// <param name="state"></param>
        /// <param name="pin"></param>
        /// <param name="new_pin"></param>
        public static void SendPin(byte state, string pin, string new_pin = "") {
            var buffer = NetworkSocket.CreateMessage();
            buffer.Write((short)PacketList.CL_WS_SendPin);
            buffer.Write(state);
            buffer.Write(pin);
            buffer.Write(new_pin);
            NetworkSocket.SendData(SocketEnum.WorldServer, buffer);
        }

        /// <summary>
        /// Realiza a requisição dos items da loja.
        /// </summary>
        /// <param name="category"></param>
        public static void RequestItems(CashShopItemCategory category, byte page) {
            var buffer = NetworkSocket.CreateMessage(5);
            buffer.Write((short)PacketList.CL_WS_RequestPageItems);
            buffer.Write((byte)category);
            buffer.Write(page);
            NetworkSocket.SendData(SocketEnum.WorldServer, buffer);
        }

        /// <summary>
        /// Realiza a requisição dos detalhes do item.
        /// </summary>
        /// <param name="cashitemID"></param>
        public static void RequestItemInformation(int cashitemID) {
            var buffer = NetworkSocket.CreateMessage(8);
            buffer.Write((short)PacketList.CL_WS_RequestItemInformation);
            buffer.Write(cashitemID);
            NetworkSocket.SendData(SocketEnum.WorldServer, buffer);
        }

        /// <summary>
        /// Realiza o pedido de compra.
        /// </summary>
        /// <param name="cashitemID"></param>
        /// <param name="quantity"></param>
        public static void RequestBuyItem(int cashitemID, short quantity, string name) {
            var buffer = NetworkSocket.CreateMessage(10);
            buffer.Write((short)PacketList.CL_WS_RequestBuyItem);
            buffer.Write(cashitemID);
            buffer.Write(quantity);
            buffer.Write(name);
            NetworkSocket.SendData(SocketEnum.WorldServer, buffer);
        }

        /// <summary>
        /// Realiza o pedido dos emails.
        /// </summary>
        public static void RequestMailTitle() {
            var buffer = NetworkSocket.CreateMessage(4);
            buffer.Write((short)PacketList.CL_WS_RequestMailTitle);
            NetworkSocket.SendData(SocketEnum.WorldServer, buffer);
        }

        public static void RequestMail(int id) {
            var buffer = NetworkSocket.CreateMessage(8);
            buffer.Write((short)PacketList.CL_WS_RequestMail);
            buffer.Write(id);
            NetworkSocket.SendData(SocketEnum.WorldServer, buffer);
        }
    }
}

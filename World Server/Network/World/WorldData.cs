using Lidgren.Network;
using WorldServer.Server;
using WorldServer.WorldChat;
using WorldServer.BlackMarket;
using WorldServer.Pin;

namespace WorldServer.Network {
    public static class WorldData {
        public static void HandleData(NetConnection connection, NetIncomingMessage msg) {
            if (msg.LengthBytes < 2) { return; }

            var header = msg.ReadInt16();

            switch (header) {
                case (short)PacketList.CL_WS_SendPlayerHexID: Authentication.ReceivedHexID(connection, msg.ReadString()); break;
                case (short)PacketList.CL_WS_DeleteCharacter: CharacterFunction.DeleteCharacter(connection, msg.ReadByte()); break;
                case (short)PacketList.CL_WS_CreateCharacter: CharacterFunction.CreateCharacter(connection, msg); break;
                case (short)PacketList.CL_WS_RequestPreLoad: CharacterFunction.RequestPreLoad(connection); break;
                case (short)PacketList.CL_WS_EnterInGame: PlayerLogin.StartGame(connection, msg.ReadByte()); break;
                case (short)PacketList.CL_WS_ChatMessage: ChatData.ReceiveChatMessage(connection, msg); break;
                case (short)PacketList.CL_WS_SendPin: PinData.VerifyPinState(connection, msg); break;
                case (short)PacketList.CL_WS_RequestPageItems: CashShopData.RequestItems(connection, msg); break;
                case (short)PacketList.CL_WS_RequestItemInformation: CashShopData.RequestItemInformation(connection, msg); break;
                case (short)PacketList.CL_WS_RequestBuyItem: CashShopData.RequestBuyItem(connection, msg); break;
            }
        }
    }
}
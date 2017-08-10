using WorldServer.Common;
using WorldServer.Network;
using Lidgren.Network;

namespace WorldServer.BlackMarket {
    public static class CashShopPacket {
        /// <summary>
        /// Envia os items da página selecionada.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="category"></param>
        /// <param name="page"></param>
        public static void SendItems(NetConnection connection, ItemCategory category, byte page) {
            var page_count = CashShop.PageCount(category);
            var itemsID = CashShop.PageItems(category, page);
            byte lenght = (byte)itemsID.Length;

            var buffer = WorldNetwork.CreateMessage();
            buffer.Write((short)PacketList.WS_CL_SendPageItems);
            buffer.Write((byte)page_count);
            buffer.Write(lenght);

            for (var n = 0; n < lenght; n++) {
                var item = CashShop.FindByID(itemsID[n]);

                buffer.Write(item.CashItemID);
                buffer.Write(item.ID);
                buffer.Write(item.Quantity); 
                buffer.Write(item.Price); 
                buffer.Write(item.Durability); 
                buffer.Write(item.Enchant); 
                buffer.Write(item.Tradeable);
                buffer.Write(item.SoulBound); 
                for (var i = 0; i < Constants.MaxItemSocket; i++)
                    buffer.Write(item.Socket[i]);
            }

            WorldNetwork.SendDataTo(connection, buffer, NetDeliveryMethod.ReliableOrdered);       
        }

        /// <summary>
        /// Envia informações sobre o item.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="cashitemID"></param>
        public static void SendItemDetail(NetConnection connection, int cashitemID) {
            var item = CashShop.FindByID(cashitemID);
            if (item == null) return;

            var buffer = WorldNetwork.CreateMessage();
            buffer.Write((short)PacketList.WS_CL_SendItemInformation);
            buffer.Write(item.GiftEnabled);
            buffer.Write(item.BuyLimit);
            buffer.Write(item.ExpireDays);
            WorldNetwork.SendDataTo(connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Envia o estado da compra.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="status"></param>
        public static void SendPurchaseStatus(NetConnection connection, ItemPurchaseStatus status) {
            var buffer = WorldNetwork.CreateMessage();
            buffer.Write((short)PacketList.WS_CL_PurchaseStatus);
            buffer.Write((byte)status);
            WorldNetwork.SendDataTo(connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }
    }
}
using System.Drawing;
using WorldServer.Server;
using WorldServer.Database;
using WorldServer.Network;
using Lidgren.Network;
using Elysium.Logs;

namespace WorldServer.BlackMarket {
    public static class CashShopData {
        /// <summary>
        /// Envia os items de acordo com a categoria e a página.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="msg"></param>
        public static void RequestItems(NetConnection connection, NetIncomingMessage msg) {
            var category = (ItemCategory)msg.ReadByte();
            var page = msg.ReadByte();

            if (category >= ItemCategory.Total)  return;

            CashShopPacket.SendItems(connection, category, page);
        }

        /// <summary>
        /// Pedido de detalhe do item.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="msg"></param>
        public static void RequestItemInformation(NetConnection connection, NetIncomingMessage msg) {
            CashShopPacket.SendItemDetail(connection, msg.ReadInt32());
        }

        /// <summary>
        /// Realiza a compra do item.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="msg"></param>
        public static void RequestBuyItem(NetConnection connection, NetIncomingMessage msg) {
            var pData = Authentication.FindByConnection(connection);
            var cashitemID = msg.ReadInt32();
            var quantity = msg.ReadInt16();
            var name = msg.ReadString();
            var item = CashShop.FindByID(cashitemID);

            if (quantity > item.BuyLimit) quantity = item.BuyLimit;

            if (item == null) {
                CashShopPacket.SendPurchaseStatus(connection, ItemPurchaseStatus.InvalidItem);
                Log.Write($"Attempt to buy an invalid item {pData.AccountID} {pData.Account}", Color.Crimson);
                return;
            }

            if (pData.Cash < (item.Price * quantity)) {
                CashShopPacket.SendPurchaseStatus(connection, ItemPurchaseStatus.NotEnoughCash);
                return;
            }

            if (!CharacterDB.Exist(name)) {
                CashShopPacket.SendPurchaseStatus(connection, ItemPurchaseStatus.InvalidName);
                return;
            }

            Log.Write($"Purchased item CashID: {item.CashItemID} by {pData.Account} {pData.AccountID}", Color.RoyalBlue);
            Log.Write($"Cash value ID: {pData.Account} {pData.AccountID} {pData.Cash}", Color.RoyalBlue);

            pData.Cash -= (item.Price * quantity);
            LoginPacket.UpdateCash(pData.AccountID, pData.Cash);
            WorldPacket.SendCash(connection, pData.Cash);

            Log.Write($"Cash value updated ID: {pData.Account} {pData.AccountID} {pData.Cash}", Color.RoyalBlue);

            CashShopPacket.SendPurchaseStatus(connection, ItemPurchaseStatus.SuccessPurchase);

            InsertMailItem(pData, name, new CashItem(item) { Quantity = quantity });
        
            //envia msg para o jogador indicando que o item está no mail.
        }

        /// <summary>
        /// Envia o item para a caixa de mensagens.
        /// </summary>
        /// <param name="pData"></param>
        /// <param name="target"></param>
        /// <param name="item"></param>
        private static void InsertMailItem(PlayerData pData, string target, CashItem item) {
            var result = string.Compare(pData.CharacterName, target, true);

            var senderID = pData.CharacterID;
            var sender = (result == 0) ? CashShop.Sender : pData.CharacterName;
            var recipientID = CharacterDB.ID(target);
            var title = (result == 0) ? CashShop.PurchaseTitle : CashShop.GiftTitle;
            var message = (result == 0) ? CashShop.PurchaseMessage : CashShop.GiftMessage.Replace("'Name'", pData.CharacterName);
            long currency = 0;
            byte express = 1;
                    
            MailDB.Insert(senderID, sender, recipientID, title, message, currency, express, item);
        }
    }
}
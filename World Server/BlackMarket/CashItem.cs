using WorldServer.GameItem;

namespace WorldServer.BlackMarket {
    public sealed class CashItem : Item, IItem {
        /// <summary>
        /// ID do item na lista de categorias.
        /// </summary>
        public int CashItemID { get; set; }
 
        /// <summary>
        /// Valor do item em cash.
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Quantidade máxima que pode ser comprada de uma vez.
        /// </summary>
        public short BuyLimit { get; set; }

        public ItemCategory Category { get; set; }

        /// <summary>
        /// Ativa ou desativa o envio de presentes.
        /// </summary>
        public bool GiftEnabled { get; set; }

        public CashItem() : base() {

        }

        /// <summary>
        /// Copia a informação de um item já criado.
        /// </summary>
        /// <param name="item"></param>
        public CashItem(CashItem item) {
            CashItemID = item.CashItemID;
            Price = item.Price;
            BuyLimit = item.BuyLimit;
            Category = item.Category;
            GiftEnabled = item.GiftEnabled;
            ID = item.ID;
            Quantity = item.Quantity;
            Enchant = item.Enchant;
            Durability = item.Durability;
            Socket = item.Socket;
            Expire = item.Expire;
            ExpireDays = item.ExpireDays;
            ExpireDate = item.ExpireDate;
            SoulBound = item.SoulBound;
            Tradeable = item.Tradeable;
        }
    }
}
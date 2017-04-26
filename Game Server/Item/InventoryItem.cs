using System;

namespace GameServer.Item {
    public class InventoryItem : IInventory {
        const int EXPIRED = 1;
        /// <summary>
        /// ID de item.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// ID serial.
        /// </summary>
        public string UniqueID { get; set; }

        /// <summary>
        /// Quantidade.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Nivel de encantamento.
        /// </summary>
        public int Enchant { get; set; }

        /// <summary>
        /// ID de elemento
        /// </summary>
        public int Element { get; set; }

        /// <summary>
        /// Durabilidade.
        /// </summary>
        public int Durability { get; set; }

        /// <summary>
        /// ID de socket.
        /// </summary>
        public string Slots { get; set; }

        /// <summary>
        /// Indica se o item pode expirar.
        /// </summary>
        public byte Expire { get; set; }

        /// <summary>
        /// Tempo limite
        /// </summary>
        public DateTime ExpireTime { get; set; }

        /// <summary>
        /// Ligado ao personagem.
        /// </summary>
        public byte SoulBound { get; set; }

        /// <summary>
        /// Construtor.
        /// </summary>
        public InventoryItem() {
            UniqueID = string.Empty;
            Slots = string.Empty;
        }

        /// <summary>
        /// Construtor.
        /// </summary>
        /// <param name="item"></param>
        public InventoryItem(InventoryItem item) {
            ID = item.ID;
            UniqueID = item.UniqueID;
            Quantity = item.Quantity;
            Enchant = item.Enchant;
            Element = item.Element;
            Durability = item.Durability;
            Slots = item.Slots;
            Expire = item.Expire;
            ExpireTime = item.ExpireTime;
            SoulBound = item.SoulBound;
        }

        /// <summary>
        /// Verifica se o item já expirou.
        /// </summary>
        /// <returns></returns>
        public bool IsExpired() {
            if (Expire == 0) return false;
            return DateTime.Now.CompareTo(ExpireTime) == EXPIRED ? true : false;
        }
    }
}

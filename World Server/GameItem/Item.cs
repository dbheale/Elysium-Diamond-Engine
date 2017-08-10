using System;
using WorldServer.Common;

namespace WorldServer.GameItem {
    public class Item : IItem {
        /// <summary>
        /// ID de item.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Quantidade.
        /// </summary>
        public short Quantity { get; set; }

        /// <summary>
        /// Nivel de encantamento.
        /// </summary>
        public short Enchant { get; set; }

        /// <summary>
        /// Durabilidade.
        /// </summary>
        public short Durability { get; set; }

        /// <summary>
        /// ID de socket.
        /// </summary>
        public short[] Socket { get; set; }

        /// <summary>
        /// Indica se o item pode expirar.
        /// </summary>
        public byte Expire { get; set; }

        /// <summary>
        /// Dias para o item expirar
        /// </summary>
        public int ExpireDays { get; set; }

        /// <summary>
        /// Tempo limite
        /// </summary>
        public DateTime ExpireDate { get; set; }

        /// <summary>
        /// Indica se o item pode ser negociado.
        /// </summary>
        public byte Tradeable { get; set; }

        /// <summary>
        /// Ligado ao personagem.
        /// </summary>
        public byte SoulBound { get; set; }

        /// <summary>
        /// Construtor.
        /// </summary>
        public Item() {
            Socket = new short[Constants.MaxItemSocket] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        }

        /// <summary>
        /// Construtor.
        /// </summary>
        /// <param name="item"></param>
        public Item(Item item) {
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

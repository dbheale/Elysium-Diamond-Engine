using System;
using GameServer.Common;

namespace GameServer.GameItem {
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
        /// Tempo limite
        /// </summary>
        public DateTime ExpireDate { get; set; }

        /// <summary>
        /// Ligado ao personagem.
        /// </summary>
        public byte SoulBound { get; set; }

        /// <summary>
        /// Item negociável.
        /// </summary>
        public byte Tradeable { get; set; }

        public Item() {
            Socket = new short[Constant.MAX_ITEM_SLOT] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        }

        public Item(Item item)  {
            ID = item.ID;
            Quantity = item.Quantity;
            Enchant = item.Enchant;
            Durability = item.Durability;
            Socket = item.Socket;
            Expire = item.Expire;
            ExpireDate = item.ExpireDate;
            SoulBound = item.SoulBound;
        }

        /// <summary>
        /// Limpa os dados do item.
        /// </summary>
        public void Clear() {
            ID = 0;
            Quantity = 0;
            Enchant = 0;
            Durability = 0;
            Tradeable = 0;
            SoulBound = 0;
            Expire = 0;

            for (int n = 0; n < Constant.MAX_ITEM_SLOT; n++) Socket[n] = 0;
        }
    }
}
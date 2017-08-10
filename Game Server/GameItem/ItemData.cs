using GameServer.Common;

namespace GameServer.GameItem {
    public sealed class ItemData {
        /// <summary>
        /// ID de item.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Armazenável.
        /// </summary>
        public byte Storable { get; set; }

        /// <summary>
        /// Utilizável.
        /// </summary>
        public byte Useable { get; set; }

        /// <summary>
        /// Quantidade máxima de estocagem.
        /// </summary>
        public short Package { get; set; }

        /// <summary>
        /// Quantidade de mãos que um item ocupa.
        /// </summary>
        public byte Handed { get; set; }

        /// <summary>
        /// Level do item.
        /// </summary>
        public short Level { get; set; }

        /// <summary>
        /// Valor do item.
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Durabilidade.
        /// </summary>
        public short Durability { get; set; }

        /// <summary>
        /// Raridade.
        /// </summary>
        public ItemRarity Rarity { get; set; } 

        /// <summary>
        /// Tipo de item.
        /// </summary>
        public ItemType Type { get; set; }

        /// <summary>
        /// Alcance do ataque.
        /// </summary>
        public byte AttackRange { get; set; }

        /// <summary>
        /// Atributos do item.
        /// </summary>
        public int[] Stat { get; set; } = new int[Constant.MAX_STATS];

        /// <summary>
        /// Aumenta o stat do item de acordo com o level.
        /// </summary>
        public int[] StatLevel { get; set; } = new int[Constant.MAX_STATS];
    }
}
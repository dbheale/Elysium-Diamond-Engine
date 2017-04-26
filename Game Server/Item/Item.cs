using GameServer.ClasseData;

namespace GameServer.Item {
    public class Item : StatsBase {
        /// <summary>
        /// ID de item.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Versão do projeto.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Armazenável.
        /// </summary>
        public bool Storable { get; set; }

        /// <summary>
        /// Utilizável.
        /// </summary>
        public bool Useable { get; set; }

        /// <summary>
        /// Quantidade máxima de estocagem.
        /// </summary>
        public short Package { get; set; }

        /// <summary>
        /// Quantidade de mãos que um item ocupa.
        /// </summary>
        public byte Handed { get; set; }

        /// <summary>
        /// Sprite do item.
        /// </summary>
        public short Sprite { get; set; }

        /// <summary>
        /// Valor do item.
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Durabilidade.
        /// </summary>
        public int Durability { get; set; }

        /// <summary>
        /// Raridade.
        /// </summary>
        public ItemRarity Rarity { get; set; } 

        /// <summary>
        /// Alcance do ataque.
        /// </summary>
        public byte AttackRange { get; set; }

        /// <summary>
        /// Tipo de item.
        /// </summary>
        public ItemType Type { get; set; }
    }
}



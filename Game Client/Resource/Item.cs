using System.IO;
using System.Collections.Generic;
using System;

namespace Elysium_Diamond.Resource {
    public class Item {
        /// <summary>
        /// ID do item.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// ID do ícone.
        /// </summary>
        public int IconID { get; set; }

        public string Name { get; set; }
        public short Durability { get; set; }
        public short Enchant { get; set; }
        public short Quantity { get; set; }
        public int Level { get; set; }
        public ItemType Type { get; set; }
        public ItemRarity Rarity { get; set; }
        public byte Hand { get; set; }
        public byte SoulBound { get; set; }
        public byte Tradeable { get; set; }

        /// <summary>
        /// ID de socket.
        /// </summary>
        public short[] Slot { get; set; }

        /// <summary>
        /// Indica se o item pode expirar.
        /// </summary>
        public byte Expire { get; set; }

        /// <summary>
        /// Tempo limite
        /// </summary>
        public DateTime ExpireDate { get; set; }

        /// <summary>
        /// Lista de stats.
        /// </summary>
        public List<string> Text { get; set; }
        
        public Item() {
            Slot = new short[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            Text = new List<string>();
        }

        public Item(Item item) {
            ID = item.ID;
            IconID = item.IconID;
            Name = item.Name;
            Durability = item.Durability;
            Enchant = item.Enchant;
            Quantity = item.Quantity;
            Level = item.Level;
            Type = item.Type;
            Rarity = item.Rarity;
            Hand = item.Hand;
            SoulBound = item.SoulBound;
            Tradeable = item.Tradeable;
            Slot = item.Slot;
            Expire = item.Expire;
            ExpireDate = item.ExpireDate;

        }

        /// <summary>
        /// Limpa os dados do item.
        /// </summary>
        public void Clear() {
            ID = 0;
            IconID = 0;
            Name = string.Empty;
            Durability = 0;
            Enchant = 0;
            Quantity = 0;
            Level = 0;
            SoulBound = 0;
            Tradeable = 0;
            Expire = 0;
            for (int n = 0; n < 9; n++) Slot[n] = 0;
        }

        /// <summary>
        /// Abre o arquivo lê e retorna um novo item.
        /// </summary>
        /// <param name="binaryfile"></param>
        /// <returns></returns>
        public static Item Read(string binaryfile) {
            if (!File.Exists(binaryfile)) return null;

            var item = new Item();

            using (FileStream file = new FileStream(binaryfile, FileMode.Open, FileAccess.Read)) {
                BinaryReader reader = new BinaryReader(file);

                item.ID = reader.ReadInt32();
                item.IconID = reader.ReadInt32();
                item.Name = reader.ReadString();
                item.Durability = reader.ReadInt16();
                item.Level = reader.ReadInt32();
                item.Type = (ItemType)reader.ReadByte();
                item.Rarity = (ItemRarity)reader.ReadByte();
                item.Hand = reader.ReadByte();
                item.SoulBound = Convert.ToByte(reader.ReadBoolean());
                item.Tradeable = Convert.ToByte(reader.ReadBoolean());

                //16 max_stats
                for (var i = 1; i <= 16; i++) {
                    item.Text.Add(reader.ReadString());
                }

                reader.Close();
            }

            return item;
        }
    }
}

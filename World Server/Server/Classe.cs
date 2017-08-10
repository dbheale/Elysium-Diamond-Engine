using System.Drawing;
using System.Collections.Generic;
using WorldServer.Common;
using WorldServer.GameItem;
using Elysium;

namespace WorldServer.Server {
    public sealed class Classe {
        public int Level { get; set; }
        public int Strenght { get; set; }
        public int Dexterity { get; set; }
        public int Agility { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Will { get; set; }
        public int Mind { get; set; }
        public int Points { get; set; }

        /// <summary>
        /// ID de classe.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// ID de icnremento
        /// </summary>
        public int IncrementID { get; set; }

        /// <summary>
        /// Lista de classes.
        /// </summary>
        public static List<Classe> Classes { get; set; }

        /// <summary>
        /// Items de inicialização do personagem.
        /// </summary>
        public Item[] EquippedItems { get; set; } = new Item[Constants.MaxEquippedItem];

        public Item[] Inventory { get; set; } = new Item[Constants.MaxInventory];

        /// <summary>
        /// Construtor
        /// </summary>
        public Classe() {
            for (var index = 0; index < Constants.MaxEquippedItem; index++) {
                EquippedItems[index] = new Item();
            }

            for (var index = 0; index < Constants.MaxInventory; index++) {
                Inventory[index] = new Item();
            }
        }

        /// <summary>
        /// Procura pelo indice da classe na lista.
        /// </summary>
        /// <param name="classeID"></param>
        /// <returns></returns>
        public static int FindClasseIndexByID(int classeID) {
            for(var index = 0; index < Classes.Count; index++) {
                if (Classes[index].ID == classeID) return index;
            }

            return -1;
        }

        /// <summary>
        /// Limpa todos os dados.
        /// </summary>
        private void ClearData() {
            Classes.Clear();
            Classes = null;

            EquippedItems = null;         
        }

        /// <summary>
        /// Limpa todos os dados.
        /// </summary>
        public static void Clear() {
            foreach(var classe in Classes) { classe.ClearData(); }
        }

        /// <summary>
        /// Adiciona um item a classe.
        /// </summary>
        /// <param name="classeID"></param>
        /// <param name="item"></param>
        /// <param name="type"></param>
        public static void SetEquippedItem(int classeID, Item item, EquipSlotType slot) {
            var index = FindClasseIndexByID(classeID);

            if (index == -1) return;

            Classes[index].EquippedItems[(int)slot] = new Item(item);
        }

        /// <summary>
        /// Adiciona um item ao inventário.
        /// </summary>
        /// <param name="classeID"></param>
        /// <param name="invslot"></param>
        /// <param name="item"></param>
        public static void AddInventoryItem(int classeID, int slot, Item item) {
            var index = FindClasseIndexByID(classeID);

            if (index == -1) return;

            Classes[index].Inventory[slot] = new Item(item);
        }
    }
}
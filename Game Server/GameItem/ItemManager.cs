using System.Collections.Generic;
using System.Linq;

namespace GameServer.GameItem {
    public static class ItemManager {
        /// <summary>
        /// Hashset de items.
        /// </summary>
        private static HashSet<ItemData> items = new HashSet<ItemData>();

        /// <summary>
        /// Adiciona um novo item à lista.
        /// </summary>
        /// <param name="item"></param>
        public static void Add(ItemData item) {
            items.Add(item);
        }

        /// <summary>
        /// Obtem um item da lista.
        /// </summary>
        /// <param name="itemID"></param>
        /// <returns></returns>
        public static ItemData FindByID(int itemID) {
            if (itemID == 0) return null;

            var find_item = from item in items
                               where item.ID.CompareTo(itemID) == 0
                               select item;
            return find_item.FirstOrDefault();
        }
        
        /// <summary>
        /// Quantidade de items.
        /// </summary>
        /// <returns></returns>
        public static int Count() {
            return items.Count;
        }

        /// <summary>
        /// Remove todos os items do conjunto.
        /// </summary>
        public static void Clear() {
            items.Clear();
        }
    }
}
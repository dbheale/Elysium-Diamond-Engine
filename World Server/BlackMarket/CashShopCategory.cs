using System.Collections.Generic;
using WorldServer.Common;

namespace WorldServer.BlackMarket {
    public sealed class CashShopCategory {
        /// <summary>
        /// Lista de ID.
        /// </summary>
        private List<int> items { get; set; } = new List<int>();

        /// <summary>
        /// Adiciona um novo ID à lista.
        /// </summary>
        /// <param name="itemID"></param>
        public void AddID(int itemID) {
            items.Add(itemID);
        }

        /// <summary>
        /// Obtém a lista de ID's de acordo com a página.
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public int[] PageItems(int page) {
            List<int> itemsID = new List<int>();

            // obtem 6 items por página para exibir na loja
            // término do laço 
            var max = page * Constants.MaxPageItem;

            // início do laço
            var min = (page * Constants.MaxPageItem) - Constants.MaxPageItem;

            if (items.Count <= max) max = items.Count;
            
            for (var index = min; index < max; index++) { 
                itemsID.Add(items[index]);
            }
     
            return itemsID.ToArray();
        }

        /// <summary>
        /// Retorna a quantidade páginas.
        /// </summary>
        /// <returns></returns>
        public int PageCount() {
            var result_value = items.Count / Constants.MaxPageItem;
            var result_mod = items.Count % Constants.MaxPageItem;

            //se sobrar items, aumenta uma página.
            if (result_mod > 0) result_value++;

            return result_value;
        }
    }
}
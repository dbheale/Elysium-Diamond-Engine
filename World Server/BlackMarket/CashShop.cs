using System.Collections.Generic;
using System.Linq;
using WorldServer.Common;

namespace WorldServer.BlackMarket {
    public sealed class CashShop {
        /// <summary>
        /// Ativa ou desativa a loja.
        /// </summary>
        public static bool Enabled { get; set; }

        /// <summary>
        /// Lista de items da loja.
        /// </summary>
        private static HashSet<CashItem> items { get; set; } = new HashSet<CashItem>();

        /// <summary>
        /// Lista somente com os ID's dos items.
        /// </summary>
        private static List<CashShopCategory> itemsID { get; set; } = new List<CashShopCategory>();

        /// <summary>
        /// Remetente da mensagem da compra.
        /// </summary>
        public static string Sender { get; set; }

        /// <summary>
        /// Título da mensagem da compra.
        /// </summary>
        public static string PurchaseTitle { get; set; }

        /// <summary>
        /// Corpo da mensagem da compra.
        /// </summary>
        public static string PurchaseMessage { get; set; }

        /// <summary>
        /// Título da mensagem da compra.
        /// </summary>
        public static string GiftTitle { get; set; }

        /// <summary>
        /// Corpo da mensagem quando o item é enviado como presente.
        /// </summary>
        public static string GiftMessage { get; set; }

        /// <summary>
        /// Inicializa as variáveis.
        /// </summary>
        /// <param name="category"></param>
        public static void Initialize() {
            for (var n = 0; n < Constants.MaxShopCategory; n++) {
                itemsID.Add(new CashShopCategory());
            }
        }

        /// <summary>
        /// Encontra um item pelo ID da loja.
        /// </summary>
        /// <param name="itemID"></param>
        /// <returns></returns>
        public static CashItem FindByID(int cashitemID) {
            var find_item = from item in items
                            where item.CashItemID.CompareTo(cashitemID) == 0
                             select item;

            return find_item.FirstOrDefault();
        }

        /// <summary>
        /// Adiciona um item à lista de items.
        /// </summary>
        /// <param name="item"></param>
        public static void AddItem(CashItem item) {
            items.Add(new CashItem(item));
            itemsID[(int)item.Category].AddID(item.CashItemID);
        }

        /// <summary>
        /// Obtém os ID's de item de acordo com a página.
        /// </summary>
        /// <param name="category"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public static int[] PageItems(ItemCategory category, int page) {
            return itemsID[(int)category].PageItems(page);
        }

        /// <summary>
        /// Retorna a quantidade páginas.
        /// </summary>
        /// <returns></returns>
        public static int PageCount(ItemCategory category) {
            return itemsID[(int)category].PageCount();
        }    

        /// <summary>
        /// Limpa todos os items.
        /// </summary>
        public static void Clear() {
            items.Clear();
            itemsID.Clear();
        }
    }
}
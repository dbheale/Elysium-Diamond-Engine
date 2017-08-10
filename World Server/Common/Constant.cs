namespace WorldServer.Common {
    public static class Constant {
        /// <summary>
        /// Valor para datas, expirado.
        /// </summary>
        public const byte Expired = 1;

        /// <summary>
        /// Quantidade de personagem.
        /// </summary>
        public const byte MaxCharacter = 4;

        /// <summary>
        /// Quantidade de (slots) items que podem ser equipados.
        /// </summary>
        public const byte MaxEquippedItem = 14;

        /// <summary>
        /// Quantidade de socket no item.
        /// </summary>
        public const byte MaxItemSocket = 9;

        /// <summary>
        /// Quantida de slots no inventário.
        /// </summary>
        public const byte MaxInventory = 56;

        /// <summary>
        /// Quantidade de stats.
        /// </summary>
        public const byte MaxStats = 8;

        /// <summary>
        /// Quantidade de items por página na loja.
        /// </summary>
        public const byte MaxPageItem = 6;

        /// <summary>
        /// Quantidade de categorias na loja.
        /// </summary>
        public const byte MaxShopCategory = 13;
    }
}
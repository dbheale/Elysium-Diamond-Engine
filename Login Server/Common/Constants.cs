namespace LoginServer.Common {
    public static class Constants {
        /// <summary>
        /// Quantidade máxima de tentativas de login.
        /// </summary>
        public const int MaxAttempt = 3;

        /// <summary>
        /// Limite de servidores.
        /// </summary>
        public const int MaxServer = 5;

        /// <summary>
        /// Indica se uma data já foi expirada.
        /// </summary>
        public const int Expired = 1;
    }
}
namespace WorldServer.Common {
    public static class Configuration {
        /// <summary>
        /// ID de world server.
        /// </summary>
        public static int ID { get; set; }

        /// <summary>
        /// Descoberta de conexão.
        /// </summary>
        public static string Discovery { get; set; }

        /// <summary>
        /// Nome do servidor.
        /// </summary>
        public static string WorldServerName { get; set; }

        /// <summary>
        /// Porta do servidor.
        /// </summary>
        public static int WorldServerPort { get; set; }

        /// <summary>
        /// Quantidade máxima de conexões.
        /// </summary>
        public static int MaximumConnections { get; set; }

        /// <summary>
        /// Sleep do loop principal.
        /// </summary>
        public static int Sleep { get; set; }

        /// <summary>
        /// Distribui os jogadores de acordo com a capacidade do servidor.
        /// </summary>
        public static bool AutoBalance { get; set; }

        /// <summary>
        /// Lista de Canal / Servidor.
        /// </summary>
        public static ServerData[] GameServer { get; set; } = new ServerData[Constant.MAX_SERVER];

        /// <summary>
        /// Permite a criação de personagens.
        /// </summary>
        public static bool CharacterCreation { get; set; }

        /// <summary>
        /// Permite a exclusão de personagens.
        /// </summary>
        public static bool CharacterDelete { get; set; }

        /// <summary>
        /// Level mínimo para exclusão.
        /// </summary>
        public static int CharacterDeleteMinLevel { get; set; }

        /// <summary>
        /// Level máximo para exclusão.
        /// </summary>
        public static int CharacterDeleteMaxLevel { get; set; }

    }
}
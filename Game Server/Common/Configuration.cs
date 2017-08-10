namespace GameServer.Common {
    public static class Configuration {
        /// <summary>
        /// ID do game server.
        /// </summary>
        public static int ID { get; set; }

        /// <summary>
        /// Nome do servidor.
        /// </summary>
        public static string GameServerName { get; set; }

        /// <summary>
        /// Server Port
        /// </summary>
        public static int GameServerPort { get; set; }

        /// <summary>
        /// Ip do connect server.
        /// </summary>
        public static string ConnectIp { get; set; }

        /// <summary>
        /// Porta do connect server.
        /// </summary>
        public static int ConnectPort { get; set; }

        /// <summary>
        /// Descoberta de conexão.
        /// </summary>
        public static string Discovery { get; set; }

        /// <summary>
        /// Quantidade máxima de conexões.
        /// </summary>
        public static int MaximumConnections { get; set; }

        /// <summary>
        /// Sleep do loop principal.
        /// </summary>
        public static int Sleep { get; set; }
    }
}
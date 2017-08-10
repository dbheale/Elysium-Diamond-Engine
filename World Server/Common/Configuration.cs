namespace WorldServer.Common {
    public static class Configuration {
        /// <summary>
        /// ID de world server.
        /// </summary>
        public static int ID { get; set; }

        /// <summary>
        /// Nome do servidor.
        /// </summary>
        public static string WorldServerName { get; set; }

        /// <summary>
        /// Porta do servidor.
        /// </summary>
        public static int WorldServerPort { get; set; }

        /// <summary>
        /// Descoberta de conexão.
        /// </summary>
        public static string Discovery { get; set; }

        /// <summary>
        /// Ip do connect server.
        /// </summary>
        public static string ConnectIp { get; set; }

        /// <summary>
        /// Porta do connect server.
        /// </summary>
        public static int ConnectPort { get; set; }

        /// <summary>
        /// Quantidade máxima de conexões.
        /// </summary>
        public static int MaxConnections { get; set; }

        /// <summary>
        /// Sleep do loop principal.
        /// </summary>
        public static int Sleep { get; set; }

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

        /// <summary>
        /// Ativa ou desativa o pin.
        /// </summary>
        public static bool Pin { get; set; }

        /// <summary>
        /// Quantidade máxima de tentavias de pin.
        /// </summary>
        public static byte PinMaxAttempt { get; set; }

        /// <summary>
        /// Tempo de bloqueio por erro de pin.
        /// </summary>
        public static short PinBannedTime { get; set; }
    }
}
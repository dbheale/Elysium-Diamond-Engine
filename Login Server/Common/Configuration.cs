using LoginServer.Server;

namespace LoginServer.Common {
    public static class Configuration {
        /// <summary>
        /// ID do servidor.
        /// </summary>  
        public static int ID { get; set; }

        /// <summary>
        /// Porta de conexão do servidor.
        /// </summary>
        public static int Port { get; set; }

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
        public static int MaxConnections { get; set; }

        /// <summary>
        /// Sleep do loop principal.
        /// </summary>
        public static int Sleep { get; set; }

        /// <summary>
        /// Desativa o login temporariamente.
        /// </summary>
        public static bool IsLoginDisabled { get; set; }

        /// <summary>
        /// Versão do cliente e servidor
        /// </summary>
        public static string Version { get; set; }

        /// <summary>
        /// Tempo de verificação do PIN.
        /// </summary>
        public static int PinCheckTime { get; set; }

        /// <summary>
        /// Lista de canal ou servidor.
        /// </summary>
        public static ServerData[] Server { get; set; } = new ServerData[Constants.MaxServer];
    }
}
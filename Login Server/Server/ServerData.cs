namespace LoginServer.Server {
    /// <summary>
    /// Dados de canal ou servidor.
    /// </summary>
    public struct ServerData {
        public bool Enabled { get; set; }

        /// <summary>
        /// Identificação do World Server.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// IP externo do World Server.
        /// </summary>
        public string WorldServerIP { get; set; }

        /// <summary>
        /// Somente usado quando os servidores estiverem em rede local.
        /// </summary>
        public string WorldServerLocalIP { get; set; }

        /// <summary>
        /// Porta de conexão.
        /// </summary>
        public int WorldServerPort { get; set; }

        /// <summary>
        /// Nome de identificação.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Região ou país.
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// Condições de canal ou servidor.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Mostra se o servidor está online.
        /// </summary>
        public bool Online { get; set; }
    }
}
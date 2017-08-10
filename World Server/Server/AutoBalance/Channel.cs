namespace WorldServer.Server {
    public sealed class Channel {
        /// <summary>
        /// ID do canal / game server.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// ID da região.
        /// </summary>
        public int RegionID { get; set; }

        /// <summary>
        /// IP externo para Game Server.
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// Somente usado quando os servidores estiverem em rede local.
        /// </summary>
        public string LocalIP { get; set; }

        /// <summary>
        /// Porta de servidor.
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Indica se o servidor está conectado.
        /// </summary>
        public bool Online { get; set; }

        /// <summary>
        /// Nome de identificação.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Capacidade de usuários.
        /// </summary>
        public int Capacity { get; set; }

        /// <summary>
        /// Usuários conectados.
        /// </summary>
        public int ConnectedUsers { get; set; }

        /// <summary>
        /// Limite de usuários (porcentagem).
        /// </summary>
        public byte Percentage { get; set; }

        /// <summary>
        /// Limite de usuários.
        /// </summary>
        public int Limit { get {
                return ((Capacity / 100) * Percentage);
            }
        }
        
        public Channel() {
            IP = string.Empty;
            LocalIP = string.Empty;
            Name = string.Empty;
        }
    }
}

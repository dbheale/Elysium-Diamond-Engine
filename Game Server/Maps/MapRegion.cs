namespace GameServer.Maps {
    public struct MapRegion {
        /// <summary>
        /// Identificação.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Ip do game server.
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// Porta do game server.
        /// </summary>
        public int Port { get; set; } 

        /// <summary>
        /// Início X da região do mapa.
        /// </summary>
        public short StartX { get; set; }

        /// <summary>
        /// Início Y da região do mapa.
        /// </summary>
        public short StartY { get; set; }

        /// <summary>
        /// Limite da região X.
        /// </summary>
        public short EndX { get; set; }

        /// <summary>
        /// Limite da região Y.
        /// </summary>
        public short EndY { get; set; }
    }
}

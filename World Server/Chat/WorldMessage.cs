namespace WorldServer.Chat {
    public struct WorldMessage {
        /// <summary>
        /// Tipo da mensagem.
        /// </summary>
        public MessageType Type { get; set; }

        /// <summary>
        /// Texto
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="msg"></param>
        public WorldMessage(string msg, MessageType type = MessageType.None) {
            Message = msg;
            Type = type;
        }
    }
}

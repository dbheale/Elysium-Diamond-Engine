namespace ConnectServer.Server {
    /// <summary>
    /// Armazena dados temporarios para consulta.
    /// </summary>
    public sealed class UserData {
        public int AccountID { get; set; }
        public string Account { get; set; }

        /// <summary>
        /// ID de servidor conectado.
        /// </summary>
        public int WorldID { get; set; }

        /// <summary>
        /// ID de servidor conectado.
        /// </summary>
        public int GameID { get; set; }

        public string HexID { get; set; }

        /// <summary>
        /// Indica que o usuário está trocando de canal.
        /// </summary>
        public bool MovingChannel { get; set; }

        /// <summary>
        /// ID de destino.
        /// </summary>
        public int TargetGameID { get; set; }

        public UserData(int accountID, string account, int worldID, int gameID) {
            AccountID = accountID;
            Account = account;
            WorldID = worldID;
            GameID = gameID;
        }
    }
}
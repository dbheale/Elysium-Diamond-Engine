using Elysium.Service;

namespace ConnectServer.Server {
    public sealed class PlayerData {
        /// <summary>
        /// ID de conexão em Hexadecimal.
        /// </summary>
        public string HexID { get; set; }

        /// <summary>
        /// ID de usuário.
        /// </summary>
        public int AccountID { get; set; }

        /// <summary>
        /// Nome de usuário.
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// Nome de usuário temporario.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Senha de usuário.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Quantidade de tentativas de login.
        /// </summary>
        public byte LoginAttempt { get; set; }

        /// <summary>
        /// Quantidade de tentaivas com pin incorreto.
        /// </summary>
        public byte PinAttempt { get; set; }

        /// <summary>
        /// ID de idioma.
        /// </summary>
        public byte LanguageID { get; set; }

        /// <summary>
        /// Nível de acesso ao sistema.
        /// </summary>
        public byte AccessLevel { get; set; }

        /// <summary>
        /// Quantidade de cash.
        /// </summary>
        public int Cash { get; set; }

        /// <summary>
        /// Senha de personagens.
        /// </summary>
        public string Pin { get; set; }

        public int CharacterID {get;set;}
        public int CharSlot { get; set; }
        public int RegionID { get; set; }

        /// <summary>
        /// Pacote de serviços de usuário.
        /// </summary>
        public PlayerService Service { get; set; }

        public PlayerData() {
            Service = new PlayerService();
        }
    }
}
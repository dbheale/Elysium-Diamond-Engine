using Elysium.Service;

namespace WorldServer.Server {
    public class HexaID {
        /// <summary>
        /// Tempo dos dados no servidor. 
        /// </summary>
        public int Time { get; set; }

        /// <summary>
        /// PIN de usuário.
        /// </summary>
        public string Pin { get; set; }

        /// <summary>
        /// Número de tentativas de PIN.
        /// </summary>
        public byte PinAttempt { get; set; }

        public string HexID { get; set; }
        public int AccountID { get; set; }
        public string Account { get; set; }
        public byte LanguageID { get; set; }
        public byte AccessLevel { get; set; }
        public int Cash { get; set; }

        /// <summary>
        /// Serviços de conta de usuário.
        /// </summary>
        public PlayerService Service { get; set; }

        /// <summary>
        /// Construtor
        /// </summary>
        public HexaID() {
            Service = new PlayerService();
        }
    } 
}

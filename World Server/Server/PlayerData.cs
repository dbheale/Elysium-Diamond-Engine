using System;
using Lidgren.Network;
using WorldServer.Common;
using Elysium;

namespace WorldServer.Server {
    public class PlayerData : HexaID {
        /// <summary>
        /// IP de usuário.
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// Dados temporários de personagem.
        /// </summary>
        public Character[] Character = new Character[Constant.MAX_CHARACTER];

        /// <summary>
        /// Player Socket.
        /// </summary>
        public NetConnection Connection { get; set; }

        /// <summary>
        /// ID de guild.
        /// </summary>
        public int GuildID { get; set; }
        
        /// <summary>
        /// ID de personagem.
        /// </summary>
        public int CharacterID { get; set; }

        /// <summary>
        /// Nome de personagem.
        /// </summary>
        public string CharacterName { get; set; }

        /// <summary>
        /// Slot de personagem.
        /// </summary>
        public int CharSlot { get; set; }

        /// <summary>
        /// ID de mundo / mapa.
        /// </summary>
        public int WorldID { get; set; }

        /// <summary>
        /// ID de região.
        /// </summary>
        public int RegionID { get; set; }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="hexID"></param>
        /// <param name="ip"></param>
        public PlayerData(NetConnection connection, string hexID, string ip) {
            Connection = connection;
            HexID = hexID;
            IP = ip;
            Account = string.Empty;
            Service = new PlayerService();
            Time = Environment.TickCount;

            //Inicializa os personagens
            for (var n = 0; n < Constant.MAX_CHARACTER; n++) {
                Character[n] = new Character() { Name = string.Empty };
            }
        }

        /// <summary>
        /// Destrutor
        /// </summary>
        ~PlayerData() {
            Clear();
            Connection.Disconnect("");
            Connection = null;
            Service.Clear();
            Service = null;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Clear() {
            AccountID = 0;
            Account = IP = string.Empty;

            if (Character == null) { return; }
            ClearCharacter();
        }

        public void ClearCharacter() {
            for (var n = 0; n < Constant.MAX_CHARACTER; n++) {
                Character[n].Clear();
            }
        }
    }
}

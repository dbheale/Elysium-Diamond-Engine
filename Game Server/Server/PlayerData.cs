using System;
using Lidgren.Network;
using GameServer.ClasseData;
using Elysium;

namespace GameServer.Server {   
    public partial class PlayerData : StatsBase {
        /// <summary>
        /// Socket de conexão
        /// </summary>
        public NetConnection Connection { get; set; }

        /// <summary>
        /// IpAddress
        /// </summary>
        public string IP { get; set; }

        public string HexID { get; set; }

        /// <summary>
        /// Tempo de da ultima mensagem (global).
        /// </summary>
        public int LastMsgTime { get; set; }

        public int AccountID { get; set; }
        public int CharacterID { get; set; }
        public string Account { get; set; }
        public string CharacterName { get; set; }
        public int CharacterSlot { get; set; }
        public byte LanguageID { get; set; }
        public short AccessLevel { get; set; }
        public int GuildID { get; set; }
        public string GuildName { get; set; } = string.Empty;
        public int ClasseID { get; set; }
        public short Sprite { get; set; }

        public long Experience { get; set; }

        /// <summary>
        /// ID do mapa.
        /// </summary>
        public short WorldID { get; set; }

        /// <summary>
        /// ID de região do mapa.
        /// </summary>
        public short RegionID { get; set; }

        /// <summary>
        /// Direção do personagem.
        /// </summary>
        public byte Direction { get; set; }

        /// <summary>
        /// Coordenada X.
        /// </summary>
        public short X { get; set; }

        /// <summary>
        /// Coordenada Y.
        /// </summary>
        public short Y { get; set; }


        public int BaseStrenght { get; set; }
        public int BaseDexterity { get; set; }
        public int BaseAgility { get; set; }
        public int BaseConstitution { get; set; }
        public int BaseIntelligence { get; set; }
        public int BaseWisdom { get; set; }
        public int BaseWill { get; set; }
        public int BaseMind { get; set; }
        public int BaseCharisma { get; set; }

        public PlayerService Service { get; set; }

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
            CharacterName = string.Empty;
            Service = new PlayerService();        
        }

        public void Clear() {
            AccountID = 0;
            Account = IP = string.Empty;
            HexID = string.Empty;
            CharacterID = 0;
            CharacterName = string.Empty;
            CharacterSlot = 0;
        }
    }
}

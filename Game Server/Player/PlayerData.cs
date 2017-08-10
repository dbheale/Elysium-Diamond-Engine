using System;
using Lidgren.Network;
using GameServer.Classes;
using GameServer.GameTalent;
using GameServer.GameItem;
using GameServer.Common;
using Elysium.Service;

namespace GameServer.Player {   
    public partial class PlayerData {
        /// <summary>
        /// Socket de conexão
        /// </summary>
        public NetConnection Connection { get; set; }

        /// <summary>
        /// IpAddress
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// ID hexadecimal.
        /// </summary>
        public string HexID { get; set; }

        /// <summary>
        /// Tempo de vida do usuário.
        /// </summary>
        public int Time { get; set; }

        public int AccountID { get; set; }
        public int CharacterID { get; set; }
        public string Account { get; set; }
        public string CharacterName { get; set; }
        public int CharacterSlot { get; set; }
        public byte LanguageID { get; set; }
        public byte AccessLevel { get; set; }
        public int GuildID { get; set; }
        public string GuildName { get; set; } = string.Empty;
        public short ClasseID { get; set; }
        public short Sprite { get; set; }

        /// <summary>
        /// Moeda corrente.
        /// </summary>
        public long Currency { get; set; }

        /// <summary>
        /// Level do personagem.
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// Experiência atual do personagem.
        /// </summary>
        public long Experience { get; set; }

        /// <summary>
        /// Pontos de level.
        /// </summary>
        public int StatPoints { get; set; }

        /// <summary>
        /// Level do talento.
        /// </summary>
        public int TalentLevel { get; set; }

        public Talent[] Balance { get; set; } = new Talent[Constant.MAX_TALENT];
        public Talent[] Physic { get; set; } = new Talent[Constant.MAX_TALENT];
        public Talent[] Magic { get; set; } = new Talent[Constant.MAX_TALENT];
        public Talent[] Restoration { get; set; } = new Talent[Constant.MAX_TALENT];

        /// <summary>
        /// Experiência atual do talento.
        /// </summary>
        public long TalentExperience { get; set; }

        /// <summary>
        /// Pontos de talento.
        /// </summary>
        public int TalentPoints { get; set; }

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

        /// <summary>
        /// Lista de serviços do usuário.
        /// </summary>
        public PlayerService Service { get; set; }

        public int[] Stat { get; set; } = new int[Constant.MAX_STATS];

        public int HP { get; set; }
        public int MaxHP { get; set; }
        public int MP { get; set; }
        public int MaxMP { get; set; }
        public int SP { get; set; }
        public int MaxSP { get; set; }

        #region Stats Base
        public int Strenght { get; set; }
        public int Dexterity { get; set; }
        public int Agility { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Will { get; set; }
        public int Mind { get; set; }
        #endregion

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
            Time = Environment.TickCount;
            Service = new PlayerService();

            for (var n = 0; n < Constant.MAX_EQUIPPED_ITEM; n++) EquippedItem[n] = new Item();
            for (int n = 0; n < Constant.MAX_INVENTORY; n++) Inventory[n] = new Item();
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
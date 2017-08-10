using Lidgren.Network;
using GameServer.Network;
using GameServer.Classes;

namespace GameServer.Player {
    public partial class PlayerData {
        public void SendPlayerCurrency() {
            var buffer = GameNetwork.CreateMessage(10);
            buffer.Write((short)PacketList.GS_CL_Currency);
            buffer.Write(Currency);
            GameNetwork.SendDataTo(Connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }
   
        /// <summary>
        /// Envia informações básicas.
        /// </summary>
        public void SendPlayerBasicData() {
            var buffer = GameNetwork.CreateMessage();
            buffer.Write((short)PacketList.GameServer_Client_PlayerData);
            buffer.Write(CharacterName);
            buffer.Write(ClasseID);
            buffer.Write(Sprite);
            buffer.Write(Level);
            buffer.Write(Experience);
            buffer.Write(StatPoints);
            GameNetwork.SendDataTo(Connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }   
        
        public void SendName() {
            var buffer = GameNetwork.CreateMessage();
            buffer.Write((short)PacketList.GS_CL_PlayerName);
            buffer.Write(CharacterName);
            GameNetwork.SendDataTo(Connection, buffer, NetDeliveryMethod.ReliableOrdered);
        } 

        public void SendStatPoints() {
            var buffer = GameNetwork.CreateMessage(6);
            buffer.Write((short)PacketList.GS_CL_PlayerStatPoints);
            buffer.Write(StatPoints);
            GameNetwork.SendDataTo(Connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        public void SendSprite() {
            var buffer = GameNetwork.CreateMessage(4);
            buffer.Write((short)PacketList.GS_CL_PlayerSprite);
            buffer.Write(Sprite);
            GameNetwork.SendDataTo(Connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        public void SendLevel() {
            var buffer = GameNetwork.CreateMessage(6);
            buffer.Write((short)PacketList.GS_CL_PlayerLevel);
            buffer.Write(Level);
            GameNetwork.SendDataTo(Connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Envia a experiência.
        /// </summary>
        public void SendPlayerExp() {
            var buffer = GameNetwork.CreateMessage();
            buffer.Write((short)PacketList.GameServer_Client_PlayerExp);
            buffer.Write(Experience);
            GameNetwork.SendDataTo(Connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Envia o vital.
        /// </summary>
        public void SendPlayerVital() {
            var buffer = GameNetwork.CreateMessage();
            buffer.Write((short)PacketList.GameServer_Client_PlayerVital);
            buffer.Write(MaxHP);
            buffer.Write(HP);
            buffer.Write(MaxMP);
            buffer.Write(MP);
            buffer.Write(MaxSP);
            buffer.Write(SP);
            GameNetwork.SendDataTo(Connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Envia a regeneração.
        /// </summary>
        public void SendPlayerVitalRegen() {
            var buffer = GameNetwork.CreateMessage();
            buffer.Write((short)PacketList.GameServer_Client_PlayerVitalRegen);
            buffer.Write(Stat[(int)StatType.RegenHP]);
            buffer.Write(Stat[(int)StatType.RegenMP]);
            buffer.Write(Stat[(int)StatType.RegenSP]);
            GameNetwork.SendDataTo(Connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }
        
        /// <summary>
        /// Envia as coordenadas e direção.
        /// </summary>
        public void SendPlayerWorldLocation() {
            var buffer = GameNetwork.CreateMessage();
            buffer.Write((short)PacketList.GameServer_Client_PlayerLocation);
            buffer.Write(WorldID);
            buffer.Write(RegionID);
            buffer.Write(Direction);
            buffer.Write(X);
            buffer.Write(Y);
            GameNetwork.SendDataTo(Connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        public void SendLocation() {
            var buffer = GameNetwork.CreateMessage();
            buffer.Write((short)PacketList.GS_CL_PlayerLocation);
            buffer.Write(X);
            buffer.Write(Y);
            GameNetwork.SendDataTo(Connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Envia os atributos.
        /// </summary>
        public void SendPlayerStats() {
            var buffer = GameNetwork.CreateMessage();
            buffer.Write((short)PacketList.GameServer_Client_PlayerStats);
            buffer.Write(Stat[(int)StatType.Strenght]);
            buffer.Write(Stat[(int)StatType.Dexterity]);
            buffer.Write(Stat[(int)StatType.Agility]);
            buffer.Write(Stat[(int)StatType.Constitution]);
            buffer.Write(Stat[(int)StatType.Intelligence]);
            buffer.Write(Stat[(int)StatType.Wisdom]);
            buffer.Write(Stat[(int)StatType.Will]);
            buffer.Write(Stat[(int)StatType.Mind]);
            GameNetwork.SendDataTo(Connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }
        
        /// <summary>
        /// Envia os atributos fisicos
        /// </summary>
        public void SendPlayerPhysicalStats() {
            var buffer = GameNetwork.CreateMessage();
            buffer.Write((short)PacketList.GameServer_Client_PlayerPhysicalStats);
            buffer.Write(Stat[(int)StatType.Attack]);
            buffer.Write(Stat[(int)StatType.Accuracy]);
            buffer.Write(Stat[(int)StatType.Defense]);
            buffer.Write(Stat[(int)StatType.Evasion]);
            buffer.Write(Stat[(int)StatType.Block]);
            buffer.Write(Stat[(int)StatType.Parry]);
            buffer.Write(Stat[(int)StatType.CriticalRate]);
            buffer.Write(Stat[(int)StatType.CriticalDamage]);
            buffer.Write(Stat[(int)StatType.AttackSpeed]);
            GameNetwork.SendDataTo(Connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }
 
        /// <summary>
        /// Envia os atributos magicos
        /// </summary>
        public void SendPlayerMagicStats() {
            var buffer = GameNetwork.CreateMessage();
            buffer.Write((short)PacketList.GameServer_Client_PlayerMagicalStats);
            buffer.Write(Stat[(int)StatType.MagicAttack]);
            buffer.Write(Stat[(int)StatType.MagicAccuracy]);
            buffer.Write(Stat[(int)StatType.MagicDefense]);
            buffer.Write(Stat[(int)StatType.MagicResist]);
            buffer.Write(Stat[(int)StatType.MagicCriticalRate]);
            buffer.Write(Stat[(int)StatType.MagicCriticalDamage]);
            buffer.Write(Stat[(int)StatType.CastSpeed]);
            GameNetwork.SendDataTo(Connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Envia os atributos unicos
        /// </summary>
        public void SendPlayerUniqueStats() {
            var buffer = GameNetwork.CreateMessage();
            buffer.Write((short)PacketList.GameServer_Client_PlayerUniqueStats);
            buffer.Write(Stat[(int)StatType.Concentration]);
            buffer.Write(Stat[(int)StatType.HealingPower]);
            buffer.Write(Stat[(int)StatType.Enmity]);
            buffer.Write(Stat[(int)StatType.DamageSuppression]);
            GameNetwork.SendDataTo(Connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Envia os atributos elementais
        /// </summary>
        public void SendPlayerElementalStats() {
            var buffer = GameNetwork.CreateMessage();
            buffer.Write((short)PacketList.GameServer_Client_PlayerElementalStats);
            buffer.Write(Stat[(int)StatType.AttributeEarth]);
            buffer.Write(Stat[(int)StatType.AttributeFire]);
            buffer.Write(Stat[(int)StatType.AttributeWater]);
            buffer.Write(Stat[(int)StatType.AttributeWind]);
            buffer.Write(Stat[(int)StatType.AttributeLight]);
            buffer.Write(Stat[(int)StatType.AttributeDark]);
            GameNetwork.SendDataTo(Connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Envia os atributos de resistencia
        /// </summary>
        public void SendPlayerResistStats() {
            var buffer = GameNetwork.CreateMessage();
            buffer.Write((short)PacketList.GameServer_Client_PlayerResistStats);
            buffer.Write(Stat[(int)StatType.ResistStun]);
            buffer.Write(Stat[(int)StatType.ResistParalysis]);
            buffer.Write(Stat[(int)StatType.ResistBlind]);
            buffer.Write(Stat[(int)StatType.ResistSilence]);
            buffer.Write(Stat[(int)StatType.ResistCriticalRate]);
            buffer.Write(Stat[(int)StatType.ResistCriticalDamage]);
            buffer.Write(Stat[(int)StatType.ResistMagicCriticalRate]);
            buffer.Write(Stat[(int)StatType.ResistMagicCriticalDamage]);
            GameNetwork.SendDataTo(Connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        public void SendPlayerTalentData() {
            var buffer = GameNetwork.CreateMessage();
            buffer.Write((short)PacketList.GS_CL_PlayerTalentData);
            buffer.Write(TalentLevel);
            buffer.Write(TalentExperience);
            buffer.Write(TalentPoints);
            GameNetwork.SendDataTo(Connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }
    }
}

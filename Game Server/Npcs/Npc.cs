namespace GameServer.Npcs { 
    public class Npc {
        public int ID { get; set; }
        public int Sprite { get; set; }
        public NpcType Type { get; set; }
        public NpcEliteType Elite { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        public int HP { get; set; }
        public int RegenHP { get; set; }      
        public int AttackSpeed { get; set; }
        public int CastSpeed { get; set; }
        public int Attack { get; set; }
        public int Accuracy { get; set; }
        public int Defense { get; set; }
        public int Evasion { get; set; }
        public int Block { get; set; }
        public int Parry { get; set; }
        public int MagicAttack { get; set; }
        public int MagicAccuracy { get; set; }
        public int MagicDefense { get; set; }
        public int MagicResist { get; set; }
        public int CriticalRate { get; set; }
        public int CriticalDamage { get; set; }
        public int AttributeFire { get; set; }
        public int AttributeWater { get; set; }
        public int AttributeEarth { get; set; }
        public int AttributeWind { get; set; }
        public int AttributeDark { get; set; }
        public int AttributeLight { get; set; }
        public int ResistStun { get; set; }
        public int ResistParalysis { get; set; }
        public int ResistSilence { get; set; }
        public int ResistBlind { get; set; }
        public int ResistCriticalRate { get; set; }
        public int ResistCriticalDamage { get; set; }
        public int ResistMagicCriticalRate { get; set; }
        public int ResistMagicCriticalDamage { get; set; }
    }
}

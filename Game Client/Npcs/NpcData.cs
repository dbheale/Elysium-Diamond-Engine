namespace Elysium_Diamond.Npcs {

    public class NpcData {
        public int ID { get; set; }
        public string Name { get; set; }
        public short Sprite { get; set; }
        public NpcType Type { get; set; }
        public NpcEliteType Elite { get; set; }
        public int Level { get; set; }

        public NpcData() {

        }

        public NpcData(NpcData npc) {
            ID = npc.ID;
            Name = npc.Name;
            Sprite = npc.Sprite;
            Type = npc.Type;
            Elite = npc.Elite;
            Level = npc.Level;
        }
    }
}

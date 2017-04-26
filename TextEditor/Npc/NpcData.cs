using System.IO;

namespace TextEditor {
    public class NpcData {
        public int ID { get; set; }
        public string Name { get; set; }
        public short Sprite { get; set; }
        public NpcType Type { get; set; }
        public NpcEliteType Elite { get; set; }
        public int Level { get; set; }

        public NpcData() {
            Name = string.Empty;
        }

        public NpcData(NpcData npc) {
            ID = npc.ID;
            Name = npc.Name;
            Sprite = npc.Sprite;
            Type = npc.Type;
            Elite = npc.Elite;
            Level = npc.Level;
        }

        /// <summary>
        /// Abre o arquivo para leitura.
        /// </summary>
        /// <returns></returns>
        public static bool OpenNpc(string binaryfile) {
            if (!File.Exists(binaryfile)) return false; 

            using (FileStream file = new FileStream(binaryfile, FileMode.Open, FileAccess.Read)) {
                BinaryReader reader = new BinaryReader(file);

                var lenght = reader.ReadInt32();
                var npc = new NpcData();

                for (int n = 0; n < lenght; n++) {
                    npc.ID = reader.ReadInt32();
                    npc.Name = reader.ReadString();
                    npc.Sprite = reader.ReadInt16();
                    npc.Type = (NpcType)reader.ReadByte();
                    npc.Elite = (NpcEliteType)reader.ReadByte();
                    npc.Level = reader.ReadInt32();

                    EditorData.Npc.Add(new NpcData(npc));
                }

                reader.Close();
            }

            return true;
        }


        /// <summary>
        /// Salva os dados no arquivo.
        /// </summary>
        public static void SaveNpc(string binaryfile) {
            using (FileStream file = new FileStream(binaryfile, FileMode.Create, FileAccess.Write)) {
                BinaryWriter writer = new BinaryWriter(file);

                writer.Write(EditorData.Npc.Count);

                foreach (var npc in EditorData.Npc) {
                    writer.Write(npc.ID);
                    writer.Write(npc.Name);
                    writer.Write(npc.Sprite);
                    writer.Write((byte)npc.Type);
                    writer.Write((byte)npc.Elite);
                    writer.Write(npc.Level);
                }

                writer.Close();
            }
        }
    }
}

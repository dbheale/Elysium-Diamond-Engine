using System;
using System.IO;
using System.Collections;

namespace TextEditor {
    public class Experience {
        public Hashtable Exp { get; set; } = new Hashtable();

        /// <summary>
        /// Obtem a quantidade de level.
        /// </summary>
        public int Count {
            get { return Exp.Count; }
        }

        public long this[int index] {
            set {
                Exp[index] = (long)value;
            }
            get {
                return (long)Exp[index];
            }

        }

        /// <summary>
        /// Adiciona um novo valor de experiencia.
        /// </summary>
        /// <param name="value"></param>
        public void Add(int level, long value) {
            Exp.Add(level, value);
        }

        /// <summary>
        /// Remove da lista com base no valor.
        /// </summary>
        /// <param name="value"></param>
        public void Remove(int level) {
            Exp.Remove(level);
        }

        /// <summary>
        /// Abre o arquivo para leitura.
        /// </summary>
        /// <returns></returns>
        public static bool OpenExp(string binaryfile) {
            if (!File.Exists(binaryfile)) return false;

            using (FileStream file = new FileStream(binaryfile, FileMode.Open, FileAccess.Read)) {
                BinaryReader reader = new BinaryReader(file);

                var lenght = reader.ReadInt32();

                for (int n = 0; n < lenght; n++) {
                    var level = reader.ReadInt32();
                    var exp = reader.ReadInt64();

                    EditorData.Experience.Add(level, exp);
                }

                reader.Close();
            }

            return true;
        }

        /// <summary>
        /// Salva os dados no arquivo.
        /// </summary>
        public static void SaveExp(string binaryfile) {
            using (FileStream file = new FileStream(binaryfile, FileMode.Create, FileAccess.Write)) {
                BinaryWriter writer = new BinaryWriter(file);

                var count = EditorData.Experience.Count;

                writer.Write(count);

                foreach(DictionaryEntry entry in EditorData.Experience.Exp) {
                    writer.Write((int)entry.Key);
                    writer.Write((long)entry.Value);
                }
  
                writer.Close();
            }
        }
    }
}


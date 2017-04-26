using System;
using System.IO;
using System.Collections;

namespace Elysium_Diamond.Resource {
    /// <summary>
    /// Experiencia.
    /// </summary>
    public class ExperienceManager {
        private Hashtable Data { get; set; } = new Hashtable();

        public long this[int index] {
            set {
                Data[index] = (long)value;
            }
            get {
                return (long)Data[index];
            }

        }

        public static ExperienceManager Experience { get; set; } = new ExperienceManager();

        /// <summary>
        /// Adiciona nova entrada de dados.
        /// </summary>
        /// <param name="level"></param>
        /// <param name="exp"></param>
        public void Add(int level, long exp) {
            Data.Add(level, exp);
        }

        /// <summary>
        /// Abre o arquivo para leitura.
        /// </summary>
        /// <returns></returns>
        public static bool OpenData() {
            if (!File.Exists("./Data/experience.bin")) return false;

            using (FileStream file = new FileStream("./Data/experience.bin", FileMode.Open, FileAccess.Read)) {
                BinaryReader reader = new BinaryReader(file);

                var lenght = reader.ReadInt32();

                for (int n = 0; n < lenght; n++) {
                    var level = reader.ReadInt32();
                    var exp = reader.ReadInt64();

                    Experience.Add(level, exp);  
                }

                reader.Close();
            }

            return true;
        }
    }
}

using System.Drawing;
using System.IO;
using TextEditor.Talent;

namespace TextEditor {
    public static class EngineStatic {
        public static Bitmap ViewTalent;

        /// <summary>
        /// Carrega as imagens.
        /// </summary>
        public static void Initialize() {
            ViewTalent = new Bitmap("talent_view.png");
        }

        /// <summary>
        /// Abre um talento.
        /// </summary>
        /// <param name="path"></param>
        public static void OpenAllTalent() {
            var max_talent = Directory.GetFiles("./Talent/").Length;


            for (var n = 1; n <= max_talent; n++) {
                using (FileStream file = new FileStream($"./Talent/{n}.talent", FileMode.Open, FileAccess.Read)) {
                    BinaryReader reader = new BinaryReader(file);

                    var talent = new TalentInfo();
                    talent.ID = reader.ReadInt32();
                    talent.IconID = reader.ReadInt32();
                    talent.Title = reader.ReadString();

                    reader.Close();

                    TalentStatic.Talents.Add(talent);                   
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using WorldServer.Common;

namespace WorldServer.Server {
    public static class DeleteTime {
        /// <summary>
        /// Level mínimo, máximo e o tempo para exclusão do personagem
        /// </summary>
        private struct LevelRange {
            public int Minimum;
            public int Maximum;
            public short Time;

            public LevelRange(int min, int max, short time) {
                Minimum = min;
                Maximum = max;
                Time = time;
            }
        }

        /// <summary>
        /// Dados temporarios do personagem para exclusão.
        /// </summary>
        private struct Character {
            public int CharacterID;
            public int AccountID;
            public int Slot;
            public DateTime Date;

            public Character(int charID, int accountID, int slot, DateTime date) {
                CharacterID = charID;
                AccountID = accountID;
                Slot = slot;
                Date = date;
            }
        }

        static List<LevelRange> levels = new List<LevelRange>();
        static List<Character> characters = new List<Character>();

        /// <summary>
        /// Adiciona as informações a lista.
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="time"></param>
        public static void AddDeleteTime(int min, int max, short time) {
            levels.Add(new LevelRange(min, max, time));
        }
        
        /// <summary>
        /// Adiciona um novo personagem para ser deletado.
        /// </summary>
        /// <param name="charID"></param>
        /// <param name="accountID"></param>
        /// <param name="date"></param>
        public static void AddCharacter(int charID, int accountID, int slot, DateTime date) {
            characters.Add(new Character(charID, accountID, slot, date));
        }

        /// <summary>
        /// Cancela a exclusão do personagem.
        /// </summary>
        /// <param name="charID"></param>
        public static void CancelDelete(int charID) {
            for (int n = 0; n < characters.Count; n++) {
                if (characters[n].CharacterID.CompareTo(charID) == 0) {
                    characters.RemoveAt(n);
                }        
            }
        }

        /// <summary>
        /// Retorna a data com o tempo de exclusão.
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public static DateTime GetDate(int level) {
            var count = levels.Count;
            LevelRange data; 

            for (int n = 0; n < count; n++) {
                data = levels[n];

                if (level >= data.Minimum && level <= data.Maximum) {
                    return DateTime.Now.AddMinutes(data.Time);
                }
            }

            return DateTime.Now;
        }

        /// <summary>
        /// Retorna o tempo em minutos.
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public static short GetMinutes(int level) {
            var count = levels.Count;
            LevelRange data;

            for (int n = 0; n < count; n++) {
                data = levels[n];

                if (level >= data.Minimum && level <= data.Maximum) {
                    return data.Time;
                }
            }

            return 0;
        }

        /// <summary>
        /// Verifica se o tempo foi expirado e deleta os personagens.
        /// </summary>
        public static void VerifyCharacters() {
            for (int n = 0; n < characters.Count; n++) {
                if (CanDelete(n)) {
                    CharacterFunction.DeleteCharacter(characters[n].AccountID, characters[n].CharacterID, characters[n].Slot);
                    characters.RemoveAt(n);
                }
            }
        }

        /// <summary>
        /// Indica se o personagem já pode ser deletado.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private static bool CanDelete(int index) {
            return (DateTime.Now.CompareTo(characters[index].Date) == Constants.Expired) ? true : false;
        }

        /// <summary>
        /// Verifica se o personagem já está na lista.
        /// </summary>
        /// <param name="charID"></param>
        /// <returns></returns>
        public static bool FindByID(int charID) {
            for (int n = 0; n < characters.Count; n++) {
                if (characters[n].CharacterID.CompareTo(charID) == 0)
                    return true;
            }

            return false;
        }
    }
}

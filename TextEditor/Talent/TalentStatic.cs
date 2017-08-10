using System.Collections.Generic;

namespace TextEditor.Talent {
    public static class TalentStatic {
        /// <summary>
        /// Formulário único de edição.
        /// </summary>
        public static TalentForm TalentForm;

        public static TalentView ViewForm;

        /// <summary>
        /// Quando algum dado da classe é modificado.
        /// </summary>
        public static bool NeedUpdate = false;

        public const int MAX_TALENT_NAME = 4;
        public const int MAX_TALENT = 24;

        public static int SelectedClasse = -1;
        public static int SelectedIndex;
        public static int SelectedType;

        /// <summary>
        /// Lista de classes.
        /// </summary>
        public static List<ClasseTalent> Classes = new List<ClasseTalent>();

        /// <summary>
        /// Lista de todos os talentos.
        /// </summary>
        public static List<TalentInfo> Talents = new List<TalentInfo>();

        /// <summary>
        /// Obtem o ícone de um talento.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int FindIconID(int id) {
            var count = Talents.Count;

            for (var n = 0; n < count; n++) {
                if (Talents[n].ID.CompareTo(id) == 0) return Talents[n].IconID;
            }

            return 0;
        }
    }
}
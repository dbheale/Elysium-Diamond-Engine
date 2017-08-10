namespace TextEditor.Talent {
    public sealed class ClasseTalent {
        public int ClasseID;
        public string ClasseName;
        public string[] TalentName;
        public int[] Balance;
        public int[] Physic;
        public int[] Magic;
        public int[] Restoration;

        public ClasseTalent(int id, string name) {
            TalentName = new string[TalentStatic.MAX_TALENT_NAME];

            Balance = new int[TalentStatic.MAX_TALENT];
            Physic = new int[TalentStatic.MAX_TALENT];
            Magic = new int[TalentStatic.MAX_TALENT];
            Restoration = new int[TalentStatic.MAX_TALENT];

            for (var n = 0; n < TalentStatic.MAX_TALENT_NAME; n++) TalentName[n] = string.Empty;

            ClasseID = id;
            ClasseName = name;
        }
    }
}
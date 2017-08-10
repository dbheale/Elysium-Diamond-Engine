namespace Elysium_Diamond.Classes {
    public sealed class ClasseTalent {
        public int ClasseID;
        public string ClasseName;
        public string[] TalentName;
        public int[] Balance;
        public int[] Physic;
        public int[] Magic;
        public int[] Restoration;

        public ClasseTalent(int id, string name) {
            const int MaxTalentName = 4;
            const int MaxTalent = 24;

            TalentName = new string[MaxTalentName];

            Balance = new int[MaxTalent];
            Physic = new int[MaxTalent];
            Magic = new int[MaxTalent];
            Restoration = new int[MaxTalent];

            for (var n = 0; n < MaxTalentName; n++) TalentName[n] = string.Empty;

            ClasseID = id;
            ClasseName = name;
        }
    }
}
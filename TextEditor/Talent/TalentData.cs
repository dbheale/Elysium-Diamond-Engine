using System.Collections.Generic;

namespace TextEditor.Talent {
    public sealed class TalentData {
        public int ID { get; set; }
        public int IconID { get; set; }
        public string Title { get; set; }
        public int MaxLevel { get; set; }
        public string Description { get; set; }
        public int ReqTalentID { get; set; }
        public int ReqTalentLevel { get; set; }

        /// <summary>
        /// Lista de efeitos.
        /// </summary>
        public List<int> Effect;

        public TalentData() {
            Title = string.Empty;
            Description = string.Empty;
            Effect = new List<int>();
        }

        public void Clear() {
            ID = 0;
            IconID = 0;
            Title = string.Empty;
            MaxLevel = 0;
            Effect.Clear();
            Description = string.Empty;
            ReqTalentID = 0;
            ReqTalentLevel = 0;
        }
    }
}
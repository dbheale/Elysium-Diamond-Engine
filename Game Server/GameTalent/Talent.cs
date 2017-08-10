namespace GameServer.GameTalent {
    public struct Talent { 
        public int ID { get; set; }

        /// <summary>
        /// Level da skill.
        /// </summary>
        public int Level { get; set; }      

        public Talent(int id, int level) {
            ID = id;
            Level = level;
        }
    }
}
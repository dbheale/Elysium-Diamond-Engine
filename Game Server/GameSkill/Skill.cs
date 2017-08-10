namespace GameServer.GameSkill {
    public struct Skill {
        /// <summary>
        /// Identificação.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Level da habilidade.
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// Experiência.
        /// </summary>
        public long Experience { get; set; }
    }
}
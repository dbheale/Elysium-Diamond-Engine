namespace GameServer.GameSkill {
    public class SkillEffect {
        /// <summary>
        /// ID do efeito.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Tipo de efeito.
        /// </summary>
        public SkillEffectType EffectType { get; set; }

        /// <summary>
        /// Efeito da habilidade.
        /// </summary>
        public int Effect { get; set; }

        /// <summary>
        /// Duração em MS.
        /// </summary>
        public int Duration { get; set; }
    }
}
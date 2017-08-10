using System.Collections.Generic;

namespace GameServer.GameSkill {
    public sealed class SkillData {
        /// <summary>
        /// Identificação.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Tipo da habilidade, passiva ou ativa.
        /// </summary>
        public SkillType Type { get; set; }

        /// <summary>
        /// Tipo de alvo, 
        /// </summary>
        public SkillTargetType TargetType { get; set; }

        /// <summary>
        /// Se a habilidade for passiva, influência o stat determinado.
        /// </summary>
        public StatType Stat { get; set; }

        /// <summary>
        /// Tipo de roubo da habilidade.
        /// </summary>
        public SkillStealType Steal { get; set; }

        /// <summary>
        /// Valor do efeito da habilidade passiva.
        /// </summary>
        public int StatData { get; set; }

        /// <summary>
        /// Alcance.
        /// </summary>
        public byte Range { get; set; }

        /// <summary>
        /// Elemento.
        /// </summary>
        public SkillElement Element { get;set; }

        /// <summary>
        /// Tempo de conjuração.
        /// </summary>
        public int CastTime { get; set; }

        /// <summary>
        /// Custo de uso.
        /// </summary>
        public int Cost { get; set; }

        /// <summary>
        /// Tipo de custo.
        /// </summary>
        public SkillCostType CostType { get; set; }

        /// <summary>
        /// Resfriamento
        /// </summary>
        public int Cooldown { get; set; }

        /// <summary>
        /// Lista de efeitos da habilidade.
        /// </summary>
        public List<SkillEffect> Effect { get; set; }
    }
}
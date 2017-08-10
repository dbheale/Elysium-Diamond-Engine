using GameServer.Common;

namespace GameServer.GameTalent {
    public class TalentData {
        /// <summary>
        /// Identificação.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Talento anterior requerido para ativação.
        /// </summary>
        public Talent Requeriment { get; set; }

        /// <summary>
        /// Tipo de talento, habilidades passivas ou ativas.
        /// </summary>
        public TalentType Type { get; set; }

        /// <summary>
        /// Tipo de efeito, valor fixo ou porcentagem.
        /// </summary>
        public TalentDataType DataType { get; set; }

        /// <summary>
        /// ID de skill que será afetada.
        /// </summary>
        public int SkillID { get; set; }

        /// <summary>
        /// Skill special que será adicionada à skill primaria.
        /// </summary>
        public int SkillEffectID { get; set; }

        /// <summary>
        /// Level máximo.
        /// </summary>
        public int MaxLevel { get; set; }

        /// <summary>
        /// Atributos de habilidade passiva.
        /// </summary>
        public int[] Stat = new int[Constant.MAX_STATS];
    }
}
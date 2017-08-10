using System.Collections.Generic;
using GameServer.Player;
using GameServer.Common;

namespace GameServer.Classes {
    public sealed class Classe : StatsBase {
        /// <summary>
        /// ID de classe.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// ID de icnremento
        /// </summary>
        public int IncrementID { get; set; }

        /// <summary>
        /// ID de talentos.
        /// </summary>
        public int TalentID { get; set; }

        /// <summary>
        /// Lista de classes.
        /// </summary>
        public static List<Classe> Classes { get; set; }

        /// <summary>
        /// Atributos de incremento
        /// </summary>
        public StatsIncrement Increment { get; set; }

        /// <summary>
        /// Talento.
        /// </summary>
        public int[] Balance { get; set; } = new int[Constant.MAX_TALENT];
        public int[] Physic { get; set; } = new int[Constant.MAX_TALENT];
        public int[] Magic { get; set; } = new int[Constant.MAX_TALENT];
        public int[] Restoration { get; set; } = new int[Constant.MAX_TALENT];

        /// <summary>
        /// Construtor
        /// </summary>
        public Classe() {
            Increment = new StatsIncrement();
        }

        /// <summary>
        /// Obtém os stats do personagem.
        /// </summary>
        /// <param name="stat"></param>
        /// <param name="pData"></param>
        /// <param name="itemStats"></param>
        /// <returns></returns>
        public int GetPlayerStat(StatType stat, PlayerData pData) {
            // Pega os valores para calculo
            int[] value = new int[Constant.MAX_BASE_STAT];

            //stats do banco + (level * incremento) 

            value[0] = pData.Level;
            value[1] = pData.Stat[(int)StatType.Strenght];
            value[2] = pData.Stat[(int)StatType.Dexterity];
            value[3] = pData.Stat[(int)StatType.Agility];
            value[4] = pData.Stat[(int)StatType.Constitution];
            value[5] = pData.Stat[(int)StatType.Intelligence];
            value[6] = pData.Stat[(int)StatType.Wisdom];
            value[7] = pData.Stat[(int)StatType.Will];
            value[8] = pData.Stat[(int)StatType.Mind];

            //stats base + level * incremento por level
            switch (stat) {
                case StatType.Strenght: return pData.Strenght;
                case StatType.Dexterity: return pData.Dexterity;
                case StatType.Agility: return pData.Agility;
                case StatType.Constitution: return pData.Constitution;
                case StatType.Intelligence: return pData.Intelligence;
                case StatType.Wisdom: return pData.Wisdom;
                case StatType.Will: return pData.Will;
                case StatType.Mind: return pData.Mind;
                case StatType.MaxHP: return MaxHP + Increment.GetIncrementStat(StatType.MaxHP, value);
                case StatType.MaxMP: return MaxMP + Increment.GetIncrementStat(StatType.MaxMP, value);
                case StatType.MaxSP: return MaxSP + Increment.GetIncrementStat(StatType.MaxSP, value);
                case StatType.RegenHP: return RegenHP + Increment.GetIncrementStat(StatType.RegenHP, value);
                case StatType.RegenMP: return RegenMP + Increment.GetIncrementStat(StatType.RegenMP, value);
                case StatType.RegenSP: return RegenSP + Increment.GetIncrementStat(StatType.RegenSP, value);
                case StatType.DamageSuppression: return DamageSuppression + Increment.GetIncrementStat(StatType.DamageSuppression, value);
                case StatType.Enmity: return Enmity + Increment.GetIncrementStat(StatType.Enmity, value);
                case StatType.AdditionalDamage: return AdditionalDamage + Increment.GetIncrementStat(StatType.AdditionalDamage, value);
                case StatType.HealingPower: return HealingPower + Increment.GetIncrementStat(StatType.HealingPower, value);
                case StatType.Concentration: return Concentration + Increment.GetIncrementStat(StatType.Concentration, value);
                case StatType.AttackSpeed: return AttackSpeed + Increment.GetIncrementStat(StatType.AttackSpeed, value);
                case StatType.CastSpeed: return CastSpeed + Increment.GetIncrementStat(StatType.CastSpeed, value);
                case StatType.Attack: return Attack + Increment.GetIncrementStat(StatType.Attack, value);
                case StatType.Accuracy: return Accuracy + Increment.GetIncrementStat(StatType.Accuracy, value);
                case StatType.Defense: return Defense + Increment.GetIncrementStat(StatType.Defense, value);
                case StatType.Evasion: return Evasion + Increment.GetIncrementStat(StatType.Evasion, value);
                case StatType.Block: return Block + Increment.GetIncrementStat(StatType.Block, value);
                case StatType.Parry: return Parry + Increment.GetIncrementStat(StatType.Parry, value);
                case StatType.CriticalRate: return CriticalRate + Increment.GetIncrementStat(StatType.CriticalRate, value);
                case StatType.CriticalDamage: return CriticalDamage + Increment.GetIncrementStat(StatType.CriticalDamage, value);
                case StatType.MagicAttack: return MagicAttack + Increment.GetIncrementStat(StatType.MagicAttack, value);
                case StatType.MagicAccuracy: return MagicAccuracy + Increment.GetIncrementStat(StatType.MagicAccuracy, value);
                case StatType.MagicDefense: return MagicDefense + Increment.GetIncrementStat(StatType.MagicDefense, value);
                case StatType.MagicResist: return MagicResist + Increment.GetIncrementStat(StatType.MagicResist, value);
                case StatType.MagicCriticalRate: return MagicCriticalRate + Increment.GetIncrementStat(StatType.MagicCriticalRate, value);
                case StatType.MagicCriticalDamage: return MagicCriticalDamage + Increment.GetIncrementStat(StatType.MagicCriticalDamage, value);
                case StatType.ResistStun: return ResistStun + Increment.GetIncrementStat(StatType.ResistStun, value);
                case StatType.ResistSilence: return ResistSilence + Increment.GetIncrementStat(StatType.ResistSilence, value);
                case StatType.ResistParalysis: return ResistParalysis + Increment.GetIncrementStat(StatType.ResistParalysis, value);
                case StatType.ResistBlind: return ResistBlind + Increment.GetIncrementStat(StatType.ResistBlind, value);
                case StatType.AttributeFire: return AttributeFire + Increment.GetIncrementStat(StatType.AttributeFire, value);
                case StatType.AttributeWater: return AttributeWater + Increment.GetIncrementStat(StatType.AttributeWater, value);
                case StatType.AttributeEarth: return AttributeEarth + Increment.GetIncrementStat(StatType.AttributeEarth, value);
                case StatType.AttributeWind: return AttributeWind + Increment.GetIncrementStat(StatType.AttributeWind, value);
                case StatType.AttributeLight: return AttributeEarth + Increment.GetIncrementStat(StatType.AttributeLight, value);
                case StatType.AttributeDark: return AttributeWind + Increment.GetIncrementStat(StatType.AttributeDark, value);
                case StatType.ResistCriticalRate: return ResistCriticalRate + Increment.GetIncrementStat(StatType.ResistCriticalRate, value);
                case StatType.ResistCriticalDamage: return ResistCriticalDamage + Increment.GetIncrementStat(StatType.ResistCriticalDamage, value);
                case StatType.ResistMagicCriticalRate: return ResistMagicCriticalRate + Increment.GetIncrementStat(StatType.ResistMagicCriticalRate, value);
                case StatType.ResistMagicCriticalDamage: return ResistMagicCriticalDamage + Increment.GetIncrementStat(StatType.ResistMagicCriticalDamage, value);
            }

            return 0;
        }

        /// <summary>
        /// Procura pelo indice da classe na lista.
        /// </summary>
        /// <param name="classeID"></param>
        /// <returns></returns>
        public static int FindClasseIndexByID(int classeID) {
            for (var index = 0; index < Classes.Count; index++) {
                if (Classes[index].ID == classeID) return index;
            }

            return -1;
        }
    }
}
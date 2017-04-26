using System;

namespace Classe_Editor.ClasseData {
    public class StatIncrement {
        public object IncrementID { get; set; }
        public object Strenght { get; set; }
        public object Dexterity { get; set; }
        public object Agility { get; set; }
        public object Constitution { get; set; }
        public object Intelligence { get; set; }
        public object Wisdom { get; set; }
        public object Will { get; set; }
        public object Mind { get; set; }
        public object Charisma { get; set; }
        public object Points { get; set; }

        private const int MAX_STATS = 10;
        private object[] inc_MaxHP = new object[MAX_STATS];
        private object[] inc_MaxMP = new object[MAX_STATS];
        private object[] inc_MaxSP = new object[MAX_STATS];
        private object[] inc_RegenHP = new object[MAX_STATS];
        private object[] inc_RegenMP = new object[MAX_STATS];
        private object[] inc_RegenSP = new object[MAX_STATS];
        private object[] inc_DamageSuppression = new object[MAX_STATS];
        private object[] inc_Enmity = new object[MAX_STATS];
        private object[] inc_AdditionalDamage = new object[MAX_STATS];
        private object[] inc_HealingPower = new object[MAX_STATS];
        private object[] inc_Concentration = new object[MAX_STATS];
        private object[] inc_AttackSpeed = new object[MAX_STATS];
        private object[] inc_CastSpeed = new object[MAX_STATS];
        private object[] inc_Attack = new object[MAX_STATS];
        private object[] inc_Accuracy = new object[MAX_STATS];
        private object[] inc_Defense = new object[MAX_STATS];
        private object[] inc_Evasion = new object[MAX_STATS];
        private object[] inc_Block = new object[MAX_STATS];
        private object[] inc_Parry = new object[MAX_STATS];
        private object[] inc_CriticalRate = new object[MAX_STATS];
        private object[] inc_CriticalDamage = new object[MAX_STATS];
        private object[] inc_MagicAttack = new object[MAX_STATS];
        private object[] inc_MagicAccuracy = new object[MAX_STATS];
        private object[] inc_MagicDefense = new object[MAX_STATS];
        private object[] inc_MagicResist = new object[MAX_STATS];
        private object[] inc_MagicCriticalRate = new object[MAX_STATS];
        private object[] inc_MagicCriticalDamage = new object[MAX_STATS];
        private object[] inc_AttributeFire = new object[MAX_STATS];
        private object[] inc_AttributeWater = new object[MAX_STATS];
        private object[] inc_AttributeEarth = new object[MAX_STATS];
        private object[] inc_AttributeWind = new object[MAX_STATS];
        private object[] inc_ResistStun = new object[MAX_STATS];
        private object[] inc_ResistBlind = new object[MAX_STATS];
        private object[] inc_ResistParalysis = new object[MAX_STATS];
        private object[] inc_ResistSilence = new object[MAX_STATS];
        private object[] inc_ResistCriticalRate = new object[MAX_STATS];
        private object[] inc_ResistCriticalDamage = new object[MAX_STATS];
        private object[] inc_ResistMagicCriticalRate = new object[MAX_STATS];
        private object[] inc_ResistMagicCriticalDamage = new object[MAX_STATS];

        /// <summary>
        /// Altera determinado 'stat'.
        /// </summary>
        /// <param name="stat"></param>
        /// <param name="data"></param>
        public void SetIncrementStat(StatType stat, string data) {
            switch (stat) {
                case StatType.MaxHP:
                    SetIncrementStat(inc_MaxHP, data);
                    break;
                case StatType.MaxMP:
                    SetIncrementStat(inc_MaxMP, data);
                    break;
                case StatType.MaxSP:
                    SetIncrementStat(inc_MaxSP, data);
                    break;
                case StatType.RegenHP:
                    SetIncrementStat(inc_RegenHP, data);
                    break;
                case StatType.RegenMP:
                    SetIncrementStat(inc_RegenMP, data);
                    break;
                case StatType.RegenSP:
                    SetIncrementStat(inc_RegenSP, data);
                    break;
                case StatType.DamageSuppression:
                    SetIncrementStat(inc_DamageSuppression, data);
                    break;
                case StatType.Enmity:
                    SetIncrementStat(inc_Enmity, data);
                    break;
                case StatType.AdditionalDamage:
                    SetIncrementStat(inc_AdditionalDamage, data);
                    break;
                case StatType.HealingPower:
                    SetIncrementStat(inc_HealingPower, data);
                    break;
                case StatType.Concentration:
                    SetIncrementStat(inc_Concentration, data);
                    break;
                case StatType.AttackSpeed:
                    SetIncrementStat(inc_AttackSpeed, data);
                    break;
                case StatType.CastSpeed:
                    SetIncrementStat(inc_CastSpeed, data);
                    break;
                case StatType.Attack:
                    SetIncrementStat(inc_Attack, data);
                    break;
                case StatType.Accuracy:
                    SetIncrementStat(inc_Accuracy, data);
                    break;
                case StatType.Defense:
                    SetIncrementStat(inc_Defense, data);
                    break;
                case StatType.Evasion:
                    SetIncrementStat(inc_Evasion, data);
                    break;
                case StatType.Block:
                    SetIncrementStat(inc_Block, data);
                    break;
                case StatType.Parry:
                    SetIncrementStat(inc_Parry, data);
                    break;
                case StatType.CriticalRate:
                    SetIncrementStat(inc_CriticalRate, data);
                    break;
                case StatType.CriticalDamage:
                    SetIncrementStat(inc_CriticalDamage, data);
                    break;
                case StatType.MagicAttack:
                    SetIncrementStat(inc_MagicAttack, data);
                    break;
                case StatType.MagicAccuracy:
                    SetIncrementStat(inc_MagicAccuracy, data);
                    break;
                case StatType.MagicDefense:
                    SetIncrementStat(inc_MagicDefense, data);
                    break;
                case StatType.MagicResist:
                    SetIncrementStat(inc_MagicResist, data);
                    break;
                case StatType.MagicCriticalRate:
                    SetIncrementStat(inc_MagicCriticalRate, data);
                    break;
                case StatType.MagicCriticalDamage:
                    SetIncrementStat(inc_MagicCriticalDamage, data);
                    break;
                case StatType.AttributeFire:
                    SetIncrementStat(inc_AttributeFire, data);
                    break;
                case StatType.AttributeWater:
                    SetIncrementStat(inc_AttributeWater, data);
                    break;
                case StatType.AttributeEarth:
                    SetIncrementStat(inc_AttributeEarth, data);
                    break;
                case StatType.AttributeWind:
                    SetIncrementStat(inc_AttributeWind, data);
                    break;
                case StatType.ResistStun:
                    SetIncrementStat(inc_ResistStun, data);
                    break;
                case StatType.ResistParalysis:
                    SetIncrementStat(inc_ResistParalysis, data);
                    break;
                case StatType.ResistSilence:
                    SetIncrementStat(inc_ResistSilence, data);
                    break;
                case StatType.ResistBlind:
                    SetIncrementStat(inc_ResistBlind, data);
                    break;
                case StatType.ResistCriticalRate:
                    SetIncrementStat(inc_ResistCriticalRate, data);
                    break;
                case StatType.ResistCriticalDamage:
                    SetIncrementStat(inc_ResistCriticalDamage, data);
                    break;
                case StatType.ResistMagicCriticalRate:
                    SetIncrementStat(inc_ResistMagicCriticalRate, data);
                    break;
                case StatType.ResistMagicCriticalDamage:
                    SetIncrementStat(inc_ResistMagicCriticalDamage, data);
                    break;
            }
        }

        /// <summary>
        /// Altera e realiza a conversão.
        /// </summary>
        /// <param name="var"></param>
        /// <param name="data"></param>
        private void SetIncrementStat(object[] var, string data) {
            string[] value = data.Split(';');
            var[0] = value[0]; // LEVEL
            var[1] = value[1]; // STRENGHT
            var[2] = value[2]; // DEXTERITY
            var[3] = value[3]; // AGILITY
            var[4] = value[4]; // CONSTITUTION
            var[5] = value[5]; // objectELLIGENCE
            var[6] = value[6]; // WISDOM
            var[7] = value[7]; // WILL
            var[8] = value[8]; // MIND
            var[9] = value[9]; // CHARISMA
        }

        /// <summary>
        /// Obtém os dados de incremento de classe.
        /// </summary>
        /// <param name="stat"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public object GetIncrementStat(StatType stat, params object[] value) {
            switch (stat) {
                case StatType.MaxHP: return GetIncrementStat(inc_MaxHP, value);
                case StatType.MaxMP: return GetIncrementStat(inc_MaxMP, value);
                case StatType.MaxSP: return GetIncrementStat(inc_MaxSP, value);
                case StatType.RegenHP: return GetIncrementStat(inc_RegenHP, value);
                case StatType.RegenMP: return GetIncrementStat(inc_RegenMP, value);
                case StatType.RegenSP: return GetIncrementStat(inc_RegenSP, value);
                case StatType.DamageSuppression: return GetIncrementStat(inc_DamageSuppression, value);
                case StatType.Enmity: return GetIncrementStat(inc_Enmity, value);
                case StatType.AdditionalDamage: return GetIncrementStat(inc_AdditionalDamage, value);
                case StatType.HealingPower: return GetIncrementStat(inc_HealingPower, value);
                case StatType.Concentration: return GetIncrementStat(inc_Concentration, value);
                case StatType.AttackSpeed: return GetIncrementStat(inc_AttackSpeed, value);
                case StatType.CastSpeed: return GetIncrementStat(inc_CastSpeed, value);
                case StatType.Attack: return GetIncrementStat(inc_Attack, value);
                case StatType.Accuracy: return GetIncrementStat(inc_Accuracy, value);
                case StatType.Defense: return GetIncrementStat(inc_Defense, value);
                case StatType.Evasion: return GetIncrementStat(inc_Evasion, value);
                case StatType.Block: return GetIncrementStat(inc_Block, value);
                case StatType.Parry: return GetIncrementStat(inc_Parry, value);
                case StatType.CriticalRate: return GetIncrementStat(inc_CriticalRate, value);
                case StatType.CriticalDamage: return GetIncrementStat(inc_CriticalDamage, value);
                case StatType.MagicAttack: return GetIncrementStat(inc_MagicAttack, value);
                case StatType.MagicAccuracy: return GetIncrementStat(inc_MagicAccuracy, value);
                case StatType.MagicDefense: return GetIncrementStat(inc_MagicDefense, value);
                case StatType.MagicResist: return GetIncrementStat(inc_MagicResist, value);
                case StatType.MagicCriticalRate: return GetIncrementStat(inc_MagicCriticalRate, value);
                case StatType.MagicCriticalDamage: return GetIncrementStat(inc_MagicCriticalDamage, value);
                case StatType.AttributeFire: return GetIncrementStat(inc_AttributeFire, value);
                case StatType.AttributeWater: return GetIncrementStat(inc_AttributeWater, value);
                case StatType.AttributeEarth: return GetIncrementStat(inc_AttributeEarth, value);
                case StatType.AttributeWind: return GetIncrementStat(inc_AttributeWind, value);
                case StatType.ResistStun: return GetIncrementStat(inc_ResistStun, value);
                case StatType.ResistParalysis: return GetIncrementStat(inc_ResistParalysis, value);
                case StatType.ResistSilence: return GetIncrementStat(inc_ResistSilence, value);
                case StatType.ResistBlind: return GetIncrementStat(inc_ResistBlind, value);
                case StatType.ResistCriticalRate: return GetIncrementStat(inc_ResistCriticalRate, value);
                case StatType.ResistCriticalDamage: return GetIncrementStat(inc_ResistCriticalDamage, value);
                case StatType.ResistMagicCriticalRate: return GetIncrementStat(inc_ResistMagicCriticalRate, value);
                case StatType.ResistMagicCriticalDamage: return GetIncrementStat(inc_ResistMagicCriticalDamage, value);
            }

            return 0;
        }

        /// <summary>
        /// Obtém os dados de incremento de classe.
        /// </summary>
        /// <param name="var"></param>
        /// <param name="stat"></param>
        /// <returns></returns>
        private object GetIncrementStat(object[] var, object[] stat) {
            var result = 0;
            result += Convert.ToInt32(stat[0]) * Convert.ToInt32(var[0]); // LEVEL
            result += Convert.ToInt32(stat[1]) * Convert.ToInt32(var[1]); // STRENGHT
            result += Convert.ToInt32(stat[2]) * Convert.ToInt32(var[2]); // DEXTERITY
            result += Convert.ToInt32(stat[3]) * Convert.ToInt32(var[3]); // AGILITY
            result += Convert.ToInt32(stat[4]) * Convert.ToInt32(var[4]); // CONSTITUTION
            result += Convert.ToInt32(stat[5]) * Convert.ToInt32(var[5]); // objectELLIGENCE
            result += Convert.ToInt32(stat[6]) * Convert.ToInt32(var[6]); // WISDOM
            result += Convert.ToInt32(stat[7]) * Convert.ToInt32(var[7]); // WILL
            result += Convert.ToInt32(stat[8]) * Convert.ToInt32(var[8]); // MIND
            result += Convert.ToInt32(stat[9]) * Convert.ToInt32(var[9]); // CHARISMA
            return result;
        }

        /// <summary>
        /// Limpa todos os dados
        /// </summary>
        public void Clear() {
            Strenght = Dexterity = Agility = Constitution = Intelligence = Wisdom = Will = Mind = Charisma = Points = 0;
            Array.Clear(inc_MaxHP, 0, MAX_STATS);
            Array.Clear(inc_MaxMP, 0, MAX_STATS);
            Array.Clear(inc_MaxSP, 0, MAX_STATS);
            Array.Clear(inc_RegenHP, 0, MAX_STATS);
            Array.Clear(inc_RegenMP, 0, MAX_STATS);
            Array.Clear(inc_RegenSP, 0, MAX_STATS);
            Array.Clear(inc_DamageSuppression, 0, MAX_STATS);
            Array.Clear(inc_Enmity, 0, MAX_STATS);
            Array.Clear(inc_AdditionalDamage, 0, MAX_STATS);
            Array.Clear(inc_HealingPower, 0, MAX_STATS);
            Array.Clear(inc_Concentration, 0, MAX_STATS);
            Array.Clear(inc_AttackSpeed, 0, MAX_STATS);
            Array.Clear(inc_CastSpeed, 0, MAX_STATS);
            Array.Clear(inc_Attack, 0, MAX_STATS);
            Array.Clear(inc_Accuracy, 0, MAX_STATS);
            Array.Clear(inc_Defense, 0, MAX_STATS);
            Array.Clear(inc_Evasion, 0, MAX_STATS);
            Array.Clear(inc_Block, 0, MAX_STATS);
            Array.Clear(inc_Parry, 0, MAX_STATS);
            Array.Clear(inc_CriticalRate, 0, MAX_STATS);
            Array.Clear(inc_CriticalDamage, 0, MAX_STATS);
            Array.Clear(inc_MagicAttack, 0, MAX_STATS);
            Array.Clear(inc_MagicAccuracy, 0, MAX_STATS);
            Array.Clear(inc_MagicDefense, 0, MAX_STATS);
            Array.Clear(inc_MagicResist, 0, MAX_STATS);
            Array.Clear(inc_MagicCriticalRate, 0, MAX_STATS);
            Array.Clear(inc_MagicCriticalDamage, 0, MAX_STATS);
            Array.Clear(inc_AttributeFire, 0, MAX_STATS);
            Array.Clear(inc_AttributeWater, 0, MAX_STATS);
            Array.Clear(inc_AttributeEarth, 0, MAX_STATS);
            Array.Clear(inc_AttributeWind, 0, MAX_STATS);
            Array.Clear(inc_ResistStun, 0, MAX_STATS);
            Array.Clear(inc_ResistParalysis, 0, MAX_STATS);
            Array.Clear(inc_ResistSilence, 0, MAX_STATS);
            Array.Clear(inc_ResistBlind, 0, MAX_STATS);
            Array.Clear(inc_ResistCriticalRate, 0, MAX_STATS);
            Array.Clear(inc_ResistCriticalDamage, 0, MAX_STATS);
            Array.Clear(inc_ResistMagicCriticalRate, 0, MAX_STATS);
            Array.Clear(inc_ResistMagicCriticalDamage, 0, MAX_STATS);
        }
    }
}

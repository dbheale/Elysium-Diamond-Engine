using System;
using MySql.Data.MySqlClient;
using GameServer.Classes;
using GameServer.Common;

namespace GameServer.MySQL {
    public static class Classes_DB {
        /// <summary>
        /// Carrega todas as classes.
        /// </summary>
        public static void GetClasseStatsBase() {
            var query = "SELECT * FROM classes";
            var cmd = new MySqlCommand(query, Common_DB.Connection);
            var reader = cmd.ExecuteReader();

            while (reader.Read()) {
                // para cada classe encontrada na db
                Classe.Classes.Add(new Classe());

                var index = Classe.Classes.Count - 1;
                var _base = Classe.Classes[index];

                _base.ID = (int)reader["id"];
                _base.IncrementID = (int)reader["increment_id"];
                _base.TalentID = (int)reader["talent_id"];
                _base.MaxHP = (int)reader["hp"];
                _base.MaxMP = (int)reader["mp"];
                _base.MaxSP = (int)reader["sp"];
                _base.RegenHP = (int)reader["regen_hp"];
                _base.RegenMP = (int)reader["regen_mp"];
                _base.RegenSP = (int)reader["regen_sp"];
                //_base.SpriteFemale = Convert.ToInt16(reader["sprite_female"]);
                //_base.SpriteMale = Convert.ToInt16(reader["sprite_male"]);
                _base.Level = (int)reader["level"];
                _base.Strenght = (int)reader["strenght"];
                _base.Dexterity = (int)reader["dexterity"];
                _base.Agility = (int)reader["agility"];
                _base.Constitution = (int)reader["constitution"];
                _base.Intelligence = (int)reader["intelligence"];
                _base.Wisdom = (int)reader["wisdom"];
                _base.Will = (int)reader["will"];
                _base.Mind = (int)reader["mind"];
                _base.Points = (int)reader["points"];
                _base.CriticalRate = (int)reader["critical_rate"];
                _base.CriticalDamage = (int)reader["critical_damage"];
                _base.MagicCriticalRate = (int)reader["magic_critical_rate"];
                _base.MagicCriticalDamage = (int)reader["magic_critical_damage"];
                _base.HealingPower = (int)reader["healing_power"];
                _base.Concentration = (int)reader["concentration"];
                _base.Attack = (int)reader["attack"];
                _base.Accuracy = (int)reader["accuracy"];
                _base.Defense = (int)reader["defense"];
                _base.Evasion = (int)reader["evasion"];
                _base.Block = (int)reader["block"];
                _base.Parry = (int)reader["parry"];
                _base.MagicAttack = (int)reader["magic_attack"];
                _base.MagicAccuracy = (int)reader["magic_accuracy"];
                _base.MagicDefense = (int)reader["magic_defense"];
                _base.MagicResist = (int)reader["magic_resist"];
                _base.DamageSuppression = (int)reader["damage_suppression"];
                _base.AdditionalDamage = (int)reader["additional_damage"];
                _base.Enmity = (int)reader["enmity"];
                _base.AttackSpeed = (int)reader["attack_speed"];
                _base.CastSpeed = (int)reader["cast_speed"];
                _base.AttributeFire = (int)reader["attribute_fire"];
                _base.AttributeWater = (int)reader["attribute_water"];
                _base.AttributeEarth = (int)reader["attribute_earth"];
                _base.AttributeWind = (int)reader["attribute_wind"];
                _base.AttributeLight = (int)reader["attribute_light"];
                _base.AttributeDark = (int)reader["attribute_dark"];
                _base.ResistStun = (int)reader["resist_stun"];
                _base.ResistSilence = (int)reader["resist_silence"];
                _base.ResistParalysis = (int)reader["resist_paralysis"];
                _base.ResistBlind = (int)reader["resist_blind"];
                _base.ResistCriticalRate = (int)reader["resist_critical_rate"];
                _base.ResistCriticalDamage = (int)reader["resist_critical_damage"];
                _base.ResistMagicCriticalRate = (int)reader["resist_magic_critical_rate"];
                _base.ResistMagicCriticalDamage = (int)reader["resist_magic_critical_damage"];

                index++;
            }

            reader.Close();
        }

        /// <summary>
        /// Carrega todos os incrementos de classe.
        /// </summary>
        public static void GetClasseStatsIncrement(int index, int incrementID) {
            var query = $"SELECT * FROM classe_increment WHERE id=?id";
            var cmd = new MySqlCommand(query, Common_DB.Connection);
            cmd.Parameters.AddWithValue("?id", incrementID);
            var reader = cmd.ExecuteReader();
            var _increment = Classe.Classes[index].Increment;

            while (reader.Read()) {
                _increment.IncrementID = (int)reader["id"];
                _increment.SetIncrementStat(StatType.MaxHP, (string)reader["hp"]);
                _increment.SetIncrementStat(StatType.MaxMP, (string)reader["mp"]);
                _increment.SetIncrementStat(StatType.MaxSP, (string)reader["sp"]);
                _increment.SetIncrementStat(StatType.RegenHP, (string)reader["regen_hp"]);
                _increment.SetIncrementStat(StatType.RegenMP, (string)reader["regen_mp"]);
                _increment.SetIncrementStat(StatType.RegenSP, (string)reader["regen_sp"]);
                _increment.Strenght = (int)reader["strenght"];
                _increment.Dexterity = (int)reader["dexterity"];
                _increment.Agility = (int)reader["agility"];
                _increment.Constitution = (int)reader["constitution"];
                _increment.Intelligence = (int)reader["intelligence"];
                _increment.Wisdom = (int)reader["wisdom"];
                _increment.Will = (int)reader["will"];
                _increment.Mind = (int)reader["mind"];
                _increment.Points = (int)reader["points"];
                _increment.SetIncrementStat(StatType.CriticalRate, (string)reader["critical_rate"]);
                _increment.SetIncrementStat(StatType.CriticalDamage, (string)reader["critical_damage"]);
                _increment.SetIncrementStat(StatType.MagicCriticalRate, (string)reader["magic_critical_rate"]);
                _increment.SetIncrementStat(StatType.MagicCriticalDamage, (string)reader["magic_critical_damage"]);
                _increment.SetIncrementStat(StatType.HealingPower, (string)reader["healing_power"]);
                _increment.SetIncrementStat(StatType.Concentration, (string)reader["concentration"]);
                _increment.SetIncrementStat(StatType.Attack, (string)reader["attack"]);
                _increment.SetIncrementStat(StatType.Accuracy, (string)reader["accuracy"]);
                _increment.SetIncrementStat(StatType.Defense, (string)reader["defense"]);
                _increment.SetIncrementStat(StatType.Evasion, (string)reader["evasion"]);
                _increment.SetIncrementStat(StatType.Block, (string)reader["block"]);
                _increment.SetIncrementStat(StatType.Parry, (string)reader["parry"]);
                _increment.SetIncrementStat(StatType.MagicAttack, (string)reader["magic_attack"]);
                _increment.SetIncrementStat(StatType.MagicAccuracy, (string)reader["magic_accuracy"]);
                _increment.SetIncrementStat(StatType.MagicDefense, (string)reader["magic_defense"]);
                _increment.SetIncrementStat(StatType.MagicResist, (string)reader["magic_resist"]);
                _increment.SetIncrementStat(StatType.DamageSuppression, (string)reader["damage_suppression"]);
                _increment.SetIncrementStat(StatType.AdditionalDamage, (string)reader["additional_damage"]);
                _increment.SetIncrementStat(StatType.Enmity, (string)reader["enmity"]);
                _increment.SetIncrementStat(StatType.AttackSpeed, (string)reader["attack_speed"]);
                _increment.SetIncrementStat(StatType.CastSpeed, (string)reader["cast_speed"]);
                _increment.SetIncrementStat(StatType.AttributeFire, (string)reader["attribute_fire"]);
                _increment.SetIncrementStat(StatType.AttributeWater, (string)reader["attribute_water"]);
                _increment.SetIncrementStat(StatType.AttributeEarth, (string)reader["attribute_earth"]);
                _increment.SetIncrementStat(StatType.AttributeWind, (string)reader["attribute_wind"]);
                _increment.SetIncrementStat(StatType.AttributeLight, (string)reader["attribute_light"]);
                _increment.SetIncrementStat(StatType.AttributeDark, (string)reader["attribute_dark"]);
                _increment.SetIncrementStat(StatType.ResistStun, (string)reader["resist_stun"]);
                _increment.SetIncrementStat(StatType.ResistSilence, (string)reader["resist_silence"]);
                _increment.SetIncrementStat(StatType.ResistParalysis, (string)reader["resist_paralysis"]);
                _increment.SetIncrementStat(StatType.ResistBlind, (string)reader["resist_blind"]);
                _increment.SetIncrementStat(StatType.ResistCriticalRate, (string)reader["resist_critical_rate"]);
                _increment.SetIncrementStat(StatType.ResistCriticalDamage, (string)reader["resist_critical_damage"]);
                _increment.SetIncrementStat(StatType.ResistMagicCriticalRate, (string)reader["resist_magic_critical_rate"]);
                _increment.SetIncrementStat(StatType.ResistMagicCriticalDamage, (string)reader["resist_magic_critical_damage"]);

                index++;
            }

            reader.Close();
        }

        /// <summary>
        /// Carrega todos os talentos de classe.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="talentID"></param>
        public static void GetClasseTalent(int index, int talentID) {
            var query = "SELECT * FROM classe_talent WHERE id=?id";
            var cmd = new MySqlCommand(query, Common_DB.Connection);
            cmd.Parameters.AddWithValue("?id", talentID);
            var reader = cmd.ExecuteReader();

            if (!reader.Read()) {
                reader.Close();
                return;
            }

            string[] balance = ((string)reader["balance"]).Split(',');
            string[] physic = ((string)reader["physic"]).Split(',');
            string[] magic = ((string)reader["magic"]).Split(',');
            string[] restoration = ((string)reader["restoration"]).Split(',');

            for (var n = 0; n < Constant.MAX_TALENT; n++) {
                Classe.Classes[index].Balance[n] = Convert.ToInt32(balance[n]);
                Classe.Classes[index].Physic[n] = Convert.ToInt32(physic[n]);
                Classe.Classes[index].Magic[n] = Convert.ToInt32(magic[n]);
                Classe.Classes[index].Restoration[n] = Convert.ToInt32(restoration[n]);
            }

            reader.Close();
        }
    }
}
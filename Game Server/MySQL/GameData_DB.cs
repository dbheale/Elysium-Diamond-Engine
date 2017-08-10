using System;
using GameServer.GameItem;
using GameServer.Server;
using GameServer.GameTalent;
using MySql.Data.MySqlClient;

namespace GameServer.MySQL {
    public static class GameData_DB { 
        public static void LoadExperience() {
            var varQUery = "SELECT level, exp_to_reach_lvl FROM data_exp";
            var cmd = new MySqlCommand(varQUery, Common_DB.Connection);
            var reader = cmd.ExecuteReader();
            var counter = 1;
 
            while (reader.Read()) {
                Experience.Level.Add(counter, Convert.ToInt64(reader["exp_to_reach_lvl"]));
                counter++;
            }

            Experience.Level.LevelMax = counter - 1;

            reader.Close();
        }

        public static void LoadItems() {
            var query = "SELECT * FROM items";
            var cmd = new MySqlCommand(query, Common_DB.Connection);
            var reader = cmd.ExecuteReader();

            while (reader.Read()) {
                var item = new ItemData();
                item.ID = (int)reader["id"];
                item.Useable = Convert.ToByte(reader["useable"]);
                item.Storable = Convert.ToByte(reader["storable"]);
                item.Package = Convert.ToInt16(reader["package"]);
                item.Handed = Convert.ToByte(reader["handed"]);
                item.Price = (int)reader["price"];
                item.Durability = Convert.ToInt16(reader["durability"]);
                item.Rarity = (ItemRarity)Convert.ToByte(reader["rarity"]);
                item.Type = (ItemType)Convert.ToByte(reader["type"]);
                item.AttackRange = Convert.ToByte(reader["attack_range"]);
                item.Level = Convert.ToInt16(reader["level"]);
                item.Stat[(int)StatType.MaxHP] = (int)reader["hp"];
                item.Stat[(int)StatType.MaxMP] = (int)reader["mp"];
                item.Stat[(int)StatType.MaxSP] = (int)reader["sp"];
                item.Stat[(int)StatType.RegenHP] = (int)reader["regen_hp"];
                item.Stat[(int)StatType.RegenMP] = (int)reader["regen_mp"];
                item.Stat[(int)StatType.RegenSP] = (int)reader["regen_sp"];
                item.Stat[(int)StatType.Strenght]  = (int)reader["strenght"];
                item.Stat[(int)StatType.Dexterity]  = (int)reader["dexterity"];
                item.Stat[(int)StatType.Agility]  = (int)reader["agility"];
                item.Stat[(int)StatType.Constitution]  = (int)reader["constitution"];
                item.Stat[(int)StatType.Intelligence]  = (int)reader["intelligence"];
                item.Stat[(int)StatType.Wisdom]  = (int)reader["wisdom"];
                item.Stat[(int)StatType.Will]  = (int)reader["will"];
                item.Stat[(int)StatType.Mind]  = (int)reader["mind"];
                item.Stat[(int)StatType.CriticalRate]  = (int)reader["critical_rate"];
                item.Stat[(int)StatType.CriticalDamage]  = (int)reader["critical_damage"];
                item.Stat[(int)StatType.MagicCriticalRate]  = (int)reader["magic_critical_rate"];
                item.Stat[(int)StatType.MagicCriticalDamage]  = (int)reader["magic_critical_damage"];
                item.Stat[(int)StatType.HealingPower]  = (int)reader["healing_power"];
                item.Stat[(int)StatType.Concentration]  = (int)reader["concentration"];
                item.Stat[(int)StatType.Attack]  = (int)reader["attack"];
                item.Stat[(int)StatType.Accuracy]  = (int)reader["accuracy"];
                item.Stat[(int)StatType.Defense]  = (int)reader["defense"];
                item.Stat[(int)StatType.Evasion]  = (int)reader["evasion"];
                item.Stat[(int)StatType.Block]  = (int)reader["block"];
                item.Stat[(int)StatType.Parry]  = (int)reader["parry"];
                item.Stat[(int)StatType.MagicAttack]  = (int)reader["magic_attack"];
                item.Stat[(int)StatType.MagicAccuracy]  = (int)reader["magic_accuracy"];
                item.Stat[(int)StatType.MagicDefense]  = (int)reader["magic_defense"];
                item.Stat[(int)StatType.MagicResist]  = (int)reader["magic_resist"];
                item.Stat[(int)StatType.DamageSuppression]  = (int)reader["damage_suppression"];
                item.Stat[(int)StatType.AdditionalDamage]  = (int)reader["additional_damage"];
                item.Stat[(int)StatType.Enmity]  = (int)reader["enmity"];
                item.Stat[(int)StatType.AttackSpeed]  = (int)reader["attack_speed"];
                item.Stat[(int)StatType.CastSpeed]  = (int)reader["cast_speed"];
                item.Stat[(int)StatType.AttributeFire]  = (int)reader["attribute_fire"];
                item.Stat[(int)StatType.AttributeWater]  = (int)reader["attribute_water"];
                item.Stat[(int)StatType.AttributeEarth]  = (int)reader["attribute_earth"];
                item.Stat[(int)StatType.AttributeWind]  = (int)reader["attribute_wind"];
                item.Stat[(int)StatType.AttributeLight]  = (int)reader["attribute_light"];
                item.Stat[(int)StatType.AttributeDark]  = (int)reader["attribute_dark"];
                item.Stat[(int)StatType.ResistStun]  = (int)reader["resist_stun"];
                item.Stat[(int)StatType.ResistSilence]  = (int)reader["resist_silence"];
                item.Stat[(int)StatType.ResistParalysis]  = (int)reader["resist_paralysis"];
                item.Stat[(int)StatType.ResistBlind]  = (int)reader["resist_blind"];
                item.Stat[(int)StatType.ResistCriticalRate]  = (int)reader["resist_critical_rate"];
                item.Stat[(int)StatType.ResistCriticalDamage]  = (int)reader["resist_critical_damage"];
                item.Stat[(int)StatType.ResistMagicCriticalRate]  = (int)reader["resist_magic_critical_rate"];
                item.Stat[(int)StatType.ResistMagicCriticalDamage]  = (int)reader["resist_magic_critical_damage"];

                ItemManager.Add(item);
            }

            reader.Close();
        }

        public static void LoadTalent() {
            var query = "SELECT * FROM talents";
            var cmd = new MySqlCommand(query, Common_DB.Connection);
            var reader = cmd.ExecuteReader();

            while (reader.Read()) {
                var talent = new TalentData();
                talent.ID = (int)reader["id"];
                talent.Requeriment = new Talent((int)reader["req_talent_id"], (int)reader["req_talent_level"]);
                talent.Type = (TalentType)Convert.ToByte(reader["type"]);
                talent.DataType = (TalentDataType)Convert.ToByte(reader["data_type"]);
                talent.SkillID = (int)reader["skill_id"];
                talent.SkillEffectID = (int)reader["skill_effect_id"];
                talent.MaxLevel = (int)reader["max_level"];
                talent.Stat[(int)StatType.Strenght] = (int)reader["strenght"];
                talent.Stat[(int)StatType.Dexterity] = (int)reader["dexterity"];
                talent.Stat[(int)StatType.Agility] = (int)reader["agility"];
                talent.Stat[(int)StatType.Constitution] = (int)reader["constitution"];
                talent.Stat[(int)StatType.Intelligence] = (int)reader["intelligence"];
                talent.Stat[(int)StatType.Wisdom] = (int)reader["wisdom"];
                talent.Stat[(int)StatType.Will] = (int)reader["will"];
                talent.Stat[(int)StatType.Mind] = (int)reader["mind"];
                talent.Stat[(int)StatType.MaxHP] = (int)reader["hp"];
                talent.Stat[(int)StatType.MaxMP] = (int)reader["mp"];
                talent.Stat[(int)StatType.MaxSP] = (int)reader["sp"];
                talent.Stat[(int)StatType.RegenHP] = (int)reader["regen_hp"];
                talent.Stat[(int)StatType.RegenMP] = (int)reader["regen_mp"];
                talent.Stat[(int)StatType.RegenSP] = (int)reader["regen_sp"];
                talent.Stat[(int)StatType.Strenght] = (int)reader["strenght"];
                talent.Stat[(int)StatType.Dexterity] = (int)reader["dexterity"];
                talent.Stat[(int)StatType.Agility] = (int)reader["agility"];
                talent.Stat[(int)StatType.Constitution] = (int)reader["constitution"];
                talent.Stat[(int)StatType.Intelligence] = (int)reader["intelligence"];
                talent.Stat[(int)StatType.Wisdom] = (int)reader["wisdom"];
                talent.Stat[(int)StatType.Will] = (int)reader["will"];
                talent.Stat[(int)StatType.Mind] = (int)reader["mind"];
                talent.Stat[(int)StatType.CriticalRate] = (int)reader["critical_rate"];
                talent.Stat[(int)StatType.CriticalDamage] = (int)reader["critical_damage"];
                talent.Stat[(int)StatType.MagicCriticalRate] = (int)reader["magic_critical_rate"];
                talent.Stat[(int)StatType.MagicCriticalDamage] = (int)reader["magic_critical_damage"];
                talent.Stat[(int)StatType.HealingPower] = (int)reader["healing_power"];
                talent.Stat[(int)StatType.Concentration] = (int)reader["concentration"];
                talent.Stat[(int)StatType.Attack] = (int)reader["attack"];
                talent.Stat[(int)StatType.Accuracy] = (int)reader["accuracy"];
                talent.Stat[(int)StatType.Defense] = (int)reader["defense"];
                talent.Stat[(int)StatType.Evasion] = (int)reader["evasion"];
                talent.Stat[(int)StatType.Block] = (int)reader["block"];
                talent.Stat[(int)StatType.Parry] = (int)reader["parry"];
                talent.Stat[(int)StatType.MagicAttack] = (int)reader["magic_attack"];
                talent.Stat[(int)StatType.MagicAccuracy] = (int)reader["magic_accuracy"];
                talent.Stat[(int)StatType.MagicDefense] = (int)reader["magic_defense"];
                talent.Stat[(int)StatType.MagicResist] = (int)reader["magic_resist"];
                talent.Stat[(int)StatType.DamageSuppression] = (int)reader["damage_suppression"];
                talent.Stat[(int)StatType.AdditionalDamage] = (int)reader["additional_damage"];
                talent.Stat[(int)StatType.Enmity] = (int)reader["enmity"];
                talent.Stat[(int)StatType.AttackSpeed] = (int)reader["attack_speed"];
                talent.Stat[(int)StatType.CastSpeed] = (int)reader["cast_speed"];
                talent.Stat[(int)StatType.AttributeFire] = (int)reader["attribute_fire"];
                talent.Stat[(int)StatType.AttributeWater] = (int)reader["attribute_water"];
                talent.Stat[(int)StatType.AttributeEarth] = (int)reader["attribute_earth"];
                talent.Stat[(int)StatType.AttributeWind] = (int)reader["attribute_wind"];
                talent.Stat[(int)StatType.AttributeLight] = (int)reader["attribute_light"];
                talent.Stat[(int)StatType.AttributeDark] = (int)reader["attribute_dark"];
                talent.Stat[(int)StatType.ResistStun] = (int)reader["resist_stun"];
                talent.Stat[(int)StatType.ResistSilence] = (int)reader["resist_silence"];
                talent.Stat[(int)StatType.ResistParalysis] = (int)reader["resist_paralysis"];
                talent.Stat[(int)StatType.ResistBlind] = (int)reader["resist_blind"];
                talent.Stat[(int)StatType.ResistCriticalRate] = (int)reader["resist_critical_rate"];
                talent.Stat[(int)StatType.ResistCriticalDamage] = (int)reader["resist_critical_damage"];
                talent.Stat[(int)StatType.ResistMagicCriticalRate] = (int)reader["resist_magic_critical_rate"];
                talent.Stat[(int)StatType.ResistMagicCriticalDamage] = (int)reader["resist_magic_critical_damage"];

                TalentManager.Talent.Add(talent);
            }

            reader.Close();
        }
    }
}

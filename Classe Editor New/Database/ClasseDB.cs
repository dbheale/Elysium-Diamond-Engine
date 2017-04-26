using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using Classe_Editor.ClasseData;

namespace Classe_Editor.Database {
    public class ClasseDB {
        public static bool ExistClasse(int id) {
            var query = "SELECT name FROM classes WHERE id=?id";
            var cmd = new MySqlCommand(query, MySQL.GameDB.Connection);
            cmd.Parameters.AddWithValue("?id", id);
            var reader = cmd.ExecuteReader();
            var result = reader.Read();
            reader.Close();

            return result;
        }

        public static List<ListClasseData> GetClasseBasicData(string table) {
            var query = $"SELECT id, name FROM {table}";
            var cmd = new MySqlCommand(query, MySQL.GameDB.Connection);
            var reader = cmd.ExecuteReader();
            var list = new List<ListClasseData>();
            var data = new ListClasseData();

            while(reader.Read()) {
                data.ID = (int)reader["id"];
                data.Name = (string)reader["name"];

                list.Add(data);
            }

            reader.Close();
            return list;
        }

        public static int InsertClasse(Classe cData) {
            var query = new StringBuilder();
            query.Append("INSERT INTO classes (id, increment_id, name, sprite, level, hp, mp, sp, regen_hp, regen_mp, regen_sp, ");
            query.Append("strenght, dexterity, agility, constitution, intelligence, will, wisdom, mind, charisma, points, ");
            query.Append("critical_rate, critical_damage, magic_critical_rate, magic_critical_damage, healing_power, concentration, ");
            query.Append("attack, accuracy, defense, evasion, block, parry, magic_attack, magic_accuracy, magic_defense, magic_resist, ");
            query.Append("damage_suppression, additional_damage, enmity, attack_speed, cast_speed, attribute_fire, attribute_water, ");
            query.Append("attribute_earth, attribute_wind, attribute_light, attribute_dark, resist_stun, resist_silence, resist_paralysis, resist_blind, ");
            query.Append("resist_critical_rate, resist_critical_damage, resist_magic_critical_rate, resist_magic_critical_damage) VALUES (");
            query.Append("?id, ?increment, ?name, ?sprite, ?level, ?hp, ?mp, ?sp, ?regen_hp, ?regen_mp, ?regen_sp, ");
            query.Append("?strenght, ?dexterity, ?agility, ?constitution, ?intelligence, ?will, ?wisdom, ?mind, ?charisma, ?points, ");
            query.Append("?critical_rate, ?critical_damage, ?magic_critical_rate, ?magic_critical_damage, ?healing_power, ?concentration, ");
            query.Append("?attack, ?accuracy, ?defense, ?evasion, ?block, ?parry, ?magic_attack, ?magic_accuracy, ?magic_defense, ?magic_resist, ");
            query.Append("?damage_suppression, ?additional_damage, ?enmity, ?attack_speed, ?cast_speed, ?attribute_fire, ?attribute_water, ");
            query.Append("?attribute_earth, ?attribute_wind, ?attribute_light, ?attribute_dark, ?resist_stun, ?resist_silence, ?resist_paralysis, ?resist_blind, ");
            query.Append("?resist_critical_rate, ?resist_critical_damage, ?resist_magic_critical_rate, ?resist_magic_critical_damage)");

            var cmd = new MySqlCommand(query.ToString(), MySQL.GameDB.Connection);
            cmd.Parameters.AddWithValue("?id", cData.ID);
            cmd.Parameters.AddWithValue("?increment", cData.IncrementID);
            cmd.Parameters.AddWithValue("?name", cData.Name);
            cmd.Parameters.AddWithValue("?sprite", cData.Sprite);
            cmd.Parameters.AddWithValue("?level", cData.Level);
            cmd.Parameters.AddWithValue("?hp", cData.HP);
            cmd.Parameters.AddWithValue("?mp", cData.MP);
            cmd.Parameters.AddWithValue("?sp", cData.SP);
            cmd.Parameters.AddWithValue("?regen_hp", cData.RegenHP);
            cmd.Parameters.AddWithValue("?regen_mp", cData.RegenMP);
            cmd.Parameters.AddWithValue("?regen_sp", cData.RegenSP);
            cmd.Parameters.AddWithValue("?strenght", cData.Strenght);
            cmd.Parameters.AddWithValue("?dexterity", cData.Dexterity);
            cmd.Parameters.AddWithValue("?agility", cData.Agility);
            cmd.Parameters.AddWithValue("?constitution", cData.Constitution);
            cmd.Parameters.AddWithValue("?intelligence", cData.Intelligence);
            cmd.Parameters.AddWithValue("?will", cData.Will);
            cmd.Parameters.AddWithValue("?wisdom", cData.Wisdom);
            cmd.Parameters.AddWithValue("?mind", cData.Mind);
            cmd.Parameters.AddWithValue("?charisma", cData.Charisma);
            cmd.Parameters.AddWithValue("?points", cData.Points);
            cmd.Parameters.AddWithValue("?critical_rate", cData.CriticalRate);
            cmd.Parameters.AddWithValue("?critical_damage", cData.CriticalDamage);
            cmd.Parameters.AddWithValue("?magic_critical_rate", cData.MagicCriticalRate);
            cmd.Parameters.AddWithValue("?magic_critical_damage", cData.MagicCriticalDamage);
            cmd.Parameters.AddWithValue("?healing_power", cData.HealingPower);
            cmd.Parameters.AddWithValue("?concentration", cData.Concentration);
            cmd.Parameters.AddWithValue("?attack", cData.Attack);
            cmd.Parameters.AddWithValue("?accuracy", cData.Accuracy);
            cmd.Parameters.AddWithValue("?defense", cData.Defense);
            cmd.Parameters.AddWithValue("?evasion", cData.Evasion);
            cmd.Parameters.AddWithValue("?block", cData.Block);
            cmd.Parameters.AddWithValue("?parry", cData.Parry);
            cmd.Parameters.AddWithValue("?magic_attack", cData.MagicAttack);
            cmd.Parameters.AddWithValue("?magic_accuracy", cData.MagicAccuracy);
            cmd.Parameters.AddWithValue("?magic_defense", cData.MagicDefense);
            cmd.Parameters.AddWithValue("?magic_resist", cData.MagicResist);
            cmd.Parameters.AddWithValue("?damage_suppression", cData.DamageSuppression);
            cmd.Parameters.AddWithValue("?additional_damage", cData.AdditionalDamage);
            cmd.Parameters.AddWithValue("?enmity", cData.Enmity);
            cmd.Parameters.AddWithValue("?attack_speed", cData.AttackSpeed);
            cmd.Parameters.AddWithValue("?cast_speed", cData.CastSpeed);
            cmd.Parameters.AddWithValue("?attribute_fire", cData.AttributeFire);
            cmd.Parameters.AddWithValue("?attribute_water", cData.AttributeWater);
            cmd.Parameters.AddWithValue("?attribute_earth", cData.AttributeEarth);
            cmd.Parameters.AddWithValue("?attribute_wind", cData.AttributeWind);
            cmd.Parameters.AddWithValue("?attribute_light", cData.AttributeLight);
            cmd.Parameters.AddWithValue("?attribute_dark", cData.AttributeDark);
            cmd.Parameters.AddWithValue("?resist_stun", cData.ResistStun);
            cmd.Parameters.AddWithValue("?resist_silence", cData.ResistSilence);
            cmd.Parameters.AddWithValue("?resist_paralysis", cData.ResistParalysis);
            cmd.Parameters.AddWithValue("?resist_blind", cData.ResistBlind);
            cmd.Parameters.AddWithValue("?resist_critical_rate", cData.ResistCriticalRate);
            cmd.Parameters.AddWithValue("?resist_critical_damage", cData.ResistCriticalDamage);
            cmd.Parameters.AddWithValue("?resist_magic_critical_rate", cData.ResistMagicCriticalRate);
            cmd.Parameters.AddWithValue("?resist_magic_critical_damage", cData.ResistMagicCriticalDamage);

            var result = cmd.ExecuteNonQuery();
            return result;
        }

        public static int UpdateClasse(Classe cData, int oldID) {
            var query = new StringBuilder();
            query.Append("UPDATE classes SET id=?id, increment_id=?increment, name=?name, sprite=?sprite, level=?level, ");
            query.Append("hp=?hp, mp=?mp, sp=?sp, regen_hp=?regen_hp, regen_mp=?regen_mp, regen_sp=?regen_sp, ");
            query.Append("strenght=?strenght, dexterity=?dexterity, agility=?agility, constitution=?constitution, intelligence=?intelligence, ");
            query.Append("will=?will, wisdom=?wisdom, mind=?mind, charisma=?charisma, points=?points, critical_rate=?critical_rate, ");
            query.Append("critical_damage=?critical_damage, magic_critical_rate=?magic_critical_rate, magic_critical_damage=?magic_critical_damage, ");
            query.Append("healing_power=?healing_power, concentration=?concentration, attack=?attack, accuracy=?accuracy, defense=?defense, ");
            query.Append("evasion=?evasion, block=?block, parry=?parry, magic_attack=?magic_attack, magic_accuracy=?magic_accuracy, ");
            query.Append("magic_defense=?magic_defense, magic_resist=?magic_resist, damage_suppression=?damage_suppression, additional_damage=?additional_damage, ");
            query.Append("enmity=?enmity, attack_speed=?attack_speed, cast_speed=?cast_speed, attribute_fire=?attribute_fire, attribute_water=?attribute_water, ");
            query.Append("attribute_earth=?attribute_earth, attribute_wind=?attribute_wind, attribute_light=?attribute_light, attribute_dark=?attribute_dark, ");
            query.Append("resist_stun=?resist_stun, resist_silence=?resist_silence, resist_paralysis=?resist_paralysis, resist_blind=?resist_blind, ");
            query.Append("resist_critical_rate=?resist_critical_rate, resist_critical_damage=?resist_critical_damage, resist_magic_critical_rate=?resist_magic_critical_rate, resist_magic_critical_damage=?resist_magic_critical_damage WHERE id=?oldID");
   
            var cmd = new MySqlCommand(query.ToString(), MySQL.GameDB.Connection);
            cmd.Parameters.AddWithValue("?id", cData.ID);
            cmd.Parameters.AddWithValue("?increment", cData.IncrementID);
            cmd.Parameters.AddWithValue("?name", cData.Name);
            cmd.Parameters.AddWithValue("?sprite", cData.Sprite);
            cmd.Parameters.AddWithValue("?level", cData.Level);
            cmd.Parameters.AddWithValue("?hp", cData.HP);
            cmd.Parameters.AddWithValue("?mp", cData.MP);
            cmd.Parameters.AddWithValue("?sp", cData.SP);
            cmd.Parameters.AddWithValue("?regen_hp", cData.RegenHP);
            cmd.Parameters.AddWithValue("?regen_mp", cData.RegenMP);
            cmd.Parameters.AddWithValue("?regen_sp", cData.RegenSP);
            cmd.Parameters.AddWithValue("?strenght", cData.Strenght);
            cmd.Parameters.AddWithValue("?dexterity", cData.Dexterity);
            cmd.Parameters.AddWithValue("?agility", cData.Agility);
            cmd.Parameters.AddWithValue("?constitution", cData.Constitution);
            cmd.Parameters.AddWithValue("?intelligence", cData.Intelligence);
            cmd.Parameters.AddWithValue("?will", cData.Will);
            cmd.Parameters.AddWithValue("?wisdom", cData.Wisdom);
            cmd.Parameters.AddWithValue("?mind", cData.Mind);
            cmd.Parameters.AddWithValue("?charisma", cData.Charisma);
            cmd.Parameters.AddWithValue("?points", cData.Points);
            cmd.Parameters.AddWithValue("?critical_rate", cData.CriticalRate);
            cmd.Parameters.AddWithValue("?critical_damage", cData.CriticalDamage);
            cmd.Parameters.AddWithValue("?magic_critical_rate", cData.MagicCriticalRate);
            cmd.Parameters.AddWithValue("?magic_critical_damage", cData.MagicCriticalDamage);
            cmd.Parameters.AddWithValue("?healing_power", cData.HealingPower);
            cmd.Parameters.AddWithValue("?concentration", cData.Concentration);
            cmd.Parameters.AddWithValue("?attack", cData.Attack);
            cmd.Parameters.AddWithValue("?accuracy", cData.Accuracy);
            cmd.Parameters.AddWithValue("?defense", cData.Defense);
            cmd.Parameters.AddWithValue("?evasion", cData.Evasion);
            cmd.Parameters.AddWithValue("?block", cData.Block);
            cmd.Parameters.AddWithValue("?parry", cData.Parry);
            cmd.Parameters.AddWithValue("?magic_attack", cData.MagicAttack);
            cmd.Parameters.AddWithValue("?magic_accuracy", cData.MagicAccuracy);
            cmd.Parameters.AddWithValue("?magic_defense", cData.MagicDefense);
            cmd.Parameters.AddWithValue("?magic_resist", cData.MagicResist);
            cmd.Parameters.AddWithValue("?damage_suppression", cData.DamageSuppression);
            cmd.Parameters.AddWithValue("?additional_damage", cData.AdditionalDamage);
            cmd.Parameters.AddWithValue("?enmity", cData.Enmity);
            cmd.Parameters.AddWithValue("?attack_speed", cData.AttackSpeed);
            cmd.Parameters.AddWithValue("?cast_speed", cData.CastSpeed);
            cmd.Parameters.AddWithValue("?attribute_fire", cData.AttributeFire);
            cmd.Parameters.AddWithValue("?attribute_water", cData.AttributeWater);
            cmd.Parameters.AddWithValue("?attribute_earth", cData.AttributeEarth);
            cmd.Parameters.AddWithValue("?attribute_wind", cData.AttributeWind);
            cmd.Parameters.AddWithValue("?attribute_light", cData.AttributeLight);
            cmd.Parameters.AddWithValue("?attribute_dark", cData.AttributeDark);
            cmd.Parameters.AddWithValue("?resist_stun", cData.ResistStun);
            cmd.Parameters.AddWithValue("?resist_silence", cData.ResistSilence);
            cmd.Parameters.AddWithValue("?resist_paralysis", cData.ResistParalysis);
            cmd.Parameters.AddWithValue("?resist_blind", cData.ResistBlind);
            cmd.Parameters.AddWithValue("?resist_critical_rate", cData.ResistCriticalRate);
            cmd.Parameters.AddWithValue("?resist_critical_damage", cData.ResistCriticalDamage);
            cmd.Parameters.AddWithValue("?resist_magic_critical_rate", cData.ResistMagicCriticalRate);
            cmd.Parameters.AddWithValue("?resist_magic_critical_damage", cData.ResistMagicCriticalDamage);
            cmd.Parameters.AddWithValue("?oldID", oldID);

            var result = cmd.ExecuteNonQuery();
            return result;
        }

        public static Classe LoadClasseData(int classeID) {
            var query = "SELECT * FROM classes WHERE id=?id";
            var cmd = new MySqlCommand(query, MySQL.GameDB.Connection);
            cmd.Parameters.AddWithValue("?id", classeID);
            var reader = cmd.ExecuteReader();

            if (!reader.Read()) {
                reader.Close();
                return new Classe();
            }

            var classe = new Classe();
            classe.ID = (int)reader["id"];
            classe.OldID = classe.ID;
            classe.IncrementID = (int)reader["increment_id"];
            classe.Name = (string)reader["name"];
            classe.Sprite = Convert.ToInt16(reader["sprite"]);
            classe.Level = (int)reader["level"];
            classe.HP = (int)reader["hp"];
            classe.MP = (int)reader["mp"];
            classe.SP = (int)reader["sp"];
            classe.RegenHP = (int)reader["regen_hp"];
            classe.RegenMP = (int)reader["regen_mp"];
            classe.RegenSP = (int)reader["regen_sp"];
            classe.Strenght = (int)reader["strenght"];
            classe.Dexterity = (int)reader["dexterity"];
            classe.Agility = (int)reader["agility"];
            classe.Constitution = (int)reader["constitution"];
            classe.Intelligence = (int)reader["intelligence"];
            classe.Will = (int)reader["will"];
            classe.Wisdom = (int)reader["wisdom"];
            classe.Mind = (int)reader["mind"];
            classe.Charisma = (int)reader["charisma"];
            classe.Points = (int)reader["points"];
            classe.CriticalRate = (int)reader["critical_rate"];
            classe.CriticalDamage = (int)reader["critical_damage"];
            classe.MagicCriticalRate = (int)reader["magic_critical_rate"];
            classe.MagicCriticalDamage = (int)reader["magic_critical_damage"];
            classe.HealingPower = (int)reader["healing_power"];
            classe.Concentration = (int)reader["concentration"];
            classe.Attack = (int)reader["attack"];
            classe.Accuracy = (int)reader["accuracy"];
            classe.Defense = (int)reader["defense"];
            classe.Evasion = (int)reader["evasion"];
            classe.Block = (int)reader["block"];
            classe.Parry = (int)reader["parry"];
            classe.MagicAttack = (int)reader["magic_attack"];
            classe.MagicAccuracy = (int)reader["magic_accuracy"];
            classe.MagicDefense = (int)reader["magic_defense"];
            classe.MagicResist = (int)reader["magic_resist"];
            classe.DamageSuppression = (int)reader["damage_suppression"];
            classe.AdditionalDamage = (int)reader["additional_damage"];
            classe.Enmity = (int)reader["enmity"];
            classe.AttackSpeed = (int)reader["attack_speed"];
            classe.CastSpeed = (int)reader["cast_speed"];
            classe.AttributeFire = (int)reader["attribute_fire"];
            classe.AttributeWater = (int)reader["attribute_water"];
            classe.AttributeEarth = (int)reader["attribute_earth"];
            classe.AttributeWind = (int)reader["attribute_wind"];
            classe.AttributeLight = (int)reader["attribute_light"];
            classe.AttributeDark = (int)reader["attribute_dark"];
            classe.ResistStun = (int)reader["resist_stun"];
            classe.ResistSilence = (int)reader["resist_silence"];
            classe.ResistParalysis = (int)reader["resist_paralysis"];
            classe.ResistBlind = (int)reader["resist_blind"];
            classe.ResistCriticalRate = (int)reader["resist_critical_rate"];
            classe.ResistCriticalDamage = (int)reader["resist_critical_damage"];
            classe.ResistMagicCriticalRate = (int)reader["resist_magic_critical_rate"];
            classe.ResistMagicCriticalDamage = (int)reader["resist_magic_critical_damage"];

            reader.Close();

            return classe;
        }
    }
}

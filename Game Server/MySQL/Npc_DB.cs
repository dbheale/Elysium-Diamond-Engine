using System;
using MySql.Data.MySqlClient;
using GameServer.Npcs;

namespace GameServer.MySQL {
    public static class Npc_DB {

        /// <summary>
        /// Carrega os dados de todos os npcs.
        /// </summary>
        public static void LoadNpcData() {
            var varQuery = "SELECT * FROM npc";
            var cmd = new MySqlCommand(varQuery, Common_DB.Connection);
            var reader = cmd.ExecuteReader();
            Npc npc;

            while (reader.Read()) {
                npc = new Npc();
                npc.ID = (int)reader["id"];
                npc.Sprite = Convert.ToInt16(reader["sprite"]);
                npc.Type = (NpcType)Convert.ToInt16(reader["type"]);
                npc.Elite = (NpcEliteType)Convert.ToInt16(reader["elite"]);
                npc.Level = (int)reader["level"];
                npc.Experience = (int)reader["experience"];
                npc.HP = (int)reader["hp"];
                npc.RegenHP = (int)reader["regen_hp"];
                npc.Attack = (int)reader["attack"];
                npc.Accuracy = (int)reader["accuracy"];
                npc.Defense = (int)reader["defense"];
                npc.Evasion = (int)reader["evasion"];
                npc.Block = (int)reader["block"];
                npc.Parry = (int)reader["parry"];
                npc.AttackSpeed = (int)reader["attack_speed"];
                npc.CastSpeed = (int)reader["attack_speed"];
                npc.MagicAttack = (int)reader["magic_attack"];
                npc.MagicAccuracy = (int)reader["magic_accuracy"];
                npc.MagicDefense = (int)reader["magic_defense"];
                npc.MagicResist = (int)reader["magic_resist"];
                npc.AttributeFire = (int)reader["attribute_fire"];
                npc.AttributeWater = (int)reader["attribute_water"];
                npc.AttributeEarth = (int)reader["attribute_earth"];
                npc.AttributeWind = (int)reader["attribute_wind"];
                npc.AttributeDark = (int)reader["attribute_dark"];
                npc.AttributeLight = (int)reader["attribute_light"];
                npc.ResistStun = (int)reader["resist_stun"];
                npc.ResistParalysis = (int)reader["resist_paralysis"];
                npc.ResistSilence = (int)reader["resist_silence"];
                npc.ResistBlind = (int)reader["resist_blind"];
                npc.ResistCriticalRate = (int)reader["resist_critical_rate"];
                npc.ResistCriticalDamage = (int)reader["resist_critical_damage"];
                npc.ResistMagicCriticalRate = (int)reader["resist_magic_critical_rate"];
                npc.ResistMagicCriticalDamage = (int)reader["resist_magic_critical_damage"];

                NpcManager.Add(npc);
            }

            reader.Close();
        }
    }
}

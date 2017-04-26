using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace NpcEditor {
    public static class MySQL {
        public static MySqlConnection Connection { get; set; } = null;
        public static string Server { get; set; }
        public static int Port { get; set; }
        public static string Username { get; set; }
        public static string Password { get; set; }
        public static string Database { get; set; }

        private static HashSet<string> dic = new HashSet<string>();

        /// <summary>
        /// Realiza a conexão com o banco de dados.
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public static bool Connect(out string error) {
            var varQuery = "Server=" + Server + ";";
            varQuery += "Port=" + Port + ";";
            varQuery += "Database=" + Database + ";";
            varQuery += "User ID=" + Username + ";";
            varQuery += "Password=" + Password + ";";

            try {
                Connection = new MySqlConnection();
                Connection.ConnectionString = varQuery;
                Connection.Open();
            }
            catch (MySqlException ex) {
                error = ex.Message;
                return false;
            }
            finally {
                varQuery = string.Empty;
            }

            error = string.Empty;
            return true;
        }

        /// <summary>
        /// Desconexão com a DB.
        /// </summary>
        /// <returns></returns>
        public static bool Disconnect() {
            if (Connection.State != ConnectionState.Closed) {
                Connection.Close();
                Connection.Dispose();
            }

            if (Connection.State == ConnectionState.Closed)
                return true;
            else
                return false;
        }


        public static HashSet<string> FindNpc(string name, int id) {
            dic.Clear();

            if (id == 0) {
                var varQuery = "SELECT id, name FROM npc WHERE name LIKE '%" + name + "%'";
                var cmd = new MySqlCommand(varQuery, Connection);
                var reader = cmd.ExecuteReader();

                while (reader.Read()) {
                    dic.Add(reader["id"] + ": " + reader["name"]);
                }

                reader.Close();
                return dic; 
            }

            if (id > 0) {
                var varQuery = "SELECT id, name FROM npc WHERE id LIKE '%" + id + "%'";
                var cmd = new MySqlCommand(varQuery, Connection);
                var reader = cmd.ExecuteReader();

                while (reader.Read()) {
                    dic.Add(reader["id"] + ": " + reader["name"]);
                }

                reader.Close();
                return dic;
            }

            return dic;
        }
        /// <summary>
        /// Carrega todos os NPC.
        /// </summary>
        public static void InitializeNpc() {
            var varQuery = "SELECT * FROM npc";
            var cmd = new MySqlCommand(varQuery, Connection);
            var reader = cmd.ExecuteReader();
            NpcData npc;

            while (reader.Read()) {
                npc = new NpcData();
                npc.ID = (int)reader["id"];
                npc.Sprite = (int)reader["sprite"];
                npc.Elite = (int)reader["elite"];
                npc.Type = (int)reader["type"];
                npc.Level = (int)reader["level"];
                npc.HP = npc.MaxHP = (int)reader["hp"];
                npc.RegenHP = (int)reader["regen_hp"];
                npc.Attack = (int)reader["attack"];
                npc.Accuracy = (int)reader["accuracy"];
                npc.Defense = (int)reader["defense"];
                npc.Evasion = (int)reader["evasion"];
                npc.Block = (int)reader["block"];
                npc.Parry = (int)reader["parry"];
                npc.Experience = (int)reader["experience"];
                npc.AttackSpeed = (int)reader["attack_speed"];
                npc.MagicAttack = (int)reader["magic_attack"];
                npc.MagicAccuracy = (int)reader["magic_accuracy"];
                npc.MagicDefense = (int)reader["magic_defense"];
                npc.MagicResist = (int)reader["magic_resist"];
                npc.AttributeFire = (int)reader["attribute_fire"];
                npc.AttributeWater = (int)reader["attribute_water"];
                npc.AttributeEarth = (int)reader["attribute_earth"];
                npc.AttributeWind = (int)reader["attribute_wind"];
                npc.ResistStun = (int)reader["resist_stun"];
                npc.ResistParalysis = (int)reader["resist_paralysis"];
                npc.ResistSilence = (int)reader["resist_silence"];
                npc.ResistBlind = (int)reader["resist_blind"];
                npc.ResistCriticalRate = (int)reader["resist_critical_rate"];
                npc.ResistCriticalDamage = (int)reader["resist_critical_damage"];
                npc.ResistMagicCriticalRate = (int)reader["resist_magic_critical_rate"];
                npc.ResistMagicCriticalDamage = (int)reader["resist_magic_critical_damage"];
                npc.ParseSkill((string)reader["skill"]);
                npc.ParseQuest((string)reader["quest"]);
                npc.ParseShop((string)reader["shop"]);
            }

            reader.Close();
        }
    }
}

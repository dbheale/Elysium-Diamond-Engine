using System;
using System.Text;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using WorldServer.Server;
using WorldServer.Common;

namespace WorldServer.MySQL {
    public static class Character_DB {
        /// <summary>
        /// Pega o ID do personagem.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static int ID(string name) {
            var query = "SELECT id FROM players WHERE name=?name";
            var cmd = new MySqlCommand(query, Common_DB.Connection);
            cmd.Parameters.AddWithValue("?name", name);
            var reader = cmd.ExecuteReader();

            if (!reader.Read()) {
                reader.Close();
                return -1;
            }

            var result = (int)reader["id"];
            reader.Close();

            return result;
        }

        /// <summary>
        /// Verifica se o nome existe no banco de dados.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool Exist(string name) {
            var query = "SELECT id FROM players WHERE name=?name";
            var cmd = new MySqlCommand(query, Common_DB.Connection);
            cmd.Parameters.AddWithValue("?name", name);
            var reader = cmd.ExecuteReader();

            var result = reader.Read();
            reader.Close();

            return result;
        }

        /// <summary>
        /// Retorna o nome do personagem a partir do slot.
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="charSlot"></param>
        /// <returns></returns>
        public static string GetName(int accountID, int charSlot) {
            var query = "SELECT name FROM players WHERE account_id=?accountID and char_slot=?charSlot";
            var cmd = new MySqlCommand(query, Common_DB.Connection);
            cmd.Parameters.AddWithValue("?accountID", accountID);
            cmd.Parameters.AddWithValue("?charSlot", charSlot);
            var reader = cmd.ExecuteReader();

            if (!reader.Read()) {
                reader.Close();
                return string.Empty;
            }

            var result = (string)reader["name"];

            reader.Close();

            return result;
        }

        /// <summary>
        /// Retorna o level de um personagem.
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="charSlot"></param>
        /// <returns></returns>
        public static int GetLevel(int accountID, int charSlot) {
            var query = "SELECT level FROM players WHERE account_id=?accountID and char_slot=?charslot";
            var cmd = new MySqlCommand(query, Common_DB.Connection);
            cmd.Parameters.AddWithValue("?accountID", accountID);
            cmd.Parameters.AddWithValue("?charslot", charSlot);
            var reader = cmd.ExecuteReader();

            if (!reader.Read()) {
                reader.Close();
                return 0;
            }

            var result = (int)reader["level"];
            reader.Close();

            return result;
        }

        /// <summary>
        /// Obtem o ID de região de um personagem.
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="charSlot"></param>
        /// <returns></returns>
        public static int GetRegionID(int accountID, int charSlot) {
            var query = "SELECT region_id FROM players WHERE account_id=?accountID and char_slot=?charslot";
            var cmd = new MySqlCommand(query, Common_DB.Connection);
            cmd.Parameters.AddWithValue("?accountID", accountID);
            cmd.Parameters.AddWithValue("?charslot", charSlot);
            var reader = cmd.ExecuteReader();

            if (!reader.Read()) {
                reader.Close();
                return 0;
            }

            var result = (int)reader["region_id"];
            reader.Close();

            return result;
        }

        /// <summary>
        /// Verifica se o personagem está pendente para exclusão.
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="charSlot"></param>
        /// <returns></returns>
        public static bool IsPendingDeletion(int accountID, int charSlot) {
            var query = "SELECT pending_deletion FROM players WHERE account_id=?accountID AND char_slot=?charslot";
            var cmd = new MySqlCommand(query, Common_DB.Connection);
            cmd.Parameters.AddWithValue("?accountID", accountID);
            cmd.Parameters.AddWithValue("?charslot", charSlot);
            var reader = cmd.ExecuteReader();

            if (!reader.Read()) {
                reader.Close();
                return false;
            }

            var result = Convert.ToBoolean(reader["pending_deletion"]);

            reader.Close();

            return result;
        }

        /// <summary>
        /// Deleta o personagem.
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="charSlot"></param>
        public static bool Delete(int accountID, int charSlot) {
            var query = "DELETE FROM players WHERE account_id=?accountID AND char_slot=?charslot";
            var cmd = new MySqlCommand(query, Common_DB.Connection);
            cmd.Parameters.AddWithValue("?accountID", accountID);
            cmd.Parameters.AddWithValue("?charslot", charSlot);

            try {
                cmd.ExecuteNonQuery();
            }
            catch {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Deleta os dados do personagem em determinada tabela.
        /// </summary>
        /// <param name="charID"></param>
        /// <param name="query"></param>
        public static void Delete(int charID, string query) {
            var cmd = new MySqlCommand(query, Common_DB.Connection);
            cmd.Parameters.AddWithValue("?charID", charID);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Carrega dados temporarios dos personagens.
        /// </summary>
        /// <param name="pData"></param>
        public static void PreLoad(PlayerData pData) {
            var query = "SELECT id, classe_id, char_slot, name, sprite, level, deletion_date, pending_deletion FROM players WHERE account_id=?accountID";
            var cmd = new MySqlCommand(query, Common_DB.Connection);
            cmd.Parameters.AddWithValue("?accountID", pData.AccountID);
            var reader = cmd.ExecuteReader();

            pData.ClearCharacter();

            while (reader.Read()) {
                var slot = (int)reader["char_slot"];

                pData.Character[slot].ID = (int)reader["id"];
                pData.Character[slot].Name = (string)reader["name"];
                pData.Character[slot].Level = (int)reader["level"];
                pData.Character[slot].Class = (int)reader["classe_id"];
                pData.Character[slot].Sprite = Convert.ToInt16(reader["sprite"]);
                pData.Character[slot].PendingDeletion = Convert.ToBoolean(reader["pending_deletion"]);

                if (pData.Character[slot].PendingDeletion) {
                    pData.Character[slot].DeletionTime = Convert.ToDateTime(reader["deletion_date"]);
                }                   
            }

            reader.Close();
        }

        /// <summary>
        /// Carrega os dados do personagem.
        /// </summary>
        /// <param name="pData"></param>
        /// <param name="charSlot"></param>
        public static void Load(PlayerData pData, int charSlot) {
            var query = "SELECT id, guild_id, name, world_id, region_id FROM players WHERE account_id=?accountID AND char_slot=?charSlot";
            var cmd = new MySqlCommand(query, Common_DB.Connection);
            cmd.Parameters.AddWithValue("?accountID", pData.AccountID);
            cmd.Parameters.AddWithValue("?charSlot", charSlot);
            var reader = cmd.ExecuteReader();

            if (!reader.Read()) {
                reader.Close();
                return;
            }

            pData.CharSlot = charSlot;
            pData.CharacterID = (int)reader["id"];
            pData.GuildID = (int)reader["guild_id"];
            pData.CharacterName = (string)reader["name"];
            pData.WorldID = (int)reader["world_id"];
            pData.RegionID = (int)reader["region_id"];

            reader.Close();
        }

        /// <summary>
        /// Insere um novo personagem ao banco de dados.
        /// </summary>
        /// <param name="hexID"></param>
        /// <param name="gender"></param>
        /// <param name="classeID"></param>
        /// <param name="name"></param>
        /// <param name="sprite"></param>
        /// <param name="charSlot"></param>
        public static void InsertCharacter(string hexID, int gender, int classeID, string name, int sprite, int charSlot) {
            var query = new StringBuilder();
            var pData = Authentication.FindByHexID(hexID);
            var index = Classe.FindClasseIndexByID(classeID);

            query.Append("INSERT INTO players (account_id, classe_id, char_slot, name, level, gender, sprite, ");
            query.Append("strenght, dexterity, agility, constitution, intelligence, wisdom, will, mind, statpoints, creation_date)");
            query.Append("VALUES (?accountID, ?classeID, ?charSlot, ?name, ?level, ?gender, ?sprite, ?strenght, ?dexterity, ?agility, ");
            query.Append("?constitution, ?intelligence, ?wisdom, ?will, ?mind, ?statpoints, ?creation)");

            var list = new List<MySqlParameter>();
            list.Add(new MySqlParameter("?accountID", pData.AccountID));
            list.Add(new MySqlParameter("?classeID", classeID));
            list.Add(new MySqlParameter("?charSlot", charSlot));
            list.Add(new MySqlParameter("?name", name));
            list.Add(new MySqlParameter("?level", Classe.Classes[index].Level));
            list.Add(new MySqlParameter("?gender", gender));
            list.Add(new MySqlParameter("?sprite", sprite));
            list.Add(new MySqlParameter("?strenght", Classe.Classes[index].Strenght));
            list.Add(new MySqlParameter("?dexterity", Classe.Classes[index].Dexterity));
            list.Add(new MySqlParameter("?agility", Classe.Classes[index].Agility));
            list.Add(new MySqlParameter("?constitution", Classe.Classes[index].Constitution));
            list.Add(new MySqlParameter("?intelligence", Classe.Classes[index].Intelligence));
            list.Add(new MySqlParameter("?wisdom", Classe.Classes[index].Wisdom));
            list.Add(new MySqlParameter("?will", Classe.Classes[index].Will));
            list.Add(new MySqlParameter("?mind", Classe.Classes[index].Mind));
            list.Add(new MySqlParameter("?statpoints", Classe.Classes[index].Points));
            list.Add(new MySqlParameter("?creation", DateTime.Now));

            var cmd = new MySqlCommand(query.ToString(), Common_DB.Connection);
            cmd.Parameters.AddRange(list.ToArray());
            cmd.ExecuteNonQuery(); 
        }    

        /// <summary>
        /// Insere os items equipados.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="classeID"></param>
        public static void InsertEquippedItems(string name, int classeID) {
            var query = new StringBuilder();
            var index = Classe.FindClasseIndexByID(classeID);
            var charID = ID(name);
            var slots = string.Empty;

            for (var item = 0; item < Constant.MaxEquippedItem; item++) {

                for (var i = 0; i < Constant.MaxItemSocket; i++) {
                    if (i == Constant.MaxItemSocket - 1) {
                        slots += Classe.Classes[index].EquippedItems[item].Socket[i];
                    }
                    else {
                        slots += Classe.Classes[index].EquippedItems[item].Socket[i] + ",";
                    }
                }

                query.Append("INSERT INTO player_equippeditem (char_id, item_id, equip_slot, quantity, ");
                query.Append("enchant, durability, slots, expire, expire_date, soul_bound, tradeable) VALUES (");
                query.Append($"'{charID}', ");
                query.Append($"'{Classe.Classes[index].EquippedItems[item].ID}', ");
                query.Append($"'{item}', ");
                query.Append($"'{Classe.Classes[index].EquippedItems[item].Quantity}', ");
                query.Append($"'{Classe.Classes[index].EquippedItems[item].Enchant}', ");
                query.Append($"'{Classe.Classes[index].EquippedItems[item].Durability}', ");
                query.Append($"'{slots}', ");
                query.Append($"'{Classe.Classes[index].EquippedItems[item].Expire}', ");
                query.Append($"'{DateTime.Now.AddDays(Classe.Classes[index].EquippedItems[item].ExpireDays)}', ");
                query.Append($"'{Classe.Classes[index].EquippedItems[item].SoulBound}', ");
                query.Append($"'{Classe.Classes[index].EquippedItems[item].Tradeable}') ");

                var cmd = new MySqlCommand(query .ToString(), Common_DB.Connection);
                cmd.ExecuteNonQuery();

                query.Clear();
                slots = string.Empty;
            }
        }

        /// <summary>
        /// Insere os items no inventário.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="classeID"></param>
        public static void InsertInventoryItems(string name, int classeID) {
            var query = new StringBuilder();
            var index = Classe.FindClasseIndexByID(classeID);
            var charID = ID(name);
            var slots = string.Empty;

            for (var item = 0; item < Constant.MaxInventory; item++) {

                for (var i = 0; i < Constant.MaxItemSocket; i++) {
                    if (i == Constant.MaxItemSocket - 1) {
                        slots += Classe.Classes[index].Inventory[item].Socket[i];
                    }
                    else {
                        slots += Classe.Classes[index].Inventory[item].Socket[i] + ",";
                    }
                }

                query.Append("INSERT INTO player_inventory (char_id, item_id, inventory_slot, quantity, ");
                query.Append("enchant, durability, slots, expire, expire_date, soul_bound, tradeable) VALUES (");
                query.Append($"'{charID}', ");
                query.Append($"'{Classe.Classes[index].Inventory[item].ID}', ");
                query.Append($"'{item}', ");
                query.Append($"'{Classe.Classes[index].Inventory[item].Quantity}', ");
                query.Append($"'{Classe.Classes[index].Inventory[item].Enchant}', ");
                query.Append($"'{Classe.Classes[index].Inventory[item].Durability}', ");
                query.Append($"'{slots}', ");
                query.Append($"'{Classe.Classes[index].Inventory[item].Expire}', ");
                query.Append($"'{DateTime.Now.AddDays(Classe.Classes[index].Inventory[item].ExpireDays)}', ");
                query.Append($"'{Classe.Classes[index].Inventory[item].SoulBound}', ");
                query.Append($"'{Classe.Classes[index].Inventory[item].Tradeable}') ");

                var cmd = new MySqlCommand(query.ToString(), Common_DB.Connection);
                cmd.ExecuteNonQuery();

                query.Clear();
                slots = string.Empty;
            }
        }

        /// <summary>
        /// Obtém o ID de guild de personagem.
        /// </summary>
        /// <param name="playerID"></param>
        /// <returns></returns>
        public static int GetGuildID(int playerID) {
            var query = "SELECT guild_id FROM players WHERE id=?playerID";
            var cmd = new MySqlCommand(query, Common_DB.Connection);
            cmd.Parameters.AddWithValue("?playerID", playerID);
            var reader = cmd.ExecuteReader();

            if (!reader.Read()) {
                reader.Close();
                return 0;
            }

            var id = (int)reader["guild_id"];

            reader.Close();

            return id;
        }

        /// <summary>
        /// Atualiza o ID de guild de personagem.
        /// </summary>
        /// <param name="playerID"></param>
        /// <param name="guildID"></param>
        public static void UpdatePlayerGuildID(int playerID, int guildID) {
            var query = "UPDATE players SET guild_id=?guildID WHERE id=?playerID";
            var cmd = new MySqlCommand(query, Common_DB.Connection);
            cmd.Parameters.AddWithValue("?playerID", playerID);
            cmd.Parameters.AddWithValue("?guildID", guildID);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Define a data para exclusão do personagem.
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="charID"></param>
        /// <param name="date"></param>
        public static void UpdateDeletionDate(int accountID, int charID, DateTime date) {
            var query = "UPDATE players SET deletion_date=?deletion WHERE id=?charID AND account_id=?accountID";
            var cmd = new MySqlCommand(query, Common_DB.Connection);
            cmd.Parameters.AddWithValue("?accountID", accountID);
            cmd.Parameters.AddWithValue("?charID", charID);
            cmd.Parameters.AddWithValue("?deletion", date);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Define se o personagem está pendente para exclusão.
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="charID"></param>
        /// <param name="value"></param>
        public static void UpdatePendingDeletion(int accountID, int charID, byte value) {
            var query = "UPDATE players SET pending_deletion=?pending WHERE id=?charID AND account_id=?accountID";
            var cmd = new MySqlCommand(query, Common_DB.Connection);
            cmd.Parameters.AddWithValue("?accountID", accountID);
            cmd.Parameters.AddWithValue("?charID", charID);
            cmd.Parameters.AddWithValue("?pending", value);
            cmd.ExecuteNonQuery();
        }
    }
}
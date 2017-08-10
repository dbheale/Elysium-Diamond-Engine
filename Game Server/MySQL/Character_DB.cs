using System;
using System.Text;
using GameServer.Server;
using GameServer.Player;
using GameServer.Common;
using GameServer.GameItem;
using MySql.Data.MySqlClient;

namespace GameServer.MySQL {
    public class Character_DB {
        /// <summary>
        /// Obtem o nome do personagem.
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="slot"></param>
        /// <returns></returns>
        public static string CharacterName(int accountID, int slot) {
            var query = $"SELECT name FROM players WHERE account_id='{accountID}' and char_slot='{slot}'";
            var cmd = new MySqlCommand(query, Common_DB.Connection);
            var reader = cmd.ExecuteReader();

            if (reader.Read() == false) {
                reader.Close();
                return string.Empty;
            }

            var result = (string)reader["name"];
            reader.Close();

            return result;
        }

        /// <summary>
        /// Carrega todos os dados do personagem.
        /// </summary>
        /// <param name="hexID"></param>
        /// <param name="slot"></param>
        public static void LoadData(string hexID, int slot) {
            if (Common_DB.Connection == null) { return; }

            var pData = Authentication.FindByHexID(hexID);

            var query = "SELECT * FROM players WHERE account_id='" + pData.AccountID + "' and char_slot='" + slot + "'";
            var cmd = new MySqlCommand(query, Common_DB.Connection);
            var reader = cmd.ExecuteReader();

            if (reader.Read() == false) {
                reader.Close();
                return;
            }

            pData.CharacterSlot = slot;
            pData.ClasseID = Convert.ToInt16(reader["classe_id"]); 
            pData.CharacterID = (int)reader["id"];    
            pData.GuildID = (int)reader["guild_id"];
            pData.CharacterName = (string)reader["name"];
            //pData.Gender = Convert.ToByte(reader["gender"]);
            pData.Sprite = Convert.ToInt16(reader["sprite"]);
            pData.HP = (int)reader["hp"];
            pData.MP = (int)reader["mp"];
            pData.SP = (int)reader["sp"];
            pData.Level = (int)reader["level"];
            pData.Experience = (long)reader["exp"];
            pData.TalentLevel = (int)reader["talent_level"];
            pData.TalentExperience = (long)reader["talent_exp"];
            pData.TalentPoints = (int)reader["talent_points"];
            pData.Strenght = (int)reader["strenght"];
            pData.Dexterity = (int)reader["dexterity"];
            pData.Agility = (int)reader["agility"];
            pData.Constitution = (int)reader["constitution"];
            pData.Intelligence = (int)reader["intelligence"];
            pData.Wisdom = (int)reader["wisdom"];
            pData.Will = (int)reader["will"];
            pData.Mind = (int)reader["mind"];
            pData.StatPoints = (int)reader["statpoints"];
            pData.WorldID = Convert.ToInt16(reader["world_id"]);
            pData.RegionID = Convert.ToInt16(reader["region_id"]);
            pData.Direction = Convert.ToByte(reader["direction"]);
            pData.X = Convert.ToInt16(reader["posx"]);
            pData.Y = Convert.ToInt16(reader["posy"]);
            pData.Currency = (long)reader["currency"];
       
            reader.Close();
        }

        /// <summary>
        /// Carrega os items equipados.
        /// </summary>
        /// <param name="pData"></param>
        public static void LoadEquippedItem(PlayerData pData) {
            var query = "SELECT * FROM player_equippeditem WHERE char_id=?id";
            var cmd = new MySqlCommand(query, Common_DB.Connection);
            cmd.Parameters.AddWithValue("?id", pData.CharacterID);
            var reader = cmd.ExecuteReader();

            while (reader.Read()) {
                var item = new Item();
                item.ID = (int)reader["item_id"];
                item.Quantity = Convert.ToInt16(reader["quantity"]);
                item.Enchant = Convert.ToInt16(reader["enchant"]);
                item.Durability = Convert.ToInt16(reader["durability"]);
                item.Expire = Convert.ToByte(reader["expire"]);
                item.ExpireDate = Convert.ToDateTime(reader["expire_date"]);
                item.SoulBound = Convert.ToByte(reader["soul_bound"]);
                item.Tradeable = Convert.ToByte(reader["tradeable"]);

                var slot = Convert.ToByte(reader["equip_slot"]);
                var slots = ((string)reader["slots"]).Split(',');
                for(var n = 0; n < Constant.MAX_ITEM_SLOT; n++) item.Socket[n] = Convert.ToInt16(slots[n]);

                pData.EquippedItem[slot] = item;
            }

            reader.Close();
        }

        /// <summary>
        /// Carrega os items.
        /// </summary>
        /// <param name="pData"></param>
        public static void LoadInventory(PlayerData pData) {
            var query = "SELECT * FROM player_inventory WHERE char_id=?id";
            var cmd = new MySqlCommand(query, Common_DB.Connection);
            cmd.Parameters.AddWithValue("?id", pData.CharacterID);
            var reader = cmd.ExecuteReader();

            while (reader.Read()) {
                var item = new Item();              
                item.ID = (int)reader["item_id"];            
                item.Quantity = Convert.ToInt16(reader["quantity"]);
                item.Enchant = Convert.ToInt16(reader["enchant"]);
                item.Durability = Convert.ToInt16(reader["durability"]);
                item.Expire = Convert.ToByte(reader["expire"]);
                item.ExpireDate = Convert.ToDateTime(reader["expire_date"]);
                item.SoulBound = Convert.ToByte(reader["soul_bound"]);
                item.Tradeable = Convert.ToByte(reader["tradeable"]);

                var slot = Convert.ToByte(reader["inventory_slot"]);
                var slots = ((string)reader["slots"]).Split(',');
                for (var n = 0; n < Constant.MAX_ITEM_SLOT; n++) item.Socket[n] = Convert.ToInt16(slots[n]);

                pData.Inventory[slot] = item;
            }

            reader.Close();
        }

        /// <summary>
        /// Salva todos os dados do personagem.
        /// </summary>
        /// <param name="hexID"></param>
        /// <param name="charID"></param>
        public static void SaveData(PlayerData pData) {
            if (Common_DB.Connection == null) { return; }

            StringBuilder query = new StringBuilder();
            query.Append("UPDATE players SET ");
            query.Append($"hp='{pData.HP}', ");
            query.Append($"mp='{pData.MP}', ");
            query.Append($"sp='{pData.SP}', ");
            query.Append($"sprite='{pData.Sprite}', ");
            query.Append($"level='{pData.Level}', ");
            query.Append($"exp='{pData.Experience}', ");
            query.Append($"talent_level='{pData.TalentLevel}', ");
            query.Append($"talent_exp='{pData.TalentExperience}', ");
            query.Append($"talent_points='{pData.TalentPoints}', ");
            query.Append($"strenght='{pData.Strenght}', ");
            query.Append($"dexterity='{pData.Dexterity}', ");
            query.Append($"agility='{pData.Agility}', ");
            query.Append($"constitution='{pData.Constitution}', ");
            query.Append($"intelligence='{pData.Intelligence}', ");
            query.Append($"wisdom='{pData.Wisdom}', ");
            query.Append($"will='{pData.Will}', ");
            query.Append($"mind='{pData.Mind}', ");
            query.Append($"statpoints='{pData.StatPoints}', ");
            query.Append($"world_id='{pData.WorldID}', ");
            query.Append($"region_id='{pData.RegionID}', ");
            query.Append($"direction='{pData.Direction}', ");
            query.Append($"posx='{pData.X}', ");
            query.Append($"posy='{pData.Y}', ");
            query.Append($"currency='{pData.Currency}' ");
            query.Append($"WHERE id='{pData.CharacterID}' AND account_id='{pData.AccountID}'");

            var cmd = new MySqlCommand(query.ToString(), Common_DB.Connection);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Salva os items equipados.
        /// </summary>
        /// <param name="pData"></param>
        public static void SaveEquippedItems(PlayerData pData) {
            var query = "UPDATE player_equippeditem SET item_id=?itemID, quantity=?quantity, enchant=?enchant, durability=?durability, ";
            query += "slots=?slots, expire=?expire, expire_date=?date, soul_bound=?soulbound, tradeable=?tradeable ";
            query += "WHERE equip_slot=?slot AND char_id=?charID";
 
            var cmd = new MySqlCommand(query, Common_DB.Connection);
            string slots;

            for (var slot = 0; slot < Constant.MAX_EQUIPPED_ITEM; slot++) {
                cmd.Parameters.Clear();
                slots = string.Empty;

                #region Socket Data
                for (var i = 0; i < Constant.MAX_ITEM_SLOT; i++) {
                    if (i == Constant.MAX_ITEM_SLOT - 1) {
                        slots += pData.EquippedItem[slot].Socket[i];
                    }
                    else {
                        slots += pData.EquippedItem[slot].Socket[i] + ",";
                    }
                }
                #endregion

                cmd.Parameters.AddWithValue("?itemID", pData.EquippedItem[slot].ID);
                cmd.Parameters.AddWithValue("?quantity", pData.EquippedItem[slot].Quantity);
                cmd.Parameters.AddWithValue("?enchant", pData.EquippedItem[slot].Enchant);
                cmd.Parameters.AddWithValue("?durability", pData.EquippedItem[slot].Durability);
                cmd.Parameters.AddWithValue("?slots", slots);
                cmd.Parameters.AddWithValue("?expire", pData.EquippedItem[slot].Expire);
                cmd.Parameters.AddWithValue("?date", pData.EquippedItem[slot].ExpireDate);
                cmd.Parameters.AddWithValue("?soulbound", pData.EquippedItem[slot].SoulBound);
                cmd.Parameters.AddWithValue("?tradeable", pData.EquippedItem[slot].Tradeable);
                cmd.Parameters.AddWithValue("?slot", slot);
                cmd.Parameters.AddWithValue("?charID", pData.CharacterID);

                cmd.ExecuteNonQuery();     
            }
        }

        /// <summary>
        /// Salva os items do inventário.
        /// </summary>
        /// <param name="pData"></param>
        public static void SaveInventory(PlayerData pData) {
            var query = "UPDATE player_inventory SET item_id=?itemID, quantity=?quantity, enchant=?enchant, durability=?durability, ";
            query += "slots=?slots, expire=?expire, expire_date=?date, soul_bound=?soulbound, tradeable=?tradeable ";
            query += "WHERE inventory_slot=?slot AND char_id=?charID";

            var cmd = new MySqlCommand(query, Common_DB.Connection);
            string slots;

            for (var slot = 0; slot < Constant.MAX_INVENTORY; slot++) {
                cmd.Parameters.Clear();
                slots = string.Empty;

                #region Socket Data
                for (var i = 0; i < Constant.MAX_ITEM_SLOT; i++) {
                    if (i == Constant.MAX_ITEM_SLOT - 1) {
                        slots += pData.Inventory[slot].Socket[i];
                    }
                    else {
                        slots += pData.Inventory[slot].Socket[i] + ",";
                    }
                }
                #endregion

                cmd.Parameters.AddWithValue("?itemID", pData.Inventory[slot].ID);
                cmd.Parameters.AddWithValue("?quantity", pData.Inventory[slot].Quantity);
                cmd.Parameters.AddWithValue("?enchant", pData.Inventory[slot].Enchant);
                cmd.Parameters.AddWithValue("?durability", pData.Inventory[slot].Durability);
                cmd.Parameters.AddWithValue("?slots", slots);
                cmd.Parameters.AddWithValue("?expire", pData.Inventory[slot].Expire);
                cmd.Parameters.AddWithValue("?date", pData.Inventory[slot].ExpireDate);
                cmd.Parameters.AddWithValue("?soulbound", pData.Inventory[slot].SoulBound);
                cmd.Parameters.AddWithValue("?tradeable", pData.Inventory[slot].Tradeable);
                cmd.Parameters.AddWithValue("?slot", slot);
                cmd.Parameters.AddWithValue("?charID", pData.CharacterID);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
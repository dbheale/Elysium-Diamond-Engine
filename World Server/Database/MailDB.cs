using System;
using System.Text;
using WorldServer.GameItem;
using WorldServer.Common;
using MySql.Data.MySqlClient;

namespace WorldServer.Database {
    public static class MailDB {
        /// <summary>
        /// Insere um novo mail na DB.
        /// </summary>
        /// <param name="mail"></param>
        public static void Insert(int senderID, string sender, int recipientID, string title, string message, long currency, byte express, IItem item) {
            var query = new StringBuilder();
            query.Append("INSERT INTO mail (sender_id, sender_name, recipient_id, mail_title, mail_message, attached_currency, express, received_date, ");
            query.Append("item_id, quantity, enchant, durability, slots, expire, expire_days, soul_bound, tradeable) ");
            query.Append("VALUES (?sender_id, ?sender_name, ?recipient_id, ?mail_title, ?mail_message, ?attached_currency, ?express, ?received_date, ");
            query.Append("?item_id, ?quantity, ?enchant, ?durability, ?slots, ?expire, ?expire_days, ?soul_bound, ?tradeable)");

            if (item == null) item = new Item();

            var slots = string.Empty;
            for (var i = 0; i < Constants.MaxItemSocket; i++) {
                if (i == Constants.MaxItemSocket - 1) {
                    slots += ((Item)item).Socket[i];
                }
                else {
                    slots += ((Item)item).Socket[i] + ",";
                }
            }

            var connection = new MySQL().CreateConnection();
            var cmd = new MySqlCommand(query.ToString(), connection);
            cmd.Parameters.AddWithValue("?sender_id", senderID);
            cmd.Parameters.AddWithValue("?sender_name", sender);
            cmd.Parameters.AddWithValue("?recipient_id", recipientID);
            cmd.Parameters.AddWithValue("?mail_title", title);
            cmd.Parameters.AddWithValue("?mail_message", message);
            cmd.Parameters.AddWithValue("?attached_currency", currency);
            cmd.Parameters.AddWithValue("?express", express);
            cmd.Parameters.AddWithValue("?received_date", DateTime.Now);
            cmd.Parameters.AddWithValue("?item_id", ((Item)item).ID);
            cmd.Parameters.AddWithValue("?quantity", ((Item)item).Quantity);
            cmd.Parameters.AddWithValue("?enchant", ((Item)item).Enchant);
            cmd.Parameters.AddWithValue("?durability", ((Item)item).Durability);
            cmd.Parameters.AddWithValue("?slots", slots);
            cmd.Parameters.AddWithValue("?expire", ((Item)item).Expire);
            cmd.Parameters.AddWithValue("?expire_days", ((Item)item).ExpireDays);
            cmd.Parameters.AddWithValue("?soul_bound", ((Item)item).SoulBound);
            cmd.Parameters.AddWithValue("?tradeable", ((Item)item).Tradeable);
            cmd.ExecuteNonQuery();
            connection.Close();
        }            
    }
}

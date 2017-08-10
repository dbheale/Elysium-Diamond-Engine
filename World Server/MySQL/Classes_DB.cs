using MySql.Data.MySqlClient;
using WorldServer.Server;

namespace WorldServer.MySQL {
    public static class Classes_DB {
        /// <summary>
        /// Carrega todas as classes.
        /// </summary>
        public static void GetClasseStatsBase() {
            var query = "SELECT * FROM classes";
            var cmd = new MySqlCommand(query, Common_DB.Connection);
            var reader = cmd.ExecuteReader();     

            while (reader.Read()) { 
                Classe.Classes.Add(new Classe());

                var index = Classe.Classes.Count - 1;
                var _base = Classe.Classes[index];

                _base.ID = (int)reader["id"];
                _base.IncrementID = (int)reader["increment_id"];
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
                index++;
            }

            reader.Close();
        } 
    }
}

using System.Data;
using System.Threading;
using MySql.Data.MySqlClient;

namespace GameServer.MySQL {
    public class Common_DB {
        public static MySqlConnection Connection = null;
        public static string Server { get; set; }
        public static int Port { get; set; }
        public static string Username { get; set; }
        public static string Password { get; set; }
        public static string Database { get; set; }

        /// <summary>
        /// Realiza a conexão com o banco de dados.
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public static bool Open(out string message) {
            var query = $"Server={Server};Port={Port};Database={Database};User ID={Username};Password={Password};";

            try {
                Connection = new MySqlConnection();
                Connection.ConnectionString = query;
                Connection.Open();
            }
            catch (MySqlException ex) {
                message = ex.Message;
                return false;
            }

            message = string.Empty;
            return true;
        }

        /// <summary>
        /// Fecha a conexão com o banco de dados.
        /// </summary>
        /// <returns></returns>
        public static bool Close() {
            if (Connection == null) { return false; }

            if (Connection.State != ConnectionState.Closed) {
                Connection.Close();
                Connection.Dispose();
            }

            Thread.Sleep(750);

            if (Connection.State == ConnectionState.Closed) {
                return true;
            }
            else {
                return false;
            }
        }
    }
}

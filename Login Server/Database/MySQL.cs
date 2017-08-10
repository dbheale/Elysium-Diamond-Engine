using System;
using MySql.Data.MySqlClient;
using LoginServer.Common;

namespace LoginServer.Database {
    public sealed class MySQL {
        private MySqlConnection _connection;
        public static string Server { get; set; }
        public static int Port { get; set; }
        public static string Username { get; set; }
        public static string Password { get; set; }
        public static string Database { get; set; }

        public MySqlConnection CreateConnection() {
            var query = $"Server={Server};Port={Port};Database={Database};User ID={Username};Password={Password};";
            _connection = new MySqlConnection(query);
            _connection.Open();

            return _connection;
        }
    }
}
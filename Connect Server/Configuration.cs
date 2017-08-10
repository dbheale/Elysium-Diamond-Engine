namespace ConnectServer {
    public static class Configuration {
        public static int Port { get; set; }
        public static string Discovery { get; set; } = string.Empty;
        public static int Sleep { get; set; }
        public static int MaxConnections { get; set; }
    }
}
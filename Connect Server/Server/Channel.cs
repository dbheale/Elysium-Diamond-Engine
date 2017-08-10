namespace ConnectServer.Server {
    public class Channel {
        public int ServerID { get; set; }

        public int RegionID { get; set; }

        public string IP { get; set; }

        public int Port { get; set; }

        public int Population { get; set; }

        public int MaxPopulation { get; set; }

        public bool Online { get; set; }

        public Channel() {
            IP = string.Empty;
        }
    }
}
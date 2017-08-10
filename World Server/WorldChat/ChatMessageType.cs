namespace WorldServer.WorldChat {
    public enum ChatMessageType : byte {
        None,
        Private,
        Party,
        Guild,
        Global,
        Server
    }
}
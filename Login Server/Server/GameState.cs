namespace LoginServer.Server {
    public enum GameState : byte {
        None,
        Login,
        Server,
        Character,
        NewCharacter,
        Game,
    }
}
namespace LoginServer.Network {
    public enum PacketList : int {
        //0~199 basic message
        None = 0,
        Error = 1,
        Disconnect = 2,
        Ping = 3,
        AcceptedConnection = 4,
        ChangeGameState = 5,
        InvalidVersion = 6,
        CantConnectNow = 7,

        //200~299; cliente to login server;
        CL_LS_Login = 200,
        CL_LS_BackToLogin =201,
        CL_LS_WorldServerConnect = 202,

        //300~399; login server to cliente;
        LS_CL_ServerList = 300,
        LS_CL_ChannelList = 301, //使用はない
        LS_CL_Maintenance = 302,
        LS_CL_AccountBanned = 303,
        LS_CL_AccountDisabled = 304,
        LS_CL_InvalidNamePass = 305,
        LS_CL_AlreadyLoggedIn = 306,
        LS_CL_SendPlayerHexID = 307,
        LS_CL_SendPin = 308, //使用はない

        //login server to world server
        LS_WS_DisconnectPlayer = 309,
        LS_WS_SendPlayerHexID = 310,
        LS_WS_IsPlayerConnected = 311, //返事する為に、同じパケットを使用する
        LS_WS_CheckConnection = 312, //サーバーだけで使用する
    }
}

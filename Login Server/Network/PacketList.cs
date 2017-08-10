namespace LoginServer.Network {
    public enum PacketList : short {
        //HEADER 0 - 199 BASIC MESSAGE
        None = 0,
        Error = 1,
        Disconnect = 2,
        Ping = 3,
        AcceptedConnection = 4,
        ChangeGameState = 5,
        InvalidVersion = 6,
        CantConnectNow = 7,
        AccountBanned = 8,
        InvalidCharacterName = 9,
        
        //HEADER 200 - 299 CLIENT -> LOGIN SERVER
        CL_LS_Login = 200,
        CL_LS_BackToLogin =201,
        CL_LS_WorldServerConnect = 202,

        //HEADER 300 - 349 LOGIN SERVER -> CLIENT
        LS_CL_ServerList = 300,
        LS_CL_Maintenance = 301,
        LS_CL_AccountDisabled = 302,
        LS_CL_InvalidNamePass = 303,
        LS_CL_AlreadyLoggedIn = 304,
        LS_CL_SendPlayerHexID = 305,

        //HEADER 350 - 399 LOGIN SERVER -> CONNECT SERVER
        CS_ServerID = 350,
        LS_WS_PlayerLogin = 351,
        LS_WS_IsPlayerConnected = 352, //返事する為に、同じパケットを使用する - O header é usado como resposta 
        CS_DisconnectPlayer = 353,

        //HEADER 400 - 449 WORLD SERVER -> LOGIN SERVER
        WS_LS_UpdatePin = 400,
        WS_LS_UpdatePinAttempt = 401,
        WS_LS_UpdateBan = 402,
        WS_LS_UpdateCash = 403,
        WS_LS_UpdateDisconnect = 404,
        WS_LS_UpdateUserStatus = 405,
        WS_LS_InsertService = 406
    }
}
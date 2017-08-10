namespace ConnectServer.Network {
    public enum PacketList {
        //サーバーだけで使用する
        CS_ServerID = 350,
        LS_WS_PlayerLogin = 351,
        LS_WS_IsPlayerConnected = 352, //返事する為に、同じパケットを使用する - O header é usado como resposta
        CS_DisconnectPlayer = 353,
        CS_SelectServer = 354,

        //HEADER 400 - 449 WORLD SERVER -> LOGIN SERVER
        WS_LS_UpdatePin = 400,
        WS_LS_UpdatePinAttempt = 401,
        WS_LS_UpdateBan = 402,
        WS_LS_UpdateCash = 403,
        WS_LS_UpdateDisconnect = 404,
        WS_LS_UpdateUserStatus = 405,
        WS_LS_InsertService = 406,

        //HEADER 600 - 699 WORLD SERVER -> GAME SERVER
        WS_GS_CheckConnection = 600,
        WS_GS_UserLogin = 601,

        //HEADER 700 - 799 GAME SERVER -> WORLD SERVER
        GS_WS_UpdateUserStatus = 700,
        GS_WS_UpdateUserCount = 701
    }
}
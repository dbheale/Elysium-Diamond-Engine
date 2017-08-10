namespace WorldServer.Network {
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

        //HEADER 350 - 399 LOGIN SERVER -> WORLD SERVER
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

        //HEADER 450 - 499 CLIENT -> WORLD SERVER
        CL_WS_SendPlayerHexID = 450,
        CL_WS_DeleteCharacter = 451,
        CL_WS_CreateCharacter = 452,
        CL_WS_EnterInGame = 453,
        CL_WS_RequestPreLoad = 454,
        CL_WS_ChatMessage = 455, //返事する為に、同じパケットを使用する - O header é usado como resposta
        CL_WS_SendPin = 456,
        CL_WS_RequestPageItems = 457,
        CL_WS_RequestItemInformation = 458,
        CL_WS_RequestBuyItem = 459,
        CL_WS_RequestMailTitle = 460,
        CL_WS_RequestMail = 461,

        //HEADER 500 - 599 WORLD SERVER -> CLIENT
        WS_CL_CharacterCreationDisabled = 500,
        WS_CL_CharacterDeleteDisabled = 501,
        WS_CL_CharacterCreated = 502,
        WS_CL_CharacterDeleted = 503,
        WS_CL_NeedPlayerHexID = 504,
        WS_CL_CharacterPreLoad = 505,
        WS_CL_GuildNameInUse = 506,
        WS_CL_UserAlreadyInGuild = 507,
        WS_CL_GuildInfo = 508,
        WS_CL_GuildMemberInfo = 509,
        WS_CL_GuildHistoryInfo = 510,
        WS_CL_CharNameInUse = 511,
        WS_CL_InvalidLevelToDelete = 512,
        WS_CL_GameServerData = 513,
        WS_CL_PlayerChat = 514,
        WS_CL_GlobalChat = 515,
        WS_CL_PlayerMessage = 516,
        WS_CL_AlertDeleteCharacter = 517,
        WS_CL_RemovePendingDelete = 518,
        WS_CL_Cash = 519,
        WS_CL_InvalidPin = 520,
        WS_CL_IncorrectPin = 521,
        WS_CL_PinStatusOK = 522,
        WS_CL_PinRegister = 523, //não há PIN na conta, força um registro
        WS_CL_ShowPinWindow = 524,
        WS_CL_ShowMessageBox = 525,
        WS_CL_SendPageItems = 526,
        WS_CL_SendItemInformation = 527,
        WS_CL_PurchaseStatus = 528,
        WS_CL_SendMailTitle = 529,
        WS_CL_SendMail = 530,

        //HEADER 600 - 699 WORLD SERVER -> GAME SERVER
        WS_GS_CheckConnection = 600,
        WS_GS_UserLogin = 601,

        //HEADER 700 - 799 GAME SERVER -> WORLD SERVER
        GS_WS_UpdateUserStatus = 700,
        GS_WS_UpdateUserCount = 701
    }
}
public enum PacketList {
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
    CL_LS_BackToLogin = 201,
    CL_LS_WorldServerConnect = 202,

    //HEADER 300 - 349 LOGIN SERVER -> CLIENT
    LS_CL_ServerList = 300,
    LS_CL_Maintenance = 301,
    LS_CL_AccountDisabled = 302,
    LS_CL_InvalidNamePass = 303,
    LS_CL_AlreadyLoggedIn = 304,
    LS_CL_SendPlayerHexID = 305,

    //HEADER 350 - 400 LOGIN SERVER -> WORLD SERVER
    LS_WS_DisconnectPlayer = 350,
    LS_WS_SendPlayerHexID = 351,
    LS_WS_IsPlayerConnected = 352, //返事する為に、同じパケットを使用する - O header é usado como resposta
    LS_WS_CheckConnection = 353, //サーバーだけで使用する 

    //HEADER 400 - 449 WORLD SERVER -> LOGIN SERVER
    WS_LS_UpdatePin = 400,
    WS_LS_UpdatePinAttempt = 401,
    WS_LS_UpdateBan = 402,
    WS_LS_UpdateCash = 403,
    WS_LS_UpdateDisconnect = 404,
    WS_LS_UpdateUserStatus = 405,
    WS_LS_InsertService = 406,

    //HEADER 450 ~ 499 CLIENT -> WORLD SERVER
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

    //1000 client to game server
    Client_GameServer_SendPlayerHexID = 0x03E8,
    Client_GameServer_PlayerMove = 0x03E9,
    CL_GS_IncrementStat = 1002,
    CL_GS_UseInventoryItem = 1003,
    CL_GS_SwapInventoryItem = 1004,
    CL_GS_UnequipItem = 1005,
    CL_GS_UnequipItemOnSlot = 1006,
    CL_GS_AdminTool = 1007,

    //2000 game server to client
    GameServer_Client_NeedHexID = 0x07D0,
    GameServer_Client_PlayerData = 0x07D1,
    GameServer_Client_GetMapPlayer = 0x07D2,
    GameServer_Client_PlayerMapMove = 0x07D3,
    GameServer_Client_PlayerLocation = 0x07D4,
    GameServer_Client_PlayerStats = 0x07D5,
    GameServer_Client_PlayerVital = 0x07D6,
    GameServer_Client_PlayerVitalRegen = 0x07D7,
    GameServer_Client_PlayerExp = 0x07D8,
    GameServer_Client_PlayerPhysicalStats = 0x07D9,
    GameServer_Client_PlayerMagicalStats = 0x07DA,
    GameServer_Client_PlayerUniqueStats = 0x07DB,
    GameServer_Client_PlayerElementalStats = 0x07DC,
    GameServer_Client_PlayerResistStats = 0x07DE,
    GameServer_Client_RemovePlayerFromMap = 0x07DF, //7E0 =16
    GameServer_SendNpc = 2050,
    GameServer_NpcMove = 2051,
    GS_CL_Currency = 2052,
    GS_CL_SendEquippedItem = 2053,
    GS_CL_SendInventoryItem = 2054,
    GS_CL_SwapEquippedItem = 2055,
    GS_CL_SwapInventoryItem = 2056,
    GS_CL_UnequipItem = 2057,
    GS_CL_PlayerTalentData = 2058,

    GS_CL_PlayerName = 3000,
    GS_CL_PlayerPoints = 3001,
    GS_CL_PlayerSprite = 3002,
    GS_CL_PlayerLevel = 3003,
    GS_CL_PlayerLocation = 3004
}
public enum PacketList {
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
    CL_LS_BackToLogin = 201,
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

    //400 ~ 499 client to world server
    Client_WorldServer_SendPlayerHexID = 0x0190,
    Client_WorldServer_DeleteCharacter = 0x0191,
    Client_WorldServer_CreateCharacter = 0x0192,
    Client_WorldServer_EnterInGame = 0x0193,
    Client_WorldServer_RequestPreLoad = 0x0194,
    Client_WorldServer_GlobalChat = 0x0195,

    //500 ~599 world server to client
    WorldServer_Client_CharacterCreationDisabled = 0x01F4,
    WorldServer_Client_CharacterDeleteDisabled = 0x01F5,
    WorldServer_Client_CharacterCreated = 0x01F6,
    WorldServer_Client_CharacterDeleted = 0x01F7,
    WorldServer_Client_NeedPlayerHexID = 0x01F8,
    WorldServer_Client_CharacterPreLoad = 0x01F9,
    WorldServer_Client_GuildNameInUse = 0x01FA,
    WorldServer_Client_UserAlreadyInGuild = 0x01FB,
    WorldServer_Client_GuildInfo = 0x01FC,
    WorldServer_Client_GuildMemberInfo = 0x01FD,
    WorldServer_Client_GuildHistoryInfo = 0x01FE,
    WorldServer_Client_CharNameInUse = 0x01FF,
    WorldServer_Client_InvalidLevelToDelete = 0x0200,
    WorldServer_Client_GameServerData = 0x0201,
    WorldServer_GameServer_GameServerLogin = 0x0202,
    WS_CL_PlayerChat = 0x0203,
    WS_CL_PlayerMessage = 0x0204,

    //1000 client to game server
    Client_GameServer_SendPlayerHexID = 0x03E8,
    Client_GameServer_PlayerMove = 0x03E9,

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
    GameServer_NpcMove = 2051
}
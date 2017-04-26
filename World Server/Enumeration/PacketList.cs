public enum PacketList {
    //0~199 basic message
    None = 0x0000,
    Error = 0x0001,
    Disconnect = 0x0002,
    Ping = 0x0003,
    AcceptedConnection = 0x0004,
    ChangeGameState = 0x0005,   
    InvalidVersion = 0x0006,
    CantConnectNow = 0x0007,

    //200~299; cliente to login server;
    CL_LS_Login = 0x00C8,
    CL_LS_BackToLogin = 0x00C9,
    CL_LS_WorldServerConnect = 0x00CA,

    //300~399; login server to world server;
    LS_WS_DisconnectPlayer = 0x0135,
    LS_WS_SendPlayerHexID = 0x0136,
    LS_WS_IsPlayerConnected = 0x0137, //返事する為に、同じパケットを使用する
    LS_WS_CheckConnection = 0x0138,

    //400 ~ 499 client to world server
    CL_WS_SendPlayerHexID = 0x0190,
    CL_WS_DeleteCharacter = 0x0191,
    CL_WS_CreateCharacter = 0x0192,
    CL_WS_EnterInGame = 0x0193,
    CL_WS_RequestPreLoad = 0x0194,
    CL_WS_GlobalChat = 0x0195, //返事する為に、同じパケットを使用する

    //500 ~599 world server to client
    WS_CL_CharacterCreationDisabled = 0x01F4,
    WS_CL_CharacterDeleteDisabled = 0x01F5,
    WS_CL_CharacterCreated = 0x01F6,
    WS_CL_CharacterDeleted = 0x01F7,
    WS_CL_NeedPlayerHexID = 0x01F8,
    WS_CL_CharacterPreLoad = 0x01F9,
    WS_CL_GuildNameInUse = 0x01FA,
    WS_CL_UserAlreadyInGuild = 0x01FB,
    WS_CL_GuildInfo = 0x01FC,
    WS_CL_GuildMemberInfo = 0x01FD,
    WS_CL_GuildHistoryInfo = 0x01FE,
    WS_CL_CharNameInUse = 0x01FF,
    WS_CL_InvalidLevelToDelete = 0x0200,
    WS_CL_GameServerData = 0x0201,

    WS_GS_GameServerLogin = 0x0202,
    WS_CL_PlayerChat = 0x0203,
    WS_CL_PlayerMessage = 0x0204     
}
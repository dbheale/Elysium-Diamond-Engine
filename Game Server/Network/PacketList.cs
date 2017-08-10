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

    //サーバーだけで使用する
    CS_ServerID = 350,

    //HEADER 600 - 699 WORLD SERVER -> GAME SERVER
    WS_GS_CheckConnection = 600,
    WS_GS_UserLogin = 601,

    //HEADER 700 - 799 GAME SERVER -> WORLD SERVER
    GS_WS_UpdateUserStatus = 700,
    GS_WS_UpdateUserCount = 701,

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
    GameServer_Client_RemovePlayerFromMap = 0x07DF,
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
    GS_CL_PlayerStatPoints = 3001,
    GS_CL_PlayerSprite = 3002,
    GS_CL_PlayerLevel = 3003,
    GS_CL_PlayerLocation = 3004,

    GS_CL_PlayerTalent = 3200,

}
using System;
using Elysium_Diamond.EngineWindow;
using Lidgren.Network;

namespace Elysium_Diamond.Network {
    public static class NetworkPacket {
        public static void ProcessPacket(NetIncomingMessage msg) {
            var index = msg.ReadInt16();

            if (index < 0) { return; }

            switch (index) {
                case (short)PacketList.None: break;
                case (short)PacketList.Error: Message.Show(PacketList.Error); break;
                case (short)PacketList.Disconnect: Message.Show(PacketList.Disconnect); break;
                case (short)PacketList.Ping: GameData.Ping(); break;
                case (short)PacketList.AcceptedConnection: Message.Show(PacketList.AcceptedConnection); break;
                case (short)PacketList.ChangeGameState: CommonData.ChangeGameState(msg.ReadByte()); break;
                case (short)PacketList.InvalidVersion: Message.Show(PacketList.InvalidVersion); break;
                case (short)PacketList.CantConnectNow: Message.Show(PacketList.CantConnectNow); break;
                case (short)PacketList.InvalidCharacterName: Message.Show(PacketList.InvalidCharacterName); break;
                case (short)PacketList.WS_CL_PinStatusOK: Message.Show(PacketList.WS_CL_PinStatusOK); break;
                case (short)PacketList.LS_CL_Maintenance: Message.Show(PacketList.LS_CL_Maintenance); break;
                case (short)PacketList.AccountBanned: Message.Show(PacketList.AccountBanned); break;
                case (short)PacketList.LS_CL_AccountDisabled: Message.Show(PacketList.LS_CL_AccountDisabled); break;
                case (short)PacketList.LS_CL_InvalidNamePass: Message.Show(PacketList.LS_CL_InvalidNamePass); break;
                case (short)PacketList.LS_CL_AlreadyLoggedIn: Message.Show(PacketList.LS_CL_AlreadyLoggedIn); break;
                case (short)PacketList.LS_CL_SendPlayerHexID: LoginData.HexID(msg.ReadString()); break;
                case (short)PacketList.LS_CL_ServerList: LoginData.ServerList(msg); break;
                case (short)PacketList.WS_CL_IncorrectPin: WorldData.IncorrectPin(msg); break;
                case (short)PacketList.WS_CL_PinRegister: WorldData.RegisterPin(); break;
                case (short)PacketList.WS_CL_InvalidPin: WorldData.IncorrectPin(); break;
                case (short)PacketList.WS_CL_ShowPinWindow: WorldData.ShowPinWindow(msg.ReadBoolean()); break;
                case (short)PacketList.WS_CL_ShowMessageBox: Message.Show(PacketList.WS_CL_ShowMessageBox); break;
                case (short)PacketList.WS_CL_SendPageItems: WorldData.ReceivePageItems(msg); break;
                case (short)PacketList.WS_CL_SendItemInformation: WorldData.ReceiveItemDetail(msg); break;
                case (short)PacketList.WS_CL_PurchaseStatus: WorldData.ReceivePurchaseStatus(msg.ReadByte()); break;
                case (short)PacketList.WS_CL_SendMailTitle: WorldData.ReceiveMailTitle(msg); break;
                case (short)PacketList.WS_CL_SendMail: WorldData.ReceiveMail(msg); break;

                case (short)PacketList.WS_CL_CharacterDeleted: Message.Show(PacketList.WS_CL_CharacterDeleted); break;
                case (short)PacketList.WS_CL_CharNameInUse: Message.Show(PacketList.WS_CL_CharNameInUse); break;
                case (short)PacketList.WS_CL_CharacterCreationDisabled: Message.Show(PacketList.WS_CL_CharacterCreationDisabled); break;
                case (short)PacketList.WS_CL_CharacterDeleteDisabled: Message.Show(PacketList.WS_CL_CharacterDeleteDisabled); break;           
                case (short)PacketList.WS_CL_InvalidLevelToDelete: Message.Show(PacketList.WS_CL_InvalidLevelToDelete); break;
                case (short)PacketList.WS_CL_AlertDeleteCharacter: WorldData.SetTimeToDelete(msg); break;
                case (short)PacketList.WS_CL_RemovePendingDelete: WorldData.RemovePendingDelete(msg); break;
                case (short)PacketList.WS_CL_Cash: WorldData.PlayerCash(msg.ReadInt32()); break;

                case (short)PacketList.GameServer_Client_NeedHexID: GamePacket.GameServerHexID(); break;
                case (short)PacketList.GameServer_Client_PlayerData: GameData.PlayerData(msg); break;
                case (short)PacketList.GameServer_SendNpc: GameData.ReceiveNpc(msg); break;
                case (short)PacketList.GameServer_Client_GetMapPlayer: GameData.GetPlayerMap(msg); break;
                case (short)PacketList.GameServer_Client_PlayerMapMove: GameData.PlayerMapMove(msg); break;
                case (short)PacketList.WS_CL_GlobalChat: WorldData.AddTextChat(msg); break;
                case (short)PacketList.WS_CL_PlayerMessage: WorldData.AddTextChat(msg); break;

                case (short)PacketList.WS_CL_NeedPlayerHexID: WorldPacket.WorldServerHexID(); break;
                case (short)PacketList.WS_CL_CharacterPreLoad: WorldData.PreLoad(msg); break;
               // case (short)PacketList.WorldServer_Client_GuildInfo: WorldServerData.WorldGuildInfo(msg); break;
                case (short)PacketList.WS_CL_GameServerData: WorldData.GameServerData(msg); break;

                case (short)PacketList.GameServer_Client_PlayerLocation: GameData.PlayerLocation(msg); break;
                case (short)PacketList.GameServer_Client_PlayerStats: GameData.PlayerStats(msg); break;
                case (short)PacketList.GameServer_Client_PlayerVital: GameData.PlayerVital(msg); break;
                case (short)PacketList.GameServer_Client_PlayerVitalRegen: GameData.PlayerVitalRegen(msg); break;
                case (short)PacketList.GameServer_Client_PlayerPhysicalStats: GameData.PlayerPhysicalStats(msg); break;
                case (short)PacketList.GameServer_Client_PlayerExp: GameData.PlayerExp(msg); break;
                case (short)PacketList.GameServer_Client_PlayerMagicalStats: GameData.PlayerMagicalStats(msg); break;
                case (short)PacketList.GameServer_Client_PlayerUniqueStats: GameData.PlayerUniqueStats(msg); break;
                case (short)PacketList.GameServer_Client_PlayerElementalStats: GameData.PlayerElementalStats(msg); break;
                case (short)PacketList.GameServer_Client_PlayerResistStats: GameData.PlayerResistStats(msg); break;
                case (short)PacketList.GameServer_Client_RemovePlayerFromMap: GameData.RemovePlayerMap(msg.ReadInt32()); break;
                case (short)PacketList.GS_CL_Currency: GameData.PlayerCurrency(msg.ReadInt64()); break;
                case (short)PacketList.GS_CL_SendEquippedItem: InventoryData.ReceiveEquippedItems(msg); break;

                case (short)PacketList.GS_CL_SendInventoryItem: InventoryData.ReceiveInventoryItems(msg); break;
                case (short)PacketList.GS_CL_SwapEquippedItem: InventoryData.SwapEquippedItem(msg); break;
                case (short)PacketList.GS_CL_SwapInventoryItem: InventoryData.SwapInventoryItem(msg); break;
                case (short)PacketList.GS_CL_UnequipItem: InventoryData.UnequipItem(msg); break;

                case (short)PacketList.GS_CL_PlayerTalentData: TalentData.ReceiveTalentData(msg); break;

                case (short)PacketList.GS_CL_PlayerName: GameData.PlayerName(msg); break;
                case (short)PacketList.GS_CL_PlayerPoints: GameData.PlayerStatPoints(msg); break;
                case (short)PacketList.GS_CL_PlayerSprite: GameData.PlayerSprite(msg); break;
                case (short)PacketList.GS_CL_PlayerLevel: GameData.PlayerLevel(msg); break;
                case (short)PacketList.GS_CL_PlayerLocation: GameData.Location(msg); break;

                case (short)PacketList.GameServer_NpcMove: GameData.NpcMove(msg); break;
            }
        }
    }
}

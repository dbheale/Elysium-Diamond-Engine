using GameServer.Classes;
using GameServer.Server;
using GameServer.Player;

namespace GameServer.GameLogic {
    public static class CharacterLogic {

        public static void UpdateCharacterStats(PlayerData pData) {
            var index = Classe.FindClasseIndexByID(pData.ClasseID); 

            for (int n = 0; n < Common.Constant.MAX_STATS; n++) {
                pData.Stat[n] = Classe.Classes[index].GetPlayerStat((StatType)n, pData) + pData.GetEquippedItemStat((StatType)n);
            }      

            pData.MaxHP = pData.Stat[(int)StatType.MaxHP];
            pData.MaxMP = pData.Stat[(int)StatType.MaxMP];
            pData.MaxSP = pData.Stat[(int)StatType.MaxSP];

            if (pData.HP > pData.MaxHP) pData.HP = pData.MaxHP;
            if (pData.MP > pData.MaxMP) pData.MP = pData.MaxMP;
            if (pData.SP > pData.MaxSP) pData.SP = pData.MaxSP;
       }

        public static void SendCharacterStats(PlayerData pData) {
            //envia os dados do jogador
            pData.SendPlayerElementalStats();
            pData.SendPlayerMagicStats();
            pData.SendPlayerPhysicalStats();
            pData.SendPlayerResistStats();
            pData.SendPlayerStats();
            pData.SendPlayerUniqueStats();
            pData.SendPlayerVital();
            pData.SendPlayerVitalRegen();
        }
    }
}

using GameServer.GameTalent;
using GameServer.Network;
using GameServer.Common;
using Lidgren.Network;

namespace GameServer.Player {
    public static class TalentPacket {
        /// <summary>
        /// Envia todos os talentos.
        /// </summary>
        /// <param name="pData"></param>
        /// <param name="tree"></param>
        public static void SendTalents(PlayerData pData, TalentTree tree) {
            for (var n = 0; n < Constant.MAX_TALENT; n++) {
                SendTalent(pData, tree, n);
            }
        }

        /// <summary>
        /// Envia determinado talento.
        /// </summary>
        /// <param name="pData"></param>
        /// <param name="tree"></param>
        /// <param name="slot"></param>
        public static void SendTalent(PlayerData pData, TalentTree tree, int slot) {
            var buffer = GameNetwork.CreateMessage(10);
            buffer.Write((short)PacketList.GS_CL_PlayerTalent);

            switch (tree) {
                case TalentTree.Balance:
                    buffer.Write(pData.Balance[slot].ID);
                    buffer.Write(pData.Balance[slot].Level);
                    break;
                case TalentTree.Physic:
                    buffer.Write(pData.Physic[slot].ID);
                    buffer.Write(pData.Physic[slot].Level);
                    break;
                case TalentTree.Magic:
                    buffer.Write(pData.Magic[slot].ID);
                    buffer.Write(pData.Magic[slot].Level);
                    break;
                case TalentTree.Restoration:
                    buffer.Write(pData.Restoration[slot].ID);
                    buffer.Write(pData.Restoration[slot].Level);
                    break;
            }

            GameNetwork.SendDataTo(pData.Connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }
    }
}
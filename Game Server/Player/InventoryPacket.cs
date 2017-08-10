using GameServer.Common;
using GameServer.Network;
using GameServer.GameItem;
using Lidgren.Network;

namespace GameServer.Player {
    public static class InventoryPacket {
        /// <summary>
        /// Envia um item do inventário para o usuário.
        /// </summary>
        /// <param name="pData"></param>
        /// <param name="slot"></param>
        public static void SendInventoryItem(PlayerData pData, short slot) {
            var buffer = GameNetwork.CreateMessage(34);
            buffer.Write((short)PacketList.GS_CL_SendInventoryItem);
            buffer.Write(slot);
            buffer.Write(pData.Inventory[slot].ID);
            buffer.Write(pData.Inventory[slot].Durability);
            buffer.Write(pData.Inventory[slot].Quantity);
            buffer.Write(pData.Inventory[slot].Enchant);
            buffer.Write(pData.Inventory[slot].Tradeable);
            buffer.Write(pData.Inventory[slot].SoulBound);

            for (int n = 0; n < Constant.MAX_ITEM_SLOT; n++) { buffer.Write(pData.Inventory[slot].Socket[n]); }

            GameNetwork.SendDataTo(pData.Connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Envia todos os items do inventário para o usuário.
        /// </summary>
        /// <param name="pData"></param>
        public static void SendInventoryItems(PlayerData pData) {
            for (short n = 0; n < Constant.MAX_INVENTORY; n++) {
                if (pData.Inventory[n].ID == 0) continue; 

                SendInventoryItem(pData, n);
            }
        }

        /// <summary>
        /// Envia os dados para a troca de items equipados.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="slot"></param>
        /// <param name="type"></param>
        public static void SendSwapEquippedItem(NetConnection connection, short slot, EquipSlotType type) {
            var buffer = GameNetwork.CreateMessage(5);
            buffer.Write((short)PacketList.GS_CL_SwapEquippedItem);
            buffer.Write(slot);
            buffer.Write((byte)type);

            GameNetwork.SendDataTo(connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Envia os dados para a troca de slot no inventário.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="from_slot"></param>
        /// <param name="to_slot"></param>
        public static void SendSwapInventoryItem(NetConnection connection, short from, short target) {
            var buffer = GameNetwork.CreateMessage(6);
            buffer.Write((short)PacketList.GS_CL_SwapInventoryItem);
            buffer.Write(from);
            buffer.Write(target);

            GameNetwork.SendDataTo(connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Desequipa o item.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="type"></param>
        public static void SendUnequipItem(NetConnection connection, EquipSlotType type) {
            var buffer = GameNetwork.CreateMessage(3);
            buffer.Write((short)PacketList.GS_CL_UnequipItem);
            buffer.Write((byte)type);

            GameNetwork.SendDataTo(connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }
    }
}
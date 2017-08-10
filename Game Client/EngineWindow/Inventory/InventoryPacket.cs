using Elysium_Diamond.Network;

namespace Elysium_Diamond.EngineWindow {
    public static class InventoryPacket {
        /// <summary>
        /// Usa o item que está em determinado slot do inventário.
        /// </summary>
        /// <param name="slot"></param>
        public static void UseInventoryItem(short slot) {
            var buffer = NetworkSocket.CreateMessage(4);
            buffer.Write((short)PacketList.CL_GS_UseInventoryItem);
            buffer.Write(slot);

            NetworkSocket.SendData(SocketEnum.GameServer, buffer);
        }

        /// <summary>
        /// Troca a posição dos items no inventário.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="target"></param>
        public static void SwapInventoryItem(short from, short target) {
            var buffer = NetworkSocket.CreateMessage(6);
            buffer.Write((short)PacketList.CL_GS_SwapInventoryItem);
            buffer.Write(from);
            buffer.Write(target);

            NetworkSocket.SendData(SocketEnum.GameServer, buffer);
        }

        /// <summary>
        /// Remove um item equipado e move para determinado slot.
        /// </summary>
        /// <param name="type"></param>
        public static void UnequipItem(EquipSlotType type, short slot) {
            var buffer = NetworkSocket.CreateMessage(5);
            buffer.Write((short)PacketList.CL_GS_UnequipItem);
            buffer.Write((byte)type);
            buffer.Write(slot);

            NetworkSocket.SendData(SocketEnum.GameServer, buffer);
        }
    }
}
using Elysium_Diamond.Resource;
using Lidgren.Network;

namespace Elysium_Diamond.EngineWindow {
    public static class InventoryData {
        /// <summary>
        /// Recebe os items equipados.
        /// </summary>
        /// <param name="msg"></param>
        public static void ReceiveEquippedItems(NetIncomingMessage msg) {
            const int MAX_ITEM_SLOT = 9;
            var type = msg.ReadByte();
            var itemID = msg.ReadInt32();

            WindowStatus.EquippedItem[type].ID = itemID;
            WindowStatus.EquippedItem[type].Durability = msg.ReadInt16();
            WindowStatus.EquippedItem[type].Enchant = msg.ReadInt16();
            WindowStatus.EquippedItem[type].Tradeable = msg.ReadByte();
            WindowStatus.EquippedItem[type].SoulBound = msg.ReadByte();
            WindowStatus.EquippedItem[type].Quantity = 1;

            for (int n = 0; n < MAX_ITEM_SLOT; n++) {
                WindowStatus.EquippedItem[type].Slot[n] = msg.ReadInt16();
            }

            WindowStatus.UpdateSlotIcons();
        }

        /// <summary>
        /// Recebe os items do inventário.
        /// </summary>
        /// <param name="msg"></param>
        public static void ReceiveInventoryItems(NetIncomingMessage msg) {
            const int MAX_ITEM_SLOT = 9;
            var slot = msg.ReadInt16();
            var itemID = msg.ReadInt32();

            WindowInventory.Inventory[slot].ID = itemID;
            WindowInventory.Inventory[slot].Durability = msg.ReadInt16();
            WindowInventory.Inventory[slot].Quantity = msg.ReadInt16();
            WindowInventory.Inventory[slot].Enchant = msg.ReadInt16();
            WindowInventory.Inventory[slot].Tradeable = msg.ReadByte();
            WindowInventory.Inventory[slot].SoulBound = msg.ReadByte();
            WindowInventory.Inventory[slot].Type = DataManager.FindItemByID(itemID).Type;

            //recebe os slots
            for (int n = 0; n < MAX_ITEM_SLOT; n++) WindowInventory.Inventory[slot].Slot[n] = msg.ReadInt16();
                     
            WindowInventory.UpdateSlotIcons();
        }

        /// <summary>
        /// Realiza a troca de equipamentos.
        /// </summary>
        /// <param name="msg"></param>
        public static void SwapEquippedItem(NetIncomingMessage msg) {
            var slot = msg.ReadInt16();
            var type = (EquipSlotType)msg.ReadByte();
            
            if (WindowStatus.EquippedItem[(int)type].ID > 0) {
                var item = new Item(WindowStatus.EquippedItem[(int)type]);

                WindowStatus.EquippedItem[(int)type] = new Item(WindowInventory.Inventory[slot]);
                WindowInventory.Inventory[slot] = new Item(item);

                item.Clear();
            } else {
                WindowStatus.EquippedItem[(int)type] = new Item(WindowInventory.Inventory[slot]);
                WindowInventory.Inventory[slot].Clear();
            }

            WindowStatus.UpdateSlotIcons();
            WindowInventory.UpdateSlotIcons();
            WindowSelectedItem.Close();
        }

        /// <summary>
        /// Troca a posição dos items no inventário.
        /// </summary>
        /// <param name="msg"></param>
        public static void SwapInventoryItem(NetIncomingMessage msg) {
            var from = msg.ReadInt16();
            var target = msg.ReadInt16();

            //copia o item para um slot temporario
            var temporary = new Item(WindowInventory.Inventory[target]);

            WindowInventory.Inventory[target] = new Item(WindowInventory.Inventory[from]);

            WindowInventory.Inventory[from] = new Item(temporary);

            temporary.Clear();

            WindowInventory.UpdateSlotIcons();
        }

        /// <summary>
        /// Remove um item equipado.
        /// </summary>
        /// <param name="msg"></param>
        public static void UnequipItem(NetIncomingMessage msg) {
            var type = msg.ReadByte();
            WindowStatus.EquippedItem[type].Clear();
            WindowStatus.UpdateSlotIcons();
        }
    }
}
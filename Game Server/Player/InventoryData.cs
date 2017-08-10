using GameServer.Server;
using GameServer.Common;
using GameServer.GameLogic;
using GameServer.GameItem;
using Lidgren.Network;

namespace GameServer.Player {
    public static class InventoryData {
        /// <summary>
        /// Usa o item que está em determinado slot do inventário.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="msg"></param>
        public static void UseInventoryItem(NetConnection connection, NetIncomingMessage msg) {
            var pData = Authentication.FindByConnection(connection);
            var slot = msg.ReadInt16();

            //verifica o range dos slots
            if (slot < 0 | slot >= Constant.MAX_INVENTORY) return;

            //verifica se há algum item
            if (pData.Inventory[slot].ID <= 0) { return; }
       
            //utiliza o item e obtem o tipo
            var type = pData.UseInventoryItem(slot);

            //envia os dados para a troca no cliente
            InventoryPacket.SendSwapEquippedItem(connection, slot, type);

            //atualiza os stats
            CharacterLogic.UpdateCharacterStats(pData);
            CharacterLogic.SendCharacterStats(pData);
        }

        /// <summary>
        /// Realiza a troca de slot entre dois items.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="msg"></param>
        public static void SwapInventoryItem(NetConnection connection, NetIncomingMessage msg) {
            var pData = Authentication.FindByConnection(connection);
            var from = msg.ReadInt16();
            var target = msg.ReadInt16();

            //verifica o range dos slots
            if (from < 0 | from >= Constant.MAX_INVENTORY) return;
            if (target < 0 | target >= Constant.MAX_INVENTORY) return;

            //verifica se há algum item
            if (pData.Inventory[from].ID <= 0) { return; }

            pData.SwapInventoryItem(from, target);

            //atualiza os items no cliente
            InventoryPacket.SendSwapInventoryItem(connection, from, target);
        }

        /// <summary>
        /// Desequipa um item em determinado slot do inventário.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="msg"></param>
        public static void UnequipItem(NetConnection connection, NetIncomingMessage msg) {
            var pData = Authentication.FindByConnection(connection);
            var type = (EquipSlotType)msg.ReadByte();
            var slot = msg.ReadInt16();
           
            //se passar dos limites
            if ((int)type >= Constant.MAX_EQUIPPED_ITEM) return;

            //se o slot já estiver ocupado, procura um slot vazio  
            if (pData.Inventory[slot].ID > 0) {
                slot = pData.FindInventoryFreeSlot();
            }
          
            //se o inventário estiver cheio, envia mensagem
            if (slot == -1) {
                //envia mensagem de inventário cheio
                return;
            }

            //adiciona o item no inventário
            pData.AddInventoryItem(pData.EquippedItem[(int)type], slot);

            //remove o item equipado
            pData.EquippedItem[(int)type].Clear();

            //desequipa o item 
            InventoryPacket.SendUnequipItem(connection, type);

            //envia o novo item
            InventoryPacket.SendInventoryItem(pData, slot);

            //atualiza os stats
            CharacterLogic.UpdateCharacterStats(pData);
            CharacterLogic.SendCharacterStats(pData);
        }
    }
}
using GameServer.GameItem;
using GameServer.Common;

namespace GameServer.Player {
    public partial class PlayerData {
        /// <summary>
        /// Items equipados ao personagem.
        /// </summary>
        public Item[] EquippedItem { get; set; } = new Item[Constant.MAX_EQUIPPED_ITEM];

        /// <summary>
        /// Inventário.
        /// </summary>
        public Item[] Inventory { get; set; } = new Item[Constant.MAX_INVENTORY];

        /// <summary>
        /// Adiciona um item ao inventário.
        /// </summary>
        /// <param name="item"></param>
        public void AddInventoryItem(Item item, short slot) {
            Inventory[slot] = new Item(item);
        }

        /// <summary>
        /// Utiliza um item do inventário e retorna o tipo de item.
        /// </summary>
        /// <param name="slot"></param>
        public EquipSlotType UseInventoryItem(short slot) {
            var item = ItemManager.FindByID(Inventory[slot].ID);
            var range = (byte)item.Type;

            //se o item for um equipamento, equipa o item no personagem
            if (range >= 0 && range < Constant.MAX_EQUIPPED_ITEM) {
                return EquipItem(slot, item.Type);
            }

            return EquipSlotType.Weapon;
        }

        /// <summary>
        /// Equipa o item do inventário e retorna o tipo de item.
        /// </summary>
        /// <param name="slot"></param>
        /// <param name="type"></param>
        private EquipSlotType EquipItem(short slot, ItemType type) {
            int index = (int)type;

            //verifica se o slot está cheio
            if (type == ItemType.Earring) {
                if (EquippedItem[(int)EquipSlotType.EarringLeft].ID == 0) {
                    index = (int)EquipSlotType.EarringLeft;
                }
                else {
                    index = (int)EquipSlotType.EarringRight;
                }
            }

            //verifica se o slot está cheio
            if (type == ItemType.Ring) {
                if (EquippedItem[(int)EquipSlotType.RingLeft].ID == 0) {
                    index = (int)EquipSlotType.RingLeft;
                }
                else {
                    index = (int)EquipSlotType.RingRight;
                }
            }

            //se há item sendo usado
            if (EquippedItem[index].ID > 0) {
                //verifica se é anel ou earring,
       
                //copia o item para um slot temporario
                var temporary = new Item(EquippedItem[index]);

                //equipa o item do inventário
                EquippedItem[index] = new Item(Inventory[slot]);

                //volta o item equipado para o inventario
                Inventory[slot] = new Item(temporary);

                temporary.Clear();
            }
            else {
                //equipa o item do inventário
                EquippedItem[index] = new Item(Inventory[slot]);

                //limpa o slot
                Inventory[slot].Clear();
            }

            //retorna o tipo de equipamento
            return (EquipSlotType)index;
        }

        /// <summary>
        /// Troca a posição dos items no inventário.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="target"></param>
        public void SwapInventoryItem(short from, short target) {
            //copia o item para um slot temporario
            var temporary = new Item(Inventory[target]);

            Inventory[target] = new Item(Inventory[from]);

            Inventory[from] = new Item(temporary);

            temporary.Clear();
        }

        /// <summary>
        /// Procura um slot vazio. Quando cheio, retorna -1.
        /// </summary>
        /// <returns></returns>
        public short FindInventoryFreeSlot() {
            for (short n = 0; n < Constant.MAX_INVENTORY; n++) {
                if (Inventory[n].ID == 0) { return n; }
            }

            return -1;
        }

        /// <summary>
        /// Obtem a informação do atributo selecionado.-
        /// </summary>
        /// <param name="stat"></param>
        /// <returns></returns>
        public int GetEquippedItemStat(StatType stat) {
            var stat_value = 0;
            ItemData item;

            for (var n = 0; n < Constant.MAX_EQUIPPED_ITEM; n++) {
                if (EquippedItem[n].ID == 0) continue;
                item = ItemManager.FindByID(EquippedItem[n].ID);
                stat_value += item.Stat[(int)stat] + (item.StatLevel[(int)stat] * EquippedItem[n].Enchant);
                //manstone 
                for (var i = 0; i < Constant.MAX_ITEM_SLOT; i++) {
                    if (EquippedItem[n].Socket[i] == 0) { continue; }
                    item = ItemManager.FindByID(EquippedItem[n].Socket[i]);
                    stat_value += item.Stat[(int)stat];
                }
            }

            return stat_value;
        }
    }
}
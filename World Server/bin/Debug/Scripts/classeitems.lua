import 'WorldServer'
import 'WorldServer.GameItem'

-- Configuração do item
local item = Item()
item.ID = 1
item.Quantity = 1
item.Enchant = 0
item.Durability = 120
item.Expire = 0
item.ExpireDays = 0
item.Socket[0] = 0
item.Socket[1] = 0
item.Socket[2] = 0
item.Socket[3] = 0
item.Socket[4] = 0
item.Socket[5] = 0
item.Socket[6] = 0
item.Socket[7] = 0
item.Socket[8] = 0
item.Tradeable = 1
item.SoulBound = 0

-- Adiciona um novo item a classe 1 - Guerreiro
-- ClasseID, Item, ItemType
SetEquippedItem(1, item, EquipSlotType.Weapon)
SetEquippedItem(2, item, EquipSlotType.Weapon)
item.ID = 2
SetEquippedItem(1, item, EquipSlotType.Shield)
SetEquippedItem(2, item, EquipSlotType.Shield)
item.ID = 3
SetEquippedItem(1, item, EquipSlotType.Gloves)
SetEquippedItem(2, item, EquipSlotType.Gloves)
item.ID = 4
SetEquippedItem(1, item, EquipSlotType.Head)
SetEquippedItem(2, item, EquipSlotType.Head)
item.ID = 5
SetEquippedItem(1, item, EquipSlotType.Pants)
SetEquippedItem(2, item, EquipSlotType.Pants)
item.ID = 6
SetEquippedItem(1, item, EquipSlotType.Legs)
SetEquippedItem(2, item, EquipSlotType.Legs)
item.ID = 7
SetEquippedItem(1, item, EquipSlotType.Shoulder)
SetEquippedItem(2, item, EquipSlotType.Shoulder)
item.ID = 8
SetEquippedItem(1, item, EquipSlotType.Chest)
SetEquippedItem(2, item, EquipSlotType.Chest)

--Adiciona um item ao inventario
--ClasseID, InvSlot, Item
AddInventoryItem(1, 0, item);
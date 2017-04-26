import 'System'
import 'WorldServer'
import 'WorldServer.Items'

-- Configuração do item
local item = Item()
item.ID = 1
item.UniqueID = "InitialItem"
item.Quantity = 1
item.Enchant = 0
item.Element = 0
item.Durability = 250
item.Expire = 0
item.ExpireTime = DateTime(2017, 04, 15, 15, 15, 00)
item.SoulBound = 0
item.Slots = '0,0,0,0,0,0'

-- Adiciona um novo item a classe 1 - Guerreiro
-- ClasseID, Item, ItemType
SetEquippedItem(1, item, ItemType.Weapon)

item = Item(item)
item.ID = 2
item.ExpireTime = DateTime(2017, 04, 15, 15, 15, 00)

-- ClasseID, Item, ItemType
SetEquippedItem(1, item, ItemType.Chest)

item = Item(item)
item.ID = 3
item.ExpireTime = DateTime(2017, 04, 15, 15, 15, 00)

-- ClasseID, Item, ItemType
SetEquippedItem(1, item, ItemType.Legs)

-- Adiciona um novo item a classe 2 - Mago
item = Item(item)
item.ID = 4
item.ExpireTime = DateTime(2017, 04, 15, 15, 15, 00)

-- ClasseID, Item, ItemType
SetEquippedItem(2, item, ItemType.Weapon)

item = Item(item)
item.ID = 5
item.ExpireTime = DateTime(2017, 04, 15, 15, 15, 00)

-- ClasseID, Item, ItemType
SetEquippedItem(2, item, ItemType.Chest)

item = Item(item)
item.ID = 6
item.ExpireTime = DateTime(2017, 04, 15, 15, 15, 00)

-- ClasseID, Item, ItemType
SetEquippedItem(2, item, ItemType.Legs)
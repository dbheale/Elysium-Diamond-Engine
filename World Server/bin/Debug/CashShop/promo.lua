import 'WorldServer'
import 'WorldServer.GameItem'
import 'WorldServer.BlackMarket'

-- Configuração do item
local item = CashItem()
item.CashItemID = 2 --ID do item na loja
item.Price = 7050 --Preço por unidade
item.BuyLimit = 5 -- limite de compra
item.Category = ItemCategory.Promo 
item.GiftEnabled = true
item.ID = 2 --ID do item 
item.Quantity = 1
item.Enchant = 0
item.Durability = 120
item.Expire = 1
item.ExpireDays = 30
item.Socket[0] = 0
item.Tradeable = 1
item.SoulBound = 0

--adiciona o item
AddCashItem(item)

item.CashItemID = 4
item.Price = 120
item.BuyLimit = 1
item.ID = 4

AddCashItem(item)

item.CashItemID = 5
item.Price = 120
item.BuyLimit = 1
item.ID = 5

AddCashItem(item)
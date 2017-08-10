import 'WorldServer'
import 'WorldServer.GameItem'
import 'WorldServer.BlackMarket'

-- Configuração do item
local item = CashItem()
item.CashItemID = 1 --ID do item na loja
item.Price = 4500 --Preço por unidade
item.BuyLimit = 1 -- limite de compra
item.Category = ItemCategory.Style 
item.GiftEnabled = true
item.ID = 1 --ID do item 
item.Quantity = 255
item.Enchant = 0
item.Durability = 120
item.Expire = 1
item.ExpireDays = 60
item.Socket[0] = 0
item.Socket[1] = 0
item.Tradeable = 1
item.SoulBound = 0

--adiciona o item
AddCashItem(item)
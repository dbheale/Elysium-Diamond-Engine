import 'WorldServer'
import 'WorldServer.GameItem'
import 'WorldServer.BlackMarket'

-- Configuração do item
local item = CashItem()
item.CashItemID = 3 --ID do item na loja
item.Price = 250 --Preço por unidade
item.BuyLimit = 1 -- Quantidade máxima que pode ser comprada de uma vez.
item.Category = ItemCategory.Boost 
item.GiftEnabled = false
item.ID = 3 --ID do item 
item.Quantity = 1 --Quantidade
item.Enchant = 0
item.Durability = 120
item.Expire = 1
item.ExpireDays = 90
item.Socket[0] = 0
item.Tradeable = 0
item.SoulBound = 0

--adiciona o item
AddCashItem(item)
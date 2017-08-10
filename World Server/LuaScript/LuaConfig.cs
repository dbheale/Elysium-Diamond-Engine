using System;
using NLua;
using WorldServer.Common;
using WorldServer.Server;
using WorldServer.BlackMarket;

namespace WorldServer.LuaScript {
    public static class LuaConfig {
        /// <summary>
        /// Inicializa lua e obtem as configurações.
        /// </summary>
        public static void InitializeConfig() {
            using (var lua = new Lua()) {
                lua.LoadCLRPackage();

                lua.RegisterFunction("AddDeleteTime", null, typeof(DeleteTime).GetMethod("AddDeleteTime"));

                lua.DoFile("./Scripts/character.lua");

                Configuration.CharacterCreation = Convert.ToBoolean(lua["Character.Creation"]);
                Configuration.CharacterDelete = Convert.ToBoolean(lua["Character.Delete"]);
                Configuration.CharacterDeleteMinLevel = Convert.ToInt32(lua["Character.DeleteMinLevel"]);
                Configuration.CharacterDeleteMaxLevel = Convert.ToInt32(lua["Character.DeleteMaxLevel"]);

                lua.RegisterFunction("AddBannedName", null, typeof(ProhibitedNames).GetMethod("AddRange"));
                lua.RegisterFunction("SetEquippedItem", null, typeof(Classe).GetMethod("SetEquippedItem"));
                lua.RegisterFunction("AddInventoryItem", null, typeof(Classe).GetMethod("AddInventoryItem"));
                lua.RegisterFunction("AddCashItem", null, typeof(CashShop).GetMethod("AddItem"));

                lua.DoFile("./Scripts/prohibitednames.lua");
                lua.DoFile("./Scripts/classeitems.lua");
                lua.DoFile("./CashShop/shop.lua");

                CashShop.Enabled = Convert.ToBoolean(lua["Enabled"]);
                CashShop.Sender = (string)lua["Sender"];
                CashShop.PurchaseTitle = (string)lua["PurchaseTitle"];
                CashShop.PurchaseMessage = (string)lua["PurchaseMessage"];
                CashShop.GiftTitle = (string)lua["GiftTitle"];
                CashShop.GiftMessage = (string)lua["GiftMessage"];
            }
        }

        public static void ReloadCashShop() {
            CashShop.Clear();

            using (var lua = new Lua()) {
                lua.LoadCLRPackage();
                lua.RegisterFunction("AddCashItem", null, typeof(CashShop).GetMethod("AddItem"));
                lua.DoFile("./CashShop/shop.lua");

                CashShop.Enabled = Convert.ToBoolean(lua["Enabled"]);
                CashShop.Sender = (string)lua["Sender"];
                CashShop.PurchaseTitle = (string)lua["PurchaseTitle"];
                CashShop.PurchaseMessage = (string)lua["PurchaseMessage"];
                CashShop.GiftTitle = (string)lua["GiftTitle"];
                CashShop.GiftMessage = (string)lua["GiftMessage"];
            }
        }
    }
}
using System;
using NLua;
using WorldServer.Common;
using WorldServer.Server;

namespace WorldServer.LuaScript {
    public static class LuaConfig {
        /// <summary>
        /// Inicializa lua e obtem as configurações.
        /// </summary>
        public static void InitializeConfig() {

            using (var lua = new Lua()) {
                
                lua.LoadCLRPackage();

                lua.DoFile("character.lua");

                Configuration.CharacterCreation = (bool)lua["Character.Creation"];
                Configuration.CharacterDelete = (bool)lua["Character.Delete"];
                Configuration.CharacterDeleteMinLevel = Convert.ToInt32(lua["Character.DeleteMinLevel"]);
                Configuration.CharacterDeleteMaxLevel = Convert.ToInt32(lua["Character.DeleteMaxLevel"]);

                lua.RegisterFunction("Add", null, typeof(ProhibitedNames).GetMethod("Add"));
                lua.RegisterFunction("AddRange", null, typeof(ProhibitedNames).GetMethod("AddRange"));
                lua.RegisterFunction("SetEquippedItem", null, typeof(Classe).GetMethod("SetEquippedItem"));
 
                lua.DoFile("prohibitednames.lua");
                lua.DoFile("classeitems.lua");
            }
        }
    }
}

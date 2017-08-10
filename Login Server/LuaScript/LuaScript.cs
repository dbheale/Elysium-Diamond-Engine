using NLua;
using LoginServer.Server;

namespace LoginServer.LuaScript {
    public static class LuaScript {

        public static void InitializeScript() {
            using(var lua = new Lua()) {
                lua.RegisterFunction("AddChecksum", null, typeof(CheckSum).GetMethod("Add"));
                lua.RegisterFunction("AddCountry", null, typeof(GeoIp).GetMethod("AddCountry"));

                lua.DoFile("checksum.lua");
                lua.DoFile("geoip.lua");
            }       
        }
    }
}
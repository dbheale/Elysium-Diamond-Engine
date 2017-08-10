using NLua;
using ConnectServer.Server;

namespace ConnectServer.LuaScript {
    public static class LuaConfig {
        /// <summary>
        /// Inicializa lua e carrega as configurações.
        /// </summary>
        public static void InitializeConfig() {
            using (var lua = new Lua()) {
                lua.RegisterFunction("AddChannel", null, typeof(AutoBalance).GetMethod("AddChannel"));

                lua.DoFile("./Scripts/channel.lua");
            }
        }
    }
}
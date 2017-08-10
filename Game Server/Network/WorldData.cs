using GameServer.Server;
using GameServer.Common;
using Lidgren.Network;
using Elysium;

namespace GameServer.Network {
    public static class WorldData {
        /// <summary>
        /// Recebe o ID do servidor world.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="msg"></param>
        public static void ReceiveConnectionID(NetConnection connection, int worldID) {
            var pData = Authentication.FindByConnection(connection);
            pData.AccountID = worldID;
            Configuration.WorldID = worldID;
            pData.HexID = NetUtility.ToHexString(connection.RemoteUniqueIdentifier);
            Logs.Write($"World Server ID: {worldID}", System.Drawing.Color.DarkMagenta);
        }
    }
}

using LoginServer.Common;
using LoginServer.Server;
using Lidgren.Network;

namespace LoginServer.Network {
    public static class LoginPacket {
        /// <summary>
        /// Envia o HexID para o cliente.
        /// </summary>
        /// <param name="hexID"></param>
        /// <param name="hexid"></param>
        public static void HexID(NetConnection connection, string hexid) {
            var buffer = LoginNetwork.CreateMessage(2);
            buffer.Write((short)PacketList.LS_CL_SendPlayerHexID);
            buffer.Write(hexid);
            LoginNetwork.SendDataTo(connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Envia a alteração do 'GameState'.
        /// </summary>
        /// <param name="hexID"></param>
        /// <param name="value"></param>
        public static void GameState(NetConnection connection, GameState state) {
            var buffer = LoginNetwork.CreateMessage(3);
            buffer.Write((short)PacketList.ChangeGameState);
            buffer.Write((byte)state);
            LoginNetwork.SendDataTo(connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Envia mensagens (cabeçalho) que são ativadas no cliente.
        /// </summary>
        /// <param name="hexID"></param>
        /// <param name="value"></param>
        public static void Message(NetConnection connection, short value) {
            var buffer = LoginNetwork.CreateMessage(2);
            buffer.Write(value);
            LoginNetwork.SendDataTo(connection, buffer, NetDeliveryMethod.ReliableUnordered);
        }

        /// <summary>
        /// Envia a lista de servidores.
        /// </summary>
        /// <param name="hexID"></param>
        public static void ServerList(NetConnection connection) {
            var buffer = LoginNetwork.CreateMessage();
            buffer.Write((short)PacketList.LS_CL_ServerList);

            for (var n = 0; n < Constants.MaxServer; n++) {
                buffer.Write(Configuration.Server[n].Name);
                buffer.Write(Configuration.Server[n].WorldServerIP);
                buffer.Write(Configuration.Server[n].WorldServerPort);
                buffer.Write(Configuration.Server[n].Region);
                buffer.Write(Configuration.Server[n].Status);
            }

            LoginNetwork.SendDataTo(connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }
    }
}
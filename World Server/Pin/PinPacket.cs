using WorldServer.Common;
using WorldServer.Network;
using Lidgren.Network;

namespace WorldServer.Pin {
   public static class PinPacket {
        /// <summary>
        /// Mostra a janela de PIN no cliente.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="value"></param>
        public static void ShowPinWindow(NetConnection connection, bool value) {
            var buffer = WorldNetwork.CreateMessage(8);
            buffer.Write((short)PacketList.WS_CL_ShowPinWindow);
            buffer.Write(value);
            WorldNetwork.SendDataTo(connection, buffer, NetDeliveryMethod.ReliableUnordered);
        }

        /// <summary>
        /// Envia a mensagem de erro do pin com o número de tentativas.
        /// </summary>
        /// <param name="hexID"></param>
        /// <param name="value"></param>
        public static void IncorrectPin(NetConnection connection, byte value) {
            var buffer = WorldNetwork.CreateMessage(8);
            buffer.Write((short)PacketList.WS_CL_IncorrectPin);
            buffer.Write(value);
            buffer.Write(Configuration.PinMaxAttempt);
            buffer.Write(Configuration.PinBannedTime);
            WorldNetwork.SendDataTo(connection, buffer, NetDeliveryMethod.ReliableUnordered);
        }

        /// <summary>
        /// Envia mensagem de erro, pin incorreto.
        /// </summary>
        /// <param name="hexID"></param>
        public static void IncorrectPin(NetConnection connection) {
            var buffer = WorldNetwork.CreateMessage(4);
            buffer.Write((short)PacketList.WS_CL_InvalidPin);
            WorldNetwork.SendDataTo(connection, buffer, NetDeliveryMethod.ReliableUnordered);
        }

        /// <summary>
        /// Envia o pedido de registro de um novo pin.
        /// </summary>
        /// <param name="hexID"></param>
        public static void RegisterPin(NetConnection connection) {
            var buffer = WorldNetwork.CreateMessage(5);
            buffer.Write((short)PacketList.WS_CL_PinRegister);
            WorldNetwork.SendDataTo(connection, buffer, NetDeliveryMethod.ReliableUnordered);
        }
    }
}

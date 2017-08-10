using WorldServer.Network;
using Lidgren.Network;

namespace WorldServer.WorldChat {
    public static class ChatPacket {
        /// <summary>
        /// Envia a mensagem para todos. 
        /// </summary>
        /// <param name="text"></param>
        public static void GlobalMessage(string sender, string msg, ChatMessageType type, ChatMessageChannel channel) {
            var buffer = WorldNetwork.CreateMessage();
            buffer.Write((short)PacketList.WS_CL_GlobalChat);
            buffer.Write((byte)type);
            buffer.Write((byte)channel);
            buffer.Write(sender);
            buffer.Write(msg);

            WorldNetwork.SendDataToAll(buffer, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Envia a mensagem para o jogador.
        /// </summary>
        /// <param name="text"></param>
        public static void PlayerMessage(NetConnection connection, string sender, string msg, ChatMessageType type, ChatMessageChannel channel = ChatMessageChannel.None) {
            var buffer = WorldNetwork.CreateMessage();
            buffer.Write((short)PacketList.WS_CL_PlayerMessage);
            buffer.Write((byte)type);
            buffer.Write((byte)channel);
            buffer.Write(sender);
            buffer.Write(msg);

            WorldNetwork.SendDataTo(connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }
    }
}

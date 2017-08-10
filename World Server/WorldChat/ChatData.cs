using WorldServer.Server;
using Lidgren.Network;

namespace WorldServer.WorldChat {
    public static class ChatData {
        public static void ReceiveChatMessage(NetConnection connection, NetIncomingMessage msg) {
            var pData = Authentication.FindByConnection(connection);
            var sender = pData.CharacterName;
            var type = (ChatMessageType)msg.ReadByte();
            var channel = (ChatMessageChannel)msg.ReadByte();
            var target = msg.ReadString().Trim();
            var message = msg.ReadString().Trim();

            //mensagem global
            if (type == ChatMessageType.Global) {
                if (channel != ChatMessageChannel.None) {
                    Chat.SendChannelMessage(sender, message, type, channel);
                }

                return;
            }

            //mensagem privada, send invalid msg, player is not online
            if (type == ChatMessageType.Private) {
                Chat.SendPrivateMessage(target, sender, message);
                return;
            }

            //mensagem de grupo, send invalid msg, you're not in party
            if (type == ChatMessageType.Party) {
                return;     
            }

            //mensagem de guild, send invalid msg, you're not in guild
            if (type == ChatMessageType.Guild) {
                return;
            }
        }
    }
}

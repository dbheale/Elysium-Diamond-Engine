using System.Collections.Generic;
using System.Drawing;
using Lidgren.Network;
using WorldServer.Server;
using Elysium.Logs;

namespace WorldServer.WorldChat {
    public class Chat {
        public static List<string> WorldMessage { get; set; }

        /// <summary>
        /// Envia a mensagem do servidor para o jogador.
        /// </summary>
        /// <param name="connection"></param>
        public static void SendServerMessage(NetConnection connection) {
            foreach (var msg in WorldMessage) {
                ChatPacket.PlayerMessage(connection, string.Empty, msg, ChatMessageType.Server, ChatMessageChannel.None);
            }
        }

        /// <summary>
        /// Envia a mensagem para determinado jogador.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="sender"></param>
        /// <param name="msg"></param>
        public static void SendPrivateMessage(string target, string sender, string msg) {
            var pData = Authentication.FindByCharacterName(target);
            if (pData == null)  return;
            ChatPacket.PlayerMessage(pData.Connection, sender, msg, ChatMessageType.Private, ChatMessageChannel.None);
        }

        /// <summary>
        /// Envia mensagem para determinado canal.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="msg"></param>
        /// <param name="type"></param>
        /// <param name="channel"></param>
        public static void SendChannelMessage(string sender, string msg, ChatMessageType type, ChatMessageChannel channel) {
            ChatPacket.GlobalMessage(sender, msg, type, channel);
            Log.Write($"Channel-> {sender}: {msg}", Color.Black);
        }
    }
}
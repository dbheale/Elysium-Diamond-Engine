using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using Lidgren.Network;
using WorldServer.Server;
using WorldServer.Network;
using WorldServer.GameGuild;
using Elysium;

namespace WorldServer.Chat {
    public class WorldChat {
        private static List<WorldMessage> messages;
        /// <summary>
        /// Envia a mensagem do servidor para o jogador.
        /// </summary>
        /// <param name="connection"></param>
        public static void SendServerMessage(NetConnection connection) {
            var pData = Authentication.FindByConnection(connection);

            foreach(var msg in messages) {
               WorldPacket.PlayerMessage(connection, "server", msg.Message, msg.Type);
            }    
        }

        /// <summary>
        /// Envia a mensagem para determinado jogador.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="msg"></param>
        public static void SendPrivateMessage(NetConnection connection, NetIncomingMessage msg) {
            var pData = Authentication.FindByConnection(connection);
            var player = msg.ReadString();
            var _msg = msg.ReadString();
            var targetPlayer = Authentication.FindByCharacterName(player);
            
            WorldPacket.PlayerMessage(targetPlayer.Connection, pData.CharacterName, _msg, MessageType.Private);
        }

        /// <summary>
        /// Envia a mensagem para determinado canal.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="msg"></param>
        public static void SendChannelMessage(NetConnection connection, NetIncomingMessage msg) {
            var channel = msg.ReadByte();
            var _msg = msg.ReadString().Trim();

            var pData = Authentication.FindByConnection(connection);

            WorldPacket.GlobalMessage(pData.CharacterName, _msg, MessageType.Channel, (MessageChannel)channel);

            Logs.Write($"Channel-> {pData.CharacterName}: {_msg}", Color.Black);
        }

        /// <summary>
        /// Envia a mensagem para os membros da guild.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="msg"></param>
        public static void SendGuildMessage(NetConnection connection, string msg) {
            var pData = Authentication.FindByConnection(connection);

            if (pData.GuildID == 0) { return; }

            var gData = Guild.FindGuildByID(pData.GuildID);

            //cria a mensagem
            var buffer = WorldNetwork.CreateMessage();
            buffer.Write((int)PacketList.WS_CL_PlayerMessage);
            buffer.Write((byte)MessageType.Guild);
            buffer.Write((byte)MessageChannel.None);
            buffer.Write(pData.CharacterName);
            buffer.Write(msg);

            foreach (var mData in gData.Member) {
                if (mData.Status == (MemberStatus.Online | MemberStatus.Busy)) {
                    var g_mData = Authentication.FindByCharacterID(mData.ID);

                    WorldNetwork.SendDataTo(g_mData.Connection, buffer, NetDeliveryMethod.ReliableOrdered);
                }
            }
        }

        /// <summary>
        /// Carrega as mensagens do servidor.
        /// </summary>
        public static void ReadMessageFile() {
            const string fileName = "WorldMessage.txt";

            if (!File.Exists(fileName))
                throw new Exception("cannot find message file");

            messages = new List<WorldMessage>();

            using (StreamReader sr = new StreamReader(fileName)) {
                while (sr.Peek() >= 0) {

                    var text = sr.ReadLine().Trim().Split(';');
                    var m_info = typeof(MessageType).GetField(text[1]);

                    messages.Add(new WorldMessage(text[0], (MessageType)m_info.GetValue(null)));
                }
            }
        }
    }
}

using Lidgren.Network;
using WorldServer.Server;
using WorldServer.Common;

namespace WorldServer.Network {
    public class WorldPacket {
        /// <summary>
        /// Envia o pedido de hexid para o cliente.
        /// </summary>
        /// <param name="index"></param>
        public static void NeedHexID(NetConnection connection) {
            var buffer = WorldNetwork.CreateMessage(4);
            buffer.Write((int)PacketList.WS_CL_NeedPlayerHexID);
            WorldNetwork.SendDataTo(connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Envia mensagens sem conteúdo.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public static void Message(string hexID, int value) {
            var buffer = WorldNetwork.CreateMessage(4);
            buffer.Write(value);
            WorldNetwork.SendDataTo(hexID, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Envia mensagens sem conteudo.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="value"></param>
        public static void Message(NetConnection connection, int value) {
            var buffer = WorldNetwork.CreateMessage(4);
            buffer.Write(value);
            WorldNetwork.SendDataTo(connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Envia a alteração de 'GameState'.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public static void GameState(string hexID, GameState state) {
            var buffer = WorldNetwork.CreateMessage(5);
            buffer.Write((int)PacketList.ChangeGameState);
            buffer.Write((byte)state);
            WorldNetwork.SendDataTo(hexID, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Envia os dados básico dos personagens.
        /// </summary>
        /// <param name="hexID"></param>
        public static void PreLoad(PlayerData pData) {
            var buffer = WorldNetwork.CreateMessage();
            buffer.Write((int)PacketList.WS_CL_CharacterPreLoad);

            for (var n = 0; n < Constant.MAX_CHARACTER; n++) {
                buffer.Write(pData.Character[n].Name);
                buffer.Write(pData.Character[n].Class);
                buffer.Write(pData.Character[n].Sprite);
                buffer.Write(pData.Character[n].Level);
            }
 
            WorldNetwork.SendDataTo(pData.HexID, buffer, NetDeliveryMethod.ReliableOrdered);
        }
    
        /// <summary>
        /// Envia os dados do game server para o cliente.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="hexID"></param>
        public static void GameServerData(NetConnection connection, string hexID) {
            var buffer = WorldNetwork.CreateMessage();
            buffer.Write((int)PacketList.WS_CL_GameServerData);
            buffer.Write(hexID);
            buffer.Write(Configuration.GameServer[0].GameServerIP);
            buffer.Write(Configuration.GameServer[0].GameServerPort);
                
            WorldNetwork.SendDataTo(connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }     

        /// <summary>
        /// Envia a resposta para o login server se o usuario foi encontrado.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="value"></param>
        /// <param name="username"></param>
        public static void ConnectedResult(NetConnection connection, bool value, string username) {
            var buffer = WorldNetwork.CreateMessage();
            buffer.Write((int)PacketList.LS_WS_IsPlayerConnected);
            buffer.Write(value);
            buffer.Write(username);

            WorldNetwork.SendDataTo(connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Envia a mensagem para todos. 
        /// </summary>
        /// <param name="text"></param>
        public static void GlobalMessage(string from, string msg, MessageType type, MessageChannel channel) {
            var buffer = WorldNetwork.CreateMessage();
            buffer.Write((int)PacketList.CL_WS_GlobalChat); //usa o mesmo pacote
            buffer.Write((byte)type);
            buffer.Write((byte)channel);
            buffer.Write(from);
            buffer.Write(msg);

            WorldNetwork.SendDataToAll(buffer, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Envia a mensagem para o jogador.
        /// </summary>
        /// <param name="text"></param>
        public static void PlayerMessage(NetConnection connection, string from, string msg, MessageType type, MessageChannel channel = MessageChannel.None) {
            var buffer = WorldNetwork.CreateMessage();
            buffer.Write((int)PacketList.WS_CL_PlayerMessage); 
            buffer.Write((byte)type);
            buffer.Write((byte)channel); 
            buffer.Write(from);
            buffer.Write(msg);

            WorldNetwork.SendDataTo(connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }
    }
}

using System;
using System.Drawing;
using LoginServer.Common;
using LoginServer.Server;
using Lidgren.Network;
using Elysium;

namespace LoginServer.Network { 
    public static class WorldPacket {
        /// <summary>
        /// Envia a identificação para o world server.
        /// </summary>
        public static void ConnectionID(int worldID) {
            var buffer = WorldNetwork.WorldServer[worldID].CreateMessage(6);
            buffer.Write((short)PacketList.LS_WS_CheckConnection);
            buffer.Write(Configuration.ID);
            WorldNetwork.WorldServer[worldID].SendData(buffer);
        }

        /// <summary>
        /// Envia todos os dados do usuário para o WorldServer que foi selecionado pelo cliente.
        /// </summary>
        /// <param name="pIndex"></param>
        /// <param name="worldID"></param>
        public static void PlayerLogin(string hexID, int worldID) {
            LoginPacket.HexID(hexID, hexID);

            var pData = Authentication.FindByHexID(hexID);
            var buffer = WorldNetwork.WorldServer[worldID].CreateMessage();
            buffer.Write((short)PacketList.LS_WS_SendPlayerHexID);
            buffer.Write(pData.HexID);
            buffer.Write(pData.Account);
            buffer.Write(pData.ID);
            buffer.Write(pData.LanguageID);
            buffer.Write(pData.AccessLevel);
            buffer.Write(pData.Cash);
            buffer.Write(pData.Pin);
            buffer.Write(pData.PinAttempt);

            //escreve a quantidade de serviços
            int[] servicesID = pData.Service.GetServicesID();
            buffer.Write(pData.Service.Count());

            //escreve cada serviço no buffer
            foreach (var id in servicesID)  buffer.Write(pData.Service.GetService(id));
            
            WorldNetwork.WorldServer[worldID].SendData(buffer);

            Logs.Write($"World Server {Configuration.Server[worldID].Name} Login Attempt: {pData.Account} {pData.IP}", Color.Black); 
        } 

        /// <summary>
        /// Verifica se o usuário já está conectado em algum outro servidor.
        /// </summary>
        /// <param name="username"></param>
        public static void IsPlayerConnected(string username) {
            //primeiro servidor world
            const byte worldN1 = 0;

            //cria a mensagem somente uma vez.
            var buffer = WorldNetwork.WorldServer[worldN1]?.CreateMessage();
            buffer.Write((short)PacketList.LS_WS_IsPlayerConnected);
            buffer.Write(username);

            for (var n = 0; n < Constant.MaxServer; n++) {
                WorldNetwork.WorldServer[n].SendData(buffer);
            }
        }

        /// <summary>
        /// Desconecta o usuário em outros servidores (world).
        /// </summary>
        /// <param name="username"></param>
        public static void DisconnectPlayer(PlayerData pData) {
            //primeiro servidor world
            const byte worldN1 = 0;

            //cria a mensagem somente uma vez.
            var buffer = WorldNetwork.WorldServer[worldN1]?.CreateMessage();
            buffer.Write((short)PacketList.LS_WS_DisconnectPlayer);
            buffer.Write(pData.Username);

            for (var n = 0; n < Constant.MaxServer; n++) {
                if (pData.WorldResult[n]) {
                    WorldNetwork.WorldServer[n].SendData(buffer);
                }               
            }
        }
    }
}

using System;
using System.Drawing;
using LoginServer.Common;
using LoginServer.Server;
using Lidgren.Network;
using Elysium.Logs;

namespace LoginServer.Network { 
    public static class ConnectPacket {
        /// <summary>
        /// Envia a identificação para o connect server.
        /// </summary>
        public static void ConnectionID() {
            var buffer = NetworkClient.CreateMessage(18);
            buffer.Write((short)PacketList.CS_ServerID);
            buffer.Write(Configuration.ID);
            buffer.Write("Login Server");
            NetworkClient.SendData(buffer);
        }

        /// <summary>
        /// Envia todos os dados do usuário para o world server que foi selecionado pelo cliente.
        /// </summary>
        /// <param name="pIndex"></param>
        /// <param name="worldIndex"></param>
        public static void PlayerLogin(PlayerData pData, int worldIndex) {
            LoginPacket.HexID(pData.Connection, pData.HexID);

            var buffer = NetworkClient.CreateMessage();
            buffer.Write((short)PacketList.LS_WS_PlayerLogin);
            buffer.Write(pData.HexID);
            buffer.Write(pData.Account);
            buffer.Write(pData.ID);
            buffer.Write(pData.LanguageID);
            buffer.Write(pData.AccessLevel);
            buffer.Write(pData.Cash);
            buffer.Write(pData.Pin);
            buffer.Write(pData.PinAttempt);
            buffer.Write(Configuration.Server[worldIndex].ID);

            //escreve a quantidade de serviços
            int[] servicesID = pData.Service.GetServicesID();
            buffer.Write(pData.Service.Count());

            //escreve cada serviço no buffer
            foreach (var id in servicesID)  buffer.Write(pData.Service.GetService(id));
            
            NetworkClient.SendData(buffer);

            Log.Write($"World Server {Configuration.Server[worldIndex].Name} Login Attempt: {pData.Account} {pData.IP}", Color.Black); 
        }

        /// <summary>
        /// Verifica se o usuário já está conectado em algum outro servidor.
        /// </summary>
        /// <param name="username"></param>
        public static void IsPlayerConnected(string username) {      
            var buffer = NetworkClient.CreateMessage();
            buffer.Write((short)PacketList.LS_WS_IsPlayerConnected);
            buffer.Write(username);
            NetworkClient.SendData(buffer);
        }

        /// <summary>
        /// Desconecta o usuário em outros servidores.
        /// </summary>
        /// <param name="username"></param>
        public static void DisconnectPlayer(string username) {
            var buffer = NetworkClient.CreateMessage();
            buffer.Write((short)PacketList.CS_DisconnectPlayer);
            buffer.Write(username);
            NetworkClient.SendData(buffer);
        }
    }
}
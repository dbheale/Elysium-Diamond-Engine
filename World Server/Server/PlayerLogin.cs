using WorldServer.MySQL;
using WorldServer.Network;
using Elysium;

namespace WorldServer.Server {
    public static class PlayerLogin {
        /// <summary>
        /// Carrega as informações do jogador.
        /// </summary>
        /// <param name="pData"></param>
        public static void Login(PlayerData pData) {
            //Carrega os personagens para apresentar ao cliente.                                             
            Character_DB.PreLoad(pData);
 
            Logs.Write($"PreLoad ID: {pData.AccountID} Account: {pData.Account}", System.Drawing.Color.Black);

            //Envia o PreLoad
            WorldPacket.PreLoad(pData);
            //Aceita a conexão
            WorldPacket.Message(pData.Connection, (int)PacketList.AcceptedConnection);
            //Muda de janela 
            WorldPacket.GameState(pData.HexID, GameState.Character); 
        }
    }
}

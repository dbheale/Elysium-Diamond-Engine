using System.Drawing;
using WorldServer.Database;
using WorldServer.Network;
using WorldServer.Common;
using WorldServer.Pin;
using WorldServer.WorldChat;
using Lidgren.Network;
using Elysium.Logs;

namespace WorldServer.Server {
    public static class PlayerLogin {
        /// <summary>
        /// Carrega as informações do usuário.
        /// </summary>
        /// <param name="pData"></param>
        public static void Login(PlayerData pData) {
            //Carrega os personagens para apresentar ao cliente                                        
            CharacterDB.PreLoad(pData);
 
            Log.Write($"PreLoad ID: {pData.AccountID} Account: {pData.Account}", Color.Black);

            //verifica se há exclusões
            CharacterFunction.CheckPendingDeletion(pData);

            //'avisa' o login que o usuario foi conectado
            LoginPacket.UpdateUserStatus(pData.AccountID, pData.Account);
            //Envia o PreLoad
            WorldPacket.PreLoad(pData);
            //Aceita a conexão
            WorldPacket.Message(pData.Connection, (short)PacketList.AcceptedConnection);
            //Muda de janela 
            WorldPacket.GameState(pData.HexID, GameState.Character); 
        }

        /// <summary>
        /// Inicia os preparativos e seleciona o servidor para o login.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="slot"></param>
        public static void StartGame(NetConnection connection, byte slot) {
            var pData = Authentication.FindByConnection(connection);

            //guarda o slot do personagem para uso posterior
            pData.CharSlot = slot;

            if (Configuration.Pin) {
                //se não há pin, envia o pedido de registro
                if (string.IsNullOrWhiteSpace(pData.Pin)) {
                    PinPacket.RegisterPin(pData.Connection);
                    return;
                }

                //se o pin não foi verificado, abre janela
                if (!pData.PinVerified) {
                    PinPacket.ShowPinWindow(pData.Connection, true);
                    return;
                }
            }

            //remove a exclusão do personagem quando pendente
            CharacterFunction.RemovePendingDeletion(pData);

            //envia msg para o connect server para obter os dados do servidor
            ConnectPacket.SelectGameServer(pData.AccountID, pData.Character[pData.CharSlot].RegionID);

            Log.Write($"{pData.Account} {pData.IP} login attempt region {pData.Character[pData.CharSlot].RegionID} ", Color.Black);
        }

        /// <summary>
        /// Continua com o processo de login e inicia operação de transferencia de dados para o gameserver.
        /// </summary>
        /// <param name="account"></param>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        public static void StartGame(NetIncomingMessage msg) {
            var accountID = msg.ReadInt32();
            var ip = msg.ReadString();
            var port = msg.ReadInt32();

            var pData = Authentication.FindByAccountID(accountID);

            //envia os dados do servidor e mostra a mensagem de espera.
            WorldPacket.GameServerData(pData.Connection, ip, port);
            WorldPacket.Message(pData.Connection, (short)PacketList.WS_CL_ShowMessageBox);

            //envia os dados de login para o game server
            GamePacket.Login(pData, pData.Character[pData.CharSlot].RegionID);
        }

        /// <summary>
        /// Realiza a entrada do usuário ao jogo carregando todos os dados.
        /// </summary>
        /// <param name="pData"></param>
        public static void EnterGame(PlayerData pData) {
            //limpa a memoria temporaria
            pData.Character = null;
   
            // Carrega os dados do personagem
            CharacterDB.Load(pData, (byte)pData.CharSlot);           

            //if (pData.GuildID > 0) GameGuild.Guild.UpdatePlayerStatus(pData.GuildID, pData.CharacterID, GuildMemberStatus.Online);
            // if (pData.GuildID > 0) WorldServerPacket.SendGuildInfo(pData);

            WorldPacket.SendCash(pData.Connection, pData.Cash);

            //Envia a mensagem do servidor.
            Chat.SendServerMessage(pData.Connection);
        }
    }
}
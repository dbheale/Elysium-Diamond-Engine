using System.Drawing;
using WorldServer.Server;
using WorldServer.Common;
using WorldServer.Network;
using Lidgren.Network;
using Elysium.Logs;

namespace WorldServer.Pin {
    public static class PinData {
        /// <summary>
        /// Inicia o processo de verificação do pin do client.
        /// </summary>
        /// <param name="hexID"></param>
        /// <param name="pin"></param>
        public static void VerifyPinState(NetConnection connection, NetIncomingMessage msg) {
            var pData = Authentication.FindByConnection(connection);
            var state = (PinState)msg.ReadByte();
            var pin = msg.ReadString();
            var pin_new = msg.ReadString();

            //cria o pin pelo primeiro acesso
            if (state == PinState.Initialize) {
                InitializePin(pData, pin);
            }

            //inicia o processo de verificação
            if (state == PinState.Login) {
                CheckPin(pData, pin);
            }

            //altera o pin do usuario
            if (state == PinState.Change) {
                ChangePin(pData, pin, pin_new);
            }
        }

        /// <summary>
        /// Verifica se o PIN está correto e garante o acesso.
        /// </summary>
        /// <param name="pData"></param>
        /// <param name="pin"></param>
        public static void CheckPin(PlayerData pData, string pin) {
            var pin_ = Hash.Compute(pin);
            var result = string.CompareOrdinal(pData.Pin, pin_);

            //se o pin estiver incorreto, envia mensagem de erro
            if (result != 0) {
                pData.PinAttempt++;

                //se passar o limite, bloqueia o usuário, volta para a tela de login e mostra a mensagem
                if (pData.PinAttempt >= 5) {
                    pData.PinAttempt = 0;

                    Log.Write($"Account {pData.Account} {pData.IP} blocked by invalid PIN", Color.Black);

                    LoginPacket.UpdateBanAccount(pData.AccountID, Configuration.PinBannedTime, "invalid pin");

                    WorldPacket.GameState(pData.HexID, GameState.Login);
                    WorldPacket.Message(pData.HexID, (short)PacketList.AccountBanned);
                }
                else {
                    PinPacket.IncorrectPin(pData.Connection, pData.PinAttempt);
                }

                //salva a tentativa de ban
                LoginPacket.UpdatePinAttempt(pData.AccountID, pData.PinAttempt);
                return;
            }

            //zera o contador quando o usuário insere o pin correto
            pData.PinAttempt = 0;
            //salva a tentativa
            LoginPacket.UpdatePinAttempt(pData.AccountID, pData.PinAttempt);

            pData.PinVerified = true;

            PinPacket.ShowPinWindow(pData.Connection, false);

            //prepara o jogador para entrar no jogo
            PlayerLogin.StartGame(pData.Connection, (byte)pData.CharSlot);
        }

        /// <summary>
        /// Define o PIN do usuário pelo primeiro acesso.
        /// </summary>
        /// <param name="pData"></param>
        /// <param name="pin"></param>
        public static void InitializePin(PlayerData pData, string pin) {
            pData.Pin = Hash.Compute(pin);
            pData.PinAttempt = 0;

            //salva a tentativa
            LoginPacket.UpdatePinAttempt(pData.AccountID, pData.PinAttempt);

            //salva o pin
            LoginPacket.UpdatePin(pData.AccountID, pData.Pin);

            WorldPacket.Message(pData.Connection, (short)PacketList.WS_CL_PinStatusOK);
        }

        /// <summary>
        /// Altera o PIN do usuário.
        /// </summary>
        /// <param name="pData"></param>
        /// <param name="pin"></param>
        /// <param name="new_pin"></param>
        public static void ChangePin(PlayerData pData, string pin, string new_pin) {
            var pin_ = Hash.Compute(pin);
            var result = string.CompareOrdinal(pData.Pin, pin_);

            //envia mensagem de erro e sai do método
            if (result != 0) {
                PinPacket.IncorrectPin(pData.Connection);
                return;
            }

            if (string.IsNullOrWhiteSpace(new_pin)) {
                PinPacket.RegisterPin(pData.Connection);
            }

            pData.Pin = Hash.Compute(new_pin);
            pData.PinAttempt = 0;

            LoginPacket.UpdatePinAttempt(pData.AccountID, pData.PinAttempt);

            LoginPacket.UpdatePin(pData.AccountID, pData.Pin);

            WorldPacket.Message(pData.Connection, (short)PacketList.WS_CL_PinStatusOK);
        }
    }
}
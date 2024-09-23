using Elysium_Diamond.Common;
using Elysium_Diamond.DirectX;
using Elysium_Diamond.EngineWindow;

namespace Elysium_Diamond.Network {
    public class Message {
        public static void Show(PacketList packet, short value = 0) {
            switch (packet) {
                case PacketList.Disconnect:
                    Configuration.Disconnected = true;
                    EngineMessageBox.Enabled = true;
                    EngineMessageBox.Show("Desconectado");

                    NetworkSocket.Disconnect(SocketEnum.LoginServer);
                    NetworkSocket.Disconnect(SocketEnum.WorldServer);
                    NetworkSocket.Disconnect(SocketEnum.GameServer);
                    break;

                case PacketList.LS_CL_AccountDisabled:
                    EngineMessageBox.Enabled = true;
                    EngineMessageBox.Show("Email não verificado");
                    break;

                case PacketList.LS_CL_InvalidNamePass:
                    EngineMessageBox.Enabled = true;
                    EngineMessageBox.Show("Nome ou senha incorretos");
                    break;

                case PacketList.LS_CL_Maintenance:
                    EngineMessageBox.Enabled = true;
                    EngineMessageBox.Show("Servidor em manutenção");
                    break;

                case PacketList.Error:
                    EngineMessageBox.Enabled = true;
                    EngineMessageBox.Show("Ocorreu um erro");
                    break;

                case PacketList.AccountBanned:
                    EngineMessageBox.Enabled = true;
                    EngineMessageBox.Show("Este usuário está banido");
                    break;

                case PacketList.LS_CL_AlreadyLoggedIn:
                    EngineMessageBox.Enabled = true;
                    EngineMessageBox.Show("Este usuário já está conectado");
                    break;

                case PacketList.AcceptedConnection:
                    EngineMessageBox.Enabled = true;
                    EngineMessageBox.Visible = false;
                    break;

                case PacketList.CantConnectNow:
                    EngineMessageBox.Enabled = true;
                    EngineMessageBox.Show("Você não pode conectar-se no momento");
                    break;

                case PacketList.InvalidVersion:
                    EngineMessageBox.Enabled = true;
                    EngineMessageBox.Show("Versão invalida");
                    break;

                case PacketList.WS_CL_CharacterDeleted:
                    if (EngineCore.GameState != 3) return;
                    EngineMessageBox.Enabled = true;
                    EngineMessageBox.Show("Personagem deletado");
                    break;

                case PacketList.WS_CL_CharNameInUse:
                    EngineMessageBox.Enabled = true;
                    EngineMessageBox.Show("Nome já está em uso");
                    break;

                case PacketList.WS_CL_CharacterCreationDisabled:
                    EngineMessageBox.Enabled = true;
                    EngineMessageBox.Show("Criação de personagens desativado");
                    break;

                case PacketList.WS_CL_CharacterDeleteDisabled:
                    EngineMessageBox.Enabled = true;
                    EngineMessageBox.Show("Exclusão de personagens desativado");
                    break;

                case PacketList.WS_CL_InvalidLevelToDelete:
                    EngineMessageBox.Enabled = true;
                    EngineMessageBox.Show("Limite de level para exclusão 1 ~ 50");
                    break;

                case PacketList.WS_CL_PinStatusOK:
                    EngineMessageBox.Enabled = true;
                    EngineMessageBox.Show("O pin foi salvo, digite novamente para confirmar");
                    WindowPin.ChangeState(PinState.Login);
                    break;

                case PacketList.WS_CL_InvalidPin:
                    EngineMessageBox.Enabled = true;
                    EngineMessageBox.Show("O pin atual está incorreto");
                    WindowPin.ChangeState(PinState.Change);
                    break;

                case PacketList.WS_CL_ShowMessageBox:
                    EngineMessageBox.Enabled = false;
                    EngineMessageBox.Show("Aguardando conexão");
                    break;

                case PacketList.InvalidCharacterName:
                    EngineMessageBox.Enabled = true;
                    EngineMessageBox.Show("The character name was not found");
                    WindowCash.WaitData = false;
                    break;


            }
        }
    }
}


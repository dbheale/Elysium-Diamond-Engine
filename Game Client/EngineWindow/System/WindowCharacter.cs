using System;
using Elysium_Diamond.Resource;
using Elysium_Diamond.Network;
using Elysium_Diamond.DirectX;
using Elysium_Diamond.GameClient;
using SharpDX;
using SharpDX.Direct3D9;
using Color = SharpDX.Color;

namespace Elysium_Diamond.EngineWindow {
    public class WindowCharacter {
        /// <summary>
        /// Limite de slots, botões e personagens.
        /// </summary>
        private const int MAX_OBJECT = 4;

        /// <summary>
        /// Imagem de (janela) fundo
        /// </summary>
        private static EngineObject background;

        /// <summary>
        /// Botões Usar, Novo, Deletar, Selecionar Servidor e Sair
        /// </summary>
        private static EngineButton[] button = new EngineButton[MAX_OBJECT];

        /// <summary>
        /// Imagem de fundo de personagem
        /// </summary>
        private static EngineObject[] charbackground = new EngineObject[MAX_OBJECT];

        /// <summary>
        /// Fundo selecionavel
        /// </summary>
        private static EngineObject[] selected_background = new EngineObject[MAX_OBJECT];

        /// <summary>
        /// Posição de todos os elementos.
        /// </summary>
        private static Point Position;

        /// <summary>
        /// Indice da janela selecionada.
        /// </summary>
        public static int SelectedIndex { get; set; } = 0;

        /// <summary>
        /// Informações dos personagens.
        /// </summary>
        public static PlayerSlotData[] Player = new PlayerSlotData[MAX_OBJECT];

        //##########
        //Cast Anim
        private static Texture[] cast = new Texture[20];
        private static int casTick, castFrameIndex;
        private static bool castEnabled = true;
        private static bool letContinue = false;
        //##########

        private static int tick_time;

        /// <summary>
        ///  Inicializa e define a configuração dos controles.
        /// </summary>
        public static void Initialize() {
            Position = new Point(208, 220);

            // Configuração imagem de fundo
            background = new EngineObject();
            background.Position = Position;
            background.Texture = EngineTexture.TextureFromFile($"{Common.Configuration.GamePath}\\Data\\Graphics\\win_char.png", 608, 288);
            background.Size = new Size2(608, 288);
            background.SourceRect = new Rectangle(0, 0, 608, 288);

            // Configuração imagem de fundo personagem
            for (int n = 0; n < MAX_OBJECT; n++) {
                charbackground[n] = new EngineObject();
                charbackground[n].Index = n;
                charbackground[n].Enabled = true;
                charbackground[n].Texture = EngineTexture.TextureFromFile($"{Common.Configuration.GamePath}\\Data\\Graphics\\selectchar_charback.png", 127, 134);
                charbackground[n].Size = new Size2(127, 134);
                charbackground[n].SourceRect = new Rectangle(0, 0, 127, 134);
                charbackground[n].MouseUp += Select_MouseUp;
                charbackground[n].BorderRect = new Rectangle(0, 0, 127, 134);
                charbackground[n].Position = new Point((Position.X + 49) + (n * 127), Position.Y + 70);

                selected_background[n] = new EngineObject();
                selected_background[n].Texture = EngineTexture.TextureFromFile(Common.Configuration.GamePath + @"\Data\Graphics\selectchar_selected.png", 127, 134);
                selected_background[n].Size = new Size2(127, 134);
                selected_background[n].SourceRect = new Rectangle(0, 0, 127, 134);
                selected_background[n].Position = new Point((Position.X + 49) + (n * 127), Position.Y + 70);
            }

            //ボタンの設定
            button[0] = new EngineButton("start", 128, 32);
            button[0].Position = new Point(Position.X + 135, Position.Y + 215);
            button[0].BorderRect = new Rectangle(20, 2, 86, 26);
            button[0].Size = new Size2(128, 32);
            button[0].SourceRect = new Rectangle(0, 0, 128, 32);
            button[0].MouseUp += Start_MouseUp;

            button[1] = new EngineButton("create", 128, 32);
            button[1].Position = new Point(Position.X + 242, Position.Y + 215);
            button[1].BorderRect = new Rectangle(20, 2, 86, 26);
            button[1].Size = new Size2(128, 32);
            button[1].SourceRect = new Rectangle(0, 0, 128, 32);
            button[1].MouseUp += Create_MouseUp;

            button[2] = new EngineButton("delete", 128, 32);
            button[2].Position = new Point(Position.X + 349, Position.Y + 215);
            button[2].BorderRect = new Rectangle(20, 2, 86, 26);
            button[2].Size = new Size2(128, 32);
            button[2].SourceRect = new Rectangle(0, 0, 128, 32);
            button[2].MouseUp += Delete_MouseUp;

            button[3] = new EngineButton("server", 128, 32);
            button[3].Position = new Point(Position.X + 240, Position.Y + 30);
            button[3].BorderRect = new Rectangle(20, 2, 86, 26);
            button[3].Size = new Size2(128, 32);
            button[3].SourceRect = new Rectangle(0, 0, 128, 32);
            button[3].MouseUp += Server_MouseUp;

            //Configuração personagens
            for (int n = 0; n < MAX_OBJECT; n++) {
                Player[n] = new PlayerSlotData();
                Player[n].Name = string.Empty;
                Player[n].Class = string.Empty;
                Player[n].Sprite = 0;
                Player[n].Level = 0;
                Player[n].Transparency = 255;
            }


            //Carrega as imagens da animação
            for (int n = 0; n < 20; n++) {
                cast[n] = EngineTexture.TextureFromFile(Common.Configuration.GamePath + @"\Data\Cast_2\" + (n + 1) + ".png", 196, 196);
            }
        }

        /// <summary>
        /// Desenha os controles.
        /// </summary>
        public static void Draw() {
            //Imagem de (janela) fundo
            background.Draw();

            //Desenha a janela de fundo do personagem.
            for (int n = 0; n < MAX_OBJECT; n++) { charbackground[n].Execute(); } //chama o método do mouse e draw. 

            //Desenha o objeto selecionado
            selected_background[SelectedIndex].Draw();

            //Desenha a animação de fundo do personagem
            DrawCastAnim(SelectedIndex * 127);

            //Desenha o personagem
            for (int n = 0; n < MAX_OBJECT; n++) { DrawPlayer(n, n * 127); }

            //Botões
            for (int n = 0; n < MAX_OBJECT; n++) { button[n].Draw(); }

            TickTime();
        }

        /// <summary>
        /// Desenha o personagem.
        /// </summary>
        /// <param name="index">índice de slots</param>
        /// <param name="x">coordenada</param>
        private static void DrawPlayer(int index, int x) {
            if (string.IsNullOrEmpty(Player[index].Name)) { return; }
            if (Player[index].Sprite <= 0) { return; }

            EngineCore.SpriteDevice.Begin(SpriteFlags.AlphaBlend);
            EngineCore.SpriteDevice.Draw(EngineTexture.FindTextureByID(Player[index].Sprite, EngineTextureType.Sprites), new ColorBGRA(255, 255, 255, Player[index].Transparency), new Rectangle(128, 0, 32, 32), new Vector3(0, 0, 0), new Vector3(Position.X + 94 + x, Position.Y + 110, 0));
            EngineCore.SpriteDevice.End();
            //   
            if (Player[index].Pending) {
                EngineFont.DrawText(Player[index].TimeString, new Size2(127, 134), new Point(Position.X + 49 + x, Position.Y + 85), Color.White, EngineFontStyle.Italic, FontDrawFlags.Center);
                //   if (Player[index].Time > 0) EngineFont.DrawText("Exclusão " + Player[index].Time + " Min.", new Size2(127, 134), new Point(Position.X + 49 + x, Position.Y + 85), Color.White, EngineFontStyle.Italic, FontDrawFlags.Center);
                //    if (Player[index].Time == 0) EngineFont.DrawText("Exclusão " + Player[index].TickTime + " Sec.", new Size2(127, 134), new Point(Position.X + 49 + x, Position.Y + 85), Color.White, EngineFontStyle.Italic, FontDrawFlags.Center);
            }

            EngineFont.DrawText(Player[index].Name, new Size2(127, 134), new Point(Position.X + 49 + x, Position.Y + 30), Color.DarkViolet, EngineFontStyle.Regular, FontDrawFlags.Center);
            EngineFont.DrawText(Player[index].Class, new Size2(127, 134), new Point(Position.X + 49 + x, Position.Y + 100), Color.Coral, EngineFontStyle.Regular, FontDrawFlags.Center);
            EngineFont.DrawText("Lv. " + Player[index].Level, new Size2(127, 134), new Point(Position.X + 49 + x, Position.Y + 120), Color.RoyalBlue, EngineFontStyle.Regular, FontDrawFlags.Center);
        }

        /// <summary>
        /// Seleciona o personagem.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Select_MouseUp(object sender, EngineEventArgs e) {
            if (EngineMessageBox.Visible) { return; }
            if (EngineInputBox.Visible) { return; }
            if (WindowPin.Visible) return;

            SelectedIndex = ((EngineObject)sender).Index;
            castFrameIndex = 0;
        }

        /// <summary>
        /// Inicia o jogo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void Start_MouseUp(object sender, EngineEventArgs e) {
            if (EngineMessageBox.Visible) { return; }
            if (EngineInputBox.Visible) { return; }
            if (WindowPin.Visible) return;

            EngineMultimedia.Play(EngineSoundEnum.Click);

            if (Player[SelectedIndex].Name.Length <= 0) { return; }

            WorldPacket.StartGame((byte)SelectedIndex);
        }

        /// <summary>
        /// Cria um novo personagem.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void Create_MouseUp(object sender, EngineEventArgs e) {
            if (EngineMessageBox.Visible) { return; }
            if (EngineInputBox.Visible) { return; }
            if (WindowPin.Visible) return;

            if (!string.IsNullOrEmpty(Player[SelectedIndex].Name)) { return; }
            if (Player[SelectedIndex].Sprite > 0) { return; }

            EngineMultimedia.Play(EngineSoundEnum.Click);
            EngineCore.GameState = 4;
        }

        /// <summary>
        /// Deleta um personagem.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void Delete_MouseUp(object sender, EngineEventArgs e) {
            if (EngineMessageBox.Visible) { return; }
            if (EngineInputBox.Visible) { return; }
            if (WindowPin.Visible) return;

            EngineMultimedia.Play(EngineSoundEnum.Click);

            if (string.IsNullOrEmpty(Player[SelectedIndex].Name)) { return; }

            EngineInputBox.Show("Digite deletar para continuar com a exclusão", EngineInputBoxAction.Delete);
        }

        /// <summary>
        /// Volta para a tela de servidores.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void Server_MouseUp(object sender, EngineEventArgs e) {
            if (EngineMessageBox.Visible) { return; }
            if (EngineInputBox.Visible) { return; }
            if (WindowPin.Visible) return;

            EngineMultimedia.Play(EngineSoundEnum.Click);

            //Configuração personagens
            for (int n = 0; n < MAX_OBJECT; n++) {
                Player[n].Name = "";
                Player[n].Class = "";
                Player[n].Sprite = 0;
                Player[n].Level = 0;
                Player[n].Transparency = 255;
            }

            EngineCore.GameState = 2;
        }

        //#### remover ###
        private static void DrawCastAnim(int x) {
            if (castEnabled == false) { return; }
            if (Environment.TickCount >= casTick + 50) {
                casTick = Environment.TickCount;
                castFrameIndex++;

                if (castFrameIndex > 13) {
                    if (letContinue == false) { castFrameIndex = 8; }
                    else {
                        if (castFrameIndex > 19) {
                            castFrameIndex = 0;
                            castEnabled = false;
                        }
                    }
                }
            }

            EngineCore.SpriteDevice.Begin(SpriteFlags.AlphaBlend);
            EngineCore.SpriteDevice.Draw(cast[castFrameIndex], Color.White, new Rectangle(0, 0, 192, 192), new Vector3(0, 0, 0), new Vector3(Position.X + 14 + x, Position.Y + 30, 0));
            EngineCore.SpriteDevice.End();
        }

        private static void TickTime() {
            if (Environment.TickCount >= tick_time + 1000) {
                tick_time = Environment.TickCount;

                for (var n = 0; n < 4; n++) {
                    if (Player[n].Pending) {

                        Player[n].Time = Player[n].Time.Subtract(new TimeSpan(0, 0, 1));

                        if (Player[n].Time.Hours > 0) {
                            Player[n].TimeString = "Exclusão " + Player[n].Time.Hours + " Hora.";
                        }
                        else if (Player[n].Time.Minutes > 0) {
                            Player[n].TimeString = "Exclusão " + Player[n].Time.Minutes + " Min.";
                        }
                        else if (Player[n].Time.Seconds > 0) {
                            Player[n].TimeString = "Exclusão " + Player[n].Time.Seconds + " Sec.";
                        }
                        else if (Player[n].Time.TotalSeconds <= 0) {
                            Player[n].TimeString = "Processando";
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Limpa todos os dados dos personagens.
        /// </summary>
        public static void Clear() {
            for (var index = 0; index < MAX_OBJECT; index++) Player[index].Clear();
        }
    }
}
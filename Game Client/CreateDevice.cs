using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Elysium_Diamond.DirectX;
using Elysium_Diamond.Network;
using Elysium_Diamond.EngineWindow;
using Elysium_Diamond.Resource;
using Microsoft.VisualBasic;

using System.IO;
using System.Security.Cryptography;

namespace Elysium_Diamond {
    public partial class CreateDevice : Form {
        public string ImeModeIso = string.Empty;
        public bool ImeModeOn = false;
        
        private const int IACE_CHILDREN = 0x0001;
        private const int IACE_DEFAULT = 0x0010;
        private const int IACE_IGNORENOCONTEXT = 0x0020;

        private const int GCS_COMPATTR = 0x10;
        private const int GCS_ = 0x20;
        private const int GCS_COMPREADATTR = 0x2;
        private const int GCS_COMPREADCLAUSE = 0x4;
        private const int GCS_COMPREADSTR = 0x1;
        private const int GCS_COMPSTR = 0x8;
        private const int GCS_CURSORPOS = 0x80;
        private const int GCS_DELTASTART = 0x100;
        private const int GCS_RESULTCLAUSE = 0x1000;
        private const int GCS_RESULTREADCLAUSE = 0x400;
        private const int GCS_RESULTREADSTR = 0x200;
        private const int GCS_RESULTSTR = 0x800;

        private const int IMN_CLOSESTATUSWINDOW = 0x0001;
        private const int IMN_OPENSTATUSWINDOW = 0x0002;
        private const int IMN_CHANGECANDIDATE = 0x0003;
        private const int IMN_CLOSECANDIDATE = 0x0004;
        private const int IMN_SETCONVERSIONMODE = 0x0005;
        private const int IMN_SETSENTENCEMODE = 0x0006;
        private const int IMN_SETOPENSTATUS = 0x0008;
        private const int IMN_SETCANDIDATEPOS = 0x0009;
        private const int IMN_SETCOMPOSITIONFONT = 0x000a;
        private const int IMN_SETCOMPOSITIONWINDOW = 0x000b;
        private const int IMN_SETSTATUSWINDOWPOS = 0x000c;
        private const int IMN_GUIDELINE = 0x000d;
        private const int IMN_PRIVATE = 0x000e;

        private const int WM_CHAR = 0x0102;
        private const int WM_IME_SETCONTEXT = 0x0281;
        private const int WM_IME_NOTIFY = 0x0282;
        private const int WM_IME_STARTCOMPOSITION = 0x010d;
        private const int WM_IME_ENDCOMPOSITION = 0x010e;
        private const int WM_IME_COMPOSITION = 0x010f;

        private const int CFS_POINT = 0x0002;


        [StructLayout(LayoutKind.Sequential)]
        public struct RECT {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct POINTAPI {
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct COMPOSITIONFORM {
            public uint dwStyle;
            public POINTAPI ptCurrentPos;
            public RECT rcArea;
        }

        //Imm系メソッド 

        #region WINAPI

        [DllImport("user32")]
        static extern IntPtr GetKeyboardLayout(uint idThread);

        [DllImport("imm32")]
        static extern IntPtr ImmAssociateContext(IntPtr hWnd, IntPtr hIMC);

        [DllImport("imm32")]
        static extern bool ImmAssociateContextEx(IntPtr hWnd, IntPtr hIMC, uint dwFlags);

        [DllImport("imm32")]
        static extern IntPtr ImmGetContext(IntPtr hWnd);

        [DllImport("imm32")]
        static extern IntPtr ImmReleaseContext(IntPtr hWnd, IntPtr hIMC);

        [DllImport("imm32", CharSet = CharSet.Unicode)]
        static extern int ImmGetCompositionString(IntPtr hIMC, uint dwIndex, byte[] lpBuf, uint dwBufLen);

        [DllImport("imm32")]
        static extern int ImmGetCandidateList(IntPtr hIMC, uint dwIndex, sbyte[] buf, uint dwBufLen);

        [DllImport("imm32")]
        static extern int ImmGetOpenStatus(IntPtr hIMC);

        [DllImport("imm32")]
        static extern uint ImmGetDescriptionW(IntPtr hKL, byte[] lpszDescription, uint uBufLen);

        [DllImport("imm32")]
        static extern int ImmGetConversionStatus(IntPtr hIMC, out uint lpfdwConversion, out uint lpfdwSentence);

        [DllImport("imm32")]
        static extern void ImmSetCompositionWindow(IntPtr hIMC, ref COMPOSITIONFORM lpCompForm);

        [DllImport("imm32")]
        static extern void ImmSetOpenStatus(IntPtr hIMC, bool fOpen);

        #endregion

        public void SetImeContext(int x, int y) {
            IntPtr hIMC = ImmGetContext(this.Handle);

            if (hIMC == IntPtr.Zero) return;

            try {
                // ウィンドウセット 
                COMPOSITIONFORM form = new COMPOSITIONFORM();
                form.dwStyle = CFS_POINT;
                form.ptCurrentPos.x = x; // MEMO:X位置設定 
                form.ptCurrentPos.y = y;// MEMO:Y位置設定 
                ImmSetCompositionWindow(hIMC, ref form);
            }
            finally {
                //   ImmReleaseContext(this.Handle, hIMC);
            }
        }

        IntPtr m_hImc;
        protected override void WndProc(ref System.Windows.Forms.Message m) {
            switch (m.Msg) {
                case WM_IME_SETCONTEXT:
                     if (m.WParam.ToInt32() == 1) {
                         ImmAssociateContext(this.Handle, m_hImc);
                    }

                    break;
                case WM_IME_NOTIFY:
                    //    if (m.WParam.ToInt32() == (int)IMN.SETOPENSTATUS && OpenStatusChanged != null)
                   // OpenStatusChanged?.Invoke(this, EventArgs.Empty);
                    break;
                case WM_IME_STARTCOMPOSITION:
                    // 入力コンテキストのセット 
                    if (EngineCore.GameState == 1) {
                        if (WindowLogin.textbox[0].CursorEnabled) {
                            ImmSetOpenStatus(m_hImc, true);
                            SetImeContext(WindowLogin.textbox[0].TextPositionX, WindowLogin.textbox[0].TextPositionY);
                        }
                        else {
                            ImmSetOpenStatus(m_hImc, false);
                         //   SetImeContext(WindowLogin.textbox[1].TextPositionX, WindowLogin.textbox[0].TextPositionY);
                        }                       
                    }

                    break;
                case WM_IME_ENDCOMPOSITION:
                    IntPtr handle = ImmGetContext(this.Handle);

                    if (handle == IntPtr.Zero) { return; }

                    var text = string.Empty;
                 
                    var strLen = ImmGetCompositionString(m_hImc, GCS_RESULTSTR, null, 0);

                    if (strLen > 0) {
                        byte[] buffer = new byte[strLen];
                        ImmGetCompositionString(m_hImc, GCS_RESULTSTR, buffer, (uint)strLen);
                        text = Encoding.Unicode.GetString(buffer);
                        WindowLogin.textbox[0].Text += text;
                    }

                    ImmReleaseContext(handle, m_hImc);

                    break;
                case WM_IME_COMPOSITION:

                    //CompositionChanged?.Invoke(this, EventArgs.Empty);
                    break;
                case WM_CHAR:
                    var ea = new KeyPressEventArgs((char)m.WParam.ToInt32());
                    Device_KeyPress(this, ea);
                    break;
            }

            base.WndProc(ref m);
        }

        #region Peek Message

        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool PeekMessage(out PeekMessageStruct msg, IntPtr hWnd, uint messageFilterMin, uint messageFilterMax, uint flags);

        /// <summary>Windows Message</summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct PeekMessageStruct {
            public IntPtr hWnd;
            public IntPtr msg;
            public IntPtr wParam;
            public IntPtr lParam;
            public uint time;
            public System.Drawing.Point p;
        }

        public void OnApplicationIdle(object sender, EventArgs e) {
            while (this.AppStillIdle) {
                EngineCore.Update();
                EngineCore.Render();
            }

            if (!EngineCore.GameRunning) { EngineCore.Exit(); }
        }

        private bool AppStillIdle {
            get {
                PeekMessageStruct msg;
                return !PeekMessage(out msg, IntPtr.Zero, 0, 0, 0);
            }
        }

        #endregion

        public CreateDevice() {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, false);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, false);
            this.SetStyle(ControlStyles.Opaque, true);
        }

        private void CreateDevice_MouseMove(object sender, MouseEventArgs e) {
            EngineCore.MousePosition = new SharpDX.Point(this.PointToClient(MousePosition).X, this.PointToClient(MousePosition).Y);
        }

        private void CreateDevice_MouseUp(object sender, MouseEventArgs e) {
            EngineCore.MouseDown = false;
        }

        private void CreateDevice_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) { EngineCore.MouseDown = true; }
        }

        private void CreateDevice_KeyDown(object sender, KeyEventArgs e) {
            // if (e.KeyCode == Keys.J) { NetworkPacket.CreateGuild("銀魂"); }

            //  if (e.KeyCode == Keys.W) { GameCharacter.DirUp = true; GameCharacter.DirDown = false; GameCharacter.DirLeft = false; GameCharacter.DirRight = false; }
            //    if (e.KeyCode == Keys.S) { GameCharacter.DirUp = false; GameCharacter.DirDown = true; GameCharacter.DirLeft = false; GameCharacter.DirRight = false; }
            //    if (e.KeyCode == Keys.A) { GameCharacter.DirUp = false; GameCharacter.DirDown = false; GameCharacter.DirLeft = true; GameCharacter.DirRight = false; }
            //     if (e.KeyCode == Keys.D) { GameCharacter.DirUp = false; GameCharacter.DirDown = false; GameCharacter.DirLeft = false; GameCharacter.DirRight = true; }

            if (EngineCore.GameState == 6) {
                if (e.KeyCode == Keys.C) {
                    if (WindowCharacterStatus.Visible) {
                        WindowCharacterStatus.Visible = false;
                    }
                    else {
                        WindowCharacterStatus.Visible = true;
                    }
                }

                if (e.KeyCode == Keys.Escape) {
                    if (WindowOption.Visible) {
                        WindowOption.Visible = false;
                    }
                    else {
                        WindowOption.Visible = true;
                    }
                }

                //      if (WindowGuild.GuildName.CompareTo(string.Empty) == 0) { return; }
                //
                //       if (e.KeyCode == Keys.G) {
                //     if (WindowGuild.Visible) {
                //        WindowGuild.Visible = false;
                //       }
                //      else {
                //  WindowGuild.Visible = true;
                //    }//
                //  }    
            }
        }

        private void CreateDevice_Load(object sender, EventArgs e) {
            m_hImc = ImmGetContext(this.Handle);

            var md5 = MD5.Create();

            Common.Configuration.ClientSerial = BitConverter.ToString(md5.ComputeHash(File.ReadAllBytes("Elysium Diamond.exe")));
        }

        private void Device_KeyPress(object sender, KeyPressEventArgs e) {
            #region GameState 1
            if (EngineCore.GameState == 1) {
                if (e.KeyChar == Convert.ToChar(Keys.Enter)) {
                    WindowLogin.Login();
                }

                if (e.KeyChar == Convert.ToChar(Keys.Tab)) {
                    if (WindowLogin.textbox[0].CursorEnabled == true) {
                        if (WindowLogin.textbox[0].Enabled == false) return;
                        WindowLogin.textbox[0].CursorEnabled = false;
                        WindowLogin.textbox[1].CursorEnabled = true;
                        WindowLogin.textbox[1].CursorState = 0;
                    }
                    else {
                        if (WindowLogin.textbox[1].Enabled == false) return;
                        WindowLogin.textbox[0].CursorEnabled = true;
                        WindowLogin.textbox[1].CursorEnabled = false;
                        WindowLogin.textbox[0].CursorState = 0;
                    }

                    return;
                }


                if (WindowLogin.textbox[0].CursorEnabled == true) {
                    if (WindowLogin.textbox[0].Enabled == false) { return; }

                    //if (char.IsLetterOrDigit(e.KeyChar) || char.(e.KeyChar))

                    if (Convert.ToInt32(e.KeyChar) == 8) { if (WindowLogin.textbox[0].Text.Length > 0) { WindowLogin.textbox[0].RemoveText(); } }


                    if (char.IsLetterOrDigit(e.KeyChar)) {
                        if (WindowLogin.textbox[0].Text.Length <= 27) {
                            //retorna se o ime estiver ativado

                            if (ImeModeOn) { return; }
                            WindowLogin.textbox[0].AddText(e.KeyChar);
                        }
                    }
                }


                if (WindowLogin.textbox[1].CursorEnabled == true) {
                    if (WindowLogin.textbox[1].Enabled == false) return;

                    if (Convert.ToInt32(e.KeyChar) == 8) { if (WindowLogin.textbox[1].Text.Length > 0) { WindowLogin.textbox[1].RemoveText(); } }

                    if (char.IsLetterOrDigit(e.KeyChar)) {
                        if (WindowLogin.textbox[1].Text.Length <= 27) {
                            if (ImeModeOn) { return; }
                            WindowLogin.textbox[1].AddText(e.KeyChar);
                        }
                    }
                }

                return;
            }
            #endregion

            #region GameState 3
            if (EngineCore.GameState == 3) {
                if (!EngineInputBox.Visible) { return; }

                if (EngineInputBox.TextBox.CursorEnabled == true) {
                    if (EngineInputBox.TextBox.Enabled == false) return;

                    if (Convert.ToInt32(e.KeyChar) == 8) { if (EngineInputBox.TextBox.Text.Length > 0) { EngineInputBox.TextBox.RemoveText(); } }

                    if (ImeModeOn) { return; }
                    if (char.IsDigit(e.KeyChar) || char.IsLetter(e.KeyChar)) { if (EngineInputBox.TextBox.Text.Length <= 12) { EngineInputBox.TextBox.AddText(e.KeyChar); } }

                }

                return;
            }
            #endregion

            #region GameState 4
            if (EngineCore.GameState == 4) {
                if (WindowNewCharacter.textbox.CursorEnabled == true) {
                    if (WindowNewCharacter.textbox.Enabled == false) return;

                    if (Convert.ToInt32(e.KeyChar) == 8) { if (WindowNewCharacter.textbox.Text.Length > 0) { WindowNewCharacter.textbox.RemoveText(); } }

                    if (ImeModeOn) { return; }
                    if (char.IsDigit(e.KeyChar) || char.IsLetter(e.KeyChar)) { if (WindowNewCharacter.textbox.Text.Length <= 12) { WindowNewCharacter.textbox.AddText(e.KeyChar); } }
                }

                return;
            }
            #endregion

            #region GameState 6
            if (EngineCore.GameState == 6) {

                if (e.KeyChar == 13) {
                    if (WindowChat.textbox.CursorEnabled) {
                        //envia o texto
                        if (WindowChat.textbox.Text.Length > 0)
                            WorldPacket.GlobalChat(WindowChat.textbox.Text);

                        //limpa o texto e fecha
                        WindowChat.textbox.Text = string.Empty;
                        WindowChat.textbox.CursorEnabled = false;
                    }else {
                        WindowChat.textbox.CursorEnabled = true;
                    }
                }

                if (WindowChat.textbox.CursorEnabled == true) {
                    if (Convert.ToInt32(e.KeyChar) == 8) {
                        if (WindowChat.textbox.Text.Length > 0) { WindowChat.textbox.RemoveText(); }
                        return;
                    }

                    if (ImeModeOn) { return; }
                    if (WindowChat.textbox.Text.Length <= 30) { WindowChat.textbox.AddText(e.KeyChar); } }

            }
            #endregion
        }

        private void CreateDevice_FormClosing(object sender, FormClosingEventArgs e) {
            e.Cancel = true;
         
            ImmReleaseContext(this.Handle, m_hImc);
            EngineCore.GameRunning = false;
            e.Cancel = false;
        }

        private void CreateDevice_InputLanguageChanged(object sender, InputLanguageChangedEventArgs e) {
            ImeModeIso = e.Culture.TwoLetterISOLanguageName;

            if (ImeModeIso == "en" | ImeModeIso == "pt") {
                ImeModeOn = false;
            }
            else {
                ImeModeOn = true;
            }


        //    ImmCreateContext();

            // Get IMC Handle
            /*  IME.imcHandle = IME.ImmGetContext(this.Handle);

              // Get language and layout details
              keys.languageFullName = e.InputLanguage.Culture.EnglishName;
              keys.languageShortName = e.InputLanguage.Culture.TwoLetterISOLanguageName;
              keys.layoutID = e.InputLanguage.Culture.KeyboardLayoutId;

              // Get current Conversion and Sentence Modes into IME.current*
              IME.ImmGetConversionStatus(IME.imcHandle, ref IME.currentConversionMode, ref IME.currentSentenceMode);

              if (IME.currentConversionMode == 0 && keys.languageShortName == "ja") {
                  IME.currentConversionMode = (int)IME.ConversionMode.IME_CMODE_NATIVE;
                  IME.currentSentenceMode = (int)IME.SentenceMode.IME_SMODE_AUTOMATIC;

                  IME.ImmSetConversionStatus(IME.imcHandle, (int)IME.ConversionMode.IME_CMODE_NATIVE | (int)IME.ConversionMode.IME_CMODE_FULLSHAPE, (int)IME.SentenceMode.IME_SMODE_AUTOMATIC);

              }

              if (IME.currentConversionMode != 0 && keys.languageShortName == "en") {
                  IME.currentConversionMode = 0;
                  IME.currentSentenceMode = (int)IME.SentenceMode.IME_SMODE_NONE;

                  IME.ImmSetConversionStatus(IME.imcHandle, (int)IME.ConversionMode.IME_CMODE_ALPHANUMERIC, (int)IME.SentenceMode.IME_SMODE_NONE);

              }

              // Release IMC Handle
              IME.ImmReleaseContext(this.Handle, IME.imcHandle);

              base.OnInputLanguageChanged(e);
               */
        }

        private void CreateDevice_ImeModeChanged(object sender, EventArgs e) {
        }
    }
}


/*
 *         public string CurrentCompStr(IntPtr handle) {
            int readType = GCS_COMPSTR;

            IntPtr hIMC = ImmGetContext(handle);
            try {
                int strLen = ImmGetCompositionStringW(hIMC, readType, null, 0);

                if (strLen > 0) {
                    byte[] buffer = new byte[strLen];

                    ImmGetCompositionStringW(hIMC, readType, buffer, strLen);

                    return Encoding.Unicode.GetString(buffer);

                } else {
                    return string.Empty;
                }
            } finally {
                ImmReleaseContext(handle, hIMC);
            }
        }
    }
 */
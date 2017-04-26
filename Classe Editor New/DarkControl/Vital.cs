using System;
using System.Windows.Forms;
using DarkUI.Docking;
using Classe_Editor.ClasseData;

namespace Classe_Editor.DarkControl {
    public partial class Vital : DarkToolWindow {
        /// <summary>
        /// Indica se abre as classes ou incrementos.
        /// </summary>
        public bool IsClasseMode { get; set; } = true;

        public Vital() {
            InitializeComponent();

            DockArea = DarkDockArea.Document;
            Dock = DockStyle.Fill;

            txt_hp.KeyPress += ControlEvent.TextBox_KeyPress;
            txt_mp.KeyPress += ControlEvent.TextBox_KeyPress;
            txt_sp.KeyPress += ControlEvent.TextBox_KeyPress;
            txt_regen_hp.KeyPress += ControlEvent.TextBox_KeyPress;
            txt_regen_mp.KeyPress += ControlEvent.TextBox_KeyPress;
            txt_regen_sp.KeyPress += ControlEvent.TextBox_KeyPress;
        }
        /// <summary>
        /// Verifica os campos e adiciona os dados.
        /// </summary>
        /// <param name="cData"></param>
        public void FillClasseData(Classe cData) {
            if (IsClasseMode) { ControlEvent.VerifyTextBox(Controls); }

            cData.HP = txt_hp.Text.Trim();
            cData.MP = txt_mp.Text.Trim();
            cData.SP = txt_sp.Text.Trim();
            cData.RegenHP = txt_regen_hp.Text.Trim();
            cData.RegenMP = txt_regen_mp.Text.Trim();
            cData.RegenSP = txt_regen_sp.Text.Trim();
        }

        /// <summary>
        /// Preenche o textbox com os dados de classe.
        /// </summary>
        /// <param name="cData"></param>
        public void FillTextbox(Classe cData) {
            txt_hp.Text = cData.HP.ToString();
            txt_mp.Text = cData.MP.ToString();
            txt_sp.Text = cData.SP.ToString();
            txt_regen_hp.Text = cData.RegenHP.ToString();
            txt_regen_mp.Text = cData.RegenMP.ToString();
            txt_regen_sp.Text = cData.RegenSP.ToString();
        }

        public void Clear() {
            txt_hp.Text = "0";
            txt_mp.Text = "0";
            txt_sp.Text = "0";
            txt_regen_hp.Text = "0";
            txt_regen_mp.Text = "0";
            txt_regen_sp.Text = "0";
        }
    }
}

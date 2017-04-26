using System;
using System.Windows.Forms;
using DarkUI.Docking;
using Classe_Editor.ClasseData;

namespace Classe_Editor.DarkControl {
    public partial class Resist : DarkToolWindow {
        /// <summary>
        /// Indica se abre as classes ou incrementos.
        /// </summary>
        public bool IsClasseMode { get; set; } = true;

        public Resist() {
            InitializeComponent();

            DockArea = DarkDockArea.Document;
            Dock = DockStyle.Fill;

            txt_stun.KeyPress += ControlEvent.TextBox_KeyPress;
            txt_silence.KeyPress += ControlEvent.TextBox_KeyPress;
            txt_blind.KeyPress += ControlEvent.TextBox_KeyPress;
            txt_paralysis.KeyPress += ControlEvent.TextBox_KeyPress;
            txt_critical_rate.KeyPress += ControlEvent.TextBox_KeyPress;
            txt_critical_dmg.KeyPress += ControlEvent.TextBox_KeyPress;
            txt_magical_rate.KeyPress += ControlEvent.TextBox_KeyPress;
            txt_magical_dmg.KeyPress += ControlEvent.TextBox_KeyPress;
        }

        /// <summary>
        /// Verifica os campos e adiciona os dados.
        /// </summary>
        /// <param name="cData"></param>
        public void FillClasseData(Classe cData) {
            if (IsClasseMode) { ControlEvent.VerifyTextBox(Controls); }

            cData.ResistStun = txt_stun.Text.Trim();
            cData.ResistSilence = txt_silence.Text.Trim();
            cData.ResistBlind = txt_blind.Text.Trim();
            cData.ResistParalysis = txt_paralysis.Text.Trim();
            cData.ResistCriticalRate = txt_critical_rate.Text.Trim();
            cData.ResistCriticalDamage = txt_critical_dmg.Text.Trim();
            cData.ResistMagicCriticalRate = txt_magical_rate.Text.Trim();
            cData.ResistMagicCriticalDamage = txt_magical_dmg.Text.Trim();
        }

        /// <summary>
        /// Preenche o textbox com os dados de classe.
        /// </summary>
        /// <param name="cData"></param>
        public void FillTextbox(Classe cData) {
            txt_stun.Text = cData.ResistStun.ToString();
            txt_silence.Text = cData.ResistSilence.ToString();
            txt_blind.Text = cData.ResistBlind.ToString();
            txt_paralysis.Text = cData.ResistParalysis.ToString();
            txt_critical_rate.Text = cData.ResistCriticalRate.ToString();
            txt_critical_dmg.Text = cData.ResistCriticalDamage.ToString();
            txt_magical_rate.Text = cData.ResistMagicCriticalRate.ToString();
            txt_magical_dmg.Text = cData.ResistMagicCriticalDamage.ToString();
        }

        public void Clear() {
            txt_stun.Text = "0";
            txt_silence.Text = "0";
            txt_blind.Text = "0";
            txt_paralysis.Text = "0";
            txt_critical_rate.Text = "0";
            txt_critical_dmg.Text = "0";
            txt_magical_rate.Text = "0";
            txt_magical_dmg.Text = "0";
        }
    }
}

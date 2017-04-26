using System;
using System.Windows.Forms;
using DarkUI.Docking;
using Classe_Editor.ClasseData;

namespace Classe_Editor.DarkControl {
    public partial class Magic : DarkToolWindow {
        /// <summary>
        /// Indica se abre as classes ou incrementos.
        /// </summary>
        public bool IsClasseMode { get; set; } = true;

        public Magic() {
            InitializeComponent();

            DockArea = DarkDockArea.Document;
            Dock = DockStyle.Fill;

            txt_attack.KeyPress += ControlEvent.TextBox_KeyPress;
            txt_accuracy.KeyPress += ControlEvent.TextBox_KeyPress;
            txt_defense.KeyPress += ControlEvent.TextBox_KeyPress;
            txt_resist.KeyPress += ControlEvent.TextBox_KeyPress;
            txt_rate.KeyPress += ControlEvent.TextBox_KeyPress;
            txt_critical.KeyPress += ControlEvent.TextBox_KeyPress;
        }

        /// <summary>
        /// Verifica os campos e adiciona os dados.
        /// </summary>
        /// <param name="cData"></param>
        public void FillClasseData(Classe cData) {
            if (IsClasseMode) { ControlEvent.VerifyTextBox(Controls); }

            cData.MagicAttack = txt_attack.Text.Trim();
            cData.MagicAccuracy = txt_accuracy.Text.Trim();
            cData.MagicDefense = txt_defense.Text.Trim();
            cData.MagicResist = txt_resist.Text.Trim();
            cData.MagicCriticalRate = txt_rate.Text.Trim();
            cData.MagicCriticalDamage = txt_critical.Text.Trim();
        }

        /// <summary>
        /// Preenche o textbox com os dados de classe.
        /// </summary>
        /// <param name="cData"></param>
        public void FillTextbox(Classe cData) {
            txt_attack.Text = cData.MagicAttack.ToString();
            txt_accuracy.Text = cData.MagicAccuracy.ToString();
            txt_defense.Text = cData.MagicDefense.ToString();
            txt_resist.Text = cData.MagicResist.ToString();
            txt_rate.Text = cData.MagicCriticalRate.ToString();
            txt_critical.Text = cData.MagicCriticalDamage.ToString();
        }

        public void Clear() {
            txt_attack.Text = "0";
            txt_accuracy.Text = "0";
            txt_defense.Text = "0";
            txt_resist.Text = "0";
            txt_rate.Text = "0";
            txt_critical.Text = "0";
        }
    }
}

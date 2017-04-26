using System;
using System.Windows.Forms;
using DarkUI.Docking;
using Classe_Editor.ClasseData;

namespace Classe_Editor.DarkControl {
    public partial class Physical : DarkToolWindow {
        /// <summary>
        /// Indica se abre as classes ou incrementos.
        /// </summary>
        public bool IsClasseMode { get; set; } = true;

        public Physical() {
            InitializeComponent();

            DockArea = DarkDockArea.Document;
            Dock = DockStyle.Fill;

            txt_attack.KeyPress += ControlEvent.TextBox_KeyPress;
            txt_accuracy.KeyPress += ControlEvent.TextBox_KeyPress;
            txt_defense.KeyPress += ControlEvent.TextBox_KeyPress;
            txt_evasion.KeyPress += ControlEvent.TextBox_KeyPress;
            txt_block.KeyPress += ControlEvent.TextBox_KeyPress;
            txt_parry.KeyPress += ControlEvent.TextBox_KeyPress;
            txt_rate.KeyPress += ControlEvent.TextBox_KeyPress;
            txt_critical.KeyPress += ControlEvent.TextBox_KeyPress;
        }

        /// <summary>
        /// Verifica os campos e adiciona os dados.
        /// </summary>
        /// <param name="cData"></param>
        public void FillClasseData(Classe cData) {
            if (IsClasseMode) { ControlEvent.VerifyTextBox(Controls); }

            cData.Attack = txt_attack.Text.Trim();
            cData.Accuracy = txt_accuracy.Text.Trim();
            cData.Defense = txt_defense.Text.Trim();
            cData.Evasion = txt_evasion.Text.Trim();
            cData.Block = txt_block.Text.Trim();
            cData.Parry = txt_parry.Text.Trim();
            cData.CriticalRate = txt_rate.Text.Trim();
            cData.CriticalDamage = txt_critical.Text.Trim();
        }

        /// <summary>
        /// Preenche o textbox com os dados de classe.
        /// </summary>
        /// <param name="cData"></param>
        public void FillTextbox(Classe cData) {
            txt_attack.Text = cData.Attack.ToString();
            txt_accuracy.Text = cData.Accuracy.ToString();
            txt_defense.Text = cData.Defense.ToString();
            txt_evasion.Text = cData.Evasion.ToString();
            txt_block.Text = cData.Block.ToString();
            txt_parry.Text = cData.Parry.ToString();
            txt_rate.Text = cData.CriticalRate.ToString();
            txt_critical.Text = cData.CriticalDamage.ToString();
        }

        public void Clear() {
            txt_attack.Text = "0";
            txt_accuracy.Text = "0";
            txt_defense.Text = "0";
            txt_evasion.Text = "0";
            txt_block.Text = "0";
            txt_parry.Text = "0";
            txt_rate.Text = "0";
            txt_critical.Text = "0";
        }
    }
}

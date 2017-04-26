using System;
using System.Windows.Forms;
using DarkUI.Docking;
using Classe_Editor.ClasseData;

namespace Classe_Editor.DarkControl {
    public partial class Extra : DarkToolWindow {
        /// <summary>
        /// Indica se abre as classes ou incrementos.
        /// </summary>
        public bool IsClasseMode { get; set; } = true;

        public Extra() {
            InitializeComponent();

            DockArea = DarkDockArea.Document;
            Dock = DockStyle.Fill;

            txt_atkspd.KeyPress += ControlEvent.TextBox_KeyPress;
            txt_castspd.KeyPress += ControlEvent.TextBox_KeyPress;
            txt_enmity.KeyPress += ControlEvent.TextBox_KeyPress;
            txt_supp.KeyPress += ControlEvent.TextBox_KeyPress;
            txt_add.KeyPress += ControlEvent.TextBox_KeyPress;
            txt_heal.KeyPress += ControlEvent.TextBox_KeyPress;
            txt_concentration.KeyPress += ControlEvent.TextBox_KeyPress;
        }

        /// <summary>
        /// Verifica os campos e adiciona os dados.
        /// </summary>
        /// <param name="cData"></param>
        public void FillClasseData(Classe cData) {
            if (IsClasseMode) { ControlEvent.VerifyTextBox(Controls); }

            cData.AttackSpeed = txt_atkspd.Text.Trim();
            cData.CastSpeed = txt_castspd.Text.Trim();
            cData.Enmity = txt_enmity.Text.Trim();
            cData.DamageSuppression = txt_supp.Text.Trim();
            cData.AdditionalDamage = txt_add.Text.Trim();
            cData.HealingPower = txt_heal.Text.Trim();
            cData.Concentration = txt_concentration.Text.Trim();
        }

        /// <summary>
        /// Preenche o textbox com os dados de classe.
        /// </summary>
        /// <param name="cData"></param>
        public void FillTextbox(Classe cData) {
            txt_atkspd.Text = cData.AttackSpeed.ToString();
            txt_castspd.Text = cData.CastSpeed.ToString();
            txt_enmity.Text = cData.Enmity.ToString();
            txt_supp.Text = cData.DamageSuppression.ToString();
            txt_add.Text = cData.AdditionalDamage.ToString();
            txt_heal.Text = cData.HealingPower.ToString();
            txt_concentration.Text = cData.Concentration.ToString();
        }

        public void Clear() {
            txt_atkspd.Text = "1000";
            txt_castspd.Text = "1000";
            txt_enmity.Text = "0";
            txt_supp.Text = "0";
            txt_add.Text = "0";
            txt_heal.Text = "0";
            txt_concentration.Text = "0";
        }
    }
}

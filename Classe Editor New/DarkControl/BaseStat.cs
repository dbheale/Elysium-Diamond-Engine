using System;
using System.Windows.Forms;
using DarkUI.Docking;
using Classe_Editor.ClasseData;

namespace Classe_Editor.DarkControl {
    public partial class BaseStat : DarkToolWindow {
        /// <summary>
        /// Indica se abre as classes ou incrementos.
        /// </summary>
        public bool IsClasseMode { get; set; } = true;

        public BaseStat() {
            InitializeComponent();

            DockArea = DarkDockArea.Document;
            Dock = DockStyle.Fill;

            txt_str.KeyPress += ControlEvent.TextBox_KeyPress;
            txt_dex.KeyPress += ControlEvent.TextBox_KeyPress;
            txt_agi.KeyPress += ControlEvent.TextBox_KeyPress;
            txt_con.KeyPress += ControlEvent.TextBox_KeyPress;
            txt_int.KeyPress += ControlEvent.TextBox_KeyPress;
            txt_wis.KeyPress += ControlEvent.TextBox_KeyPress;
            txt_wil.KeyPress += ControlEvent.TextBox_KeyPress;
            txt_min.KeyPress += ControlEvent.TextBox_KeyPress;
            txt_cha.KeyPress += ControlEvent.TextBox_KeyPress;
        }

        /// <summary>
        /// Verifica os campos e adiciona os dados.
        /// </summary>
        /// <param name="cData"></param>
        public void FillClasseData(Classe cData) {
            if (IsClasseMode) { ControlEvent.VerifyTextBox(Controls); }

            cData.Strenght = txt_str.Text.Trim();
            cData.Dexterity = txt_dex.Text.Trim();
            cData.Agility = txt_agi.Text.Trim();
            cData.Constitution = txt_con.Text.Trim();
            cData.Intelligence = txt_int.Text.Trim();
            cData.Wisdom = txt_wis.Text.Trim();
            cData.Will = txt_wil.Text.Trim();
            cData.Mind = txt_min.Text.Trim();
            cData.Charisma = txt_cha.Text.Trim();
        }

        /// <summary>
        /// Preenche o textbox com os dados de classe.
        /// </summary>
        /// <param name="cData"></param>
        public void FillTextbox(Classe cData) {
            txt_str.Text = cData.Strenght.ToString();
            txt_dex.Text = cData.Dexterity.ToString();
            txt_agi.Text = cData.Agility.ToString();
            txt_con.Text = cData.Constitution.ToString();
            txt_int.Text = cData.Intelligence.ToString();
            txt_wis.Text = cData.Wisdom.ToString();
            txt_wil.Text = cData.Will.ToString();
            txt_min.Text = cData.Mind.ToString();
            txt_cha.Text = cData.Charisma.ToString();
        }

        public void Clear() {
            txt_str.Text = "0";
            txt_dex.Text = "0";
            txt_agi.Text = "0";
            txt_con.Text = "0";
            txt_int.Text = "0";
            txt_wis.Text = "0";
            txt_wil.Text = "0";
            txt_min.Text = "0";
            txt_cha.Text = "0";
        }
    }
}

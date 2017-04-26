using System;
using System.Windows.Forms;
using DarkUI.Docking;
using Classe_Editor.ClasseData;

namespace Classe_Editor.DarkControl {
    public partial class Elemental : DarkToolWindow {
        /// <summary>
        /// Indica se abre as classes ou incrementos.
        /// </summary>
        public bool IsClasseMode { get; set; } = true;

        public Elemental() {
            InitializeComponent();

            DockArea = DarkDockArea.Document;
            Dock = DockStyle.Fill;

            txt_fire.KeyPress += ControlEvent.TextBox_KeyPress;
            txt_water.KeyPress += ControlEvent.TextBox_KeyPress;
            txt_air.KeyPress += ControlEvent.TextBox_KeyPress;
            txt_earth.KeyPress += ControlEvent.TextBox_KeyPress;
            txt_light.KeyPress += ControlEvent.TextBox_KeyPress;
            txt_dark.KeyPress += ControlEvent.TextBox_KeyPress;
        }

        /// <summary>
        /// Verifica os campos e adiciona os dados.
        /// </summary>
        /// <param name="cData"></param>
        public void FillClasseData(Classe cData) {
            if (IsClasseMode) { ControlEvent.VerifyTextBox(Controls); }

            cData.AttributeFire = txt_fire.Text.Trim();
            cData.AttributeWater = txt_water.Text.Trim();
            cData.AttributeWind = txt_air.Text.Trim();
            cData.AttributeEarth = txt_earth.Text.Trim();
            cData.AttributeLight = txt_light.Text.Trim();
            cData.AttributeDark = txt_dark.Text.Trim();
        }

        /// <summary>
        /// Preenche o textbox com os dados de classe.
        /// </summary>
        /// <param name="cData"></param>
        public void FillTextbox(Classe cData) {
            txt_fire.Text = cData.AttributeFire.ToString();
            txt_water.Text = cData.AttributeWater.ToString();
            txt_air.Text = cData.AttributeWind.ToString();
            txt_earth.Text = cData.AttributeEarth.ToString();
            txt_light.Text = cData.AttributeLight.ToString();
            txt_dark.Text = cData.AttributeDark.ToString();
        }

        public void Clear() {
            txt_fire.Text = "0";
            txt_water.Text = "0";
            txt_air.Text = "0";
            txt_earth.Text = "0";
            txt_light.Text = "0";
            txt_dark.Text = "0";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DarkUI.Docking;
using DarkUI.Controls;
using Classe_Editor.Database;
using Classe_Editor.ClasseData;

namespace Classe_Editor.DarkControl {
    public partial class Basic : DarkToolWindow {
        bool _isClasseMode = true;
        /// <summary>
        /// Indica se abre as classes ou incrementos.
        /// </summary>
        public bool IsClasseMode {
            get { return _isClasseMode; }
            set {
                _isClasseMode = value;
                dockpanel.Visible = value;
            }
        }
      
        private List<ListClasseData> increment;
       
        public Basic() {
            InitializeComponent();

            DockArea = DarkDockArea.Document;
            Dock = DockStyle.Fill;

            txt_id.KeyPress += ControlEvent.TextBox_KeyPress;
            txt_level.KeyPress += ControlEvent.TextBox_KeyPress;
            txt_point.KeyPress += ControlEvent.TextBox_KeyPress;

            //obtem os incrementos e preenche a lista
            increment = ClasseDB.GetClasseBasicData("classes_increment");
            for (var n = 0; n < increment.Count; n++) {
                list_increment.Items.Add(new DarkListItem($"{increment[n].ID} - {increment[n].Name}"));
            }   
        }

        private void VerifyTextBox() {
            if (txt_id.Text.Length == 0) { txt_id.Text = "0"; }
            if (txt_name.Text.Length == 0) { txt_name.Text = string.Empty; }
            if (txt_level.Text.Length == 0) { txt_level.Text = "0"; }
            if (txt_point.Text.Length == 0) { txt_point.Text = "0"; }
            if (txt_sprite.Text.Length == 0) { txt_sprite.Text = "0"; }
        }

        /// <summary>
        /// Verifica os campos e adiciona os dados.
        /// </summary>
        /// <param name="cData"></param>
        public void FillClasseData(Classe cData) {
            if (IsClasseMode) { VerifyTextBox(); }

            cData.ID = Convert.ToInt32(txt_id.Text.Trim());
            cData.Name = txt_name.Text.Trim();
            cData.Level = txt_level.Text.Trim();
            cData.Points = txt_point.Text.Trim();
            cData.Sprite = Convert.ToInt16(txt_sprite.Text.Trim());

            if (IsClasseMode) {
                var index = list_increment.SelectedIndices[0];
                cData.IncrementID = (index <= 0) ? 0 : increment[index].ID;
            }
        }

        /// <summary>
        /// Preenche o textbox com os dados de classe.
        /// </summary>
        /// <param name="cData"></param>
        public void FillTextbox(Classe cData) {
            txt_id.Text = cData.ID.ToString();
            txt_name.Text = cData.Name;
            txt_level.Text = cData.Level.ToString();
            txt_point.Text = cData.Points.ToString();
            txt_sprite.Text = cData.Sprite.ToString();

            if (IsClasseMode) {
                var index = FindIndexByID(cData.IncrementID);
                list_increment.SelectItem(index);           
            }
        }

        private int FindIndexByID(int incrementID) {
            for (var index = 0; index < increment.Count; index++) {
                if (increment[index].ID == incrementID) return index;
            }

            return -1;
        }

        public void Clear() {
            txt_id.Text = "0";
            txt_name.Text = string.Empty;
            txt_level.Text = "0";
            txt_point.Text = "0";
            txt_sprite.Text = "0";
        }
    }
}

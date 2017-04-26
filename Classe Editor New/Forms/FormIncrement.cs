using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DarkUI.Forms;
using DarkUI.Docking;
using DarkUI.Controls;
using Classe_Editor.DarkControl;
using Classe_Editor.ClasseData;

namespace Classe_Editor {
    public partial class FormIncrement : DarkForm {
        /// <summary>
        /// Indica se o formulário está para editar ou criar.
        /// </summary>
        public bool IsSaveMode { get; set; }

        /// <summary>
        /// verifica o form já está aberto
        /// </summary>
        public bool IsOpen { get; set; } = false;

        Increment IncrementTab;
        Classe pData;
        Basic BasicTab;
        BaseStat StatTab;
        Vital VitalTab;
        Physical PhysicalTab;
        Magic MagicTab;
        Extra ExtraTab;
        Elemental ElementalTab;
        Resist ResistTab;

        public FormIncrement() {
            InitializeComponent();

            pData = new Classe();
            IncrementTab = new Increment();
            //muda o modo de edição para incremento
            BasicTab = new Basic();
            BasicTab.IsClasseMode = false;

            StatTab = new BaseStat();
            VitalTab = new Vital();
            PhysicalTab = new Physical();
            MagicTab = new Magic();
            ExtraTab = new Extra();
            ElementalTab = new Elemental();
            ResistTab = new Resist();

            DockPanel.AddContent(BasicTab);
            DockPanel.AddContent(StatTab);
            DockPanel.AddContent(VitalTab);
            DockPanel.AddContent(PhysicalTab);
            DockPanel.AddContent(MagicTab);
            DockPanel.AddContent(ElementalTab);
            DockPanel.AddContent(ResistTab);
            DockPanel.AddContent(ExtraTab);

            DockPanel.ContentRemoved += DockPanel_ContentRemoved;
        }

        #region Event

        private void DockPanel_ContentRemoved(object sender, DockContentEventArgs e) {
            switch (e.Content.DockText) {
                case "Atributos":
                    item_stat.Checked = false;
                    break;
                case "Básico":
                    item_basic.Checked = false;
                    break;
                case "Elemental":
                    item_elemental.Checked = false;
                    break;
                case "Extra":
                    item_extra.Checked = false;
                    break;
                case "Combate Mágico":
                    item_magic.Checked = false;
                    break;
                case "Combate Físico":
                    item_physical.Checked = false;
                    break;
                case "Resistências":
                    item_resist.Checked = false;
                    break;
                case "Vital":
                    item_vital.Checked = false;
                    break;
            }
        }

        private void FormIncrement_FormClosing(object sender, FormClosingEventArgs e) {
            IsOpen = false;
        }
        #endregion

        #region Menu Strip

        private void item_basic_Click(object sender, EventArgs e) {
            if (!DockPanel.ContainsContent(BasicTab)) {
                BasicTab.DockArea = DarkDockArea.Document;
                DockPanel.AddContent(BasicTab);
                item_basic.Checked = true;
            }
            else {
                DockPanel.RemoveContent(BasicTab);
                item_basic.Checked = false;
            }
        }

        private void item_stat_Click(object sender, EventArgs e) {
            if (!DockPanel.ContainsContent(StatTab)) {
                StatTab.DockArea = DarkDockArea.Document;
                DockPanel.AddContent(StatTab);
                item_stat.Checked = true;
            }
            else {
                DockPanel.RemoveContent(StatTab);
                item_stat.Checked = false;
            }
        }

        private void item_vital_Click(object sender, EventArgs e) {
            if (!DockPanel.ContainsContent(VitalTab)) {
                VitalTab.DockArea = DarkDockArea.Document;
                DockPanel.AddContent(VitalTab);
                item_vital.Checked = true;
            }
            else {
                DockPanel.RemoveContent(VitalTab);
                item_vital.Checked = false;
            }
        }

        private void item_physical_Click(object sender, EventArgs e) {
            if (!DockPanel.ContainsContent(PhysicalTab)) {
                PhysicalTab.DockArea = DarkDockArea.Document;
                DockPanel.AddContent(PhysicalTab);
                item_physical.Checked = true;
            }
            else {
                DockPanel.RemoveContent(PhysicalTab);
                item_physical.Checked = false;
            }
        }

        private void item_magic_Click(object sender, EventArgs e) {
            if (!DockPanel.ContainsContent(MagicTab)) {
                MagicTab.DockArea = DarkDockArea.Document;
                DockPanel.AddContent(MagicTab);
                item_magic.Checked = true;
            }
            else {
                DockPanel.RemoveContent(MagicTab);
                item_magic.Checked = false;
            }
        }

        private void item_resist_Click(object sender, EventArgs e) {
            if (!DockPanel.ContainsContent(ResistTab)) {
                ResistTab.DockArea = DarkDockArea.Document;
                DockPanel.AddContent(ResistTab);
                item_resist.Checked = true;
            }
            else {
                DockPanel.RemoveContent(ResistTab);
                item_resist.Checked = false;
            }
        }

        private void item_elemental_Click(object sender, EventArgs e) {
            if (!DockPanel.ContainsContent(ElementalTab)) {
                ElementalTab.DockArea = DarkDockArea.Document;
                DockPanel.AddContent(ElementalTab);
                item_elemental.Checked = true;
            }
            else {
                DockPanel.RemoveContent(ElementalTab);
                item_elemental.Checked = false;
            }
        }

        private void item_extra_Click(object sender, EventArgs e) {
            if (!DockPanel.ContainsContent(ExtraTab)) {
                ExtraTab.DockArea = DarkDockArea.Document;
                DockPanel.AddContent(ExtraTab);
                item_extra.Checked = true;
            }
            else {
                DockPanel.RemoveContent(ExtraTab);
                item_extra.Checked = false;
            }
        }

        private void item_exit_Click(object sender, EventArgs e) {
            Close();
        }

        private void item_clear_Click(object sender, EventArgs e) {
            Clear();
            FillClasseData();
        }

        #endregion

        public void Show(int incrementID) {

        }

        /// <summary>
        /// Limpa os dados de todos os campos.
        /// </summary>
        private void Clear() {
            BasicTab.Clear();
            StatTab.Clear();
            VitalTab.Clear();
            PhysicalTab.Clear();
            MagicTab.Clear();
            ExtraTab.Clear();
            ElementalTab.Clear();
            ResistTab.Clear();
        }

        /// <summary>
        /// Preenche com os dados do textbox.
        /// </summary>
        private void FillClasseData() {
            BasicTab.FillClasseData(pData);
            StatTab.FillClasseData(pData);
            VitalTab.FillClasseData(pData);
            PhysicalTab.FillClasseData(pData);
            MagicTab.FillClasseData(pData);
            ExtraTab.FillClasseData(pData);
            ElementalTab.FillClasseData(pData);
            ResistTab.FillClasseData(pData);
        }

        /// <summary>
        /// Preenche os textbox com os dados de classe.
        /// </summary>
        private void FillTextbox() {
            BasicTab.FillTextbox(pData);
            StatTab.FillTextbox(pData);
            VitalTab.FillTextbox(pData);
            PhysicalTab.FillTextbox(pData);
            MagicTab.FillTextbox(pData);
            ExtraTab.FillTextbox(pData);
            ElementalTab.FillTextbox(pData);
            ResistTab.FillTextbox(pData);
        }
    }
}

using System;
using DarkUI.Forms;
using DarkUI.Docking;
using Classe_Editor.DarkControl;
using Classe_Editor.ClasseData;
using Classe_Editor.Database;

namespace Classe_Editor {
    public partial class FormClasses : DarkForm {
        /// <summary>
        /// Indica se o formulário está para editar ou criar.
        /// </summary>
        public bool IsSaveMode { get;set; }

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

        public FormClasses() {
            InitializeComponent();

            pData = new Classe();
            IncrementTab = new Increment();
            BasicTab = new Basic();         
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
                case "Atributos": item_stat.Checked = false;
                    break;
                case "Básico": item_basic.Checked = false;
                    break;
                case "Elemental": item_elemental.Checked = false;
                    break;
                case "Extra": item_extra.Checked = false;
                    break;
                case "Combate Mágico": item_magic.Checked = false;
                    break;
                case "Combate Físico": item_physical.Checked = false;
                    break;
                case "Resistências": item_resist.Checked = false;
                    break;
                case "Vital": item_vital.Checked = false;
                    break;
            }
        }

        private void FormClasses_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e) {
            IsOpen = false;
        }

        #endregion

        #region Menu Item

        private void item_basic_Click(object sender, EventArgs e) {
            if (!DockPanel.ContainsContent(BasicTab)) {
                BasicTab.DockArea = DarkDockArea.Document;
                DockPanel.AddContent(BasicTab);
                item_basic.Checked = true;
            } else {
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
            } else {
                DockPanel.RemoveContent(VitalTab);
                item_vital.Checked = false;
            }
        }

        private void item_physical_Click(object sender, EventArgs e) {
            if (!DockPanel.ContainsContent(PhysicalTab)) {
                PhysicalTab.DockArea = DarkDockArea.Document;
                DockPanel.AddContent(PhysicalTab);
                item_physical.Checked = true;
            } else {
                DockPanel.RemoveContent(PhysicalTab);
                item_physical.Checked = false;
            }
        }

        private void item_magic_Click(object sender, EventArgs e) {
            if (!DockPanel.ContainsContent(MagicTab)) {
                MagicTab.DockArea = DarkDockArea.Document;
                DockPanel.AddContent(MagicTab);
                item_magic.Checked = true;
            } else {
                DockPanel.RemoveContent(MagicTab);
                item_magic.Checked = false;
            }
        }

        private void item_resist_Click(object sender, EventArgs e) {
            if (!DockPanel.ContainsContent(ResistTab)) {
                ResistTab.DockArea = DarkDockArea.Document;
                DockPanel.AddContent(ResistTab);
                item_resist.Checked = true;
            } else {
                DockPanel.RemoveContent(ResistTab);
                item_resist.Checked = false;
            }
        }

        private void item_elemental_Click(object sender, EventArgs e) {
            if (!DockPanel.ContainsContent(ElementalTab)) {
                ElementalTab.DockArea = DarkDockArea.Document;
                DockPanel.AddContent(ElementalTab);
                item_elemental.Checked = true;
            } else {
                DockPanel.RemoveContent(ElementalTab);
                item_elemental.Checked = false;
            }
        }

        private void item_extra_Click(object sender, EventArgs e) {
            if (!DockPanel.ContainsContent(ExtraTab)) {
                ExtraTab.DockArea = DarkDockArea.Document;
                DockPanel.AddContent(ExtraTab);
                item_extra.Checked = true;
            } else {
                DockPanel.RemoveContent(ExtraTab);
                item_extra.Checked = false;
            }
        }

        /// <summary>
        /// Salva ou insere os dados.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void item_save_Click(object sender, EventArgs e) {
            FillClasseData();

            if (!IsSaveMode) {
                if (ClasseDB.ExistClasse(pData.ID)) {
                    DarkMessageBox.ShowInformation("O ID já está em uso.", "Aviso");
                    return;
                }

                if (ClasseDB.InsertClasse(pData) > 0) {
                    DarkMessageBox.ShowInformation("As informações foram salvas.", "Aviso");
                    Program.MainForm.LoadClasse();
                    Close();
                }
            } else {
                if (ClasseDB.UpdateClasse(pData, pData.OldID) > 0) {
                    DarkMessageBox.ShowInformation("As informações foram salvas.", "Aviso");
                    //atualiza as informações
                    pData.OldID = pData.ID;
                    Program.MainForm.LoadClasse();
                }
            }
        }

        /// <summary>
        /// Limpa os campos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void item_clear_Click(object sender, EventArgs e) {
            Clear();
            FillClasseData();
        }

        private void item_exit_Click(object sender, EventArgs e) {
            Close();
        }

        #endregion

        /// <summary>
        /// Abre o formulario e carrega as informações da classe.
        /// </summary>
        /// <param name="classeID"></param>
        public void Show(int classeID) {
            pData = ClasseDB.LoadClasseData(classeID);

            FillTextbox();

            if (!IsOpen) { Show(); }

            IsOpen = true;
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

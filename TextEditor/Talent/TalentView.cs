using System;
using System.Windows.Forms;

namespace TextEditor.Talent {
    public sealed partial class TalentView : Form {
        public TalentView() {
            InitializeComponent();
        }

        /// <summary>
        /// Esconde a janela.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_cancel_Click(object sender, EventArgs e) {
            Hide();
            //list_talent.SelectedIndex = 0;
        }

        /// <summary>
        /// Seleciona um talento.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_select_Click(object sender, EventArgs e) {
            var index = list_talent.SelectedIndex;
            if (index == -1) { return; }
            if (TalentStatic.SelectedClasse == -1) { return; }
            if (TalentStatic.Classes.Count == 0) { return; }

            var id = TalentStatic.Talents[index].ID;

            if (TalentStatic.SelectedType == 0)
                TalentStatic.Classes[TalentStatic.SelectedClasse].Balance[TalentStatic.SelectedIndex] = id;

            if (TalentStatic.SelectedType == 1)
                TalentStatic.Classes[TalentStatic.SelectedClasse].Physic[TalentStatic.SelectedIndex] = id;

            if (TalentStatic.SelectedType == 2)
                TalentStatic.Classes[TalentStatic.SelectedClasse].Magic[TalentStatic.SelectedIndex] = id;

            if (TalentStatic.SelectedType == 3)
                TalentStatic.Classes[TalentStatic.SelectedClasse].Restoration[TalentStatic.SelectedIndex] = id;

            TalentStatic.TalentForm.UpdateIcon();

            Hide();
            list_talent.SelectedIndex = 0;
        }

        /// <summary>
        /// Exibe o ícone do talento.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void list_talent_SelectedIndexChanged(object sender, EventArgs e) {
            var index = list_talent.SelectedIndex;
            if (index == -1) { return; }

            var icon = TalentStatic.Talents[index].IconID;
            lbl_icon.Image = EngineIcon.Icon[icon];
        }

        /// <summary>
        /// Atualiza os talentos quando a lista estiver limpa.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TalentView_Load(object sender, EventArgs e) {
            if (list_talent.Items.Count == 0) {
                list_talent.BeginUpdate();

                var count = TalentStatic.Talents.Count;
                for (var n = 0; n < count; n++) {
                    list_talent.Items.Add($"{TalentStatic.Talents[n].ID}: {TalentStatic.Talents[n].Title}");
                }

                list_talent.EndUpdate();
            }
        }
    }
}
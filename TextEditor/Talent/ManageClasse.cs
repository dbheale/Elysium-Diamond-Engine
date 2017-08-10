using System;
using System.Windows.Forms;

namespace TextEditor.Talent {
    public sealed partial class ManageClasse : Form {
        /// <summary>
        /// item do combobox selecionado.
        /// </summary>
        int index = -1;

        /// <summary>
        /// Indica que o modo de editação está habilidade ou desabilitado.
        /// </summary>
        bool edit = false;

        public ManageClasse() {
            InitializeComponent();
            txt_id.TextChanged += text_Change;
            txt_name.TextChanged += text_Change;
        }

        private void ManageClasse_Load(object sender, EventArgs e) {
            LoadClasse();
        }

        /// <summary>
        /// Carrega os dados para o combobox.
        /// </summary>
        private void LoadClasse() {
            var count = TalentStatic.Classes.Count;
            cmb_classe.Items.Clear();

            for (int n = 0; n < count; n++) {
                cmb_classe.Items.Add($"{TalentStatic.Classes[n].ClasseID}: {TalentStatic.Classes[n].ClasseName}");
            }

            if (count > 0) {
                SelectIndex(0);
                index = 0;
            }
            else {
                index = -1;
            }
        }

        /// <summary>
        /// Seleciona o índice no combo e exibe os dados.
        /// </summary>
        /// <param name="index"></param>
        private void SelectIndex(int index) {
            cmb_classe.SelectedIndex = index;
            txt_id.Text = $"{TalentStatic.Classes[index].ClasseID}";
            txt_name.Text = TalentStatic.Classes[index].ClasseName;
        }

        /// <summary>
        /// Adiciona uma nova aba de talentos para classe.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        private void Add(int id, string name) {
            TalentStatic.Classes.Add(new ClasseTalent(id, name));
            cmb_classe.Items.Add($"{id}: {name}");
        }

        /// <summary>
        /// Remove uma aba de talentos de classe.
        /// </summary>
        /// <param name="index"></param>
        private void Remove(int index) {
            TalentStatic.Classes.RemoveAt(index);

            LoadClasse();
        }

        /// <summary>
        /// Limpa os dados dos controles e também a lista de talentos de classe.
        /// </summary>
        private void Clear() {
            TalentStatic.Classes.Clear();
            cmb_classe.Items.Clear();
            txt_id.Clear();
            txt_name.Clear();
        }

        private void btn_add_Click(object sender, EventArgs e) {
            var id = 0;
            var result = int.TryParse(txt_id.Text.Trim(), out id);

            if (!result) {
                MessageBox.Show("Formato incorreto ID", "Aviso");
                return;
            }

            Add(id, txt_name.Text.Trim());

            //seleciona o primeiro item da lista  
            SelectIndex(0);

            TalentStatic.NeedUpdate = true;
        }

        private void btn_remove_Click(object sender, EventArgs e) {
            var index = cmb_classe.SelectedIndex;

            if (index == -1) return;

            TalentStatic.NeedUpdate = true;

            Remove(index);
        }

        /// <summary>
        /// Atualiza as informaçãos quando o texto é alterado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void text_Change(object sender, EventArgs e) {
            if (index == -1 | !edit) { return; }
            
            var id = 0;
            var result = int.TryParse(txt_id.Text.Trim(), out id);

            if (!result) { return; }

            cmb_classe.Items[index] = $"{id}: {txt_name.Text.Trim()}";

            TalentStatic.Classes[index].ClasseID = id;
            TalentStatic.Classes[index].ClasseName = txt_name.Text.Trim();
            TalentStatic.NeedUpdate = true;
        }

        /// <summary>
        /// Seleciona um índice no combo e exibe os dados.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmb_classe_SelectedIndexChanged(object sender, EventArgs e) {
            index = cmb_classe.SelectedIndex;
            if (!edit) SelectIndex(index);
        }

        /// <summary>
        /// Habilita ou desabilita o modo de edição.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chk_edit_CheckedChanged(object sender, EventArgs e) {
            edit = chk_edit.Checked;
            cmb_classe.Enabled = !edit;
            btn_add.Enabled = !edit;
            btn_remove.Enabled = !edit;
        }
    }
}
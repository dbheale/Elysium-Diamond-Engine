using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor {
    public partial class ExpForm : Form {
        public ExpForm() {
            InitializeComponent();
        }

        private int OldLevel = 0;

        private void ExpForm_Load(object sender, EventArgs e) {
            EditorData.Experience = new Experience();
        }

        /// <summary>
        /// Salva os dados no arquivo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_save_Click(object sender, EventArgs e) {
            Experience.SaveExp("experience.bin");

            MessageBox.Show("Arquivo salvo (experience.bin)", "Aviso");
        }

        /// <summary>
        /// Abre os dados do arquivo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_open_Click(object sender, EventArgs e) {
            EditorData.Experience.Exp.Clear();
           
            Experience.OpenExp("experience.bin");

            FillListBox();
        }

        /// <summary>
        /// Adiciona um novo valor.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_add_Click(object sender, EventArgs e) {
            var level = Convert.ToInt32(txt_lvl.Text.Trim());
            var exp = Convert.ToInt64(txt_exp.Text.Trim());

            EditorData.Experience.Add(level, exp);

            FillListBox();
        }

        /// <summary>
        /// Atualiza a lista
        /// </summary>
        private void FillListBox() {
            listBox1.Items.Clear();

            foreach(DictionaryEntry entry in EditorData.Experience.Exp) {
                listBox1.Items.Add($"{entry.Key}, {entry.Value}");
            }

            listBox1.Refresh();
            listBox1.Update();
        }

        /// <summary>
        /// Preenche com os dados
        /// </summary>
        /// <param name="level"></param>
        private void FillTextbox(int level) {
            txt_lvl.Text = level + "";
            txt_exp.Text = EditorData.Experience[level].ToString();
        }

        /// <summary>
        /// Seleciona o item para edição
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {
            var text = listBox1.SelectedItem.ToString().Split(',');
            OldLevel = Convert.ToInt32(text[0]);

            Text = $"OldLevel: {OldLevel}";

            FillTextbox(OldLevel);
        }

        /// <summary>
        /// Atualiza as informações.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_update_Click(object sender, EventArgs e) {
            if (!EditorData.Experience.Exp.ContainsKey(OldLevel)) return;
           
            var exp = Convert.ToInt64(txt_exp.Text.Trim());

            EditorData.Experience[OldLevel] = exp;

            ResetOldLevel();

            FillListBox();
        }

        /// <summary>
        /// Remove o item da lista.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_remove_Click(object sender, EventArgs e) {
            if (EditorData.Experience.Exp.ContainsKey(OldLevel))
                EditorData.Experience.Remove(OldLevel);

            ResetOldLevel();

            FillListBox();
        }

        private void ResetOldLevel() {
            OldLevel = 0;
            Text = $"OldLevel: {OldLevel}";
        }
    }
}

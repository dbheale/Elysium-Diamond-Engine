using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor {
    public partial class NpcForm : Form {
        private int old_id;

        public NpcForm() {
            InitializeComponent();
        }

        private void NpcForm_Load(object sender, EventArgs e) {
            EditorData.Npc = new HashSet<NpcData>();
            cmb_elite.SelectedIndex = 0;
            cmb_type.SelectedIndex = 0;
        }

        /// <summary>
        /// Completa o textbox com as informações do npc.
        /// </summary>
        /// <param name="npc"></param>
        private void FillData(NpcData npc) {
            txt_unique.Text = npc.ID + "";
            txt_name.Text = npc.Name;
            txt_sprite.Text = npc.Sprite + "";
            cmb_type.Text = npc.Type.ToString();
            cmb_elite.SelectedItem = npc.Elite.ToString();
            txt_level.Text = npc.Level + "";
        }

        /// <summary>
        /// Completa o npc com as informações do textbox.
        /// </summary>
        /// <returns></returns>
        private NpcData CreateNpc() {
            var npc = new NpcData();

            npc.ID = Convert.ToInt32(txt_unique.Text.Trim());
            npc.Name = txt_name.Text.Trim();
            npc.Sprite = Convert.ToInt16(txt_sprite.Text.Trim());
            npc.Type = (NpcType)Convert.ToByte(cmb_type.SelectedIndex);
            npc.Elite = (NpcEliteType)Convert.ToByte(cmb_elite.SelectedIndex);
            npc.Level = Convert.ToInt32(txt_level.Text);

            return npc;
        }

        /// <summary>
        /// Lista todos os npc.
        /// </summary>
        private void FillListbox() {
            listBox1.Items.Clear();

            foreach (var npc in EditorData.Npc) {
                listBox1.Items.Add($"{npc.ID}, {npc.Name}, {npc.Sprite}, {npc.Type.ToString()}, {npc.Elite.ToString()}, {npc.Level}");
            }

            listBox1.Refresh();
            listBox1.Update();
        }

        /// <summary>
        /// Salva a lista de npc no arquivo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_save_Click(object sender, EventArgs e) {
            NpcData.SaveNpc("npc.bin");

            MessageBox.Show("Arquivo salvo (npc.bin)", "Aviso");
        }

        /// <summary>
        /// Abre a lista de todos os npc.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_open_Click(object sender, EventArgs e) {
            EditorData.Npc.Clear();

            NpcData.OpenNpc("npc.bin");
           
            FillListbox();
        }

        /// <summary>
        /// Adiciona um novo npc.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_add_Click(object sender, EventArgs e) {
            EditorData.Npc.Add(CreateNpc());
            FillListbox();
        }

        /// <summary>
        /// Atualiza as informações do npc na lista.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_update_Click(object sender, EventArgs e) {
            var npc_find = EditorData.FindNpcByID(old_id);

            if (npc_find == null) return;

            var npc = CreateNpc();

            npc_find.ID = npc.ID;
            npc_find.Name = npc.Name;
            npc_find.Sprite = npc.Sprite;
            npc_find.Type = npc.Type;
            npc_find.Elite = npc.Elite;
            npc_find.Level = npc.Level;

            FillListbox();
        }

        /// <summary>
        /// Seleciona o npc para edição.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {
            var text = listBox1.SelectedItem.ToString().Split(',');
            var npc = EditorData.FindNpcByID(Convert.ToInt32(text[0]));

            if (npc == null) return;

            old_id = npc.ID;

            Text = $"Old ID: {old_id}";

            FillData(npc);
        }

        /// <summary>
        /// Remove um npc.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_remove_Click(object sender, EventArgs e) {
            var npc = EditorData.FindNpcByID(old_id);

            if (npc == null) return;

            EditorData.Npc.Remove(npc);

            old_id = 0;
            Text = "Old ID: 0";

            FillListbox();
        }
    }
}

using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace TextEditor.Talent {
    public sealed partial class TalentForm : Form {
        private Label[] balance = new Label[TalentStatic.MAX_TALENT];
        private Label[] physic = new Label[TalentStatic.MAX_TALENT];
        private Label[] magic = new Label[TalentStatic.MAX_TALENT];
        private Label[] restoration = new Label[TalentStatic.MAX_TALENT];

        public TalentForm() {
            InitializeComponent();

            txt_path0.TextChanged += Text_Change;
            txt_path1.TextChanged += Text_Change;
            txt_path2.TextChanged += Text_Change;
            txt_path3.TextChanged += Text_Change;

            txt_path0.KeyPress += Text_KeyPress;
            txt_path1.KeyPress += Text_KeyPress;
            txt_path2.KeyPress += Text_KeyPress;
            txt_path3.KeyPress += Text_KeyPress;

            int x = 30;
            int y = -3;

            var new_y = 110;
            var new_x = 0;

            for (int n = 0; n < TalentStatic.MAX_TALENT; n++) {
                balance[n] = new Label();
                physic[n] = new Label();
                magic[n] = new Label();
                restoration[n] = new Label();

                balance[n].MouseClick += Balance_Click;
                physic[n].MouseClick += Physic_Click;
                magic[n].MouseClick += Magic_Click;
                restoration[n].MouseClick += Restoration_Click;

                balance[n].Name = n.ToString();
                physic[n].Name = n.ToString();
                magic[n].Name = n.ToString();
                restoration[n].Name = n.ToString();

                balance[n].BackColor = Color.Transparent;
                physic[n].BackColor = Color.Transparent;
                magic[n].BackColor = Color.Transparent;
                restoration[n].BackColor = Color.Transparent;

                balance[n].Size = new Size(32, 32);
                physic[n].Size = new Size(32, 32);
                magic[n].Size = new Size(32, 32);
                restoration[n].Size = new Size(32, 32);

                if (n >= 4 & n < 8) { new_x = 4; new_y = 150; }
                if (n >= 8 & n < 12) { new_x = 8; new_y = 190; }
                if (n >= 12 & n < 16) { new_x = 12; new_y = 230; }
                if (n >= 16 & n < 20) { new_x = 16; new_y = 270; }
                if (n >= 20 & n < 24) { new_x = 20; new_y = 310; }

                balance[n].Location = new Point(x + +((n - new_x) * 38), y + new_y);
                physic[n].Location = new Point(x + 192 + ((n - new_x) * 38), y + new_y);
                magic[n].Location = new Point(x + 384 + ((n - new_x) * 38), y + new_y);
                restoration[n].Location = new Point(x + 576 + ((n - new_x) * 38), y + new_y);

                Controls.Add(balance[n]);
                Controls.Add(physic[n]);
                Controls.Add(magic[n]);
                Controls.Add(restoration[n]);
            }
        }

        /// <summary>
        /// Atualiza todos os ícones.
        /// </summary>
        public void UpdateIcons() {
            if (TalentStatic.SelectedClasse == -1) { return; }
            if (TalentStatic.Classes.Count == 0) { return; }

            int icon = 0;

            for (int n = 0; n < TalentStatic.MAX_TALENT; n++) {
                icon = TalentStatic.FindIconID(TalentStatic.Classes[TalentStatic.SelectedClasse].Balance[n]);
                balance[n].Image = EngineIcon.Icon[icon];

                icon = TalentStatic.FindIconID(TalentStatic.Classes[TalentStatic.SelectedClasse].Physic[n]);
                physic[n].Image = EngineIcon.Icon[icon];

                icon = TalentStatic.FindIconID(TalentStatic.Classes[TalentStatic.SelectedClasse].Magic[n]);
                magic[n].Image = EngineIcon.Icon[icon];

                icon = TalentStatic.FindIconID(TalentStatic.Classes[TalentStatic.SelectedClasse].Restoration[n]);
                restoration[n].Image = EngineIcon.Icon[icon];
            }
        }

        /// <summary>
        /// Atualiza um ícone.
        /// </summary>
        public void UpdateIcon() {
            var icon = 0;

            if (TalentStatic.SelectedType == 0) {
                icon = TalentStatic.FindIconID(TalentStatic.Classes[TalentStatic.SelectedClasse].Balance[TalentStatic.SelectedIndex]);
                balance[TalentStatic.SelectedIndex].Image = EngineIcon.Icon[icon];
                return;
            }

            if (TalentStatic.SelectedType == 1) {
                icon = TalentStatic.FindIconID(TalentStatic.Classes[TalentStatic.SelectedClasse].Physic[TalentStatic.SelectedIndex]);
                physic[TalentStatic.SelectedIndex].Image = EngineIcon.Icon[icon];
                return;
            }

            if (TalentStatic.SelectedType == 2) {
                icon = TalentStatic.FindIconID(TalentStatic.Classes[TalentStatic.SelectedClasse].Magic[TalentStatic.SelectedIndex]);
                magic[TalentStatic.SelectedIndex].Image = EngineIcon.Icon[icon];
                return;
            }

            if (TalentStatic.SelectedType == 3) {
                icon = TalentStatic.FindIconID(TalentStatic.Classes[TalentStatic.SelectedClasse].Restoration[TalentStatic.SelectedIndex]);
                restoration[TalentStatic.SelectedIndex].Image = EngineIcon.Icon[icon];
            }
        }

        /// <summary>
        /// Preenche toda a informação das classes na janela.
        /// </summary>
        private void FillData() {
            var index = TalentStatic.SelectedClasse;

            txt_path0.Text = TalentStatic.Classes[index].TalentName[0];
            txt_path1.Text = TalentStatic.Classes[index].TalentName[1];
            txt_path2.Text = TalentStatic.Classes[index].TalentName[2];
            txt_path3.Text = TalentStatic.Classes[index].TalentName[3];

            UpdateIcons();
        }

        /// <summary>
        /// Preenche o combobox quando o arquivo é aberto.
        /// </summary>
        private void FillComboBox() {
            cmb_classe.SelectedItem = string.Empty;
            cmb_classe.Items.Clear();
            var count = TalentStatic.Classes.Count;

            for (int n = 0; n < count; n++) {
                cmb_classe.Items.Add($"{TalentStatic.Classes[n].ClasseID}: {TalentStatic.Classes[n].ClasseName}");
            }
        }

        #region Labels
        private void Balance_Click(object sender, MouseEventArgs e) {
            TalentStatic.SelectedIndex = Convert.ToInt32(((Label)sender).Name);
            TalentStatic.SelectedType = 0;

            if (e.Button == MouseButtons.Left) {
                ShowSelectTalent();
            }

            if (e.Button == MouseButtons.Right) {
                RemoveTalent(0);
            }
        }

        private void Physic_Click(object sender, MouseEventArgs e) {
            TalentStatic.SelectedIndex = Convert.ToInt32(((Label)sender).Name);
            TalentStatic.SelectedType = 1;

            if (e.Button == MouseButtons.Left) {
                ShowSelectTalent();
            }

            if (e.Button == MouseButtons.Right) {
                RemoveTalent(1);
            }
        }

        private void Magic_Click(object sender, MouseEventArgs e) {
            TalentStatic.SelectedIndex = Convert.ToInt32(((Label)sender).Name);
            TalentStatic.SelectedType = 2;

            if (e.Button == MouseButtons.Left) {
                ShowSelectTalent();
            }

            if (e.Button == MouseButtons.Right) {
                RemoveTalent(2);
            }
        }

        private void Restoration_Click(object sender, MouseEventArgs e) {
            TalentStatic.SelectedIndex = Convert.ToInt32(((Label)sender).Name);
            TalentStatic.SelectedType = 3;

            if (e.Button == MouseButtons.Left) {
                ShowSelectTalent();
            }

            if (e.Button == MouseButtons.Right) {
                RemoveTalent(3);
            }
        }
        #endregion

        #region Remove / Select Talent
        private void ShowSelectTalent() {
            if (TalentStatic.ViewForm == null) {
                TalentStatic.ViewForm = new TalentView();
            }

            if (TalentStatic.ViewForm.IsDisposed) {
                TalentStatic.ViewForm = new TalentView();
            }

            TalentStatic.ViewForm.Show();
        }

        private void RemoveTalent(int type) {
            if (TalentStatic.SelectedClasse == -1) { return; }
            if (TalentStatic.Classes.Count == 0) { return; }

            if (type == 0) {
                TalentStatic.Classes[TalentStatic.SelectedClasse].Balance[TalentStatic.SelectedIndex] = 0;
                balance[TalentStatic.SelectedIndex].Image = null;
            }
            if (type == 1) {
                TalentStatic.Classes[TalentStatic.SelectedClasse].Physic[TalentStatic.SelectedIndex] = 0;
                physic[TalentStatic.SelectedIndex].Image = null;
            }
            if (type == 2) {
                TalentStatic.Classes[TalentStatic.SelectedClasse].Magic[TalentStatic.SelectedIndex] = 0;
                magic[TalentStatic.SelectedIndex].Image = null;
            }
            if (type == 3) {
                TalentStatic.Classes[TalentStatic.SelectedClasse].Restoration[TalentStatic.SelectedIndex] = 0;
                restoration[TalentStatic.SelectedIndex].Image = null;
            }
        }
        #endregion

        #region Textbox
        private void Text_Change(object sender, EventArgs e) {
            var type = Convert.ToInt32(((TextBox)sender).Name.Substring(8, 1));
            var text = ((TextBox)sender).Text;

            if (TalentStatic.SelectedClasse == -1) { return; }
            if (TalentStatic.Classes.Count == 0) { return; }

            TalentStatic.Classes[TalentStatic.SelectedClasse].TalentName[type] = text;
        }

        private void Text_KeyPress(object sender, KeyPressEventArgs e) {
            if (TalentStatic.SelectedClasse == -1 | TalentStatic.Classes.Count == 0)
                e.Handled = true;
        }

        #endregion

        #region ComboBox
        /// <summary>
        /// Atualiza o combobox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmb_classe_Click(object sender, EventArgs e) {
            if (cmb_classe.Items.Count == 0 | TalentStatic.NeedUpdate) {
                cmb_classe.SelectedItem = string.Empty;
                cmb_classe.Items.Clear();
                var count = TalentStatic.Classes.Count;

                for (int n = 0; n < count; n++) {
                    cmb_classe.Items.Add($"{TalentStatic.Classes[n].ClasseID}: {TalentStatic.Classes[n].ClasseName}");
                }

                TalentStatic.NeedUpdate = false;
            }
        }

        private void cmb_classe_SelectedIndexChanged(object sender, EventArgs e) {
            TalentStatic.SelectedClasse = cmb_classe.SelectedIndex;

            FillData();
        }
        #endregion

        #region Save / Open
        /// <summary>
        /// Salva todos os dados.
        /// </summary>
        private void SaveTalents() {
            using (FileStream file = new FileStream("Talent.bin", FileMode.Create, FileAccess.Write)) {
                BinaryWriter writer = new BinaryWriter(file);

                //guarda a quantidade de classes
                writer.Write(TalentStatic.Classes.Count);

                for (var n = 0; n < TalentStatic.Classes.Count; n++) {
                    writer.Write(TalentStatic.Classes[n].ClasseID);
                    writer.Write(TalentStatic.Classes[n].ClasseName);

                    for(var i = 0; i < TalentStatic.MAX_TALENT_NAME; i++) {
                        writer.Write(TalentStatic.Classes[n].TalentName[i]);
                    }

                    for (var j = 0; j < TalentStatic.MAX_TALENT; j++) {
                        writer.Write(TalentStatic.Classes[n].Balance[j]);
                        writer.Write(TalentStatic.Classes[n].Physic[j]);
                        writer.Write(TalentStatic.Classes[n].Magic[j]);
                        writer.Write(TalentStatic.Classes[n].Restoration[j]);
                    }
                }

                writer.Close();
            }
        }

        /// <summary>
        /// Carrega todos os dados.
        /// </summary>
        private void OpenTalents() {
            if (!File.Exists("Talent.bin")) {
                MessageBox.Show("Arquivo não encontrado", "Erro");
                return;
            }

            using (FileStream file = new FileStream("Talent.bin", FileMode.Open, FileAccess.Read)) {
                BinaryReader reader = new BinaryReader(file);

                //obtem a quantidade de classes
                var count = reader.ReadInt32(); 

                for (var n = 0; n < count; n++) {
                    TalentStatic.Classes.Add(new ClasseTalent(reader.ReadInt32(), reader.ReadString()));

                    for (var i = 0; i < TalentStatic.MAX_TALENT_NAME; i++) {
                        TalentStatic.Classes[n].TalentName[i] = reader.ReadString();
                    }

                    for (var j = 0; j < TalentStatic.MAX_TALENT; j++) {
                        TalentStatic.Classes[n].Balance[j] = reader.ReadInt32();
                        TalentStatic.Classes[n].Physic[j] = reader.ReadInt32();
                        TalentStatic.Classes[n].Magic[j] = reader.ReadInt32();
                        TalentStatic.Classes[n].Restoration[j] = reader.ReadInt32();
                    }
                }
                
                reader.Close();
            }
        }

        private void btn_open_Click(object sender, EventArgs e) {
            TalentStatic.Classes.Clear();

            OpenTalents();

            FillComboBox();
        }

        private void btn_save_Click(object sender, EventArgs e) {
            SaveTalents();
        }
        #endregion

        /// <summary>
        /// Gerenciamento das classes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_manage_Click(object sender, EventArgs e) {
            ManageClasse frm = new ManageClasse();
            frm.Show();
        }

        private void TalentForm_FormClosing(object sender, FormClosingEventArgs e) {
            TalentStatic.SelectedClasse = -1;
            TalentStatic.SelectedIndex = -1;
        }
    }
}
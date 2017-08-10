using System;
using System.Windows.Forms;
using System.IO;

namespace TextEditor.Talent {
    public sealed partial class TalentEdit : Form {
        /// <summary>
        /// Talento para edição.
        /// </summary>
        private TalentData talent;

        public TalentEdit() {
            InitializeComponent();
        }

        private void TalentEdit_Load(object sender, EventArgs e) {
            talent = new TalentData();
            BackgroundImage = EngineStatic.ViewTalent;
        }

        #region Create Data 
        /// <summary>
        /// Preenche o textbox com os dados do talento.
        /// </summary>
        private void FillTextbox() {
            txt_id.Text = talent.ID.ToString();
            txt_icon.Text = talent.IconID.ToString();
            txt_title.Text = talent.Title;
            txt_maxlevel.Text = talent.MaxLevel.ToString();
            txt_desc.Text = talent.Description;
            txt_reqid.Text = talent.ReqTalentID.ToString();
            txt_reqlevel.Text = talent.ReqTalentLevel.ToString();

            var count = talent.Effect.Count;
            for (var n = 0; n < count; n++) list_effect.Items.Add($"Effect{n}: {talent.Effect[n]}");
        }

        /// <summary>
        /// Preenche o talento com os dados do textbox.
        /// </summary>
        private void FillTalent() {
            talent.ID = Convert.ToInt32(txt_id.Text.Trim());
            talent.IconID = Convert.ToInt32(txt_icon.Text.Trim());
            talent.Title = txt_title.Text.Trim();
            talent.MaxLevel = Convert.ToInt32(txt_maxlevel.Text.Trim());
            talent.Description =  txt_desc.Text.Trim();
            talent.ReqTalentID = Convert.ToInt32(txt_reqid.Text.Trim());
            talent.ReqTalentLevel = Convert.ToInt32(txt_reqlevel.Text.Trim());
        }
        #endregion

        private void txt_icon_TextChanged(object sender, EventArgs e) {
            var value = 0;
            var result = int.TryParse(txt_icon.Text.Trim(), out value);

            if (value == 0 || value >= EngineIcon.Icon.Count) {
                lbl_icon.Image = null;
                return;
            }
     
            if (result) {
                lbl_icon.Image = EngineIcon.Icon[value];
            }
            else {
                lbl_icon.Image = null;
            }
        }

        private void txt_title_TextChanged(object sender, EventArgs e) {
            lbl_title.Text = txt_title.Text.Trim();
        }

        private void txt_reqlevel_TextChanged(object sender, EventArgs e) {
            lbl_req_level.Text = $"Nome do talento Lv. {txt_reqlevel.Text.Trim()}";
        }

        private void txt_maxlevel_TextChanged(object sender, EventArgs e) {
            var value = 0;
            var result = int.TryParse(txt_maxlevel.Text.Trim(), out value);

            if (result) {
                lbl_level.Text = "Level 1/" + value;
            } else {
                lbl_level.Text = "Level 1/1";
            }
        }

        private void txt_desc_TextChanged(object sender, EventArgs e) {
            ChangeDescription();
        }

        private void txt_effect_TextChanged(object sender, EventArgs e) {
            ChangeDescription();
        }

        /// <summary>
        /// Troca as palavras 'effect' pelo valor do efeito.
        /// </summary>
        private void ChangeDescription() {
            var count = talent.Effect.Count;
            var text = txt_desc.Text.Trim();
            
            if (count > 0) {
                for (var n = 0; n < count; n++) {
                    text = text.Replace($"'effect{n}'", talent.Effect[n].ToString());
                }
            }

            lbl_desc.Text = text;
        }

        #region Open & Save Talent 
        private void btn_save_Click(object sender, EventArgs e) {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Talent Files (*.talent) | *.talent";
            dialog.InitialDirectory = Environment.CurrentDirectory + "\\Talent\\";
            var result = dialog.ShowDialog();

            if (result == DialogResult.Cancel) return;

            FillTalent();

            Save(dialog.FileName);

            //adciona o talent à lista.
            var talent_info = new TalentInfo();
            talent_info.ID = talent.ID;
            talent_info.IconID = talent.IconID;
            talent_info.Title = talent.Title;

            TalentStatic.Talents.Add(talent_info);
        }

        private void btn_open_Click(object sender, EventArgs e) {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Talent Files (*.talent) | *.talent";
            dialog.InitialDirectory = Environment.CurrentDirectory + "\\Talent\\";
            var result = dialog.ShowDialog();

            if (result == DialogResult.Cancel) return;

            Open(dialog.FileName);

            //atualiza lista
            FillTextbox();
        }

        /// <summary>
        /// Abre um talento.
        /// </summary>
        /// <param name="path"></param>
        private void Open(string path) {
            if (!File.Exists(path)) return;

            using (FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read)) {
                BinaryReader reader = new BinaryReader(file);

                talent.ID = reader.ReadInt32();
                talent.IconID = reader.ReadInt32();
                talent.Title = reader.ReadString();
                talent.Description = reader.ReadString();
                talent.MaxLevel = reader.ReadInt32();
                talent.ReqTalentID = reader.ReadInt32();
                talent.ReqTalentLevel = reader.ReadInt32();
                var count = reader.ReadInt32();
                for (var n = 0; n < count; n++) talent.Effect.Add(reader.ReadInt32());

                reader.Close();
            }
        }

        /// <summary>
        /// Salva os dados no arquivo.
        /// </summary>
        /// <param name="path"></param>
        private void Save(string path) {
            using (FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write)) {
                BinaryWriter writer = new BinaryWriter(file);

                writer.Write(talent.ID);
                writer.Write(talent.IconID);
                writer.Write(talent.Title);
                writer.Write(talent.Description);
                writer.Write(talent.MaxLevel);
                writer.Write(talent.ReqTalentID);
                writer.Write(talent.ReqTalentLevel);
                writer.Write(talent.Effect.Count);

                var count = talent.Effect.Count;
                for (var n = 0; n < count; n++)  writer.Write(talent.Effect[n]); 

                writer.Close();
            }
        }
    
        #endregion

        #region List Effect
        /// <summary>
        /// Limpa a lista.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_effect_clear_Click(object sender, EventArgs e) {
            talent.Effect.Clear();
            list_effect.Items.Clear();
        }

        /// <summary>
        /// Remove um item da lista.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_effect_remove_Click(object sender, EventArgs e) {
            var index = list_effect.SelectedIndex;
            if (index == -1) return;

            list_effect.Items.RemoveAt(index);
            talent.Effect.RemoveAt(index);
        }

        /// <summary>
        /// Adiciona o valor à lista.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_effect_add_Click(object sender, EventArgs e) {
            var value = 0;
            var result = int.TryParse(txt_effect.Text.Trim(), out value);

            if (!result) return;

            talent.Effect.Add(value);
            list_effect.Items.Add($"Effect{talent.Effect.Count - 1}: {value}");
        }
        #endregion
    }
}
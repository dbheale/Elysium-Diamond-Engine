using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TextEditor {
    public partial class ItemForm : Form {
        public ItemForm() {
            InitializeComponent();

            for (var i = 1; i <= 16; i++) {
                ((Label)Controls["lbl_stat" + i]).Click += label_Click;
            }
        }

        byte selected_stat = 1;

        private void ItemForm_Load(object sender, EventArgs e) {

        }        

        private void txt_name_TextChanged(object sender, EventArgs e) {
            lbl_name.Text = txt_name.Text.Trim();
        }

        private void txt_durability_TextChanged(object sender, EventArgs e) {
            var value = txt_durability.Text;
            lbl_durability.Text = $"Durabilidade {value} / {value}";
        }

        private void txt_level_TextChanged(object sender, EventArgs e) {
            var level = txt_level.Text;
            lbl_level.Text = $"Pode ser usado no level {level}";
        }

        private void c_soul_CheckedChanged(object sender, EventArgs e) {
            var value = c_soul.Checked;

            if (value) {
                lbl_bound.Text = "Item ligado ao personagem";
            }
            else {
                lbl_bound.Text = "Item não ligado ao personagem";
            }
        }

        private void c_trade_CheckedChanged(object sender, EventArgs e) {
            var value = c_trade.Checked;

            if (value) {
                lbl_tradeable.Text = "Negociável";
            }
            else {
                lbl_tradeable.Text = "Inegociável";
            }
        }

        private void cmb_type_SelectedIndexChanged(object sender, EventArgs e) {
            var result = (ItemType)cmb_type.SelectedIndex;
            var text = string.Empty;

            if (result == ItemType.Weapon) text = "Arma";
            if (result == ItemType.Shield) text = "Escudo";
            if (result == ItemType.Gloves) text = "Luva";
            if (result == ItemType.Shoulder) text = "Ombro";
            if (result == ItemType.Chest) text = "Peito";
            if (result == ItemType.Pants) text = "Calça";
            if (result == ItemType.Legs) text = "Bota";
            if (result == ItemType.Belt) text = "Cinto";
            if (result == ItemType.Necklace) text = "Amuleto";
            if (result == ItemType.Earring) text = "Brinco";
            if (result == ItemType.Ring) text = "Anel";

            lbl_type.Text = text;
        }

        private void cmb_rarity_SelectedIndexChanged(object sender, EventArgs e) {
            var result = (ItemRarity)cmb_rarity.SelectedIndex;
            var text = string.Empty;
            var color = Color.White;

            if (result == ItemRarity.Poor) { text = "Baixa qualidade"; color = Color.DimGray; }
            if (result == ItemRarity.Common) { text = "Comum"; color = Color.White; }
            if (result == ItemRarity.Uncommon) { text = "Incomum"; color = Color.SpringGreen; }
            if (result == ItemRarity.Rare) { text = "Raro"; color = Color.RoyalBlue; }
            if (result == ItemRarity.Epic) { text = "Épico"; color = Color.MediumVioletRed ; }
            if (result == ItemRarity.Legendary) {  text = "Lendário"; color = Color.Orange; }
            if (result == ItemRarity.Mythic) { text = "Mítico";  color = Color.Indigo; }
            if (result == ItemRarity.Artifact) { text = "Artefato"; color = Color.Salmon; }
            if (result == ItemRarity.Ethereal) { text = "Etéreo"; color = Color.Crimson; }

            lbl_rarity.Text = text;
            lbl_name.ForeColor = color;
        }

        private void cmb_hand_SelectedIndexChanged(object sender, EventArgs e) {
            var result = (ItemHand)cmb_hand.SelectedIndex;
            var text = string.Empty;

            if (result == ItemHand.OneHanded) text = "Item de uma mão";
            if (result == ItemHand.TwoHanded) text = "Item de duas mãos";

            lbl_hand.Text = text;
        }

        private void c_showline_CheckedChanged(object sender, EventArgs e) {
            ShowLine(c_showline.Checked);
        }

        /// <summary>
        /// Ativa a borda das label de stats.
        /// </summary>
        /// <param name="show"></param>
        private void ShowLine(bool show) {
            var border = (show == true) ? BorderStyle.FixedSingle : BorderStyle.None;
            
            for (var i = 1; i <= 16; i++) {
                ((Label)Controls["lbl_stat" + i]).BorderStyle = border;
            }
        }

        private void label_Click(object sender, EventArgs e) {
            selected_stat = Convert.ToByte(((Label)sender).Name.Replace("lbl_stat", ""));

            lbl_line.Text = $"Line: {selected_stat}";
            txt_stat.Text = ((Label)sender).Text;
        }

        private void txt_stat_TextChanged(object sender, EventArgs e) {
            ((Label)Controls["lbl_stat" + selected_stat]).Text = txt_stat.Text;
        }

        private void SaveItem(string binaryfile) {
            using (FileStream file = new FileStream(binaryfile, FileMode.Create, FileAccess.Write)) {
                BinaryWriter writer = new BinaryWriter(file);

                var id = Convert.ToInt32(txt_id.Text.Trim());
                var icon = Convert.ToInt32(txt_icon.Text.Trim());
                var name = txt_name.Text.Trim();
                var durability = Convert.ToInt16(txt_durability.Text.Trim());
                var level = Convert.ToInt32(txt_level.Text.Trim());
                var type = (byte)cmb_type.SelectedIndex;
                var rarity = (byte)cmb_rarity.SelectedIndex;
                var hand = (byte)cmb_hand.SelectedIndex;
                var soulbound = c_soul.Checked;
                var tradeable = c_trade.Checked;

                writer.Write(id);
                writer.Write(icon);
                writer.Write(name);
                writer.Write(durability);
                writer.Write(level);
                writer.Write(type);
                writer.Write(rarity);
                writer.Write(hand);
                writer.Write(soulbound);
                writer.Write(tradeable);

                for (var i = 1; i <= 16; i++) {
                    writer.Write(((Label)Controls["lbl_stat" + i]).Text);
                }

                writer.Close();
            }
        }

        private void OpenItem(string binaryfile) {
            if (!File.Exists(binaryfile)) return;

            using (FileStream file = new FileStream(binaryfile, FileMode.Open, FileAccess.Read)) {
                BinaryReader reader = new BinaryReader(file);

                txt_id.Text = reader.ReadInt32().ToString();
                txt_icon.Text = reader.ReadInt32().ToString();
                txt_name.Text = reader.ReadString();
                txt_durability.Text = reader.ReadInt16().ToString();
                txt_level.Text = reader.ReadInt32().ToString();
                cmb_type.SelectedIndex = reader.ReadByte();
                cmb_rarity.SelectedIndex = reader.ReadByte();
                cmb_hand.SelectedIndex = reader.ReadByte();
                c_soul.Checked = reader.ReadBoolean();
                c_trade.Checked = reader.ReadBoolean();

                for (var i = 1; i <= 16; i++) {
                    ((Label)Controls["lbl_stat" + i]).Text = reader.ReadString();
                }

                reader.Close();
            }
        }

        private void btn_save_Click(object sender, EventArgs e) {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Item Files (*.item) | *.item";
            dialog.InitialDirectory = Environment.CurrentDirectory + "\\Items\\";
            var result = dialog.ShowDialog();

            if (result == DialogResult.Cancel) return;

            SaveItem(dialog.FileName);
        }

        private void btn_open_Click(object sender, EventArgs e) {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Item Files (*.item) | *.item";
            dialog.InitialDirectory = Environment.CurrentDirectory + "\\Items\\";
            var result = dialog.ShowDialog();

            if (result == DialogResult.Cancel) return;

            OpenItem(dialog.FileName);
        }
    }
}

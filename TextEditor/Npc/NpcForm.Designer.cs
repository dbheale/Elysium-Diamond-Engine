namespace TextEditor {
    partial class NpcForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.btn_add = new System.Windows.Forms.Button();
            this.txt_unique = new System.Windows.Forms.TextBox();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.txt_sprite = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_level = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btn_open = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_remove = new System.Windows.Forms.Button();
            this.cmb_elite = new System.Windows.Forms.ComboBox();
            this.cmb_type = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btn_add
            // 
            this.btn_add.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.btn_add.Location = new System.Drawing.Point(16, 167);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(92, 23);
            this.btn_add.TabIndex = 0;
            this.btn_add.Text = "Add";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // txt_unique
            // 
            this.txt_unique.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.txt_unique.Location = new System.Drawing.Point(93, 13);
            this.txt_unique.Name = "txt_unique";
            this.txt_unique.Size = new System.Drawing.Size(145, 23);
            this.txt_unique.TabIndex = 1;
            this.txt_unique.Text = "0";
            // 
            // txt_name
            // 
            this.txt_name.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.txt_name.Location = new System.Drawing.Point(93, 38);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(145, 23);
            this.txt_name.TabIndex = 2;
            // 
            // txt_sprite
            // 
            this.txt_sprite.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.txt_sprite.Location = new System.Drawing.Point(93, 63);
            this.txt_sprite.Name = "txt_sprite";
            this.txt_sprite.Size = new System.Drawing.Size(145, 23);
            this.txt_sprite.TabIndex = 3;
            this.txt_sprite.Text = "0";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "Unique ID";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(12, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 19);
            this.label2.TabIndex = 6;
            this.label2.Text = "Name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(12, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 19);
            this.label3.TabIndex = 7;
            this.label3.Text = "Sprite";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(12, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 19);
            this.label4.TabIndex = 8;
            this.label4.Text = "Type";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(12, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 19);
            this.label5.TabIndex = 10;
            this.label5.Text = "Elite";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(12, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 19);
            this.label6.TabIndex = 12;
            this.label6.Text = "Level";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_level
            // 
            this.txt_level.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.txt_level.Location = new System.Drawing.Point(93, 138);
            this.txt_level.Name = "txt_level";
            this.txt_level.Size = new System.Drawing.Size(145, 23);
            this.txt_level.TabIndex = 11;
            this.txt_level.Text = "0";
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(16, 196);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(226, 229);
            this.listBox1.TabIndex = 13;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // btn_open
            // 
            this.btn_open.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.btn_open.Location = new System.Drawing.Point(16, 463);
            this.btn_open.Name = "btn_open";
            this.btn_open.Size = new System.Drawing.Size(92, 23);
            this.btn_open.TabIndex = 14;
            this.btn_open.Text = "Open File";
            this.btn_open.UseVisualStyleBackColor = true;
            this.btn_open.Click += new System.EventHandler(this.btn_open_Click);
            // 
            // btn_save
            // 
            this.btn_save.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.btn_save.Location = new System.Drawing.Point(150, 463);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(92, 23);
            this.btn_save.TabIndex = 15;
            this.btn_save.Text = "Save File";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_update
            // 
            this.btn_update.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.btn_update.Location = new System.Drawing.Point(150, 167);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(92, 23);
            this.btn_update.TabIndex = 16;
            this.btn_update.Text = "Update";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_remove
            // 
            this.btn_remove.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.btn_remove.Location = new System.Drawing.Point(16, 434);
            this.btn_remove.Name = "btn_remove";
            this.btn_remove.Size = new System.Drawing.Size(226, 23);
            this.btn_remove.TabIndex = 17;
            this.btn_remove.Text = "Remove Npc";
            this.btn_remove.UseVisualStyleBackColor = true;
            this.btn_remove.Click += new System.EventHandler(this.btn_remove_Click);
            // 
            // cmb_elite
            // 
            this.cmb_elite.FormattingEnabled = true;
            this.cmb_elite.Items.AddRange(new object[] {
            "Normal",
            "Soldier",
            "Elite",
            "Army",
            "Boss"});
            this.cmb_elite.Location = new System.Drawing.Point(93, 114);
            this.cmb_elite.Name = "cmb_elite";
            this.cmb_elite.Size = new System.Drawing.Size(145, 20);
            this.cmb_elite.TabIndex = 18;
            // 
            // cmb_type
            // 
            this.cmb_type.FormattingEnabled = true;
            this.cmb_type.Items.AddRange(new object[] {
            "Citizen",
            "Monster",
            "Guardian",
            "Patrol"});
            this.cmb_type.Location = new System.Drawing.Point(93, 90);
            this.cmb_type.Name = "cmb_type";
            this.cmb_type.Size = new System.Drawing.Size(145, 20);
            this.cmb_type.TabIndex = 19;
            // 
            // NpcForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 494);
            this.Controls.Add(this.cmb_type);
            this.Controls.Add(this.cmb_elite);
            this.Controls.Add(this.btn_remove);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_open);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_level);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_sprite);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.txt_unique);
            this.Controls.Add(this.btn_add);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "NpcForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Old ID: 0";
            this.Load += new System.EventHandler(this.NpcForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.TextBox txt_unique;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.TextBox txt_sprite;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_level;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btn_open;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_remove;
        private System.Windows.Forms.ComboBox cmb_elite;
        private System.Windows.Forms.ComboBox cmb_type;
    }
}
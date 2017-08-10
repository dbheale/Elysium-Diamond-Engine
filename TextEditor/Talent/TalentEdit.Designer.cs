namespace TextEditor.Talent {
    sealed partial class TalentEdit {
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
            this.lbl_title = new System.Windows.Forms.Label();
            this.lbl_desc = new System.Windows.Forms.Label();
            this.lbl_level = new System.Windows.Forms.Label();
            this.lbl_title_ = new System.Windows.Forms.Label();
            this.txt_title = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_maxlevel = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_desc = new System.Windows.Forms.TextBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.txt_effect = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_icon = new System.Windows.Forms.TextBox();
            this.lbl_icon = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_reqid = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_reqlevel = new System.Windows.Forms.TextBox();
            this.lbl_id = new System.Windows.Forms.Label();
            this.txt_id = new System.Windows.Forms.TextBox();
            this.btn_open = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_effect_add = new System.Windows.Forms.Button();
            this.list_effect = new System.Windows.Forms.ListBox();
            this.btn_effect_remove = new System.Windows.Forms.Button();
            this.btn_effect_clear = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_req_level = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_title
            // 
            this.lbl_title.BackColor = System.Drawing.Color.Transparent;
            this.lbl_title.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_title.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_title.ForeColor = System.Drawing.Color.White;
            this.lbl_title.Location = new System.Drawing.Point(12, 9);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(299, 20);
            this.lbl_title.TabIndex = 1;
            this.lbl_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_desc
            // 
            this.lbl_desc.BackColor = System.Drawing.Color.Transparent;
            this.lbl_desc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_desc.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_desc.ForeColor = System.Drawing.Color.White;
            this.lbl_desc.Location = new System.Drawing.Point(12, 69);
            this.lbl_desc.Name = "lbl_desc";
            this.lbl_desc.Size = new System.Drawing.Size(299, 110);
            this.lbl_desc.TabIndex = 2;
            // 
            // lbl_level
            // 
            this.lbl_level.BackColor = System.Drawing.Color.Transparent;
            this.lbl_level.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_level.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_level.ForeColor = System.Drawing.Color.White;
            this.lbl_level.Location = new System.Drawing.Point(12, 29);
            this.lbl_level.Name = "lbl_level";
            this.lbl_level.Size = new System.Drawing.Size(299, 20);
            this.lbl_level.TabIndex = 3;
            this.lbl_level.Text = "Level 1/1";
            this.lbl_level.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_title_
            // 
            this.lbl_title_.Font = new System.Drawing.Font("Open Sans", 9F);
            this.lbl_title_.Location = new System.Drawing.Point(331, 59);
            this.lbl_title_.Name = "lbl_title_";
            this.lbl_title_.Size = new System.Drawing.Size(98, 20);
            this.lbl_title_.TabIndex = 130;
            this.lbl_title_.Text = "Title";
            this.lbl_title_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_title
            // 
            this.txt_title.Font = new System.Drawing.Font("Open Sans", 9F);
            this.txt_title.Location = new System.Drawing.Point(334, 82);
            this.txt_title.Name = "txt_title";
            this.txt_title.Size = new System.Drawing.Size(201, 24);
            this.txt_title.TabIndex = 129;
            this.txt_title.TextChanged += new System.EventHandler(this.txt_title_TextChanged);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Open Sans", 9F);
            this.label5.Location = new System.Drawing.Point(331, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 20);
            this.label5.TabIndex = 132;
            this.label5.Text = "Max Level";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_maxlevel
            // 
            this.txt_maxlevel.Font = new System.Drawing.Font("Open Sans", 9F);
            this.txt_maxlevel.Location = new System.Drawing.Point(334, 132);
            this.txt_maxlevel.Name = "txt_maxlevel";
            this.txt_maxlevel.Size = new System.Drawing.Size(201, 24);
            this.txt_maxlevel.TabIndex = 131;
            this.txt_maxlevel.Text = "1";
            this.txt_maxlevel.TextChanged += new System.EventHandler(this.txt_maxlevel_TextChanged);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Open Sans", 9F);
            this.label6.Location = new System.Drawing.Point(334, 209);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 20);
            this.label6.TabIndex = 134;
            this.label6.Text = "Description";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_desc
            // 
            this.txt_desc.Font = new System.Drawing.Font("Open Sans", 9F);
            this.txt_desc.Location = new System.Drawing.Point(337, 232);
            this.txt_desc.Multiline = true;
            this.txt_desc.Name = "txt_desc";
            this.txt_desc.Size = new System.Drawing.Size(201, 70);
            this.txt_desc.TabIndex = 133;
            this.txt_desc.TextChanged += new System.EventHandler(this.txt_desc_TextChanged);
            // 
            // btn_save
            // 
            this.btn_save.Font = new System.Drawing.Font("Open Sans", 9F);
            this.btn_save.Location = new System.Drawing.Point(455, 308);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(84, 23);
            this.btn_save.TabIndex = 135;
            this.btn_save.Text = "Save Talent";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // txt_effect
            // 
            this.txt_effect.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_effect.Location = new System.Drawing.Point(552, 29);
            this.txt_effect.Name = "txt_effect";
            this.txt_effect.Size = new System.Drawing.Size(175, 24);
            this.txt_effect.TabIndex = 136;
            this.txt_effect.Text = "0";
            this.txt_effect.TextChanged += new System.EventHandler(this.txt_effect_TextChanged);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Open Sans", 9F);
            this.label7.Location = new System.Drawing.Point(550, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 20);
            this.label7.TabIndex = 137;
            this.label7.Text = "Effect";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Open Sans", 9F);
            this.label1.Location = new System.Drawing.Point(398, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 143;
            this.label1.Text = "Icon";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_icon
            // 
            this.txt_icon.Font = new System.Drawing.Font("Open Sans", 9F);
            this.txt_icon.Location = new System.Drawing.Point(401, 32);
            this.txt_icon.Name = "txt_icon";
            this.txt_icon.Size = new System.Drawing.Size(48, 24);
            this.txt_icon.TabIndex = 142;
            this.txt_icon.Text = "0";
            this.txt_icon.TextChanged += new System.EventHandler(this.txt_icon_TextChanged);
            // 
            // lbl_icon
            // 
            this.lbl_icon.BackColor = System.Drawing.Color.Transparent;
            this.lbl_icon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_icon.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_icon.ForeColor = System.Drawing.Color.White;
            this.lbl_icon.Location = new System.Drawing.Point(455, 27);
            this.lbl_icon.Name = "lbl_icon";
            this.lbl_icon.Size = new System.Drawing.Size(32, 32);
            this.lbl_icon.TabIndex = 144;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Open Sans", 9F);
            this.label4.Location = new System.Drawing.Point(333, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 20);
            this.label4.TabIndex = 148;
            this.label4.Text = "Req Talent ID";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_reqid
            // 
            this.txt_reqid.Font = new System.Drawing.Font("Open Sans", 9F);
            this.txt_reqid.Location = new System.Drawing.Point(336, 182);
            this.txt_reqid.Name = "txt_reqid";
            this.txt_reqid.Size = new System.Drawing.Size(81, 24);
            this.txt_reqid.TabIndex = 147;
            this.txt_reqid.Text = "0";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Open Sans", 9F);
            this.label8.Location = new System.Drawing.Point(420, 159);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 20);
            this.label8.TabIndex = 150;
            this.label8.Text = "Req Talent Level";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_reqlevel
            // 
            this.txt_reqlevel.Font = new System.Drawing.Font("Open Sans", 9F);
            this.txt_reqlevel.Location = new System.Drawing.Point(423, 182);
            this.txt_reqlevel.Name = "txt_reqlevel";
            this.txt_reqlevel.Size = new System.Drawing.Size(81, 24);
            this.txt_reqlevel.TabIndex = 149;
            this.txt_reqlevel.Text = "0";
            this.txt_reqlevel.TextChanged += new System.EventHandler(this.txt_reqlevel_TextChanged);
            // 
            // lbl_id
            // 
            this.lbl_id.Font = new System.Drawing.Font("Open Sans", 9F);
            this.lbl_id.Location = new System.Drawing.Point(331, 9);
            this.lbl_id.Name = "lbl_id";
            this.lbl_id.Size = new System.Drawing.Size(50, 20);
            this.lbl_id.TabIndex = 153;
            this.lbl_id.Text = "ID";
            this.lbl_id.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_id
            // 
            this.txt_id.Font = new System.Drawing.Font("Open Sans", 9F);
            this.txt_id.Location = new System.Drawing.Point(334, 32);
            this.txt_id.Name = "txt_id";
            this.txt_id.Size = new System.Drawing.Size(47, 24);
            this.txt_id.TabIndex = 152;
            this.txt_id.Text = "0";
            // 
            // btn_open
            // 
            this.btn_open.Font = new System.Drawing.Font("Open Sans", 9F);
            this.btn_open.Location = new System.Drawing.Point(337, 308);
            this.btn_open.Name = "btn_open";
            this.btn_open.Size = new System.Drawing.Size(84, 23);
            this.btn_open.TabIndex = 154;
            this.btn_open.Text = "Open Talent";
            this.btn_open.UseVisualStyleBackColor = true;
            this.btn_open.Click += new System.EventHandler(this.btn_open_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Open Sans", 9F);
            this.label2.Location = new System.Drawing.Point(550, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 20);
            this.label2.TabIndex = 158;
            this.label2.Text = "Effect List";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_effect_add
            // 
            this.btn_effect_add.Font = new System.Drawing.Font("Open Sans", 9F);
            this.btn_effect_add.Location = new System.Drawing.Point(554, 307);
            this.btn_effect_add.Name = "btn_effect_add";
            this.btn_effect_add.Size = new System.Drawing.Size(49, 24);
            this.btn_effect_add.TabIndex = 159;
            this.btn_effect_add.Text = "Add";
            this.btn_effect_add.UseVisualStyleBackColor = true;
            this.btn_effect_add.Click += new System.EventHandler(this.btn_effect_add_Click);
            // 
            // list_effect
            // 
            this.list_effect.Font = new System.Drawing.Font("Open Sans", 9F);
            this.list_effect.FormattingEnabled = true;
            this.list_effect.ItemHeight = 17;
            this.list_effect.Location = new System.Drawing.Point(552, 82);
            this.list_effect.Name = "list_effect";
            this.list_effect.Size = new System.Drawing.Size(175, 208);
            this.list_effect.TabIndex = 160;
            // 
            // btn_effect_remove
            // 
            this.btn_effect_remove.Font = new System.Drawing.Font("Open Sans", 9F);
            this.btn_effect_remove.Location = new System.Drawing.Point(609, 307);
            this.btn_effect_remove.Name = "btn_effect_remove";
            this.btn_effect_remove.Size = new System.Drawing.Size(63, 24);
            this.btn_effect_remove.TabIndex = 161;
            this.btn_effect_remove.Text = "Remove";
            this.btn_effect_remove.UseVisualStyleBackColor = true;
            this.btn_effect_remove.Click += new System.EventHandler(this.btn_effect_remove_Click);
            // 
            // btn_effect_clear
            // 
            this.btn_effect_clear.Font = new System.Drawing.Font("Open Sans", 9F);
            this.btn_effect_clear.Location = new System.Drawing.Point(678, 307);
            this.btn_effect_clear.Name = "btn_effect_clear";
            this.btn_effect_clear.Size = new System.Drawing.Size(49, 24);
            this.btn_effect_clear.TabIndex = 162;
            this.btn_effect_clear.Text = "Clear";
            this.btn_effect_clear.UseVisualStyleBackColor = true;
            this.btn_effect_clear.Click += new System.EventHandler(this.btn_effect_clear_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(299, 20);
            this.label3.TabIndex = 163;
            this.label3.Text = "Requerimento";
            // 
            // lbl_req_level
            // 
            this.lbl_req_level.BackColor = System.Drawing.Color.Transparent;
            this.lbl_req_level.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_req_level.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_req_level.ForeColor = System.Drawing.Color.White;
            this.lbl_req_level.Location = new System.Drawing.Point(12, 158);
            this.lbl_req_level.Name = "lbl_req_level";
            this.lbl_req_level.Size = new System.Drawing.Size(299, 20);
            this.lbl_req_level.TabIndex = 164;
            this.lbl_req_level.Text = "Nome do talento Lv. 0";
            // 
            // TalentEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(747, 348);
            this.Controls.Add(this.lbl_req_level);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_effect_clear);
            this.Controls.Add(this.btn_effect_remove);
            this.Controls.Add(this.list_effect);
            this.Controls.Add(this.btn_effect_add);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_open);
            this.Controls.Add(this.lbl_id);
            this.Controls.Add(this.txt_id);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_reqlevel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_reqid);
            this.Controls.Add(this.lbl_icon);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_icon);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_effect);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_desc);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_maxlevel);
            this.Controls.Add(this.lbl_title_);
            this.Controls.Add(this.txt_title);
            this.Controls.Add(this.lbl_level);
            this.Controls.Add(this.lbl_desc);
            this.Controls.Add(this.lbl_title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "TalentEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TalentEdit";
            this.Load += new System.EventHandler(this.TalentEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Label lbl_desc;
        private System.Windows.Forms.Label lbl_level;
        private System.Windows.Forms.Label lbl_title_;
        private System.Windows.Forms.TextBox txt_title;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_maxlevel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_desc;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.TextBox txt_effect;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_icon;
        private System.Windows.Forms.Label lbl_icon;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_reqid;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_reqlevel;
        private System.Windows.Forms.Label lbl_id;
        private System.Windows.Forms.TextBox txt_id;
        private System.Windows.Forms.Button btn_open;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_effect_add;
        private System.Windows.Forms.ListBox list_effect;
        private System.Windows.Forms.Button btn_effect_remove;
        private System.Windows.Forms.Button btn_effect_clear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_req_level;
    }
}
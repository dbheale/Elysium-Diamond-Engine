namespace TextEditor.Talent {
    sealed partial class TalentForm {
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
            this.btn_open = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.txt_path0 = new System.Windows.Forms.TextBox();
            this.txt_path1 = new System.Windows.Forms.TextBox();
            this.txt_path2 = new System.Windows.Forms.TextBox();
            this.txt_path3 = new System.Windows.Forms.TextBox();
            this.cmb_classe = new System.Windows.Forms.ComboBox();
            this.btn_manage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_open
            // 
            this.btn_open.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_open.Location = new System.Drawing.Point(15, 8);
            this.btn_open.Name = "btn_open";
            this.btn_open.Size = new System.Drawing.Size(50, 26);
            this.btn_open.TabIndex = 0;
            this.btn_open.Text = "Open";
            this.btn_open.UseVisualStyleBackColor = true;
            this.btn_open.Click += new System.EventHandler(this.btn_open_Click);
            // 
            // btn_save
            // 
            this.btn_save.Font = new System.Drawing.Font("Open Sans", 9F);
            this.btn_save.Location = new System.Drawing.Point(71, 8);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(50, 26);
            this.btn_save.TabIndex = 1;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // txt_path0
            // 
            this.txt_path0.Font = new System.Drawing.Font("Open Sans", 9F);
            this.txt_path0.Location = new System.Drawing.Point(51, 60);
            this.txt_path0.Name = "txt_path0";
            this.txt_path0.Size = new System.Drawing.Size(100, 24);
            this.txt_path0.TabIndex = 2;
            this.txt_path0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_path1
            // 
            this.txt_path1.Font = new System.Drawing.Font("Open Sans", 9F);
            this.txt_path1.Location = new System.Drawing.Point(246, 60);
            this.txt_path1.Name = "txt_path1";
            this.txt_path1.Size = new System.Drawing.Size(100, 24);
            this.txt_path1.TabIndex = 3;
            this.txt_path1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_path2
            // 
            this.txt_path2.Font = new System.Drawing.Font("Open Sans", 9F);
            this.txt_path2.Location = new System.Drawing.Point(434, 60);
            this.txt_path2.Name = "txt_path2";
            this.txt_path2.Size = new System.Drawing.Size(100, 24);
            this.txt_path2.TabIndex = 4;
            this.txt_path2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_path3
            // 
            this.txt_path3.Font = new System.Drawing.Font("Open Sans", 9F);
            this.txt_path3.Location = new System.Drawing.Point(630, 60);
            this.txt_path3.Name = "txt_path3";
            this.txt_path3.Size = new System.Drawing.Size(100, 24);
            this.txt_path3.TabIndex = 5;
            this.txt_path3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmb_classe
            // 
            this.cmb_classe.Font = new System.Drawing.Font("Open Sans", 9F);
            this.cmb_classe.FormattingEnabled = true;
            this.cmb_classe.Location = new System.Drawing.Point(284, 8);
            this.cmb_classe.Name = "cmb_classe";
            this.cmb_classe.Size = new System.Drawing.Size(207, 25);
            this.cmb_classe.TabIndex = 6;
            this.cmb_classe.SelectedIndexChanged += new System.EventHandler(this.cmb_classe_SelectedIndexChanged);
            this.cmb_classe.Click += new System.EventHandler(this.cmb_classe_Click);
            // 
            // btn_manage
            // 
            this.btn_manage.Font = new System.Drawing.Font("Open Sans", 9F);
            this.btn_manage.Location = new System.Drawing.Point(635, 8);
            this.btn_manage.Name = "btn_manage";
            this.btn_manage.Size = new System.Drawing.Size(118, 26);
            this.btn_manage.TabIndex = 7;
            this.btn_manage.Text = "Manage Classe";
            this.btn_manage.UseVisualStyleBackColor = true;
            this.btn_manage.Click += new System.EventHandler(this.btn_manage_Click);
            // 
            // TalentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TextEditor.Properties.Resources.talent;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(780, 377);
            this.Controls.Add(this.btn_manage);
            this.Controls.Add(this.cmb_classe);
            this.Controls.Add(this.txt_path3);
            this.Controls.Add(this.txt_path2);
            this.Controls.Add(this.txt_path1);
            this.Controls.Add(this.txt_path0);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_open);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "TalentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TalentForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TalentForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_open;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.TextBox txt_path0;
        private System.Windows.Forms.TextBox txt_path1;
        private System.Windows.Forms.TextBox txt_path2;
        private System.Windows.Forms.TextBox txt_path3;
        private System.Windows.Forms.ComboBox cmb_classe;
        private System.Windows.Forms.Button btn_manage;
    }
}
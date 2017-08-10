namespace TextEditor.Talent {
    sealed partial class ManageClasse {
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
            this.cmb_classe = new System.Windows.Forms.ComboBox();
            this.txt_id = new System.Windows.Forms.TextBox();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_remove = new System.Windows.Forms.Button();
            this.chk_edit = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btn_add
            // 
            this.btn_add.Font = new System.Drawing.Font("Open Sans", 9F);
            this.btn_add.Location = new System.Drawing.Point(12, 195);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 23);
            this.btn_add.TabIndex = 0;
            this.btn_add.Text = "Add";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // cmb_classe
            // 
            this.cmb_classe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_classe.Font = new System.Drawing.Font("Open Sans", 9F);
            this.cmb_classe.Location = new System.Drawing.Point(12, 30);
            this.cmb_classe.Name = "cmb_classe";
            this.cmb_classe.Size = new System.Drawing.Size(239, 25);
            this.cmb_classe.TabIndex = 1;
            this.cmb_classe.SelectedIndexChanged += new System.EventHandler(this.cmb_classe_SelectedIndexChanged);
            // 
            // txt_id
            // 
            this.txt_id.Font = new System.Drawing.Font("Open Sans", 9F);
            this.txt_id.Location = new System.Drawing.Point(12, 85);
            this.txt_id.Name = "txt_id";
            this.txt_id.Size = new System.Drawing.Size(237, 24);
            this.txt_id.TabIndex = 2;
            // 
            // txt_name
            // 
            this.txt_name.Font = new System.Drawing.Font("Open Sans", 9F);
            this.txt_name.Location = new System.Drawing.Point(12, 138);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(237, 24);
            this.txt_name.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Open Sans", 9F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Classe";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Open Sans", 9F);
            this.label2.Location = new System.Drawing.Point(12, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "ID";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Open Sans", 9F);
            this.label3.Location = new System.Drawing.Point(12, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Name";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_remove
            // 
            this.btn_remove.Font = new System.Drawing.Font("Open Sans", 9F);
            this.btn_remove.Location = new System.Drawing.Point(174, 195);
            this.btn_remove.Name = "btn_remove";
            this.btn_remove.Size = new System.Drawing.Size(75, 23);
            this.btn_remove.TabIndex = 7;
            this.btn_remove.Text = "Remove";
            this.btn_remove.UseVisualStyleBackColor = true;
            this.btn_remove.Click += new System.EventHandler(this.btn_remove_Click);
            // 
            // chk_edit
            // 
            this.chk_edit.AutoSize = true;
            this.chk_edit.Font = new System.Drawing.Font("Open Sans", 9F);
            this.chk_edit.Location = new System.Drawing.Point(15, 168);
            this.chk_edit.Name = "chk_edit";
            this.chk_edit.Size = new System.Drawing.Size(83, 21);
            this.chk_edit.TabIndex = 8;
            this.chk_edit.Text = "Edit Mode";
            this.chk_edit.UseVisualStyleBackColor = true;
            this.chk_edit.CheckedChanged += new System.EventHandler(this.chk_edit_CheckedChanged);
            // 
            // ManageClasse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 226);
            this.Controls.Add(this.chk_edit);
            this.Controls.Add(this.btn_remove);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.txt_id);
            this.Controls.Add(this.cmb_classe);
            this.Controls.Add(this.btn_add);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ManageClasse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Classe";
            this.Load += new System.EventHandler(this.ManageClasse_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.ComboBox cmb_classe;
        private System.Windows.Forms.TextBox txt_id;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_remove;
        private System.Windows.Forms.CheckBox chk_edit;
    }
}
namespace TextEditor {
    partial class ExpForm {
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btn_open = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_remove = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.txt_exp = new System.Windows.Forms.TextBox();
            this.txt_lvl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(12, 166);
            this.listBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(265, 334);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // btn_open
            // 
            this.btn_open.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.btn_open.Location = new System.Drawing.Point(12, 508);
            this.btn_open.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_open.Name = "btn_open";
            this.btn_open.Size = new System.Drawing.Size(85, 29);
            this.btn_open.TabIndex = 6;
            this.btn_open.Text = "Open File";
            this.btn_open.UseVisualStyleBackColor = true;
            this.btn_open.Click += new System.EventHandler(this.btn_open_Click);
            // 
            // btn_save
            // 
            this.btn_save.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.btn_save.Location = new System.Drawing.Point(194, 508);
            this.btn_save.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(85, 29);
            this.btn_save.TabIndex = 7;
            this.btn_save.Text = "Save File";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_add
            // 
            this.btn_add.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.btn_add.Location = new System.Drawing.Point(12, 129);
            this.btn_add.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(85, 29);
            this.btn_add.TabIndex = 3;
            this.btn_add.Text = "Add";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_remove
            // 
            this.btn_remove.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.btn_remove.Location = new System.Drawing.Point(103, 129);
            this.btn_remove.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_remove.Name = "btn_remove";
            this.btn_remove.Size = new System.Drawing.Size(85, 29);
            this.btn_remove.TabIndex = 4;
            this.btn_remove.Text = "Remove";
            this.btn_remove.UseVisualStyleBackColor = true;
            this.btn_remove.Click += new System.EventHandler(this.btn_remove_Click);
            // 
            // btn_update
            // 
            this.btn_update.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.btn_update.Location = new System.Drawing.Point(194, 129);
            this.btn_update.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(85, 29);
            this.btn_update.TabIndex = 5;
            this.btn_update.Text = "Update";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // txt_exp
            // 
            this.txt_exp.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.txt_exp.Location = new System.Drawing.Point(14, 83);
            this.txt_exp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_exp.Name = "txt_exp";
            this.txt_exp.Size = new System.Drawing.Size(265, 23);
            this.txt_exp.TabIndex = 2;
            this.txt_exp.Text = "0";
            // 
            // txt_lvl
            // 
            this.txt_lvl.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.txt_lvl.Location = new System.Drawing.Point(14, 37);
            this.txt_lvl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_lvl.Name = "txt_lvl";
            this.txt_lvl.Size = new System.Drawing.Size(265, 23);
            this.txt_lvl.TabIndex = 1;
            this.txt_lvl.Text = "0";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(11, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Level:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(11, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Experience";
            // 
            // ExpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 554);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_lvl);
            this.Controls.Add(this.txt_exp);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.btn_remove);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_open);
            this.Controls.Add(this.listBox1);
            this.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "ExpForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Level: 0";
            this.Load += new System.EventHandler(this.ExpForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btn_open;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_remove;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.TextBox txt_exp;
        private System.Windows.Forms.TextBox txt_lvl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
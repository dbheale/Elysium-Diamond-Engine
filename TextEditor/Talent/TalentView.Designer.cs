namespace TextEditor.Talent {
    sealed partial class TalentView {
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
            this.list_talent = new System.Windows.Forms.ListBox();
            this.lbl_icon = new System.Windows.Forms.Label();
            this.btn_select = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // list_talent
            // 
            this.list_talent.Font = new System.Drawing.Font("Open Sans", 9F);
            this.list_talent.FormattingEnabled = true;
            this.list_talent.ItemHeight = 17;
            this.list_talent.Location = new System.Drawing.Point(12, 12);
            this.list_talent.Name = "list_talent";
            this.list_talent.ScrollAlwaysVisible = true;
            this.list_talent.Size = new System.Drawing.Size(264, 344);
            this.list_talent.TabIndex = 0;
            this.list_talent.SelectedIndexChanged += new System.EventHandler(this.list_talent_SelectedIndexChanged);
            // 
            // lbl_icon
            // 
            this.lbl_icon.BackColor = System.Drawing.Color.Transparent;
            this.lbl_icon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_icon.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_icon.ForeColor = System.Drawing.Color.White;
            this.lbl_icon.Location = new System.Drawing.Point(124, 362);
            this.lbl_icon.Name = "lbl_icon";
            this.lbl_icon.Size = new System.Drawing.Size(32, 32);
            this.lbl_icon.TabIndex = 148;
            // 
            // btn_select
            // 
            this.btn_select.Font = new System.Drawing.Font("Open Sans", 9F);
            this.btn_select.Location = new System.Drawing.Point(12, 371);
            this.btn_select.Name = "btn_select";
            this.btn_select.Size = new System.Drawing.Size(75, 23);
            this.btn_select.TabIndex = 149;
            this.btn_select.Text = "Select";
            this.btn_select.UseVisualStyleBackColor = true;
            this.btn_select.Click += new System.EventHandler(this.btn_select_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Font = new System.Drawing.Font("Open Sans", 9F);
            this.btn_cancel.Location = new System.Drawing.Point(201, 371);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 150;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // TalentView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 404);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_select);
            this.Controls.Add(this.lbl_icon);
            this.Controls.Add(this.list_talent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "TalentView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Talent View";
            this.Load += new System.EventHandler(this.TalentView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox list_talent;
        private System.Windows.Forms.Label lbl_icon;
        private System.Windows.Forms.Button btn_select;
        private System.Windows.Forms.Button btn_cancel;
    }
}
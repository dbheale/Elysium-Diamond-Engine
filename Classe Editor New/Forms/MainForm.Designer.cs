namespace Classe_Editor {
    partial class MainForm {
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
            this.darkSeparator1 = new DarkUI.Controls.DarkSeparator();
            this.darkSectionPanel1 = new DarkUI.Controls.DarkSectionPanel();
            this.list_classes = new DarkUI.Controls.DarkListView();
            this.btn_classe = new DarkUI.Controls.DarkButton();
            this.btn_increment = new DarkUI.Controls.DarkButton();
            this.darkSectionPanel2 = new DarkUI.Controls.DarkSectionPanel();
            this.list_increment = new DarkUI.Controls.DarkListView();
            this.btn_simulator = new DarkUI.Controls.DarkButton();
            this.darkSectionPanel1.SuspendLayout();
            this.darkSectionPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // darkSeparator1
            // 
            this.darkSeparator1.Dock = System.Windows.Forms.DockStyle.Top;
            this.darkSeparator1.Location = new System.Drawing.Point(0, 0);
            this.darkSeparator1.Name = "darkSeparator1";
            this.darkSeparator1.Size = new System.Drawing.Size(508, 2);
            this.darkSeparator1.TabIndex = 2;
            this.darkSeparator1.Text = "darkSeparator1";
            // 
            // darkSectionPanel1
            // 
            this.darkSectionPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.darkSectionPanel1.Controls.Add(this.list_classes);
            this.darkSectionPanel1.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.darkSectionPanel1.Location = new System.Drawing.Point(13, 39);
            this.darkSectionPanel1.Name = "darkSectionPanel1";
            this.darkSectionPanel1.SectionHeader = "Classes";
            this.darkSectionPanel1.Size = new System.Drawing.Size(238, 244);
            this.darkSectionPanel1.TabIndex = 4;
            // 
            // list_classes
            // 
            this.list_classes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.list_classes.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.list_classes.Location = new System.Drawing.Point(1, 25);
            this.list_classes.Name = "list_classes";
            this.list_classes.Size = new System.Drawing.Size(234, 216);
            this.list_classes.TabIndex = 0;
            this.list_classes.Text = "darkListView1";
            this.list_classes.DoubleClick += new System.EventHandler(this.list_classes_DoubleClick);
            // 
            // btn_classe
            // 
            this.btn_classe.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.btn_classe.Location = new System.Drawing.Point(13, 289);
            this.btn_classe.Name = "btn_classe";
            this.btn_classe.Padding = new System.Windows.Forms.Padding(5);
            this.btn_classe.Size = new System.Drawing.Size(238, 23);
            this.btn_classe.TabIndex = 5;
            this.btn_classe.Text = "Criar uma nova classe";
            this.btn_classe.Click += new System.EventHandler(this.btn_classe_Click);
            // 
            // btn_increment
            // 
            this.btn_increment.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_increment.Location = new System.Drawing.Point(257, 289);
            this.btn_increment.Name = "btn_increment";
            this.btn_increment.Padding = new System.Windows.Forms.Padding(5);
            this.btn_increment.Size = new System.Drawing.Size(238, 23);
            this.btn_increment.TabIndex = 6;
            this.btn_increment.Text = "Criar um novo incremento";
            this.btn_increment.Click += new System.EventHandler(this.btn_increment_Click);
            // 
            // darkSectionPanel2
            // 
            this.darkSectionPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.darkSectionPanel2.Controls.Add(this.list_increment);
            this.darkSectionPanel2.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.darkSectionPanel2.Location = new System.Drawing.Point(257, 39);
            this.darkSectionPanel2.Name = "darkSectionPanel2";
            this.darkSectionPanel2.SectionHeader = "Incrementos";
            this.darkSectionPanel2.Size = new System.Drawing.Size(238, 244);
            this.darkSectionPanel2.TabIndex = 7;
            // 
            // list_increment
            // 
            this.list_increment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.list_increment.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.list_increment.Location = new System.Drawing.Point(1, 25);
            this.list_increment.Name = "list_increment";
            this.list_increment.Size = new System.Drawing.Size(234, 216);
            this.list_increment.TabIndex = 1;
            this.list_increment.Text = "darkListView2";
            // 
            // btn_simulator
            // 
            this.btn_simulator.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_simulator.Location = new System.Drawing.Point(13, 10);
            this.btn_simulator.Name = "btn_simulator";
            this.btn_simulator.Padding = new System.Windows.Forms.Padding(5);
            this.btn_simulator.Size = new System.Drawing.Size(482, 23);
            this.btn_simulator.TabIndex = 8;
            this.btn_simulator.Text = "Simulador";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 326);
            this.Controls.Add(this.btn_simulator);
            this.Controls.Add(this.darkSectionPanel2);
            this.Controls.Add(this.btn_increment);
            this.Controls.Add(this.btn_classe);
            this.Controls.Add(this.darkSectionPanel1);
            this.Controls.Add(this.darkSeparator1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Classes @";
            this.darkSectionPanel1.ResumeLayout(false);
            this.darkSectionPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DarkUI.Controls.DarkSeparator darkSeparator1;
        private DarkUI.Controls.DarkSectionPanel darkSectionPanel1;
        private DarkUI.Controls.DarkButton btn_classe;
        private DarkUI.Controls.DarkButton btn_increment;
        private DarkUI.Controls.DarkListView list_classes;
        private DarkUI.Controls.DarkSectionPanel darkSectionPanel2;
        private DarkUI.Controls.DarkListView list_increment;
        private DarkUI.Controls.DarkButton btn_simulator;
    }
}


namespace Classe_Editor {
    partial class FormIncrement {
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
            this.darkMenuStrip1 = new DarkUI.Controls.DarkMenuStrip();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.item_save = new System.Windows.Forms.ToolStripMenuItem();
            this.item_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.item_clear = new System.Windows.Forms.ToolStripMenuItem();
            this.mostrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.item_basic = new System.Windows.Forms.ToolStripMenuItem();
            this.item_stat = new System.Windows.Forms.ToolStripMenuItem();
            this.item_vital = new System.Windows.Forms.ToolStripMenuItem();
            this.item_physical = new System.Windows.Forms.ToolStripMenuItem();
            this.item_magic = new System.Windows.Forms.ToolStripMenuItem();
            this.item_resist = new System.Windows.Forms.ToolStripMenuItem();
            this.item_elemental = new System.Windows.Forms.ToolStripMenuItem();
            this.item_extra = new System.Windows.Forms.ToolStripMenuItem();
            this.darkSeparator1 = new DarkUI.Controls.DarkSeparator();
            this.DockPanel = new DarkUI.Docking.DarkDockPanel();
            this.darkMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // darkMenuStrip1
            // 
            this.darkMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.darkMenuStrip1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivoToolStripMenuItem,
            this.editarToolStripMenuItem,
            this.mostrarToolStripMenuItem});
            this.darkMenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.darkMenuStrip1.Name = "darkMenuStrip1";
            this.darkMenuStrip1.Padding = new System.Windows.Forms.Padding(3, 2, 0, 2);
            this.darkMenuStrip1.Size = new System.Drawing.Size(734, 24);
            this.darkMenuStrip1.TabIndex = 0;
            this.darkMenuStrip1.Text = "darkMenuStrip1";
            // 
            // arquivoToolStripMenuItem
            // 
            this.arquivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.item_save,
            this.item_exit});
            this.arquivoToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.arquivoToolStripMenuItem.Text = "Arquivo";
            // 
            // item_save
            // 
            this.item_save.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.item_save.Name = "item_save";
            this.item_save.Size = new System.Drawing.Size(152, 22);
            this.item_save.Text = "Salvar";
            // 
            // item_exit
            // 
            this.item_exit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.item_exit.Name = "item_exit";
            this.item_exit.Size = new System.Drawing.Size(152, 22);
            this.item_exit.Text = "Sair";
            this.item_exit.Click += new System.EventHandler(this.item_exit_Click);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.item_clear});
            this.editarToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.editarToolStripMenuItem.Text = "Editar";
            // 
            // item_clear
            // 
            this.item_clear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.item_clear.Name = "item_clear";
            this.item_clear.Size = new System.Drawing.Size(166, 22);
            this.item_clear.Text = "Limpar Campos";
            this.item_clear.Click += new System.EventHandler(this.item_clear_Click);
            // 
            // mostrarToolStripMenuItem
            // 
            this.mostrarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.item_basic,
            this.item_stat,
            this.item_vital,
            this.item_physical,
            this.item_magic,
            this.item_resist,
            this.item_elemental,
            this.item_extra});
            this.mostrarToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.mostrarToolStripMenuItem.Name = "mostrarToolStripMenuItem";
            this.mostrarToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.mostrarToolStripMenuItem.Text = "Mostrar";
            // 
            // item_basic
            // 
            this.item_basic.Checked = true;
            this.item_basic.CheckState = System.Windows.Forms.CheckState.Checked;
            this.item_basic.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.item_basic.Name = "item_basic";
            this.item_basic.Size = new System.Drawing.Size(171, 22);
            this.item_basic.Text = "Básico";
            this.item_basic.Click += new System.EventHandler(this.item_basic_Click);
            // 
            // item_stat
            // 
            this.item_stat.Checked = true;
            this.item_stat.CheckState = System.Windows.Forms.CheckState.Checked;
            this.item_stat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.item_stat.Name = "item_stat";
            this.item_stat.Size = new System.Drawing.Size(171, 22);
            this.item_stat.Text = "Atributos";
            this.item_stat.Click += new System.EventHandler(this.item_stat_Click);
            // 
            // item_vital
            // 
            this.item_vital.Checked = true;
            this.item_vital.CheckState = System.Windows.Forms.CheckState.Checked;
            this.item_vital.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.item_vital.Name = "item_vital";
            this.item_vital.Size = new System.Drawing.Size(171, 22);
            this.item_vital.Text = "Vital";
            this.item_vital.Click += new System.EventHandler(this.item_vital_Click);
            // 
            // item_physical
            // 
            this.item_physical.Checked = true;
            this.item_physical.CheckState = System.Windows.Forms.CheckState.Checked;
            this.item_physical.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.item_physical.Name = "item_physical";
            this.item_physical.Size = new System.Drawing.Size(171, 22);
            this.item_physical.Text = "Combate Físico";
            this.item_physical.Click += new System.EventHandler(this.item_physical_Click);
            // 
            // item_magic
            // 
            this.item_magic.Checked = true;
            this.item_magic.CheckState = System.Windows.Forms.CheckState.Checked;
            this.item_magic.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.item_magic.Name = "item_magic";
            this.item_magic.Size = new System.Drawing.Size(171, 22);
            this.item_magic.Text = "Combate Mágico";
            this.item_magic.Click += new System.EventHandler(this.item_magic_Click);
            // 
            // item_resist
            // 
            this.item_resist.Checked = true;
            this.item_resist.CheckState = System.Windows.Forms.CheckState.Checked;
            this.item_resist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.item_resist.Name = "item_resist";
            this.item_resist.Size = new System.Drawing.Size(171, 22);
            this.item_resist.Text = "Resistências";
            this.item_resist.Click += new System.EventHandler(this.item_resist_Click);
            // 
            // item_elemental
            // 
            this.item_elemental.Checked = true;
            this.item_elemental.CheckState = System.Windows.Forms.CheckState.Checked;
            this.item_elemental.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.item_elemental.Name = "item_elemental";
            this.item_elemental.Size = new System.Drawing.Size(171, 22);
            this.item_elemental.Text = "Elemental";
            this.item_elemental.Click += new System.EventHandler(this.item_elemental_Click);
            // 
            // item_extra
            // 
            this.item_extra.Checked = true;
            this.item_extra.CheckState = System.Windows.Forms.CheckState.Checked;
            this.item_extra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.item_extra.Name = "item_extra";
            this.item_extra.Size = new System.Drawing.Size(171, 22);
            this.item_extra.Text = "Extra";
            this.item_extra.Click += new System.EventHandler(this.item_extra_Click);
            // 
            // darkSeparator1
            // 
            this.darkSeparator1.Dock = System.Windows.Forms.DockStyle.Top;
            this.darkSeparator1.Location = new System.Drawing.Point(0, 24);
            this.darkSeparator1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.darkSeparator1.Name = "darkSeparator1";
            this.darkSeparator1.Size = new System.Drawing.Size(734, 2);
            this.darkSeparator1.TabIndex = 1;
            this.darkSeparator1.Text = "darkSeparator1";
            // 
            // DockPanel
            // 
            this.DockPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.DockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DockPanel.Location = new System.Drawing.Point(0, 26);
            this.DockPanel.Name = "DockPanel";
            this.DockPanel.Size = new System.Drawing.Size(734, 525);
            this.DockPanel.TabIndex = 2;
            // 
            // FormIncrement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 551);
            this.Controls.Add(this.DockPanel);
            this.Controls.Add(this.darkSeparator1);
            this.Controls.Add(this.darkMenuStrip1);
            this.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.MainMenuStrip = this.darkMenuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormIncrement";
            this.Text = "Incremento";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormIncrement_FormClosing);
            this.darkMenuStrip1.ResumeLayout(false);
            this.darkMenuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DarkUI.Controls.DarkMenuStrip darkMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem arquivoToolStripMenuItem;
        private DarkUI.Controls.DarkSeparator darkSeparator1;
        private System.Windows.Forms.ToolStripMenuItem item_save;
        private System.Windows.Forms.ToolStripMenuItem item_exit;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem item_clear;
        private System.Windows.Forms.ToolStripMenuItem mostrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem item_basic;
        private System.Windows.Forms.ToolStripMenuItem item_stat;
        private System.Windows.Forms.ToolStripMenuItem item_vital;
        private System.Windows.Forms.ToolStripMenuItem item_physical;
        private System.Windows.Forms.ToolStripMenuItem item_magic;
        private System.Windows.Forms.ToolStripMenuItem item_resist;
        private System.Windows.Forms.ToolStripMenuItem item_elemental;
        private System.Windows.Forms.ToolStripMenuItem item_extra;
        private DarkUI.Docking.DarkDockPanel DockPanel;
    }
}
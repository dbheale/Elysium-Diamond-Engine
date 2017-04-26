using System;
using System.Collections.Generic;
using DarkUI.Forms;
using DarkUI.Controls;
using Classe_Editor.Database;
using Classe_Editor.ClasseData;

namespace Classe_Editor {
    public partial class MainForm : DarkForm {
        private List<ListClasseData> classe;
        private List<ListClasseData> increment;

        public MainForm() {
            InitializeComponent();

            InitializeDatabase();

            LoadClasse();
            LoadIncrement();
        }

 
        private void InitializeDatabase() {
            // carrega o arquivo de configuração
            Configuration.ParseConfigFile("Config.txt");

            MySQL.GameDB = new CommonDB();
            MySQL.GameDB.Server = Configuration.GetString("game_ip");
            MySQL.GameDB.Port = Configuration.GetInt32("game_port");
            MySQL.GameDB.Username = Configuration.GetString("game_user");
            MySQL.GameDB.Password = Configuration.GetString("game_password");
            MySQL.GameDB.Database = Configuration.GetString("game_database");

            var error = string.Empty;
            if (!MySQL.GameDB.Open(out error)) {
                DarkMessageBox.ShowError(error, "Ocorreu um erro ao conectar ao MySQL.");
            }
        }

        /// <summary>
        /// Abre o formulário para edição de nova classe.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_classe_Click(object sender, EventArgs e) {
            //não permite a edição para uma nova classe.
            if (Program.FormClasses.IsDisposed) { Program.FormClasses = new FormClasses(); }
            Program.FormClasses.IsSaveMode = false;
            Program.FormClasses.Show();
        }

        /// <summary>
        /// Carrega uma nova classe para edição.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void list_classes_DoubleClick(object sender, EventArgs e) {
            var index = list_classes.SelectedIndices[0];

            //não permite a edição para uma nova classe.
            if (Program.FormClasses.IsDisposed) { Program.FormClasses = new FormClasses(); }
            Program.FormClasses.IsSaveMode = true;
            Program.FormClasses.Show(classe[index].ID);
        }

        /// <summary>
        /// Carrega as classes e apreseta na lista.
        /// </summary>
        public void LoadClasse() {
            list_classes.Items.Clear();

            //obtem as classes e preenche a lista
            classe = ClasseDB.GetClasseBasicData("classes");
            for (var n = 0; n < classe.Count; n++) {
                list_classes.Items.Add(new DarkListItem($"{classe[n].ID} - {classe[n].Name}"));
            }
        }

        /// <summary>
        /// Carrega os incrementos e apresenta na lista.
        /// </summary>
        public void LoadIncrement() {
            list_increment.Items.Clear();
            //obtem os incrementos e preenche a lista
            increment = ClasseDB.GetClasseBasicData("classes_increment");
            for (var n = 0; n < increment.Count; n++) {
                list_increment.Items.Add(new DarkListItem($"{increment[n].ID} - {increment[n].Name}"));
            }
        }


        private void btn_increment_Click(object sender, EventArgs e) {
            //não permite a edição para uma nova classe.
            if (Program.FormIncrement.IsDisposed) { Program.FormIncrement = new FormIncrement(); }
            Program.FormIncrement.IsSaveMode = false;
            Program.FormIncrement.Show();
        }
    }
}

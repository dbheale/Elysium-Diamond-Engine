using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NpcEditor {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }


        #region Find Npc
        private HashSet<string> dic = new HashSet<string>();
        /// <summary>
        /// Texto alterado, realiza a pesquisa.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_findnpc_TextChanged(object sender, EventArgs e) {
            if (string.IsNullOrWhiteSpace(txt_findnpc.Text)) { return; }
            
            dic.Clear();
            listBox1.Items.Clear();


            var id = 0;
            if (int.TryParse(txt_findnpc.Text, out id)) {
                dic = MySQL.FindNpc(string.Empty, id);
            } else {
                dic = MySQL.FindNpc(txt_findnpc.Text, 0);
            }                

            foreach(var item in dic) {
                listBox1.Items.Add(item);
            }
        }

        #endregion

        private void Form1_Load(object sender, EventArgs e) {
            Configuration.ParseConfigFile("Config.txt");

            MySQL.Server = Configuration.GetString("Server");
            MySQL.Port = Configuration.GetInt32("Port");
            MySQL.Username = Configuration.GetString("User");
            MySQL.Password = Configuration.GetString("Pass");
            MySQL.Database = Configuration.GetString("DB");

            var msg = string.Empty;
            if (MySQL.Connect(out msg) == false) {
                MessageBox.Show(msg);
                return;
            }

        }

        private void tabPage1_Click(object sender, EventArgs e) {

        }
    }
}

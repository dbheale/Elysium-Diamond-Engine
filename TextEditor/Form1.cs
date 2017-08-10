using System;
using System.Windows.Forms;
using TextEditor.Talent;

namespace TextEditor {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            EngineIcon.LoadBitmap();
            EngineStatic.Initialize();
            EngineStatic.OpenAllTalent();

             //  NpcForm form = new NpcForm();
             //  form.Show();

             //   ExpForm form_2 = new ExpForm();
             //  form_2.Show();

             //   var form_3 = new ItemForm();
             //  form_3.Show();

        }

        private void button1_Click(object sender, EventArgs e) {
            if (TalentStatic.TalentForm == null) {
                TalentStatic.TalentForm = new TalentForm();
            }

            if (TalentStatic.TalentForm.IsDisposed) {
                TalentStatic.TalentForm = new TalentForm();
            }
                
            TalentStatic.TalentForm.Show();
        }

        private void button2_Click(object sender, EventArgs e) {
            ItemForm frm = new ItemForm();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e) {
            TalentEdit frm = new TalentEdit();
            frm.Show();
        }
    }
}

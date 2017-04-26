using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DarkUI.Controls;

namespace Classe_Editor.DarkControl {
    public class ControlEvent {
        /// <summary>
        /// Não permite que letras sejam inseridas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void TextBox_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsDigit(e.KeyChar) & e.KeyChar != (char)Keys.Back) { e.Handled = true; }
        }

        /// <summary>
        /// Percorre os controles e verifica se há algum vazio.
        /// </summary>
        /// <param name="controls"></param>
        public static void VerifyTextBox(Control.ControlCollection controls) {
            foreach (var c in controls) {
                if (c is DarkTextBox) {
                    if (((DarkTextBox)c).Text.Length == 0) { ((DarkTextBox)c).Text = "0"; }
                }
            }
        }
    }
}

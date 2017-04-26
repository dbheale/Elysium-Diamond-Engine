using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DarkUI.Docking;

namespace Classe_Editor.DarkControl {
    public partial class Increment : DarkToolWindow {

        public Increment() {
            InitializeComponent();

            DockArea = DarkDockArea.Left;
            Dock = DockStyle.Left;
        }
    }
}

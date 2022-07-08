using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskList.View
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSettings f = new FormSettings();
            f.ShowDialog();
        }
    }
}

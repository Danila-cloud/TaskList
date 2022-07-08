using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskList.Models;

namespace TaskList.View
{
    public partial class FormMain : Form
    {
        public static Data.ApplicationDbContext db = new Data.ApplicationDbContext();
        public FormMain()
        {
            InitializeComponent();
            this.LoadProjectsToList();
        }
        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSettings f = new FormSettings();
            f.ShowDialog();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void LoadProjectsToList()
        {
            listBox.Items.Clear();
            listBox.Items.AddRange(db.Projects.ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormProject f = new FormProject();
            f.ShowDialog();
            if(f.DialogResult == DialogResult.OK)
            {
                Project p = new Project { Name = f.textBox1.Text, DateCreate = DateTime.Now };
                db.Projects.Add(p);
                db.SaveChanges();
            }
            LoadProjectsToList();
        }

        private void toPdfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Your task save to pdf");
        }
        Project selectedProject = null;
        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedProject = (Project) (sender as ListBox).SelectedItem;
        }
    }
}

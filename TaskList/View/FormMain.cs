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
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System.Drawing;

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


        private void FormMain_Load(object sender, EventArgs e)
        {

        }
        Models.Task selectedTask = null;
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTask = (Models.Task)(sender as ListBox).SelectedItem;
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
            ClientSize = new System.Drawing.Size(450, 150);
            using (PdfDocument document = new PdfDocument())
            {
                PdfPage page = document.Pages.Add();
                PdfGraphics graphics = page.Graphics;
                PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 16);
                graphics.DrawString("Task name: " + selectedTask.Name + "\n"
                    + "Description: " + selectedTask.Description + "\n"
                    + "Date to complete: " + selectedTask.Date_complete + "\n"
                    + "Priority: " + selectedTask.Priority + "\n"
                    , font, PdfBrushes.Black, new Point(0, 0));
                document.Save(selectedTask.Name + ".pdf");
            }


            MessageBox.Show("Your task save to pdf");
        }
        Project selectedProject = null;
        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedProject = (Project) (sender as ListBox).SelectedItem;
            LoadTasksToList();
        }

        private void LoadTasksToList()
        {
            listBox1.Items.Clear();
            db.Entry(selectedProject).Collection(p => p.Tasks).Load();
            listBox1.Items.AddRange(selectedProject.Tasks.ToArray());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormTask f = new FormTask();
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK)
            {
                Models.Task p = new Models.Task
                {
                    Name = f.textBox1.Text,
                    Date_complete = f.dateTimePicker1.Value,
                    Description = f.textBox2.Text,
                    Priority = f.comboBox1.Text
                };
                p.Project = selectedProject;
                db.Tasks.Add(p);
                db.SaveChanges();
                LoadTasksToList();
            }

        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Name: " + selectedTask.Name + "\n"
                + "Description: " + selectedTask.Description + "\n"
                + "Date to complete: " + selectedTask.Date_complete + "\n"
                + "Priority: " + selectedTask.Priority);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This application was created for ItStep exam by Danylo Provilskyi");
        }

        private void changeColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.AnyColor = true;
            colorDialog1.ShowDialog();
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                this.BackColor = colorDialog1.Color;
            }
        }

        private void defauldColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.WhiteSmoke;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            db.Tasks.Remove(selectedTask);
            db.SaveChanges();
            LoadTasksToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WFHW7
{
    public partial class Form3 : Form
    {
        DriveInfo[] drives = DriveInfo.GetDrives();
        List<string> fields = new List<string>();
        List<string> bwdPath = new List<string>();
        public Form3()
        {
            InitializeComponent();
            foreach (var drive in drives)
            {
                fields.Add(drive.Name);
                listBox1.Items.Add(drive.Name);
            }
            backwardToolStripMenuItem.Enabled = false;
            bwdToolStripMenuItem.Enabled = false;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            fields.Clear();
            listBox1.Items.Clear();
            backwardToolStripMenuItem.Enabled = true;
            bwdToolStripMenuItem.Enabled = true;
            FolderBrowserDialog fbd = new FolderBrowserDialog() { Description = "Виберіть шлях" };
            
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                foreach (string item in Directory.GetFileSystemEntries(fbd.SelectedPath))
                {
                    FileInfo file = new FileInfo(item);
                    fields.Add(file.FullName);
                    listBox1.Items.Add(file.Name);
                }
                textBox1.Text = fbd.SelectedPath;
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (Directory.Exists(fields[listBox1.SelectedIndex]))
            {
                bwdPath.Add(textBox1.Text);
                textBox1.Text = fields[listBox1.SelectedIndex];
                fields.Clear();
                listBox1.Items.Clear();
                foreach (string item in Directory.GetFileSystemEntries(textBox1.Text))
                {
                    FileInfo file = new FileInfo(item);
                    fields.Add(file.FullName);
                    listBox1.Items.Add(file.Name);
                }
                backwardToolStripMenuItem.Enabled = true;
                bwdToolStripMenuItem.Enabled = true;
            }
            else
            {
                MessageBox.Show("Невірний шлях", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void backwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bwdPath.Count == 1 || bwdPath.Count == 0)
            {
                fields.Clear();
                listBox1.Items.Clear();
                textBox1.Text = "";
                backwardToolStripMenuItem.Enabled = false;
                bwdToolStripMenuItem.Enabled = false;
                foreach (var drive in drives)
                {
                    fields.Add(drive.Name);
                    listBox1.Items.Add(drive.Name);
                }
                bwdPath.Clear();
                return;
            }
            textBox1.Text = bwdPath.Last();
            fields.Clear();
            listBox1.Items.Clear();
            foreach (string item in Directory.GetFileSystemEntries(textBox1.Text))
            {
                FileInfo file = new FileInfo(item);
                fields.Add(file.FullName);
                listBox1.Items.Add(file.Name);
                bwdPath.Remove(textBox1.Text);
            }
        }
    }
}

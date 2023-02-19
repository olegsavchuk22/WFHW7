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

namespace WFHW7
{
    public partial class Form2 : Form
    {
        string openedPath = "";
        TextBox textBox = new TextBox();
        public Form2()
        {
            InitializeComponent();
            this.Text = "Текстовий редактор";
        }

        void OpenFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "All Files(*.*)|*.*|Text Files(*.txt)|*.txt";
            ofd.FilterIndex = 2;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                openedPath = ofd.FileName;
                StreamReader reader = File.OpenText(ofd.FileName);
                textBox1.Text = reader.ReadToEnd();
                reader.Close();
            }
        }
        void SaveFileAs()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text Files(*.txt) | *.txt";
            sfd.DefaultExt = "txt";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                openedPath = sfd.FileName;
                SaveFile(sfd.FileName);
            }
        }
        private void SaveFile(string path)
        {
            StreamWriter write = new StreamWriter(path);
            write.Write(textBox1.Text);
            write.Close();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox = textBox1;
            textBox1.Text = "";
            openedPath = "";
            this.Text = "Текстовий редактор";
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
            this.Text = openedPath;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openedPath == "")
            {
                SaveFileAs();
            }
            SaveFile(openedPath);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileAs();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.SelectedText != "")
            {
                Clipboard.SetText(textBox1.SelectedText);
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Text = textBox1.Text;
            if (textBox1.SelectedText != "")
            {
                Clipboard.SetText(textBox1.SelectedText);
            }
            string tmp = textBox1.Text;
            textBox1.Text = tmp.Remove(tmp.IndexOf(Clipboard.GetText()), Clipboard.GetText().Length);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Text = textBox1.Text;
            textBox1.Text += Clipboard.GetText();
        }

        private void undoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox.Text;
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();   
        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Text = textBox1.Text;
            textBox1.ForeColor = Color.Red;
        }

        private void orangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Text = textBox1.Text;
            textBox1.ForeColor = Color.Orange;
        }

        private void yellowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Text = textBox1.Text;
            textBox1.ForeColor = Color.Yellow;
        }

        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Text = textBox1.Text;
            textBox1.ForeColor = Color.Green;
        }

        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Text = textBox1.Text;
            textBox1.ForeColor = Color.Blue;
        }

        private void dBlueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Text = textBox1.Text;
            textBox1.ForeColor = Color.DarkBlue;
        }

        private void violetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Text = textBox1.Text;
            textBox1.ForeColor = Color.Violet;
        }

        private void italicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Text = textBox1.Text;
            textBox1.Font = new Font("Microsoft Sans Serif",9, FontStyle.Italic);
        }

        private void boldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Text = textBox1.Text;
            textBox1.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold);
        }

        private void underlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Text = textBox1.Text;
            textBox1.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Underline);
        }

        private void regularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Text = textBox1.Text;
            textBox1.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular);
        }
    }
}

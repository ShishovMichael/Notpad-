using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace Notepad
{
    public partial class Form1 : Form
    {
        private string FilePath;
        public Form1()
        {
            InitializeComponent();
        }
        // Loading screen
        private void AppStartUp(object sender, StartupEventArgs e)
        {
            var splash = new SplashScreen("cloud2.png");
            splash.Show(true);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {  // OPEN file wit openFileDialog
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                    FilePath = dialog.FileName;
                    textBox1.Text = File.ReadAllText(FilePath);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
               
        }

       

        private void whiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.White;
        }

        private void goldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.Gold;
        }
        // function ,to save file  
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(FilePath))
            {
                using (SaveFileDialog dialog = new SaveFileDialog())
                {
                    if (dialog.ShowDialog()== DialogResult.OK)
                    {
                        FilePath = dialog.FileName;
                        File.WriteAllText(FilePath, textBox1.Text);
                    }
                }
            }

        }
        // move to words
        private void moveWordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            moveWordsToolStripMenuItem = moveWordsToolStripMenuItem;
            textBox1.WordWrap = moveWordsToolStripMenuItem.Checked;
        }
        // function  , to  save as
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using(SaveFileDialog dialog = new SaveFileDialog())
            {
                if(dialog.ShowDialog() == DialogResult.OK)
                {
                    FilePath = dialog.FileName;
                    File.WriteAllText(FilePath, textBox1.Text);
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) => Close();

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Undo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste();
        }

        private void label1_Click(object sender, EventArgs e)
        {
           label1.Text= DateTime.Now.ToString("yyyy.MM.dd, HH.mm");
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }
        // function , to change font of the text
        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using(FontDialog dialog = new FontDialog())
            {
                 if (dialog.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Font = dialog.Font;
                }
            }
        }

        private void googleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://google.com");
        }

        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.Green;
        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.Red;
        }

        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.Blue;
        }
    }
}

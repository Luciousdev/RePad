using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace repad
{
    public partial class repad : Form
    {
        // Dialog
        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;
        private FontDialog fontDialog;



        public repad()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void repad_Load(object sender, EventArgs e)
        {
            fontDialog = new FontDialog();
        }

        // creates a new file instance.
        private void NewFile()
        {
            try
            {
                if (!string.IsNullOrEmpty(this.richTextBox1.Text))
                {
                    MessageBox.Show("You need to save the file to complete this action");
                }
                else
                {
                    this.richTextBox1.Text = string.Empty;
                    this.Text = "Untitled";
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }

        private void SaveFile()
        {
            try
            {
                if(!string.IsNullOrEmpty(this.richTextBox1.Text))
                {
                    saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Text Document (*.txt | *.txt";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(saveFileDialog.FileName, this.richTextBox1.Text);
                        this.Text = saveFileDialog.FileName;
                    }
                }
                else
                {
                    MessageBox.Show("Empty files cannot be saved!");
                }


            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }

        private void OpenFile()
        {
            try
            {
                openFileDialog = new OpenFileDialog();

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.richTextBox1.Text = File.ReadAllText(openFileDialog.FileName);
                    this.Text = openFileDialog.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("A error has occurred while attempting to open this file");
            }
            finally
            {
                openFileDialog = null;
            }
        }

        private void SaveFileAs()
        {
            try
            {
                if (!string.IsNullOrEmpty(this.richTextBox1.Text))
                {
                    saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Text Document (*.txt) | *.txt | All Files (*.*) | *.* | RePad doc (*.rpdc) | *.rpdc | Word-document (*.docx) | *.docx | PDF (*.pdf) | *.pdf";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(saveFileDialog.FileName, this.richTextBox1.Text);
                        this.Text = saveFileDialog.FileName;
                    }
                }
                else
                {
                    MessageBox.Show("Empty files cannot be saved!");
                }


            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }


        private bool ALT_F4 = false;

        private void repad_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ALT_F4)
            {
                e.Cancel = true;
                return;
            }
        }

        private void repad_KeyDown(object sender, KeyEventArgs e)
        {
            ALT_F4 = (e.KeyCode.Equals(Keys.F4) && e.Alt == true);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewFile();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileAs();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.richTextBox1.Text))
                {
                    SaveFile();
                }
                else
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if(fontDialog.ShowDialog() == DialogResult.OK)
                {
                    this.richTextBox1.Font = fontDialog.Font;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }
    }
}

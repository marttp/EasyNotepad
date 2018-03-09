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

namespace Program_Text_File
{
    public partial class Form1 : Form
    {



        public static bool Check= true;
        public static bool CheckNew = false;
        public static bool NewFile = false;
        public static bool richTextCheck = false;
        public static int i = 1;




        public Form1()
        {
            InitializeComponent();
            richTextBox1.Hide();
        }





        private void creditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Credit showCredit = new Credit();
            showCredit.ShowDialog();
        }







        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Text File|*.txt";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                StreamReader strRead = new StreamReader(openFile.FileName);
                richTextBox1.Show();
                richTextCheck = true;
                richTextBox1.Text = strRead.ReadToEnd();
                strRead.Dispose();
                this.Text = openFile.FileName;
                NewFile = true;
                openFile.Dispose();
            }
            Check = true;
            CheckNew = false;
        }



        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            Check = false;
        }



        public void CloseProgram(bool check)
        {
            if (Check == false)
            {
                string MessageBoxText = "Do you want to save changes?";
                string MessageBoxCaption = "Warning";
                MessageBoxButtons beforeExit = MessageBoxButtons.YesNoCancel;
                MessageBoxIcon icon = MessageBoxIcon.Warning;
                DialogResult result = MessageBox.Show(MessageBoxText, MessageBoxCaption, beforeExit, icon);
                switch (result)
                {
                    case DialogResult.Yes:
                        {
                            if (CheckNew == true)
                            {
                                SaveFileDialog SaveFile = new SaveFileDialog();
                                SaveFile.Filter = "Text File(.txt)|*.txt";
                                if (SaveFile.ShowDialog() == DialogResult.OK)
                                {
                                    using (StreamWriter strWrite = new StreamWriter(SaveFile.FileName))
                                    {
                                        strWrite.Write(richTextBox1.Text.Replace("\n", "\r\n"));
                                        this.Text = SaveFile.FileName;
                                        Check = true;
                                        strWrite.Dispose();
                                    }

                                }
                                CheckNew = false;
                            }
                            else
                            {
                                using (StreamWriter strWrite = new StreamWriter(this.Text))
                                {   
                                    strWrite.Write(richTextBox1.Text.Replace("\n", "\r\n"));
                                    Check = true;
                                    strWrite.Dispose();
                                }
                            }
                            Application.Exit();
                            break;
                        }

                    case DialogResult.No:
                        {
                            Application.Exit();
                            break;
                        }

                    case DialogResult.Cancel:
                        {
                            break;
                        }
                }
            }
            else
            {
                Application.Exit();
            }
        }





        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseProgram(Check);
        }






        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NewFile == false)
            {
                FileStream newFile = new FileStream("Untitled.txt", FileMode.Create, FileAccess.ReadWrite);
                richTextBox1.Show();
                richTextCheck = true;
                this.Text = "Untitled.txt";
                Check = false;
                CheckNew = true;
                NewFile = true;
            }
            else
            {
                string MessageBoxText = "Do you want to save changes ?";
                string MessageBoxCaption = "Easy-Notepad";
                MessageBoxButtons Savethisfile = MessageBoxButtons.YesNoCancel;
                MessageBoxIcon Question = MessageBoxIcon.Question;
                DialogResult result1 = MessageBox.Show(MessageBoxText, MessageBoxCaption, Savethisfile, Question);
                switch (result1)
                {
                    case DialogResult.Yes :
                        {

                            if (richTextCheck == true)
                            {
                                if (CheckNew == true)
                                {
                                    SaveFileDialog SaveFile = new SaveFileDialog();
                                    SaveFile.Filter = "Text File(.txt)|*.txt";
                                    if (SaveFile.ShowDialog() == DialogResult.OK)
                                    {
                                        using (StreamWriter strWrite = new StreamWriter(SaveFile.FileName))
                                        {
                                            strWrite.Write(richTextBox1.Text.Replace("\n", "\r\n"));
                                            this.Text = SaveFile.FileName;
                                            Check = true;
                                            strWrite.Dispose();
                                        }
                                        CheckNew = true;
                                    }
                                    else
                                    {
                                        SaveFile.Dispose();
                                    }
                                }
                                else
                                {

                                    using (StreamWriter strWrite = new StreamWriter(this.Text))
                                    {
                                        strWrite.Write(richTextBox1.Text.Replace("\n", "\r\n"));
                                        Check = true;
                                        strWrite.Dispose();
                                        CheckNew = true;
                                    }
                                }
                            }
                            richTextBox1.Clear();
                            this.Text = "Untitled" + i + ".txt";
                            i++;
                            CheckNew = true;
                            break;
                        }

                    case DialogResult.No:
                        {
                            richTextBox1.Clear();
                            this.Text = "Untitled"+i+".txt";
                            i++;
                            CheckNew = true;
                            break;
                        }
                    case DialogResult.Cancel:
                        {
                            break;
                        }
                }
            }
                
        }








        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextCheck == true)
            {
                SaveFileDialog SaveFile = new SaveFileDialog();
                SaveFile.Filter = "Text File(.txt)|*.txt";
                if (SaveFile.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter strWrite = new StreamWriter(SaveFile.FileName))
                    {
                        strWrite.Write(richTextBox1.Text.Replace("\n", "\r\n"));
                        this.Text = SaveFile.FileName;
                        Check = true;
                        strWrite.Dispose();
                    }
                    CheckNew = false;
                }
                else
                {
                    SaveFile.Dispose();
                }
            }
            else
            {
                string MessageBoxText = "Can't save empty files";
                string MessageBoxCaption = "Warning";
                MessageBoxButtons Error = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Error;
                MessageBox.Show(MessageBoxText, MessageBoxCaption, Error, icon);

            }


        }










        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextCheck == true)
            {
                if (CheckNew == true)
                {
                    SaveFileDialog SaveFile = new SaveFileDialog();
                    SaveFile.Filter = "Text File(.txt)|*.txt";
                    if (SaveFile.ShowDialog() == DialogResult.OK)
                    {
                        using (StreamWriter strWrite = new StreamWriter(SaveFile.FileName))
                        {

                            strWrite.Write(richTextBox1.Text.Replace("\n", "\r\n"));
                            this.Text = SaveFile.FileName;
                            Check = true;
                            strWrite.Dispose();
                        }
                        CheckNew = false;
                    }
                    else
                    {
                        SaveFile.Dispose();
                    }
                }
                else
                {

                    using (StreamWriter strWrite = new StreamWriter(this.Text))
                    {
                        strWrite.Write(richTextBox1.Text.Replace("\n", "\r\n"));
                        Check = true;
                        strWrite.Dispose();
                    }
                }
            }
            else
            {
                string MessageBoxText = "Can't save empty files";
                string MessageBoxCaption = "Warning";
                MessageBoxButtons Error = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Error;
                MessageBox.Show(MessageBoxText, MessageBoxCaption, Error, icon);

            }

        }










        private void fontsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.Font = richTextBox1.Font;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font = fontDialog.Font;
            }
            else
            {
                fontDialog.Dispose();
            }
        }


 
        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CloseProgram(Check);
        }



    }
}

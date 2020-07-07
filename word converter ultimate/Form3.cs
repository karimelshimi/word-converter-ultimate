using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Globalization;
namespace word_converter_ultimate
{
    public partial class Form3 : Form
    {
        void enq()
        {

            progressBar1.Value = 0;
            textBox2.Text = string.Empty;
            foreach (char km in textBox1.Text)
            {
                
                progressBar1.Maximum = textBox2.TextLength;
                progressBar1.Increment(1);
                char encrypted = (char)(km + 8e7);
                textBox2.Text += encrypted.ToString();

            }
            
        }
        void dec()
        {
            textBox2.Text = string.Empty;
            progressBar1.Value = 0;

            foreach (char mm in textBox1.Text)
            {

                progressBar1.Maximum = textBox2.TextLength;
                progressBar1.Increment(1);
                char encrypted = (char)(mm - 8e7);
                textBox2.Text += encrypted.ToString();
                progressBar1.Show();

            }
        }
        public Form3()
        {
            InitializeComponent();
        }

        private void new1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            progressBar1.Value = 0;
            encrypted2.Hide();
            pictureBox1.Hide();
            pictureBox2.Hide();
            decrypt2.Hide();
        }

        private void open_Click(object sender, EventArgs e)
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Text File";
            theDialog.Filter = "TXT files|*.txt";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                string s = File.ReadAllText(theDialog.FileName);
                textBox1.Text = s;
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                sfd.FilterIndex = 2;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(sfd.FileName, textBox2.Text);
                }
            } 
        }

        private void save1_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                sfd.FilterIndex = 2;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(sfd.FileName, textBox2.Text);
                }
            } 
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void undo_Click(object sender, EventArgs e)
        {
            textBox1.Undo();
        }

        private void redo_Click(object sender, EventArgs e)
        {
            textBox1.Redo();
        }

        private void cut_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("There are no words for cutting");
            }
            else
            {
                Clipboard.SetText(textBox1.Text);
                textBox1.Clear();
            }
        }

        private void copy_Click(object sender, EventArgs e)
        {
             if (textBox1.Text == "")
            {
                MessageBox.Show("There are no words for copying");
            }
            else
                Clipboard.SetText(textBox1.Text);
        }

        private void paste_Click(object sender, EventArgs e)
        {
            textBox1.Paste();
        }

        private void selectAll_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }

        private void arabic_Click(object sender, EventArgs e)
        {
            this.Hide();
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("Ar");
            Form2 ar = new Form2();
            if (ar.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new Form1());
            }
            else
            {
                Application.Exit();
            }
        }

        private void do1_Click(object sender, EventArgs e)
        {
            if (copy1.Checked)
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("There are no words for copying");
                }
                else
                    Clipboard.SetText(textBox1.Text);
            }
            else if (cut1.Checked)
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("There are no words for cutting");
                }
                else
                {
                    Clipboard.SetText(textBox1.Text);
                    textBox1.Clear();
                }
               
            }
            else if (paste1.Checked)
            {
                textBox1.Paste();
            }    
        }

        private void do2_Click(object sender, EventArgs e)
        {
             if (copy2.Checked)
            {
                if (textBox2.Text == "")
                {
                    MessageBox.Show("There are no words for copying");
                }
                else
                    Clipboard.SetText(textBox2.Text);

            }
            else if (cut2.Checked)
            {
                if (textBox2.Text == "")
                {
                    MessageBox.Show("There are no words for cutting");
                }
                else
                {
                    Clipboard.SetText(textBox2.Text);
                    textBox2.Clear();
                }
            }
            else if (save2.Checked)
            {
                saveFileDialog1.Filter = "txt File | *.txt"; //file types
                saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);//gile where the save dialoge will sart
                saveFileDialog1.Title = "Choose where to save the file";//save box title
                saveFileDialog1.ShowDialog();//show the dialog   
            }
        }

        private void clear1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            progressBar1.Value = 0;
            encrypted2.Hide();
            decrypt2.Hide();
            pictureBox1.Hide();
            pictureBox2.Hide();
        }

        private void clear2_Click(object sender, EventArgs e)
        {
             textBox2.Clear();
            progressBar1.Value = 0;
            encrypted2.Hide();
            decrypt2.Hide();
            pictureBox1.Hide();
            pictureBox2.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                cut.Enabled = true;
                copy.Enabled = true;

            }
            else if (textBox1.Text == "")
            {
                cut.Enabled = false;
                copy.Enabled = false;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
               if (textBox1.Text != "")
            {
                cut.Enabled = true;
                copy.Enabled = true;

            }
            else if (textBox1.Text == "")
            {
                cut.Enabled = false;
                copy.Enabled = false;
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            if (timer1.Enabled == false)
            {
                timer1.Enabled = true;
            }
            else
            {
                timer1.Enabled = false;
            }
        }

        private void encrypt1_Click(object sender, EventArgs e)
        {
            Thread trd = new Thread(new ThreadStart(enq));
            trd.IsBackground = true;
            trd.Start();


            
            encrypted2.Show();
            decrypt2.Hide();
            pictureBox2.Hide();
            pictureBox1.Show();
            if (textBox1.Text == "")
            {
                encrypted2.Hide();
                pictureBox1.Hide();
                MessageBox.Show("please type a word for encrypt it");
            }
            if (timer2.Enabled == false)
            {
                timer2.Enabled = true;
            }
        }

        private void decrypt1_Click(object sender, EventArgs e)
        {
            textBox2.Text = string.Empty;
            Thread trd2 = new Thread(new ThreadStart(dec));
            trd2.IsBackground = true;
            trd2.Start();


            pictureBox1.Hide();
            decrypt2.Show();
            encrypted2.Hide();
            pictureBox2.Show();
            if (textBox1.Text == string.Empty)
            {

                decrypt2.Hide();
                pictureBox2.Hide();
                MessageBox.Show("please type a word for decrypt it");


            }
            if (timer3.Enabled == false)
            {
                timer3.Enabled = true;
            }
        }

        private void english_Click(object sender, EventArgs e)
        {
            this.Hide();
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("En");
            Form1 k = new Form1();
            if (k.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new Form1());
            }
            else
            {
                Application.Exit();
            }
        }

        private void french_Click(object sender, EventArgs e)
        {
            this.Hide();
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("Fr");
            Form3 fr = new Form3();
            if (fr.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new Form1());
            }
            else
            {
                Application.Exit();
            }
        }
    }
    }

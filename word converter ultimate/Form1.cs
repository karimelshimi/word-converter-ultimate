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
    public partial class Form1 : Form
    {
        
        void enq()
        {

            progressBar1.Value = 0;
            textBox2.Text = string.Empty;
            foreach (char km in textBox1.Text)
            {
                if (comboBox1.Text == "Top-level encryption")
                {
                progressBar1.Maximum = textBox2.TextLength;
                progressBar1.Increment(1);
                char encrypted = (char)(km + 8e7);
                textBox2.Text += encrypted.ToString();
                }
                else if (comboBox1.Text =="Mid-level encryption")
                {
                    progressBar1.Maximum = textBox2.TextLength;
                    progressBar1.Increment(1);
                    char encrypted = (char)(km + 1000);
                    textBox2.Text += encrypted.ToString();
                }
                else if (comboBox1.Text == "low-level encryption")
                {
                    progressBar1.Maximum = textBox2.TextLength;
                    progressBar1.Increment(1);
                    char encrypted = (char)(km + 3);
                    textBox2.Text += encrypted.ToString();
                }

            }
            
        }
        void dec()
        {
            //textBox2.Text = string.Empty;
            progressBar1.Value = 0;

            foreach (char mm in textBox1.Text)
            {
                if (comboBox2.Text == "Top-level decryption")
                {
                    progressBar1.Maximum = textBox2.TextLength;
                    progressBar1.Increment(1);
                    char encrypted = (char)(mm - 8e7);
                    textBox2.Text += encrypted.ToString();
                }
                else if (comboBox2.Text == "mid-level decryption")
                {
                    progressBar1.Maximum = textBox2.TextLength;
                    progressBar1.Increment(1);
                    char encrypted = (char)(mm - 1000);
                    textBox2.Text += encrypted.ToString();
                }
                else if (comboBox2.Text == "low-level decryption")
                {
                    progressBar1.Maximum = textBox2.TextLength;
                    progressBar1.Increment(1);
                    char encrypted = (char)(mm - 3);
                    textBox2.Text += encrypted.ToString();
                }
                
                
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

       

       

        

        private void button4_Click(object sender, EventArgs e)
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
                encrypted2.Hide();
                decrypt2.Hide();
                progressBar1.Value = 0;
                pictureBox1.Hide();
                textBox2.Clear();
            }
            else if (save2.Checked)
            {
                saveFileDialog1.Filter = "txt File | *.txt"; //file types
                saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);//gile where the save dialoge will sart
                saveFileDialog1.Title = "Choose where to save the file";//save box title
                saveFileDialog1.ShowDialog();//show the dialog   
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //This Line Of Code Is To Refresh The Timer 
            this.Refresh();

            // This Line Of Code Is The Speed You want It To Scroll At. 
            by1.Left = by1.Left + 10;
            //This If Statement Is What Makes The Label Scroll 
            if (by1.Left >= this.Width)
            {

                by1.Left = -285;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
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

       

       

       

        private void button6_Click(object sender, EventArgs e)
        {
            encrypted2.Hide();
            decrypt2.Hide();
            textBox1.Clear();
            pictureBox1.Hide();
            progressBar1.Value = 0;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            encrypted2.Hide();
            decrypt2.Hide();
            textBox2.Clear();
            pictureBox1.Hide();
            progressBar1.Value = 0;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //This Line Of Code Is To Refresh The Timer 
            this.Refresh();

            // This Line Of Code Is The Speed You want It To Scroll At. 
            encrypted2.Left = encrypted2.Left + 10;
            //This If Statement Is What Makes The Label Scroll 
            if (encrypted2.Left >= this.Width)
            {

                encrypted2.Left = -146;
            }
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                try
                {
                    ofd.Filter = "Text files (*.txt)|*.txt|RTF files (*.rtf)|*.rtf";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        if (Path.GetExtension(ofd.FileName) == ".rtf")
                        {
                            textBox1.LoadFile(ofd.FileName, RichTextBoxStreamType.RichText);
                        }
                        if (Path.GetExtension(ofd.FileName) == ".txt")
                        {
                            textBox1.LoadFile(ofd.FileName, RichTextBoxStreamType.PlainText);
                        }

                    }
                }
                catch (Exception )
                {
                }
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "txt File | *.txt"; //file types
            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);//gile where the save dialoge will sart
            saveFileDialog1.Title = "Choose where to save the file";//save box title
            saveFileDialog1.ShowDialog();//show the dialog 
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "txt File | *.txt"; //file types
            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);//gile where the save dialoge will sart
            saveFileDialog1.Title = "Choose where to save the file";//save box title
            saveFileDialog1.ShowDialog();//show the dialog 
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            encrypted2.Hide();
            decrypt2.Hide();
            textBox1.Clear();
            textBox2.Clear();
            pictureBox1.Hide();
            progressBar1.Value = 0;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void copyToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            
        }

       

        private void toolStripContainer3_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void toolStripContainer3_ContentPanel_Load(object sender, EventArgs e)
        {
            
        }

    

        

        private void button3_Click_1(object sender, EventArgs e)
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

        private void button6_Click_1(object sender, EventArgs e)
        {
            textBox1.Clear();
            progressBar1.Value = 0;
            encrypted2.Hide();
            decrypt2.Hide();
            pictureBox1.Hide();
            pictureBox2.Hide();
            
        }

        private void button4_Click_1(object sender, EventArgs e)
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            textBox2.Text = string.Empty;
            Thread trd2 = new Thread(new ThreadStart(dec));
            trd2.IsBackground = true;
            trd2.Start();

            if (comboBox2.Text == string.Empty)
            {
                pictureBox2.Hide();
                decrypt2.Hide();
                if (textBox1.Text != string.Empty)
                    MessageBox.Show("Please Choose the Level of Decryption");
            }
            
            if (textBox2.Text != string.Empty)
            {
                decrypt2.Show();
                pictureBox2.Show();
            }
            pictureBox1.Hide();
            encrypted2.Hide();
            if (textBox1.Text == string.Empty)
            {

                decrypt2.Hide();
                pictureBox2.Hide();
                MessageBox.Show("Please type a Word for Decrypt it");


            }
            if (timer3.Enabled == false)
            {
                timer3.Enabled = true;
            }
            
            
           
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Thread trd = new Thread(new ThreadStart(enq));
            trd.IsBackground = true;
            trd.Start();


            if (comboBox1.Text == string.Empty)
            {
                pictureBox1.Hide();
                encrypted2.Hide();
                MessageBox.Show("Please Choose the Level of Encryption");
                
            }
            if (textBox2.Text != string.Empty)
            {
                encrypted2.Show();
                pictureBox1.Show();
                
            }
            
            decrypt2.Hide();
            pictureBox2.Hide();
            
            if (textBox1.Text == string.Empty)
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

        private void button5_Click_1(object sender, EventArgs e)
        {
            textBox2.Clear();
            progressBar1.Value = 0;
            encrypted2.Hide();
            decrypt2.Hide();
            pictureBox1.Hide();
            pictureBox2.Hide();
        }

        private void newToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            progressBar1.Value = 0;
            encrypted2.Hide();
            pictureBox1.Hide();
            pictureBox2.Hide();
            decrypt2.Hide();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
                toolStripMenuItem12.Enabled = true;
                toolStripMenuItem13.Enabled = true;

            }
            else if (textBox1.Text == string.Empty)
            {
                toolStripMenuItem12.Enabled = false;
                toolStripMenuItem13.Enabled = false;
            }
            
            
        }

        private void saveToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, textBox2.Text);
            }     
        }

        private void saveAsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "txt File | *.txt"; //file types
            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);//gile where the save dialoge will sart
            saveFileDialog1.Title = "Choose where to save the file";//save box title
            saveFileDialog1.ShowDialog();//show the dialog   
        }

        private void exitToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void copyToolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("There are no words for copying");
            }
            else
                Clipboard.SetText(textBox1.Text);
        }

        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
            textBox1.Paste();
            
        }

        

        private void openToolStripMenuItem1_Click_1(object sender, EventArgs e)
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

        private void cutToolStripMenuItem1_Click(object sender, EventArgs e)
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

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            
            
                textBox1.Undo();
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                toolStripMenuItem12.Enabled = true;
                toolStripMenuItem13.Enabled = true;

            }
            else if (textBox1.Text == "")
            {
                toolStripMenuItem12.Enabled = false;
                toolStripMenuItem13.Enabled = false;
            }
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Redo();
        }

        private void background2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
          
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            //This Line Of Code Is To Refresh The Timer 
            this.Refresh();

            // This Line Of Code Is The Speed You want It To Scroll At. 
            decrypt2.Left = decrypt2.Left + 10;
            //This If Statement Is What Makes The Label Scroll 
            if (decrypt2.Left >= this.Width)
            {

                decrypt2.Left = -116;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }

        private void help_Click(object sender, EventArgs e)
        {

        }

        private void english_Click(object sender, EventArgs e)
        {
            this.Hide();
            Thread.CurrentThread.CurrentUICulture = new CultureInfo ("En");
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

        private void progressBar1_Click(object sender, EventArgs e)
        {
            
        }

        private void file_Click(object sender, EventArgs e)
        {

        }

        private void print_Click(object sender, EventArgs e)
        {

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

       

        private void languages_Click(object sender, EventArgs e)
        {

        }

      

        private void frenchToolStripMenuItem_Click(object sender, EventArgs e)
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

       

       

        private void toolStripMenuItem26_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStripMenuItem24_Click(object sender, EventArgs e)
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

        private void toolStripMenuItem25_Click(object sender, EventArgs e)
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

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            progressBar1.Value = 0;
            encrypted2.Hide();
            pictureBox1.Hide();
            pictureBox2.Hide();
            decrypt2.Hide();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
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

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
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

        private void frenchToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("Fr");
            Form3 fre = new Form3();
            if (fre.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new Form1());
            }
            else
            {
                Application.Exit();
            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
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

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            textBox1.Undo();
            
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            textBox1.Redo();
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
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

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("There are no words for copying");
            }
            else
            {
                Clipboard.SetText(textBox1.Text);
            }
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            textBox1.Paste();
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }


       

        
    }
}

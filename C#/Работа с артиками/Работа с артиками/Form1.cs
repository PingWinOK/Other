using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Работа_с_артиками
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<string> smej = new List<string>();
        string S;
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            Klass.kar.Clear();
            Klass.karPol.Clear();
            smej.Clear();
            S = "";
            FolderBrowserDialog DirDialog = new FolderBrowserDialog();
            DirDialog.Description = "Выбор директории";
            DirDialog.SelectedPath = @"C:\";

            if (DirDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = DirDialog.SelectedPath;
                S = DirDialog.SelectedPath;
                Klass.t = S;
            }
            try
            {
                foreach (var file in Directory.GetFileSystemEntries(Klass.t))
                {
                    FileInfo f = new FileInfo(file);
                    if (textBox2.Visible == true)
                    {
                        textBox2.Text += f.Name + Environment.NewLine;
                    }
                }
            }
            catch
            {

            }
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            Form2 ar = new Form2();
            ar.Owner = this;
            ar.ShowDialog();
            Klass.kar.Clear();
            smej.Clear();

            int g = 0;
            if (textBox4.Text == "")
            {
                g = 1;
            }
            else
            {
                g = Convert.ToInt32(textBox4.Text);
            }
            foreach (var file in Directory.GetFileSystemEntries(S))
            {
                FileInfo f = new FileInfo(file);
                if ((f.Extension == ".jpg") || (f.Extension == ".png") || (f.Extension == ".gif") || (f.Extension == ".PNG") || (f.Extension == ".jpeg"))
                {
                    string New = S + "\\" + g + f.Extension;
                    string Null = S + "\\" + "_____" + g + f.Extension;
                    g++;
                    Klass.kar.Add(New);
                    smej.Add(Null);
                }
            }
            try
            {
                for (int i = 0; i < Klass.karPol.Count; i++)
                {
                    File.Move(Klass.karPol[i], smej[i]);
                 }
                for (int i = 0; i < Klass.karPol.Count; i++)
                {
                    File.Move(smej[i], Klass.kar[i]);
                    if (textBox3.Visible == true)
                    {
                        
                        textBox3.Text += Klass.kar[i] + Environment.NewLine;
                    }

                }
                MessageBox.Show("Готово!");


            }
            catch
            {
                for (int i = 0; i < Klass.karPol.Count; i++)
                {
                    File.Move(Klass.karPol[i], Klass.kar[i]);
                    if (textBox3.Visible == true)
                    {
                        textBox3.Text += Klass.kar[i] + Environment.NewLine;
                    }

                }
                MessageBox.Show("Готово!");
                Klass.karPol.Clear();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (textBox2.Visible == false)
            {
                textBox2.Visible = true;
            }
            else
            {
                textBox2.Visible = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (textBox3.Visible == false)
            {
                textBox3.Visible = true;
            }
            else
            {
                textBox3.Visible = false;
            }
        }
    }
}

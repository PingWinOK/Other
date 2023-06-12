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

namespace Laba6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        string path = @"D:\Вуз\ЛабораторныеОИБ\Лаба 6\Laba6\Laba6\bin\Debug\loger.txt";
        string path1 = @"D:\Вуз\ЛабораторныеОИБ\Лаба 6\Laba6\Laba6\bin\Debug\LIB.txt";
        private void button2_Click(object sender, EventArgs e)
        {
            string Pass = "", Login = "", Prowerka = "";
            int P = 1,U = 0 , L = 0;
            Login = textBox1.Text;
            Pass = textBox2.Text;
            Prowerka = textBox3.Text;
            for (int i = 0; i < Pass.Length; i++)
            {
                if (Char.IsNumber(Pass[i]) == true || Char.IsPunctuation(Pass[i]) == true || Char.IsSeparator(Pass[i]) == true) 
                {
                    P = 0;
                    break;
                }
                if (Char.IsUpper(Pass[i]) == true)
                {
                    U += 1;
                }
                if (Char.IsLower(Pass[i]) == true)
                {
                    L += 1;
                }
            }
            if (Pass == Prowerka && P == 1 && (U != 0 && L !=0))
            {
                using (StreamWriter Zapis = new StreamWriter(path, true, System.Text.Encoding.Default))
                {
                    Zapis.WriteLine(Login + " " + Pass);
                }
                MessageBox.Show("Вы успешно зарегестрировались!");
            }
            else
            {
                MessageBox.Show("Проверте правильность вввода!");
             
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                button2.Visible = true;
                textBox3.Visible = true;
                label3.Visible = true;
            }
            else
            {
                button2.Visible = false;
                textBox3.Visible = false;
                label3.Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<string> LP = new List<string>();
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    LP.Add(line);
                }
            }
            if(comboBox1.Text == "Брутфорсом")
            {
                Random r = new Random();
                List<string> Pass = new List<string>();
                List<string> Log = new List<string>();
                List<string> poisk = new List<string>();
                string Lib = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPRSTUVWXYZ";
                for (int i = 0; i < LP.Count; i++)
                {
                    string[] words = LP[i].Split(new char[] {' '});
                    Pass.Add(words[1]);
                    Log.Add(words[0]);
                }
                for (int c = 0; c < Log.Count;c++)
                {
                while(true)
                {

                        
                    
                string Podbor = "";
                for(int i = 0; i < Pass[c].Length;i++)
                {
                    Podbor += Lib[r.Next(0,Lib.Length)];
                }
                if(Podbor == Pass[c])
                {
                
                    MessageBox.Show("Пороль подобран: " + Podbor + "Логин: " + Log[c]);
                    poisk.Add(Log[c]);
                    break;
                }
                }
                }
                }
             

            if (comboBox1.Text == "Словарем")
            {
                int f = 0;
                List<string> LIB = new List<string>();
                List<string> Pass = new List<string>();
                for (int i = 0; i < LP.Count; i++)
                {
                   string[] words = LP[i].Split(new char[] {' '});
                    Pass.Add(words[1]);
                }
                using (StreamReader sr = new StreamReader(path1, System.Text.Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        LIB.Add(line);
                    }
                }
                for (int i = 0; i < LP.Count; i++)
                {
                    for (int j = 0; j < LIB.Count; j++)
                    {
                        if (Pass[i] == LIB[j])
                        {
                            MessageBox.Show("Пороль подобран:" + LIB[j]);
                            f = 1;
                            break;
                        }
                    }
                }
                if (f == 0)
                {
                    MessageBox.Show("Пороль не подобран");
                }
            }
        }
        int H = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            string Pass = textBox2.Text;
            string Login = textBox1.Text;
            List<string> LP = new List<string>();
            string G = Pass + " " + Login;
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    LP.Add(line);
                }
            }
            foreach(string i in LP)
            {
                if (i == G)
                {
                    MessageBox.Show("Вы успешно вошли!");
                    break;
                }
                else
                {
                    MessageBox.Show("Пароль или логин не верны!");
                    H += 1;
                    if (H >= 3)
                    {
                        MessageBox.Show("Вы ошиблись слишком много раз. Попробуйте позже!");
                        button1.Enabled = false;
                        button2.Enabled = false;
                        button3.Enabled = false;
                    }
                    break;
                }
            }
        }
    }
}


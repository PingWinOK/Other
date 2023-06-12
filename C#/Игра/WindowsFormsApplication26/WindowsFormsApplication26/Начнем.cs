using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApplication26
{
    public partial class Form1 : Form
    {

        int num = 0;
        List<Рабы> Состояние = new List<Рабы>();
        double Раб,Цена_Раба = 100,Деньги = 100000,Инфляция = 0,День;
        double Уголь, Медь, Железо,Добыча;
        double Плантация = 1000, День_посадки;
        Кнопка K1,K2,K3,K4;
        int t;
        public Form1()
        {

            InitializeComponent();
            K1 = new Кнопка(button1, panel2, timer1);
            K2 = new Кнопка(button10, panel3, timer2);
            K3 = new Кнопка(button15, panel4, timer3);
            K4 = new Кнопка(button20, panel5, timer4);
            panel2.Blokc();
            panel3.Blokc();
            panel4.Blokc();
            panel5.Blokc();
            new ToolTip().SetToolTip(button5, "Цена" + "\nПроизводство");
            label1.Text = "Количество свободных рабов " + Раб;
            label3.Text = "Деньги: " + Деньги;
            label2.Text = "Цена раба: " + Цена_Раба;
            label4.Text = "Инфляция: " + Инфляция;
            label9.Text = "Стоймость плантации: " + Плантация;


        }
        private void button1_Click(object sender, EventArgs e)
        {
            K1.t_Start();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            K2.t_Start();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            K3.t_Start();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            K4.t_Start();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Цена_Раба = Цена_Раба + (Цена_Раба * Инфляция);
            if (Деньги >= Цена_Раба)
            {                
                
                Состояние.Add(new Рабы() { Сытость = 100, Усталость = 0,Номер = num++});
                Цена_Раба = Цена_Раба + 10;
                Деньги = Деньги - Цена_Раба;
                label1.Text = "Количество свободных рабов " + Состояние.Count;
                label3.Text = "Деньги: " + Деньги;
                label2.Text = "Цена раба: " + Цена_Раба;
                label4.Text = "Инфляция: " + Инфляция;
                numericUpDown1.Maximum = Convert.ToDecimal(Состояние.Count);



            }
            else
            {
                MessageBox.Show("Деняк нет на раба ебанного");
            }

        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (Состояние.Count > 0)
            {
                Состояние.RemoveAt(Состояние.Count - 1);
                label1.Text = "Количество свободных рабов " + Состояние.Count;
                numericUpDown1.Maximum = Convert.ToDecimal(Состояние.Count);
            }
            else
            {
                MessageBox.Show("Нет рабов");
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            День = День + 1;
            label5.Text = "День: " + День;
        }
        private bool Проверка(List<Рабы> Шахтеры, int r)
        {
            if (Шахтеры.Count != 0)
            {
                for (int i = 0; i < Шахтеры.Count; i++)
                {
                    if (Шахтеры[i].Номер == r)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            try
            {
                List<Рабы> Шахтеры = new List<Рабы>();
                do
                {
                    int r = new Random().Next(0, Состояние.Count);
                    if (Проверка(Шахтеры, r) == true)
                    {
                        Шахтеры.Add(Состояние[r]);
                    }
                }
                while (Шахтеры.Count < (int)numericUpDown1.Value);
                foreach (var item in Шахтеры)
                {
                    Состояние.Remove(Состояние.Where(i => i.Номер == item.Номер).First());   
                }
                if (radioButton1.Checked == true)
                {
                    Random Random = new Random();
                    for (int i = 0; i < numericUpDown1.Value; i++)
                    {
                        int a = Random.Next(0, 10);
                        Добыча = Добыча + a;
                    }
                    Уголь = Уголь + Добыча;
                    textBox1.Text += numericUpDown1.Value + " рабов добыли " + Добыча + " угля за сегодня" + Environment.NewLine;
                    Добыча = 0;
                    label6.Text = "Уголь: " + Уголь;
                    foreach (var ie in Шахтеры)
                    {
                        ie.Усталость = ie.Усталость + Random.Next(0, 5);
                        ie.Сытость = ie.Сытость - Random.Next(0, 5);
                    }
                    Состояние.AddRange(Шахтеры);
                    День = День + 1;
                    label5.Text = "День: " + День;


                }
            if (radioButton2.Checked == true)
            {
                Random Random = new Random();
                for (int i = 0; i < numericUpDown1.Value; i++)
                {
                    int a = Random.Next(0, 5);
                    Добыча = Добыча + a;
                }
                Медь = Медь + Добыча;
                textBox1.Text += numericUpDown1.Value + " рабов добыли " + Добыча + " меди за сегодня" + Environment.NewLine;
                Добыча = 0;
                label7.Text = "Медь: " + Медь;
                foreach (var ie in Шахтеры)
                {
                    ie.Усталость = ie.Усталость + Random.Next(0, 6);
                    ie.Сытость = ie.Сытость - Random.Next(0, 6);
                }
                Состояние.AddRange(Шахтеры);
                День = День + 1;
                label5.Text = "День: " + День;
            }
            if (radioButton3.Checked == true)
            {
                Random Random = new Random();
                for (int i = 0; i < numericUpDown1.Value; i++)
                {
                    int a = Random.Next(0, 3);
                    Добыча = Добыча + a;
                }
                Железо = Железо + Добыча;
                textBox1.Text += numericUpDown1.Value + " рабов добыли " + Добыча + " железа за сегодня" + Environment.NewLine;
                Добыча = 0;
                label8.Text = "Железо: " + Железо;
                foreach (var ie in Шахтеры)
                {
                    ie.Усталость = ie.Усталость + Random.Next(0, 7);
                    ie.Сытость = ie.Сытость - Random.Next(0, 7);
                }
                Состояние.AddRange(Шахтеры);
                День = День + 1;
                label5.Text = "День: " + День;
            }
        }
            catch
            {
                MessageBox.Show("Требуется нанять рабов");
            }
        }
        //Плантация
        
        static double g = 0;
        public static void Плант(ComboBox t, TextBox r, TextBox r1, TextBox h, TextBox h1, Button q, double g, GroupBox p)
        {
            int x = Convert.ToInt32(r.Text);
            int y = Convert.ToInt32(r1.Text);
            int x1 = Convert.ToInt32(h.Text);
            int y1 = Convert.ToInt32(h1.Text);
            switch (t.Text)
            {

                case "Картошка":
                    if (q.Text == "✖")
                    {
                        if (y > x)
                        {
                            r.Text = Convert.ToString(y);
                            h.Text = Convert.ToString(x1 + y1);
                            q.Text = "Картошка";
                            break;
                        }
                        else
                        {
                            r.Text = Convert.ToString(x);
                            h.Text = Convert.ToString(x1 + y1);
                            q.Text = "Картошка";
                            break;
                        }


                    }
                    else
                    {
                        break;
                    }

                case "Морковь":
                    if (q.Text == "✖")
                    {
                        if (y > x)
                        {
                            r.Text = Convert.ToString(y);
                            h.Text = Convert.ToString(x1 + y1);
                            q.Text = "Морковь";
                            break;
                        }
                        else
                        {
                            r.Text = Convert.ToString(x);
                            h.Text = Convert.ToString(x1 + y1);
                            q.Text = "Морковь";
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                case "Рис":
                    if (q.Text == "✖")
                    {
                        if (y > x)
                        {
                            r.Text = Convert.ToString(y);
                            h.Text = Convert.ToString(x1 + y1);
                            q.Text = "Рис";
                            break;
                        }
                        else
                        {
                            r.Text = Convert.ToString(x);
                            h.Text = Convert.ToString(x1 + y1);
                            q.Text = "Рис";
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                case "Дуб":
                    if (q.Text == "✖")
                    {
                        if (y > x)
                        {
                            r.Text = Convert.ToString(y);
                            h.Text = Convert.ToString(x1 + y1);
                            q.Text = "Дуб";
                            break;
                        }
                        else
                        {
                            r.Text = Convert.ToString(x);
                            h.Text = Convert.ToString(x1 + y1);
                            q.Text = "Дуб";
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
            }
        }
    
        public static void Рост(Button r, double День_посадки, double День, TextBox t, Label Картошка, Label Морковь, Label Рис, Label Дуб)
        {
            if (r.Text != "✖")
            {
               r.Enabled = false;
            }
           double Прошло;
           double Картошка1 = 0, Рис1 = 0, Морковка1 = 0, Дуб1 = 0;
           Прошло = День - День_посадки;
            switch (r.Text)
            {  
                case "Картошка":
                    if (Прошло == 3 && r.Text != "✖")
                    {
                        t.Text += "Картошка выросла" + Environment.NewLine;
                        double.TryParse(string.Join("", Convert.ToString(Картошка.Text).Where(c => char.IsDigit(c))), out Картошка1);
                        Картошка1 = Картошка1 + 1;
                        Картошка.Text = "Картошка:" + Картошка1;
                        r.Text = "✖";
                        r.Enabled = true;
                        break;
                    }
                    else
                    {
                        break;
                    }
                case "Морковь":
                    if (Прошло == 5 && r.Text != "✖")
                    {
                            t.Text += "Морковь выросла" + Environment.NewLine;
                            double.TryParse(string.Join("", Convert.ToString(Морковь.Text).Where(c => char.IsDigit(c))), out Морковка1);
                            Морковка1 = Морковка1 + 1;
                            r.Text = "✖";
                            Морковь.Text = "Морковь:" + Морковка1;
                            r.Enabled = true;
                            break;

                    }
                    else
                    {
                        break;
                    }
                case "Рис":
                    if (Прошло == 8 && r.Text != "✖")
                    {
                            t.Text += "Рис вырос" + Environment.NewLine;
                            double.TryParse(string.Join("", Convert.ToString(Рис.Text).Where(c => char.IsDigit(c))), out Рис1);
                            Рис1 = Рис1 + 1;
                            r.Text = "✖";
                            Рис.Text = "Рис:" + Рис1;
                            r.Enabled = true;
                            break;
                    }
                    else
                    {
                        break;
                    }
                case "Дуб":
                    if (Прошло == 4 && r.Text != "✖")
                    {
                            t.Text += "Дуб вырос" + Environment.NewLine;
                            double.TryParse(string.Join("", Convert.ToString(Дуб.Text).Where(c => char.IsDigit(c))), out Дуб1);
                            Дуб1 = Дуб1 + 1;
                            r.Text = "✖";
                             Дуб.Text = "Дуб:" + Дуб1;
                            r.Enabled = true;
                            break;
                    }
                    else
                    {
                        break;
                    }
            }
        }

        public void Цена_Посадки(Button r,Label t, double Деньги,TextBox g)
        {
            List<Рабы> Плантации = new List<Рабы>();
            do
            {
                int y = new Random().Next(0, Состояние.Count);
                if (Проверка(Плантации, y) == true)
                {
                    Плантации.Add(Состояние[y]);
                }
            }
            while (Плантации.Count < (int)numericUpDown1.Value);
            switch (r.Text)
            {
                case "Картошка":
                    {
                        double.TryParse(string.Join("", Convert.ToString(t.Text).Where(c => char.IsDigit(c))), out Деньги);
                        Деньги = Деньги - 100;
                        t.Text = "Деньги:" + Деньги;
                        break;
                    }

                case "Морковь":
                    {
                        double.TryParse(string.Join("", Convert.ToString(t.Text).Where(c => char.IsDigit(c))), out Деньги);
                        Деньги = Деньги - 200;
                        t.Text = "Деньги:" + Деньги;
                        break;
                    }

                case "Рис":
                    {
                        double.TryParse(string.Join("", Convert.ToString(t.Text).Where(c => char.IsDigit(c))), out Деньги);
                        Деньги = Деньги - 1000;
                        t.Text = "Деньги:" + Деньги;
                        break;
                    }
                case "Дуб":
                    {
                        double.TryParse(string.Join("", Convert.ToString(t.Text).Where(c => char.IsDigit(c))), out Деньги);
                        Деньги = Деньги - 300;
                        t.Text = "Деньги:" + Деньги;
                        break;
                    }
            }
        }
        private void button25_Click(object sender, EventArgs e)
        {
            if (button26.Visible == true)
            {
                Плант(comboBox1, textBox4, textBox2, textBox6, textBox5, button25, g , groupBox6);
                //g = g + 1;
            }
            else
            {
                if (Деньги >= Плантация)
                {
                    button26.Visible = true;
                    Деньги = Деньги - Плантация;
                    label3.Text = "Деньги: " + Деньги;
                    Плантация = Плантация + 1000;
                    label9.Text = "Стоимость плантации:" + Плантация;
                }

                else
                {
                    MessageBox.Show("Деняг мало");
                }
            }
        }
        private void button26_Click(object sender, EventArgs e)
        {
            if (button27.Visible == true)
            {
                Плант(comboBox1, textBox4, textBox2, textBox6, textBox5, button26,g,groupBox6);
                
                //g = g + 1;
            }
            else
            {
                if (Деньги >= Плантация)
                {
                    button27.Visible = true;
                    Деньги = Деньги - Плантация;
                    label3.Text = "Деньги: " + Деньги;
                    Плантация = Плантация + 1000;
                    label9.Text = "Стоимость плантации:" + Плантация;
                }
                else
                {
                    MessageBox.Show("Деняг мало");
                }
            }
        }
        private void button27_Click(object sender, EventArgs e)
        {
            if (button31.Visible == true)
            {
                Плант(comboBox1, textBox4, textBox2, textBox6, textBox5, button27, g, groupBox6);
                //g = g + 1;
            }
            else
            {
                if (Деньги >= Плантация)
                {
                    button31.Visible = true;
                    Деньги = Деньги - Плантация;
                    label3.Text = "Деньги: " + Деньги;
                    Плантация = Плантация + 1000;
                    label9.Text = "Стоимость плантации:" + Плантация;
                }
                else
                {
                    MessageBox.Show("Деняг мало");
                }
            }
        }
        private void button28_Click(object sender, EventArgs e)
        {
            if (button29.Visible == true)
            {
                Плант(comboBox1, textBox4, textBox2, textBox6, textBox5, button28, g, groupBox6);
                //g = g + 1;
            }
            else
            {

                if (Деньги >= Плантация)
                {
                    button29.Visible = true;
                    Деньги = Деньги - Плантация;
                    label3.Text = "Деньги: " + Деньги;
                    Плантация = Плантация + 1000;
                    label9.Text = "Стоимость плантации:" + Плантация;
                }
                else
                {
                    MessageBox.Show("Деняг мало");
                }
            }
        }
        private void button29_Click(object sender, EventArgs e)
        {
            if (button30.Visible == true)
            {
                Плант(comboBox1, textBox4, textBox2, textBox6, textBox5, button29, g, groupBox6);
                //g = g + 1;

            }
            else
            {

                if (Деньги >= Плантация)
                {
                    button30.Visible = true;
                    Деньги = Деньги - Плантация;
                    label3.Text = "Деньги: " + Деньги;
                    Плантация = Плантация + 1000;
                    label9.Text = "Стоимость плантации:" + Плантация;
               }
                else
                {
                    MessageBox.Show("Деняг мало");
                }
            }
        }
        private void button30_Click(object sender, EventArgs e)
        {
            if (button32.Visible == true)
            {
                Плант(comboBox1, textBox4, textBox2, textBox6, textBox5, button30, g, groupBox6);
                //g = g + 1;
            }
            else
            {
                if (Деньги >= Плантация)
                {
                    button32.Visible = true;
                    Деньги = Деньги - Плантация;
                    label3.Text = "Деньги: " + Деньги;
                    Плантация = Плантация + 1000;
                    label9.Text = "Стоимость плантации:" + Плантация;
               }
                else
                {
                    MessageBox.Show("Деняг мало");
                }
            }
        }
        private void button31_Click(object sender, EventArgs e)
        {
            if (button28.Visible == true)
            {
                Плант(comboBox1, textBox4, textBox2, textBox6, textBox5, button31, g, groupBox6);
                //g = g + 1;
            }
            else
            {
                if (Деньги >= Плантация)
                {
                    button28.Visible = true;
                    Деньги = Деньги - Плантация;
                    label3.Text = "Деньги: " + Деньги;
                    Плантация = Плантация + 1000;
                    label9.Text = "Стоимость плантации:" + Плантация;
                }

                else
                {
                    MessageBox.Show("Деняг мало");
                }
            }
        }
        private void button32_Click(object sender, EventArgs e)
        {
            if (t == 0)
            {
                if (Деньги >= Плантация)
                {
                    Деньги = Деньги - Плантация;
                    label3.Text = "Деньги: " + Деньги;
                    label9.Text = "Все плантации куплены";
                    t = t + 1;
                }
                else
                {
                    MessageBox.Show("Деняг мало");
                }
            }
            else
            {

                Плант(comboBox1, textBox4, textBox2, textBox6, textBox5, button32, g, groupBox6);
            }
        }
       
        private void button34_Click(object sender, EventArgs e)
        {
            numericUpDown1.Maximum = Convert.ToDecimal(Состояние.Count);
            label1.Text = "Количество свободных рабов " + Состояние.Count;
            День_посадки = День;
            Рост(button25, День_посадки, День, textBox3, label14, label15, label16, label17);
            Цена_Посадки(button25,label3, Деньги,textBox7);
            Рост(button26, День_посадки, День, textBox3, label14, label15, label16, label17);
            Цена_Посадки(button26, label3, Деньги, textBox7);
            Рост(button27, День_посадки, День, textBox3, label14, label15, label16, label17);
            Цена_Посадки(button27, label3, Деньги, textBox7);
            Рост(button31, День_посадки, День, textBox3, label14, label15, label16, label17);
            Цена_Посадки(button31, label3, Деньги, textBox7);
            Рост(button28, День_посадки, День, textBox3, label14, label15, label16, label17);
            Цена_Посадки(button28, label3, Деньги, textBox7);
            Рост(button29, День_посадки, День, textBox3, label14, label15, label16, label17);
            Цена_Посадки(button29, label3, Деньги, textBox7);
            Рост(button30, День_посадки, День, textBox3, label14, label15, label16, label17);
            Цена_Посадки(button30, label3, Деньги, textBox7);
            Рост(button32, День_посадки, День, textBox3, label14, label15, label16, label17);
            Цена_Посадки(button32, label3, Деньги, textBox7);
            
           
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "Картошка":
                    textBox2.Text = "3";
                    textBox5.Text = "50";
                    textBox7.Text = "3";
                    break;
                case "Морковь":
                    textBox2.Text = "5";
                    textBox5.Text = "100";
                    textBox7.Text = "5";
                    break;
                case "Рис":
                    textBox2.Text = "8";
                    textBox5.Text = "200";
                    textBox7.Text = "10";
                    break;
                case "Дуб":
                    textBox2.Text = "4";
                    textBox5.Text = "100";
                    textBox7.Text = "5";
                    break;
            }
        }

        public void Статус()
        {
            int[] Усталость_рабов = new int[Состояние.Count];
            int[] Сытость_рабов = new int[Состояние.Count];
            int Среднее = 0, Сумма = 0, Сытость = 0, Сытость_сред = 0;
            foreach (var ie in Состояние)
            {
                Сумма = Сумма + ie.Усталость;
                Сытость = Сытость + ie.Сытость;
            }
            Сытость_сред = Сытость / Состояние.Count;
            Среднее = Сумма / Состояние.Count;
            progressBar1.Value = Среднее;
            progressBar2.Value = Сытость_сред;
        }
        private void label5_TextChanged(object sender, EventArgs e)
        {
            int t;
            t = Convert.ToInt32(textBox4.Text);
            if (t > 0)
            {
                textBox4.Text = Convert.ToString(t - 1);
            }
            Рост(button25, День_посадки, День, textBox3, label14, label15, label16, label17);
            Рост(button26, День_посадки, День, textBox3, label14, label15, label16, label17);
            Рост(button27, День_посадки, День, textBox3, label14, label15, label16, label17);
            Рост(button31, День_посадки, День, textBox3, label14, label15, label16, label17);
            Рост(button28, День_посадки, День, textBox3, label14, label15, label16, label17);
            Рост(button29, День_посадки, День, textBox3, label14, label15, label16, label17);
            Рост(button30, День_посадки, День, textBox3, label14, label15, label16, label17);
            Рост(button32, День_посадки, День, textBox3, label14, label15, label16, label17);
            Статус();
        }






       

        


     
    }
}

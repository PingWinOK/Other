using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Курсовой_проект2019
{
    public partial class ДобавлениеPos : Form
    {
        public static string ConBD = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=KT.mdb";
        private OleDbConnection Connect;
        public ДобавлениеPos()
        {
            InitializeComponent();
            Connect = new OleDbConnection(ConBD);
            Connect.Open();
        }

        public void Цифры(KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public void Буквы(KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(conteyner.h);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Канцелярия main = this.Owner as Канцелярия;
            try
            {
           
                string query = "INSERT INTO Tovari ( №, Товар, Количество, Цена, Сумма, Примечание, Поставщик ) VALUES (" + textBox1.Text + ",'" + textBox2.Text + "'," + textBox3.Text + "," + textBox4.Text + "," + textBox5.Text + ",'" + textBox6.Text + "','" + textBox7.Text + "')";
                OleDbCommand comand = new OleDbCommand(query, Connect);
                OleDbDataReader otvet = comand.ExecuteReader();
                MessageBox.Show("Добавленно");
            }
            catch
            {
                MessageBox.Show("Проверьте правильность набора");
            }
            textBox1.Text = Convert.ToString(conteyner.h + 1);
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            Цифры(e);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            Цифры(e);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            Цифры(e);
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {

        }




    }

}

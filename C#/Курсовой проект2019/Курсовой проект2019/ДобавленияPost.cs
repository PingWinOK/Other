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
    public partial class ДобавленияPost : Form
    {
        public static string ConBD = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=KT.mdb";
        private OleDbConnection Connect;
        public ДобавленияPost()
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
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                string query = "INSERT INTO Postavchik ( [Порядковый номер], Поставщик, [Вид товаров], [Главный офис], [Количество товара на складе] ) VALUES (" + textBox1.Text + ",'" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
                OleDbCommand comand = new OleDbCommand(query, Connect);
                OleDbDataReader otvet = comand.ExecuteReader();

            }
            catch
            {
                MessageBox.Show("Проверьте правильность набора");
            }
            textBox1.Text = Convert.ToString(conteyner.t + 1);
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void ДобавленияPost_Load(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(conteyner.t);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            Цифры(e);
        }
    }
}

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
using System.Data.SqlClient;
using Tutorial.SqlConn;
using MySql.Data.MySqlClient;

namespace Курсовой_проект2019
{
    public partial class ДобавленияPost : Form
    {

        public ДобавленияPost()
        {
            InitializeComponent();
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
                MySqlConnection Connect = DBUtils.GetDBConnection();
                Connect.Open();
                string query = "INSERT INTO Postavchik ( `№`, Поставщик, `Вид товаров`, `Главный офис`, `Количество товара на складе` ) VALUES (" + textBox1.Text + ",'" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
                MySqlCommand command = new MySqlCommand(query, Connect);
                MySqlDataReader Otvet = command.ExecuteReader();
                Connect.Close();

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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

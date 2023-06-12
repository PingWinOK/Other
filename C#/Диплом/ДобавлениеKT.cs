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
    public partial class ДобавлениеPos : Form
    {

        public ДобавлениеPos()
        {
            InitializeComponent();
            MySqlConnection Connect = DBUtils.GetDBConnection();
            Connect.Open();
            string fard = "SELECT DISTINCT Поставщик FROM Postavchik";
            MySqlCommand command = new MySqlCommand(fard, Connect);
            MySqlDataReader Otvet = command.ExecuteReader();
            List<string> OList = new List<string>();
            foreach (var item in Otvet)
            {

                OList.Add(Otvet[0].ToString());
            }
            comboBox1.Items.Clear();
            conteyner.Поставщики_2 = OList;
            foreach (string s in OList)
                comboBox1.Items.Add(s);
            Connect.Close();
            //comboBox1.Items.AddRange(conteyner.Поставщики_2.ToArray());
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
                MySqlConnection Connect = DBUtils.GetDBConnection();
                Connect.Open();
                string query = "INSERT INTO Tovari ( №, Товар, Количество, Цена, Сумма, Примечание, Поставщик ) VALUES (" + textBox1.Text + ",'" + textBox2.Text + "'," + textBox3.Text + "," + textBox4.Text + "," + textBox5.Text + ",'" + textBox6.Text + "','"+ comboBox1.Text + "')";
                MySqlCommand command = new MySqlCommand(query, Connect);
                MySqlDataReader Otvet = command.ExecuteReader();
                Connect.Close();
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
            comboBox1.Text = "";

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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }

}

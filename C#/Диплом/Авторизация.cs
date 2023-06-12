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
    public partial class Авторизация : Form
    {
        public Авторизация()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string log = textBox1.Text;
                string pass = textBox2.Text;
                MySqlConnection Connect = DBUtils.GetDBConnection();
                Connect.Open();
                string query = "SELECT * FROM avto WHERE Логин LIKE '%" + textBox1.Text + "%' and Пароль LIKE '%" + textBox2.Text + "%'";
                MySqlCommand command = new MySqlCommand(query, Connect);
                MySqlDataReader Otvet = command.ExecuteReader();
                List<string> OList = new List<string>();
                foreach (var item in Otvet)
                {
                    OList.Add(Otvet[0].ToString());
                    OList.Add(Otvet[1].ToString());
                }
                if (OList[0] == log || OList[1] == pass)
                {
                    MessageBox.Show("Вы вошли");
                    Выбор_БД af = new Выбор_БД();
                    af.Show();
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль");
                }
                Connect.Close();
            }
            catch
            {
                MessageBox.Show("Неверный логин или пароль");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (groupBox1.Height == 88)
            {
                groupBox1.Height = 124;
            }
            else
            {
                groupBox1.Height = 88;
            }
        }

        private void Авторизация_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnection Connect2 = DBUtils.GetDBConnection();
            Connect2.Open();
            string query2 = "SELECT * FROM avto WHERE Пароль LIKE '%" + textBox3.Text + "%'";
            MySqlCommand command2 = new MySqlCommand(query2, Connect2);
            MySqlDataReader Otvet2 = command2.ExecuteReader();
            List<string> OList2 = new List<string>();
            try
            {
                foreach (var item in Otvet2)
                {
                    OList2.Add(Otvet2[0].ToString());
                }
            }
            catch
            {
                OList2.Add("Nan");
            }
            Connect2.Close();
            try
            {
                if (OList2[0] == textBox3.Text)
                {
                    string log = textBox1.Text;
                    string pass = textBox2.Text;
                    MySqlConnection Connect = DBUtils.GetDBConnection();
                    Connect.Open();
                    string query = "INSERT INTO avto ( Логин, Пароль) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "')";
                    MySqlCommand command = new MySqlCommand(query, Connect);
                    MySqlDataReader Otvet = command.ExecuteReader();
                    Connect.Close();
                    MessageBox.Show("Код принят");
                    MessageBox.Show("Регистрация завершена");
                    groupBox1.Height = 88;
                }
                else
                {
                    MessageBox.Show("Код неверен");
                }
            }
            catch
            {
                MessageBox.Show("Код неверен");
            }
        }

    }
}

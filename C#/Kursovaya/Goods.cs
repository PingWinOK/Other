using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Kursovaya
{
    public partial class Goods : Form
    {
        private MySqlConnection conn = null;
        public Goods()
        {
            InitializeComponent();
            const string Connect = "Server =  127.0.0.1; Database = mydb; port= 3306; User Id = root; password= 123123";
            conn = new MySqlConnection(Connect);
            conn.OpenAsync();
            MySqlCommand command = new MySqlCommand("SELECT Provider_Name FROM provider", conn);
            MySqlDataReader sqlReader = null;
            command.ExecuteNonQueryAsync();
            sqlReader = command.ExecuteReader();
            while (sqlReader.Read())
            {
                ListViewItem item = new ListViewItem(new string[] {
                Convert.ToString(sqlReader[0]),
                         });
                comboBox1.Items.Add(item.Text);
            }
            conn.CloseAsync();
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {

            if (
                  !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) &&
                  !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text) &&
                  !string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox5.Text) &&
                  !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text) &&
                  !string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox6.Text))
            {
                await conn.CloseAsync();
                await conn.OpenAsync();
                string ID;
                MySqlCommand command = new MySqlCommand("INSERT INTO `goods` (`Quantity`, `Product_Name`, `Selling_price`, `Units`, `Purchase_price`,`Provider_idProvider`) VALUES (@QUA, @PNAME, @SELLP, @UNI, @PUR, @PRO);", conn);
                MySqlCommand command1 = new MySqlCommand("SELECT idProvider FROM provider where Provider_Name = @PRO;", conn);
                command.Parameters.AddWithValue("QUA", textBox2.Text);
                command.Parameters.AddWithValue("PNAME", textBox3.Text);
                command.Parameters.AddWithValue("SELLP", textBox4.Text);
                command.Parameters.AddWithValue("UNI", textBox5.Text);
                command.Parameters.AddWithValue("PUR", textBox6.Text);
                command1.Parameters.AddWithValue("PRO", comboBox1.Text);
                ID = comboBox1.Text;
                MySqlDataReader sqlReader1 = null;
                await command1.ExecuteNonQueryAsync();
                sqlReader1 = command1.ExecuteReader();
                while (sqlReader1.Read())
                {
                    ListViewItem item = new ListViewItem(new string[] {
                    Convert.ToString(sqlReader1[0]),
                         });
                    ID = item.Text;
                }
                await conn.CloseAsync();
                command.Parameters.AddWithValue("PRO", ID);
                await conn.OpenAsync();
                try
                {
                    await command.ExecuteNonQueryAsync();
                    MessageBox.Show("Добавление прошло успешно", "Добавление прошло успешно", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            conn.Close();
            this.Hide();
            Baza F = new Baza();
            F.Show();
            MySqlDataReader sqlReader = null;
            F.listView1.Clear();
            F.listView1.GridLines = true;
            F.listView1.FullRowSelect = true;
            F.listView1.View = View.Details;
            F.listView1.Columns.Add("Код товара");
            F.listView1.Columns.Add("Количество");
            F.listView1.Columns.Add("Название товара");
            F.listView1.Columns.Add("Цена продажи");
            F.listView1.Columns.Add("Ед.измерения");
            F.listView1.Columns.Add("Цена покупки");
            F.listView1.Columns.Add("Поставщик");
            F.listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            F.listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            conn.Open();
            MySqlCommand command = new MySqlCommand(@"SELECT idGoods AS `Код товара`, 
                                                        Quantity AS `Количество`, 
                                                        Product_Name AS `Название товара`, 
                                                        Selling_price AS `Цена продажи`, 
                                                        Units AS `Ед.измерения`, 
                                                        Purchase_price AS `Цена покупки`, 
                                                        Provider_Name AS `Поставщик`
                                                        FROM goods, provider WHERE Provider_idProvider = idProvider; ", conn);
            await command.ExecuteNonQueryAsync();
            sqlReader = command.ExecuteReader();
            while (await sqlReader.ReadAsync())
            {
                ListViewItem item = new ListViewItem(new string[] {
                    Convert.ToString(sqlReader["Код товара"]),
                    Convert.ToString(sqlReader["Количество"]),
                    Convert.ToString(sqlReader["Название товара"]),
                    Convert.ToString(sqlReader["Цена продажи"]),
                    Convert.ToString(sqlReader["Ед.измерения"]),
                    Convert.ToString(sqlReader["Цена покупки"]),
                    Convert.ToString(sqlReader["Поставщик"]),
                         });
                F.listView1.Items.Add(item);
            }
            Close();
            F.table = 1;
        }
    }
}

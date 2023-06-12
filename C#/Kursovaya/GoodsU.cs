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
    public partial class GoodsU : Form
    {
        private int id;
        private MySqlConnection conn = null;
        private int Prov;
        public GoodsU(int id)
        {
            InitializeComponent();
            this.id = id;
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

        private async void button2_Click(object sender, EventArgs e)
        {
            conn.Close();
            this.Hide();
            Baza F = new Baza();
            F.Show();
            MySqlDataReader sqlReader1 = null;
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
            MySqlCommand command1 = new MySqlCommand(@"SELECT idGoods AS `Код товара`, 
                                                        Quantity AS `Количество`, 
                                                        Product_Name AS `Название товара`, 
                                                        Selling_price AS `Цена продажи`, 
                                                        Units AS `Ед.измерения`, 
                                                        Purchase_price AS `Цена покупки`, 
                                                        Provider_Name AS `Поставщик`
                                                        FROM goods, provider WHERE Provider_idProvider = idProvider; ", conn);
            await command1.ExecuteNonQueryAsync();
            sqlReader1 = command1.ExecuteReader();
            while (await sqlReader1.ReadAsync())
            {
                ListViewItem item = new ListViewItem(new string[] {
                    Convert.ToString(sqlReader1["Код товара"]),
                    Convert.ToString(sqlReader1["Количество"]),
                    Convert.ToString(sqlReader1["Название товара"]),
                    Convert.ToString(sqlReader1["Цена продажи"]),
                    Convert.ToString(sqlReader1["Ед.измерения"]),
                    Convert.ToString(sqlReader1["Цена покупки"]),
                    Convert.ToString(sqlReader1["Поставщик"]),
                         });
                F.listView1.Items.Add(item);
            }
            Close();
            F.table = 1;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            MySqlCommand UGoods = new MySqlCommand(@"UPDATE goods SET Quantity = @Q, Product_Name = @PN, Selling_price = @SP, Units = @U, Purchase_price = @PP, Provider_idProvider = @PID WHERE (idGoods = @id);", conn);
            MySqlCommand command = new MySqlCommand("SELECT idProvider FROM provider where Provider_Name = @PRO;", conn);
            UGoods.Parameters.AddWithValue("id", id);
            UGoods.Parameters.AddWithValue("Q", textBox2.Text);
            UGoods.Parameters.AddWithValue("PN", textBox3.Text);
            UGoods.Parameters.AddWithValue("SP", Convert.ToInt32(textBox4.Text));
            UGoods.Parameters.AddWithValue("U", textBox5.Text);
            UGoods.Parameters.AddWithValue("PP", Convert.ToInt32(textBox6.Text));
            command.Parameters.AddWithValue("PRO", comboBox1.Text);
            string ID = comboBox1.Text;
            MySqlDataReader sqlReader = null;
            await command.ExecuteNonQueryAsync();
            sqlReader = command.ExecuteReader();
            while (sqlReader.Read())
            {
                ListViewItem item = new ListViewItem(new string[] {
                    Convert.ToString(sqlReader[0]),
                         });
                ID = item.Text;
            }
            await conn.CloseAsync();
            UGoods.Parameters.AddWithValue("PID", ID);
            conn.Open();
            await UGoods.ExecuteNonQueryAsync();
            MessageBox.Show("Изменение прошло успешно", "Изменение прошло успешно", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            conn.Close();
            this.Hide();
            Baza F = new Baza();
            F.Show();
            MySqlDataReader sqlReader1 = null;
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
            MySqlCommand command1 = new MySqlCommand(@"SELECT idGoods AS `Код товара`, 
                                                        Quantity AS `Количество`, 
                                                        Product_Name AS `Название товара`, 
                                                        Selling_price AS `Цена продажи`, 
                                                        Units AS `Ед.измерения`, 
                                                        Purchase_price AS `Цена покупки`, 
                                                        Provider_Name AS `Поставщик`
                                                        FROM goods, provider WHERE Provider_idProvider = idProvider; ", conn);
            await command1.ExecuteNonQueryAsync();
            sqlReader1 = command1.ExecuteReader();
            while (await sqlReader1.ReadAsync())
            {
                ListViewItem item = new ListViewItem(new string[] {
                    Convert.ToString(sqlReader1["Код товара"]),
                    Convert.ToString(sqlReader1["Количество"]),
                    Convert.ToString(sqlReader1["Название товара"]),
                    Convert.ToString(sqlReader1["Цена продажи"]),
                    Convert.ToString(sqlReader1["Ед.измерения"]),
                    Convert.ToString(sqlReader1["Цена покупки"]),
                    Convert.ToString(sqlReader1["Поставщик"]),
                         });
                F.listView1.Items.Add(item);
            }
            Close();
            F.table = 1;
        }

        private async void GoodsU_Load(object sender, EventArgs e)
        {
            conn.Close();
            conn.Open();
            MySqlCommand command = new MySqlCommand(@"SELECT idGoods AS `Код товара`, 
                                                        Quantity AS `Количество`, 
                                                        Product_Name AS `Название товара`, 
                                                        Selling_price AS `Цена продажи`, 
                                                        Units AS `Ед.измерения`, 
                                                        Purchase_price AS `Цена покупки`, 
                                                        Provider_idProvider AS `Поставщик`
                                                        FROM goods, provider WHERE idGoods = @id;", conn);
            command.Parameters.AddWithValue("id", id);

            MySqlDataReader sqlReader = null;
            try
            {
                sqlReader = command.ExecuteReader();
                while (await sqlReader.ReadAsync())
                {

                    textBox2.Text = Convert.ToString(sqlReader["Количество"]);
                    textBox3.Text = Convert.ToString(sqlReader["Название товара"]);
                    textBox4.Text = Convert.ToString(Convert.ToInt32(sqlReader["Цена продажи"]));
                    textBox5.Text = Convert.ToString(sqlReader["Ед.измерения"]);
                    textBox6.Text = Convert.ToString(Convert.ToInt32(sqlReader["Цена покупки"]));
                    comboBox1.SelectedIndex = Convert.ToInt32(sqlReader["Поставщик"]) -1;
                    Prov = Convert.ToInt32(sqlReader["Поставщик"]) - 1;


                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message.ToString(), exp.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();


        }
    }
}

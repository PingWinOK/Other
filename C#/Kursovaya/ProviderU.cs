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
    public partial class ProviderU : Form
    {
        private int id;
        private MySqlConnection conn = null;
        public ProviderU(int id)
        {
            this.id = id;
            InitializeComponent();
            const string Connect = "Server =  127.0.0.1; Database = mydb; port= 3306; User Id = root; password= 123123";
            conn = new MySqlConnection(Connect);
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Baza F = new Baza();
            F.Show();

            F.table = 5;
            await conn.CloseAsync();
            await conn.OpenAsync();
            F.listView1.Clear();
            F.listView1.GridLines = true;
            F.listView1.FullRowSelect = true;
            F.listView1.View = View.Details;
            F.listView1.Columns.Add("Код поставщика");
            F.listView1.Columns.Add("Имя поставщика");
            F.listView1.Columns.Add("Адрес поставщика");
            F.listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            F.listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            MySqlDataReader sqlReader = null;
            MySqlCommand command = new MySqlCommand(@"SELECT idProvider AS `Код поставщика`, 
                                                        Provider_Name AS `Имя поставщика`,
                                                        Address AS `Адрес поставщика`   
                                                        FROM provider", conn);
            try
            {
                sqlReader = command.ExecuteReader();

                while (await sqlReader.ReadAsync())
                {
                    ListViewItem item = new ListViewItem(new string[] {
                    Convert.ToString(sqlReader["Код поставщика"]),
                    Convert.ToString(sqlReader["Имя поставщика"]),
                    Convert.ToString(sqlReader["Адрес поставщика"]),
                         });
                    F.listView1.Items.Add(item);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null && !sqlReader.IsClosed)
                    sqlReader.Close();
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            conn.Close();
            conn.Open();
            MySqlCommand UGoods = new MySqlCommand(@"UPDATE provider SET Provider_Name = @PN, Address = @ADD WHERE (idProvider = @id);", conn);
            UGoods.Parameters.AddWithValue("id", id);
            UGoods.Parameters.AddWithValue("PN", textBox2.Text);
            UGoods.Parameters.AddWithValue("ADD", textBox3.Text);
            await UGoods.ExecuteNonQueryAsync();
            MessageBox.Show("Изменение прошло успешно", "Изменение прошло успешно", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            conn.Close();
            this.Hide();
            Baza F = new Baza();
            F.Show();
            F.table = 5;
            await conn.CloseAsync();
            await conn.OpenAsync();
            F.listView1.Clear();
            F.listView1.GridLines = true;
            F.listView1.FullRowSelect = true;
            F.listView1.View = View.Details;
            F.listView1.Columns.Add("Код поставщика");
            F.listView1.Columns.Add("Имя поставщика");
            F.listView1.Columns.Add("Адрес поставщика");
            F.listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            F.listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            MySqlDataReader sqlReader1 = null;
            MySqlCommand command1 = new MySqlCommand(@"SELECT idProvider AS `Код поставщика`, 
                                                        Provider_Name AS `Имя поставщика`,
                                                        Address AS `Адрес поставщика`   
                                                        FROM provider", conn);
            try
            {
                sqlReader1 = command1.ExecuteReader();

                while (await sqlReader1.ReadAsync())
                {
                    ListViewItem item = new ListViewItem(new string[] {
                    Convert.ToString(sqlReader1["Код поставщика"]),
                    Convert.ToString(sqlReader1["Имя поставщика"]),
                    Convert.ToString(sqlReader1["Адрес поставщика"]),
                         });
                    F.listView1.Items.Add(item);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader1 != null && !sqlReader1.IsClosed)
                    sqlReader1.Close();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private async void ProviderU_Load(object sender, EventArgs e)
        {
            conn.Close();
            conn.Open();
            MySqlCommand command = new MySqlCommand(@"SELECT Provider_Name AS `Имя поставщика`, 
                                                        Address AS `Адрес поставщика`
                                                                FROM provider WHERE idProvider=@id", conn);
            command.Parameters.AddWithValue("id", id);

            MySqlDataReader sqlReader = null;
            try
            {
                sqlReader = command.ExecuteReader();
                while (await sqlReader.ReadAsync())
                {

                    textBox2.Text = Convert.ToString(sqlReader["Имя поставщика"]);
                    textBox3.Text = Convert.ToString(sqlReader["Адрес поставщика"]);


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


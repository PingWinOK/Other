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
    public partial class Provider : Form
    {
        MySqlDataAdapter mda;
        DataSet ds;
        private MySqlConnection conn = null;
        public Provider()
        {
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
            if (!string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text) &&
                 !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text))
            {
                await conn.CloseAsync();
                await conn.OpenAsync();
                MySqlCommand command = new MySqlCommand("INSERT INTO `provider` (`Provider_Name`, `Address`) VALUES (@Name, @AD);", conn);
                command.Parameters.AddWithValue("Name", textBox2.Text);
                command.Parameters.AddWithValue("AD", textBox3.Text);
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

        private void Provider_Load(object sender, EventArgs e)
        {

        }
    }
}

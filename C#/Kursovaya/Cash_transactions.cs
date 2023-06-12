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
    public partial class Cash_transactions : Form
    {
        private MySqlConnection conn = null;
        public Cash_transactions()
        {
            InitializeComponent();
            const string Connect = "Server =  127.0.0.1; Database = mydb; port= 3306; User Id = root; password= 123123";
            conn = new MySqlConnection(Connect);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Baza F = new Baza();
            F.Show();
            F.table = 7;
            await conn.CloseAsync();
            await conn.OpenAsync();
            F.listView1.Clear();
            F.listView1.GridLines = true;
            F.listView1.FullRowSelect = true;
            F.listView1.View = View.Details;
            F.listView1.Columns.Add("Код транзакции");
            F.listView1.Columns.Add("Назначение");
            F.listView1.Columns.Add("Сумма");
            F.listView1.Columns.Add("Дата/Время");
            F.listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            F.listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
           
            MySqlDataReader sqlReader = null;
            MySqlCommand command = new MySqlCommand(@"SELECT idCash_transactions AS `Код транзакции`, 
                                                            Appointment AS `Назначение`,
                                                            Sum AS `Сумма`,
                                                            Date_Time AS `Дата/Время`
                                                            FROM cash_transactions", conn);
            try
            {
                sqlReader = command.ExecuteReader();

                while (await sqlReader.ReadAsync())
                {
                    ListViewItem item = new ListViewItem(new string[] {
                    Convert.ToString(sqlReader["Код транзакции"]),
                    Convert.ToString(sqlReader["Назначение"]),
                    Convert.ToString(sqlReader["Сумма"]),
                    Convert.ToString(sqlReader["Дата/Время"]),
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
            if (!string.IsNullOrEmpty(comboBox1.Text) && !string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                await conn.CloseAsync();
                await conn.OpenAsync();
                MySqlCommand command = new MySqlCommand("INSERT INTO `cash_transactions` (`Appointment`, `Sum`, `Date_Time`) VALUES ( @APP, @Sum, @Date);", conn);
                command.Parameters.AddWithValue("Date", dateTimePicker1.Text);
                command.Parameters.AddWithValue("Sum", textBox2.Text);
                command.Parameters.AddWithValue("APP", comboBox1.Text);
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
    }
}

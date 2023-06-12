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
    public partial class Cash_transactionsU : Form
    {
        private MySqlConnection conn = null;
        private int id;
        private string NAZ;
        public Cash_transactionsU(int id)
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

        private async void Cash_transactionsU_Load(object sender, EventArgs e)
        {
            conn.Close();
            conn.Open();
            MySqlCommand command = new MySqlCommand(@"SELECT idCash_transactions AS `Код транзакции`, 
                                                            Appointment AS `Назначение`,
                                                            Sum AS `Сумма`,
                                                            Date_Time AS `Дата/Время`
                                                            FROM cash_transactions WHERE idCash_transactions = @id ", conn);
            command.Parameters.AddWithValue("id", id);

            MySqlDataReader sqlReader = null;
            try
            {
                sqlReader = command.ExecuteReader();
                while (await sqlReader.ReadAsync())
                {

                    dateTimePicker1.Text = Convert.ToString(sqlReader["Дата/Время"]);
                    textBox2.Text = Convert.ToString(Convert.ToInt32(sqlReader["Сумма"]));
                    comboBox1.Text = Convert.ToString(sqlReader["Назначение"]);
                    NAZ = Convert.ToString(sqlReader["Назначение"]);


                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message.ToString(), exp.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            conn.Close();
            conn.Open();
            MySqlCommand UGoods = new MySqlCommand(@"UPDATE cash_transactions SET Appointment = @AP, Sum = @SUM,Date_Time = @DATE WHERE (idCash_transactions = @id);", conn);
            UGoods.Parameters.AddWithValue("id", id);
            UGoods.Parameters.AddWithValue("AP", comboBox1.Text);
            UGoods.Parameters.AddWithValue("SUM", textBox2.Text);
            UGoods.Parameters.AddWithValue("DATE", dateTimePicker1.Text);
            await UGoods.ExecuteNonQueryAsync();
            MessageBox.Show("Изменение прошло успешно", "Изменение прошло успешно", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            conn.Close();
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
    }
}

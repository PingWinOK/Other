using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Kursovaya
{
    public partial class Purchases : Form
    {
        MySqlDataAdapter mda;
        DataSet ds;
        private MySqlConnection conn = null;
        public Purchases()
        {
            InitializeComponent();
            const string Connect = "Server =  127.0.0.1; Database = mydb; port= 3306; User Id = root; password= 123123";
            conn = new MySqlConnection(Connect);
            conn.Open();
            MySqlDataAdapter Goods = new MySqlDataAdapter("SELECT * FROM goods;", conn);
            DataTable Good = new DataTable();
            Goods.Fill(Good);
            comboBox3.DataSource = Good;
            comboBox3.ValueMember = "Product_Name";
            comboBox3.DisplayMember = "name";
            MySqlDataAdapter IN = new MySqlDataAdapter("SELECT * FROM cash_transactions;", conn);
            DataTable cash = new DataTable();
            IN.Fill(cash);
            conn.CloseAsync();


        }

        private async void button1_Click(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(comboBox1.Text) && !string.IsNullOrWhiteSpace(comboBox1.Text))
            //{
            //    await conn.CloseAsync();
            //    await conn.OpenAsync();
            //    MySqlCommand command = new MySqlCommand("INSERT INTO `purchases` (`Purchase_date`, `Completion_status`, `Cash_transactions_idCash_transactions`) VALUES (@Date, @Stat, @Cash);", conn);
            //    command.Parameters.AddWithValue("Date", dateTimePicker1.Text);
            //    command.Parameters.AddWithValue("Stat", checkBox1.Checked);
            //    command.Parameters.AddWithValue("Cash", comboBox1.Text);
            //    try
            //    {
            //        await command.ExecuteNonQueryAsync();
            //        MessageBox.Show("Добавление прошло успешно", "Добавление прошло успешно", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Заполните все поля", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //conn.Close();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            Baza f = new Baza();
            f.Show();
            Close();
            await conn.CloseAsync();
            await conn.OpenAsync();
            f.listView1.Clear();
            f.listView1.GridLines = true;
            f.listView1.FullRowSelect = true;
            f.listView1.View = View.Details;
            f.listView1.Columns.Add("Код закупки");
            f.listView1.Columns.Add("Дата закупки");
            f.listView1.Columns.Add("Статус");
            f.listView1.Columns.Add("Транзакция");
            f.listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            f.listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            f.table = 2;
            MySqlDataReader sqlReader = null;
            MySqlCommand command = new MySqlCommand(@"SELECT idPurchases AS `Код закупки`, 
                                                            Purchase_date AS `Дата закупки`,
                                                            Completion_status AS `Статус`,
                                                            Cash_transactions_idCash_transactions AS `Транзакция`
                                                            FROM purchases", conn);
            try
            {
                sqlReader = command.ExecuteReader();

                while (await sqlReader.ReadAsync())
                {
                    ListViewItem item = new ListViewItem(new string[] {
                    Convert.ToString(sqlReader["Код закупки"]),
                    Convert.ToString(sqlReader["Дата закупки"]),
                    Convert.ToString(sqlReader["Статус"]),
                    Convert.ToString(sqlReader["Транзакция"]),
                         });
                    f.listView1.Items.Add(item);
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

        private void Purchases_Load(object sender, EventArgs e)
        {
            listView1.Clear();
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.View = View.Details;
            listView1.Columns.Add("Название");
            listView1.Columns.Add("Количество");
            listView1.Columns.Add("Сумма");
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            await conn.CloseAsync();
            await conn.OpenAsync();
            int GSum = 0;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                GSum += Convert.ToInt32(listView1.Items[i].SubItems[2].Text);
            }
            DateTime date = DateTime.Now;
            string Date = date.ToString("yyyy-MM-dd hh:mm:ss");
            MySqlCommand command1 = new MySqlCommand("INSERT INTO `cash_transactions` (`Appointment`, `Sum`, `Date_Time`) VALUES ( @APP, @Sum, @Date);", conn);
            command1.Parameters.AddWithValue("Date", Date);
            command1.Parameters.AddWithValue("Sum", GSum);
            command1.Parameters.AddWithValue("APP", "purchase");
            await command1.ExecuteNonQueryAsync();
            MySqlCommand command2 = new MySqlCommand("SELECT idCash_transactions FROM Cash_transactions ORDER BY idCash_transactions DESC LIMIT 1", conn);
            int IDT = 0;
            MySqlDataReader sqlReader2 = null;
            await command2.ExecuteNonQueryAsync();
            sqlReader2 = command2.ExecuteReader();
            while (sqlReader2.Read())
            {
                ListViewItem item = new ListViewItem(new string[] {
                    Convert.ToString(sqlReader2[0]),
                         });
                IDT = Convert.ToInt32(item.Text);
            }
            await conn.CloseAsync();
            await conn.OpenAsync();
            MySqlCommand command3 = new MySqlCommand("INSERT INTO `purchases` ( `Purchase_date`, `Completion_status`, `Cash_transactions_idCash_transactions`) VALUES ( @Date, @CS, @IDT);", conn);
            command3.Parameters.AddWithValue("Date", Date);
            command3.Parameters.AddWithValue("CS", checkBox1.Checked); ;
            command3.Parameters.AddWithValue("IDT", IDT);
            await conn.CloseAsync();

            try
            {
                await conn.OpenAsync();
                await command3.ExecuteNonQueryAsync();
                await conn.CloseAsync();
                MessageBox.Show("Добавление прошло успешно", "Добавление прошло успешно", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                await conn.CloseAsync();
                await conn.OpenAsync();
                int Q;
                Q = Convert.ToInt32(listView1.Items[i].SubItems[1].Text);
                MySqlCommand GO = new MySqlCommand("SELECT idGoods FROM goods WHERE Product_Name = @GO;", conn);
                GO.Parameters.AddWithValue("GO", listView1.Items[i].SubItems[0].Text);
                int GID = 0;
                MySqlDataReader sqlReaderGO = null;
                await GO.ExecuteNonQueryAsync();
                sqlReaderGO = GO.ExecuteReader();
                while (sqlReaderGO.Read())
                {
                    ListViewItem item = new ListViewItem(new string[] {
                    Convert.ToString(sqlReaderGO[0]),
                         });
                    GID = Convert.ToInt32(item.Text);
                }
                MySqlCommand PU = new MySqlCommand("SELECT idPurchases FROM purchases ORDER BY idPurchases DESC LIMIT 1", conn);
                int PID = 0;
                MySqlDataReader sqlReaderPU = null;
                await conn.CloseAsync();
                await conn.OpenAsync();
                await PU.ExecuteNonQueryAsync();
                sqlReaderPU = PU.ExecuteReader();
                while (sqlReaderPU.Read())
                {
                    ListViewItem item = new ListViewItem(new string[] {
                    Convert.ToString(sqlReaderPU[0]),
                         });
                    PID = Convert.ToInt32(item.Text);
                }

                MySqlCommand command0 = new MySqlCommand("INSERT INTO `purchase_item` (`Quantity`, `Goods_idGoods`, `Purchases_idPurchases`) VALUES ( @Q, @GID, @PID);", conn);
                command0.Parameters.AddWithValue("Q", Q);
                command0.Parameters.AddWithValue("GID", GID);
                command0.Parameters.AddWithValue("PID", PID);
                await conn.CloseAsync();
                await conn.OpenAsync();
                await command0.ExecuteNonQueryAsync();
                await conn.CloseAsync();

            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            await conn.CloseAsync();
            await conn.OpenAsync();
            string Name = comboBox3.Text;
            string Quantity = Convert.ToString(numericUpDown1.Value);
            string SUM = null;
            string prise = null;
            int num;
            MySqlCommand command = new MySqlCommand("SELECT Purchase_price FROM goods where Product_Name = @Name;", conn);
            command.Parameters.AddWithValue("Name", Name);
            MySqlDataReader sqlReader = null;
            await command.ExecuteNonQueryAsync();
            sqlReader = command.ExecuteReader();
            while (sqlReader.Read())
            {
                ListViewItem item = new ListViewItem(new string[] {
                    Convert.ToString(sqlReader[0]),
                         });
                prise = item.Text;
            }
            IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "," };
            double p = double.Parse(prise, formatter);
            SUM = Convert.ToString(p * Convert.ToDouble(Quantity));
            await conn.CloseAsync();
            listView1.Items.Add(new ListViewItem(new[] { Name, Quantity, SUM }));

        }

        private async void button4_Click(object sender, EventArgs e)
        {
            Baza f = new Baza();
            f.Show();
            Close();
            f.table = 2;
            await conn.CloseAsync();
            await conn.OpenAsync();
            f.listView1.Clear();
            f.listView1.GridLines = true;
            f.listView1.FullRowSelect = true;
            f.listView1.View = View.Details;
            f.listView1.Columns.Add("Код закупки");
            f.listView1.Columns.Add("Дата закупки");
            f.listView1.Columns.Add("Статус");
            f.listView1.Columns.Add("Транзакция");
            f.listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            f.listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            MySqlDataReader sqlReader = null;
            MySqlCommand command = new MySqlCommand(@"SELECT idPurchases AS `Код закупки`, 
                                                            Purchase_date AS `Дата закупки`,
                                                            Completion_status AS `Статус`,
                                                            Cash_transactions_idCash_transactions AS `Транзакция`
                                                            FROM purchases", conn);
            try
            {
                sqlReader = command.ExecuteReader();

                while (await sqlReader.ReadAsync())
                {
                    ListViewItem item = new ListViewItem(new string[] {
                    Convert.ToString(sqlReader["Код закупки"]),
                    Convert.ToString(sqlReader["Дата закупки"]),
                    Convert.ToString(sqlReader["Статус"]),
                    Convert.ToString(sqlReader["Транзакция"]),
                         });
                    f.listView1.Items.Add(item);
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

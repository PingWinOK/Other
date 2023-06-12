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
using System.Globalization;

namespace Kursovaya
{
    public partial class Sales : Form
    {
        private MySqlConnection conn = null;
        public Sales()
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
            MySqlDataAdapter EM = new MySqlDataAdapter("SELECT * FROM employee;", conn);
            DataTable emp = new DataTable();
            EM.Fill(emp);
            comboBox2.DataSource = emp;
            comboBox2.ValueMember = "Full_Name";
            comboBox2.DisplayMember = "name";
            conn.CloseAsync();

        }

        private async void button1_Click(object sender, EventArgs e)
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
            command1.Parameters.AddWithValue("APP", "sale");
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
            MySqlCommand command3 = new MySqlCommand("INSERT INTO `sales` ( `Date_of_sale`, `Cash_transactions_idCash_transactions`, `Employees_idEmployees`) VALUES ( @Date, @IDT, @IDS);", conn);
            MySqlCommand command4 = new MySqlCommand("SELECT idEmployees FROM employee where Full_Name = @IDS;", conn);
            command3.Parameters.AddWithValue("Date", Date);
            command3.Parameters.AddWithValue("IDT", IDT);
            command4.Parameters.AddWithValue("IDS", comboBox2.Text);
            string IDS = comboBox2.Text;
            MySqlDataReader sqlReader4 = null;
            await command4.ExecuteNonQueryAsync();
            sqlReader4 = command4.ExecuteReader();
            while (sqlReader4.Read())
            {
                ListViewItem item = new ListViewItem(new string[] {
                    Convert.ToString(sqlReader4[0]),
                         });
                IDS = item.Text;
            }
            await conn.CloseAsync();
            command3.Parameters.AddWithValue("IDS", IDS);
     
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
                MySqlCommand SEL = new MySqlCommand("SELECT idSales FROM sales ORDER BY idSales DESC LIMIT 1", conn);
                int SID = 0;
                MySqlDataReader sqlReaderSEL = null;
                await conn.CloseAsync();
                await conn.OpenAsync();
                await SEL.ExecuteNonQueryAsync();
                sqlReaderSEL = SEL.ExecuteReader();
                while (sqlReaderSEL.Read())
                {
                    ListViewItem item = new ListViewItem(new string[] {
                    Convert.ToString(sqlReaderSEL[0]),
                         });
                    SID = Convert.ToInt32(item.Text);
                }

                MySqlCommand command0 = new MySqlCommand("INSERT INTO `product_sale` (`Quantity`, `Goods_idGoods`, `Sales_idSales`) VALUES ( @Q, @GID, @SID);", conn);
                command0.Parameters.AddWithValue("Q", Q);
                command0.Parameters.AddWithValue("GID", GID);
                command0.Parameters.AddWithValue("SID", SID);
                await conn.CloseAsync();
                await conn.OpenAsync();
                await command0.ExecuteNonQueryAsync();
                await conn.CloseAsync();

            }
            //    await conn.CloseAsync();
            //    await conn.OpenAsync();
            //    MySqlCommand command = new MySqlCommand("INSERT INTO `sales` ( `Date_of_sale`, `Cash_transactions_idCash_transactions`, `Employees_idEmployees`) VALUES ( @Date, @IDT, @IDS);", conn);
            //if (!string.IsNullOrEmpty(comboBox1.Text) && !string.IsNullOrWhiteSpace(comboBox1.Text) &&
            //     !string.IsNullOrEmpty(comboBox2.Text) && !string.IsNullOrWhiteSpace(comboBox2.Text))
            //{
            //    await conn.CloseAsync();
            //    await conn.OpenAsync();
            //    MySqlCommand command = new MySqlCommand("INSERT INTO `sales` ( `Date_of_sale`, `Cash_transactions_idCash_transactions`, `Employees_idEmployees`) VALUES ( @Date, @IDT, @IDS);", conn);
            //    MySqlCommand command2 = new MySqlCommand("SELECT idEmployees FROM employee where Full_Name = @IDS;", conn);

            //    command.Parameters.AddWithValue("Date", dateTimePicker1.Text);
            //    command.Parameters.AddWithValue("IDT", comboBox1.Text);
            //    command2.Parameters.AddWithValue("IDS", comboBox2.Text);
            //    string IDS = comboBox2.Text;
            //    MySqlDataReader sqlReader2 = null;
            //    await command2.ExecuteNonQueryAsync();
            //    sqlReader2 = command2.ExecuteReader();
            //    while (sqlReader2.Read())
            //    {
            //        ListViewItem item = new ListViewItem(new string[] {
            //        Convert.ToString(sqlReader2[0]),
            //             });
            //        IDS = item.Text;
            //    }
            //    await conn.CloseAsync();
            //    command.Parameters.AddWithValue("IDS", IDS);
            //    await conn.OpenAsync();
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
            f.table = 6;
            await conn.CloseAsync();
            await conn.OpenAsync();
            f.listView1.Clear();
            f.listView1.GridLines = true;
            f.listView1.FullRowSelect = true;
            f.listView1.View = View.Details;
            f.listView1.Columns.Add("Код продажи");
            f.listView1.Columns.Add("Дата продажи");
            f.listView1.Columns.Add("Код транзакции");
            f.listView1.Columns.Add("Имя сотрудника");
            f.listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            f.listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            MySqlDataReader sqlReader = null;
            MySqlCommand command = new MySqlCommand(@"SELECT idSales AS `Код продажи`, 
                                                        Date_of_sale AS `Дата продажи`,
                                                        Cash_transactions_idCash_transactions AS `Код транзакции`,
                                                        Full_Name AS `Имя сотрудника`
                                                        FROM sales,employee WHERE Employees_idEmployees = idEmployees", conn);
            try
            {
                sqlReader = command.ExecuteReader();

                while (await sqlReader.ReadAsync())
                {
                    ListViewItem item = new ListViewItem(new string[] {
                    Convert.ToString(sqlReader["Код продажи"]),
                    Convert.ToString(sqlReader["Дата продажи"]),
                    Convert.ToString(sqlReader["Код транзакции"]),
                    Convert.ToString(sqlReader["Имя сотрудника"]),

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

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Sales_Load(object sender, EventArgs e)
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

        private async void button3_Click(object sender, EventArgs e)
        {
            await conn.CloseAsync();
            await conn.OpenAsync();
            string Name = comboBox3.Text;
            string Quantity = Convert.ToString(numericUpDown1.Value);
            string SUM = null;
            string prise = null;
            int num;
            MySqlCommand command = new MySqlCommand("SELECT Selling_price FROM goods where Product_Name = @Name;", conn);
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
            listView1.Items.Add(new ListViewItem(new[] { Name , Quantity, SUM}));

            //DateTime date = new DateTime();
            //string Date = date.ToString("yyyy-MM-dd hh:mm:ss");
            //MySqlCommand command1 = new MySqlCommand("INSERT INTO `cash_transactions` (`Appointment`, `Sum`, `Date_Time`) VALUES ( @APP, @Sum, @Date);", conn);
            //command1.Parameters.AddWithValue("Date", Date);
            //command1.Parameters.AddWithValue("Sum", textBox2.Text);
            //command1.Parameters.AddWithValue("APP", comboBox1.Text);
            //try
            //{
            //    await command1.ExecuteNonQueryAsync();
            //    MessageBox.Show("Добавление прошло успешно", "Добавление прошло успешно", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            
        }
    }
}

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
    public partial class PurchasesU : Form
    {
        private int id;
        private MySqlConnection conn = null;
        private int Trans;
        public PurchasesU(int id)
        {
            this.id = id;
            InitializeComponent();
            const string Connect = "Server =  127.0.0.1; Database = mydb; port= 3306; User Id = root; password= 123123";
            conn = new MySqlConnection(Connect);
            conn.Open();
            MySqlDataAdapter IN = new MySqlDataAdapter("SELECT * FROM cash_transactions;", conn);
            DataTable cash = new DataTable();
            IN.Fill(cash);
            comboBox1.DataSource = cash;
            comboBox1.ValueMember = "idCash_transactions";
            comboBox1.DisplayMember = "name";
            conn.CloseAsync();
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

        private async void PurchasesU_Load(object sender, EventArgs e)
        {
            conn.Close();
            conn.Open();
            MySqlCommand command = new MySqlCommand(@"SELECT idPurchases AS `Код закупки`, 
                                                            Purchase_date AS `Дата закупки`,
                                                            Completion_status AS `Статус`,
                                                            Cash_transactions_idCash_transactions AS `Транзакция`
                                                            FROM purchases WHERE idPurchases =@id ", conn);
            command.Parameters.AddWithValue("id", id);

            MySqlDataReader sqlReader = null;
            try
            {
                sqlReader = command.ExecuteReader();
                while (await sqlReader.ReadAsync())
                {

                    dateTimePicker1.Text = Convert.ToString(sqlReader["Дата закупки"]);
                    checkBox1.Checked = Convert.ToBoolean(sqlReader["Статус"]);
                    comboBox1.SelectedIndex = Convert.ToInt32(sqlReader["Транзакция"]) - 1;
                    Trans = Convert.ToInt32(sqlReader["Транзакция"]) - 1;


                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message.ToString(), exp.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();


        }

        private async  void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            MySqlCommand PurchasesU = new MySqlCommand(@"UPDATE purchases SET Purchase_date = @PD, Completion_status = @CS, Cash_transactions_idCash_transactions = @CT WHERE (idPurchases = @id);", conn);
            PurchasesU.Parameters.AddWithValue("id", id);
            PurchasesU.Parameters.AddWithValue("PD", dateTimePicker1.Text);
            PurchasesU.Parameters.AddWithValue("CS", checkBox1.Checked);
            PurchasesU.Parameters.AddWithValue("CT", comboBox1.Text);
            await PurchasesU.ExecuteNonQueryAsync();
            MessageBox.Show("Изменение прошло успешно", "Изменение прошло успешно", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            conn.Close();
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
    }
}

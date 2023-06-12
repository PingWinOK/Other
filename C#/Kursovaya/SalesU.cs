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
    public partial class SalesU : Form
    {
        private MySqlConnection conn = null;
        private int id;
        private int Trans;
        private int Sotr;
        public SalesU(int id)
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
            MySqlDataAdapter EM = new MySqlDataAdapter("SELECT * FROM employee;", conn);
            DataTable emp = new DataTable();
            EM.Fill(emp);
            comboBox2.DataSource = emp;
            comboBox2.ValueMember = "Full_Name";
            comboBox2.DisplayMember = "name";
            conn.CloseAsync();
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

        private async void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            MySqlCommand SalesU = new MySqlCommand(@"UPDATE sales SET Date_of_sale = @DS, Cash_transactions_idCash_transactions = @TR, Employees_idEmployees = @EMP WHERE (idSales = @id);", conn);
            MySqlCommand command = new MySqlCommand("SELECT idEmployees FROM employee where Full_Name = @PRO;", conn);
            SalesU.Parameters.AddWithValue("id", id);
            SalesU.Parameters.AddWithValue("TR", comboBox1.Text);
            SalesU.Parameters.AddWithValue("DS", dateTimePicker1.Text);
            command.Parameters.AddWithValue("PRO", comboBox2.Text);
            string EMP = comboBox2.Text;
            MySqlDataReader sqlReader = null;
            await command.ExecuteNonQueryAsync();
            sqlReader = command.ExecuteReader();
            while (sqlReader.Read())
            {
                ListViewItem item = new ListViewItem(new string[] {
                    Convert.ToString(sqlReader[0]),
                         });
                EMP = item.Text;
            }
            await conn.CloseAsync();
            SalesU.Parameters.AddWithValue("EMP", EMP);
            conn.Open();
            await SalesU.ExecuteNonQueryAsync();
            MessageBox.Show("Изменение прошло успешно", "Изменение прошло успешно", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            conn.Close();
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
            MySqlDataReader sqlReader1 = null;
            MySqlCommand command1 = new MySqlCommand(@"SELECT idSales AS `Код продажи`, 
                                                        Date_of_sale AS `Дата продажи`,
                                                        Cash_transactions_idCash_transactions AS `Код транзакции`,
                                                        Full_Name AS `Имя сотрудника`
                                                        FROM sales,employee WHERE Employees_idEmployees = idEmployees", conn);
            try
            {
                sqlReader1 = command1.ExecuteReader();

                while (await sqlReader1.ReadAsync())
                {
                    ListViewItem item = new ListViewItem(new string[] {
                    Convert.ToString(sqlReader1["Код продажи"]),
                    Convert.ToString(sqlReader1["Дата продажи"]),
                    Convert.ToString(sqlReader1["Код транзакции"]),
                    Convert.ToString(sqlReader1["Имя сотрудника"]),

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
                if (sqlReader1 != null && !sqlReader1.IsClosed)
                    sqlReader1.Close();
            }
        }

        private async void SalesU_Load(object sender, EventArgs e)
        {
            conn.Close();
            conn.Open();
            MySqlCommand command = new MySqlCommand(@"SELECT Date_of_sale AS `Дата продажи`, 
                                                        Cash_transactions_idCash_transactions AS `Код транзакции`, 
                                                        Employees_idEmployees AS `Имя сотрудника`
                                                        FROM sales WHERE idSales = @id;", conn);
            command.Parameters.AddWithValue("id", id);

            MySqlDataReader sqlReader = null;
            try
            {
                sqlReader = command.ExecuteReader();
                while (await sqlReader.ReadAsync())
                {

                    dateTimePicker1.Text = Convert.ToString(sqlReader["Дата продажи"]);
                    comboBox1.SelectedIndex = Convert.ToInt32(sqlReader["Код транзакции"]) - 1;
                    comboBox2.SelectedIndex = Convert.ToInt32(sqlReader["Имя сотрудника"]) - 1;
                    Trans = Convert.ToInt32(sqlReader["Код транзакции"]) - 1;
                    Sotr = Convert.ToInt32(sqlReader["Имя сотрудника"]) - 1;


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

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
    public partial class Employee : Form
    {
        private MySqlConnection conn = null;
        public Employee()
        {
            InitializeComponent();
            const string Connect = "Server =  127.0.0.1; Database = mydb; port= 3306; User Id = root; password= 123123";
            conn = new MySqlConnection(Connect);
            conn.CloseAsync();
            conn.OpenAsync();
            MySqlDataAdapter EM = new MySqlDataAdapter("SELECT * FROM post;", conn);
            DataTable emp = new DataTable();
            EM.Fill(emp);
            comboBox1.DataSource = emp;
            comboBox1.ValueMember = "Name_post";
            comboBox1.DisplayMember = "name";
            conn.CloseAsync();
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
                MySqlCommand command = new MySqlCommand("INSERT INTO `employee` (`Passport_number`, `Phone_number`, `Address`, `Full_Name`, `Post_idPost`, `SNILS`) VALUES (@PN, @PF, @AD, @Name, @Post, @SNILS);", conn);
                MySqlCommand command1 = new MySqlCommand("SELECT idPost FROM post where Name_post = @Post;", conn);
                command.Parameters.AddWithValue("PN", textBox3.Text);
                command.Parameters.AddWithValue("PF", textBox4.Text);
                command.Parameters.AddWithValue("AD", textBox5.Text);
                command.Parameters.AddWithValue("Name", textBox2.Text);
                command1.Parameters.AddWithValue("Post", comboBox1.Text);
                command.Parameters.AddWithValue("SNILS", textBox6.Text);
                string Post = comboBox1.Text;
                MySqlDataReader sqlReader1 = null;
                await command1.ExecuteNonQueryAsync();
                sqlReader1 = command1.ExecuteReader();
                while (sqlReader1.Read())
                {
                    ListViewItem item = new ListViewItem(new string[] {
                    Convert.ToString(sqlReader1[0]),
                         });
                    Post = item.Text;
                }
                await conn.CloseAsync();
                command.Parameters.AddWithValue("Post", Post);
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
            this.Hide();
            Baza F = new Baza();
            F.Show();
            F.table = 4;
            await conn.CloseAsync();
            await conn.OpenAsync();
            F.listView1.Clear();
            F.listView1.GridLines = true;
            F.listView1.FullRowSelect = true;
            F.listView1.View = View.Details;
            F.listView1.Columns.Add("Код сотрудника");
            F.listView1.Columns.Add("Код паспорта");
            F.listView1.Columns.Add("Номер телефона");
            F.listView1.Columns.Add("Адрес");
            F.listView1.Columns.Add("Имя сотрудника");
            F.listView1.Columns.Add("Название должности");
            F.listView1.Columns.Add("СНИЛС");
            F.listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            F.listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            MySqlDataReader sqlReader = null;
            MySqlCommand command = new MySqlCommand(@"SELECT idEmployees AS `Код сотрудника`, 
                                                        Passport_number AS `Код паспорта`,
                                                        Phone_number AS `Номер телефона`,
                                                        Address AS `Адрес`,
                                                        Full_Name AS `Имя сотрудника`,
                                                        Name_post AS `Название должности`,
                                                        SNILS AS `СНИЛС`
                                                        FROM employee, post WHERE Post_idPost = idPost; ", conn);
            try
            {
                sqlReader = command.ExecuteReader();

                while (await sqlReader.ReadAsync())
                {
                    ListViewItem item = new ListViewItem(new string[] {
                    Convert.ToString(sqlReader["Код сотрудника"]),
                    Convert.ToString(sqlReader["Код паспорта"]),
                    Convert.ToString(sqlReader["Номер телефона"]),
                    Convert.ToString(sqlReader["Адрес"]),
                    Convert.ToString(sqlReader["Имя сотрудника"]),
                    Convert.ToString(sqlReader["Название должности"]),
                    Convert.ToString(sqlReader["СНИЛС"]),
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

        private void Employee_Load(object sender, EventArgs e)
        {

        }
    }
}

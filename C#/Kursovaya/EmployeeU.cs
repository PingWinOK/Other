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
    public partial class EmployeeU : Form
    {
        private int id;
        private MySqlConnection conn = null;
        private int Post;
        public EmployeeU(int id)
        {
            this.id = id;
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

        private async void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            MySqlCommand UEmployees = new MySqlCommand(@"UPDATE employee SET Passport_number = @PN, Phone_number = @PNOMBER, Address = @AD, Full_Name = @FN, Post_idPost = @NP, SNILS = @SNILS WHERE (idEmployees = @id);", conn);
            MySqlCommand command = new MySqlCommand("SELECT idPost FROM post where Name_post = @NP;", conn);
            UEmployees.Parameters.AddWithValue("id", id);
            UEmployees.Parameters.AddWithValue("PN", textBox3.Text);
            UEmployees.Parameters.AddWithValue("PNOMBER", textBox4.Text);
            UEmployees.Parameters.AddWithValue("AD", textBox5.Text);
            UEmployees.Parameters.AddWithValue("FN", textBox2.Text);
            UEmployees.Parameters.AddWithValue("SNILS", textBox6.Text);
            command.Parameters.AddWithValue("NP", comboBox1.Text);
            string NP = comboBox1.Text;
            MySqlDataReader sqlReader = null;
            await command.ExecuteNonQueryAsync();
            sqlReader = command.ExecuteReader();
            while (sqlReader.Read())
            {
                ListViewItem item = new ListViewItem(new string[] {
                    Convert.ToString(sqlReader[0]),
                         });
                NP = item.Text;
            }
            await conn.CloseAsync();
            UEmployees.Parameters.AddWithValue("NP", NP);
            conn.Open();
            await UEmployees.ExecuteNonQueryAsync();
            MessageBox.Show("Изменение прошло успешно", "Изменение прошло успешно", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            conn.Close();
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
            MySqlDataReader sqlReader1 = null;
            MySqlCommand command1 = new MySqlCommand(@"SELECT idEmployees AS `Код сотрудника`, 
                                                        Passport_number AS `Код паспорта`,
                                                        Phone_number AS `Номер телефона`,
                                                        Address AS `Адрес`,
                                                        Full_Name AS `Имя сотрудника`,
                                                        Name_post AS `Название должности`,
                                                        SNILS AS `СНИЛС`
                                                        FROM employee, post WHERE Post_idPost = idPost; ", conn);
            try
            {
                sqlReader1 = command1.ExecuteReader();

                while (await sqlReader1.ReadAsync())
                {
                    ListViewItem item = new ListViewItem(new string[] {
                    Convert.ToString(sqlReader1["Код сотрудника"]),
                    Convert.ToString(sqlReader1["Код паспорта"]),
                    Convert.ToString(sqlReader1["Номер телефона"]),
                    Convert.ToString(sqlReader1["Адрес"]),
                    Convert.ToString(sqlReader1["Имя сотрудника"]),
                    Convert.ToString(sqlReader1["Название должности"]),
                    Convert.ToString(sqlReader1["СНИЛС"]),
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

        private async void EmployeeU_Load(object sender, EventArgs e)
        {
            conn.Close();
            conn.Open();
            MySqlCommand command = new MySqlCommand(@"SELECT idEmployees AS `Код сотрудника`, 
                                                        Passport_number AS `Код паспорта`,
                                                        Phone_number AS `Номер телефона`,
                                                        Address AS `Адрес`,
                                                        Full_Name AS `Имя сотрудника`,
                                                        Post_idPost AS `Название должности`,
                                                        SNILS AS `СНИЛС`
                                                        FROM employee WHERE idEmployees = @id;", conn);
            command.Parameters.AddWithValue("id", id);

            MySqlDataReader sqlReader = null;
            try
            {
                sqlReader = command.ExecuteReader();
                while (await sqlReader.ReadAsync())
                {

                    textBox3.Text = Convert.ToString(sqlReader["Код паспорта"]);
                    textBox4.Text = Convert.ToString(sqlReader["Номер телефона"]);
                    textBox5.Text = Convert.ToString(sqlReader["Адрес"]);
                    textBox2.Text = Convert.ToString(sqlReader["Имя сотрудника"]);
                    textBox6.Text = Convert.ToString(sqlReader["СНИЛС"]);
                    comboBox1.SelectedIndex = Convert.ToInt32(sqlReader["Название должности"]) - 1;
                    Post = Convert.ToInt32(sqlReader["Название должности"]) - 1;


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


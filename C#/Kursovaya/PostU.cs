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
    public partial class PostU : Form
    {
        private int id;
        private MySqlConnection conn = null;
        public PostU(int id)
        {
            this.id = id;
            InitializeComponent();
            const string Connect = "Server =  127.0.0.1; Database = mydb; port= 3306; User Id = root; password= 123123";
            conn = new MySqlConnection(Connect);
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
            f.listView1.Columns.Add("Код должности");
            f.listView1.Columns.Add("Название должности");
            f.listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            f.listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            f.table = 3;
            MySqlDataReader sqlReader = null;
            MySqlCommand command = new MySqlCommand(@"SELECT idPost AS `Код должности`, 
                                                        Name_post AS `Название должности`
                                                                FROM post;", conn);
            try
            {
                sqlReader = command.ExecuteReader();

                while (await sqlReader.ReadAsync())
                {
                    ListViewItem item = new ListViewItem(new string[] {
                    Convert.ToString(sqlReader["Код должности"]),
                    Convert.ToString(sqlReader["Название должности"]),
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

        private async void PostU_Load(object sender, EventArgs e)
        {
            conn.Close();
            conn.Open();
            MySqlCommand command = new MySqlCommand(@"SELECT idPost AS `Код должности`, 
                                                        Name_post AS `Название должности`
                                                                FROM post WHERE idPost=@id", conn);
            command.Parameters.AddWithValue("id", id);

            MySqlDataReader sqlReader = null;
            try
            {
                sqlReader = command.ExecuteReader();
                while (await sqlReader.ReadAsync())
                {

                    textBox2.Text = Convert.ToString(sqlReader["Название должности"]);


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
            conn.Open();
            MySqlCommand UGoods = new MySqlCommand(@"UPDATE post SET Name_post = @NP WHERE (idPost = @id);", conn);
           
            UGoods.Parameters.AddWithValue("NP", textBox2.Text);
            UGoods.Parameters.AddWithValue("id", id);
            await UGoods.ExecuteNonQueryAsync();
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
            f.listView1.Columns.Add("Код должности");
            f.listView1.Columns.Add("Название должности");
            f.listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            f.listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            f.table = 3;
            MySqlDataReader sqlReader = null;
            MySqlCommand command = new MySqlCommand(@"SELECT idPost AS `Код должности`, 
                                                        Name_post AS `Название должности`
                                                                FROM post;", conn);
            try
            {
                sqlReader = command.ExecuteReader();

                while (await sqlReader.ReadAsync())
                {
                    ListViewItem item = new ListViewItem(new string[] {
                    Convert.ToString(sqlReader["Код должности"]),
                    Convert.ToString(sqlReader["Название должности"]),
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

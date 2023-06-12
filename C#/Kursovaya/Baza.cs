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
    public partial class Baza : Form
    {
        MySqlDataAdapter mda;
        DataSet ds;
        private MySqlConnection conn = null;
        public int table = 0;
        public Baza()
        {
            InitializeComponent();
            const string Connect = "Server =  127.0.0.1; Database = mydb; port= 3306; User Id = root; password= 123123";
            conn = new MySqlConnection(Connect);

        }

        private async void Baza_Load(object sender, EventArgs e)
        {




        }

        private async void button4_Click(object sender, EventArgs e)
        {
            button14.Visible = false;

            await conn.CloseAsync();
            await conn.OpenAsync();
            listView1.Clear();
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.View = View.Details;
            listView1.Columns.Add("Код должности");
            listView1.Columns.Add("Название должности");
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            table = 3;
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
                    listView1.Items.Add(item);
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
            button14.Visible = false;

            await conn.CloseAsync();
            await conn.OpenAsync();
            listView1.Clear();
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.View = View.Details;
            listView1.Columns.Add("Код товара");
            listView1.Columns.Add("Количество");
            listView1.Columns.Add("Название товара");
            listView1.Columns.Add("Цена продажи");
            listView1.Columns.Add("Ед.измерения");
            listView1.Columns.Add("Цена покупки");
            listView1.Columns.Add("Поставщик");
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            table = 1;
            MySqlDataReader sqlReader = null;
            MySqlCommand command = new MySqlCommand(@"SELECT idGoods AS `Код товара`, 
                                                        Quantity AS `Количество`, 
                                                        Product_Name AS `Название товара`, 
                                                        Selling_price AS `Цена продажи`, 
                                                        Units AS `Ед.измерения`, 
                                                        Purchase_price AS `Цена покупки`, 
                                                        Provider_Name AS `Поставщик`
                                                        FROM goods, provider WHERE Provider_idProvider = idProvider; ", conn);
            try
            {
                sqlReader = command.ExecuteReader();

                while (await sqlReader.ReadAsync())
                {
                    ListViewItem item = new ListViewItem(new string[] {
                    Convert.ToString(sqlReader["Код товара"]),
                    Convert.ToString(sqlReader["Количество"]),
                    Convert.ToString(sqlReader["Название товара"]),
                    Convert.ToString(sqlReader["Цена продажи"]),
                    Convert.ToString(sqlReader["Ед.измерения"]),
                    Convert.ToString(sqlReader["Цена покупки"]),
                    Convert.ToString(sqlReader["Поставщик"]),
                         });
                    listView1.Items.Add(item);
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

        private async void button5_Click(object sender, EventArgs e)
        {
            button14.Visible = false;

            await conn.CloseAsync();
            await conn.OpenAsync();
            listView1.Clear();
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.View = View.Details;
            listView1.Columns.Add("Код сотрудника");
            listView1.Columns.Add("Код паспорта");
            listView1.Columns.Add("Номер телефона");
            listView1.Columns.Add("Адрес");
            listView1.Columns.Add("Имя сотрудника");
            listView1.Columns.Add("Название должности");
            listView1.Columns.Add("СНИЛС");

            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            table = 4;
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
                    listView1.Items.Add(item);
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

        private async void button6_Click(object sender, EventArgs e)
        {
            button14.Visible = false;

            await conn.CloseAsync();
            await conn.OpenAsync();
            listView1.Clear();
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.View = View.Details;
            listView1.Columns.Add("Код поставщика");
            listView1.Columns.Add("Имя поставщика");
            listView1.Columns.Add("Адрес поставщика");
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            table = 5;
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
                    listView1.Items.Add(item);
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

        private async void button2_Click(object sender, EventArgs e)
        {
            button14.Visible = true;
            await conn.CloseAsync();
            await conn.OpenAsync();
            listView1.Clear();
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.View = View.Details;
            listView1.Columns.Add("Код закупки");
            listView1.Columns.Add("Дата закупки");
            listView1.Columns.Add("Статус");
            listView1.Columns.Add("Сумма закупки");
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            table = 2;
            MySqlDataReader sqlReader = null;
            MySqlCommand command = new MySqlCommand(@"SELECT idPurchases AS `Код закупки`, 
                                                            Purchase_date AS `Дата закупки`,
                                                            Completion_status AS `Статус`,
                                                            Sum AS `Сумма закупки`
                                                            FROM purchases ,cash_transactions WHERE (idCash_transactions = idPurchases)", conn);
            try
            {
                sqlReader = command.ExecuteReader();

                while (await sqlReader.ReadAsync())
                {
                    ListViewItem item = new ListViewItem(new string[] {
                    Convert.ToString(sqlReader["Код закупки"]),
                    Convert.ToString(sqlReader["Дата закупки"]),
                    Convert.ToString(sqlReader["Статус"]),
                    Convert.ToString(sqlReader["Сумма закупки"]),
                         });
                    listView1.Items.Add(item);
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

        private async void button8_Click(object sender, EventArgs e)
        {
            button14.Visible = false;
            await conn.CloseAsync();
            await conn.OpenAsync();
            listView1.Clear();
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.View = View.Details;
            listView1.Columns.Add("Код транзакции");
            listView1.Columns.Add("Назначение");
            listView1.Columns.Add("Сумма");
            listView1.Columns.Add("Дата/Время");
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            table = 7;
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
                    listView1.Items.Add(item);
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

        private async void button7_Click(object sender, EventArgs e)
        {
            button14.Visible = true;
            await conn.CloseAsync();

            await conn.OpenAsync();
            listView1.Clear();
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.View = View.Details;
            listView1.Columns.Add("Код продажи");
            listView1.Columns.Add("Дата продажи");
            listView1.Columns.Add("Сумма продажи");
            listView1.Columns.Add("Имя сотрудника");
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            table = 6;
            MySqlDataReader sqlReader = null;
            MySqlCommand command = new MySqlCommand(@"SELECT idSales AS `Код продажи`,
                                                        Date_of_sale AS `Дата продажи`,
                                                        Sum AS `Сумма продажи`,
                                                        Full_Name AS `Имя сотрудника`
                                                        FROM sales,employee,cash_transactions WHERE (Employees_idEmployees = idEmployees) and (idCash_transactions = idSales)", conn);
            try
            {
                sqlReader = command.ExecuteReader();

                while (await sqlReader.ReadAsync())
                {
                    ListViewItem item = new ListViewItem(new string[] {
                    Convert.ToString(sqlReader["Код продажи"]),
                    Convert.ToString(sqlReader["Дата продажи"]),
                    Convert.ToString(sqlReader["Сумма продажи"]),
                    Convert.ToString(sqlReader["Имя сотрудника"]),

                         });
                    listView1.Items.Add(item);
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

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

            switch (table)
            {
                case 0:
                    MessageBox.Show("Выберите таблицу!");
                    break;
                case 2:
                    Purchases Table1 = new Purchases();
                    Table1.ShowDialog();
                    this.Hide();
                    break;
                case 1:
                    Goods Table2 = new Goods();
                    Table2.ShowDialog();
                    this.Hide();
                    break;
                case 3:
                    Post Table3 = new Post();
                    Table3.ShowDialog();
                    this.Hide();
                    break;
                case 4:
                    Employee Table4 = new Employee();
                    Table4.ShowDialog();
                    this.Hide();
                    break;
                case 5:
                    Provider Table5 = new Provider();
                    Table5.ShowDialog();
                    this.Hide();
                    break;
                case 6:
                    Sales Table6 = new Sales();
                    Table6.ShowDialog();
                    this.Hide();
                    break;
                case 7:
                    Cash_transactions Table7 = new Cash_transactions();
                    Table7.ShowDialog();
                    this.Hide();
                    break;

            }


        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            login f = new login();
            f.Show();
            Close();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private async void button12_Click(object sender, EventArgs e)
        {
            await conn.CloseAsync();
            await conn.OpenAsync();
            switch (table)
            {
                case 0:
                    MessageBox.Show("Выберите таблицу!");
                    break;
                case 2:
                    if (listView1.SelectedItems.Count > 0)
                    {
                        DialogResult res = MessageBox.Show("Вы действительно хотите удалить данный товар", "Удаление товара", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                        switch (res)
                        {
                            case DialogResult.OK:
                                MySqlCommand dellSotrComand = new MySqlCommand("DELETE FROM goods WHERE idGoods = @id;", conn);
                                dellSotrComand.Parameters.AddWithValue("id", Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text));
                                try
                                {
                                    await dellSotrComand.ExecuteNonQueryAsync();
                                    MessageBox.Show("Запись удалена", "Подтверждение удаления", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    await conn.CloseAsync();
                                }
                                catch (Exception exp)
                                {
                                    MessageBox.Show(exp.Message.ToString(), exp.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                listView1.Items.Clear();
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Выделите строку для удаления", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case 1:
                    if (listView1.SelectedItems.Count > 0)
                    {
                        DialogResult res = MessageBox.Show("Вы действительно хотите удалить данную закупку", "Удаление закупки", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                        switch (res)
                        {
                            case DialogResult.OK:
                                MySqlCommand dellSotrComand = new MySqlCommand("DELETE FROM purchases WHERE idPurchases = @id;", conn);
                                dellSotrComand.Parameters.AddWithValue("id", Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text));
                                try
                                {
                                    await dellSotrComand.ExecuteNonQueryAsync();
                                    MessageBox.Show("Запись удалена", "Подтверждение удаления", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    await conn.CloseAsync();
                                }
                                catch (Exception exp)
                                {
                                    MessageBox.Show(exp.Message.ToString(), exp.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                listView1.Items.Clear();
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Выделите строку для удаления", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case 3:
                    if (listView1.SelectedItems.Count > 0)
                    {
                        DialogResult res = MessageBox.Show("Вы действительно хотите удалить данную должность", "Удаление должности", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                        switch (res)
                        {
                            case DialogResult.OK:
                                MySqlCommand dellSotrComand = new MySqlCommand("DELETE FROM post WHERE (idPost = @id);", conn);
                                dellSotrComand.Parameters.AddWithValue("id", Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text));
                                try
                                {
                                    await dellSotrComand.ExecuteNonQueryAsync();
                                    MessageBox.Show("Запись удалена", "Подтверждение удаления", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                catch (Exception exp)
                                {
                                    MessageBox.Show(exp.Message.ToString(), exp.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                listView1.Items.Clear();
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Выделите строку для удаления", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case 4:
                    if (listView1.SelectedItems.Count > 0)
                    {
                        DialogResult res = MessageBox.Show("Вы действительно хотите удалить данного сотрудника", "Удаление сотрудника", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                        switch (res)
                        {
                            case DialogResult.OK:
                                MySqlCommand dellSotrComand = new MySqlCommand("DELETE FROM employee WHERE (idEmployees = @id);", conn);
                                dellSotrComand.Parameters.AddWithValue("id", Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text));
                                try
                                {
                                    await dellSotrComand.ExecuteNonQueryAsync();
                                    MessageBox.Show("Запись удалена", "Подтверждение удаления", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                catch (Exception exp)
                                {
                                    MessageBox.Show(exp.Message.ToString(), exp.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                listView1.Items.Clear();
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Выделите строку для удаления", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    break;
                case 5:
                    if (listView1.SelectedItems.Count > 0)
                    {
                        DialogResult res = MessageBox.Show("Вы действительно хотите удалить поставщика", "Удаление поставщика", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                        switch (res)
                        {
                            case DialogResult.OK:
                                MySqlCommand dellSotrComand = new MySqlCommand("DELETE FROM provider WHERE idProvider = @id;", conn);
                                dellSotrComand.Parameters.AddWithValue("id", Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text));
                                try
                                {
                                    await dellSotrComand.ExecuteNonQueryAsync();
                                    MessageBox.Show("Запись удалена", "Подтверждение удаления", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    await conn.CloseAsync();
                                }
                                catch (Exception exp)
                                {
                                    MessageBox.Show(exp.Message.ToString(), exp.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                listView1.Items.Clear();
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Выделите строку для удаления", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case 6:
                    if (listView1.SelectedItems.Count > 0)
                    {
                        DialogResult res = MessageBox.Show("Вы действительно хотите данную продажу", "Удаление продажи", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                        switch (res)
                        {
                            case DialogResult.OK:
                                MySqlCommand dellSotrComand = new MySqlCommand("DELETE FROM sales WHERE idSales = @id;", conn);
                                dellSotrComand.Parameters.AddWithValue("id", Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text));
                                try
                                {
                                    await dellSotrComand.ExecuteNonQueryAsync();
                                    MessageBox.Show("Запись удалена", "Подтверждение удаления", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    await conn.CloseAsync();
                                }
                                catch (Exception exp)
                                {
                                    MessageBox.Show(exp.Message.ToString(), exp.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                listView1.Items.Clear();
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Выделите строку для удаления", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case 7:
                    if (listView1.SelectedItems.Count > 0)
                    {
                        DialogResult res = MessageBox.Show("Вы действительно хотите данную транзакцию", "Удаление транзакции", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                        switch (res)
                        {
                            case DialogResult.OK:
                                MySqlCommand dellSotrComand = new MySqlCommand("DELETE FROM cash_transactions WHERE idCash_transactions = @id;", conn);
                                dellSotrComand.Parameters.AddWithValue("id", Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text));
                                try
                                {
                                    await dellSotrComand.ExecuteNonQueryAsync();
                                    MessageBox.Show("Запись удалена", "Подтверждение удаления", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    await conn.CloseAsync();
                                }
                                catch (Exception exp)
                                {
                                    MessageBox.Show(exp.Message.ToString(), exp.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                listView1.Items.Clear();
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Выделите строку для удаления", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

            }
        }

        private async void button13_Click(object sender, EventArgs e)
        {
            switch (table)
            {
                case 0:
                    MessageBox.Show("Выберите таблицу!");
                    break;
                case 1:
                    if (listView1.SelectedItems.Count > 0)
                    {
                        GoodsU GoodsU = new GoodsU(Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text));
                        GoodsU.ShowDialog();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Выделите строку для изменения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case 2:
                    if (listView1.SelectedItems.Count > 0)
                    {
                        PurchasesU PurchasesU = new PurchasesU(Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text));
                        PurchasesU.ShowDialog();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Выделите строку для изменения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case 3:
                    if (listView1.SelectedItems.Count > 0)
                    {
                        PostU PostU = new PostU(Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text));
                        PostU.ShowDialog();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Выделите строку для изменения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case 4:
                    if (listView1.SelectedItems.Count > 0)
                    {
                        EmployeeU EmployeeU = new EmployeeU(Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text));
                        EmployeeU.ShowDialog();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Выделите строку для изменения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    break;
                case 5:
                    if (listView1.SelectedItems.Count > 0)
                    {
                        ProviderU ProviderU = new ProviderU(Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text));
                        ProviderU.ShowDialog();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Выделите строку для изменения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case 6:
                    if (listView1.SelectedItems.Count > 0)
                    {
                        SalesU SalesU = new SalesU(Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text));
                        SalesU.ShowDialog();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Выделите строку для изменения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case 7:
                    if (listView1.SelectedItems.Count > 0)
                    {
                        Cash_transactionsU Cash_transactionsU = new Cash_transactionsU(Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text));
                        Cash_transactionsU.ShowDialog();
                        this.Hide();
                        break;
                        
                    }
                    else
                    {
                        MessageBox.Show("Выделите строку для изменения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

            }
        }

        private async void button14_Click_1(object sender, EventArgs e)
        {
            button11.Visible = false;
            button12.Visible = false;
            button13.Visible = false;
            button14.Visible = false;
            button15.Visible = true;
            int id = Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text);
            await conn.CloseAsync();
            await conn.OpenAsync();
            listView1.Clear();
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.View = View.Details;
            listView1.Columns.Add("Название");
            listView1.Columns.Add("Количество");
            listView1.Columns.Add("Сумма");
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            MySqlDataReader sqlReader = null;
            MySqlCommand command = null;
            if (table == 6)
            {
                command = new MySqlCommand(@"SELECT product_sale.Quantity AS `Количество`,
                                                        Product_Name AS `Название`,
                                                        Selling_price AS 'Цена'
                                                        FROM product_sale, goods  WHERE (Sales_idSales = @ID) and (Goods_idGoods = idGoods); ", conn);
                command.Parameters.AddWithValue("id", id);
            }
            if (table == 2)
            {
                command = new MySqlCommand(@"SELECT purchase_item.Quantity AS `Количество`,
                                                        Product_Name AS `Название`,
                                                        Purchase_price AS 'Цена'
                                                        FROM purchase_item, goods  WHERE (Purchases_idPurchases = @ID) and (Goods_idGoods = idGoods); ", conn);
                command.Parameters.AddWithValue("id", id);
            }
            try
            {
                sqlReader = command.ExecuteReader();
                IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "," };
                while (await sqlReader.ReadAsync())
                {
                    string P = Convert.ToString(sqlReader["Количество"]);
                    string Q = Convert.ToString(sqlReader["Цена"]);
                    double R = double.Parse(P, formatter);
                    string SUM = Convert.ToString(R * Convert.ToDouble(Q));
                    ListViewItem item = new ListViewItem(new string[] {
                    Convert.ToString(sqlReader["Название"]),
                    Convert.ToString(sqlReader["Количество"]),
                    Convert.ToString(SUM),

                         });
                    listView1.Items.Add(item);
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

        private void button15_Click(object sender, EventArgs e)
        {
            if (table == 6)
            {
                button7.PerformClick();
            }
            else
            {
                button2.PerformClick();
            }
            button11.Visible = true;
            button12.Visible = true;
            button13.Visible = true;
            button14.Visible = true;
            button15.Visible = false;
        }
    }

}

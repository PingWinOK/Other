using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Курсовой_проект2019
{
    public partial class Поставщики : Form
    {
        public static string ConBD = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=KT.mdb";
        private OleDbConnection Connect;
        public Поставщики()
        {
            InitializeComponent();

            Connect = new OleDbConnection(ConBD);
            Обновление(dataGridView1);


        }
        public void Обновление(DataGridView t)
        {
            t.Rows.Clear();
            Connect.Open();
            string query = "SELECT * FROM Postavchik ORDER BY [Порядковый номер]";
            OleDbCommand comand = new OleDbCommand(query, Connect);
            DataGridViewComboBoxColumn col = dataGridView1.Columns[1] as DataGridViewComboBoxColumn;
            OleDbDataReader Otvet = comand.ExecuteReader();
            List<string[]> OList = new List<string[]>();
            foreach (var item in Otvet)
            {
                OList.Add(new string[5]);

                OList[OList.Count - 1][0] = Otvet[0].ToString();
                OList[OList.Count - 1][1] = Otvet[1].ToString();
                OList[OList.Count - 1][2] = Otvet[2].ToString();
                OList[OList.Count - 1][3] = Otvet[3].ToString();
                OList[OList.Count - 1][4] = Otvet[4].ToString();
            }
            Connect.Close();
            foreach (string[] s in OList)
                t.Rows.Add(s);
            if (conteyner.Поставщики_2.Count > 1)
            {
                col.Items.Clear();
                foreach (string s in conteyner.Поставщики_2)
                    col.Items.Add(s);
            }
        }


        private void button7_Click(object sender, EventArgs e)
        {
            Connect.Close();
            Connect.Open();
            string fard;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                fard = "UPDATE Postavchik SET Поставщик ='" + dataGridView1.Rows[i].Cells[1].Value + "',[Вид товаров] ='" + dataGridView1.Rows[i].Cells[2].Value + "',[Главный офис] ='" + dataGridView1.Rows[i].Cells[3].Value + "',[Количество товара на складе]  ='" + dataGridView1.Rows[i].Cells[4].Value + "' WHERE [Порядковый номер] =" + dataGridView1.Rows[i].Cells[0].Value;
                OleDbCommand comand = new OleDbCommand(fard, Connect);
                OleDbDataReader fore = comand.ExecuteReader();
            }
            Connect.Close();
        }

        private void Канцелярия_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kTDataSet.Tovari". При необходимости она может быть перемещена или удалена.
            this.tovariTableAdapter.Fill(this.kTDataSet.Tovari);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
            Connect.Close();
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Выбор_БД af = new Выбор_БД();
            af.Show();
            this.Close();

        }
        public class User
        {
            public string Name { get; set; }
            public int Id { get; set; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            conteyner.t = dataGridView1.RowCount + 1;
            ДобавленияPost ar = new ДобавленияPost();
            ar.Owner = this;
            ar.ShowDialog();
            button9_Click(sender, e);
            DataGridViewComboBoxColumn col = dataGridView1.Columns[1] as DataGridViewComboBoxColumn;
            Connect.Close();
            Connect.Open();
            string fard = "SELECT DISTINCT Поставщик FROM Postavchik";
            OleDbCommand comand = new OleDbCommand(fard, Connect);
            OleDbDataReader Otvet = comand.ExecuteReader();
            List<string> OList = new List<string>();
            foreach (var item in Otvet)
            {

                OList.Add(Otvet[0].ToString());
            }
            col.Items.Clear();
            conteyner.Поставщики_2 = OList;
            foreach (string s in OList)
                col.Items.Add(s);
            Connect.Close();

        }


        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.OK)
                {
                    Connect.Open();
                    double mas = Convert.ToDouble(dataGridView1.Rows[Convert.ToInt32(dataGridView1.SelectedCells[0].RowIndex)].Cells[0].Value);
                    string query = "DELETE FROM Postavchik WHERE [Порядковый номер] = " + mas;
                    OleDbCommand comand = new OleDbCommand(query, Connect);
                    OleDbDataReader Otvet = comand.ExecuteReader();
                    dataGridView1.Refresh();
                    Connect.Close();
                    Обновление(dataGridView1);

                }
            }
            catch
            {
                MessageBox.Show("Выберите строку для удаления");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Обновление(dataGridView1);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Обновление(dataGridView1);
            try
            {
                switch (comboBox3.Text)
                {
                    case "Найти":
                        Connect.Open();
                        dataGridView1.Rows.Clear();
                        string query = "SELECT * FROM Postavchik WHERE [" + comboBox2.Text + "] LIKE '%" + textBox1.Text + "%'";
                        OleDbCommand comand = new OleDbCommand(query, Connect);
                        OleDbDataReader Otvet = comand.ExecuteReader();

                        List<string[]> OList = new List<string[]>();
                        foreach (var item in Otvet)
                        {
                                        OList.Add(new string[5]);

                                        OList[OList.Count - 1][0] = Otvet[0].ToString();
                                        OList[OList.Count - 1][1] = Otvet[1].ToString();
                                        OList[OList.Count - 1][2] = Otvet[2].ToString();
                                        OList[OList.Count - 1][3] = Otvet[3].ToString();
                                        OList[OList.Count - 1][4] = Otvet[4].ToString();
                                    }
                                    Connect.Close();
                                    foreach (string[] s in OList)
                                        dataGridView1.Rows.Add(s);

                        break;
                    case "Максимальное число":
                        Connect.Open();
                        textBox1.Text = "";
                        dataGridView1.Rows.Clear();
                        string query1 = "SELECT * FROM Postavchik WHERE [" + comboBox2.Text + "] =(SELECT MAX([" + comboBox2.Text + "]) FROM Postavchik)";
                        OleDbCommand comand1 = new OleDbCommand(query1, Connect);
                        OleDbDataReader Otvet1 = comand1.ExecuteReader();

                        List<string[]> OList1 = new List<string[]>();
                        foreach (var item in Otvet1)
                        {
                            OList1.Add(new string[5]);

                            OList1[OList1.Count - 1][0] = Otvet1[0].ToString();
                            OList1[OList1.Count - 1][1] = Otvet1[1].ToString();
                            OList1[OList1.Count - 1][2] = Otvet1[2].ToString();
                            OList1[OList1.Count - 1][3] = Otvet1[3].ToString();
                            OList1[OList1.Count - 1][4] = Otvet1[4].ToString();
                        }
                        Connect.Close();
                        foreach (string[] s in OList1)
                            dataGridView1.Rows.Add(s);
                        break;
                    case "Минимальное число":
                        Connect.Open();
                        textBox1.Text = "";
                        dataGridView1.Rows.Clear();
                        string query2 = "SELECT * FROM Postavchik WHERE [" + comboBox2.Text + "] =(SELECT MIN([" + comboBox2.Text + "]) FROM Postavchik)";
                        OleDbCommand comand2 = new OleDbCommand(query2, Connect);
                        OleDbDataReader Otvet2 = comand2.ExecuteReader();

                        List<string[]> OList2 = new List<string[]>();
                        foreach (var item in Otvet2)
                        {
                            OList2.Add(new string[5]);

                            OList2[OList2.Count - 1][0] = Otvet2[0].ToString();
                            OList2[OList2.Count - 1][1] = Otvet2[1].ToString();
                            OList2[OList2.Count - 1][2] = Otvet2[2].ToString();
                            OList2[OList2.Count - 1][3] = Otvet2[3].ToString();
                            OList2[OList2.Count - 1][4] = Otvet2[4].ToString();

                        }
                        Connect.Close();
                        foreach (string[] s in OList2)
                            dataGridView1.Rows.Add(s);

                        break;
                }
            }
            catch
            {
                Connect.Close();
                MessageBox.Show("Проверте правильность набора символов или выбора колонок ");
                comboBox2.Refresh();
                comboBox3.Refresh();

            }
        }
        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            if (textBox1.Text == String.Empty)
            {
                textBox1.Text = "Введите значение";
            }

        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Введите значение")
            {
                textBox1.Text = "";
            }
        }
        


        private void rectangleShape1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            FAQ af = new FAQ();
            af.Owner = this;
            af.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "Help.chm", HelpNavigator.TableOfContents);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Text = "Выберите колонку";
            switch (comboBox3.Text)
            {
                case "Найти":
                    textBox1.Enabled = true;
                    string[] Найти = { "Порядковый номер", "Поставщик", "Вид товаров", "Главный офис", "Количество товара на складе"};
                    comboBox2.Items.Clear();
                    comboBox2.Items.AddRange(Найти);
                    break;
                case "Максимальное число":
                    textBox1.Enabled = false;
                    string[] Числа = { "Порядковый номер", "Количество товара на складе"};
                    comboBox2.Items.Clear();
                    comboBox2.Items.AddRange(Числа);
                    break;
                case "Минимальное число":
                    textBox1.Enabled = false;
                    string[] Числа2 = { "Порядковый номер", "Количество товара на складе" };
                    comboBox2.Items.Clear();
                    comboBox2.Items.AddRange(Числа2);
                    break;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Tutorial.SqlConn;
using MySql.Data.MySqlClient;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using Application = System.Windows.Forms.Application;
using System.IO;

namespace Курсовой_проект2019
{
    public partial class Поставщики : Form
    {

        public Поставщики()
        {
            InitializeComponent();

            Обновление(dataGridView1);



        }
        public void Обновление(DataGridView t)
        {
            MySqlConnection Connect = DBUtils.GetDBConnection();
            t.Rows.Clear();
            Connect.Open();
            string query = "SELECT * FROM Postavchik ORDER BY `№`";
            MySqlCommand command = new MySqlCommand(query, Connect);
            DataGridViewComboBoxColumn col = dataGridView1.Columns[1] as DataGridViewComboBoxColumn;
            MySqlDataReader Otvet = command.ExecuteReader();
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
            string fard;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                MySqlConnection Connect = DBUtils.GetDBConnection();
                Connect.Close();
                Connect.Open();
                fard = "UPDATE Postavchik SET Поставщик ='" + dataGridView1.Rows[i].Cells[1].Value + "',`Вид товаров` ='" + dataGridView1.Rows[i].Cells[2].Value + "',`Главный офис` ='" + dataGridView1.Rows[i].Cells[3].Value + "',`Количество товара на складе`  ='" + dataGridView1.Rows[i].Cells[4].Value + "' WHERE `№` =" + dataGridView1.Rows[i].Cells[0].Value;
                MySqlCommand command = new MySqlCommand(fard, Connect);
                MySqlDataReader Otvet = command.ExecuteReader();
                Connect.Close();

            }
        }

        private void Канцелярия_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kTDataSet.Tovari". При необходимости она может быть перемещена или удалена.
            //this.tovariTableAdapter.Fill(this.kTDataSet.Tovari);
            toolTip1.SetToolTip(button1, "Нажмите для добавления");
            toolTip1.SetToolTip(button3, "Нажмите для удаления");
            toolTip1.SetToolTip(button7, "Сохранить изменения");
            toolTip1.SetToolTip(button9, "Обновить таблицу");
            toolTip1.SetToolTip(button8, "Нажмите чтобы \nвызвать помощь по кнопкам");
            toolTip1.SetToolTip(button10, "Выполнить поиск");
            toolTip1.SetToolTip(button4, "Назад");
            toolTip1.SetToolTip(button5, "Вернуться ");

        }

        private void button5_Click(object sender, EventArgs e)
        {
            MySqlConnection Connect = DBUtils.GetDBConnection();
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
            MySqlConnection Connect = DBUtils.GetDBConnection();
            conteyner.t = dataGridView1.RowCount + 1;
            ДобавленияPost ar = new ДобавленияPost();
            ar.Owner = this;
            ar.ShowDialog();
            button9_Click(sender, e);
            DataGridViewComboBoxColumn col = dataGridView1.Columns[1] as DataGridViewComboBoxColumn;
            Connect.Close();
            Connect.Open();
            string fard = "SELECT DISTINCT Поставщик FROM Postavchik";
            MySqlCommand command = new MySqlCommand(fard, Connect);
            MySqlDataReader Otvet = command.ExecuteReader();
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
                    MySqlConnection Connect = DBUtils.GetDBConnection();
                    Connect.Open();
                    double mas = Convert.ToDouble(dataGridView1.Rows[Convert.ToInt32(dataGridView1.SelectedCells[0].RowIndex)].Cells[0].Value);
                    string query = "DELETE FROM Postavchik WHERE `№` = " + mas;
                    MySqlCommand command = new MySqlCommand(query, Connect);
                    MySqlDataReader Otvet = command.ExecuteReader();
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
                        MySqlConnection Connect = DBUtils.GetDBConnection();
                        Connect.Open();
                        dataGridView1.Rows.Clear();
                        string query = "SELECT * FROM postavchik WHERE `" + comboBox2.Text + "` LIKE '%" + textBox1.Text + "%'";
                        MySqlCommand command = new MySqlCommand(query, Connect);
                        MySqlDataReader Otvet = command.ExecuteReader();

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
                        MySqlConnection Connect1 = DBUtils.GetDBConnection();
                        Connect1.Open();
                        textBox1.Text = "";
                        dataGridView1.Rows.Clear();
                        string query1 = "SELECT * FROM postavchik WHERE `" + comboBox2.Text + "` = (SELECT Max(`" + comboBox2.Text + "`) FROM postavchik);";
                        MySqlCommand command1 = new MySqlCommand(query1, Connect1);
                        MySqlDataReader Otvet1 = command1.ExecuteReader();

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
                        Connect1.Close();
                        foreach (string[] s in OList1)
                            dataGridView1.Rows.Add(s);
                        break;
                    case "Минимальное число":
                        MySqlConnection Connect2 = DBUtils.GetDBConnection();
                        Connect2.Open();
                        textBox1.Text = "";
                        dataGridView1.Rows.Clear();
                        //string query2 = "SELECT * FROM Postavchik WHERE [" + comboBox2.Text + "] =(SELECT MIN([" + comboBox2.Text + "]) FROM Postavchik)";
                        string query2 = "SELECT * FROM postavchik WHERE `" + comboBox2.Text + "` = (SELECT MIN(`" + comboBox2.Text + "`) FROM postavchik);";
                        MySqlCommand command2 = new MySqlCommand(query2, Connect2);
                        MySqlDataReader Otvet2 = command2.ExecuteReader();

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
                        Connect2.Close();
                        foreach (string[] s in OList2)
                            dataGridView1.Rows.Add(s);

                        break;
                }
            }
            catch
            {
                MySqlConnection Connect = DBUtils.GetDBConnection();
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
                    string[] Найти = { "№", "Поставщик", "Вид товаров", "Главный офис", "Количество товара на складе"};
                    comboBox2.Items.Clear();
                    comboBox2.Items.AddRange(Найти);
                    break;
                case "Максимальное число":
                    textBox1.Enabled = false;
                    string[] Числа = { "№", "Количество товара на складе"};
                    comboBox2.Items.Clear();
                    comboBox2.Items.AddRange(Числа);
                    break;
                case "Минимальное число":
                    textBox1.Enabled = false;
                    string[] Числа2 = { "№", "Количество товара на складе" };
                    comboBox2.Items.Clear();
                    comboBox2.Items.AddRange(Числа2);
                    break;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            О_Программе af = new О_Программе();
            af.Owner = this;
            af.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "Help.chm", HelpNavigator.TableOfContents);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            О_Программе af = new О_Программе();
            af.Owner = this;
            af.ShowDialog();
        }

        private void отчетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveTable(dataGridView1);
            MessageBox.Show("Отчет сохранен");
        }
        void SaveTable(DataGridView What_save)
        {
            //Метод делаем.
            DateTime d = DateTime.Now;
            string path = System.IO.Directory.GetCurrentDirectory() + @"\" + "Отчет по таблице Поставщики(" + d.ToShortDateString() + " " + d.Hour + "." + d.Minute + "." + d.Second + ").xlsx";
            // Короче.Коментарии будут относиться к коду сверху. Этот код создает екселевский файл Отчет(дата создания)  
            Excel.Application excelapp = new Excel.Application();
            Excel.Workbook workbook = excelapp.Workbooks.Add();
            Excel.Worksheet worksheet = workbook.ActiveSheet;
            // Создание экземпляра Excel. Создание книг и листов. worksheet - это наш лист,с которым мы будем работать.
            Excel.Range range1 = (Excel.Range)worksheet.Range[worksheet.Cells[2, 1], worksheet.Cells[2, 5]];
            // Выделение области под заголовки .Даем название range1
            Excel.Range range2 = (Excel.Range)worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, 5]];
            // Выделение области под надпись "Отчет бла бла бла" .Даем название range2
            worksheet.Cells[1, 1] = "Отчет по таблице Поставщики за " + d.ToShortDateString();
            worksheet.Cells[2, 1] = dataGridView1.Columns[0].HeaderText;
            worksheet.Cells[2, 2] = dataGridView1.Columns[1].HeaderText;
            worksheet.Cells[2, 3] = dataGridView1.Columns[2].HeaderText;
            worksheet.Cells[2, 4] = dataGridView1.Columns[3].HeaderText;
            worksheet.Cells[2, 5] = dataGridView1.Columns[4].HeaderText;
            // Кидаем в ячейки на листе наши заголовки из датыгридвью
            range1.HorizontalAlignment = Excel.Constants.xlCenter;
            range1.VerticalAlignment = Excel.Constants.xlCenter;
            // Выравниваем заголовки по горизонтали и вертикали
            range2.Cells.Font.Name = "Tahoma";
            range2.Cells.Font.Size = 27;
            range2.Cells.Font.Bold = true;
            // Меняем ячейке "Отчет бла" шрифт,размер, выделяем жирным.
            range2.HorizontalAlignment = Excel.Constants.xlCenter;
            range2.VerticalAlignment = Excel.Constants.xlCenter;
            // Выравниваем "Отчет блав" по горизонтали и вертикали
            range2.Merge(Type.Missing);
            // соединяем ячейки области range2 в одну 
            for (int i = 1; i < dataGridView1.RowCount + 1; i++)
            {
                for (int j = 1; j < dataGridView1.ColumnCount + 1; j++)
                {
                    worksheet.Cells[i + 2, j] = dataGridView1.Rows[i - 1].Cells[j - 1].Value;
                }
            }
            // заполняем страницу из датыгридвью
            Excel.Range c1 = worksheet.Cells[1, 1];
            Excel.Range c2 = worksheet.Cells[dataGridView1.RowCount + 2, dataGridView1.ColumnCount];
            Excel.Range range3 = (Excel.Range)worksheet.Range[c1, c2];
            // Выделим область из добавленных данных и заголовков и закинем в range3
            range3.Cells.Font.Name = "Tahoma";
            range3.Cells.Font.Size = 13;
            // меняем шрифт и размер шрифта range3
            worksheet.Columns.EntireColumn.AutoFit();
            //для всей страницы делаем параметр авторазмера ячек по тексту 
            range3.Borders.get_Item(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous;
            range3.Borders.get_Item(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous;
            range3.Borders.get_Item(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Excel.XlLineStyle.xlContinuous;
            range3.Borders.get_Item(Excel.XlBordersIndex.xlInsideVertical).LineStyle = Excel.XlLineStyle.xlContinuous;
            range3.Borders.get_Item(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous;
            // Делаем рамку для области range3
            range3.HorizontalAlignment = Excel.Constants.xlCenter;
            range3.VerticalAlignment = Excel.Constants.xlCenter;
            // Выравниваем range3 по горизонтали и вертикали
            excelapp.AlertBeforeOverwriting = false;
            workbook.SaveAs(path);
            excelapp.Quit();
            // сохранение и выход

        }
    }
}

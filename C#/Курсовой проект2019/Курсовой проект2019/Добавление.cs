using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсовой_проект2019
{
    public partial class Добавление : Form
    {
        public Добавление()
        {
            InitializeComponent();
        }

        public void Цифры(KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public void Буквы(KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(conteyner.h);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Канцелярия main = this.Owner as Канцелярия;
            if (main != null)
            {
                DataRow nrow = main.kTDataSet.Tables[0].NewRow();
                try
                {
                    nrow[0] = (main.dataGridView1.RowCount + 1).ToString();
                    nrow[1] = textBox2.Text;
                    nrow[2] = textBox3.Text;
                    nrow[3] = textBox4.Text;
                    nrow[4] = textBox5.Text;
                    nrow[5] = textBox6.Text;
                }
                catch
                {
                    MessageBox.Show("Проверьте правильность набора");
                }
                main.kTDataSet.Tables[0].Rows.Add(nrow);
                main.tovariTableAdapter.Update(main.kTDataSet.Tovari);
                main.kTDataSet.Tables[0].AcceptChanges();
                main.dataGridView1.Refresh();
                textBox1.Text = Convert.ToString(conteyner.h + 1);
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            Цифры(e);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            Цифры(e);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            Цифры(e);
        }




    }

}

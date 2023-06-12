using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursovaya
{

    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Main F = new Main();
            F.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string log = Convert.ToString(textBox1.Text);
            string pass = Convert.ToString(textBox2.Text);
            if((log == "Dir") && (pass == "111"))
            {
                Baza Table = new Baza();
                Table.label2.Text = "Директор";
                this.Close();
                Table.ShowDialog();
                
            }
            else if ((log == "Zadir") && (pass == "222"))
            {
                Baza Table = new Baza();
                Table.label2.Text = "Зам.Директора";
                Table.button6.Visible = false;
                Table.button7.Visible = false;
                Table.button8.Visible = false;
                this.Close();
                Table.ShowDialog();

            }
            else if((log == "Prod") && (pass == "333"))
            {
                Baza Table = new Baza();
                Table.label2.Text = "Продавец";
                Table.button1.Visible = false;
                Table.button3.Visible = false;
                Table.button4.Visible = false;
                Table.button5.Visible = false;
                Table.button6.Visible = false;
                Table.button2.Visible = false;
                Table.button8.Visible = false;
                this.Close();
                Table.ShowDialog();

            }
            else
            {
                MessageBox.Show("Неверные логин или пароль");
                Application.Exit();
            }

        }
    }
}

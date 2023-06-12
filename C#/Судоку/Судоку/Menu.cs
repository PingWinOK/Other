using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Судоку
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked == true)
            {
                difficult Dif = new difficult();
                Dif.freefield = 20;
                Sudoku Form1 = new Sudoku(Dif);
                Form1.Show();
                this.Hide();
            }
            else
            {
                difficult Dif = new difficult();
                Dif.freefield = 40;
                Sudoku Form1 = new Sudoku(Dif);
                Form1.Show();
                this.Hide();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            About About = new About();
            // Отображение второй формы
            About.Show();
        }
    }
}

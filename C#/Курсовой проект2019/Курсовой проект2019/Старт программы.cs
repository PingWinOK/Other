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
    public partial class Stars : Form
    {
        public Stars()
        {
            InitializeComponent();
        }

        public void Foo(Label t, Color r)
        {
            t.ForeColor = r;
        }
        private void label2_Click(object sender, EventArgs e)
        {
            Close();
            Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Выбор_БД newForm = new Выбор_БД();
            newForm.Show();
            this.Hide();
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            Foo(label3, Color.Crimson);
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            Foo(label3, Color.PowderBlue);
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            Foo(label4, Color.Crimson);
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            Foo(label4, Color.PowderBlue);
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            Foo(label2, Color.Crimson);
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            Foo(label2, Color.PowderBlue);
        }

        private void label5_MouseEnter(object sender, EventArgs e)
        {
            Foo(label5, Color.Crimson);
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            Foo(label5, Color.PowderBlue);
        }

        private void Stars_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            О_Программе af = new О_Программе();
            af.Owner = this;
            af.ShowDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "Help.chm", HelpNavigator.TableOfContents);
        }
    }
}
﻿using System;
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
    public partial class Выбор_БД : Form
    {
        public Выбор_БД()
        {
            InitializeComponent();
        }
        private void label1_Click(object sender, EventArgs e)
        {
            Канцелярия newForm = new Канцелярия();
            newForm.Show();
            this.Hide();
        }
        public void Foo(Label t, Color r)
        {
            t.ForeColor = r;
        }
        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            Foo(label1, Color.Red);
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            Foo(label1, Color.Black);
        }

        private void label2_MouseMove(object sender, MouseEventArgs e)
        {
            Foo(label2, Color.Red);
        }
        private void label2_MouseLeave(object sender, EventArgs e)
        {
            Foo(label2, Color.Black);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            
            Stars af = new Stars();
            af.Show();
            this.Close();
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            Foo(label4, Color.Black);
        }
        private void label4_MouseMove(object sender, MouseEventArgs e)
        {
            Foo(label4, Color.Red);
        }
    }
}

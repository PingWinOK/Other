using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;

namespace Grafika3
{
    public partial class Form1 : Form
    {
        Graphics g;
        string filename = @"Strings.txt";
        string[] sm = {
"First line", "Second line", "Third line",
"Fourth line", "Fifth line", "Sixth line",
"Seventh line", "Eighth line", "Ninth line",
"Tenth line", "Eleven line", "Twelve line"};

        public Form1()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter f = new StreamWriter(new FileStream(filename, FileMode.Create, FileAccess.Write));
            foreach (string s in sm) { f.WriteLine(s); }
            f.Close();
            MessageBox.Show("12 строк записано в файл !");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            g.Clear(Color.FromArgb(255, 255, 255));
            File.Delete(filename);
            MessageBox.Show("Файл Strings.txt удалён !");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int k = 0;
            try
            {
                StreamReader f = new StreamReader(new FileStream(filename,
                FileMode.Open, FileAccess.Read));
                for (int i = 0; i < 12; i++) { sm[i] = f.ReadLine(); }
                f.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            pictureBox1.BackColor = Color.FromName("Azure");
            pictureBox1.Refresh();
            for (int i = 0; i < 12; i++)
            {
                if ((i >= 0) && (i < 6))
                {

                    k = i;
                    Font fn = new Font("Calibri", 36, FontStyle.Strikeout);
                    StringFormat sf =
                   (StringFormat)StringFormat.GenericTypographic.Clone();
                    sf.FormatFlags = StringFormatFlags.DirectionVertical;
                    sf.Alignment = StringAlignment.Near;
                    sf.LineAlignment = StringAlignment.Near;
                    g.DrawString(sm[i], fn, Brushes.Black,
  new RectangleF(0 + k * 32, 0, pictureBox1.Size.Width - 110, pictureBox1.Size.Height - 120), sf);
                    fn.Dispose();
                }
                if ((i >= 7) && (i < 11))
                {
                    k = i - 7;
                    Font fn = new Font("Consolas", 24, FontStyle.Bold);
                    StringFormat sf =
                   (StringFormat)StringFormat.GenericTypographic.Clone();
                    sf.Alignment = StringAlignment.Far;
                    sf.LineAlignment = StringAlignment.Near;
                    g.DrawString(sm[i], fn, Brushes.Blue,
new RectangleF(0, 0 + k * 25, pictureBox1.Size.Width - 1,
pictureBox1.Size.Height - 1), sf);
                    fn.Dispose();
                }
                if (i == 11)
                {
                    Font fn = new Font("Corbel", 30,FontStyle.Underline);
                    StringFormat sf =
                   (StringFormat)StringFormat.GenericTypographic.Clone();
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Near;
                    g.DrawString(sm[i], fn, Brushes.Green,
                    new RectangleF(0, 0 + i * 30, pictureBox1.Size.Width - 10, pictureBox1.Size.Height - 10), sf);
                    fn.Dispose();
                }
            }
        }
    }
}

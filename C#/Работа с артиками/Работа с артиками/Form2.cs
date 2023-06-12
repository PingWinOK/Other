using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Работа_с_артиками
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        List<string> kar = new List<string>();
        int i = 0;
        private void Form2_Load(object sender, EventArgs e)
        {
            Klass.kar.Clear();
            Klass.karPol.Clear();
            foreach (var file in Directory.GetFileSystemEntries(Klass.t))
            {
                FileInfo f = new FileInfo(file);
                if ((f.Extension == ".jpg") || (f.Extension == ".png") || (f.Extension == ".gif") || (f.Extension == ".PNG") || (f.Extension == ".jpeg"))
                {
                    string New = Klass.t + "\\" + i + f.Extension;
                    i++;
                    Klass.kar.Add(New);
                    Klass.karPol.Add(file);
                    progressBar1.Value += 1;
                    

                }

            }
            Close();
        }

    }
}

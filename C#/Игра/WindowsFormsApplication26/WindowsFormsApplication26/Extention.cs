using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApplication26
{
    public static class Extention
    {
        public static void Blokc(this Panel p)
        {
            List<Button> btnList = p.Controls.OfType<Button>().ToList();
            Button z = btnList[btnList.Count - 1];
            foreach (Button item in btnList)
            {
                if (item.Text == String.Empty)
                    item.Click += (s, e) =>
                        {
                            p.Height = 60;
                            z.Image = item.Image;
                            p.Enabled = false;
                        };
            }
            
        }
    }
}

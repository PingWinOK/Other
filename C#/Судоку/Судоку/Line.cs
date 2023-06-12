using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Судоку
{
    class Lines
    {
        public int WidthLine = 0;
        public int HeightLine = 0;
        public int LocationLineH = 0;
        public int LocationLineV = 0;

        public Panel P { get;  set; }

        public void Line(int WidthLine,int HeightLine,int LocationLineH,int LocationLineV,Panel P)
        {
            this.WidthLine = WidthLine;
            this.HeightLine = HeightLine;
            this.LocationLineH = LocationLineH;
            this.LocationLineV = LocationLineV;
            this.P = P;
        }
        public void CreateLine()
        {
            Panel LineOne = new Panel
            {
                Width = this.WidthLine,
                Height = this.HeightLine,
                BackColor = Color.Black,
                Location = new Point(this.LocationLineH, this.LocationLineV)
            };
            P.Controls.Add(LineOne);
        }

    }
}

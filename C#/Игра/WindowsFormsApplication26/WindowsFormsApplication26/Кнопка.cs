using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication26
{
   public class Кнопка
    {
        public bool выпадающая_кнопка1;
        public Button _btn;
        public Timer _t;
        public Panel _P;

        public Кнопка(Button btn, Panel P, Timer t)
        {
            _btn = btn;
            _t = t;
            _P = P;

            _t.Tick +=new EventHandler(_t_Tick);

        }
        private void _t_Tick(object sender, EventArgs e)
        {
            if (выпадающая_кнопка1)
            {
                _P.Height += 10;
                if (_P.Size.Height == _P.MaximumSize.Height)
                {
                   _t.Stop();
                    выпадающая_кнопка1 = false;
                }
            }
            else
            {
                _P.Height -= 10;
                if (_P.Size == _P.MinimumSize)
                {
                    _t.Stop();
                    выпадающая_кнопка1 = true;
                }
            }
        }
        public void t_Start()
        {
            _t.Start();
        }
        public void t_Stop()
        {
            _t.Stop();
        }

    }
}

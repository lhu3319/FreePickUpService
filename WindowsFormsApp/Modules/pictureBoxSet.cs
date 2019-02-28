using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    class pictureBoxSet
    {
        Form form;
        string imageRoute;
        int pX;
        int pY;
        int sX;
        int sY;

        public pictureBoxSet(Form form, int sX, int sY, int pX, int pY, string imageRoute)
        {
            this.form = form;
            this.sX = sX;
            this.sY = sY;
            this.pX = pX;
            this.pY = pY;
            this.imageRoute = imageRoute;
        }

        public string ImageRoute { get => imageRoute; }
        public int PX { get => pX; }
        public int PY { get => pY; }
        public int SX { get => sX; }
        public int SY { get => sY; }
        public Form Form { get => form; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
namespace WindowsFormsApp
{
    class rbSet
    {
        Form form;
        Control control;
        string name, text;
        int  pX, pY;
        public EventHandler eh_btn;

        public rbSet(Form form, string name,string text, int pX, int pY, EventHandler eh_btn)
        {
            this.form = form;
            this.name = name;
            this.text = text;
            this.pX = pX;
            this.pY = pY;
            this.eh_btn = eh_btn;

        }
        public rbSet(Form form, string name, string text, int pX, int pY)
        {
            this.form = form;
            this.name = name;
            this.text = text;
            this.pX = pX;
            this.pY = pY;
            

        }
        public rbSet(Control control, string name, string text, int pX, int pY, EventHandler eh_btn)
        {
            this.form = null; // 예외처리
            this.control = control;
            this.name = name;
            this.text = text;
            this.pX = pX;
            this.pY = pY;
            this.eh_btn = eh_btn;
        }
        public Control Control
        {
            get { return control; }
        }
        public Form Form
        {
            get { return form; }
        }
        public string Name
        {
            get { return name; }
        }

        public int PX
        {
            get { return pX; }
        }
        public int PY
        {
            get { return pY; }
        }
        public string Text
        {
            get { return text; }
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp.Forms;
namespace WindowsFormsApp
{
    public partial class MainForm : Form
    {
        Commons cm = new Commons();
        Create ct = new Create();
        Button book, check;
        Panel head,body;
        Form form;
        public int step = 4;
        public string phone = "";
        public string date = "";
        public MainForm() // size 1200, 900
        {
            InitializeComponent();
            Load += Main_Load;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.Text = "수거예약 서비스 프로그램";
            this.Size = new Size(1200, 900);
            this.IsMdiContainer = true;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.FormClosing += MainForm_FormClosing;
            View();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            step = -1;
            if (form != null) form.Dispose();
        }

        public void View()
        {
            pnSet pn1 = new pnSet(this, 100, 900, 0, 0);
            head = ct.panel(pn1);
            Controls.Add(head);

            pnSet pn2 = new pnSet(this, 1100, 900, 100, 0);
            body = ct.panel(pn2);
            Controls.Add(body);

            btnSet bs1 = new btnSet(this, "book", "예약하기", 100, 100, 0, 100, btn_Book_click);
            book = ct.btn(bs1);
            head.Controls.Add(book);

            btnSet bs2 = new btnSet(this, "check", "예약조회·변경", 100, 100, 0, 200, btn_Check_click);
            check = ct.btn(bs2);
            head.Controls.Add(check);

            CheckForm();
        }
            

            private void btn_Book_click(object sender, EventArgs e)
        {
            phone = "";
            step = 0;
            CheckForm();
        }


        private void btn_Check_click(object sender, EventArgs e)
        {
            phone = "";
            step = 4;
            CheckForm();
        }

        private void CheckForm()
        {
            
            switch (step)
            {
                case 0:
                    form = new AgreeForm(this);
                    break;
                case 1:
                    form = new Information(this);
                    break;
                case 2:
                    form = new ChoiceForm(this);
                    break;
                case 4:
                    form = new Check(this);
                    break;
                default:
                    body.Controls.Clear();
                    step = 0;
                    return;
            }
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.FormBorderStyle = FormBorderStyle.None;
            body.Controls.Add(form);
            form.Show();
            form.Disposed += Form_Disposed;
        }

        private void Form_Disposed(object sender, EventArgs e)
        {
            CheckForm();
        }
    }
}

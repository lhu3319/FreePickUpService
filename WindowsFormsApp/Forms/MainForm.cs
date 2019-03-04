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

namespace WindowsFormsApp
{
    public partial class MainForm : Form
    {
        Commons cm = new Commons();
        Create ct = new Create();
        Button book, check;
        Panel head,body;
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
            View();
        }
        
        public void View()
        {
            pnSet pn1 = new pnSet(this,100,900,0,0);
            head = ct.panel(pn1);
            Controls.Add(head);

            pnSet pn2 = new pnSet(this, 1100, 900, 100, 0);
            body = ct.panel(pn2);
            Controls.Add(body);

            btnSet bs1 = new btnSet(this, "book", "예약하기", 100, 100, 0, 100, btn_Book_click);
            book = ct.btn(bs1);
            head.Controls.Add(book);

            btnSet bs2 = new btnSet(this, "check", "예약조회·변경",100,100,0,200, btn_Book_click);
            check = ct.btn(bs2);
            head.Controls.Add(check);


        }

        private void btn_Book_click(object sender, EventArgs e)
        {
            AgreeForm af = new AgreeForm();
            af.MdiParent = this;
            af.WindowState = FormWindowState.Maximized;
            af.FormBorderStyle = FormBorderStyle.None;
            body.Controls.Add(af);
            af.Show();

        }
    }
}

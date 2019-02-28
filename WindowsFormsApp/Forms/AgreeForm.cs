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
    public partial class AgreeForm : Form
    {//1100, 700
        Commons cm = new Commons();
        Create ct = new Create();
        Label top;
        Panel head;
        public AgreeForm()
        {
            InitializeComponent();
            Load += AgreeForm_Load;
        }

        private void AgreeForm_Load(object sender, EventArgs e)
        {
            View();
        }
        public void View()
        {
            pnSet pn1 = new pnSet(this, 1200, 150, 0, 0);
            head = ct.panel(pn1);
            Controls.Add(head);

            lbSet lb1 = new lbSet(this, "top", "폐가전제품 방문수거 배출예약", 300, 50, 50, 10, 14);
            top = ct.label(lb1);
            top.Font = new Font("Verdana", 20.5f, FontStyle.Bold);
            head.Controls.Add(top);

            ArrayList label_list = new ArrayList();
            label_list.Add(new lbSet(this,"first" ,"약관동의" , 200, 150, 50,100,15));
            label_list.Add(new lbSet(this, "second", "기본정보 입력", 200,150,300,100,15));
            label_list.Add(new lbSet(this, "third", "배출품목 입력", 200, 150, 550, 100,15));
            label_list.Add(new lbSet(this, "fourth", "예약완료", 200, 150, 800, 100,15));

            for(int i = 0; i < label_list.Count; i++)
            {
                Label label = ct.label((lbSet)label_list[i]);
                label.BackColor = Color.Beige;
                label.Font = new Font("Verdana", 15.5f, FontStyle.Bold);
                label.TextAlign = ContentAlignment.TopCenter;
                head.Controls.Add(label);
            }
        }
    }
}


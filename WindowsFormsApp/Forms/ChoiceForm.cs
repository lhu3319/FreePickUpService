using Newtonsoft.Json.Linq;
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
    public partial class ChoiceForm : Form
    {
        MainForm mf;
        Create ct = new Create();
        Panel head,first,second,third,fourth;
        ArrayList label_list,radio_list;
        Label top,fl,sl,tl,ll;
        pnSet pn1;
        lbSet lb1;
        RadioButton rbutton;
        Hashtable ht;
        Webapi api;
        Button next;
        btnSet bt1;
        RadioButton button;
        public ChoiceForm()
        {
            InitializeComponent();
            Load += ChoiceForm_Load;
        }
        public ChoiceForm(MainForm mf)
        {
            InitializeComponent();
            Load += ChoiceForm_Load;
            this.mf = mf;
        }
        private void ChoiceForm_Load(object sender, EventArgs e)
        {
            View();
            first_view();
            
        }

        public void View()
        {
            
            pn1 = new pnSet(this, 1200, 900, 0, 0);
            head = ct.panel(pn1);
            Controls.Add(head);

            pn1 = new pnSet(this, 150, 300, 50, 150);
            first = ct.panel(pn1);
            first.BackColor = Color.Coral;
            head.Controls.Add(first);

            pn1 = new pnSet(this, 150, 300, 300, 150);
            second = ct.panel(pn1);
            second.BackColor = Color.DimGray;
            head.Controls.Add(second);

            pn1 = new pnSet(this, 150, 300, 550, 150);
            third = ct.panel(pn1);
            third.BackColor = Color.DeepSkyBlue;
            head.Controls.Add(third);

            pn1 = new pnSet(this, 150, 300, 800, 150);
            fourth = ct.panel(pn1);
            fourth.BackColor = Color.Cornsilk;
            head.Controls.Add(fourth);


            lb1 = new lbSet(this, "top", "폐가전제품 방문수거 배출예약", 300, 40, 50, 10, 14);
            top = ct.label(lb1);
            top.Font = new Font("Verdana", 20.5f, FontStyle.Bold);
            head.Controls.Add(top);
            label_list = new ArrayList();
            label_list.Add(new lbSet(this, "first", "약관동의", 200, 50, 50, 50, 15));
            label_list.Add(new lbSet(this, "second", "기본정보 입력", 200, 50, 300, 50, 15));
            label_list.Add(new lbSet(this, "third", "배출품목 입력", 200, 50, 550, 50, 15));
            label_list.Add(new lbSet(this, "fourth", "예약완료", 200, 50, 800, 50, 15));

            for (int i = 0; i < label_list.Count; i++)
            {
                Label label = ct.label((lbSet)label_list[i]);
                if (i == 2)
                {
                    label.BackColor = Color.Beige;
                }

                label.Font = new Font("Verdana", 15.5f, FontStyle.Bold);
                label.TextAlign = ContentAlignment.MiddleCenter;
                head.Controls.Add(label);
            }
            lb1 = new lbSet(this, "first", "대분류", 150, 30, 0, 0, 10);
            fl = ct.label(lb1);
            fl.Font = new Font("Verdana", 13.5f, FontStyle.Bold);
            fl.BackColor = Color.Silver;
            fl.TextAlign = ContentAlignment.MiddleCenter;
            first.Controls.Add(fl);

            lb1 = new lbSet(this, "second", "중분류", 150, 30, 0, 0, 10);
            sl = ct.label(lb1);
            sl.Font = new Font("Verdana", 13.5f, FontStyle.Bold);
            sl.BackColor = Color.Silver;
            sl.TextAlign = ContentAlignment.MiddleCenter;
            second.Controls.Add(sl);

            lb1 = new lbSet(this, "third", "소분류", 150, 30, 0, 0, 10);
            tl = ct.label(lb1);
            tl.Font = new Font("Verdana", 13.5f, FontStyle.Bold);
            tl.BackColor = Color.Silver;
            tl.TextAlign = ContentAlignment.MiddleCenter;
            third.Controls.Add(tl);

            lb1 = new lbSet(this, "ll", "수량", 150, 30, 0, 0, 10);
            ll = ct.label(lb1);
            ll.Font = new Font("Verdana", 13.5f, FontStyle.Bold);
            ll.BackColor = Color.Silver;
            ll.TextAlign = ContentAlignment.MiddleCenter;
            fourth.Controls.Add(ll);

            /*
            rbSet rb = new rbSet(this, "test", "test", 100, 750);
            RadioButton rbtn = ct.radio(rb);
            head.Controls.Add(rbtn);
            rbtn.Click += next_click;
            */
            bt1 = new btnSet(this, "next", "다음단계", 100, 50, 960, 750, test_Click);
            next = ct.btn(bt1);
            head.Controls.Add(next);
        }
        private void next_click(object sender, EventArgs e)
        {
            
            RadioButton btn = (RadioButton)sender;

            MessageBox.Show(btn.Name+"!!");
            //MessageBox.Show(_bNo);
            ArrayList list = new ArrayList();
            ht = new Hashtable();
            ht.Add("spName", "pro_first");
            ht.Add("no", "no:1" );
            second.Controls.Clear();
            list = api.Select("http://192.168.3.15:5000/pro_first", ht);
            MessageBox.Show(list.Count.ToString());
            if (list != null)
            {
                ArrayList arrayList = api.Radio2(second, list, second_Click);
                for (int i = 0; i < arrayList.Count; i++)
                {
                    RadioButton button = ct.radio((rbSet)arrayList[i]);
                    second.Controls.Add(button);
                }
            }
            
        }
        ArrayList button_List;
            ArrayList button_List1 = new ArrayList();

            private void first_view()
        {

            api = new Webapi();
            ht = new Hashtable();
            ht.Add("spName", "pro_first");
            ht.Add("no", "no:0" );
            ArrayList list = api.Select("http://192.168.3.15:5000/pro_first", ht);
            MessageBox.Show(list.Count.ToString());
            if (list != null)
            {
                button_List = api.Radio(this, list, test_Click);
                for (int i = 0; i < button_List.Count; i++)
                {
                    button = ct.radio((rbSet)button_List[i]);
                    button_List1.Add(button);
                    first.Controls.Add(button);
                }
            }
        }
        private void test_Click(object sender, EventArgs e)
        {
            //RadioButton btn = (RadioButton)sender;
            button = (RadioButton)button_List1[1];
            MessageBox.Show(button.Name);
        }

        private void first_Click(object sender, EventArgs e)
        {
            RadioButton btn = (RadioButton)sender;

            
            MessageBox.Show("1");
            ArrayList list = new ArrayList();
            ht = new Hashtable();
            ht.Add("spName", "pro_first");
            ht.Add("no", "no:"+btn.Name);
            MessageBox.Show(ht["no"].ToString());
            second.Controls.Clear();
            list = api.Select("http://192.168.3.15:5000/pro_first", ht);
            MessageBox.Show(list.Count.ToString());
            if (list != null)
            {
                ArrayList arrayList = api.Radio2(second, list, second_Click);
                for (int i = 0; i < arrayList.Count; i++)
                {
                    RadioButton button = ct.radio((rbSet)arrayList[i]);
                    second.Controls.Add(button);
                }
            }
        }
        private void second_Click(object sender, EventArgs e)
        {

        }

    }
}


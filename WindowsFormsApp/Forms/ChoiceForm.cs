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
        Button next,behind,add;
        btnSet bt1;
        TextBox count;
        ListView lv;
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

            pn1 = new pnSet(this, 200, 300, 550, 150);
            third = ct.panel(pn1);
            third.BackColor = Color.DeepSkyBlue;
            head.Controls.Add(third);

            pn1 = new pnSet(this, 150, 300, 850, 150);
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

            CreateLb(second, new lbSet(this, "second", "중분류", 150, 30, 0, 0, 10));
            CreateLb(third, new lbSet(this, "third", "소분류", 200, 30, 0, 0, 10));

            lb1 = new lbSet(this, "ll", "수량", 150, 30, 0, 0, 10);
            ll = ct.label(lb1);
            ll.Font = new Font("Verdana", 13.5f, FontStyle.Bold);
            ll.BackColor = Color.Silver;
            ll.TextAlign = ContentAlignment.MiddleCenter;
            fourth.Controls.Add(ll);

            bt1 = new btnSet(this, "next", "다음단계", 100, 50, 960, 750, Next_Click);
            next = ct.btn(bt1);
            head.Controls.Add(next);

            bt1 = new btnSet(this, "behind", "이전단계", 100, 50, 850, 750, Behind_Click);
            behind = ct.btn(bt1);
            head.Controls.Add(behind);

            bt1 = new btnSet(this, "add","추가", 70, 30, 60, 80, Add_Click);
            add = ct.btn(bt1);
            fourth.Controls.Add(add);
            //150 300
            tbSet ts = new tbSet(this, "count", 60, 30, 45, 40);
            count = ct.txtbox(ts);
            count.Font = new Font("Verdana", 13.5f, FontStyle.Regular);
            count.Multiline = false;
            count.MaxLength = 2;
            fourth.Controls.Add(count);

            lvSet ls = new lvSet(this, "리스트뷰", 950, 200, 50, 500,null);
            lv = ct.listview(ls);
            lv.Columns.Add("대분류",200, HorizontalAlignment.Center);
            lv.Columns.Add("중분류", 200, HorizontalAlignment.Center);
            lv.Columns.Add("소분류", 300, HorizontalAlignment.Center);
            lv.Columns.Add("수량", 100, HorizontalAlignment.Center);
            lv.Columns.Add("삭제", 150, HorizontalAlignment.Center);
            lv.Scrollable = false;
            
            head.Controls.Add(lv);
        }

        private void CreateLb(Control ctr, lbSet lb)
        {
            sl = ct.label(lb);
            sl.Font = new Font("Verdana", 13.5f, FontStyle.Bold);
            sl.BackColor = Color.Silver;
            sl.TextAlign = ContentAlignment.MiddleCenter;
            ctr.Controls.Add(sl);
        }
        
        ArrayList button_List;
            ArrayList button_List1 = new ArrayList();

        private void first_view()
        {

            api = new Webapi();
            ht = new Hashtable();
            ht.Add("spName", "pro_first");
            ht.Add("Upno", 0 );
            ArrayList list = api.Select(Program.URL + "/pro_first", ht);
            if (list != null)
            {
                button_List = api.Radio(this, list, first_Click);
                for (int i = 0; i < button_List.Count; i++)
                {
                    RadioButton rButton = ct.radio((rbSet)button_List[i]);
                    MessageBox.Show(rButton.Text);
                    button_List1.Add(rButton);
                    first.Controls.Add(rButton);
                }
            }
        }
        private void Next_Click(object sender, EventArgs e)
        {
            mf.step = 3;
            this.Dispose();
        }
        private void Behind_Click(object sender, EventArgs e)
        {
            mf.step = 1;
            this.Dispose();
        }
        private void Add_Click(object sender, EventArgs e)
        {
            lv.Items.Add(count.Text, 4);
        }
        private void first_Click(object sender, EventArgs e)
        {
            RadioButton btn = (RadioButton)sender;            
            ArrayList list = new ArrayList();
            ht = new Hashtable();
            ht.Add("spName", "pro_first");
            ht.Add("no", btn.Name);
            second.Controls.Clear();
            CreateLb(second, new lbSet(this, "second", "중분류", 150, 30, 0, 0, 10));
            list = api.Select(Program.URL + "/pro_first", ht);
            if (list != null)
            {
                ArrayList arrayList = api.Radio(second, list, second_Click);
                for (int i = 0; i < arrayList.Count; i++)
                {
                    RadioButton button = ct.radio((rbSet)arrayList[i]);
                    second.Controls.Add(button);
                }
            }
        }
        private void second_Click(object sender, EventArgs e)
        {
            RadioButton btn = (RadioButton)sender;
            ArrayList list = new ArrayList();
            ht = new Hashtable();
            ht.Add("spName", "pro_first");
            ht.Add("no", btn.Name);
            third.Controls.Clear();
            CreateLb(third, new lbSet(this, "third", "소분류", 200, 30, 0, 0, 10));
            list = api.Select(Program.URL + "/pro_first", ht);
            if (list != null)
            {
                ArrayList arrayList = api.Radio(third, list, null);
                for (int i = 0; i < arrayList.Count; i++)
                {
                    RadioButton button = ct.radio((rbSet)arrayList[i]);
                    third.Controls.Add(button);
                }
            }
        }

    }
}


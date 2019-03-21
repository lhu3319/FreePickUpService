using Newtonsoft.Json;
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
        ArrayList AddList = new ArrayList();
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
            api = new Webapi();
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

            lvSet ls = new lvSet(this, "리스트뷰", 400, 200, 50, 500, lv_Click);
            lv = ct.listview(ls);
            lv.FullRowSelect = true;
            lv.Columns.Add("번호", 50, HorizontalAlignment.Center);
            lv.Columns.Add("폐가전제품" ,250, HorizontalAlignment.Center);
            lv.Columns.Add("수량", 100, HorizontalAlignment.Center);
            lv.Font = new Font("Verdana", 11.5f, FontStyle.Bold);
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

        private void first_view() // 대분류 라디오버튼
        {
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
                    button_List1.Add(rButton);
                    first.Controls.Add(rButton);
                }
            }
        }
        string name;
        private void Add_Click(object sender, EventArgs e)
        {
            if (count.Text != null)
            {
                foreach (Control ctr in third.Controls)
                {
                    if (ctr.GetType().ToString() == "System.Windows.Forms.RadioButton")
                    {
                        RadioButton rb = (RadioButton)ctr;
                        if (rb.Checked)
                        {
                            string 번호 = ctr.Name;
                            string 폐가전제품 = ctr.Text;
                            string 수량 = count.Text;

                            if (lv.Items.Count > 0)
                            {
                                bool check = true;
                                foreach (ListViewItem lvi in lv.Items)
                                {
                                    if (lvi.SubItems[0].Text == 번호)
                                    {
                                        int 변경수량 = Convert.ToInt32(lvi.SubItems[2].Text) + Convert.ToInt32(수량);
                                        lvi.SubItems[2].Text = 변경수량.ToString();
                                        check = false;
                                        break;
                                    }
                                }

                                if (check)
                                {
                                    lv.Items.Add(new ListViewItem(new string[] { 번호, 폐가전제품, 수량 }));
                                }
                            }
                            else
                            {
                                lv.Items.Add(new ListViewItem(new string[] { 번호, 폐가전제품, 수량 }));
                            }                            
                        }
                    }
                }
            }
        }
        
        private void lv_Click(object sender, EventArgs e)
        {
            ListView lv1 = (ListView)sender;
            string 제품 = lv1.SelectedItems[0].SubItems[1].Text;
            DialogResult dr = MessageBox.Show(string.Format("{0}를 목록에서 삭제하시겠습니까?",  제품), "한의 경고창", MessageBoxButtons.YesNo);
            if(dr == DialogResult.Yes)
            {
                lv1.Items.Remove(lv1.SelectedItems[0]);
            }
        }

        private void first_Click(object sender, EventArgs e) // 중분류 라디오버튼
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
        
        private void second_Click(object sender, EventArgs e) // 소분류 라디오버튼
        {
            RadioButton last = (RadioButton)sender;
            
            ArrayList list = new ArrayList();
            ht = new Hashtable();
            ht.Add("spName", "pro_first");
            ht.Add("no", last.Name);
            third.Controls.Clear();
            CreateLb(third, new lbSet(this, "third", "소분류", 200, 30, 0, 0, 10));
            list = api.Select(Program.URL + "/pro_first", ht);
            if (list != null)
            {
                ArrayList arrayList = api.Radio(third, list, third_Click);
                for (int i = 0; i < arrayList.Count; i++)
                {
                    RadioButton button = ct.radio((rbSet)arrayList[i]);
                    third.Controls.Add(button);
                }
            }
            
        }
        private void third_Click(object sender, EventArgs e)
        {
            RadioButton btn = (RadioButton)sender;
            name = btn.Text;
        }

        private void Next_Click(object sender, EventArgs e)
        {
            if(lv.Items.Count > 0)
            {
                Label third = new Label();
                Label fourth = new Label();
                foreach (Control ctr in head.Controls)
                {
                    if (ctr.Name == "third")
                    {
                        ctr.BackColor = Color.Transparent;
                        third = (Label)ctr;
                    }

                    if (ctr.Name == "fourth")
                    {
                        ctr.BackColor = Color.Beige;
                        fourth = (Label)ctr;
                        break;
                    }
                }
                DialogResult dr = MessageBox.Show("등록하신 폐가전제품을 요청하시겠습니까?", "한의 경고창", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    // 디비
                    int check = 0;
                    foreach (ListViewItem lvi in lv.Items)
                    {
                        JObject jo = new JObject();
                        jo.Add("_Phone", mf.phone);
                        jo.Add("_iNo", lvi.SubItems[0].Text);
                        jo.Add("_cnt", lvi.SubItems[2].Text);
                        jo.Add("_date", mf.date);
                        Hashtable ht = new Hashtable();
                        ht.Add("spName", "insert_Product");
                        ht.Add("param", jo.ToString());

                        string result = api.Post_Param(Program.URL + "/param_request_NonQuery", ht);
                        JObject resultObject = JsonConvert.DeserializeObject<JObject>(result);
                        foreach (JProperty jp in resultObject.Properties())
                        {
                            if (jp.Name == "state")
                            {
                                if (jp.Value.ToString() == "0")
                                {
                                    check++;
                                }
                            }
                        }
                    }
                    if (check > 0)
                    {
                        MessageBox.Show("요청 오류 발생 건이 있습니다.");
                    }
                    mf.step = 4;
                    this.Dispose();
                }
                else
                {
                    third.BackColor = Color.Beige;
                    fourth.BackColor = Color.Transparent;
                }
            }
            else
            {
                MessageBox.Show("폐가전제품을 등록하세요.");
            }            
        }
        private void Behind_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < t.Count; i++)
            {
                MessageBox.Show(t[i].ToString());
            }
            mf.step = 1;
            this.Dispose();
        }
        ArrayList t = new ArrayList();
    }
}


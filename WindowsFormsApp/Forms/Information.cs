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
    public partial class Information : Form
    {
        Create ct = new Create();
        Panel head;
        Label top, warning, content, addr, raddr;
        RichTextBox name_box, pnb_box1, pnb_box2, pnb_box3, nb_box1, nb_box2, nb_box3, addr_box, road_box, detail_box, memo_box;
        ArrayList label_list;
        lbSet lb1;
        richtbSet rb1;
        btnSet bt1;
        Button search, next, behind;
        comboboxSet cb1;
        ComboBox home, elevator;
        MainForm mf;
        DateTimePicker date;
        string today = DateTime.Now.ToString("yyyy-MM-dd"); // 오늘날짜 비교용
        //RichTextBox ;
        public Information()
        {
            InitializeComponent();
            Load += Information_Load;
        }
        public Information(MainForm mf)
        {
            InitializeComponent();
            Load += Information_Load;
            this.mf = mf;

        }

        private void Information_Load(object sender, EventArgs e)
        {
            View();
        }
        public void View()
        {
            pnSet pn1 = new pnSet(this, 1200, 900, 0, 0);
            head = ct.panel(pn1);
            Controls.Add(head);

            lbSet lb1 = new lbSet(this, "top", "폐가전제품 방문수거 배출예약", 300, 40, 50, 10, 14);
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
                if (i == 1)
                {
                    label.BackColor = Color.Beige;
                }
                label.Font = new Font("Verdana", 15.5f, FontStyle.Bold);
                label.TextAlign = ContentAlignment.MiddleCenter;
                head.Controls.Add(label);
            }
            lb1 = new lbSet(this, "content", "※ 배출예약 시 주의사항", 200, 18, 50, 130, 9);
            warning = ct.label(lb1);
            warning.Font = new Font("맑은고딕", 9.5f, FontStyle.Bold);
            head.Controls.Add(warning);
            lb1 = new lbSet(this, "warning", "1. 주소가 입력되지 않은 상태에서는 품목 및 희망 배출일 선택이 되지 않습니다. 주소를 우선적으로 입력해주세요.\n2. 접수 시 불편사항이나 문의사항은 1599 - 0903으로 연락 바랍니다.", 1000, 50, 50, 158, 10);
            content = ct.label(lb1);
            content.Font = new Font("맑은고딕", 10.5f);
            head.Controls.Add(content);

            //name,pnumber,number,addr,home,outdate,memo
            label_list = new ArrayList();
            label_list.Add(new lbSet(this, "name", "이름\n(*)", 90, 50, 50, 220, 10));
            label_list.Add(new lbSet(this, "pnumber", "휴대폰번호(*)", 90, 50, 50, 280, 10));
            label_list.Add(new lbSet(this, "number", "전화번호", 90, 50, 50, 340, 10));
            label_list.Add(new lbSet(this, "addr", "주소\n(*)", 90, 160, 50, 400, 10));
            label_list.Add(new lbSet(this, "home", "주거방법", 90, 50, 50, 570, 10));
            label_list.Add(new lbSet(this, "outdate", "배출희망날짜(*)", 90, 50, 50, 630, 10));
            label_list.Add(new lbSet(this, "memo", "메모", 90, 50, 50, 690, 10));


            for (int i = 0; i < label_list.Count; i++)
            {
                Label label = ct.label((lbSet)label_list[i]);
                if (i == 3)
                {
                    label.BackColor = Color.Bisque;
                }
                else if (i == 7 || i == 8)
                {
                    label.Font = new Font("Verdana", 9.5f, FontStyle.Bold);
                    label.TextAlign = ContentAlignment.MiddleCenter;
                }
                label.Font = new Font("Verdana", 11.5f, FontStyle.Bold);
                label.TextAlign = ContentAlignment.MiddleCenter;
                head.Controls.Add(label);
            }
            label_list = new ArrayList();
            label_list.Add(new lbSet(this, "hipen1", "-", 10, 30, 218, 290, 10));
            label_list.Add(new lbSet(this, "hipen2", "-", 10, 30, 295, 290, 10));
            label_list.Add(new lbSet(this, "hipen3", "-", 10, 30, 218, 340, 10));
            label_list.Add(new lbSet(this, "hipen4", "-", 10, 30, 295, 340, 10));
            for (int i = 0; i < label_list.Count; i++)
            {
                Label label = ct.label((lbSet)label_list[i]);
                label.Font = new Font("Verdana", 9.5f, FontStyle.Bold);
                label.TextAlign = ContentAlignment.MiddleCenter;
                head.Controls.Add(label);
            }
            //RichTextBox name_box, pnb_box1, pnb_box2, pnb_box3, nb_box1, nb_box2, nb_box3, addr_box, road_box, memo_box;
            rb1 = new richtbSet(this, "name_box", 220, 30, 150, 230);
            name_box = ct.richbox(rb1);
            name_box.Font = new Font("Verdana", 11.5f);
            name_box.MaxLength = 4;
            name_box.Multiline = false;
            head.Controls.Add(name_box);

            rb1 = new richtbSet(this, "pnb_box3", 65, 30, 150, 290);
            pnb_box1 = ct.richbox(rb1);
            pnb_box1.Font = new Font("Verdana", 11.5f);
            pnb_box1.KeyPress += Tb_KeyPress;
            pnb_box1.MaxLength = 3;
            pnb_box1.Multiline = false;
            head.Controls.Add(pnb_box1);

            rb1 = new richtbSet(this, "pnb_box2", 65, 30, 228, 290);
            pnb_box2 = ct.richbox(rb1);
            pnb_box2.Font = new Font("Verdana", 11.5f);
            pnb_box2.KeyPress += Tb_KeyPress;
            pnb_box2.MaxLength = 4;
            pnb_box2.Multiline = false;
            head.Controls.Add(pnb_box2);

            rb1 = new richtbSet(this, "pnb_box3", 65, 30, 305, 290);
            pnb_box3 = ct.richbox(rb1);
            pnb_box3.Font = new Font("Verdana", 11.5f);
            pnb_box3.KeyPress += Tb_KeyPress;
            pnb_box3.MaxLength = 4;
            pnb_box3.Multiline = false;
            head.Controls.Add(pnb_box3);

            rb1 = new richtbSet(this, "nb_box1", 65, 30, 150, 340);
            nb_box1 = ct.richbox(rb1);
            nb_box1.Font = new Font("Verdana", 11.5f);
            nb_box1.KeyPress += Tb_KeyPress;
            nb_box1.MaxLength = 3;
            nb_box1.Multiline = false;
            head.Controls.Add(nb_box1);

            rb1 = new richtbSet(this, "nb_box2", 65, 30, 228, 340);
            nb_box2 = ct.richbox(rb1);
            nb_box2.Font = new Font("Verdana", 11.5f);
            nb_box2.KeyPress += Tb_KeyPress;
            nb_box2.MaxLength = 4;
            nb_box2.Multiline = false;
            head.Controls.Add(nb_box2);

            rb1 = new richtbSet(this, "nb_box3", 65, 30, 305, 340);
            nb_box3 = ct.richbox(rb1);
            nb_box3.Font = new Font("Verdana", 11.5f);
            nb_box3.KeyPress += Tb_KeyPress;
            nb_box3.MaxLength = 4;
            nb_box3.Multiline = false;
            head.Controls.Add(nb_box3);

            bt1 = new btnSet(this, "search", "주소검색", 70, 30, 160, 400, Search_click);
            search = ct.btn(bt1);
            search.Font = new Font("맑은고딕", 11.5f);
            head.Controls.Add(search);

            lb1 = new lbSet(this, "addr", "구주소", 60, 30, 160, 440, 9);
            addr = ct.label(lb1);
            addr.TextAlign = ContentAlignment.MiddleCenter;
            addr.Font = new Font("맑은고딕", 11.5f);
            head.Controls.Add(addr);
            lb1 = new lbSet(this, "raddr", "새주소", 60, 30, 160, 480, 9);
            raddr = ct.label(lb1);
            raddr.TextAlign = ContentAlignment.MiddleCenter;
            raddr.Font = new Font("맑은고딕", 11.5f);
            head.Controls.Add(raddr);

            rb1 = new richtbSet(this, "addr", 350, 30, 225, 440);
            addr_box = ct.richbox(rb1);
            addr_box.Font = new Font("Verdana", 11.5f);
            addr_box.Multiline = false;
            head.Controls.Add(addr_box);

            rb1 = new richtbSet(this, "raddr", 350, 30, 225, 480);
            road_box = ct.richbox(rb1);
            road_box.Font = new Font("Verdana", 11.5f);
            road_box.Multiline = false;
            head.Controls.Add(road_box);

            rb1 = new richtbSet(this, "raddr", 250, 30, 225, 520);
            detail_box = ct.richbox(rb1);
            detail_box.Font = new Font("Verdana", 11.5f);
            detail_box.Text = "상세주소";
            detail_box.ForeColor = Color.Gray;
            detail_box.Multiline = false;
            detail_box.Click += detail_box_Click;

            head.Controls.Add(detail_box);

            cb1 = new comboboxSet(this, "home", 100, 30, 160, 580);
            home = ct.combobox(cb1);
            home.Font = new Font("Verdana", 11.5f);
            home.Text = ("주거형태");
            home.Items.Add("아파트");
            home.Items.Add("연립주택");
            home.Items.Add("단층주택");
            home.Items.Add("빌딩");
            head.Controls.Add(home);

            cb1 = new comboboxSet(this, "elevator", 130, 30, 270, 580);
            elevator = ct.combobox(cb1);
            elevator.Font = new Font("Verdana", 11.5f);
            elevator.Text = ("엘레베이터 유무");
            elevator.Items.Add("유");
            elevator.Items.Add("무");
            head.Controls.Add(elevator);

            DateSet ds1 = new DateSet(this, "date", 170, 30, 160, 650);
            date = ct.datepic(ds1); 
            date.Font = new Font("Verdana", 11.5f);
            date.MinDate = DateTime.Today;
            head.Controls.Add(date);

            rb1 = new richtbSet(this, "memo", 420, 30, 160, 700);
            memo_box = ct.richbox(rb1);
            memo_box.Font = new Font("Verdana", 11.5f);
            memo_box.Multiline = false;
            head.Controls.Add(memo_box);

            bt1 = new btnSet(this, "next", "다음단계", 100, 50, 960, 750, next_click);
            next = ct.btn(bt1);
            head.Controls.Add(next);

            bt1 = new btnSet(this, "behind", "이전단계", 100, 50, 850, 750, behind_click);
            behind = ct.btn(bt1);
            head.Controls.Add(behind);

        }

        private void Tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            RichTextBox tb = (RichTextBox)sender;
            tb.ForeColor = Color.Black;
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == '-'))
            {
                e.Handled = true;
            }
        }
        private void detail_box_Click(object sender, EventArgs e)
        {
            detail_box.Text = "";
            detail_box.ForeColor = Color.Black;
        }
        private void Search_click(object sender, EventArgs e)
        {
            SearchAddrForm saf = new SearchAddrForm();
            saf.ShowDialog();
        }
        private void next_click(object sender, EventArgs e)
        {
            string date_text = date.Text.Substring(0, 10);
            if (name_box.Text == "")
            {
                MessageBox.Show("이름을 입력해주세요.");
                
            }/*
            else if (pnb_box1.Text == "" || pnb_box2.Text == "" || pnb_box3.Text == "")
            {
                MessageBox.Show("휴대폰 번호를 입력해주세요");
            }
            else if (addr_box.Text == "" || road_box.Text == "" || detail_box.Text == "")
            {
                MessageBox.Show("주소를 입력해주세요");
            }
            else if(today == date_text)
            {
                MessageBox.Show("당일에는 예약이 불가능합니다");
            }*/
            else
            {
                ChoiceForm cf = new ChoiceForm();
                cf.TopLevel = false;
                //cf.MdiParent = ParentForm;
                cf.WindowState = FormWindowState.Maximized;
                cf.FormBorderStyle = FormBorderStyle.None;
                head.Controls.Add(cf);
                cf.Show();
            }
        }
        private void behind_click(object sender, EventArgs e)
        {
            AgreeForm af = new AgreeForm();
            af.TopLevel = false;
            af.WindowState = FormWindowState.Maximized;
            af.FormBorderStyle = FormBorderStyle.None;
            this.Visible = false;
            head.Controls.Add(af);
            af.Show();
        }
    }
}

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
        Label top,warning,content,name,pnumber,number,addr,home,outdate,memo;
        RichTextBox name_box, pnb_box1, pnb_box2, pnb_box3, nb_box1, nb_box2, nb_box3, addr_box, road_box, memo_box;
        ArrayList label_list;
        //RichTextBox ;
        public Information()
        {
            InitializeComponent();
            Load += Information_Load;
        }

        private void Information_Load(object sender, EventArgs e)
        {
            View();
        }
        public void View()
        {
            pnSet pn1 = new pnSet(this, 1200, 800, 0, 0);
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
            lbSet lb2 = new lbSet(this,"content" ,"※ 배출예약 시 주의사항", 200, 18, 50, 130, 9);
            warning = ct.label(lb2);
            warning.Font = new Font("맑은고딕",9.5f ,FontStyle.Bold);
            head.Controls.Add(warning);
            lbSet lb3 = new lbSet(this, "warning", "1. 주소가 입력되지 않은 상태에서는 품목 및 희망 배출일 선택이 되지 않습니다. 주소를 우선적으로 입력해주세요.\n2. 접수 시 불편사항이나 문의사항은 1599 - 0903으로 연락 바랍니다.", 1000, 50, 50, 158, 10);
            content = ct.label(lb3);
            content.Font = new Font("맑은고딕", 10.5f);
            head.Controls.Add(content);

            //name,pnumber,number,addr,home,outdate,memo
            label_list = new ArrayList();
            label_list.Add(new lbSet(this, "name", "이름(*)", 90, 50, 50, 220, 10));
            label_list.Add(new lbSet(this, "pnumber", "휴대폰번호(*)", 90, 50, 50, 280, 10));
            label_list.Add(new lbSet(this, "number", "전화번호", 90, 50, 50, 330, 10));
            label_list.Add(new lbSet(this, "addr", "주소(*)", 90, 100, 50, 380, 10));
            label_list.Add(new lbSet(this, "home", "주거방법", 90, 50, 50, 430, 10));
            label_list.Add(new lbSet(this, "outdate", "배출희망날짜", 90, 50, 50, 480, 10));
            label_list.Add(new lbSet(this, "memo", "메모", 90, 50, 50, 530, 10));

            for(int i = 0; i < label_list.Count; i++)
            {
                Label label = ct.label((lbSet)label_list[i]);
                if (i == 3)
                {
                    label.BackColor = Color.Bisque;
                }
                label.Font = new Font("Verdana", 11.5f, FontStyle.Bold);
                label.TextAlign = ContentAlignment.MiddleCenter;
                head.Controls.Add(label);
            }

            
        }
    }
}

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
    {//1100, 800
        
        Create ct = new Create();
        Label top;
        MainForm mf;
        Panel head;
        ArrayList label_list;
        RichTextBox service_box, info_box, apply_box;
        CheckBox service_check, info_check, apply_check,all_check;
        Button next;

        string service_string = string.Format("제 1장 총칙 \n\n 제 1 조(목적) \n\n① 이 약관은 배출예약시스템(http://www.15990903.or.kr) 사이트(이하 '당 사이트'라 함)가 제공하는 모든 서비스(이하 \"서비스\")의 가입 및 이용조건/절차, 이용자와 당 사이트의 권리, 의무, 책임사항과 기타 필요한 사항을 규정함을 목적으로 합니다."+
            "\n\n 제 2 조 (약관의 효력 및 변경) \n\n① 당 사이트는 이용자가 본 약관 내용에 동의하는 것을 조건으로 이용자에게 서비스를 제공할 것이며, 이용자가 본 약관의 내용에 동의하는 경우 당 사이트의 서비스 제공 행위 및 이용자의 서비스 사용 행위에는 본 약관이 우선적으로 적용될 것입니다."+
            "\n\n② 당 사이트는 본 약관을 사전 고지 없이 변경할 수 있으며, 변경된 약관은 당 사이트 내에 공지함으로써 이용자가 직접 확인하도록 할 것입니다. 이용자가 변경된 약관에 동의하지 아니하는 경우, 이용자는 서비스 신청을 취소(회원탈퇴)할 수 있으며, 계속 사용의 경우는 약관 변경에 대한 동의로 간주됩니다. 변경된 약관은 공지와 동시에 그 효력이 발생됩니다."+
            "\n\n 제 3 조 (약관 외 준칙) \n\n① 본 약관은 당 사이트가 제공하는 서비스에 관한 이용규정과 함께 적용됩니다. \n\n② 본 약관에 명시되지 아니한 사항에 대해서는 전기통신기본법, 전기통신사업법, 정보통신윤리위원회심의규정, 정보통신 윤리강령, 프로그램보호법 및 기타 관련 법령의 규정 및 서비스별 안내의 취지에 따라 적용할 수 있습니다."
            );

        string info_string = string.Format("개인정보 수집 이용 등에 대한 사전 동의 개인정보보호를 위한 이용자 동의사항(자세한 내용은 “개인정보취급방침”을 확인하시기 바랍니다."+ "\n\n 가. 개인정보의 수집·이용 목적  "+
            "\n\n① 홈페이지 회원 가입 및 관리 회원 가입의사 확인 \n\n② 회원제 서비스 제공에 따른 본인 식별/인증\n\n③ 회원자격 유지/관리\n\n④ 제한적 본인 확인제 시행에 따른 본인확인\n\n⑤ 서비스 부정이용 방지, 맞춤서비스 제공\n\n⑥ 만 14세 미만 아동의 개인정보 처리시 법정대리인의 동의여부 확인"+
            "\n\n 나. 개인정보의 처리  \n\n① 고충처리 민원인의 신원 확인 \n\n② 민원사항 확인, 사실조사를 위한 연락/통지\n\n③ 처리결과 통보  "
            );
        string apply_string = string.Format("① 한국전자제품자원순환공제조합은(이하 '공제조합'이라 한다.) 정보주체의 개인정보를 제1조(개인정보의 처리 목적)에서 명시한 범위 내에서만 처리하며, 정보주체의 동의, 법률의 특별한 규정 등 개인정보 보호법 제17조에 해당하는 경우에만 개인정보를 제3자에게 제공합니다."+
            "\n\n② 공제조합은 다음과 같이 개인정보를 제3자에게 제공하고 있습니다.\n\n - 개인정보를 제공받는 자 : (주)알씨엘 , 녹색소비자연대\n ※ ART 캠페인 참여자에 한하여 녹색소비자연대에 개인정보 제공" +
            "\n\n - 제공받는 자의 개인정보 이용목적 : 배출예약품목 무상 방문수거 \n\n - 제공하는 개인정보 항목 : 성명, 연락처, 주소\n\n - 제공받는 자의 보유․이용기간 : 3개월"
            );

        public AgreeForm()
        {
            InitializeComponent();
            Load += AgreeForm_Load;
        }

        public AgreeForm(MainForm mf)
        {
            InitializeComponent();
            Load += AgreeForm_Load;
            this.mf = mf;

        }

        private void AgreeForm_Load(object sender, EventArgs e)
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
            label_list= new ArrayList();
            label_list.Add(new lbSet(this,"first" ,"약관동의" , 200, 50, 50,50,15));
            label_list.Add(new lbSet(this, "second", "기본정보 입력", 200,50,300,50,15));
            label_list.Add(new lbSet(this, "third", "배출품목 입력", 200, 50, 550, 50,15));
            label_list.Add(new lbSet(this, "fourth", "예약완료", 200, 50, 800, 50,15));
            
            for(int i = 0; i < label_list.Count; i++)
            {
                Label label = ct.label((lbSet)label_list[i]);
                if (i == 0)
                {
                    label.BackColor = Color.Beige;
                }
                
                label.Font = new Font("Verdana", 15.5f, FontStyle.Bold);
                label.TextAlign = ContentAlignment.MiddleCenter;
                head.Controls.Add(label);
            }
            
            richtbSet rt1 = new richtbSet(this,"service_text",950,200,50,170);
            service_box = ct.richbox(rt1);
            service_box.ReadOnly=true;
            service_box.Text = service_string;
            Point(service_box, 0,11);
            Point(service_box, 2, 10);
            Point(service_box, 6, 10);
            head.Controls.Add(service_box);

            richtbSet rt2 = new richtbSet(this, "info_text", 450, 200, 50, 440);
            info_box = ct.richbox(rt2);
            service_box.ReadOnly = true;
            info_box.Text = info_string;
            Point(info_box, 2, 10);
            Point(info_box, 16, 10);
            head.Controls.Add(info_box);

            richtbSet rt3 = new richtbSet(this, "apply_text", 450, 200, 550, 440);
            apply_box = ct.richbox(rt3);
            apply_box.ReadOnly = true;
            apply_box.Text = apply_string;
            head.Controls.Add(apply_box);

            checkedSet ch1 = new checkedSet(this, "service", "▶ 서비스 약관(필수)", 950, 50, 50, 120);
            service_check = ct.checkbox(ch1);
            service_check.CheckAlign = ContentAlignment.MiddleRight;
            head.Controls.Add(service_check);

            checkedSet ch2 = new checkedSet(this, "info", "▶ 개인정보 이용 동의(필수)", 450, 50, 50, 390);
            info_check = ct.checkbox(ch2);
            info_check.CheckAlign = ContentAlignment.MiddleRight;
            head.Controls.Add(info_check);

            checkedSet ch3 = new checkedSet(this, "apply", "▶ 개인정보 제 3자 제공 동의(필수)", 450, 50, 550, 390);
            apply_check = ct.checkbox(ch3);
            apply_check.CheckAlign = ContentAlignment.MiddleRight;
            head.Controls.Add(apply_check);

            checkedSet ch4 = new checkedSet(this, "all", "전체동의", 100, 50, 490, 650);
            all_check = ct.checkbox(ch4);
            all_check.CheckedChanged+= check_all_click;
            head.Controls.Add(all_check);

            btnSet bt1 = new btnSet(this, "next", "다음단계", 100, 50, 960, 700, btn_next_click);
            next = ct.btn(bt1);
            head.Controls.Add(next);
            
        }
        private void check_all_click(object sender, EventArgs e)
        {
            if (all_check.Checked)
            {
                service_check.Checked = true;
                info_check.Checked = true;
                apply_check.Checked = true;
            }
            else
            {
                service_check.Checked = false;
                info_check.Checked = false;
                apply_check.Checked = false;
            }
        }
        
        private void btn_next_click(object sender, EventArgs e)
        {
            if (service_check.Checked&& info_check.Checked&& apply_check.Checked)
            {
                Information info = new Information();
                info.MdiParent = ParentForm; // 자식1을 자식2를 위한 
                info.WindowState = FormWindowState.Maximized;
                info.FormBorderStyle = FormBorderStyle.None;
                //this.Dispose();
                head.Controls.Add(info);
                info.Show();
            }
            else
            {
                MessageBox.Show("세가지 이용에 동의하여주십시오.");
            }
        }

        public void Point(RichTextBox rt, int line_number,int size)
        {
            string firstLine = rt.Lines[line_number];
            rt.Select(rt.GetFirstCharIndexFromLine(line_number), firstLine.Length);
            rt.SelectionFont = new Font("Tahoma", size, FontStyle.Bold);
            rt.Select(0, 0);
        }
    }
}


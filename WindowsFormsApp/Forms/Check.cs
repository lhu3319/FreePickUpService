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

namespace WindowsFormsApp.Forms
{
    public partial class Check : Form
    {
        Create ct = new Create();
        Panel head;
        Label top;
        MainForm mf;
        TextBox name, phone;
        ArrayList label_list;
        ListView lv;
        Webapi api;
        public Check()
        {
            InitializeComponent();
            Load += Check_Load;
        }
        public Check(MainForm mf)
        {
            InitializeComponent();
            Load += Check_Load;
            this.mf = mf;
        }
        private void Check_Load(object sender, EventArgs e)
        {
            api = new Webapi();
            View();
        }
        public void View()
        {
            pnSet pn1 = new pnSet(this, 1200, 900, 0, 0);
            head = ct.panel(pn1);
            Controls.Add(head);

            lbSet lb1 = new lbSet(this, "top", "폐가전제품 방문수거 배출예약 조회", 450, 40, 50, 10, 14);
            top = ct.label(lb1);
            top.Font = new Font("Verdana", 20.5f, FontStyle.Bold);
            head.Controls.Add(top);

            label_list = new ArrayList();
            
            label_list.Add(new lbSet(this, "second", "전화번호", 100, 50, 50, 200, 15));

            for (int i = 0; i < label_list.Count; i++)
            {
                Label label = ct.label((lbSet)label_list[i]);
                
                label.Font = new Font("Verdana", 15.5f, FontStyle.Bold);
                label.TextAlign = ContentAlignment.MiddleCenter;
                head.Controls.Add(label);
            }
            
            tbSet tb2 = new tbSet(this, "phone", 200, 30, 210, 210);
            
            
            phone = ct.txtbox(tb2);
            phone.Font = new Font("Verdana", 15.5f, FontStyle.Bold);
            head.Controls.Add(phone);

            btnSet bt1 = new btnSet(this, "add", "조회", 70, 30, 440, 210, Add_Click);
            Button bt = ct.btn(bt1);
            head.Controls.Add(bt);

            lvSet lv1 = new lvSet(this, "listview", 800, 400,50,400, null);
            lv = ct.listview(lv1);
            lv.FullRowSelect = true;
            lv.Columns.Add("번호", 50, HorizontalAlignment.Center);
            lv.Columns.Add("성명", 250, HorizontalAlignment.Center);
            lv.Columns.Add("제품명", 300, HorizontalAlignment.Center);
            lv.Columns.Add("수량", 50, HorizontalAlignment.Center);
            lv.Columns.Add("요청일", 150, HorizontalAlignment.Center);
            lv.Font = new Font("Verdana", 11.5f, FontStyle.Bold);
            head.Controls.Add(lv);

            Get_Data();
        }

        private void Get_Data()
        {
            if (mf.phone != "")
            {
                JObject jo = new JObject();
                jo.Add("_phone", mf.phone);
                Hashtable param = new Hashtable();
                param.Add("param", jo.ToString());
                param.Add("spName", "select_orderlist");
                // 휴대폰번호로 기존 사용자 체크
                string result = api.Post_Param(Program.URL + "/param_request_list", param);
                ArrayList resultArray = JsonConvert.DeserializeObject<ArrayList>(result);
                lv.Items.Clear();
                foreach (JObject row in resultArray)
                {
                    string[] arr = new string[5];
                    int index = 0;
                    foreach (JProperty jp in row.Properties())
                    {
                        
                        if(jp.Name.ToString() == "oNo")
                        {
                            arr[0] = jp.Value.ToString();
                        }
                        if (jp.Name.ToString() == "pName")
                        {
                            arr[1] = jp.Value.ToString();
                        }
                        if (jp.Name.ToString() == "NAME")
                        {
                            arr[2] = jp.Value.ToString();
                        }
                        if (jp.Name.ToString() == "cnt")
                        {
                            arr[3] = jp.Value.ToString();
                        }
                        if (jp.Name.ToString() == "oDate")
                        {
                            arr[4] = jp.Value.ToString();
                        }
                        index++;
                    }
                    lv.Items.Add(new ListViewItem(arr));
                }
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if(phone.Text != "")
            {
                mf.phone = phone.Text;
                Get_Data();
            }            
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp.Properties;

namespace WindowsFormsApp
{
    public partial class SearchAddrForm : Form
    {
        private Information inf;
        private Timer timer = null;
        private WebBrowser wb;

        public SearchAddrForm(Information inf)
        {
            this.inf = inf;
            InitializeComponent();
            Load += SearchAddrForm_Load;
        }

        private void SearchAddrForm_Load(object sender, EventArgs e)
        {
            wb = new WebBrowser();
            wb.Dock = DockStyle.Fill;
            wb.IsWebBrowserContextMenuEnabled = false;
            wb.Navigate(Program.URL+ "/daum.html?refresh=" + Guid.NewGuid().ToString());
            this.Controls.Add(wb);
            this.BackColor = Color.Black;
            this.Text = "주소검색";
            this.Icon = Resources.favicon;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            wb.DocumentCompleted += Wb_DocumentCompleted;
            timer = new Timer();
            timer.Interval = 100;
            timer.Tick += Timer_Tick;
        }

        private void Wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if(wb != null)
            {
                string extraAddr = wb.Document.GetElementById("extraAddr").GetAttribute("value");
                string zonecode = wb.Document.GetElementById("zonecode").GetAttribute("value");
                string addr = wb.Document.GetElementById("addr").GetAttribute("value");
                if (zonecode != "")
                {
                    timer.Stop();
                    inf.addr_box.Text = addr;
                    inf.road_box.Text = extraAddr;
                    this.Dispose();
                }
            }            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    class Create
    {
        //버튼
        public Button btn(btnSet bS)
        {
            Button btn = new Button();
            btn.DialogResult = DialogResult.OK;
            btn.Name = bS.Name;
            btn.Text = bS.Text;
            btn.Size = new Size(bS.SX,bS.SY);
            btn.Location = new Point(bS.PX,bS.PY);
            btn.BackColor = Color.White;
            btn.Cursor = Cursors.Hand;
            btn.Click += bS.eh_btn;
            if(bS.Form == null)
            {
                bS.Control.Controls.Add(btn);
            }
            else
            {
                bS.Form.Controls.Add(btn);
            }            
            return btn;
        }

        //라벨
        public Label label(lbSet lb)
        {
            Label label = new Label();
            label.Name = lb.Name;
            label.Text = lb.Text;
            label.Font = new Font("굴림",lb.FS);
            label.Size = new Size(lb.SX, lb.SY);
            label.Location = new Point(lb.PX, lb.PY);
            //label.BackColor = Color.Transparent;
            lb.Form.Controls.Add(label);
            return label;
        }

        //패널
        public Panel panel(pnSet pn)
        {
            Panel panel = new Panel();
            panel.Size = new Size(pn.SX,pn.SY);
            panel.Location = new Point(pn.PX,pn.PY);
            //pn.Form.Controls.Add(panel);
            return panel;
        }

        //텍스트박스
        public TextBox txtbox(tbSet ts)
        {
            TextBox txtbox = new TextBox();
            txtbox.Multiline = true;
            txtbox.Name = ts.Name;
            txtbox.Size = new Size(ts.SX,ts.SY);
            txtbox.Location = new Point(ts.PX,ts.PY);
            ts.Form.Controls.Add(txtbox);
            return txtbox;
        }
        //리치텍스트박스
        public RichTextBox richbox(richtbSet rt)
        {
            RichTextBox rtxtbox = new RichTextBox();
            rtxtbox.Multiline = true;
            rtxtbox.Name = rt.Name;
            rtxtbox.Size = new Size(rt.SX, rt.SY);
            rtxtbox.Location = new Point(rt.PX, rt.PY);
            rt.Form.Controls.Add(rtxtbox);
            return rtxtbox;
        }
        public CheckBox checkbox(checkedSet ch)
        {
            CheckBox chbox = new CheckBox();
            chbox.Name = ch.Name;
            chbox.Size = new Size(ch.SX, ch.SY);
            chbox.Location = new Point(ch.PX, ch.PY);
            ch.Form.Controls.Add(chbox);
            return chbox;
        }
        //리스트뷰
        public ListView listview(lvSet lv)
        {
            ListView listView = new ListView();
            listView.View = View.Details;
            listView.GridLines = true;
            listView.FullRowSelect = true;
            listView.Size = new Size(lv.SX, lv.SY);
            listView.Location = new Point(lv.PX,lv.PY);
            listView.MouseClick += lv.listview;
            lv.Form.Controls.Add(listView);
            return listView;
        }
        //픽쳐박스
        public PictureBox picture(pictureBoxSet pb)
        {
            PictureBox picture = new PictureBox();
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
            picture.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(pb.ImageRoute);
            picture.Size = new Size(pb.SX, pb.SY);
            picture.Location = new Point(pb.PX, pb.PY);
            pb.Form.Controls.Add(picture);
            return picture;
        }
        public DateTimePicker datepic(DateSet ds)
        {
            DateTimePicker datepic = new DateTimePicker();
            datepic.Name = ds.Name;
            datepic.Location = new Point(ds.PX, ds.PY);
            datepic.Size = new Size(ds.SX, ds.SY);
            datepic.CustomFormat = "yyyy-MM-dd dddd";
            datepic.Format = DateTimePickerFormat.Custom;
            ds.Form.Controls.Add(datepic);
            return datepic;
        }
        //콤보박스
        
        public ComboBox combobox(comboboxSet cbox)
        {
            ComboBox combobox = new ComboBox();
            combobox.Name = cbox.Name;
            combobox.Location = new Point(cbox.PX, cbox.PY);
            combobox.Size = new Size(cbox.SX, cbox.SY);
            combobox.DisplayMember = "1";
            combobox.ValueMember = "2";
            combobox.MouseClick += cbox.eh_cbox;
            return combobox;
        }
        
    }
}

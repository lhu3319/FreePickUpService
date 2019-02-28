using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    class Commons
    {
        public Panel getPanel(Hashtable hashtable, Control parentDomain)
        {
            Panel panel = new Panel();
            panel.Size = (Size)hashtable["size"];
            panel.Location = (Point)hashtable["point"];
            panel.BackColor = (Color)hashtable["color"];
            panel.Name = hashtable["name"].ToString();
            parentDomain.Controls.Add(panel);
            return panel;//
        }

        public Button getButton(Hashtable hashtable, Control parentDomain)
        {
            Button btn = new Button();
            btn.Size = (Size)hashtable["size"];
            btn.Location = (Point)hashtable["point"];
            btn.BackColor = (Color)hashtable["color"];
            btn.Name = hashtable["name"].ToString();
            btn.Text = hashtable["text"].ToString();
            btn.Click += (EventHandler)hashtable["click"];
            parentDomain.Controls.Add(btn);
            return btn;
        }

        public Label getLabel(Hashtable hashtable, Control parentDomain)
        {
            Label label = new Label();
            label.Location = (Point)hashtable["point"];
            label.BackColor = (Color)hashtable["color"];
            label.Name = hashtable["name"].ToString();
            label.Text = hashtable["text"].ToString();
            parentDomain.Controls.Add(label);
            return label;
        }
        public RichTextBox GetRichTextBox(Hashtable hashtable, Control parentDomain)
        {
            RichTextBox richtextBox = new RichTextBox();
            richtextBox.Name = hashtable["name"].ToString();
            richtextBox.Size = (Size)hashtable["size"];
            richtextBox.Font = new Font("Verdana", 10.5f, FontStyle.Italic);
            richtextBox.Location = (Point)hashtable["point"];
            parentDomain.Controls.Add(richtextBox);
            return richtextBox;
        }
        public TextBox GetTextBox(Hashtable hashtable, Control parentDomain)
        {
            TextBox textBox = new TextBox();
            textBox.Name = hashtable["name"].ToString();
            textBox.Width = Convert.ToInt32(hashtable["width"].ToString());
            textBox.Location = (Point)hashtable["point"];
            parentDomain.Controls.Add(textBox);
            return textBox;
        }
        public DateTimePicker GetDateTimePicker(Hashtable hashtable, Control parentDomain)
        {
            DateTimePicker dateTimePicker = new DateTimePicker();
            dateTimePicker.Name = hashtable["name"].ToString();
            dateTimePicker.Size = (Size)hashtable["size"];
            dateTimePicker.Location = (Point)hashtable["point"];
            dateTimePicker.CustomFormat = "yyyy-MM-dd dddd";
            parentDomain.Controls.Add(dateTimePicker);
            return dateTimePicker;
        }
        public ComboBox getComboBox(Hashtable hashtable, Control parentDomain)
        {
            ComboBox comboBox = new ComboBox();
            comboBox.Width = Convert.ToInt32(hashtable["width"].ToString());
            comboBox.DropDownWidth = Convert.ToInt32(hashtable["width"].ToString());
            comboBox.Location = (Point)hashtable["point"];
            comboBox.BackColor = (Color)hashtable["color"];
            comboBox.Name = hashtable["name"].ToString();
            comboBox.DisplayMember = "value";
            comboBox.ValueMember = "Key";
            parentDomain.Controls.Add(comboBox);
            return comboBox;
        }

        public ListView GetListView(Hashtable hashtable, Control parentDomain)
        {
            ListView listView = new ListView();
            listView.Dock = DockStyle.Fill;
            listView.View = View.Details;
            listView.GridLines = true;
            listView.FullRowSelect = true;
            listView.BackColor = (Color)hashtable["color"];
            listView.Name = hashtable["name"].ToString();
            listView.MouseClick += (MouseEventHandler)hashtable["click"];
            parentDomain.Controls.Add(listView);
            return listView;
        }
    }
}

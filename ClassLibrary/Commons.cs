using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassLibrary
{
    class Commons
    {
        public Panel getPanel(Hashtable hashtable)
        {
            Panel panel = new Panel();
            panel.Size = (Size)hashtable["size"];
            panel.Location = (Point)hashtable["point"];
            panel.BackColor = (Color)hashtable["color"];
            panel.Name = hashtable["name"].ToString();
            return panel;//
        }

        public Button getButton(Hashtable hashtable)
        {
            Button btn = new Button();
            btn.Size = (Size)hashtable["size"];
            btn.Location = (Point)hashtable["point"];
            btn.BackColor = (Color)hashtable["color"];
            btn.Name = hashtable["name"].ToString();
            btn.Text = hashtable["text"].ToString();
            btn.Click += (EventHandler)hashtable["click"];
            return btn;
        }

        public Label getLabel(Hashtable hashtable)
        {
            Label label = new Label();
            label.Location = (Point)hashtable["point"];
            label.BackColor = (Color)hashtable["color"];
            label.Name = hashtable["name"].ToString();
            label.Text = hashtable["text"].ToString();
            return label;
        }
        public RichTextBox GetRichTextBox(Hashtable hashtable)
        {
            RichTextBox richtextBox = new RichTextBox();
            richtextBox.Name = hashtable["name"].ToString();
            richtextBox.Size = (Size)hashtable["size"];
            richtextBox.Font = new Font("Verdana", 10.5f, FontStyle.Italic);
            richtextBox.Location = (Point)hashtable["point"];
            return richtextBox;
        }
        public TextBox GetTextBox(Hashtable hashtable)
        {
            TextBox textBox = new TextBox();
            textBox.Name = hashtable["name"].ToString();
            textBox.Width = Convert.ToInt32(hashtable["width"].ToString());
            textBox.Location = (Point)hashtable["point"];
            return textBox;
        }
        public DateTimePicker GetDateTimePicker(Hashtable hashtable)
        {
            DateTimePicker dateTimePicker = new DateTimePicker();
            dateTimePicker.Name = hashtable["name"].ToString();
            dateTimePicker.Size = (Size)hashtable["size"];
            dateTimePicker.Location = (Point)hashtable["point"];
            dateTimePicker.CustomFormat = "yyyy-MM-dd dddd";
            return dateTimePicker;
        }
        public ComboBox getComboBox(Hashtable hashtable)
        {
            ComboBox comboBox = new ComboBox();
            comboBox.Width = Convert.ToInt32(hashtable["width"].ToString());
            comboBox.DropDownWidth = Convert.ToInt32(hashtable["width"].ToString());
            comboBox.Location = (Point)hashtable["point"];
            comboBox.BackColor = (Color)hashtable["color"];
            comboBox.Name = hashtable["name"].ToString();
            comboBox.DisplayMember = "value";
            comboBox.ValueMember = "Key";
            return comboBox;
        }

        public ListView GetListView(Hashtable hashtable)
        {
            ListView listView = new ListView();
            listView.Dock = DockStyle.Fill;
            listView.View = View.Details;
            listView.GridLines = true;
            listView.FullRowSelect = true;
            listView.BackColor = (Color)hashtable["color"];
            listView.Name = hashtable["name"].ToString();
            listView.MouseClick += (MouseEventHandler)hashtable["click"];
            return listView;
        }
    }
}

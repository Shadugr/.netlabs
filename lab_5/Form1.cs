using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;

namespace lab_5
{
    public partial class Form1 : Form
    {
        public List<Person> contacts = new List<Person>();
        public bool n;
        public bool sn;
        public bool mn;
        public bool p;
        public bool s;
        public bool a;
        public bool b;

        public void write_xml()
        { 
            XmlWriter w = XmlWriter.Create("contacts.xml");
            w.WriteStartDocument();
            w.WriteStartElement("contacts");
            foreach (Person p in contacts)
            {
                w.WriteStartElement("contact");
                w.WriteElementString("name", p.name);
                w.WriteElementString("second_name", p.sec_name);
                w.WriteElementString("middle_name", p.mid_name);
                w.WriteElementString("phone", p.phone);
                w.WriteElementString("skype", p.skype);
                w.WriteElementString("adress", p.adress);
                w.WriteElementString("birthday", p.birthday);
                w.WriteEndElement();
            }
            w.WriteEndElement();
            w.WriteEndDocument();
            w.Flush();
        }
        public void read_xml()
        {
            XmlDocument r = new XmlDocument();
            string n = "";
            string sn = "";
            string mn = "";
            string p = "";
            string s = "";
            string a = "";
            string b = "";

            r.Load("contacts.xml");
            foreach (XmlNode node in r.GetElementsByTagName("contact"))
            {
                foreach (XmlNode ch in node.ChildNodes)
                {
                    switch (ch.Name)
                    {
                        case "name":
                            n = ch.InnerText;
                            break;
                        case "second_name":
                            sn = ch.InnerText;
                            break;
                        case "middle_name":
                            mn = ch.InnerText;
                            break;
                        case "phone":
                            p = ch.InnerText;
                            break;
                        case "adress":
                            a = ch.InnerText;
                            break;
                        case "skype":
                            s = ch.InnerText;
                            break;
                        case "birthday":
                            b = ch.InnerText;
                            break;
                    }
                }
                contacts.Add(new Person(n, sn, mn, p, s, a, b));
            }
            show_contats();
        }
        public void show_contats()
        {
            listView1.Items.Clear();
            ListViewItem li;
            foreach (Person pr in contacts)
            {
                li = listView1.Items.Add(pr.name);
                li = listView1.Items.Add(pr.sec_name);
                li = listView1.Items.Add(pr.mid_name);
                li = listView1.Items.Add(pr.phone);
                li = listView1.Items.Add(pr.skype);
                li = listView1.Items.Add(pr.adress);
                li = listView1.Items.Add(pr.birthday);          
                li.SubItems.AddRange(pr.get_columns(false, sn, mn, p, s, a, b).ToArray());
                li.Tag = pr;
            }
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        public void recreate_columns()
        {
            n = nameToolStripMenuItem.Checked;
            sn = secondNameToolStripMenuItem.Checked;
            mn = middleNameToolStripMenuItem.Checked;
            p = phoneToolStripMenuItem.Checked;
            s = skypeToolStripMenuItem.Checked;
            a = adressToolStripMenuItem.Checked;
            b = birthdayToolStripMenuItem.Checked;
            listView1.Columns.Clear();
            if (n) listView1.Columns.Add("Name");
            if (sn) listView1.Columns.Add("Second Name");
            if (mn) listView1.Columns.Add("Middle Name");
            if (p) listView1.Columns.Add("Phone");
            if (s) listView1.Columns.Add("Skype");
            if (a) listView1.Columns.Add("Adress");
            if (b) listView1.Columns.Add("Birthday");
            show_contats();
        }
        public Form1()
        {
            InitializeComponent();
            recreate_columns();
        }
        private void nameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            recreate_columns();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            write_xml();
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            read_xml();
        }
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Person pr;
            foreach (int ind in listView1.SelectedIndices)
            {
                pr = (Person)listView1.Items[ind].Tag;
            }
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(this);
            f2.ShowDialog();
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (int ind in listView1.SelectedIndices)
                contacts.RemoveAt(ind);
            show_contats();
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int sel = -1;
            foreach (int ind in listView1.SelectedIndices)
                sel = ind;
            if (sel != -1)
            {
                Form2 f2 = new Form2(this, contacts[sel].name, contacts[sel].sec_name, contacts[sel].mid_name, contacts[sel].phone, contacts[sel].skype, contacts[sel].adress, contacts[sel].birthday, sel);
                f2.ShowDialog();

            }
        }
    }
    public class Person
    {
        public string name;
        public string sec_name;
        public string mid_name;
        public string phone;
        public string skype;
        public string adress;
        public string birthday;
        public Person(string n, string sn, string mn, string p, string s, string a, string b)
        {
            name = n;
            sec_name = sn;
            mid_name = mn;
            phone = p;
            skype = s;
            adress = a;
            birthday = b;
        }
        public List<string> get_columns(bool n, bool sn, bool mn, bool p, bool s, bool a, bool b)
        {

            var t = new List<string>();
            if (n) t.Add(name);
            if (sn) t.Add(sec_name);
            if (mn) t.Add(mid_name);
            if (p) t.Add(phone);
            if (s) t.Add(skype);
            if (a) t.Add(adress);
            if (b) t.Add(birthday);
            return t;
        }
    }
}

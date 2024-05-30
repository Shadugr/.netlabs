using System;
using System.Windows.Forms;

namespace lab_5
{
    public partial class Form2 : Form
    {
        public int contact_index;
        public Form1 f;

        public Form2(Form1 f1, string n = "", string sn = "", string mn = "", string p = "", string s = "", string a = "", string b = "", int cn = -1)
        {
            InitializeComponent();
            textBox1.Text = n;
            textBox2.Text = sn;
            textBox3.Text = mn;
            textBox4.Text = p;
            textBox5.Text = s;
            textBox6.Text = a;
            textBox7.Text = b;
            contact_index = cn;
            f = f1;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (contact_index == -1)
            {
                f.contacts.Add(new Person(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text));
                f.show_contats();
            }
            else
            {

                Person p = new Person(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text);
                f.contacts[contact_index] = p;
                f.show_contats();

            }
            Close();
        }
    }
}
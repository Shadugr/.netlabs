using System;
using System.Windows.Forms;

namespace lab_3
{
    public partial class Form3 : Form
    {
        public int ind = 0;
        public RichTextBox rt;
        public Form3(RichTextBox r)
        {
            InitializeComponent();
            rt = r;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            rt.HideSelection = true;
            string s = textBox1.Text;
            string rs = textBox2.Text;
            StringComparison sc;
            if (checkBox1.Checked)
            {
                sc = StringComparison.CurrentCultureIgnoreCase;
            }
            else
            {
                sc = StringComparison.CurrentCulture;
            }
            while (ind != -1)
            {
                ind = rt.Text.IndexOf(s, ind, sc);
                if (ind != -1)
                {
                    rt.SelectionStart = ind;
                    rt.SelectionLength = s.Length;
                    rt.SelectedText = rs;
                    ind += s.Length;
                }
            }
            MessageBox.Show("Done!");
            Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            rt.HideSelection = false;
            string s = textBox1.Text;
            string rs = textBox2.Text;
            StringComparison sc;
            if (checkBox1.Checked)
            {
                sc = StringComparison.CurrentCultureIgnoreCase;
            }
            else
            {
                sc = StringComparison.CurrentCulture;
            }
            while (ind != -1)
            {
                ind = rt.Text.IndexOf(s, ind, sc);
                if (ind != -1)
                {
                    rt.SelectionStart = ind;
                    rt.SelectionLength = s.Length;
                    if (MessageBox.Show("Replace this?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        rt.SelectedText = rs;
                    ind += s.Length;
                }
            }
            MessageBox.Show("Done!");
            Close();
        }
    }
}

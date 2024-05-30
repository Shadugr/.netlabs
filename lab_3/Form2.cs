using System;
using System.Windows.Forms;

namespace lab_3
{
    public partial class Form2 : Form
    {
        public RichTextBox rt;
        int ind = 0;
        public Form2(RichTextBox r)
        {
            InitializeComponent();
            rt = r;
            rt.HideSelection = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text;
            if (checkBox1.Checked)
            {
                ind = rt.Text.IndexOf(s, ind, StringComparison.CurrentCultureIgnoreCase);
                if (ind != -1)
                {
                    rt.SelectionStart = ind;
                    rt.SelectionLength = s.Length;
                    ind +=
                        s.Length;
                }
                else
                {
                    MessageBox.Show("Noting finded!");
                }
            }
            else
            {
                ind = rt.Text.IndexOf(s, ind, StringComparison.CurrentCulture);
                if (ind != -1)
                {
                    rt.SelectionStart = ind;
                    rt.SelectionLength = s.Length;
                    ind +=
                        s.Length;
                }
                else
                {
                    MessageBox.Show("Noting finded!");
                }
            }
        }
    }
}

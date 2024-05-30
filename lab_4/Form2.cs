using System;
using System.Windows.Forms;

namespace lab_4
{
    public partial class Form2 : Form

    {
        public Form1 f1;
        public Form2(int c, int r, Form1 f)
        {
            InitializeComponent();
            textBox1.Text = c.ToString();
            textBox2.Text = r.ToString();
            f1 = f;
        }
        private void button2_Click(object sender, EventArgs e)

        {
            Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            f1.x = int.Parse(textBox1.Text);
            f1.y = int.Parse(textBox2.Text);
            f1.initGrid(f1.x, f1.y);
            Close();
        }
    }
}

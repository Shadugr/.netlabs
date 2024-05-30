using System;
using System.Windows.Forms;

namespace lab_4
{
    public partial class Form3 : Form
    {
        public Form1 f1;
        public Form3(Form1 f)
        {
            InitializeComponent();
            f1 = f;
        }
        private void button1_Click(object sender, EventArgs e)  //кнопка знайти
        {
            f1.gridFind(textBox1.Text, checkBox1.Checked);
            Close();
        }
        private void button2_Click(object sender, EventArgs e)  //кнопка відмінити
        {
            Close();
        }
    }
}

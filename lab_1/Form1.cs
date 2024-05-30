using System;
using System.Windows.Forms;

namespace lab_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2("about.png", "Сама цікава і функціональна програма! Купіть мене!");
            f2.ShowDialog(); 
        }
        private void messageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2("error.png", "Трапилася помилка! Все для Вас і безкоштовно!");
            f2.ShowDialog();
        }
    }
}

using System;
using System.Windows.Forms;

namespace lab_1
{
    internal static class Program
    {

    [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
    public partial class Form2 : Form
    {
        public Form2(string fn, string tex) 
        {
            InitializeComponent();
            textBox1.Text = tex;
            pictureBox1.Load(fn);
            Controls.Add(pictureBox1);
        }
    }
}


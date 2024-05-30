using System;
using System.Windows.Forms;

namespace lab_4
{
    public partial class Form4 : Form

    {
        public Form1 f1;
        public DataGridView dg;
        public int c = 0;
        public int r = 0;

        public Form4(Form1 f, DataGridView d)
        {
            InitializeComponent();
            f1 = f;
            dg = d;
        }
        private void button2_Click(object sender, EventArgs e)  //кнопка відмінити
        {
            Close();
        }
        private void button1_Click(object sender, EventArgs e)

        {
            f1.gridFind(textBox1.Text, checkBox1.Checked);
            int replacedCount = 0;
            foreach (DataGridViewCell cl in dg.SelectedCells)
            {
                cl.Value = textBox2.Text;
                replacedCount++;
            }
            MessageBox.Show($"Заміна завершена, замінено {replacedCount} клітинок.", "Замінено");
            Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            f1.gridFind(textBox1.Text, checkBox1.Checked);
            for (int i = dg.SelectedCells.Count - 1; i >= 0; i--)
            {
                if (MessageBox.Show("Replace?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    dg.SelectedCells[i].Value = textBox2.Text;
                }
            }
            Close();
        }
    }
}

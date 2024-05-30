using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace lab_4
{
    public partial class Form1 : Form

    {
        public int x = 10;
        public int y = 10;

        private bool isGridModified = false;
        private string currentFileName = null;

        public void initGrid(int c, int r)
        { 
            x = c;
            y = r;

            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            for (int i = 0; i < x; i++)

            {
                dataGridView1.Columns.Add(i.ToString(), i.ToString());
            }

            for (int i = 0; i < y; i++)
            {
                dataGridView1.Rows.Add();
            }
        }
        public void saveGrid(string fn)
        {
            FileInfo f = new FileInfo(fn);
            StreamWriter w = new StreamWriter(f.Create());
            string l;

            for (int rc = 0; rc < dataGridView1.Rows.Count - 1; rc++)
            {
                l = "";
                for (int cc = 0; cc <= dataGridView1.Columns.Count - 1; cc++)
                {
                    l += dataGridView1.Rows[rc].Cells[cc].Value + "|";
                }
                l.Substring(0, l.Length - 1);
                w.WriteLine(l);
            }
            w.Close();
        }


        public void openGrid(string fn)
        {
            FileInfo f = new FileInfo(fn);
            StreamReader r = new StreamReader(f.OpenRead());
            string l;

            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            while (!r.EndOfStream)
            {

                l = r.ReadLine();
                String[] cells = l.Split('|');

                if (dataGridView1.Columns.Count < cells.Length - 1)
                    for (int i = 0; i < cells.Length - 1;
                         i++)
                        dataGridView1.Columns.Add(i.ToString(), i.ToString());
                dataGridView1.Rows.Add(cells);
            }
        }
        public void gridFind(string txt, bool c)
        {
            string ct;

            foreach (DataGridViewCell cl in dataGridView1.SelectedCells)
            {

                cl.Selected = false;
            }
            for (int rc = 0; rc <= dataGridView1.Rows.Count - 1; rc++)
                for (int cc = 0; cc <= dataGridView1.Columns.Count - 1; cc++)
                {
                    if (!c)

                    {
                        ct = dataGridView1.Rows[rc].Cells[cc].Value + "";

                        if (txt.ToUpper() == ct.ToUpper())

                            dataGridView1.Rows[rc].Cells[cc].Selected = true;
                    }
                    else

                    {
                        if (txt == dataGridView1.Rows[rc].Cells[cc].Value + "")

                            dataGridView1.Rows[rc].Cells[cc].Selected = true;
                    }
                }
        }
        public Form1()
        {
            InitializeComponent();
            initGrid(x, y);
            FormClosing += new FormClosingEventHandler(Form1_FormClosing);
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(x, y, this);
            f2.ShowDialog();
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentFileName))
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Excel Files|*.xls;*.xlsx|All Files|*.*";
                saveFileDialog1.Title = "Зберегти файл таблиці";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    currentFileName = saveFileDialog1.FileName;
                }
            }
            if (!string.IsNullOrEmpty(currentFileName))
            {
                saveGrid(currentFileName);
            }
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Excel Files|*.xls;*.xlsx|All Files|*.*";
            saveFileDialog1.Title = "Зберегти файл таблиці";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                saveGrid(saveFileDialog1.FileName);
            }
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Excel Files|*.xls;*.xlsx|All Files|*.*";
            openFileDialog1.Title = "Відкрити файл таблиці";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                openGrid(openFileDialog1.FileName);
        }
        private void addColumnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewColumn col = new DataGridViewColumn(new DataGridViewTextBoxCell()) { Name = "col", HeaderText = "col" };
            dataGridView1.Columns.Insert(dataGridView1.CurrentCell.ColumnIndex, col);
        }
        private void addRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Insert(dataGridView1.CurrentCell.RowIndex, new String[] { });
        }
        private void removeColumnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.RemoveAt(dataGridView1.CurrentCell.ColumnIndex);
        }
        private void removeRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.RemoveAt(dataGridView1.CurrentCell.RowIndex);
        }
        private void boldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentCell.Style.Font.Bold)
                    dataGridView1.CurrentCell.Style.Font =
                        new Font(dataGridView1.CurrentCell.Style.Font, dataGridView1.CurrentCell.Style.Font.Style & ~FontStyle.Bold);
                else
                    dataGridView1.CurrentCell.Style.Font =
                        new Font(dataGridView1.CurrentCell.Style.Font, dataGridView1.CurrentCell.Style.Font.Style | FontStyle.Bold);
            }
            catch
            {
                dataGridView1.CurrentCell.Style.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Bold);
            }
        }
        private void italicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentCell.Style.Font.Italic)
                    dataGridView1.CurrentCell.Style.Font = new Font(dataGridView1.CurrentCell.Style.Font, dataGridView1.CurrentCell.Style.Font.Style & ~FontStyle.Italic);
                else
                    dataGridView1.CurrentCell.Style.Font = new Font(dataGridView1.CurrentCell.Style.Font, dataGridView1.CurrentCell.Style.Font.Style | FontStyle.Italic);
            }
            catch
            {
                dataGridView1.CurrentCell.Style.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Italic);
            }
        }
        private void underlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentCell.Style.Font.Italic)
                    dataGridView1.CurrentCell.Style.Font = new Font(dataGridView1.CurrentCell.Style.Font, dataGridView1.CurrentCell.Style.Font.Style & ~FontStyle.Underline);
                else
                    dataGridView1.CurrentCell.Style.Font = new Font(dataGridView1.CurrentCell.Style.Font, dataGridView1.CurrentCell.Style.Font.Style | FontStyle.Underline);
            }
            catch
            {
                dataGridView1.CurrentCell.Style.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Underline);
            }
        }
        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog1 = new FontDialog();
            if (fontDialog1.ShowDialog() == DialogResult.OK)
                dataGridView1.CurrentCell.Style.Font = fontDialog1.Font;
        }
        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3(this);
            f3.ShowDialog();
        }
        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4(this, dataGridView1);
            f4.ShowDialog();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ранок добрий");
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isGridModified)
            {
                var result = MessageBox.Show("Зберегти зміни перед закриттям?", "Зберегти", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "Excel Files|*.xls;*.xlsx|All Files|*.*";
                    saveFileDialog1.Title = "Зберегти файл таблиці";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        saveGrid(saveFileDialog1.FileName);
                    }
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void renameColumnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell != null)
            {
                string input = Microsoft.VisualBasic.Interaction.InputBox("Введіть нову назву стовпця:", "Змінити назву стовпця", dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex].HeaderText);
                if (!string.IsNullOrEmpty(input))
                {
                    dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex].HeaderText = input;
                }
            }
        }
    }
}

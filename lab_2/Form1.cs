using System;
using System.Drawing;
using System.Windows.Forms;

namespace lab_2
{
    public partial class Form1 : Form
    {
        int[,] f = new int[51, 51];
        Button[,] b = new Button[51, 51];
        Label[,] l = new Label[51, 51];
        int fsize = 20;
        int status = 0;

        public Form1()
        {
            InitializeComponent();
            f_to_zero();
            b_l_create();
        }
        public void f_to_zero()
        {
            int x, y;
            for (x = 0; x <= fsize; x++)
                for (y = 0; y <= fsize; y++)
                    f[x, y] = 0;
        }
        public void b_l_create()
        {
            int x, y, h;
            h = menuStrip1.Height;
            for (x = 0; x <= fsize; x++)
                for (y = 0; y <= fsize; y++)
                {
                    b[x, y] = new Button();
                    l[x, y] = new Label();
                    b[x, y].SetBounds(x * 20, y * 20 + h, 20, 20);
                    l[x, y].SetBounds(x * 20, y * 20 + h, 20, 20);
                    l[x, y].Visible = false;
                    l[x, y].Text = "";
                    b[x, y].Tag = l[x, y];
                    b[x, y].Click += but_clck;
                    Controls.Add(b[x, y]);
                    Controls.Add(l[x, y]);
                }
        }
        private void but_clck(object sender, EventArgs e)
        {
            Button o = ((Button)sender);
            Label ol = ((Label)o.Tag);
            o.Visible = false;
            ol.Visible = true;
            if (ol.Text == "B")
            {
                MessageBox.Show("Looooser!");
                b_hide();
                l_show(fsize);
                ol.Font = new Font(ol.Font, FontStyle.Bold);
                status = 2;
            }
        }
        public void b_hide()
        {
            int x, y;
            for (x = 0; x <= fsize; x++)
                for (y = 0; y <= fsize; y++)
                    b[x, y].Visible = false;
        }

        public void l_show(int s)
        {
            int x, y;
            for (x = 0; x <= s; x++)
                for (y = 0; y <= s; y++)
                    l[x, y].Visible = true;
        }
        public void l_hide()
        {
            int x, y;
            for (x = 0; x <= fsize; x++)
                for (y = 0; y <= fsize; y++)
                    l[x, y].Visible = false;
        }
        public void b_show(int s)
        {
            int x, y;
            for (x = 0; x <= s; x++)
                for (y = 0; y <= s; y++)
                    b[x, y].Visible = true;
        }
        public void generate_bombs(int bombval, int sizeval)
        {
            Random rand = new Random();
            int x, y, k;
            for (k = 1; k <= bombval; k++)
            {
                do
                {
                    x = rand.Next(sizeval);
                    y = rand.Next(sizeval);
                } while (f[x, y] == 255);
                f[x, y] = 255;
            }
            int z;
            for (x = 0; x <= sizeval; x++)
                for (y = 0; y <= sizeval; y++)
                    if (f[x, y] != 255)
                    {
                        z = 0;
                        if (x > 0 && y > 0 && f[x - 1, y - 1] == 255) z++;
                        if (x > 0 && f[x - 1, y] == 255) z++;
                        if (x > 0 && y < sizeval && f[x - 1, y + 1] == 255) z++;
                        if (y > 0 && f[x, y - 1] == 255) z++;
                        if (y < sizeval && f[x, y + 1] == 255) z++;
                        if (x < sizeval && y > 0 && f[x + 1, y - 1] == 255) z++;
                        if (x < sizeval && f[x + 1, y] == 255) z++;
                        if (x < sizeval && y < sizeval && f[x + 1, y + 1] == 255) z++;
                        f[x, y] = z;
                    }

            for (x = 0; x <= sizeval; x++)
                for (y = 0; y <= sizeval; y++)
                {
                    if (f[x, y] == 255) l[x, y].Text = "B";
                    if (f[x, y] > 0) l[x, y].Text = f[x, y].ToString();
                }
        }

        private void розпочатиГруToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int bmv = int.Parse(toolStripMenuItem2.Text);
            int fsv = int.Parse(toolStripTextBox1.Text);
            fsize = fsv;

            fsize = fsv;

            if (status == 0)
            {
                generate_bombs(bmv, fsv);
                b_show(fsv);
                status = 1;
            }
            else
            {
                if (status == 1)
                {
                    MessageBox.Show("You need to lose first!");
                }
                if (status == 2)
                {
                    f_to_zero();
                    l_hide();
                    generate_bombs(bmv, fsv);
                    b_show(fsv);
                    status = 1;
                }
            }
        }
    }
}
namespace lab_2
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem граToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem розпочатиГруToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem розмірПоляToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripMenuItem кількістьКлітинокToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripMenuItem2;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.граToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.розпочатиГруToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.розмірПоляToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.кількістьКлітинокToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripTextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.граToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(423, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // граToolStripMenuItem
            // 
            this.граToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.розпочатиГруToolStripMenuItem,
            this.розмірПоляToolStripMenuItem,
            this.кількістьКлітинокToolStripMenuItem});
            this.граToolStripMenuItem.Name = "граToolStripMenuItem";
            this.граToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.граToolStripMenuItem.Text = "Гра";
            // 
            // розпочатиГруToolStripMenuItem
            // 
            this.розпочатиГруToolStripMenuItem.Name = "розпочатиГруToolStripMenuItem";
            this.розпочатиГруToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.розпочатиГруToolStripMenuItem.Text = "Розпочати гру";
            this.розпочатиГруToolStripMenuItem.Click += new System.EventHandler(this.розпочатиГруToolStripMenuItem_Click);
            // 
            // розмірПоляToolStripMenuItem
            // 
            this.розмірПоляToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1});
            this.розмірПоляToolStripMenuItem.Name = "розмірПоляToolStripMenuItem";
            this.розмірПоляToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.розмірПоляToolStripMenuItem.Text = "Розмір поля";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox1.Text = "20";
            // 
            // кількістьКлітинокToolStripMenuItem
            // 
            this.кількістьКлітинокToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2});
            this.кількістьКлітинокToolStripMenuItem.Name = "кількістьКлітинокToolStripMenuItem";
            this.кількістьКлітинокToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.кількістьКлітинокToolStripMenuItem.Text = "Кількість мін";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(100, 23);
            this.toolStripMenuItem2.Text = "30";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 448);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
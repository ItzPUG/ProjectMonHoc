namespace ProjectQLHS
{
    partial class frmHeThong
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHeThong));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thoátỨngDụngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quanLyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hocSinhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(139)))), ((int)(((byte)(1)))));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hệThốngToolStripMenuItem,
            this.thoátỨngDụngToolStripMenuItem,
            this.quanLyToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(917, 34);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // hệThốngToolStripMenuItem
            // 
            this.hệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.đăngXuấtToolStripMenuItem});
            this.hệThốngToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hệThốngToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.hệThốngToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("hệThốngToolStripMenuItem.Image")));
            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(130, 30);
            this.hệThốngToolStripMenuItem.Text = "Hệ thống";
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(193, 30);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // thoátỨngDụngToolStripMenuItem
            // 
            this.thoátỨngDụngToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.thoátỨngDụngToolStripMenuItem.BackColor = System.Drawing.Color.ForestGreen;
            this.thoátỨngDụngToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.thoátỨngDụngToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("thoátỨngDụngToolStripMenuItem.Image")));
            this.thoátỨngDụngToolStripMenuItem.Name = "thoátỨngDụngToolStripMenuItem";
            this.thoátỨngDụngToolStripMenuItem.Size = new System.Drawing.Size(81, 30);
            this.thoátỨngDụngToolStripMenuItem.Text = "Thoát";
            this.thoátỨngDụngToolStripMenuItem.Click += new System.EventHandler(this.thoátỨngDụngToolStripMenuItem_Click);
            // 
            // quanLyToolStripMenuItem
            // 
            this.quanLyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hocSinhToolStripMenuItem,
            this.lopToolStripMenuItem});
            this.quanLyToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quanLyToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.quanLyToolStripMenuItem.Name = "quanLyToolStripMenuItem";
            this.quanLyToolStripMenuItem.Size = new System.Drawing.Size(108, 30);
            this.quanLyToolStripMenuItem.Text = "Quản Lý";
            // 
            // hocSinhToolStripMenuItem
            // 
            this.hocSinhToolStripMenuItem.Name = "hocSinhToolStripMenuItem";
            this.hocSinhToolStripMenuItem.Size = new System.Drawing.Size(184, 30);
            this.hocSinhToolStripMenuItem.Text = "Hoc Sinh";
            this.hocSinhToolStripMenuItem.Click += new System.EventHandler(this.hocSinhToolStripMenuItem_Click);
            // 
            // lopToolStripMenuItem
            // 
            this.lopToolStripMenuItem.Name = "lopToolStripMenuItem";
            this.lopToolStripMenuItem.Size = new System.Drawing.Size(184, 30);
            this.lopToolStripMenuItem.Text = "Lop";
            this.lopToolStripMenuItem.Click += new System.EventHandler(this.lopToolStripMenuItem_Click);
            // 
            // frmHeThong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(917, 466);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmHeThong";
            this.Text = "Hệ thống quản lý";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        //private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem25;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoátỨngDụngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quanLyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hocSinhToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lopToolStripMenuItem;
    }
}
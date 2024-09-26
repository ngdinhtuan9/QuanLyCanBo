namespace QuanLyNhanSu.Main
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBussiness = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReport = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuLists = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.mnuLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRegister = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSystem,
            this.mnuBussiness,
            this.mnuReport,
            this.MnuLists});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(961, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuSystem
            // 
            this.mnuSystem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLogin,
            this.mnuRegister});
            this.mnuSystem.Enabled = false;
            this.mnuSystem.Name = "mnuSystem";
            this.mnuSystem.Size = new System.Drawing.Size(69, 20);
            this.mnuSystem.Text = "Hệ thống";
            // 
            // mnuBussiness
            // 
            this.mnuBussiness.Enabled = false;
            this.mnuBussiness.Name = "mnuBussiness";
            this.mnuBussiness.Size = new System.Drawing.Size(74, 20);
            this.mnuBussiness.Text = "Nghiệp vụ";
            // 
            // mnuReport
            // 
            this.mnuReport.Enabled = false;
            this.mnuReport.Name = "mnuReport";
            this.mnuReport.Size = new System.Drawing.Size(61, 20);
            this.mnuReport.Text = "Báo cáo";
            // 
            // MnuLists
            // 
            this.MnuLists.Name = "MnuLists";
            this.MnuLists.Size = new System.Drawing.Size(74, 20);
            this.MnuLists.Text = "Danh mục";
            this.MnuLists.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(961, 34);
            this.panel1.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(4, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 31);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // mnuLogin
            // 
            this.mnuLogin.Name = "mnuLogin";
            this.mnuLogin.Size = new System.Drawing.Size(180, 22);
            this.mnuLogin.Text = "Đăng nhập";
            this.mnuLogin.Click += new System.EventHandler(this.mnuLogin_Click);
            // 
            // mnuRegister
            // 
            this.mnuRegister.Name = "mnuRegister";
            this.mnuRegister.Size = new System.Drawing.Size(180, 22);
            this.mnuRegister.Text = "Đăng ký tài khoản";
            this.mnuRegister.Click += new System.EventHandler(this.mnuRegister_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 527);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuSystem;
        private System.Windows.Forms.ToolStripMenuItem mnuBussiness;
        private System.Windows.Forms.ToolStripMenuItem mnuReport;
        private System.Windows.Forms.ToolStripMenuItem MnuLists;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem mnuLogin;
        private System.Windows.Forms.ToolStripMenuItem mnuRegister;
    }
}
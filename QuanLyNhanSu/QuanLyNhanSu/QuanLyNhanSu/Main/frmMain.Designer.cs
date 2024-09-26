namespace QuanLyNhanSu.Main
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRegister = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBussiness = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReport = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuLists = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUnits = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDepartment = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLevel = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnPanelMain = new System.Windows.Forms.Panel();
            this.mnuSchool = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPosition = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAcademicLevel = new System.Windows.Forms.ToolStripMenuItem();
            this.trìnhĐộLLCTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuResponsible = new System.Windows.Forms.ToolStripMenuItem();
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
            this.mnuSystem.Image = ((System.Drawing.Image)(resources.GetObject("mnuSystem.Image")));
            this.mnuSystem.Name = "mnuSystem";
            this.mnuSystem.Size = new System.Drawing.Size(85, 20);
            this.mnuSystem.Text = "Hệ thống";
            // 
            // mnuLogin
            // 
            this.mnuLogin.Image = ((System.Drawing.Image)(resources.GetObject("mnuLogin.Image")));
            this.mnuLogin.Name = "mnuLogin";
            this.mnuLogin.Size = new System.Drawing.Size(169, 22);
            this.mnuLogin.Text = "Đăng nhập";
            this.mnuLogin.Click += new System.EventHandler(this.mnuLogin_Click);
            // 
            // mnuRegister
            // 
            this.mnuRegister.Image = ((System.Drawing.Image)(resources.GetObject("mnuRegister.Image")));
            this.mnuRegister.Name = "mnuRegister";
            this.mnuRegister.Size = new System.Drawing.Size(169, 22);
            this.mnuRegister.Text = "Đăng ký tài khoản";
            this.mnuRegister.Click += new System.EventHandler(this.mnuRegister_Click);
            // 
            // mnuBussiness
            // 
            this.mnuBussiness.Enabled = false;
            this.mnuBussiness.Image = ((System.Drawing.Image)(resources.GetObject("mnuBussiness.Image")));
            this.mnuBussiness.Name = "mnuBussiness";
            this.mnuBussiness.Size = new System.Drawing.Size(90, 20);
            this.mnuBussiness.Text = "Nghiệp vụ";
            // 
            // mnuReport
            // 
            this.mnuReport.Enabled = false;
            this.mnuReport.Image = ((System.Drawing.Image)(resources.GetObject("mnuReport.Image")));
            this.mnuReport.Name = "mnuReport";
            this.mnuReport.Size = new System.Drawing.Size(77, 20);
            this.mnuReport.Text = "Báo cáo";
            // 
            // MnuLists
            // 
            this.MnuLists.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuUnits,
            this.mnuDepartment,
            this.mnuLevel,
            this.mnuSchool,
            this.mnuPosition,
            this.mnuAcademicLevel,
            this.trìnhĐộLLCTToolStripMenuItem,
            this.mnuResponsible});
            this.MnuLists.Image = ((System.Drawing.Image)(resources.GetObject("MnuLists.Image")));
            this.MnuLists.Name = "MnuLists";
            this.MnuLists.Size = new System.Drawing.Size(90, 20);
            this.MnuLists.Text = "Danh mục";
            this.MnuLists.Visible = false;
            // 
            // mnuUnits
            // 
            this.mnuUnits.Image = ((System.Drawing.Image)(resources.GetObject("mnuUnits.Image")));
            this.mnuUnits.Name = "mnuUnits";
            this.mnuUnits.Size = new System.Drawing.Size(206, 22);
            this.mnuUnits.Text = "1. Đơn vị";
            this.mnuUnits.Click += new System.EventHandler(this.mnuUnits_Click);
            // 
            // mnuDepartment
            // 
            this.mnuDepartment.Name = "mnuDepartment";
            this.mnuDepartment.Size = new System.Drawing.Size(206, 22);
            this.mnuDepartment.Text = "2. Phòng ban";
            this.mnuDepartment.Click += new System.EventHandler(this.mnuDepartment_Click);
            // 
            // mnuLevel
            // 
            this.mnuLevel.Name = "mnuLevel";
            this.mnuLevel.Size = new System.Drawing.Size(206, 22);
            this.mnuLevel.Text = "3. Cấp bậc";
            this.mnuLevel.Click += new System.EventHandler(this.mnuLevel_Click);
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
            this.pictureBox1.Location = new System.Drawing.Point(12, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 31);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // pnPanelMain
            // 
            this.pnPanelMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnPanelMain.Location = new System.Drawing.Point(4, 65);
            this.pnPanelMain.Name = "pnPanelMain";
            this.pnPanelMain.Size = new System.Drawing.Size(957, 440);
            this.pnPanelMain.TabIndex = 3;
            // 
            // mnuSchool
            // 
            this.mnuSchool.Name = "mnuSchool";
            this.mnuSchool.Size = new System.Drawing.Size(206, 22);
            this.mnuSchool.Text = "4. Trường";
            // 
            // mnuPosition
            // 
            this.mnuPosition.Name = "mnuPosition";
            this.mnuPosition.Size = new System.Drawing.Size(206, 22);
            this.mnuPosition.Text = "5. Chức vụ";
            this.mnuPosition.Click += new System.EventHandler(this.mnuPosition_Click);
            // 
            // mnuAcademicLevel
            // 
            this.mnuAcademicLevel.Name = "mnuAcademicLevel";
            this.mnuAcademicLevel.Size = new System.Drawing.Size(206, 22);
            this.mnuAcademicLevel.Text = "6. Trình độ";
            this.mnuAcademicLevel.Click += new System.EventHandler(this.mnuAcademicLevel_Click);
            // 
            // trìnhĐộLLCTToolStripMenuItem
            // 
            this.trìnhĐộLLCTToolStripMenuItem.Name = "trìnhĐộLLCTToolStripMenuItem";
            this.trìnhĐộLLCTToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.trìnhĐộLLCTToolStripMenuItem.Text = "7. Trình độ LLCT";
            this.trìnhĐộLLCTToolStripMenuItem.Click += new System.EventHandler(this.trìnhĐộLLCTToolStripMenuItem_Click);
            // 
            // mnuResponsible
            // 
            this.mnuResponsible.Name = "mnuResponsible";
            this.mnuResponsible.Size = new System.Drawing.Size(206, 22);
            this.mnuResponsible.Text = "8. Công tác chuyên trách";
            this.mnuResponsible.Click += new System.EventHandler(this.mnuResponsible_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 527);
            this.Controls.Add(this.pnPanelMain);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần mềm quản lý cán bộ";
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
        private System.Windows.Forms.ToolStripMenuItem mnuUnits;
        private System.Windows.Forms.Panel pnPanelMain;
        private System.Windows.Forms.ToolStripMenuItem mnuLevel;
        private System.Windows.Forms.ToolStripMenuItem mnuDepartment;
        private System.Windows.Forms.ToolStripMenuItem mnuSchool;
        private System.Windows.Forms.ToolStripMenuItem mnuPosition;
        private System.Windows.Forms.ToolStripMenuItem mnuAcademicLevel;
        private System.Windows.Forms.ToolStripMenuItem trìnhĐộLLCTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuResponsible;
    }
}
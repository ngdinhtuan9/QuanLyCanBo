namespace QuanLyNhanSu.Main
{
    partial class frmMainNew
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainNew));
            this.mnuReport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuListPerson = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLevelReport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuManagerment = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBussiness = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddNewPerson = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuResponsible = new System.Windows.Forms.ToolStripMenuItem();
            this.trìnhĐộLLCTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAcademicLevel = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPosition = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSchool = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLevel = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDepartment = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUnits = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuLists = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFostering = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFosteringQPAN = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClassify = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPoliticalLevelForm = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTittle = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCompetition = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTraningType = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFosteringType = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRegister = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuChangePass = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAccountManager = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRestore = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.pnPanelMain = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBoxExit = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuIntro = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQLHL = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQLDiem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnPanelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuReport
            // 
            this.mnuReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuListPerson,
            this.mnuLevelReport});
            this.mnuReport.Enabled = false;
            this.mnuReport.Image = ((System.Drawing.Image)(resources.GetObject("mnuReport.Image")));
            this.mnuReport.Name = "mnuReport";
            this.mnuReport.Size = new System.Drawing.Size(77, 20);
            this.mnuReport.Text = "&Báo cáo";
            // 
            // mnuListPerson
            // 
            this.mnuListPerson.Name = "mnuListPerson";
            this.mnuListPerson.Size = new System.Drawing.Size(172, 22);
            this.mnuListPerson.Text = "&1. Danh sách ";
            this.mnuListPerson.Click += new System.EventHandler(this.mnuListPerson_Click);
            // 
            // mnuLevelReport
            // 
            this.mnuLevelReport.Name = "mnuLevelReport";
            this.mnuLevelReport.Size = new System.Drawing.Size(172, 22);
            this.mnuLevelReport.Text = "2. Thống kê số liệu";
            this.mnuLevelReport.Click += new System.EventHandler(this.mnuThongKe_Click);
            // 
            // mnuManagerment
            // 
            this.mnuManagerment.Name = "mnuManagerment";
            this.mnuManagerment.Size = new System.Drawing.Size(176, 22);
            this.mnuManagerment.Text = "&1. Quản lý cán bộ";
            this.mnuManagerment.Click += new System.EventHandler(this.mnuManagerment_Click);
            // 
            // mnuBussiness
            // 
            this.mnuBussiness.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuManagerment,
            this.mnuAddNewPerson});
            this.mnuBussiness.Enabled = false;
            this.mnuBussiness.Image = ((System.Drawing.Image)(resources.GetObject("mnuBussiness.Image")));
            this.mnuBussiness.Name = "mnuBussiness";
            this.mnuBussiness.Size = new System.Drawing.Size(76, 20);
            this.mnuBussiness.Text = "&Quản lý";
            // 
            // mnuAddNewPerson
            // 
            this.mnuAddNewPerson.Name = "mnuAddNewPerson";
            this.mnuAddNewPerson.Size = new System.Drawing.Size(176, 22);
            this.mnuAddNewPerson.Text = "&2.Thêm mới cán bộ";
            this.mnuAddNewPerson.Click += new System.EventHandler(this.mnuAddNewPerson_Click);
            // 
            // mnuResponsible
            // 
            this.mnuResponsible.Name = "mnuResponsible";
            this.mnuResponsible.Size = new System.Drawing.Size(219, 22);
            this.mnuResponsible.Text = "&8. Công tác chuyên trách";
            this.mnuResponsible.Visible = false;
            this.mnuResponsible.Click += new System.EventHandler(this.mnuResponsible_Click);
            // 
            // trìnhĐộLLCTToolStripMenuItem
            // 
            this.trìnhĐộLLCTToolStripMenuItem.Name = "trìnhĐộLLCTToolStripMenuItem";
            this.trìnhĐộLLCTToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.trìnhĐộLLCTToolStripMenuItem.Text = "&7. Trình độ LLCT";
            this.trìnhĐộLLCTToolStripMenuItem.Visible = false;
            this.trìnhĐộLLCTToolStripMenuItem.Click += new System.EventHandler(this.trìnhĐộLLCTToolStripMenuItem_Click);
            // 
            // mnuAcademicLevel
            // 
            this.mnuAcademicLevel.Name = "mnuAcademicLevel";
            this.mnuAcademicLevel.Size = new System.Drawing.Size(219, 22);
            this.mnuAcademicLevel.Text = "&6. Trình độ";
            this.mnuAcademicLevel.Visible = false;
            this.mnuAcademicLevel.Click += new System.EventHandler(this.mnuAcademicLevel_Click);
            // 
            // mnuPosition
            // 
            this.mnuPosition.Name = "mnuPosition";
            this.mnuPosition.Size = new System.Drawing.Size(219, 22);
            this.mnuPosition.Text = "&5. Chức vụ";
            this.mnuPosition.Visible = false;
            this.mnuPosition.Click += new System.EventHandler(this.mnuPosition_Click);
            // 
            // mnuSchool
            // 
            this.mnuSchool.Name = "mnuSchool";
            this.mnuSchool.Size = new System.Drawing.Size(219, 22);
            this.mnuSchool.Text = "&4. Trường";
            this.mnuSchool.Visible = false;
            this.mnuSchool.Click += new System.EventHandler(this.mnuSchool_Click);
            // 
            // mnuLevel
            // 
            this.mnuLevel.Name = "mnuLevel";
            this.mnuLevel.Size = new System.Drawing.Size(219, 22);
            this.mnuLevel.Text = "&3. Cấp bậc";
            this.mnuLevel.Visible = false;
            this.mnuLevel.Click += new System.EventHandler(this.mnuLevel_Click);
            // 
            // mnuDepartment
            // 
            this.mnuDepartment.Name = "mnuDepartment";
            this.mnuDepartment.Size = new System.Drawing.Size(219, 22);
            this.mnuDepartment.Text = "&2. Đơn vị trực thuộc";
            this.mnuDepartment.Click += new System.EventHandler(this.mnuDepartment_Click);
            // 
            // mnuUnits
            // 
            this.mnuUnits.Image = ((System.Drawing.Image)(resources.GetObject("mnuUnits.Image")));
            this.mnuUnits.Name = "mnuUnits";
            this.mnuUnits.Size = new System.Drawing.Size(219, 22);
            this.mnuUnits.Text = "&1. Đơn vị chủ quản";
            this.mnuUnits.Visible = false;
            this.mnuUnits.Click += new System.EventHandler(this.mnuUnits_Click);
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
            this.mnuResponsible,
            this.btnFostering,
            this.mnuFosteringQPAN,
            this.mnuClassify,
            this.mnuPoliticalLevelForm,
            this.mnuTittle,
            this.mnuCompetition,
            this.mnuTraningType,
            this.mnuFosteringType});
            this.MnuLists.Image = ((System.Drawing.Image)(resources.GetObject("MnuLists.Image")));
            this.MnuLists.Name = "MnuLists";
            this.MnuLists.Size = new System.Drawing.Size(90, 20);
            this.MnuLists.Text = "&Danh mục";
            // 
            // btnFostering
            // 
            this.btnFostering.Name = "btnFostering";
            this.btnFostering.Size = new System.Drawing.Size(219, 22);
            this.btnFostering.Text = "&9. Bồi dưỡng PLNV";
            this.btnFostering.Visible = false;
            this.btnFostering.Click += new System.EventHandler(this.btnFostering_Click);
            // 
            // mnuFosteringQPAN
            // 
            this.mnuFosteringQPAN.Name = "mnuFosteringQPAN";
            this.mnuFosteringQPAN.Size = new System.Drawing.Size(219, 22);
            this.mnuFosteringQPAN.Text = "&10. Bồi dưỡng QPAN";
            this.mnuFosteringQPAN.Visible = false;
            this.mnuFosteringQPAN.Click += new System.EventHandler(this.mnuFosteringQPAN_Click);
            // 
            // mnuClassify
            // 
            this.mnuClassify.Name = "mnuClassify";
            this.mnuClassify.Size = new System.Drawing.Size(219, 22);
            this.mnuClassify.Text = "&11. Phân loại cán bộ";
            this.mnuClassify.Visible = false;
            this.mnuClassify.Click += new System.EventHandler(this.mnuClassify_Click);
            // 
            // mnuPoliticalLevelForm
            // 
            this.mnuPoliticalLevelForm.Name = "mnuPoliticalLevelForm";
            this.mnuPoliticalLevelForm.Size = new System.Drawing.Size(219, 22);
            this.mnuPoliticalLevelForm.Text = "&12. Hình thức trình độ LLCT";
            this.mnuPoliticalLevelForm.Visible = false;
            this.mnuPoliticalLevelForm.Click += new System.EventHandler(this.mnuPoliticalLevelForm_Click);
            // 
            // mnuTittle
            // 
            this.mnuTittle.Name = "mnuTittle";
            this.mnuTittle.Size = new System.Drawing.Size(219, 22);
            this.mnuTittle.Text = "&13. Chức danh";
            this.mnuTittle.Visible = false;
            this.mnuTittle.Click += new System.EventHandler(this.mnuTittle_Click);
            // 
            // mnuCompetition
            // 
            this.mnuCompetition.Name = "mnuCompetition";
            this.mnuCompetition.Size = new System.Drawing.Size(219, 22);
            this.mnuCompetition.Text = "&14.Phân loại thi đua";
            this.mnuCompetition.Visible = false;
            this.mnuCompetition.Click += new System.EventHandler(this.mnuCompetition_Click);
            // 
            // mnuTraningType
            // 
            this.mnuTraningType.Name = "mnuTraningType";
            this.mnuTraningType.Size = new System.Drawing.Size(219, 22);
            this.mnuTraningType.Text = "&15. Hình thức đào tạo";
            this.mnuTraningType.Click += new System.EventHandler(this.mnuTraningType_Click);
            // 
            // mnuFosteringType
            // 
            this.mnuFosteringType.Name = "mnuFosteringType";
            this.mnuFosteringType.Size = new System.Drawing.Size(219, 22);
            this.mnuFosteringType.Text = "&16. Hệ đào tạo";
            this.mnuFosteringType.Click += new System.EventHandler(this.hệĐàoTạoToolStripMenuItem_Click);
            // 
            // mnuRegister
            // 
            this.mnuRegister.Image = ((System.Drawing.Image)(resources.GetObject("mnuRegister.Image")));
            this.mnuRegister.Name = "mnuRegister";
            this.mnuRegister.Size = new System.Drawing.Size(181, 22);
            this.mnuRegister.Text = "&3. Đăng ký tài khoản";
            this.mnuRegister.Visible = false;
            this.mnuRegister.Click += new System.EventHandler(this.mnuRegister_Click);
            // 
            // mnuChangePass
            // 
            this.mnuChangePass.Name = "mnuChangePass";
            this.mnuChangePass.Size = new System.Drawing.Size(181, 22);
            this.mnuChangePass.Text = "&2. Đổi mật khẩu";
            this.mnuChangePass.Click += new System.EventHandler(this.mnuChangePass_Click);
            // 
            // mnuLogin
            // 
            this.mnuLogin.Image = ((System.Drawing.Image)(resources.GetObject("mnuLogin.Image")));
            this.mnuLogin.Name = "mnuLogin";
            this.mnuLogin.Size = new System.Drawing.Size(181, 22);
            this.mnuLogin.Text = "&1.Đăng nhập";
            this.mnuLogin.Click += new System.EventHandler(this.mnuLogin_Click);
            // 
            // mnuSystem
            // 
            this.mnuSystem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLogin,
            this.mnuChangePass,
            this.mnuRegister,
            this.mnuAccountManager,
            this.toolStripSeparator1,
            this.mnuBackup,
            this.mnuRestore,
            this.toolStripSeparator2,
            this.btnExit});
            this.mnuSystem.Enabled = false;
            this.mnuSystem.Image = ((System.Drawing.Image)(resources.GetObject("mnuSystem.Image")));
            this.mnuSystem.Name = "mnuSystem";
            this.mnuSystem.Size = new System.Drawing.Size(85, 20);
            this.mnuSystem.Text = "&Hệ thống";
            // 
            // mnuAccountManager
            // 
            this.mnuAccountManager.Name = "mnuAccountManager";
            this.mnuAccountManager.Size = new System.Drawing.Size(181, 22);
            this.mnuAccountManager.Text = "&4. Quản lý tài khoản";
            this.mnuAccountManager.Click += new System.EventHandler(this.mnuAccountManager_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(178, 6);
            // 
            // mnuBackup
            // 
            this.mnuBackup.Name = "mnuBackup";
            this.mnuBackup.Size = new System.Drawing.Size(181, 22);
            this.mnuBackup.Text = "&5. Backup dữ liệu";
            this.mnuBackup.Click += new System.EventHandler(this.mnuBackup_Click);
            // 
            // mnuRestore
            // 
            this.mnuRestore.Name = "mnuRestore";
            this.mnuRestore.Size = new System.Drawing.Size(181, 22);
            this.mnuRestore.Text = "&6. Khôi phục dữ liệu";
            this.mnuRestore.Click += new System.EventHandler(this.mnuRestore_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(178, 6);
            // 
            // btnExit
            // 
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(181, 22);
            this.btnExit.Text = "&7. Thoát";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pnPanelMain
            // 
            this.pnPanelMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnPanelMain.Controls.Add(this.pictureBox3);
            this.pnPanelMain.Location = new System.Drawing.Point(4, 107);
            this.pnPanelMain.Name = "pnPanelMain";
            this.pnPanelMain.Size = new System.Drawing.Size(1114, 537);
            this.pnPanelMain.TabIndex = 6;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.InitialImage = null;
            this.pictureBox3.Location = new System.Drawing.Point(3, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(1108, 531);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.pictureBoxExit);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1118, 74);
            this.panel1.TabIndex = 5;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(188, 3);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(75, 68);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox4.TabIndex = 7;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            this.pictureBox4.MouseEnter += new System.EventHandler(this.pictureBox4_MouseEnter);
            this.pictureBox4.MouseLeave += new System.EventHandler(this.pictureBox4_MouseLeave);
            // 
            // pictureBoxExit
            // 
            this.pictureBoxExit.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxExit.Image")));
            this.pictureBoxExit.Location = new System.Drawing.Point(278, 3);
            this.pictureBoxExit.Name = "pictureBoxExit";
            this.pictureBoxExit.Size = new System.Drawing.Size(75, 68);
            this.pictureBoxExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxExit.TabIndex = 6;
            this.pictureBoxExit.TabStop = false;
            this.pictureBoxExit.Click += new System.EventHandler(this.pictureBoxExit_Click);
            this.pictureBoxExit.MouseEnter += new System.EventHandler(this.pictureBoxExit_MouseEnter);
            this.pictureBoxExit.MouseLeave += new System.EventHandler(this.pictureBoxExit_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(71, 68);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter_1);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave_1);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(95, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(77, 71);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            this.pictureBox2.MouseEnter += new System.EventHandler(this.pictureBox2_MouseEnter);
            this.pictureBox2.MouseLeave += new System.EventHandler(this.pictureBox2_MouseLeave);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSystem,
            this.mnuBussiness,
            this.MnuLists,
            this.mnuReport,
            this.mnuIntro,
            this.mnuQLHL});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1118, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuIntro
            // 
            this.mnuIntro.Name = "mnuIntro";
            this.mnuIntro.Size = new System.Drawing.Size(70, 20);
            this.mnuIntro.Text = "&Giới thiệu";
            this.mnuIntro.Click += new System.EventHandler(this.mnuIntro_Click);
            // 
            // mnuQLHL
            // 
            this.mnuQLHL.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuQLDiem});
            this.mnuQLHL.Name = "mnuQLHL";
            this.mnuQLHL.Size = new System.Drawing.Size(122, 20);
            this.mnuQLHL.Text = "Quản lý huấn luyện";
            this.mnuQLHL.Visible = false;
            // 
            // mnuQLDiem
            // 
            this.mnuQLDiem.Name = "mnuQLDiem";
            this.mnuQLDiem.Size = new System.Drawing.Size(180, 22);
            this.mnuQLDiem.Text = "1. Quản lý điểm";
            this.mnuQLDiem.Click += new System.EventHandler(this.mnuQLDiem_Click);
            // 
            // frmMainNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 646);
            this.Controls.Add(this.pnPanelMain);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMainNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PHẦN MỀM QUẢN LÝ TRÌNH ĐỘ ĐÀO TẠO CÁN BỘ TRONG BIÊN CHẾ K02  (Phòng tổ chức cán b" +
    "ộ) Version 1.0.2";
            this.Load += new System.EventHandler(this.frmMainNew_Load);
            this.pnPanelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem mnuReport;
        private System.Windows.Forms.ToolStripMenuItem mnuManagerment;
        private System.Windows.Forms.ToolStripMenuItem mnuBussiness;
        private System.Windows.Forms.ToolStripMenuItem mnuResponsible;
        private System.Windows.Forms.ToolStripMenuItem trìnhĐộLLCTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuAcademicLevel;
        private System.Windows.Forms.ToolStripMenuItem mnuPosition;
        private System.Windows.Forms.ToolStripMenuItem mnuSchool;
        private System.Windows.Forms.ToolStripMenuItem mnuLevel;
        private System.Windows.Forms.ToolStripMenuItem mnuDepartment;
        private System.Windows.Forms.ToolStripMenuItem mnuUnits;
        private System.Windows.Forms.ToolStripMenuItem MnuLists;
        private System.Windows.Forms.ToolStripMenuItem mnuRegister;
        private System.Windows.Forms.ToolStripMenuItem mnuChangePass;
        private System.Windows.Forms.ToolStripMenuItem mnuLogin;
        private System.Windows.Forms.ToolStripMenuItem mnuSystem;
        private System.Windows.Forms.Panel pnPanelMain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuAddNewPerson;
        private System.Windows.Forms.ToolStripMenuItem mnuBackup;
        private System.Windows.Forms.ToolStripMenuItem mnuRestore;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem btnExit;
        private System.Windows.Forms.ToolStripMenuItem btnFostering;
        private System.Windows.Forms.PictureBox pictureBoxExit;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem mnuFosteringQPAN;
        private System.Windows.Forms.ToolStripMenuItem mnuClassify;
        private System.Windows.Forms.ToolStripMenuItem mnuPoliticalLevelForm;
        private System.Windows.Forms.ToolStripMenuItem mnuTittle;
        private System.Windows.Forms.ToolStripMenuItem mnuCompetition;
        private System.Windows.Forms.ToolStripMenuItem mnuListPerson;
        private System.Windows.Forms.ToolStripMenuItem mnuAccountManager;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.ToolStripMenuItem mnuIntro;
        private System.Windows.Forms.ToolStripMenuItem mnuTraningType;
        private System.Windows.Forms.ToolStripMenuItem mnuFosteringType;
        private System.Windows.Forms.ToolStripMenuItem mnuLevelReport;
        private System.Windows.Forms.ToolStripMenuItem mnuQLHL;
        private System.Windows.Forms.ToolStripMenuItem mnuQLDiem;
    }
}
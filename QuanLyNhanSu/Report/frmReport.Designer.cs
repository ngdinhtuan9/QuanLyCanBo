namespace QuanLyNhanSu.Category
{
    partial class frmReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReport));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbxTypeFostering = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbxDepartment = new System.Windows.Forms.ComboBox();
            this.D = new System.Windows.Forms.Label();
            this.cbxUnit = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxArrange = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxAcademicLevel = new System.Windows.Forms.ComboBox();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CHECK = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExcel = new System.Windows.Forms.Button();
            this.clbColumns = new System.Windows.Forms.CheckedListBox();
            this.cbxCheckAll = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.cbxTypeFostering);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.cbxDepartment);
            this.panel1.Controls.Add(this.D);
            this.panel1.Controls.Add(this.cbxUnit);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cbxArrange);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cbxAcademicLevel);
            this.panel1.Controls.Add(this.txtFullName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtCode);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1374, 90);
            this.panel1.TabIndex = 0;
            // 
            // cbxTypeFostering
            // 
            this.cbxTypeFostering.DisplayMember = "Description";
            this.cbxTypeFostering.FormattingEnabled = true;
            this.cbxTypeFostering.Location = new System.Drawing.Point(622, 51);
            this.cbxTypeFostering.Name = "cbxTypeFostering";
            this.cbxTypeFostering.Size = new System.Drawing.Size(173, 21);
            this.cbxTypeFostering.TabIndex = 56;
            this.cbxTypeFostering.ValueMember = "Value";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(552, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 55;
            this.label6.Text = "Bồi dưỡng";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(193, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 13);
            this.label7.TabIndex = 54;
            this.label7.Text = "Đơn vị trực thuộc";
            // 
            // cbxDepartment
            // 
            this.cbxDepartment.DisplayMember = "Description";
            this.cbxDepartment.FormattingEnabled = true;
            this.cbxDepartment.Location = new System.Drawing.Point(302, 48);
            this.cbxDepartment.Name = "cbxDepartment";
            this.cbxDepartment.Size = new System.Drawing.Size(226, 21);
            this.cbxDepartment.TabIndex = 53;
            this.cbxDepartment.ValueMember = "Value";
            // 
            // D
            // 
            this.D.AutoSize = true;
            this.D.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.D.Location = new System.Drawing.Point(196, 26);
            this.D.Name = "D";
            this.D.Size = new System.Drawing.Size(101, 13);
            this.D.TabIndex = 52;
            this.D.Text = "Đơn vị chủ quản";
            // 
            // cbxUnit
            // 
            this.cbxUnit.DisplayMember = "Description";
            this.cbxUnit.FormattingEnabled = true;
            this.cbxUnit.Location = new System.Drawing.Point(302, 24);
            this.cbxUnit.Name = "cbxUnit";
            this.cbxUnit.Size = new System.Drawing.Size(226, 21);
            this.cbxUnit.TabIndex = 51;
            this.cbxUnit.ValueMember = "Value";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(843, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 46;
            this.label4.Text = "Sắp xếp";
            // 
            // cbxArrange
            // 
            this.cbxArrange.DisplayMember = "Description";
            this.cbxArrange.FormattingEnabled = true;
            this.cbxArrange.Location = new System.Drawing.Point(904, 23);
            this.cbxArrange.Name = "cbxArrange";
            this.cbxArrange.Size = new System.Drawing.Size(94, 21);
            this.cbxArrange.TabIndex = 45;
            this.cbxArrange.ValueMember = "Value";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(561, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 44;
            this.label3.Text = "Trình độ";
            // 
            // cbxAcademicLevel
            // 
            this.cbxAcademicLevel.DisplayMember = "Description";
            this.cbxAcademicLevel.FormattingEnabled = true;
            this.cbxAcademicLevel.Location = new System.Drawing.Point(622, 24);
            this.cbxAcademicLevel.Name = "cbxAcademicLevel";
            this.cbxAcademicLevel.Size = new System.Drawing.Size(173, 21);
            this.cbxAcademicLevel.TabIndex = 43;
            this.cbxAcademicLevel.ValueMember = "Value";
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(62, 47);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(115, 20);
            this.txtFullName.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Tên";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(62, 24);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(115, 20);
            this.txtCode.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Số hiệu ";
            // 
            // btnSearch
            // 
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(1045, 22);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(72, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "&Tìm kiếm";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(1310, 632);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(60, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "T&hoát";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_1);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CHECK,
            this.STT});
            this.dataGridView1.Location = new System.Drawing.Point(232, 98);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1120, 528);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            this.dataGridView1.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataGridView1_RowPrePaint);
            // 
            // CHECK
            // 
            this.CHECK.HeaderText = "";
            this.CHECK.Name = "CHECK";
            this.CHECK.Width = 20;
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.Width = 50;
            // 
            // btnExcel
            // 
            this.btnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcel.Location = new System.Drawing.Point(12, 632);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(83, 23);
            this.btnExcel.TabIndex = 11;
            this.btnExcel.Text = "&Xuất Excel";
            this.btnExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // clbColumns
            // 
            this.clbColumns.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.clbColumns.FormattingEnabled = true;
            this.clbColumns.Location = new System.Drawing.Point(2, 113);
            this.clbColumns.Name = "clbColumns";
            this.clbColumns.Size = new System.Drawing.Size(224, 514);
            this.clbColumns.TabIndex = 51;
            // 
            // cbxCheckAll
            // 
            this.cbxCheckAll.AutoSize = true;
            this.cbxCheckAll.Location = new System.Drawing.Point(277, 104);
            this.cbxCheckAll.Name = "cbxCheckAll";
            this.cbxCheckAll.Size = new System.Drawing.Size(15, 14);
            this.cbxCheckAll.TabIndex = 52;
            this.cbxCheckAll.UseVisualStyleBackColor = true;
            this.cbxCheckAll.CheckedChanged += new System.EventHandler(this.cbxCheckAll_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(5, 95);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(81, 17);
            this.checkBox1.TabIndex = 53;
            this.checkBox1.Text = "Chọn tất cả";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // frmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1376, 660);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.cbxCheckAll);
            this.Controls.Add(this.clbColumns);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnCancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách cán bộ";
            this.Load += new System.EventHandler(this.frmUnits_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;

        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CHECK;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxAcademicLevel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxArrange;
        private System.Windows.Forms.CheckedListBox clbColumns;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbxDepartment;
        private System.Windows.Forms.Label D;
        private System.Windows.Forms.ComboBox cbxUnit;
        private System.Windows.Forms.ComboBox cbxTypeFostering;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox cbxCheckAll;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}
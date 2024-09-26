namespace QuanLyNhanSu.Category
{
    partial class frmTraningProcessDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTraningProcessDetails));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbxTraningProcessType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxAcademicLevel = new System.Windows.Forms.ComboBox();
            this.txtDecisionNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.D = new System.Windows.Forms.Label();
            this.cbxSchool = new System.Windows.Forms.ComboBox();
            this.rtbNote = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMajor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.mtbEndYear = new System.Windows.Forms.MaskedTextBox();
            this.mtbBeginYear = new System.Windows.Forms.MaskedTextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.mtbEndYear);
            this.panel1.Controls.Add(this.mtbBeginYear);
            this.panel1.Controls.Add(this.cbxTraningProcessType);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cbxType);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cbxAcademicLevel);
            this.panel1.Controls.Add(this.txtDecisionNumber);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.D);
            this.panel1.Controls.Add(this.cbxSchool);
            this.panel1.Controls.Add(this.rtbNote);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtMajor);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(395, 296);
            this.panel1.TabIndex = 0;
            // 
            // cbxTraningProcessType
            // 
            this.cbxTraningProcessType.DisplayMember = "Description";
            this.cbxTraningProcessType.FormattingEnabled = true;
            this.cbxTraningProcessType.Location = new System.Drawing.Point(132, 119);
            this.cbxTraningProcessType.Name = "cbxTraningProcessType";
            this.cbxTraningProcessType.Size = new System.Drawing.Size(223, 21);
            this.cbxTraningProcessType.TabIndex = 4;
            this.cbxTraningProcessType.ValueMember = "Value";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(16, 122);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 13);
            this.label7.TabIndex = 48;
            this.label7.Text = "Hình thức đào tạo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(47, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 46;
            this.label6.Text = "Loại đào tạo";
            // 
            // cbxType
            // 
            this.cbxType.DisplayMember = "Description";
            this.cbxType.FormattingEnabled = true;
            this.cbxType.Location = new System.Drawing.Point(132, 12);
            this.cbxType.Name = "cbxType";
            this.cbxType.Size = new System.Drawing.Size(223, 21);
            this.cbxType.TabIndex = 0;
            this.cbxType.ValueMember = "Value";
            this.cbxType.TextChanged += new System.EventHandler(this.cbxType_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(42, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 41;
            this.label5.Text = "Ngày bắt đầu";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(39, 203);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(87, 13);
            this.label13.TabIndex = 39;
            this.label13.Text = "Ngày kết thúc";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(71, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Trình độ";
            // 
            // cbxAcademicLevel
            // 
            this.cbxAcademicLevel.DisplayMember = "Description";
            this.cbxAcademicLevel.FormattingEnabled = true;
            this.cbxAcademicLevel.Location = new System.Drawing.Point(132, 92);
            this.cbxAcademicLevel.Name = "cbxAcademicLevel";
            this.cbxAcademicLevel.Size = new System.Drawing.Size(223, 21);
            this.cbxAcademicLevel.TabIndex = 3;
            this.cbxAcademicLevel.ValueMember = "Value";
            // 
            // txtDecisionNumber
            // 
            this.txtDecisionNumber.Location = new System.Drawing.Point(132, 145);
            this.txtDecisionNumber.Name = "txtDecisionNumber";
            this.txtDecisionNumber.Size = new System.Drawing.Size(223, 20);
            this.txtDecisionNumber.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Số quyết định";
            // 
            // D
            // 
            this.D.AutoSize = true;
            this.D.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.D.Location = new System.Drawing.Point(79, 42);
            this.D.Name = "D";
            this.D.Size = new System.Drawing.Size(47, 13);
            this.D.TabIndex = 22;
            this.D.Text = "Trường";
            // 
            // cbxSchool
            // 
            this.cbxSchool.DisplayMember = "Description";
            this.cbxSchool.FormattingEnabled = true;
            this.cbxSchool.Location = new System.Drawing.Point(132, 39);
            this.cbxSchool.Name = "cbxSchool";
            this.cbxSchool.Size = new System.Drawing.Size(223, 21);
            this.cbxSchool.TabIndex = 1;
            this.cbxSchool.ValueMember = "Value";
            this.cbxSchool.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cbxSchool_MouseClick);
            // 
            // rtbNote
            // 
            this.rtbNote.Location = new System.Drawing.Point(132, 223);
            this.rtbNote.Name = "rtbNote";
            this.rtbNote.Size = new System.Drawing.Size(223, 61);
            this.rtbNote.TabIndex = 8;
            this.rtbNote.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(75, 226);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Ghi chú";
            // 
            // txtMajor
            // 
            this.txtMajor.Location = new System.Drawing.Point(132, 66);
            this.txtMajor.Name = "txtMajor";
            this.txtMajor.Size = new System.Drawing.Size(223, 20);
            this.txtMajor.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(38, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Chuyên ngành";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(245, 306);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(83, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Lưu dữ liệu";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(333, 306);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(60, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "T&hoát";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // mtbEndYear
            // 
            this.mtbEndYear.Location = new System.Drawing.Point(132, 196);
            this.mtbEndYear.Name = "mtbEndYear";
            this.mtbEndYear.Size = new System.Drawing.Size(100, 20);
            this.mtbEndYear.TabIndex = 7;
            // 
            // mtbBeginYear
            // 
            this.mtbBeginYear.Location = new System.Drawing.Point(132, 170);
            this.mtbBeginYear.Name = "mtbBeginYear";
            this.mtbBeginYear.Size = new System.Drawing.Size(100, 20);
            this.mtbBeginYear.TabIndex = 6;
            // 
            // frmTraningProcessDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 337);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTraningProcessDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi tiết";
            this.Load += new System.EventHandler(this.frmUnitDetail_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMajor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rtbNote;
        private System.Windows.Forms.Label D;
        private System.Windows.Forms.ComboBox cbxSchool;
        private System.Windows.Forms.TextBox txtDecisionNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxAcademicLevel;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbxTraningProcessType;
        private System.Windows.Forms.MaskedTextBox mtbEndYear;
        private System.Windows.Forms.MaskedTextBox mtbBeginYear;
    }
}
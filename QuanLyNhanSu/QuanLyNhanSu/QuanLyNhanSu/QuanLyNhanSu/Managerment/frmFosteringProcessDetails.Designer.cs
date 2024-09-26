namespace QuanLyNhanSu.Category
{
    partial class frmFosteringProcessDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFosteringProcessDetails));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtBeginYear = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.dtEndYear = new System.Windows.Forms.DateTimePicker();
            this.txtDecisionNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.D = new System.Windows.Forms.Label();
            this.cbxSchool = new System.Windows.Forms.ComboBox();
            this.rtbNote = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbxFostering = new System.Windows.Forms.ComboBox();
            this.cbxFosteringQPAN = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.cbxFosteringQPAN);
            this.panel1.Controls.Add(this.cbxFostering);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cbxType);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.dtBeginYear);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.dtEndYear);
            this.panel1.Controls.Add(this.txtDecisionNumber);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.D);
            this.panel1.Controls.Add(this.cbxSchool);
            this.panel1.Controls.Add(this.rtbNote);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtContent);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(420, 235);
            this.panel1.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(50, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 44;
            this.label6.Text = "Loại bồ dưỡng";
            // 
            // cbxType
            // 
            this.cbxType.DisplayMember = "Description";
            this.cbxType.FormattingEnabled = true;
            this.cbxType.Location = new System.Drawing.Point(144, 8);
            this.cbxType.Name = "cbxType";
            this.cbxType.Size = new System.Drawing.Size(223, 21);
            this.cbxType.TabIndex = 43;
            this.cbxType.ValueMember = "Value";
            this.cbxType.SelectedIndexChanged += new System.EventHandler(this.cbxType_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(54, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 41;
            this.label5.Text = "Ngày bắt đầu";
            // 
            // dtBeginYear
            // 
            this.dtBeginYear.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtBeginYear.Location = new System.Drawing.Point(144, 114);
            this.dtBeginYear.Name = "dtBeginYear";
            this.dtBeginYear.Size = new System.Drawing.Size(99, 20);
            this.dtBeginYear.TabIndex = 4;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(51, 146);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(87, 13);
            this.label13.TabIndex = 39;
            this.label13.Text = "Ngày kết thúc";
            // 
            // dtEndYear
            // 
            this.dtEndYear.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtEndYear.Location = new System.Drawing.Point(144, 140);
            this.dtEndYear.Name = "dtEndYear";
            this.dtEndYear.Size = new System.Drawing.Size(97, 20);
            this.dtEndYear.TabIndex = 5;
            // 
            // txtDecisionNumber
            // 
            this.txtDecisionNumber.Location = new System.Drawing.Point(144, 88);
            this.txtDecisionNumber.Name = "txtDecisionNumber";
            this.txtDecisionNumber.Size = new System.Drawing.Size(223, 20);
            this.txtDecisionNumber.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(52, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Số quyết định";
            // 
            // D
            // 
            this.D.AutoSize = true;
            this.D.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.D.Location = new System.Drawing.Point(91, 38);
            this.D.Name = "D";
            this.D.Size = new System.Drawing.Size(47, 13);
            this.D.TabIndex = 22;
            this.D.Text = "Trường";
            // 
            // cbxSchool
            // 
            this.cbxSchool.DisplayMember = "Description";
            this.cbxSchool.FormattingEnabled = true;
            this.cbxSchool.Location = new System.Drawing.Point(144, 35);
            this.cbxSchool.Name = "cbxSchool";
            this.cbxSchool.Size = new System.Drawing.Size(223, 21);
            this.cbxSchool.TabIndex = 0;
            this.cbxSchool.ValueMember = "Value";
            this.cbxSchool.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cbxSchool_MouseClick);
            // 
            // rtbNote
            // 
            this.rtbNote.Location = new System.Drawing.Point(144, 166);
            this.rtbNote.Name = "rtbNote";
            this.rtbNote.Size = new System.Drawing.Size(223, 61);
            this.rtbNote.TabIndex = 6;
            this.rtbNote.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(64, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Ghi chú";
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(144, 62);
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(223, 20);
            this.txtContent.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nội dung bồi dưỡng";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(270, 245);
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
            this.btnCancel.Location = new System.Drawing.Point(358, 245);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(60, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "T&hoát";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cbxFostering
            // 
            this.cbxFostering.DisplayMember = "Description";
            this.cbxFostering.FormattingEnabled = true;
            this.cbxFostering.Location = new System.Drawing.Point(144, 62);
            this.cbxFostering.Name = "cbxFostering";
            this.cbxFostering.Size = new System.Drawing.Size(223, 21);
            this.cbxFostering.TabIndex = 45;
            this.cbxFostering.ValueMember = "Value";
            // 
            // cbxFosteringQPAN
            // 
            this.cbxFosteringQPAN.DisplayMember = "Description";
            this.cbxFosteringQPAN.FormattingEnabled = true;
            this.cbxFosteringQPAN.Location = new System.Drawing.Point(144, 62);
            this.cbxFosteringQPAN.Name = "cbxFosteringQPAN";
            this.cbxFosteringQPAN.Size = new System.Drawing.Size(223, 21);
            this.cbxFosteringQPAN.TabIndex = 46;
            this.cbxFosteringQPAN.ValueMember = "Value";
            // 
            // frmFosteringProcessDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 276);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFosteringProcessDetails";
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
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rtbNote;
        private System.Windows.Forms.Label D;
        private System.Windows.Forms.ComboBox cbxSchool;
        private System.Windows.Forms.TextBox txtDecisionNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtBeginYear;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtEndYear;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxType;
        private System.Windows.Forms.ComboBox cbxFostering;
        private System.Windows.Forms.ComboBox cbxFosteringQPAN;
    }
}
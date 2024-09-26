namespace QuanLyNhanSu.Report
{
    partial class frmLevelReportNew
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLevelReportNew));
            this.btnCreateAccount = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.D = new System.Windows.Forms.Label();
            this.cbxUnit = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnCreateAccount
            // 
            this.btnCreateAccount.Image = ((System.Drawing.Image)(resources.GetObject("btnCreateAccount.Image")));
            this.btnCreateAccount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateAccount.Location = new System.Drawing.Point(222, 52);
            this.btnCreateAccount.Name = "btnCreateAccount";
            this.btnCreateAccount.Size = new System.Drawing.Size(98, 23);
            this.btnCreateAccount.TabIndex = 3;
            this.btnCreateAccount.Text = "&Xuất báo cáo";
            this.btnCreateAccount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCreateAccount.UseVisualStyleBackColor = true;
            this.btnCreateAccount.Click += new System.EventHandler(this.btnCreateAccount_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(326, 52);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(52, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "&Hủy";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // D
            // 
            this.D.AutoSize = true;
            this.D.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.D.Location = new System.Drawing.Point(35, 21);
            this.D.Name = "D";
            this.D.Size = new System.Drawing.Size(44, 13);
            this.D.TabIndex = 24;
            this.D.Text = "Đơn vị";
            // 
            // cbxUnit
            // 
            this.cbxUnit.DisplayMember = "Description";
            this.cbxUnit.FormattingEnabled = true;
            this.cbxUnit.Location = new System.Drawing.Point(94, 18);
            this.cbxUnit.Name = "cbxUnit";
            this.cbxUnit.Size = new System.Drawing.Size(284, 21);
            this.cbxUnit.TabIndex = 23;
            this.cbxUnit.ValueMember = "Value";
            // 
            // frmLevelReportNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 85);
            this.Controls.Add(this.D);
            this.Controls.Add(this.cbxUnit);
            this.Controls.Add(this.btnCreateAccount);
            this.Controls.Add(this.btnCancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLevelReportNew";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo thống kê trình độ";
            this.Load += new System.EventHandler(this.frmCreateAccount_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCreateAccount;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label D;
        private System.Windows.Forms.ComboBox cbxUnit;
    }
}
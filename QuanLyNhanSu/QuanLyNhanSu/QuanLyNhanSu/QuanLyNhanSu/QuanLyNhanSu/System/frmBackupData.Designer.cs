namespace QuanLyNhanSu
{
    partial class frmBackupData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBackupData));
            this.btnCreateAccount = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtFolderPath = new System.Windows.Forms.TextBox();
            this.cbxFullData = new System.Windows.Forms.CheckBox();
            this.D = new System.Windows.Forms.Label();
            this.cbxUnit = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnCreateAccount
            // 
            this.btnCreateAccount.Image = ((System.Drawing.Image)(resources.GetObject("btnCreateAccount.Image")));
            this.btnCreateAccount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateAccount.Location = new System.Drawing.Point(245, 76);
            this.btnCreateAccount.Name = "btnCreateAccount";
            this.btnCreateAccount.Size = new System.Drawing.Size(97, 23);
            this.btnCreateAccount.TabIndex = 3;
            this.btnCreateAccount.Text = "Tạo file lưu trữ";
            this.btnCreateAccount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCreateAccount.UseVisualStyleBackColor = true;
            this.btnCreateAccount.Click += new System.EventHandler(this.btnCreateAccount_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(348, 76);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(56, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Đường dẫn";
            // 
            // button1
            // 
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(348, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "...";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtFolderPath
            // 
            this.txtFolderPath.Location = new System.Drawing.Point(88, 17);
            this.txtFolderPath.Name = "txtFolderPath";
            this.txtFolderPath.Size = new System.Drawing.Size(254, 20);
            this.txtFolderPath.TabIndex = 18;
            // 
            // cbxFullData
            // 
            this.cbxFullData.AutoSize = true;
            this.cbxFullData.Location = new System.Drawing.Point(88, 69);
            this.cbxFullData.Name = "cbxFullData";
            this.cbxFullData.Size = new System.Drawing.Size(131, 17);
            this.cbxFullData.TabIndex = 19;
            this.cbxFullData.Text = "Đầy đủ dữ liệu cán bộ";
            this.cbxFullData.UseVisualStyleBackColor = true;
            // 
            // D
            // 
            this.D.AutoSize = true;
            this.D.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.D.Location = new System.Drawing.Point(41, 46);
            this.D.Name = "D";
            this.D.Size = new System.Drawing.Size(44, 13);
            this.D.TabIndex = 22;
            this.D.Text = "Đơn vị";
            // 
            // cbxUnit
            // 
            this.cbxUnit.DisplayMember = "Description";
            this.cbxUnit.FormattingEnabled = true;
            this.cbxUnit.Location = new System.Drawing.Point(88, 43);
            this.cbxUnit.Name = "cbxUnit";
            this.cbxUnit.Size = new System.Drawing.Size(254, 21);
            this.cbxUnit.TabIndex = 21;
            this.cbxUnit.ValueMember = "Value";
            // 
            // frmBackupData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 111);
            this.Controls.Add(this.D);
            this.Controls.Add(this.cbxUnit);
            this.Controls.Add(this.cbxFullData);
            this.Controls.Add(this.txtFolderPath);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCreateAccount);
            this.Controls.Add(this.btnCancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBackupData";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lưu trữ dữ liệu";
            this.Load += new System.EventHandler(this.frmBackupData_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCreateAccount;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtFolderPath;
        private System.Windows.Forms.CheckBox cbxFullData;
        private System.Windows.Forms.Label D;
        private System.Windows.Forms.ComboBox cbxUnit;
    }
}
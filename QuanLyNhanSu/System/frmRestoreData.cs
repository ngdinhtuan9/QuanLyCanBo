using QuanLyNhanSu.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.IO.Compression;
using Ionic.Zip;
using System.Diagnostics;

namespace QuanLyNhanSu
{
    public partial class frmRestoreData : Form
    {
        string path = AppDomain.CurrentDomain.BaseDirectory ;
        public frmRestoreData()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            string sourceFile = path;
            try
            {
                string selectedZipFile = txtFolderPath.Text ;
                if (selectedZipFile == "") { MessageBox.Show("Bạn chưa chọn file để khôi phục.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

                using (ZipFile zip = ZipFile.Read(selectedZipFile))
                {
                    // Gán mật khẩu cho file zip (chỉ áp dụng nếu file zip được mã hóa)
                    zip.Password = Common.zipPassword;
                    // Giải nén tất cả các file và thư mục từ file zip đến thư mục đích
                    zip.ExtractAll(path, ExtractExistingFileAction.OverwriteSilently);
                }
                MessageBox.Show("Khôi phục file thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi trong quá trình xử lý dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();

            // Thiết lập các thuộc tính cho hộp thoại mở tệp
            openFileDialog.Title = "Chọn file zip";
            openFileDialog.Filter = "File zip (*.zip)|*.zip|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            // Hiển thị hộp thoại mở tệp và xác nhận lựa chọn của người dùng
            string selectedZipFile = "";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Lấy đường dẫn đến file zip đã chọn
                 selectedZipFile = openFileDialog.FileName;
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn file.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //string zipFilePath = path;
            txtFolderPath.Text = selectedZipFile;
            // Mật khẩu của file zip
           
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi trong quá trình xử lý dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

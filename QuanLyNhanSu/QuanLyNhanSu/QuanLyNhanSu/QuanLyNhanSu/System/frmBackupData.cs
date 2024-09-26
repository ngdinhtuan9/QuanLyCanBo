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
    public partial class frmBackupData : Form
    {
        string path = AppDomain.CurrentDomain.BaseDirectory + "Data";
        List<Unit> allUnits;
        string fileUnitName = "Units\\Units.txt";
        public frmBackupData()
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
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                folderBrowserDialog.Description = "Chọn thư mục để lưu file zip";

                if (txtFolderPath.Text == "")
                {
                    MessageBox.Show("Chưa chọn đường dẫn lưu file.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string zipFile = System.IO.Path.Combine(txtFolderPath.Text, "archive.zip");
                string folderNameToDelete = "Managerment";
                string fileNameToDelete = "Category/Units/Units.txt";
                // Khởi tạo đối tượng ZipFile
                using (ZipFile zip = new ZipFile())
                {
                    zip.Password = Common.zipPassword;
                    // Thêm file vào file zip với mật khẩu đã thiết lập
                    zip.AddDirectory(sourceFile, "");
                    
                    if (!cbxFullData.Checked)
                    {
                        foreach (ZipEntry entry in zip.ToList())
                        {
                            // Nếu entry là thư mục và có tiền tố là tên thư mục cần xóa
                            if (entry.FileName.StartsWith(folderNameToDelete + "/"))
                            {
                                // Xóa entry khỏi tập tin zip
                                zip.RemoveEntry(entry.FileName);
                            }
                            if (cbxUnit.Text.Trim() != "Tất cả" && entry.FileName.StartsWith(fileNameToDelete))
                            {
                                zip.RemoveEntry(entry.FileName);
                                //xly danh muc don vi chi cho 1 dv

                            }
                        }
                    }
                    zip.Save(zipFile);
                    MessageBox.Show("Lưu file backup thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sourceFile = path;
            string password = "Duc@nhBTL";
            try
            {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                folderBrowserDialog.Description = "Chọn thư mục để lưu file zip";
                // Mở FolderBrowserDialog và kiểm tra kết quả
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    string folderPath = folderBrowserDialog.SelectedPath;
                    txtFolderPath.Text = folderPath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmBackupData_Load(object sender, EventArgs e)
        {
            string unit = Common.ReadFileContent(Common.pathCategory + fileUnitName);
            allUnits = new List<Unit>();
            allUnits = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Unit>>(unit);
            if (allUnits.Count > 1)
            {
                Unit unitAll = new Unit();
                unitAll.Name = "Tất cả";
                unitAll.Id = 0;
                allUnits.Add(unitAll);
            }

            cbxUnit.DataSource = allUnits;
            cbxUnit.DisplayMember = "Name";
            cbxUnit.ValueMember = "Id";
            //cbxUnit.Text = "Tất cả";
            cbxUnit.DropDownStyle = ComboBoxStyle.DropDownList;
            allUnits.RemoveAll(obj => obj.Id == 0);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace QuanLyNhanSu
{
    public partial class Login : Form
    {
        public bool isLogin;
        public int role;
        public Login()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUserName.Text;
                string password = txtPassword.Text;

                // Kiểm tra xem các trường đều không được để trống
                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string path = AppDomain.CurrentDomain.BaseDirectory + "Data\\Account\\";
                string filePath = path + username + ".txt";
                if (!File.Exists(filePath))
                {
                    MessageBox.Show("Vui lòng liên hệ người quản trị để tạo tài khoản", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Đọc nội dung từ tệp tin
                string content = File.ReadAllText(filePath);
                if (content == null)
                {
                    MessageBox.Show("Vui lòng liên hệ người quản trị để tạo tài khoản", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                content = Common.Decrypt(content);
                XmlDocument xmlDoc = new XmlDocument();
                // Load chuỗi XML vào XmlDocument
                xmlDoc.LoadXml(content);
                XmlNode elementNode = xmlDoc.SelectSingleNode("/Data/Password");

                // Kiểm tra xem thẻ có tồn tại không
                if (elementNode != null)
                {
                    // Lấy nội dung của thẻ
                    string elementValue = elementNode.InnerText;
                    if (elementValue != username.ToUpper() + password)
                    {
                        MessageBox.Show("Sai thông tin mật khẩu hoặc tài khoản", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Sai thông tin mật khẩu hoặc tài khoản", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                elementNode = xmlDoc.SelectSingleNode("/Data/Role");
                if (elementNode != null)
                {
                    // Lấy nội dung của thẻ
                    role = Int16.Parse(elementNode.InnerText);
                }
                else { role = 2; }
                isLogin = true;
                this.Close();
            }
            catch (Exception ex )
            {
                MessageBox.Show("Sai thông tin mật khẩu hoặc tài khoản", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}

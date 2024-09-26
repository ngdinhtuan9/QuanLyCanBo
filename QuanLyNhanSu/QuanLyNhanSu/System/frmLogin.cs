using QuanLyNhanSu.Entity;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyNhanSu
{
    public partial class frmLogin : Form
    {
        public bool isLogin;
        public string userName = "";
        public string role;
        string path = AppDomain.CurrentDomain.BaseDirectory + "Data\\Account\\Account.txt";
        List<User> allUser;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Login()
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
                //string path = AppDomain.CurrentDomain.BaseDirectory + "Data\\Account\\";
               // string filePath = path + username + ".txt";
                if (!File.Exists(path))
                {
                    MessageBox.Show("Vui lòng liên hệ người quản trị để tạo tài khoản", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Đọc nội dung từ tệp tin
               // string content = File.ReadAllText(filePath);

                if (allUser == null)
                {
                    MessageBox.Show("Vui lòng liên hệ người quản trị để tạo tài khoản", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                 var  user = allUser.First(item => item.UserName == username && item.Password == username + password);
                if (user == null)
                {
                    MessageBox.Show("Sai thông tin mật khẩu hoặc tài khoản", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                isLogin = true;
                role =  user.Role;
                Common.glbUnit = user.UnitName;
                Common.glbUserName = user.UserName;

                try
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(QLNSCommon.path + "Config.xml");
                    XmlNode root = xmlDoc.DocumentElement;
                    XmlNode userNameNode = root.SelectSingleNode("UserName");
                    if (userNameNode != null)
                    {
                        userNameNode.InnerText = Common.glbUserName; 
                    }
                    else
                    {
                        XmlElement newUserNameNode = xmlDoc.CreateElement("UserName");
                        newUserNameNode.InnerText = Common.glbUserName;
                        root.AppendChild(newUserNameNode);
                    }
                    xmlDoc.Save(QLNSCommon.path + "Config.xml");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating XML file: {ex.Message}");
                }
                 this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sai thông tin mật khẩu hoặc tài khoản", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Thực hiện quá trình đăng nhập ở đây
                Login();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Thực hiện quá trình đăng nhập ở đây
                Login();
            }
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Thực hiện quá trình đăng nhập ở đây
                Login();
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                txtUserName.Text = userName;
                //txtUserName.Multiline = true;
                //txtUserName.Width = 100;  
                //txtUserName.Height = 25;
                //txtUserName.Font = new Font("Arial", 16);
                string contentUser = Common.ReadFileContent(path);
                allUser = new List<User>();
                allUser = Newtonsoft.Json.JsonConvert.DeserializeObject<List<User>>(contentUser);
                txtUserName.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chưa có thông tin đăng nhập.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }
            
        }

        private void btnShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (btnShowPass.Checked)
            {
                txtPassword.PasswordChar = '\0'; // '\0' nghĩa là không có ký tự che dấu
            }
            else
            {
                txtPassword.PasswordChar = '*'; // Thiết lập lại ký tự che dấu
            }
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(Common.glbUserName == "")
            Application.Exit();
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
          //  txtPassForget.ForeColor = Color.Blue;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
           // txtPassForget.ForeColor = Color.Black;
        }

        private void txtPassForget_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng đang được hoàn thiện.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //try
            //{
            //    frmForgotPass frmDep = new frmForgotPass();
            //    // frmDep.TopLevel = false;
            //    frmDep.Show();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
    }
}

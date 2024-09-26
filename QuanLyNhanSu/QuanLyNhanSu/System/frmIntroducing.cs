using QuanLyNhanSu.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLyNhanSu
{
    public partial class frmIntroducing : Form
    {
        public bool isLogin;
        public string role;
        string path = AppDomain.CurrentDomain.BaseDirectory + "Data\\Account\\Account.txt";
        List<User> allUser;
        public frmIntroducing()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Login()
        {
            try
            {
                //string username = txtUserName.Text;
               // string password = txtPassword.Text;
                string firstThree = code.Substring(0, 3);
                string lastThree = code.Substring(code.Length - 3, 3);
                string textCompare = firstThree + lastThree;
                User user = null;
                //if (txtPassword.Text == textCompare)
                //{
                //   user = allUser.First(item => item.UserName == Common.glbUserName);
                //}
                //else
                //{
                //    MessageBox.Show("Chuỗi xác thực không chính xác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}

                if (user == null )
                {
                    MessageBox.Show("Không có thông tin tài khoản.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                user.Password = Common.glbUserName + Common.glbUserName + "@123";
                string str = Newtonsoft.Json.JsonConvert.SerializeObject(allUser);
                Common.SaveFileContent(path, str);
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
      
        string randomNumber = "";
        string code = "";
        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                label4.Text = "Năm 2024 ( Phiên bản " + QLNSCommon.glbVersion +")";
                label5.Text = "ĐT: " + QLNSCommon.glbContact;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chưa có thông tin đăng nhập.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }
            
        }

        private void btnShowPass_CheckedChanged(object sender, EventArgs e)
        {
            //if (btnShowPass.Checked)
            //{
            //    txtPassword.PasswordChar = '\0'; // '\0' nghĩa là không có ký tự che dấu
            //}
            //else
            //{
            //    txtPassword.PasswordChar = '*'; // Thiết lập lại ký tự che dấu
            //}
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
           // if(Common.glbUserName == "")
            //Application.Exit();
        }

        //private void label3_MouseEnter(object sender, EventArgs e)
        //{
        //    txtPassForget.ForeColor = Color.Blue;
        //}

        //private void label3_MouseLeave(object sender, EventArgs e)
        //{
        //    txtPassForget.ForeColor = Color.Black;
        //}

        private void txtPassForget_Click(object sender, EventArgs e)
        {
            
        }
    }
}

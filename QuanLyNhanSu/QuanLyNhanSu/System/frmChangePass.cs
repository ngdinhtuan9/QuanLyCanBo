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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLyNhanSu
{
    public partial class frmChangePass : Form
    {
        public string userName ="";
        public bool adminChangePass = false;
        string path = AppDomain.CurrentDomain.BaseDirectory + "Data\\Account\\Account.txt";
        List<User> allUser;
        public frmChangePass()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            try
            {
                if (!valid())
                {
                    return;
                }
                string username = txtUserName.Text;
                string oldPass = txtOldPass.Text;
                string password = txtPassword.Text;
                User user;
                if (!adminChangePass)
                {
                     user = allUser.First(item => item.UserName == username && item.Password == username + oldPass);
                }
                else 
                {
                    user = allUser.First(item => item.UserName == username);
                }


                if (user == null && !adminChangePass)
                {
                    MessageBox.Show("Sai thông tin mật khẩu cũ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return ;
                }
               
                    user.Password = username + password;
                    string str = Newtonsoft.Json.JsonConvert.SerializeObject(allUser);
                    Common.SaveFileContent(path, str);
                
                MessageBox.Show("Đổi mật khẩu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                if (ex.ToString().Contains("Sequence contains no matching element"))
                {
                    MessageBox.Show("Sai thông tin mật khẩu cũ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
       

        public Boolean valid()
        {
            try
            {
                string username = txtUserName.Text;
                string password = txtPassword.Text;
                string rePassword = txtRePassword.Text;

                // Kiểm tra xem các trường đều không được để trống
                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(rePassword))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                // Kiểm tra xem mật khẩu và mật khẩu nhập lại có khớp nhau không
                if (password != rePassword)
                {
                    MessageBox.Show("Mật khẩu và mật khẩu nhập lại không khớp nhau.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                // Kiểm tra độ dài tối thiểu của mật khẩu
                int minLength = 8; // Độ dài tối thiểu của mật khẩu
                if (password.Length < minLength)
                {
                    MessageBox.Show($"Mật khẩu phải có ít nhất {minLength} ký tự.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                // Kiểm tra xem mật khẩu có chứa ít nhất một chữ cái in hoa và một chữ cái thường không
                if (!password.Any(char.IsUpper) || !password.Any(char.IsLower))
                {
                    MessageBox.Show("Mật khẩu phải chứa ít nhất một chữ cái in hoa và một chữ cái thường.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

               

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
          
        }
        XmlNodeList nodeList;
        private void frmCreateAccount_Load(object sender, EventArgs e)
        {
            try
            {
                if (adminChangePass)
                {
                    txtOldPass.Enabled = false;
                }
                if(userName != "")
                {
                    txtUserName.Text = userName;
                }
                else
                txtUserName.Text = Common.glbUserName;
                //txtUserName.Text = "tuannd";
                txtUserName.ReadOnly = true;
                string contentUser = Common.ReadFileContent(path);
                allUser = new List<User>();
                allUser = Newtonsoft.Json.JsonConvert.DeserializeObject<List<User>>(contentUser);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }
            
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

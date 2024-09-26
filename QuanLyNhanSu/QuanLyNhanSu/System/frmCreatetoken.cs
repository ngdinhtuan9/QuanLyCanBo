using QuanLyNhanSu.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLyNhanSu
{
    public partial class frmCreatetoken : Form
    {
        public bool isLogin;
        public string role;
        string path = AppDomain.CurrentDomain.BaseDirectory + "Data\\Account\\Account.txt";
        List<User> allUser;
        public frmCreatetoken()
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
                string password = txtPassword.Text;
                if (password == "")
                {
                    MessageBox.Show("Chưa nhập chuỗi từ phía người dùng gửi lên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //label1.Text = randomNumber;
                code = EncodeNumber(password);
                string firstThree = code.Substring(0, 3);
                string lastThree = code.Substring(code.Length - 3, 3);
                string textCompare = firstThree + lastThree;
                label1.Text = textCompare;
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

       

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Thực hiện quá trình đăng nhập ở đây
                Login();
            }
        }
        static string EncodeNumber(string number)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Chuyển đổi số thành chuỗi và sau đó thành mảng byte
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(number.ToString()));

                // Chuyển đổi mảng byte thành chuỗi số
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("X2"));  // Chuyển đổi byte thành chuỗi số hexa
                }

                // Trả về chuỗi số đã mã hóa
                return builder.ToString();
            }
        }
        string randomNumber = "";
        string code = "";
        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                Random random = new Random();

                int number1 = random.Next(0, 10);  
                int number2 = random.Next(0, 10);  
                int number3 = random.Next(0, 10);
                int number4 = random.Next(0, 10);
                int number5 = random.Next(0, 10);
                // Kết hợp 3 số thành một chuỗi
                 randomNumber = $"{number1}{number2}{number3}{number4}{number5}";
                label1.Text = randomNumber;
                code = EncodeNumber(randomNumber);
                string contentUser = Common.ReadFileContent(path);
                allUser = new List<User>();
                allUser = Newtonsoft.Json.JsonConvert.DeserializeObject<List<User>>(contentUser);
               // txtUserName.Focus();
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
            //if(Common.glbUserName == "")
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

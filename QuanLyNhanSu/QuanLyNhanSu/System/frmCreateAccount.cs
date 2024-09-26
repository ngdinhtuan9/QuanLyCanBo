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
    public partial class frmCreateAccount : Form
    {
        string path = AppDomain.CurrentDomain.BaseDirectory + "Data\\Account\\Account.txt";
        List<User> allUser;

        List<Unit> allUnits;
        string fileUnitName = "Units\\Units.txt";
        public frmCreateAccount()
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
               
                string name = txtUserName.Text;
               // string filePath = Path.Combine(path, txtUserName.Text + ".txt");
                //if (!File.Exists(path))
                //{
                //    Directory.CreateDirectory(path);
                //}

                User user = new User();
                user.UserName = txtUserName.Text;
                user.Password = txtUserName.Text.Trim() + txtPassword.Text.Trim();
                user.Role = cbxRole.Text;
                user.UnitName = cbxUnit.Text;
                if (allUser == null) { allUser = new List<User>(); }
                allUser.Add(user);
                string str = Newtonsoft.Json.JsonConvert.SerializeObject(allUser);
                Common.SaveFileContent(path, str);
                MessageBox.Show("Tạo thành công tài khoản " + name + ".", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
         
        void CreateXmlFile(string filePath)
        {
           
           

            // Tạo một tài liệu XML mới
            //XmlDocument xmlDoc = new XmlDocument();

            //// Tạo phần tử gốc và thêm vào tài liệu
            //XmlElement root = xmlDoc.CreateElement("Data");
            //xmlDoc.AppendChild(root);

            //// Tạo các phần tử con và thêm chúng vào phần tử gốc
            //XmlElement item1 = xmlDoc.CreateElement("UserName");
            //item1.InnerText = txtUserName.Text;
            //root.AppendChild(item1);

            //XmlElement item2 = xmlDoc.CreateElement("Password");
            //item2.InnerText = txtUserName.Text.ToUpper() + txtPassword.Text;
            //root.AppendChild(item2);

            //XmlElement item3 = xmlDoc.CreateElement("Role");
            //string selectedText = cbxRole.Text;
            //if (selectedText != null)
            //{
            //    foreach (XmlNode node in nodeList)
            //    {
            //        string description = node.SelectSingleNode("Description").InnerText;
            //        if (selectedText == description)
            //            item3.InnerText = node.SelectSingleNode("Value").InnerText;
            //    }
            //}
            //root.AppendChild(item3);
            //string content = Common.Encrypt(xmlDoc.OuterXml);
           
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
                List<User> lstUser = allUser.FindAll(item => item.UserName == txtUserName.Text);
                if (lstUser.Count > 0)
                {
                    MessageBox.Show("Tên tài khoản đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                string unit = Common.ReadFileContent(QLNSCommon.pathCategory + fileUnitName);
                allUnits = new List<Unit>();
                allUnits = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Unit>>(unit);
                //if (Common.glbUnit != "Tất cả")
                //{
                //    allUnits
                //}    
                if (allUnits.Count > 1 && Common.glbUnit != "Tất cả")
                {
                    Unit unitAll = new Unit();
                    unitAll.Name = "Tất cả";
                    unitAll.Id = 0;
                    allUnits.Add(unitAll);
                }
                cbxUnit.DataSource = allUnits;
                cbxUnit.DisplayMember = "Name";
                cbxUnit.ValueMember = "Id";
                cbxUnit.Text = "Tất cả";
                cbxUnit.DropDownWidth = 400;
                cbxUnit.DropDownStyle = ComboBoxStyle.DropDownList;

                string contentUser = Common.ReadFileContent(path);
                allUser = new List<User>();
                allUser = Newtonsoft.Json.JsonConvert.DeserializeObject<List<User>>(contentUser);

                string pathRole = AppDomain.CurrentDomain.BaseDirectory + "Data\\Role\\";
                string name = txtUserName.Text;

                string filePath = Path.Combine(pathRole, "Role.xml");
                if (!File.Exists(filePath))
                {
                    MessageBox.Show("Chưa có thông tin quyền.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return ;
                }
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(filePath);

                // Lấy tất cả các thẻ <item> trong tệp tin XML
                 nodeList = xmlDoc.GetElementsByTagName("Infor");

                // Thêm các giá trị và mô tả từ các thẻ vào ComboBox
                foreach (XmlNode node in nodeList)
                {
                    string value = node.SelectSingleNode("Value").InnerText;
                    string description = node.SelectSingleNode("Description").InnerText;
                    cbxRole.Items.Add(description); 
                }
                cbxRole.SelectedIndex = 1;
                cbxRole.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }
            
        }
       
    }
}

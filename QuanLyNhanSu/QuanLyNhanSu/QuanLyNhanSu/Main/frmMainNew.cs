using QuanLyNhanSu.Category;
using QuanLyNhanSu.Entity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace QuanLyNhanSu.Main
{
    public partial class frmMainNew : Form
    {
        public frmMainNew()
        {
            InitializeComponent();
        }
        private ToolTip toolTip;
        private void mnuRegister_Click(object sender, EventArgs e)
        {
            var frmCreateAcc = new frmCreateAccount();
            frmCreateAcc.ShowDialog();
        }

        private void mnuLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var frmLogin = new frmLogin();
                frmLogin.ShowDialog();
                if (frmLogin.isLogin)
                {
                    if (frmLogin.role == "Quản trị")
                    {
                        mnuSystem.Enabled = true;
                        mnuBussiness.Enabled = true;
                        mnuReport.Enabled = true;
                        MnuLists.Visible = true;
                        mnuRegister.Visible = true;
                        mnuUnits.Visible = true;
                        mnuLevel.Visible = true;    
                        mnuSchool.Visible = true;
                        mnuPosition.Visible = true;
                        mnuAcademicLevel.Visible = true;
                        trìnhĐộLLCTToolStripMenuItem.Visible = true;
                        mnuResponsible.Visible = true;
                        btnFostering.Visible = true;
                        mnuFosteringQPAN.Visible = true;
                        mnuClassify.Visible = true;
                        mnuPoliticalLevelForm.Visible = true;
                        mnuTittle.Visible   = true;
                        mnuCompetition.Visible = true;
                        mnuTraningType.Visible = true;
                        mnuFosteringType.Visible = true;

                    }
                    else if (frmLogin.role == "Người dùng")
                    {
                        mnuSystem.Enabled = true;
                        mnuBussiness.Enabled = true;
                        mnuReport.Enabled = true;
                        MnuLists.Visible = true;
                        mnuRegister.Visible = false;
                        mnuUnits.Visible = false;
                        mnuLevel.Visible = false;
                        mnuSchool.Visible = false;
                        mnuPosition.Visible = false;
                        mnuAcademicLevel.Visible = false;
                        trìnhĐộLLCTToolStripMenuItem.Visible = false;
                        mnuResponsible.Visible = false;
                        btnFostering.Visible = false;
                        mnuFosteringQPAN.Visible = false;
                        mnuClassify.Visible = false;
                        mnuPoliticalLevelForm.Visible = false;
                        mnuTittle.Visible = false;
                        mnuCompetition.Visible = false;
                        mnuTraningType.Visible = false;
                        mnuFosteringType.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuUnits_Click(object sender, EventArgs e)
        {
            try
            {
                frmUnits frmUnit = new frmUnits();
                frmUnit.TopLevel = false;
                pictureBox3.Controls.Add(frmUnit);
                frmUnit.Location = new Point(
                   (pictureBox3.Width - frmUnit.Width) / 2,
                   (pictureBox3.Height - frmUnit.Height) / 2
               );
                frmUnit.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuLevel_Click(object sender, EventArgs e)
        {
            try
            {
                frmLevel frmLevel = new frmLevel();
                frmLevel.TopLevel = false;
                pictureBox3.Controls.Add(frmLevel);
                frmLevel.Location = new Point(
                   (pictureBox3.Width - frmLevel.Width) / 2,
                   (pictureBox3.Height - frmLevel.Height) / 2
               );
                frmLevel.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuDepartment_Click(object sender, EventArgs e)
        {
            try
            {
                frmDepartment frmDep = new frmDepartment();
                frmDep.TopLevel = false;
                pictureBox3.Controls.Add(frmDep);
                frmDep.Location = new Point(
                   (pictureBox3.Width - frmDep.Width) / 2,
                   (pictureBox3.Height - frmDep.Height) / 2
               );
                frmDep.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuPosition_Click(object sender, EventArgs e)
        {
            try
            {
                frmPosition frmDep = new frmPosition();
                frmDep.TopLevel = false;
                pictureBox3.Controls.Add(frmDep);
                frmDep.Location = new Point(
                   (pictureBox3.Width - frmDep.Width) / 2,
                   (pictureBox3.Height - frmDep.Height) / 2
               );
                frmDep.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuAcademicLevel_Click(object sender, EventArgs e)
        {
            try
            {
                frmAcademicLevel frmDep = new frmAcademicLevel();
                frmDep.TopLevel = false;
                pictureBox3.Controls.Add(frmDep);
                frmDep.Location = new Point(
                   (pictureBox3.Width - frmDep.Width) / 2,
                   (pictureBox3.Height - frmDep.Height) / 2
               );
                frmDep.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuResponsible_Click(object sender, EventArgs e)
        {
            try
            {
                frmResponsible frmDep = new frmResponsible();
                frmDep.TopLevel = false;
                pictureBox3.Controls.Add(frmDep);
                frmDep.Location = new Point(
                   (pictureBox3.Width - frmDep.Width) / 2,
                   (pictureBox3.Height - frmDep.Height) / 2
               );
                frmDep.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void trìnhĐộLLCTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmPoliticalLevel frmDep = new frmPoliticalLevel();
                frmDep.TopLevel = false;
                pictureBox3.Controls.Add(frmDep);
                frmDep.Location = new Point(
                   (pictureBox3.Width - frmDep.Width) / 2,
                   (pictureBox3.Height - frmDep.Height) / 2
               );
                frmDep.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuManagerment_Click(object sender, EventArgs e)
        {
            try
            {
                frmPerson frmDep = new frmPerson();
                frmDep.TopLevel = false;
                pictureBox3.Controls.Add(frmDep);
                frmDep.Location = new Point(
                   (pictureBox3.Width - frmDep.Width) / 2,
                   (pictureBox3.Height - frmDep.Height) / 2
               );
                frmDep.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuChangePass_Click(object sender, EventArgs e)
        {
            try
            {
                frmChangePass frmDep = new frmChangePass();
                frmDep.TopLevel = false;
                pictureBox3.Controls.Add(frmDep);
                frmDep.Location = new Point(
                   (pictureBox3.Width - frmDep.Width) / 2,
                   (pictureBox3.Height - frmDep.Height) / 2
               );
                frmDep.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmMainNew_Load(object sender, EventArgs e)
        {
            try
            {
                string filePath = QLNSCommon.path  + "Config.xml";
                try
                {
                    // Tạo đối tượng XmlDocument và tải file XML
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(filePath);

                    // Lấy các giá trị từ XML với kiểm tra null
                    XmlNode root = xmlDoc.DocumentElement;

                    QLNSCommon.glbVersion = root.SelectSingleNode("Version")?.InnerText ?? "1.0.1";
                    QLNSCommon.glbUserCache = root.SelectSingleNode("UserName")?.InnerText ?? "";
                    QLNSCommon.glbContact = root.SelectSingleNode("Contact")?.InnerText ?? "";

                }
                catch (Exception)
                {
                    MessageBox.Show("Không đọc được thông tin file cấu hình.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                this.Text = "PHẦN MỀM QUẢN LÝ TRÌNH ĐỘ ĐÀO TẠO CÁN BỘ TRONG BIÊN CHẾ K02  (Phòng tổ chức cán bộ) Version " + QLNSCommon.glbVersion ;
                pictureBoxExit.BackColor = Color.LightGray;
                pictureBox1.BackColor = Color.LightGray;
                pictureBox2.BackColor = Color.LightGray;
                this.WindowState = FormWindowState.Maximized;
                toolTip = new ToolTip();
                toolTip.SetToolTip(pictureBox1, "Thêm mới cán bộ.");
                toolTip.SetToolTip(pictureBox2, "Danh sách cán bộ.");
                toolTip.SetToolTip(pictureBox4, "Đổi mật khẩu.");
                toolTip.SetToolTip(pictureBoxExit, "Thoát.");
                if (Common.glbUserName == "")
                {
                    var frmLogin = new frmLogin();
                    frmLogin.userName = QLNSCommon.glbUserCache;
                    frmLogin.ShowDialog();
                    if (frmLogin.isLogin)
                    {
                        if (frmLogin.role == "Quản trị")
                        {
                            mnuAccountManager.Visible = true;
                            mnuSystem.Enabled = true;
                            mnuDepartment.Text = "2. Đơn vị trực thuộc";
                            mnuBussiness.Enabled = true;
                            mnuReport.Enabled = true;
                            MnuLists.Visible = true;
                            mnuRegister.Visible = true;
                            mnuUnits.Visible = true;
                            mnuLevel.Visible = true;
                            mnuSchool.Visible = true;
                            mnuPosition.Visible = true;
                            mnuAcademicLevel.Visible = true;
                            trìnhĐộLLCTToolStripMenuItem.Visible = true;
                            mnuResponsible.Visible = true;
                            btnFostering.Visible = true;
                            mnuFosteringQPAN.Visible = true;
                            mnuClassify.Visible = true;
                            mnuPoliticalLevelForm.Visible = true;
                            mnuTittle.Visible = true;
                            mnuCompetition.Visible = true;
                            mnuTraningType.Visible = true;
                            mnuFosteringType.Visible = true;
                        }
                        else if (frmLogin.role == "Người dùng")
                        {
                            mnuAccountManager.Visible = false;
                            mnuSystem.Enabled = true;
                            mnuDepartment.Text = "1. Đơn vị trực thuộc";
                            mnuBussiness.Enabled = true;
                            mnuReport.Enabled = true;
                            MnuLists.Visible = true;
                            mnuRegister.Visible = false;
                            mnuUnits.Visible = false;
                            mnuLevel.Visible = false;
                            mnuSchool.Visible = false;
                            mnuPosition.Visible = false;
                            mnuAcademicLevel.Visible = false;
                            trìnhĐộLLCTToolStripMenuItem.Visible = false;
                            mnuResponsible.Visible = false;
                            btnFostering.Visible = false;
                            mnuFosteringQPAN.Visible = false;
                            mnuClassify.Visible = false;
                            mnuPoliticalLevelForm.Visible = false;
                            mnuTittle.Visible = false;
                            mnuCompetition.Visible = false;
                            mnuTraningType.Visible = false;
                            mnuFosteringType.Visible = false;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuAddNewPerson_Click(object sender, EventArgs e)
        {
            try
            {
                List<Unit> allUnits;
                string fileUnitName = "Units\\Units.txt";

                List<TranningProcess> allTranningProcess;
                string fileTranningProcess = "TranningProcess\\TranningProcess.txt";

                List<FosteringProcess> allFosteringProcess;
                string fileFosteringProcess = "FosteringProcess\\FosteringProcess.txt";

                string fileName = "Person\\Person.txt";
                List<Person> allperson;
                string content = Common.ReadFileContent(QLNSCommon.pathManagerment + fileName);
                allperson = new List<Person>();
                allperson = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Person>>(content);

                string unit = Common.ReadFileContent(QLNSCommon.pathCategory + fileUnitName);
                allUnits = new List<Unit>();
                allUnits = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Unit>>(unit);

                string contentTranningProcess = Common.ReadFileContent(QLNSCommon.pathManagerment + fileTranningProcess);
                allTranningProcess = new List<TranningProcess>();
                allTranningProcess = Newtonsoft.Json.JsonConvert.DeserializeObject<List<TranningProcess>>(contentTranningProcess);

                string contentFosteringProcess = Checking.CheckNullString(Common.ReadFileContent(QLNSCommon.pathManagerment + fileFosteringProcess));
                allFosteringProcess = new List<FosteringProcess>();
                allFosteringProcess = Newtonsoft.Json.JsonConvert.DeserializeObject<List<FosteringProcess>>(contentFosteringProcess);

                int maxID = 0;
                if (allperson != null && allperson.Count > 0) { maxID = allperson.Max(obj => obj.Id); }
                else
                {
                    allperson = new List<Person>();
                    maxID = 1;
                }
                frmPersonDetail frmDetail = new frmPersonDetail();
                frmDetail.maxpersonId = maxID;
                frmDetail.allUnits = allUnits;
                frmDetail.allFosteringProcess = allFosteringProcess;
                frmDetail.allTranningProcess = allTranningProcess;
                frmDetail.allperson = allperson;
                frmDetail.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuSchool_Click(object sender, EventArgs e)
        {
            try
            {
                frmSchool frmDep = new frmSchool();
                frmDep.TopLevel = false;
                pictureBox3.Controls.Add(frmDep);
                frmDep.Location = new Point(
                   (pictureBox3.Width - frmDep.Width) / 2,
                   (pictureBox3.Height - frmDep.Height) / 2
               );
                frmDep.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuBackup_Click(object sender, EventArgs e)
        {
            try
            {
                frmBackupData frmDep = new frmBackupData();
                frmDep.TopLevel = false;
                pictureBox3.Controls.Add(frmDep);
                frmDep.Location = new Point(
                   (pictureBox3.Width - frmDep.Width) / 2,
                   (pictureBox3.Height - frmDep.Height) / 2
               );
                frmDep.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuRestore_Click(object sender, EventArgs e)
        {
            try
            {
                frmRestoreData frmDep = new frmRestoreData();
                frmDep.TopLevel = false;
                pictureBox3.Controls.Add(frmDep);
                frmDep.Location = new Point(
                   (pictureBox3.Width - frmDep.Width) / 2,
                   (pictureBox3.Height - frmDep.Height) / 2
               );
                frmDep.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                List<Unit> allUnits;
                string fileUnitName = "Units\\Units.txt";

                List<TranningProcess> allTranningProcess;
                string fileTranningProcess = "TranningProcess\\TranningProcess.txt";

                List<FosteringProcess> allFosteringProcess;
                string fileFosteringProcess = "FosteringProcess\\FosteringProcess.txt";

                string fileName = "Person\\Person.txt";
                List<Person> allperson;
                string content = Common.ReadFileContent(QLNSCommon.pathManagerment + fileName);
                allperson = new List<Person>();
                allperson = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Person>>(content);

                string unit = Common.ReadFileContent(QLNSCommon.pathCategory + fileUnitName);
                allUnits = new List<Unit>();
                allUnits = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Unit>>(unit);

                string contentTranningProcess = Common.ReadFileContent(QLNSCommon.pathManagerment + fileTranningProcess);
                allTranningProcess = new List<TranningProcess>();
                allTranningProcess = Newtonsoft.Json.JsonConvert.DeserializeObject<List<TranningProcess>>(contentTranningProcess);

                string contentFosteringProcess = Checking.CheckNullString(Common.ReadFileContent(QLNSCommon.pathManagerment + fileFosteringProcess));
                allFosteringProcess = new List<FosteringProcess>();
                allFosteringProcess = Newtonsoft.Json.JsonConvert.DeserializeObject<List<FosteringProcess>>(contentFosteringProcess);

                int maxID = 0;
                if (allperson != null && allperson.Count > 0) { maxID = allperson.Max(obj => obj.Id); }
                else
                {
                    allperson = new List<Person>();
                    maxID = 1;
                }
                frmPersonDetail frmDetail = new frmPersonDetail();
                frmDetail.maxpersonId = maxID;
                frmDetail.allUnits = allUnits;
                frmDetail.allFosteringProcess = allFosteringProcess;
                frmDetail.allTranningProcess = allTranningProcess;
                frmDetail.allperson = allperson;
                frmDetail.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.LightGreen;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.LightGray;
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.LightGreen;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.LightGray;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                frmPerson frmDep = new frmPerson();
                frmDep.TopLevel = false;
                pictureBox3.Controls.Add(frmDep);
                frmDep.Location = new Point(
                   (pictureBox3.Width - frmDep.Width) / 2,
                   (pictureBox3.Height - frmDep.Height) / 2
               );
                frmDep.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnFostering_Click(object sender, EventArgs e)
        {
            try
            {
                frmFostering frmDep = new frmFostering();
                frmDep.TopLevel = false;
                pictureBox3.Controls.Add(frmDep);
                frmDep.Location = new Point(
                   (pictureBox3.Width - frmDep.Width) / 2,
                   (pictureBox3.Height - frmDep.Height) / 2
               );
                frmDep.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBoxExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void pictureBox1_MouseLeave_1(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.LightGray;
        }

        private void pictureBox1_MouseEnter_1(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.LightGreen;
        }

        private void pictureBoxExit_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxExit.BackColor = Color.LightGray;
        }

        private void pictureBoxExit_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxExit.BackColor = Color.LightGreen;
        }

        private void mnuFosteringQPAN_Click(object sender, EventArgs e)
        {
            try
            {
                frmFosteringQPAN frmDep = new frmFosteringQPAN();
                frmDep.TopLevel = false;
                pictureBox3.Controls.Add(frmDep);
                frmDep.Location = new Point(
                   (pictureBox3.Width - frmDep.Width) / 2,
                   (pictureBox3.Height - frmDep.Height) / 2
               );
                frmDep.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuClassify_Click(object sender, EventArgs e)
        {
            try
            {
                frmClassify frmDep = new frmClassify();
                frmDep.TopLevel = false;
                pictureBox3.Controls.Add(frmDep);
                frmDep.Location = new Point(
                   (pictureBox3.Width - frmDep.Width) / 2,
                   (pictureBox3.Height - frmDep.Height) / 2
               );
                frmDep.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            try
            {
                List<Unit> allUnits;
                string fileUnitName = "Units\\Units.txt";

                List<TranningProcess> allTranningProcess;
                string fileTranningProcess = "TranningProcess\\TranningProcess.txt";

                List<FosteringProcess> allFosteringProcess;
                string fileFosteringProcess = "FosteringProcess\\FosteringProcess.txt";

                string fileName = "Person\\Person.txt";
                List<Person> allperson;
                string content = Common.ReadFileContent(QLNSCommon.pathManagerment + fileName);
                allperson = new List<Person>();
                allperson = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Person>>(content);

                string unit = Common.ReadFileContent(QLNSCommon.pathCategory + fileUnitName);
                allUnits = new List<Unit>();
                allUnits = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Unit>>(unit);

                string contentTranningProcess = Common.ReadFileContent(QLNSCommon.pathManagerment + fileTranningProcess);
                allTranningProcess = new List<TranningProcess>();
                allTranningProcess = Newtonsoft.Json.JsonConvert.DeserializeObject<List<TranningProcess>>(contentTranningProcess);

                string contentFosteringProcess = Checking.CheckNullString(Common.ReadFileContent(QLNSCommon.pathManagerment + fileFosteringProcess));
                allFosteringProcess = new List<FosteringProcess>();
                allFosteringProcess = Newtonsoft.Json.JsonConvert.DeserializeObject<List<FosteringProcess>>(contentFosteringProcess);

                int maxID = 0;
                if (allperson != null && allperson.Count > 0) { maxID = allperson.Max(obj => obj.Id); }
                else
                {
                    allperson = new List<Person>();
                    maxID = 1;
                }
                QLNSCommon.CloseFormIfOpen(typeof(frmPerson));
                frmPersonDetail frmDetail = new frmPersonDetail();
                frmDetail.maxpersonId = maxID;
                frmDetail.allUnits = allUnits;
                frmDetail.allFosteringProcess = allFosteringProcess;
                frmDetail.allTranningProcess = allTranningProcess;
                frmDetail.allperson = allperson;
                frmDetail.ShowDialog();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GetData()
        {
            try
            {
                string fileName = "Person\\Person.txt";
                List<Person> allperson;
                string content = Common.ReadFileContent(QLNSCommon.pathManagerment + fileName);
                allperson = new List<Person>();
                allperson = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Person>>(content);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
        private void mnuPoliticalLevelForm_Click(object sender, EventArgs e)
        {
            try
            {
                frmPoliticalLevelForm frmDep = new frmPoliticalLevelForm();
                frmDep.TopLevel = false;
                pictureBox3.Controls.Add(frmDep);
                frmDep.Location = new Point(
                   (pictureBox3.Width - frmDep.Width) / 2,
                   (pictureBox3.Height - frmDep.Height) / 2
               );
                frmDep.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuTittle_Click(object sender, EventArgs e)
        {
            try
            {
                frmTittle frmDep = new frmTittle();
                frmDep.TopLevel = false;
                pictureBox3.Controls.Add(frmDep);
                frmDep.Location = new Point(
                   (pictureBox3.Width - frmDep.Width) / 2,
                   (pictureBox3.Height - frmDep.Height) / 2
               );
                frmDep.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuCompetition_Click(object sender, EventArgs e)
        {
            try
            {
                frmCompetition frmDep = new frmCompetition();
                frmDep.TopLevel = false;
                pictureBox3.Controls.Add(frmDep);
                frmDep.Location = new Point(
                   (pictureBox3.Width - frmDep.Width) / 2,
                   (pictureBox3.Height - frmDep.Height) / 2
               );
                frmDep.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuListPerson_Click(object sender, EventArgs e)
        {
            try
            {
                frmReport frmDep = new frmReport();
                frmDep.TopLevel = false;
                pictureBox3.Controls.Add(frmDep);
                frmDep.Location = new Point(
                   (pictureBox3.Width - frmDep.Width) / 2,
                   (pictureBox3.Height - frmDep.Height) / 2
               );
                frmDep.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuAccountManager_Click(object sender, EventArgs e)
        {
            try
            {
                frmAccount frmDep = new frmAccount();
                frmDep.TopLevel = false;
                pictureBox3.Controls.Add(frmDep);
                frmDep.Location = new Point(
                   (pictureBox3.Width - frmDep.Width) / 2,
                   (pictureBox3.Height - frmDep.Height) / 2
               );
                frmDep.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            try
            {
                frmChangePass frmDep = new frmChangePass();
                frmDep.TopLevel = false;
                pictureBox3.Controls.Add(frmDep);
                frmDep.Location = new Point(
                   (pictureBox3.Width - frmDep.Width) / 2,
                   (pictureBox3.Height - frmDep.Height) / 2
               );
                frmDep.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.LightGreen;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.LightGray;
        }

        private void mnuIntro_Click(object sender, EventArgs e)
        {
            try
            {
                frmIntroducing frmDep = new frmIntroducing();
                frmDep.TopLevel = false;
                pictureBox3.Controls.Add(frmDep);
                frmDep.Location = new Point(
                   (pictureBox3.Width - frmDep.Width) / 2,
                   (pictureBox3.Height - frmDep.Height) / 2
               );
                frmDep.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuTraningType_Click(object sender, EventArgs e)
        {
            try
            {
                frmTraningProcessType frmDep = new frmTraningProcessType();
                frmDep.TopLevel = false;
                pictureBox3.Controls.Add(frmDep);
                frmDep.Location = new Point(
                   (pictureBox3.Width - frmDep.Width) / 2,
                   (pictureBox3.Height - frmDep.Height) / 2
               );
                frmDep.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

   
        private void hệĐàoTạoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmTraningFosteringType frmDep = new frmTraningFosteringType();
                frmDep.TopLevel = false;
                pictureBox3.Controls.Add(frmDep);
                frmDep.Location = new Point(
                   (pictureBox3.Width - frmDep.Width) / 2,
                   (pictureBox3.Height - frmDep.Height) / 2
               );
                frmDep.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
    }
}

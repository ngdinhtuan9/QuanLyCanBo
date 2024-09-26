using Newtonsoft.Json.Linq;
using QuanLyNhanSu.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyNhanSu.HuanLuyenDauKhoa
{
    public partial class frmChiTietHuanLuyen : Form
    {
        public Person person;
        string fileNameAllperson = "Person\\Person.txt";
        public List<Person> allperson;
        public int personId = 0;
        public int maxpersonId = 0;
        public bool succesed;
        public string personCode;

        public List<Unit> allUnits;
        string fileUnitName = "Units\\Units.txt";

        string fileDepartmentName = "Department\\Department.txt";
        List<Department> allDepartment;

        List<Responsible> allResponsible;
        string fileResponsibleName = "Responsible\\Responsible.txt";

        List<Level> allLevel;
        string fileNameLevel = "level\\level.txt";

        List<PoliticalLevel> allPoliticalLevel;
        string fileNamePoliticalLevel = "PoliticalLevel\\PoliticalLevel.txt";

        List<PoliticalLevelForm> allPoliticalLevelForm;
        string fileNamePoliticalLevelForm = "PoliticalLevelForm\\PoliticalLevelForm.txt";

        List<AcademicLevel> allAcademicLevel;
        string fileNameAcademicLevel = "AcademicLevel\\AcademicLevel.txt";


        List<Position> allPosition;
        string fileNamePosition = "Position\\Position.txt";

        List<Classify> allClassify;
        string fileNameClassify = "Classify\\Classify.txt";

        List<Competition> allCompetition;
        string fileNameCompetition = "Competition\\Competition.txt";

        List<Tittle> allTittle;
        string fileNameTittle = "Tittle\\Tittle.txt";


        public List<TranningProcess> allTranningProcess;
        string fileTranningProcess = "TranningProcess\\TranningProcess.txt";

        public List<FosteringProcess> allFosteringProcess;
        string fileFosteringProcess = "FosteringProcess\\FosteringProcess.txt";
        bool edit = false;
        bool load = false;
        public frmChiTietHuanLuyen()
        {
            InitializeComponent();
        }

        private void frmUnitDetail_Load(object sender, EventArgs e)
        {
            try
            {
                panel2.Dock = DockStyle.Fill; // Panel sẽ chiếm toàn bộ form
                panel2.AutoScroll = true;

                foreach (Control control in this.Controls)
                {
                    control.Width = (int)(this.Width * (control.Width / (double)this.ClientSize.Width));
                    control.Height = (int)(this.Height * (control.Height / (double)this.ClientSize.Height));
                    control.Left = (int)(this.Width * (control.Left / (double)this.ClientSize.Width));
                    control.Top = (int)(this.Height * (control.Top / (double)this.ClientSize.Height));
                }

                load = true;
                txtCode.Focus();
                DtDateOfBird.Value = DateTime.Now.AddYears(-18);

               
              
              


                //trinh do LLCT
                string contentPoliticalLevel = Common.ReadFileContent(QLNSCommon.pathCategory + fileNamePoliticalLevel);
                allPoliticalLevel = new List<PoliticalLevel>();
                allPoliticalLevel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<PoliticalLevel>>(contentPoliticalLevel);
               


                if (person != null)
                {
                    personId = person.Id;
                    txtCode.Text = person.Code;
                    txtIdentityCard.Text = person.IdentityCard;
                   
                    txtCode.ReadOnly = true;
                    txtFullName.Text = person.FullName;
                   
                    DtDateOfBird.Value = Common.ConvertStringToDate(person.DateOfBird);
                    //txtAddress.Text = person.Address;
                    txtHometown.Text = person.Hometown;
                 
                   
                }
                else
                {
                    person = new Person();
                    txtCode.Text = "";
                    txtIdentityCard.Text = "";
                    txtFullName.Text = "";
                  
                    txtHometown.Text = "";
                   
                    // dataGridView1.DataSource = allTranningProcess;
                    // dataGridView2.DataSource = allFosteringProcess;
                }
                if (person != null && Checking.CheckNullString(person.Code) != "")
                {
                   
                    edit = false;
                    btnSave.Enabled = false;
                }
                load = false;
            }
            catch (Exception ex)
            {
                succesed = false;
                MessageBox.Show("Lỗi trong quá trình xử lý dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void save(bool savebtn)
        {
            person.Code = txtCode.Text.Trim();
            person.IdentityCard = txtIdentityCard.Text.Trim();
            person.FullName = txtFullName.Text;
           
            person.DateOfBird = Common.ConvertDateToString(DtDateOfBird.Value.Date);
           
            person.Hometown = txtHometown.Text;


            if (person.Id == 0 && maxpersonId >= 0)
            {
                person.Id = maxpersonId + 1;
                personId = person.Id;
                allperson.RemoveAll(obj => obj.Code == person.Code);
                allperson.Add(person);
            }
            //else
            //{
            string str = Newtonsoft.Json.JsonConvert.SerializeObject(allperson);
            Common.SaveFileContent(QLNSCommon.pathManagerment + fileNameAllperson, str);
            txtCode.ReadOnly = true;
            // }
            if (savebtn)
            {
                edit = false;
                MessageBox.Show("Lưu dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private void save()
        {
            if (!valid()) { succesed = true; return; }
            save(true);
            succesed = true;
            edit = false;
            btnSave.Enabled = false;
            this.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                save();
            }
            catch (Exception ex)
            {
                succesed = false;
                MessageBox.Show("Lỗi trong quá trình xử lý dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (edit)
            {
                var result = MessageBox.Show("Dữ liệu chưa được lưu, bạn có muốn lưu dữ liệu không ? ", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (result == DialogResult.OK)
                {
                    save();  
                    Close();
                }
                else if (result == DialogResult.Cancel)
                {
                    btnSave.Enabled = false;
                    edit = false;
                    Close();
                   
                }
            }
            else
            {
                btnSave.Enabled = false;
                Close();
            }

        }

       
        

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                string index = (e.RowIndex + 1).ToString();
                DataGridView dgv = sender as DataGridView;
                Brush brush = SystemBrushes.ControlText;
                DataGridViewCell cell = dgv.Rows[e.RowIndex].Cells["STT"];
                if (cell.Value == null)
                    cell.Value = index;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi trong quá trình xử lý dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                string index = (e.RowIndex + 1).ToString();
                DataGridView dgv = sender as DataGridView;
                Brush brush = SystemBrushes.ControlText;
                DataGridViewCell cell = dgv.Rows[e.RowIndex].Cells["STTBD"];
                if (cell.Value == null)
                    cell.Value = index;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi trong quá trình xử lý dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool valid()
        {
            try
            {
                if (txtCode.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập số hiệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCode.Focus();
                    return false;
                };
                var personCode = allperson.FirstOrDefault(item => item.Code == txtCode.Text);
                string code = txtCode.Text;
                Person person = allperson.FirstOrDefault(obj => obj.Code == code);
                if (person != null && maxpersonId != 0)
                {
                    MessageBox.Show("Trùng số hiệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCode.Focus();
                    return false;
                }
                if (txtFullName.Text == "")
                {
                    txtFullName.Focus();
                    return false;
                };
                if (DtDateOfBird.Value > DateTime.Now.AddYears(-18))
                {
                    MessageBox.Show("Ngày sinh không phù hợp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DtDateOfBird.Focus();
                    return false;
                };
                if (txtHometown.Text == "")
                {
                    MessageBox.Show("Bạn phải nhập quê quán.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtHometown.Focus();
                    return false;
                };

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }
       

     

       
       
       

      

       
       

      
       
       
        private void cbxFosteringPLNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!load)
            {
                edit = true;
                btnSave.Enabled = true;
            }
        }

       
       
        private void txtFullName_TextChanged(object sender, EventArgs e)
        {
            // Lấy vị trí con trỏ hiện tại
            int selectionStart = txtFullName.SelectionStart;

            // Chuyển đổi chữ cái đầu tiên và sau dấu cách thành chữ hoa
            string text = txtFullName.Text;
            if (text.Length > 0)
            {
                text = char.ToUpper(text[0]) + text.Substring(1);
                for (int i = 1; i < text.Length; i++)
                {
                    if (char.IsWhiteSpace(text[i - 1]) && !char.IsWhiteSpace(text[i]))
                    {
                        text = text.Substring(0, i) + char.ToUpper(text[i]) + text.Substring(i + 1);
                    }
                }
            }
            txtFullName.Text = text;
            // Đặt lại vị trí con trỏ
            txtFullName.SelectionStart = selectionStart;
            if (!load)
            {
                edit = true;
                btnSave.Enabled = true;
            }
        }

        private void txtHometown_TextChanged(object sender, EventArgs e)
        {
            if (!load)
            {
                edit = true;
                btnSave.Enabled = true;
            }
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

            if (!load)
            {
                edit = true;
                btnSave.Enabled = true;
            }
        }

        private void cbxResponsible_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!load)
            {
                edit = true;
                btnSave.Enabled = true;
            }
        }

        private void dteYearBegin_ValueChanged(object sender, EventArgs e)
        {
            
            if (!load)
            {
                edit = true;
                btnSave.Enabled = true;
               // dteYearBegin.Format = DateTimePickerFormat.Short;
                // dteCommunistPartyBegin.Value = Common.ConvertStringToDate(person.CommunistPartyBegin);
            }
        }

        private void dteOfficialStartYear_ValueChanged(object sender, EventArgs e)
        {

            if (!load)
            {
                edit = true;
                btnSave.Enabled = true;
              //  dteOfficialStartYear.Format = DateTimePickerFormat.Short;
                // dteCommunistPartyBegin.Value = Common.ConvertStringToDate(person.CommunistPartyBegin);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            edit = true;
            btnSave.Enabled = true;
            if (!load)
            {
               // dteCommunistPartyBegin.Format = DateTimePickerFormat.Short;
                // dteCommunistPartyBegin.Value = Common.ConvertStringToDate(person.CommunistPartyBegin);
            }

        }

        private void cbxLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!load)
            {
                edit = true;
                btnSave.Enabled = true;
                btnSave.Enabled = true;
            }
        }

        private void cbxInternalSchool_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!load)
            {
                edit = true;
                btnSave.Enabled = true;
            }
        }

        private void cbxCurInternalSchool_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!load)
            {
                edit = true;
                btnSave.Enabled = true;
            }
        }

        private void cbxTittleTraning_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!load)
            {
                edit = true;
                btnSave.Enabled = true;
            }
        }

        private void cbxTittleTraningPlanning_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!load)
            {
                edit = true;
                btnSave.Enabled = true;
            }
        }

        private void cbxFosteringQPA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!load)
            {
                edit = true;
                btnSave.Enabled = true;
            }
        }

        private void cbxPoliticalLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!load)
            {
                edit = true;
                btnSave.Enabled = true;
            }
        }

        private void cbxDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rtbNote_TextChanged(object sender, EventArgs e)
        {
            if (!load)
            {
                edit = true;
                btnSave.Enabled = true;
            }
        }

       

       

      

        private void dteCommunistPartyBegin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {

              //  dteCommunistPartyBegin.CustomFormat = " ";
            }
            if (e.KeyCode == Keys.Back)
            {

              //  dteCommunistPartyBegin.CustomFormat = " ";
            }
        }

        private void dteOfficialStartYear_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {

               // dteOfficialStartYear.CustomFormat = " ";
            }
            if (e.KeyCode == Keys.Back)
            {

              //  dteOfficialStartYear.CustomFormat = " ";
            }
        }

        private void dteYearBegin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {

               // dteYearBegin.CustomFormat = " ";
            }
            if (e.KeyCode == Keys.Back)
            {

               // dteYearBegin.CustomFormat = " ";
            }
        }

        private void frmPersonDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnSave.Enabled == true)
            {
                var result = MessageBox.Show("Dữ liệu chưa được lưu, bạn có muốn lưu dữ liệu không ? ", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (result == DialogResult.OK)
                {

                    save();
                    edit = false;
                    Close();
                }
                else if (result == DialogResult.Cancel)
                {
                    edit = false;
                    btnSave.Enabled = false;
                    Close();
                   
                }
                return;
            }
        }

       
        private void mtbYearBegin_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            MaskedTextBox maskedTextBox = sender as MaskedTextBox;

            if (e.KeyCode == Keys.Tab)
            {
                // Move to next section if Tab is pressed
                int currentPosition = maskedTextBox.SelectionStart;
                if (currentPosition == 2 || currentPosition == 5)
                {
                    maskedTextBox.SelectionStart = currentPosition + 1;
                    maskedTextBox.SelectionLength = 0;
                    e.IsInputKey = true;
                }

                // Prevent the default Tab behavior

            }
        }

        private void mtbOfficialStartYear_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            MaskedTextBox maskedTextBox = sender as MaskedTextBox;

            if (e.KeyCode == Keys.Tab)
            {
                // Move to next section if Tab is pressed
                int currentPosition = maskedTextBox.SelectionStart;
                if (currentPosition == 2 || currentPosition == 5)
                {
                    maskedTextBox.SelectionStart = currentPosition + 1;
                    maskedTextBox.SelectionLength = 0;
                    e.IsInputKey = true;
                }

                // Prevent the default Tab behavior

            }
        }

        private void mtbCommunistPartyBegin_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            MaskedTextBox maskedTextBox = sender as MaskedTextBox;

            if (e.KeyCode == Keys.Tab)
            {
                // Move to next section if Tab is pressed
                int currentPosition = maskedTextBox.SelectionStart;
                if (currentPosition == 2 || currentPosition == 5)
                {
                    maskedTextBox.SelectionStart = currentPosition + 1;
                    maskedTextBox.SelectionLength = 0;
                    e.IsInputKey = true;
                }

                // Prevent the default Tab behavior

            }
        }

    }
}

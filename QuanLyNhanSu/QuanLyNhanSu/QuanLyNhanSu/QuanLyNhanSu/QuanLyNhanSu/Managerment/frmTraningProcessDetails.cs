using QuanLyNhanSu.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyNhanSu.Category
{
    public partial class frmTraningProcessDetails : Form
    {
        public TranningProcess traningProcess;

        public string personCode;

        public int traningProcessId ;
        public int maxTraningProcessId ;
        public bool succesed;

        public List<School> allSchool;
        string fileSchoolName = "School\\School.txt";

        List<AcademicLevel> allAcademicLevel;
        string fileNameAcademicLevel = "AcademicLevel\\AcademicLevel.txt";

        public List<TranningProcess> allTranningProcess;
        string fileTranningProcess = "TranningProcess\\TranningProcess.txt";
        public frmTraningProcessDetails()
        {
            InitializeComponent();
        }

        private void frmUnitDetail_Load(object sender, EventArgs e)
        {
            try
            {
                string contentSchool = Common.ReadFileContent(Common.pathCategory + fileSchoolName);
                allSchool = new List<School>();
                allSchool = Newtonsoft.Json.JsonConvert.DeserializeObject<List<School>>(contentSchool);
                cbxSchool.DataSource = allSchool;
                cbxSchool.DisplayMember = "Name";
                cbxSchool.ValueMember = "Id";
                cbxSchool.Text = "";
                //cbxSchool.DropDownStyle = ComboBoxStyle.DropDownList;

                string contentLevel = Common.ReadFileContent(Common.pathCategory + fileNameAcademicLevel);
                allAcademicLevel = new List<AcademicLevel>();
                allAcademicLevel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AcademicLevel>>(contentLevel);
                cbxAcademicLevel.DataSource = allAcademicLevel;
                cbxAcademicLevel.DisplayMember = "Name";
                cbxAcademicLevel.ValueMember = "Id";
                //cbxLevel.DropDownStyle = ComboBoxStyle.DropDownList;

                if (traningProcess != null)
                {
                    cbxSchool.Text = traningProcess.SchoolName;
                    txtMajor.Text = traningProcess.Major;
                    cbxAcademicLevel.Text = traningProcess.Level;
                    txtDecisionNumber.Text = traningProcess?.DecisionNumber;
                    dtBeginYear.Value = Common.ConvertStringToDate(traningProcess.BeginYear);
                    dtEndYear.Value = Common.ConvertStringToDate(traningProcess.EndYear);   
                    rtbNote.Text = traningProcess.Note;
                }
                else
                {
                    traningProcess = new TranningProcess();
                    txtMajor.Text = "";
                    cbxAcademicLevel.Text = "";
                    txtDecisionNumber.Text = "";
                    rtbNote.Text = "";
                }
            }
            catch (Exception ex)
            {
                succesed = false;
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private bool valid()
        {
            try
            {
                if (cbxSchool.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập trường.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbxSchool.Focus();
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
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!valid()) { succesed = false; return; }

                  traningProcess.SchoolName = cbxSchool.Text;
                  traningProcess.Major = txtMajor.Text;
                  traningProcess.Level = cbxAcademicLevel.Text;
                  traningProcess.DecisionNumber = txtDecisionNumber.Text;
                  traningProcess.BeginYear = Common.ConvertDateToString(dtBeginYear.Value.Date);
                  traningProcess.EndYear = Common.ConvertDateToString(dtEndYear.Value.Date);
                  traningProcess.Note = rtbNote.Text;
                  traningProcess.PersonCode = personCode;
               
                if (traningProcess.Id == 0 && maxTraningProcessId >= 0)
                {
                    traningProcess.Id = maxTraningProcessId + 1;
                    traningProcessId = traningProcess.Id;
                    allTranningProcess.Add(traningProcess);
                }
                else
                {
                    int index = allTranningProcess.FindIndex(obj => obj.Id == traningProcess.Id);
                    if (index != -1)
                    {
                        allTranningProcess[index] = traningProcess;
                    }
                }
                string str = Newtonsoft.Json.JsonConvert.SerializeObject(allTranningProcess);
                Common.SaveFileContent(Common.pathManagerment + fileTranningProcess, str);
                MessageBox.Show("Lưu dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                succesed = true;
                this.Close();
            }
            catch (Exception ex)
            {
                succesed = false;
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbxSchool_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                string searchText = cbxSchool.Text.ToLower().Trim();
                List<School> filteredItems = allSchool.Where(item => item.Name.ToLower().Contains(searchText)).ToList();
                cbxSchool.DataSource = null;
                cbxSchool.DataSource = filteredItems;
                cbxSchool.DisplayMember = "Name";
                cbxSchool.ValueMember = "Id";
                cbxSchool.DroppedDown = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void cbxLevel_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                string searchText = cbxAcademicLevel.Text.ToLower().Trim();
                List<AcademicLevel> filteredItems = allAcademicLevel.Where(item => item.Name.ToLower().Contains(searchText)).ToList();
                cbxAcademicLevel.DataSource = null;
                cbxAcademicLevel.DataSource = filteredItems;
                cbxAcademicLevel.DisplayMember = "Name";
                cbxAcademicLevel.ValueMember = "Id";
                cbxAcademicLevel.DroppedDown = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        //private void cbxLevel_TextChanged(object sender, EventArgs e)
        //{
        //    if (allAcademicLevel == null) return;
        //    string searchText = cbxLevel.Text.ToLower(); // Lấy giá trị đã nhập và chuyển thành chữ thường
        //    cbxLevel.Items.Clear(); // Xóa các mục hiện tại trong ComboBox

        //    foreach (var item in allAcademicLevel) // yourDataSource là nguồn dữ liệu của ComboBox
        //    {
        //        if (item.Name.ToLower().Contains(searchText)) 
        //        {
        //            cbxLevel.Text = item.Name; // Nếu có, thêm mục vào ComboBox
        //        }
        //    }
        //}
    }
}

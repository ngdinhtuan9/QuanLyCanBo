using QuanLyNhanSu.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyNhanSu.Category
{
    public partial class frmFosteringProcessDetails : Form
    {
        public FosteringProcess fosteringProcess;

        public string personCode;

        public int fosteringProcessId = 0;
        public int maxFosteringProcessId = 0;
        public bool succesed;

        public List<School> allSchool;
        string fileSchoolName = "School\\School.txt";

        List<AcademicLevel> allAcademicLevel;
        string fileNameAcademicLevel = "AcademicLevel\\AcademicLevel.txt";

        public List<FosteringProcess> allFosteringProcess;
        string fileFosteringProcess = "FosteringProcess\\FosteringProcess.txt";

        List<Fostering> allFostering;
        string fileName = "Fostering\\Fostering.txt";

        List<FosteringQPAN> allFosteringQPAN;
        string fileNameQPAN = "FosteringQPAN\\FosteringQPAN.txt";
        public frmFosteringProcessDetails()
        {
            InitializeComponent();
        }

        private void frmUnitDetail_Load(object sender, EventArgs e)
        {
            try
            {
                cbxFostering.Visible = false;
                txtContent.Visible = false;
                cbxFosteringQPAN.Visible = false;
                string contentSchool = Common.ReadFileContent(Common.pathCategory + fileSchoolName);
                allSchool = new List<School>();
                allSchool = Newtonsoft.Json.JsonConvert.DeserializeObject<List<School>>(contentSchool);
                cbxSchool.DataSource = allSchool;
                cbxSchool.DisplayMember = "Name";
                cbxSchool.ValueMember = "Id";
                cbxSchool.Text = "";
                // cbxSchool.DropDownStyle = ComboBoxStyle.DropDownList;
                cbxType.Items.Add("Bồi dưỡng PLNV");
                cbxType.Items.Add("Bồi dưỡng chức danh");
                cbxType.Items.Add("Bồi dưỡng quy hoạch chức danh");
                cbxType.Items.Add("Bồi dưỡng QPAN");
                cbxType.DropDownStyle = ComboBoxStyle.DropDownList;

                string content = Common.ReadFileContent(Common.pathCategory + fileName);
                allFostering = new List<Fostering>();
                allFostering = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Fostering>>(content);
                cbxFostering.DataSource = allFostering;
                cbxFostering.DisplayMember = "Name";
                cbxFostering.ValueMember = "Name";
                cbxFostering.DropDownStyle = ComboBoxStyle.DropDownList;


                string contentQPAN = Common.ReadFileContent(Common.pathCategory + fileNameQPAN);
                allFosteringQPAN = new List<FosteringQPAN>();
                allFosteringQPAN = Newtonsoft.Json.JsonConvert.DeserializeObject<List<FosteringQPAN>>(contentQPAN);
                cbxFosteringQPAN.DataSource = allFosteringQPAN;
                cbxFosteringQPAN.DisplayMember = "Name";
                cbxFosteringQPAN.ValueMember = "Name";
                cbxFosteringQPAN.DropDownStyle = ComboBoxStyle.DropDownList;

                if (fosteringProcess != null)
                {
                    cbxSchool.Text = fosteringProcess.SchoolName;
                   // txtContent.Text = fosteringProcess.Major;
                    cbxType.Text = fosteringProcess.Type;
                    cbxFostering.Text = fosteringProcess.FosteringContent;
                    cbxFosteringQPAN.Text = fosteringProcess.FosteringContent;
                    // cbxAcademicLevel.Text = fosteringProcess.Level;
                    txtContent.Text = fosteringProcess.FosteringContent;
                    txtDecisionNumber.Text = fosteringProcess?.DecisionNumber;
                    dtBeginYear.Value = Common.ConvertStringToDate(fosteringProcess.BeginYear);
                    dtEndYear.Value = Common.ConvertStringToDate(fosteringProcess.EndYear);
                    rtbNote.Text = fosteringProcess.Note;
                    //personCode = traningProcess.PersonCode;
                }
                else
                {
                    fosteringProcess = new FosteringProcess();
                    //cbxSchool.Text = "";
                    txtContent.Text = "";
                    cbxType.Text = "Bồi dưỡng PLNV";
                    txtDecisionNumber.Text = "";
                    //dtBeginYear.Value = ;// traningProcess.BeginYear;
                    // dtEndYear.Value = traningProcess.EndYear;
                    rtbNote.Text = "";
                    //personCode = traningProcess.PersonCode;
                }
            }
            catch (Exception ex)
            {
                succesed = false;
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!valid()) { succesed = false; return; }

                fosteringProcess.SchoolName = cbxSchool.Text;
                fosteringProcess.Major = txtContent.Text;
                //fosteringProcess.Level = cbxAcademicLevel.Text;
                if (cbxType.Text == "Bồi dưỡng PLNV")
                {
                    fosteringProcess.FosteringContent = cbxFostering.Text;
                }
                else if (cbxType.Text == "Bồi dưỡng QPAN")
                {
                    fosteringProcess.FosteringContent = cbxFosteringQPAN.Text;
                }
                else
                {
                    fosteringProcess.FosteringContent = txtContent.Text;
                }
                fosteringProcess.Type = cbxType.Text;
                fosteringProcess.DecisionNumber = txtDecisionNumber.Text;
                fosteringProcess.BeginYear = Common.ConvertDateToString(dtBeginYear.Value.Date);
                fosteringProcess.EndYear = Common.ConvertDateToString(dtEndYear.Value.Date);
                fosteringProcess.Note = rtbNote.Text;
                fosteringProcess.PersonCode = personCode;

                if (fosteringProcess.Id == 0 && maxFosteringProcessId >= 0)
                {
                    fosteringProcess.Id = maxFosteringProcessId + 1;
                    fosteringProcessId = fosteringProcess.Id;
                    allFosteringProcess.Add(fosteringProcess);
                }
                else
                {
                    int index = allFosteringProcess.FindIndex(obj => obj.Id == fosteringProcess.Id);
                    if (index != -1)
                    {
                        allFosteringProcess[index] = fosteringProcess;
                    }
                }
                string str = Newtonsoft.Json.JsonConvert.SerializeObject(allFosteringProcess);
                Common.SaveFileContent(Common.pathManagerment + fileFosteringProcess, str);
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


        private bool valid()
        {
            try
            {
                if (cbxType.Text == "")
                {
                    MessageBox.Show("Bạn chưa chọn loại bồi dưỡng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbxType.Focus();
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

        private void cbxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //cbxType.Items.Add("Bồi dưỡng PLNV");
                //cbxType.Items.Add("Bồi dưỡng chức danh");
                //cbxType.Items.Add("Bồi dưỡng quy hoạch chức danh");
                //cbxType.Items.Add("Bồi dưỡng QPAN");
                if (cbxType.Text == "Bồi dưỡng PLNV")
                {
                    cbxFostering.Visible = true;
                    txtContent.Visible = false;
                    cbxFosteringQPAN.Visible = false;
                }
                else if (cbxType.Text == "Bồi dưỡng chức danh")
                {
                    cbxFostering.Visible = false;
                    txtContent.Visible = true;
                    cbxFosteringQPAN.Visible = false;
                }
                else if (cbxType.Text == "Bồi dưỡng quy hoạch chức danh")
                {
                    cbxFostering.Visible = false;
                    txtContent.Visible = true;
                    cbxFosteringQPAN.Visible = false;
                }
                else if (cbxType.Text == "Bồi dưỡng QPAN")
                {
                    cbxFostering.Visible = false;
                    txtContent.Visible = false;
                    cbxFosteringQPAN.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}

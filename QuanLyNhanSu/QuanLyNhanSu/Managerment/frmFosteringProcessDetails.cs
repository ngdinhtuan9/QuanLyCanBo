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
        bool load = false;
        public frmFosteringProcessDetails()
        {
            InitializeComponent();

        }

        private void frmUnitDetail_Load(object sender, EventArgs e)
        {
            try
            {
                // mtbBeginYear.KeyDown += new KeyEventHandler(mtbBeginYear_KeyDown);

                mtbBeginYear.Mask = "00/00/0000";
                mtbEndYear.Mask = "00/00/0000";
                load = true;
                cbxFostering.Visible = false;
                txtContent.Visible = false;
                cbxFosteringQPAN.Visible = false;
                string contentSchool = Common.ReadFileContent(QLNSCommon.pathCategory + fileSchoolName);
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

                string content = Common.ReadFileContent(QLNSCommon.pathCategory + fileName);
                allFostering = new List<Fostering>();
                allFostering = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Fostering>>(content);
                cbxFostering.DataSource = allFostering;
                cbxFostering.DisplayMember = "Name";
                cbxFostering.ValueMember = "Name";
                //cbxFostering.DropDownStyle = ComboBoxStyle.DropDownList;


                string contentQPAN = Common.ReadFileContent(QLNSCommon.pathCategory + fileNameQPAN);
                allFosteringQPAN = new List<FosteringQPAN>();
                allFosteringQPAN = Newtonsoft.Json.JsonConvert.DeserializeObject<List<FosteringQPAN>>(contentQPAN);
                cbxFosteringQPAN.DataSource = allFosteringQPAN;
                cbxFosteringQPAN.DisplayMember = "Name";
                cbxFosteringQPAN.ValueMember = "Name";
                //cbxFosteringQPAN.DropDownStyle = ComboBoxStyle.DropDownList;
                //dtBeginYear.CustomFormat = " ";
               // dtEndYear.CustomFormat = " ";
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
                    if (Checking.CheckNullString(fosteringProcess.BeginYear) != "")
                    {
                        mtbBeginYear.Text = fosteringProcess.BeginYear;
                        //dtBeginYear.Format = DateTimePickerFormat.Short;
                    }
                    if (Checking.CheckNullString(fosteringProcess.EndYear) != "")
                    {
                        mtbEndYear.Text = fosteringProcess.EndYear;
                        //dtBeginYear.Format = DateTimePickerFormat.Short;
                    }
                    //if (Checking.CheckNullString(fosteringProcess.EndYear) != "")
                    //{
                    //    dtEndYear.Value = Common.ConvertStringToDate(fosteringProcess.EndYear);
                    //    dtEndYear.Format = DateTimePickerFormat.Short;
                    //}
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
                    cbxFostering.Text = "";
                    cbxFosteringQPAN.Text = "";

                    //dtBeginYear.Value = ;// traningProcess.BeginYear;
                    // dtEndYear.Value = traningProcess.EndYear;
                    rtbNote.Text = "";
                    //personCode = traningProcess.PersonCode;
                }
                load = false;
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
                //fosteringProcess.Major = txtContent.Text;
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
                if (mtbBeginYear.Text != "  /  /")
                {
                    fosteringProcess.BeginYear = mtbBeginYear.Text;
                }
                else
                {
                    fosteringProcess.BeginYear = "";
                }

                if (mtbEndYear.Text != "  /  /")
                {
                    fosteringProcess.EndYear = mtbEndYear.Text;
                }
                else
                {
                    fosteringProcess.EndYear = "";
                }
                //fosteringProcess.EndYear = Common.ConvertDateToString(dtEndYear.Value.Date);
                //fosteringProcess.BeginYear = Common.ConvertDateToString(dtBeginYear.Value.Date);
                //fosteringProcess.EndYear = Common.ConvertDateToString(dtEndYear.Value.Date);
                fosteringProcess.Note = rtbNote.Text;
                fosteringProcess.PersonCode = personCode;

                if (fosteringProcess.Id == 0 && maxFosteringProcessId >= 0)
                {
                    fosteringProcess.Id = maxFosteringProcessId + 1;
                    fosteringProcessId = fosteringProcess.Id;
                    allFosteringProcess.RemoveAll(obj => obj.PersonCode == fosteringProcess.PersonCode
                    && obj.SchoolName == fosteringProcess.SchoolName && obj.FosteringContent == fosteringProcess.FosteringContent);
                    //allperson.Add(person);
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
                Common.SaveFileContent(QLNSCommon.pathManagerment + fileFosteringProcess, str);
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
                if (mtbBeginYear.Text != "  /  /")
                {
                    if (DateTime.TryParseExact(mtbBeginYear.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime result))
                    {

                    }
                    else
                    {
                        MessageBox.Show("Ngày tháng bắt đầu không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        // MessageBox.Show("Ngày tháng không hợp lệ!");
                        return false;
                    }
                }

                if (mtbEndYear.Text != "  /  /")
                {
                    if (DateTime.TryParseExact(mtbEndYear.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime result))
                    {

                    }
                    else
                    {
                        MessageBox.Show("Ngày tháng kết thúc không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
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

        private void dtBeginYear_ValueChanged(object sender, EventArgs e)
        {
            if (!load)
            {
                //dtBeginYear.Format = DateTimePickerFormat.Short;
                // dteCommunistPartyBegin.Value = Common.ConvertStringToDate(person.CommunistPartyBegin);
            }
        }

        private void dtEndYear_ValueChanged(object sender, EventArgs e)
        {
            if (!load)
            {
               // dtEndYear.Format = DateTimePickerFormat.Short;
                // dteCommunistPartyBegin.Value = Common.ConvertStringToDate(person.CommunistPartyBegin);
            }
        }

        private void dtBeginYear_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {

                //dtBeginYear.CustomFormat = " ";
            }
            if (e.KeyCode == Keys.Back)
            {

                // dtBeginYear.CustomFormat = " ";
            }
        }

        private void dtEndYear_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {

                //dtEndYear.CustomFormat = " ";
            }
            if (e.KeyCode == Keys.Back)
            {

              //  dtEndYear.CustomFormat = " ";
            }
        }

        private void mtbBeginYear_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                // Lấy vị trí hiện tại của con trỏ
                int selectionStart = mtbBeginYear.SelectionStart;
                if (selectionStart < 3)
                {
                    // Di chuyển đến phần tháng
                    mtbBeginYear.SelectionStart = 3;
                }
                else if (selectionStart < 6)
                {
                    // Di chuyển đến phần năm
                    mtbBeginYear.SelectionStart = 6;
                }
                e.Handled = true;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mtbBeginYear_KeyDown_1(object sender, KeyEventArgs e)
        {

        }


    }
}

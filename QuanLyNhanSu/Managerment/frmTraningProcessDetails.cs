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

        public int traningProcessId;
        public int maxTraningProcessId;
        public bool succesed;

        public List<School> allSchool;
        string fileSchoolName = "School\\School.txt";

        List<AcademicLevel> allAcademicLevel;
        string fileNameAcademicLevel = "AcademicLevel\\AcademicLevel.txt";

        List<TraningProcessType> allTraningProcessType;
        string fileNameTraningProcessType = "TraningProcessType\\TraningProcessType.txt";

        public List<TraningFosteringType> allTraningFosteringType;
        string fileTraningFosteringType = "TraningFosteringType\\TraningFosteringType.txt";

        public List<TranningProcess> allTranningProcess;
        string fileTranningProcess = "TranningProcess\\TranningProcess.txt";


        bool load = false;
        public frmTraningProcessDetails()
        {
            InitializeComponent();
        }

        private void frmUnitDetail_Load(object sender, EventArgs e)
        {
            try
            {
                mtbBeginYear.Mask = "00/00/0000";
                mtbEndYear.Mask = "00/00/0000";

                load = true;
                cbxType.Items.Add("Tốt nghiệp trong CAND");
                cbxType.Items.Add("Tốt nghiệp trường ngoài CAND");
                cbxType.Items.Add("Đang học các lớp trong CAND");
                cbxType.DropDownStyle = ComboBoxStyle.DropDownList;

                string contentSchool = Common.ReadFileContent(QLNSCommon.pathCategory + fileSchoolName);
                allSchool = new List<School>();
                allSchool = Newtonsoft.Json.JsonConvert.DeserializeObject<List<School>>(contentSchool);
                cbxSchool.DataSource = allSchool;
                cbxSchool.DisplayMember = "Name";
                cbxSchool.ValueMember = "Id";
                cbxSchool.Text = "";
                //cbxSchool.DropDownStyle = ComboBoxStyle.DropDownList;

                string contentLevel = Common.ReadFileContent(QLNSCommon.pathCategory + fileNameAcademicLevel);
                allAcademicLevel = new List<AcademicLevel>();
                allAcademicLevel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AcademicLevel>>(contentLevel);
                cbxAcademicLevel.DataSource = allAcademicLevel;
                cbxAcademicLevel.DisplayMember = "Name";
                cbxAcademicLevel.ValueMember = "Id";
                //cbxLevel.DropDownStyle = ComboBoxStyle.DropDownList;

                string contentTraningProcessType = Common.ReadFileContent(QLNSCommon.pathCategory + fileNameTraningProcessType);
                allTraningProcessType = new List<TraningProcessType>();
                allTraningProcessType = Newtonsoft.Json.JsonConvert.DeserializeObject<List<TraningProcessType>>(contentTraningProcessType);
                cbxTraningProcessType.DataSource = allTraningProcessType;
                cbxTraningProcessType.DisplayMember = "Name";
                cbxTraningProcessType.ValueMember = "Id";

                string contentTraningFosteringType = Common.ReadFileContent(QLNSCommon.pathCategory + fileTraningFosteringType);
                allTraningFosteringType = new List<TraningFosteringType>();
                allTraningFosteringType = Newtonsoft.Json.JsonConvert.DeserializeObject<List<TraningFosteringType>>(contentTraningFosteringType);


                cbxTraningProcessType.Text = "";
                //dtEndYear.CustomFormat = " ";
                //dtBeginYear.CustomFormat = " ";
                if (traningProcess != null)
                {
                    cbxType.Text = traningProcess.Type;
                    cbxSchool.Text = traningProcess.SchoolName;
                    txtMajor.Text = traningProcess.Major;
                    cbxAcademicLevel.Text = traningProcess.Level;
                    txtDecisionNumber.Text = traningProcess?.DecisionNumber;
                    if (Checking.CheckNullString(traningProcess.BeginYear) != "")
                    {
                        mtbBeginYear.Text = traningProcess.BeginYear;
                        //dtBeginYear.Format = DateTimePickerFormat.Short;
                    }
                    if (Checking.CheckNullString(traningProcess.EndYear) != "")
                    {
                        mtbEndYear.Text = traningProcess.EndYear;
                        //dtBeginYear.Format = DateTimePickerFormat.Short;
                    }
                    //dtBeginYear.Value = Common.ConvertStringToDate(traningProcess.BeginYear);
                    //dtEndYear.Value = Common.ConvertStringToDate(traningProcess.EndYear);
                    rtbNote.Text = traningProcess.Note;
                }
                else
                {
                    traningProcess = new TranningProcess();
                    txtMajor.Text = "";
                    cbxAcademicLevel.Text = "";
                    txtDecisionNumber.Text = "";
                    cbxTraningProcessType.Text = "";
                    rtbNote.Text = "";
                }
                load = false;
            }
            catch (Exception ex)
            {
                succesed = false;
                MessageBox.Show("Lỗi trong quá trình xử lý dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private bool valid()
        {
            try
            {
                if (cbxType.Text == "")
                {
                    MessageBox.Show("Bạn chưa chọn loại hình đào tạo.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbxType.Focus();
                    return false;
                };
                if (cbxSchool.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập trường.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);          
                    cbxSchool.Focus();
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
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!valid()) { succesed = false; return; }

                traningProcess.Type = cbxType.Text;
                traningProcess.SchoolName = cbxSchool.Text;
                traningProcess.Major = txtMajor.Text;
                traningProcess.Level = cbxAcademicLevel.Text;
                traningProcess.DecisionNumber = txtDecisionNumber.Text;
                if (mtbBeginYear.Text != "  /  /")
                {
                    traningProcess.BeginYear = mtbBeginYear.Text;
                }
                else
                {
                    traningProcess.BeginYear = "";
                }

                if (mtbEndYear.Text != "  /  /")
                {
                    traningProcess.EndYear = mtbEndYear.Text;
                }
                else
                {
                    traningProcess.EndYear = "";
                }
                traningProcess.Note = rtbNote.Text;
                traningProcess.TraningType = cbxTraningProcessType.Text;
                traningProcess.PersonCode = personCode;

                if (traningProcess.Id == 0 && maxTraningProcessId >= 0)
                {
                    traningProcess.Id = maxTraningProcessId + 1;
                    traningProcessId = traningProcess.Id;
                    allTranningProcess.RemoveAll(obj => obj.PersonCode == traningProcess.PersonCode
                    && obj.SchoolName == traningProcess.SchoolName && obj.Type == traningProcess.Type 
                    && obj.Level == traningProcess.Level && obj.Major == traningProcess.Major);
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
                Common.SaveFileContent(QLNSCommon.pathManagerment + fileTranningProcess, str);
                MessageBox.Show("Lưu dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                succesed = true;
                this.Close();
            }
            catch (Exception ex)
            {
                succesed = false;
                MessageBox.Show("Lỗi trong quá trình xử lý dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Lỗi trong quá trình xử lý dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        //private void cbxLevel_MouseClick(object sender, MouseEventArgs e)
        //{
        //    try
        //    {
        //        string searchText = cbxAcademicLevel.Text.ToLower().Trim();
        //        if (Checking.CheckNullString(cbxType.Text) == "Đang học các lớp trong CAND")
        //        {
                    
        //            List<TraningFosteringType> filteredItems = allTraningFosteringType.Where(item => item.Name.ToLower().Contains(searchText)).ToList();
        //            cbxAcademicLevel.DataSource = null;
        //            cbxAcademicLevel.DataSource = filteredItems;
        //            cbxAcademicLevel.DisplayMember = "Name";
        //            cbxAcademicLevel.ValueMember = "Id";
        //            cbxAcademicLevel.DroppedDown = true;
        //        }
        //        else
        //        {
        //           // string searchText = cbxAcademicLevel.Text.ToLower().Trim();
        //            List<AcademicLevel> filteredItems = allAcademicLevel.Where(item => item.Name.ToLower().Contains(searchText)).ToList();
        //            cbxAcademicLevel.DataSource = null;
        //            cbxAcademicLevel.DataSource = filteredItems;
        //            cbxAcademicLevel.DisplayMember = "Name";
        //            cbxAcademicLevel.ValueMember = "Id";
        //            cbxAcademicLevel.DroppedDown = true;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Lỗi trong quá trình xử lý dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //    }
        //}

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

                //dtBeginYear.CustomFormat = " ";
            }
        }

        private void dtEndYear_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {

               // dtEndYear.CustomFormat = " ";
            }
            if (e.KeyCode == Keys.Back)
            {

              //  dtEndYear.CustomFormat = " ";
            }
        }

      

        private void cbxType_TextChanged(object sender, EventArgs e)
        {
            try
            {
               // cbxType.Items.Add("Đang học các lớp trong CAND");
                if (Checking.CheckNullString(cbxType.Text) == "Đang học các lớp trong CAND") 
                {
                    label3.Text = "Hệ đào tạo";
                    label3.Location = new Point(55, 95);
                    cbxAcademicLevel.DataSource = allTraningFosteringType;
                    cbxAcademicLevel.DisplayMember = "Name";
                    cbxAcademicLevel.ValueMember = "Id";

                }
                else
                {
                    label3.Text = "Trình độ";
                    label3.Location = new Point(71, 95);
                    cbxAcademicLevel.DataSource = allAcademicLevel;
                    cbxAcademicLevel.DisplayMember = "Name";
                    cbxAcademicLevel.ValueMember = "Id";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi trong quá trình xử lý dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    
    }
}

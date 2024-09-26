using GemBox.Spreadsheet;
using Newtonsoft.Json.Linq;
using QuanLyNhanSu.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace QuanLyNhanSu.Category
{
    public partial class frmReport : Form
    {

        string fileName = "Person\\Person.txt";
        // List<Person> person;
        List<Person> allperson;
        List<Person> personSearch = new List<Person>();

        List<Unit> allUnits;
        string fileUnitName = "Units\\Units.txt";

        string fileDepartmentName = "Department\\Department.txt";
        List<Department> allDepartment;

        List<Level> allLevel;
        string fileNameLevel = "level\\level.txt";

        List<AcademicLevel> allAcademicLevel;
        string fileNameAcademicLevel = "AcademicLevel\\AcademicLevel.txt";

        public List<School> allSchool;
        string fileSchoolName = "School\\School.txt";

        List<PoliticalLevel> allPoliticalLevel;
        string fileNamePoliticalLevel = "PoliticalLevel\\PoliticalLevel.txt";

        List<TranningProcess> allTranningProcess;
        string fileTranningProcess = "TranningProcess\\TranningProcess.txt";

        List<FosteringProcess> allFosteringProcess;
        string fileFosteringProcess = "FosteringProcess\\FosteringProcess.txt";

     
        public frmReport()
        {
            InitializeComponent();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmUnits_Load(object sender, EventArgs e)
        {
            dataGridView1.RowTemplate.Height = 50;
            dataGridView1.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            LoadData();
            Resize();
        }
        private void LoadData()
        {
            try
            {
                cbxArrange.DisplayMember = "Text";
                cbxArrange.ValueMember = "Value";
                cbxArrange.Items.Add(new  {Text = "Số hiệu", Value = "Code"});
                cbxArrange.Items.Add(new {Text = "Họ tên", Value = "FullName" });
                cbxArrange.Items.Add(new { Text = "Đơn vị", Value = "UnitCode" });
                cbxArrange.Items.Add(new { Text = "Cấp bậc", Value = "LevelCode" });
                cbxArrange.Items.Add(new { Text = "Trình độ", Value = "AcademicLevelName" });
                cbxArrange.Items.Add(new { Text = "Quê quán", Value = "Hometown" });
                cbxArrange.Items.Add(new { Text = "Địa chỉ thường trú", Value = "Address" });
                //cap bac
                string contentLevel = Common.ReadFileContent(QLNSCommon.pathCategory + fileNameLevel);
                allLevel = new List<Level>();
                allLevel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Level>>(contentLevel);
                this.WindowState = FormWindowState.Maximized;

                string contentAcademicLevel = Common.ReadFileContent(QLNSCommon.pathCategory + fileNameAcademicLevel);
                allAcademicLevel = new List<AcademicLevel>();
                allAcademicLevel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AcademicLevel>>(contentAcademicLevel);
                if (allAcademicLevel.Count > 1)
                {
                    AcademicLevel LevelAll = new AcademicLevel();
                    LevelAll.Name = "Tất cả";
                    LevelAll.Id = 0;
                    allAcademicLevel.Add(LevelAll);
                }

                cbxTypeFostering.Items.Add("Tất cả");
                cbxTypeFostering.Items.Add("Bồi dưỡng PLNV");
                cbxTypeFostering.Items.Add("Bồi dưỡng chức danh");
                cbxTypeFostering.Items.Add("Bồi dưỡng quy hoạch chức danh");
                cbxTypeFostering.Items.Add("Bồi dưỡng QPAN");
                cbxTypeFostering.Text = "Tất cả";
                cbxTypeFostering.DropDownWidth = 300;

                cbxAcademicLevel.DataSource = allAcademicLevel;
                cbxAcademicLevel.DisplayMember = "Name";
                cbxAcademicLevel.ValueMember = "Id";
                cbxAcademicLevel.Text = "Tất cả";
                cbxAcademicLevel.DropDownStyle = ComboBoxStyle.DropDownList;
                allAcademicLevel.RemoveAll(obj => obj.Id == 0);

                string contentSchool = Common.ReadFileContent(QLNSCommon.pathCategory + fileSchoolName);
                allSchool = new List<School>();
                allSchool = Newtonsoft.Json.JsonConvert.DeserializeObject<List<School>>(contentSchool);

                string contentDepartment = Common.ReadFileContent(QLNSCommon.pathCategory + fileDepartmentName);
                allDepartment = new List<Department>();
                allDepartment = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Department>>(contentDepartment);
                cbxDepartment.DropDownWidth = 400;


                string unit = Common.ReadFileContent(QLNSCommon.pathCategory + fileUnitName);
                allUnits = new List<Unit>();
                allUnits = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Unit>>(unit);
                List<Unit> unitRole = allUnits;
                if (Common.glbUnit != "Tất cả")
                {
                    unitRole = allUnits.FindAll(item => item.Name.Contains(Common.glbUnit.Trim()));
                }
                if (unitRole.Count > 1) 
                {
                    Unit unitAll = new Unit();
                    unitAll.Name = "Tất cả";
                    unitAll.Id = 900000;
                    allUnits.Add(unitAll);
                }

                cbxUnit.DataSource = unitRole;
                cbxUnit.DisplayMember = "Name";
                cbxUnit.ValueMember = "Id";
                cbxUnit.Text = "Tất cả";
                cbxUnit.DropDownWidth = 400;
                cbxUnit.DropDownStyle = ComboBoxStyle.DropDownList;
                allUnits.RemoveAll(obj => obj.Id == 0);

                string contentPoliticalLevel = Common.ReadFileContent(QLNSCommon.pathCategory + fileNamePoliticalLevel);
                allPoliticalLevel = new List<PoliticalLevel>();
                allPoliticalLevel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<PoliticalLevel>>(contentPoliticalLevel);

                //cbxUnit.DropDownStyle = ComboBoxStyle.DropDownList;
                string content = Common.ReadFileContent(QLNSCommon.pathManagerment + fileName);
                allperson = new List<Person>();
                allperson = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Person>>(content);
                dataGridView1.DataSource = allperson;
                personSearch = allperson;
               
                string contentTranningProcess = Common.ReadFileContent(QLNSCommon.pathManagerment + fileTranningProcess);
                allTranningProcess = new List<TranningProcess>();
                //string abc = contentTranningProcess;
                if (contentTranningProcess.ToString() != "" && !contentTranningProcess.ToString().Contains("Bad")) { allTranningProcess = Newtonsoft.Json.JsonConvert.DeserializeObject<List<TranningProcess>>(contentTranningProcess); }
                
                string contentFosteringProcess = Checking.CheckNullString(Common.ReadFileContent(QLNSCommon.pathManagerment + fileFosteringProcess));
                allFosteringProcess = new List<FosteringProcess>();
                if (contentFosteringProcess != "" & !contentFosteringProcess.Contains("Bad")) { allFosteringProcess = Newtonsoft.Json.JsonConvert.DeserializeObject<List<FosteringProcess>>(contentFosteringProcess); }

                clbColumns.Items.Add("Mã");
                clbColumns.Items.Add("CCCD");
                clbColumns.Items.Add("Họ và tên");
                clbColumns.Items.Add("Năm sinh");
                clbColumns.Items.Add("Giới tính");
                clbColumns.Items.Add("Quê quán(xã, huyện, tỉnh)");
                clbColumns.Items.Add("Hộ khẩu TT");
                clbColumns.Items.Add("Công tác chuyên trách");
                clbColumns.Items.Add("Ngày vào CAND");
                clbColumns.Items.Add("Ngày vào CAND chính thức");
                clbColumns.Items.Add("Ngày vào đảng");
                clbColumns.Items.Add("Cấp bậc");
                clbColumns.Items.Add("Chức danh");
                clbColumns.Items.Add("Chức vụ");

                clbColumns.Items.Add("Trình độ đào tạo trong CAND");
                clbColumns.Items.Add("Chuyên ngành đào tạo trong CAND");
                clbColumns.Items.Add("Trường trong CAND");
                clbColumns.Items.Add("Năm tốt nghiệp trong CAND");
                clbColumns.Items.Add("Hình thức hình đào tạo trong CAND");

                clbColumns.Items.Add("Trường ngoài CAND");
                clbColumns.Items.Add("Chuyên ngành đào tạo ngoài CAND");
                clbColumns.Items.Add("Năm tốt nghiệp ngoài CAND ");
                clbColumns.Items.Add("Hình thức hình đào tạo ngoài CAND");
                clbColumns.Items.Add("Trình độ đào tạo ngoài CAND");

                clbColumns.Items.Add("Trường đang đào tạo trong CAND");
                clbColumns.Items.Add("Chuyên ngành đang đào tạo trong CAND");
                clbColumns.Items.Add("Năm tốt nghiệp trường đang đào tạo trong CAND");
                clbColumns.Items.Add("Trình độ đang đào tạo");
                clbColumns.Items.Add("Hình thức đang đào tạo");

                clbColumns.Items.Add("Bồi dưỡng NLNV");
                clbColumns.Items.Add("Bồi dưỡng chức danh");
                clbColumns.Items.Add("Bồi dưỡng quy hoạch chức danh");
                clbColumns.Items.Add("Bồi dưỡng QPAN");

                clbColumns.Items.Add("Trình độ LLCT");
                clbColumns.Items.Add("Hình thức đào tạo LLCT");
                clbColumns.Items.Add("Phân loại cán bộ");
                clbColumns.Items.Add("Phân loại thi đua");
                clbColumns.Items.Add("Đơn vị chủ quản");
                clbColumns.Items.Add("Đơn vị trực thuộc");
                clbColumns.Items.Add("Ghi chú");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Search()
        {
            try
            {
                //personSearch = new List<Person>();
                personSearch = allperson;
                if (txtCode.Text.Trim() != "")
                {
                    personSearch = personSearch.FindAll(item => item.Code.Contains(txtCode.Text.Trim()));
                }
                if (txtFullName.Text.Trim() != "")
                {
                    personSearch = personSearch.FindAll(item => item.FullName.Contains(txtFullName.Text.Trim()));
                }
                if (cbxTypeFostering.Text.Trim() != "" && cbxTypeFostering.Text.Trim() != "Tất cả")
                {
                    if (cbxTypeFostering.Text == "Bồi dưỡng PLNV")
                    {
                        personSearch = personSearch.FindAll(item => Checking.CheckNullString(item.FosteringPLNV) != "");
                    }
                    else if (cbxTypeFostering.Text == "Bồi dưỡng chức danh")
                    {
                        personSearch = personSearch.FindAll(item => Checking.CheckNullString(item.TittleTraning) != "");
                    }
                    else if (cbxTypeFostering.Text == "Bồi dưỡng quy hoạch chức danh")
                    {
                        personSearch = personSearch.FindAll(item => Checking.CheckNullString(item.TittleTraningPlanning) != "");
                    }
                    else if (cbxTypeFostering.Text == "Bồi dưỡng QPAN")
                    {
                        personSearch = personSearch.FindAll(item => Checking.CheckNullString(item.FosteringQPA) != "");
                    }
                }
                if (cbxUnit.Text.Trim() != "" && cbxUnit.Text.Trim() != "Tất cả")
                {
                    personSearch = personSearch.FindAll(item => item.UnitCode.Contains(cbxUnit.Text));
                }
                if (cbxAcademicLevel.Text.Trim() != "" && cbxAcademicLevel.Text.Trim() != "Tất cả")
                {
                    personSearch = personSearch.FindAll(item => item.AcademicLevelName.Contains(cbxAcademicLevel.Text));
                }
                if (cbxDepartment.Text.Trim() != "" && cbxDepartment.Text.Trim() != "Tất cả")
                {
                    personSearch = personSearch.FindAll(item => item.Department.Contains(cbxDepartment.Text));
                }
                if (cbxArrange.SelectedItem != null)
                {
                    var selectedProperty = ((dynamic)cbxArrange.SelectedItem).Value;

                    // Sắp xếp danh sách theo thuộc tính được chọn
                    switch (selectedProperty)
                    {
                        case "Code":
                            personSearch = personSearch.OrderBy(p => p.Code).ToList();
                            break;
                        case "FullName":
                            personSearch = personSearch.OrderBy(p => p.FullName).ToList();
                            break;
                        case "UnitCode":
                            personSearch = personSearch.OrderBy(p => p.UnitCode).ToList();
                            break;
                        case "LevelCode":
                            personSearch = personSearch.OrderBy(p => p.LevelCode).ToList();
                            break;
                        case "AcademicLevelName":
                            personSearch = personSearch.OrderBy(p => p.AcademicLevelName).ToList();
                            break;
                        case "Hometown":
                            personSearch = personSearch.OrderBy(p => p.Hometown).ToList();
                            break;
                        case "Address":
                            personSearch = personSearch.OrderBy(p => p.Address).ToList();
                            break;

                    }
                }
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = personSearch;
                Resize();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                string columnName = dataGridView1.Columns[e.ColumnIndex].Name;
                if (columnName == "CHECK")
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Edit(string value)
        {
            Person person = allperson.FirstOrDefault(obj => obj.Code == value);
            frmPersonDetail frmDetail = new frmPersonDetail();
            frmDetail.personId = person.Id;
            frmDetail.person = person;
            frmDetail.allperson = allperson;
            frmDetail.allUnits = allUnits;
            frmDetail.allFosteringProcess = allFosteringProcess;
            frmDetail.allTranningProcess = allTranningProcess;

            frmDetail.ShowDialog();
            if (frmDetail.succesed)
            {
                if (frmDetail.personId == person.Id)
                {
                    string str = Newtonsoft.Json.JsonConvert.SerializeObject(allperson);
                    Common.SaveFileContent(QLNSCommon.pathManagerment + fileName, str);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = allperson;
                    Resize();
                    //MessageBox.Show("Lưu dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            allFosteringProcess = frmDetail.allFosteringProcess;
            allTranningProcess = frmDetail.allTranningProcess;
        }
        //private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        if (e.RowIndex < 0)
        //            return;
        //        DataGridViewRow clickedRow = dataGridView1.Rows[e.RowIndex];
        //        string value = clickedRow.Cells["Code"].Value.ToString();
        //        Edit(value);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //}

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
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int count = 0;
                for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--)
                {
                    DataGridViewRow row = dataGridView1.Rows[i];
                    DataGridViewCheckBoxCell cell = row.Cells["CHECK"] as DataGridViewCheckBoxCell;
                    bool isChecked = Convert.ToBoolean(cell.Value);
                    if (isChecked)
                    {
                        count = 1;
                        break;
                    }
                }
                if (count == 0) { MessageBox.Show("Không có dữ liệu được chọn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

                if (MessageBox.Show("Bạn có chắc chắn muốn xóa các dữ liệu đã chọn?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--)
                    {
                        DataGridViewRow row = dataGridView1.Rows[i];
                        DataGridViewCheckBoxCell cell = row.Cells["CHECK"] as DataGridViewCheckBoxCell;
                        bool isChecked = Convert.ToBoolean(cell.Value);
                        if (isChecked)
                        {
                            //decimal targetID = decimal.Parse(row.Cells["Id"].Value.ToString());
                            //allperson.RemoveAll(obj => obj.Id == targetID);
                            string personCode = row.Cells["Code"].Value.ToString();
                            allTranningProcess.RemoveAll(obj => obj.PersonCode == personCode);
                            allFosteringProcess.RemoveAll(obj => obj.PersonCode == personCode);
                            allperson.RemoveAll(obj => obj.Code == personCode);
                        }
                    }
                    string str = Newtonsoft.Json.JsonConvert.SerializeObject(allperson);
                    Common.SaveFileContent(QLNSCommon.pathManagerment + fileName, str);
                    //xoa bang con
                    string strallTranningProcess = Newtonsoft.Json.JsonConvert.SerializeObject(allTranningProcess);
                    Common.SaveFileContent(QLNSCommon.pathManagerment + fileTranningProcess, strallTranningProcess);

                    string strallFosteringProcess = Newtonsoft.Json.JsonConvert.SerializeObject(allFosteringProcess);
                    Common.SaveFileContent(QLNSCommon.pathManagerment + fileFosteringProcess, strallFosteringProcess);

                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = allperson;
                    Resize();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Resize()
        {
            System.Drawing.Font headerFont = new System.Drawing.Font(dataGridView1.Font, System.Drawing.FontStyle.Bold);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = headerFont;
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns["CreatedBy"].Visible = false;
            dataGridView1.Columns["CreatedTime"].Visible = false;
            dataGridView1.Columns["ModifiedBy"].Visible = false;
            dataGridView1.Columns["ModifiedTime"].Visible = false;
            dataGridView1.Columns["Sex"].Visible = false;
            dataGridView1.Columns["FullName"].Visible = false;
            dataGridView1.Columns["Code"].Visible = false;
            dataGridView1.Columns["IdentityCard"].Visible = false;
            dataGridView1.Columns["Note"].Visible = false;
            dataGridView1.Columns["DateOfBird"].Visible = false;
            dataGridView1.Columns["Address"].Visible = false;
            dataGridView1.Columns["Hometown"].Visible = false;
            dataGridView1.Columns["Department"].Visible = false;
            dataGridView1.Columns["Levelcode"].Visible = false;
            //dataGridView1.Columns["AcademicLevelName"].HeaderText = "Trình độ";
            dataGridView1.Columns["ResponsibleName"].Visible = false;
            dataGridView1.Columns["YearBegin"].Visible = false;
            dataGridView1.Columns["OfficialStartYear"].Visible = false;
            dataGridView1.Columns["InternalAcademicLevelName"].Visible = false;
            dataGridView1.Columns["InternalMajor"].Visible = false;
            
            dataGridView1.Columns["InternalSchool"].Visible = false;
            dataGridView1.Columns["InternalSchoolYear"].Visible = false;
            dataGridView1.Columns["InternalTraningType"].Visible = false;

            dataGridView1.Columns["CurInternalAcademicLevelName"].Visible = false;
            dataGridView1.Columns["CurInternalMajor"].Visible = false;
            
            dataGridView1.Columns["CurInternalSchool"].Visible = false;
            dataGridView1.Columns["CurInternalSchoolYear"].Visible = false;
            dataGridView1.Columns["CurInternalTraningType"].Visible = false;

            dataGridView1.Columns["AcademicLevelName"].Visible = false;
            dataGridView1.Columns["Major"].Visible = false;
            dataGridView1.Columns["SchoolName"].Visible = false;
            dataGridView1.Columns["SchoolYear"].Visible = false;
            dataGridView1.Columns["TraningType"].Visible = false;
            dataGridView1.Columns["Position"].Visible = false;
           // dataGridView1.Columns["OtherSchool"].Visible = false;
            dataGridView1.Columns["FosteringPLNV"].Visible = false;
            dataGridView1.Columns["TittleTraning"].Visible = false;
            dataGridView1.Columns["TittleTraningPlanning"].Visible = false;
            dataGridView1.Columns["FosteringQPA"].Visible = false;
            dataGridView1.Columns["PoliticalLevel"].Visible = false;
            dataGridView1.Columns["PoliticalLevelForm"].Visible = false;
            //dataGridView1.Columns["SchoolYear"].HeaderText = "Năm tốt nghiệp";
            dataGridView1.Columns["CommunistPartyBegin"].Visible = false;
            dataGridView1.Columns["Classify"].Visible = false;
            dataGridView1.Columns["Competition"].Visible = false;
            dataGridView1.Columns["Tittle"].Visible = false;
            dataGridView1.Columns["UnitCode"].Visible = false;

            var checkedItems = clbColumns.CheckedItems;
            foreach (var item in checkedItems)
            {
                if(item.ToString() == "Mã") dataGridView1.Columns["Code"].Visible = true;
                if (item.ToString() == "CCCD") dataGridView1.Columns["IdentityCard"].Visible = true;
                
                //clbColumns.Items.Add("Mã");
                if (item.ToString() == "Họ và tên") dataGridView1.Columns["FullName"].Visible = true;
                //clbColumns.Items.Add("Họ tên");
                if (item.ToString() == "Quê quán(xã, huyện, tỉnh)") dataGridView1.Columns["Hometown"].Visible = true;
                //clbColumns.Items.Add("Quê quán");
                if (item.ToString() == "Hộ khẩu TT") dataGridView1.Columns["Address"].Visible = true;
                //clbColumns.Items.Add("Địa chỉ");
                if (item.ToString() == "Năm sinh") dataGridView1.Columns["DateOfBird"].Visible = true;
                //clbColumns.Items.Add("Ngày sinh");
                if (item.ToString() == "Giới tính") dataGridView1.Columns["Sex"].Visible = true;
                //clbColumns.Items.Add("Giới tính");
                if (item.ToString() == "Công tác chuyên trách") dataGridView1.Columns["ResponsibleName"].Visible = true;
                //clbColumns.Items.Add("Công tác chuyên trách");
                if (item.ToString() == "Ngày vào CAND") dataGridView1.Columns["YearBegin"].Visible = true;
                //clbColumns.Items.Add("Ngày vào CAND");
                if (item.ToString() == "Ngày vào CAND chính thức") dataGridView1.Columns["OfficialStartYear"].Visible = true;
                //clbColumns.Items.Add("Ngày chính thức");
                if (item.ToString() == "Ngày vào đảng") dataGridView1.Columns["CommunistPartyBegin"].Visible = true;
                //clbColumns.Items.Add("Ngày vào đảng");
                if (item.ToString() == "Cấp bậc") dataGridView1.Columns["LevelCode"].Visible = true;
                //clbColumns.Items.Add("Cấp bậc");
                if (item.ToString() == "Chức danh") dataGridView1.Columns["Tittle"].Visible = true;
                //clbColumns.Items.Add("Chức danh");
                if (item.ToString() == "Chức vụ") dataGridView1.Columns["Position"].Visible = true;
                //clbColumns.Items.Add("Chức vụ");
                if (item.ToString() == "Trường ngoài CAND") dataGridView1.Columns["SchoolName"].Visible = true;
                //clbColumns.Items.Add("Chuyên ngành đào tạo ngoài CAND");
                if (item.ToString() == "Chuyên ngành đào tạo ngoài CAND") dataGridView1.Columns["Major"].Visible = true;
                //clbColumns.Items.Add("Trường ngoài CAND");
                if (item.ToString() == "Năm tốt nghiệp ngoài CAND") dataGridView1.Columns["SchoolYear"].Visible = true;
                //clbColumns.Items.Add("Năm tốt nghiệp ngoài CAND");
                if (item.ToString() == "Hình thức hình đào tạo ngoài CAND") dataGridView1.Columns["TraningType"].Visible = true;
                //clbColumns.Items.Add("Hình thức hình đào tạo ngoài CAND");
                if (item.ToString() == "Trình độ đào tạo ngoài CAND") dataGridView1.Columns["AcademicLevelName"].Visible = true;

                //clbColumns.Items.Add("Trình độ đào tạo ngoài CAND");
                if (item.ToString() == "Trình độ đào tạo trong CAND") dataGridView1.Columns["InternalAcademicLevelName"].Visible = true;
                //clbColumns.Items.Add("Trình độ đào tạo trong CAND");
                if (item.ToString() == "Trường trong CAND") dataGridView1.Columns["InternalSchool"].Visible = true;
                //clbColumns.Items.Add("Chuyên ngành đào tạo trong CAND");
                if (item.ToString() == "Chuyên ngành đào tạo trong CAND") dataGridView1.Columns["InternalMajor"].Visible = true;
                //clbColumns.Items.Add("Trường trong CAND");
                if (item.ToString() == "Năm tốt nghiệp trong CAND") dataGridView1.Columns["InternalSchoolYear"].Visible = true;
                //clbColumns.Items.Add("Năm tốt nghiệp trong CAND");
                if (item.ToString() == "Hình thức hình đào tạo trong CAND") dataGridView1.Columns["InternalTraningType"].Visible = true;

                //clbColumns.Items.Add("Hình thức hình đào tạo trong CAND");
                if (item.ToString() == "Trường đang đào tạo trong CAND") dataGridView1.Columns["CurInternalSchool"].Visible = true;
                //clbColumns.Items.Add("Chuyên ngành đang đào tạo trong CAND");
                if (item.ToString() == "Chuyên ngành đang đào tạo trong CAND") dataGridView1.Columns["CurInternalMajor"].Visible = true;
                //clbColumns.Items.Add("Trường đang đào tạo trong CAND");
                if (item.ToString() == "Năm tốt nghiệp trường đang đào tạo trong CAND") dataGridView1.Columns["CurInternalSchoolYear"].Visible = true;
                //clbColumns.Items.Add("Năm tốt nghiệp trường trong CAND");
                if (item.ToString() == "Trình độ đang đào tạo") dataGridView1.Columns["CurInternalAcademicLevelName"].Visible = true;
                //clbColumns.Items.Add("Trình độ đang đào tạo");
                if (item.ToString() == "Hình thức đang đào tạo") dataGridView1.Columns["CurInternalTraningType"].Visible = true;

                //clbColumns.Items.Add("Hình thức đang đào tạo");
                if (item.ToString() == "Bồi dưỡng NLNV") dataGridView1.Columns["FosteringPLNV"].Visible = true;
                //clbColumns.Items.Add("Bồi dưỡng NLNV");
                if (item.ToString() == "Bồi dưỡng chức danh") dataGridView1.Columns["TittleTraning"].Visible = true;
                //clbColumns.Items.Add("Bồi dưỡng chức danh");
                if (item.ToString() == "Bồi dưỡng quy hoạch chức danh") dataGridView1.Columns["TittleTraningPlanning"].Visible = true;
                //clbColumns.Items.Add("Bồi dưỡng quy hoạch chức danh");
                if (item.ToString() == "Bồi dưỡng QPAN") dataGridView1.Columns["FosteringQPA"].Visible = true;
                //clbColumns.Items.Add("Bồi dưỡng QPAN");
                if (item.ToString() == "Trình độ LLCT") dataGridView1.Columns["PoliticalLevel"].Visible = true;
                //clbColumns.Items.Add("Trình độ LLCT");
                if (item.ToString() == "Hình thức đào tạo LLCT") dataGridView1.Columns["PoliticalLevelForm"].Visible = true;
                //clbColumns.Items.Add("Hình thức đào tạo LLCT");
                if (item.ToString() == "Phân loại cán bộ") dataGridView1.Columns["Classify"].Visible = true;
                //clbColumns.Items.Add("Phân loại cán bộ");
                if (item.ToString() == "Phân loại thi đua") dataGridView1.Columns["Competition"].Visible = true;
                //clbColumns.Items.Add("Phân loại thi đua");
                if (item.ToString() == "Đơn vị chủ quản") dataGridView1.Columns["UnitCode"].Visible = true;
                //clbColumns.Items.Add("Đơn vị");
                if (item.ToString() == "Đơn vị trực thuộc") dataGridView1.Columns["Department"].Visible = true;
                //clbColumns.Items.Add("Phòng ban");
                if (item.ToString() == "Ghi chú") dataGridView1.Columns["Note"].Visible = true;
                //clbColumns.Items.Add("Ghi chú");

            }
            dataGridView1.Columns["FullName"].HeaderText = "Họ tên";
            dataGridView1.Columns["Code"].HeaderText = "Mã";
            dataGridView1.Columns["IdentityCard"].HeaderText = "CCCD";
            
            dataGridView1.Columns["Sex"].HeaderText = "Giới tính";
            dataGridView1.Columns["Note"].HeaderText = "Ghi chú";
            dataGridView1.Columns["DateOfBird"].HeaderText = "Năm sinh";
            dataGridView1.Columns["Address"].HeaderText = "Hộ khẩu TT";
            dataGridView1.Columns["Hometown"].HeaderText = "Quê quán(xã, huyện, tỉnh)";
            
            dataGridView1.Columns["Levelcode"].HeaderText = "Cấp bậc";
            dataGridView1.Columns["Position"].HeaderText = "Chức danh";
            dataGridView1.Columns["Tittle"].HeaderText = "Chức vụ";
            //dataGridView1.Columns["AcademicLevelName"].HeaderText = "Trình độ";
            dataGridView1.Columns["ResponsibleName"].HeaderText = "Chuyên trách";
            dataGridView1.Columns["YearBegin"].HeaderText = "Ngày vào CAND";
            dataGridView1.Columns["OfficialStartYear"].HeaderText = "Ngày vào CAND chính thức";

            dataGridView1.Columns["InternalAcademicLevelName"].HeaderText = "Trình độ đào tạo trường trong CAND";
            dataGridView1.Columns["InternalMajor"].HeaderText = "Chuyên ngành đào tạo trong CAND";
            dataGridView1.Columns["InternalSchool"].HeaderText = "Tên trường trong CAND";
            dataGridView1.Columns["InternalSchoolYear"].HeaderText = "Năm tốt nghiệp trường trong CAND";
            dataGridView1.Columns["InternalTraningType"].HeaderText = "Hình thức đào tạo trường trong CAND";

            dataGridView1.Columns["CurInternalAcademicLevelName"].HeaderText = "Hệ đang đào tạo lớp trong CAND";
            dataGridView1.Columns["CurInternalMajor"].HeaderText = "Chuyên ngành đang đào tạo trong CAND";
            dataGridView1.Columns["CurInternalSchool"].HeaderText = "Lớp đang đào tạo trong CAND";
            dataGridView1.Columns["CurInternalSchoolYear"].HeaderText = "Năm tốt nghiệp lớp đang đào tạo trong CAND";
            dataGridView1.Columns["CurInternalTraningType"].HeaderText = "Hình thức đang đào tạo lớp trong CAND";

            dataGridView1.Columns["AcademicLevelName"].HeaderText = "Trình độ đào tạo trường ngoài CAND";
            dataGridView1.Columns["Major"].HeaderText = "Chuyên ngành đào tạo ngoài CAND";
            dataGridView1.Columns["SchoolName"].HeaderText = "Tên trường ngoài CAND";
            dataGridView1.Columns["SchoolYear"].HeaderText = "Năm tốt nghiệp trường ngoài CAND";
            dataGridView1.Columns["TraningType"].HeaderText = "Hình thức đang đào tạo ngoài CAND";

            //dataGridView1.Columns["OtherSchool"].HeaderText = "Đào tạo ngoài ngành";
            dataGridView1.Columns["FosteringPLNV"].HeaderText = "Bồi dưỡng PLNV";
            dataGridView1.Columns["TittleTraning"].HeaderText = "Bồi dưỡng chức danh";
            dataGridView1.Columns["TittleTraningPlanning"].HeaderText = "Bồi dưỡng quy hoạch chức danh";
            dataGridView1.Columns["FosteringQPA"].HeaderText = "Bồi dưỡng QP&AN";
            dataGridView1.Columns["PoliticalLevel"].HeaderText = "Trình độ LLCT";
            dataGridView1.Columns["PoliticalLevelForm"].HeaderText = "Hình thức đào tạo LLCT";
            //dataGridView1.Columns["SchoolYear"].HeaderText = "Năm tốt nghiệp";
            dataGridView1.Columns["CommunistPartyBegin"].HeaderText = "Ngày vào đảng";
            dataGridView1.Columns["Classify"].HeaderText = "Phân loại cán bộ";
            dataGridView1.Columns["Competition"].HeaderText = "Phân loại thi đua";
            
            dataGridView1.Columns["UnitCode"].HeaderText = "Đơn vị chủ quản";
            dataGridView1.Columns["Department"].HeaderText = "Đơn vị trực thuộc";
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            // dataGridView1.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            // dataGridView1.Columns["Note"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
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
                if (frmDetail.succesed)
                {
                    if (frmDetail.personId > 0)
                    {
                        allperson = frmDetail.allperson;
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = allperson;
                        Resize();
                    }
                }
                allFosteringProcess = frmDetail.allFosteringProcess;
                allTranningProcess = frmDetail.allTranningProcess;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    string cellValue = selectedRow.Cells["Code"].Value.ToString();
                    Edit(cellValue);
                }
                else
                {
                    MessageBox.Show("Chưa có thông tin nào được chọn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        static string selectedFilePath = String.Empty;

       
        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                int count = 0;
                for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--)
                {
                    DataGridViewRow row = dataGridView1.Rows[i];
                    DataGridViewCheckBoxCell cell = row.Cells["CHECK"] as DataGridViewCheckBoxCell;
                    bool isChecked = Convert.ToBoolean(cell.Value);
                    if (isChecked)
                    {
                        count = 1;
                        break;
                    }
                }
                if (count == 0) { MessageBox.Show("Không có dữ liệu được chọn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                foreach (DataGridViewColumn column in dataGridView1.Columns.Cast<DataGridViewColumn>().ToList())
                {
                    if (!column.Visible)
                    {
                        dataGridView1.Columns.Remove(column);
                    }
                }
                SpreadsheetInfo.SetLicense(Common.excelLicence);
                var workbook = new ExcelFile();
                var worksheet = workbook.Worksheets.Add("Sheet1");

                // Thêm header từ DataGridView vào worksheet
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                  
                        worksheet.Cells[0, i].Value = dataGridView1.Columns[i].HeaderText;
                        worksheet.Cells[0, i].Style.Font.Weight = ExcelFont.BoldWeight;
                        worksheet.Cells[0, i].Style.HorizontalAlignment = HorizontalAlignmentStyle.Center;
                        worksheet.Cells[0, i].Style.Borders.SetBorders(MultipleBorders.Outside, SpreadsheetColor.FromName(ColorName.Black), LineStyle.Thin);
                 
                }

                // Thêm dữ liệu từ DataGridView vào worksheet
                int countRow = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewRow row = dataGridView1.Rows[i];
                    DataGridViewCheckBoxCell cell = row.Cells["CHECK"] as DataGridViewCheckBoxCell;
                    bool isChecked = Convert.ToBoolean(cell.Value);
                    if (isChecked)
                    {
                        countRow = countRow + 1;
                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            //if (dataGridView1.Columns[j].Visible)
                            // {
                            dataGridView1.Rows[i].Cells["STT"].Value = countRow;
                            worksheet.Cells[countRow , j].Value = dataGridView1.Rows[i].Cells[j].Value?.ToString();
                            worksheet.Cells[countRow , j].Style.Borders.SetBorders(MultipleBorders.Outside, SpreadsheetColor.FromName(ColorName.Black), LineStyle.Thin);

                            // }
                        }
                    }
                        
                }
                //dataGridView1.DataSource = personSearch;
                //Resize();
                Search();
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                        worksheet.Columns[i].AutoFit();
                }

                // Lưu file Excel
                using (SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = "Excel Files|*.xlsx", Title = "Save an Excel File" })
                {
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        workbook.Save(saveFileDialog.FileName);
                        if (MessageBox.Show("Lưu dữ liệu thành công. Bạn có muốn mở báo cáo không.", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Process.Start(saveFileDialog.FileName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.ToString().Contains("being used by another process"))
                {
                    MessageBox.Show("File đang được mở, vui lòng đóng file trước khi xuất dữ liệu.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
       
        private bool validTranning(TranningProcess traning, ref string message)
        {
            try
            {
                if (Checking.CheckNullString(traning.SchoolName) != "")
                {
                    School politicalLevel = allSchool.FirstOrDefault(obj => obj.Name == traning.SchoolName);
                    if (politicalLevel == null)
                    {
                        message = message + "Tên trường không đúng.,";
                        //  return false;
                    }
                }

                List<string> strings = new List<string>();
                strings.Add("Tốt nghiệp trong CAND");
                strings.Add("Tốt nghiệp trường ngoài CAND");
                strings.Add("Đang học các lớp trong CAND"); 
                if (Checking.CheckNullString(traning.Type) != "")
                {
                    if (!strings.Contains(traning.Type))
                    {
                        message = message + "Loại bồi dưỡng không đúng.,";
                    }
                }
                else
                {
                    message = message + "Loại bồi dưỡng không được bỏ trống.,";
                }
                if (message != "") { return false; }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
          }
        private bool validFostering(FosteringProcess fostering, ref string message)
        {
            try
            {
                if (Checking.CheckNullString(fostering.SchoolName) != "")
                {
                    School politicalLevel = allSchool.FirstOrDefault(obj => obj.Name == fostering.SchoolName);
                    if (politicalLevel == null)
                    {
                        message = message + "Tên trường không đúng.,";
                        //  return false;
                    }
                }
                List<string> strings = new List<string>();
                strings.Add("Tốt nghiệp trong CAND");
                strings.Add("Tốt nghiệp trường ngoài CAND");
                strings.Add("Đang học các lớp trong CAND");
                if (Checking.CheckNullString(fostering.Type) != "")
                {
                    if (!strings.Contains(fostering.Type))
                    {
                        message = message + "Loại bồi dưỡng không đúng.,";
                    }
                }
                else
                {
                    message = message + "Loại bồi dưỡng không được bỏ trống.,";
                }
                if (message != "") { return false; }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        
        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {

                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGray;
            }
            else
            {
                //dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightYellow;
            }
        }

        private void cbxUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Checking.CheckNullInt(cbxUnit.SelectedValue) <= 0 ) { return; }
                List<Department> depSearch = allDepartment.FindAll(item => item.UnitId == Checking.CheckNullInt(cbxUnit.SelectedValue));
                
                if (depSearch.Count > 1)
                {
                    Department depAll = new Department();
                    depAll.Name = "Tất cả";
                    depAll.Id = 900000;
                    depSearch.Add(depAll);
                }
                cbxDepartment.DataSource = depSearch;
                cbxDepartment.DisplayMember = "Name";
                cbxDepartment.ValueMember = "Id";
                cbxDepartment.Text = "Tất cả";
                cbxDepartment.DropDownStyle = ComboBoxStyle.DropDownList;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbxCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox headerCheckBox = (CheckBox)sender;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    ((DataGridViewCheckBoxCell)row.Cells["CHECK"]).Value = headerCheckBox.Checked;
                }
                dataGridView1.RefreshEdit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool check = checkBox1.Checked;
            for (int i = 0; i < clbColumns.Items.Count; i++)
            {
                clbColumns.SetItemChecked(i, check);
            }
        }
    }
}

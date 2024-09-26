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

namespace QuanLyNhanSu.Report
{
    public partial class frmLevelReport : Form
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

        public frmLevelReport()
        {
            InitializeComponent();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmUnits_Load(object sender, EventArgs e)
        {
            //dataGridView1.RowTemplate.Height = 50;
          //  dataGridView1.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            LoadData();
            Resize();
        }
        private void GetData()
        {
            //cbxUnit.DropDownStyle = ComboBoxStyle.DropDownList;
            string content = Common.ReadFileContent(QLNSCommon.pathManagerment + fileName);
            allperson = new List<Person>();
            allperson = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Person>>(content);




            //dataGridView1.DataSource = allperson;
            //personSearch = allperson;

            //string contentTranningProcess = Common.ReadFileContent(QLNSCommon.pathManagerment + fileTranningProcess);
            //allTranningProcess = new List<TranningProcess>();
            ////string abc = contentTranningProcess;
            //if (contentTranningProcess.ToString() != "" && !contentTranningProcess.ToString().Contains("Bad")) { allTranningProcess = Newtonsoft.Json.JsonConvert.DeserializeObject<List<TranningProcess>>(contentTranningProcess); }

            //string contentFosteringProcess = Checking.CheckNullString(Common.ReadFileContent(QLNSCommon.pathManagerment + fileFosteringProcess));
            //allFosteringProcess = new List<FosteringProcess>();
            //if (contentFosteringProcess != "" & !contentFosteringProcess.Contains("Bad")) { allFosteringProcess = Newtonsoft.Json.JsonConvert.DeserializeObject<List<FosteringProcess>>(contentFosteringProcess); }

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

                cbxType.Items.Add("Tất cả");
                cbxType.Items.Add("Tốt nghiệp trong CAND");
                cbxType.Items.Add("Tốt nghiệp trường ngoài CAND");
                cbxType.Items.Add("Đang học các lớp trong CAND");
                cbxType.Text = "Tất cả";
                cbxType.DropDownWidth = 300;

                cbxTypeFostering.Items.Add("Tất cả");
                cbxTypeFostering.Items.Add("Bồi dưỡng PLNV");
                cbxTypeFostering.Items.Add("Bồi dưỡng chức danh");
                cbxTypeFostering.Items.Add("Bồi dưỡng quy hoạch chức danh");
                cbxTypeFostering.Items.Add("Bồi dưỡng QPAN");
                cbxTypeFostering.Text = "Tất cả";
                cbxTypeFostering.DropDownWidth = 300;

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
                if (allUnits.Count > 1) 
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
                GetData();
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
                //if (txtCode.Text.Trim() != "")
                //{
                //    personSearch = personSearch.FindAll(item => item.Code.Contains(txtCode.Text.Trim()));
                //}
                //if (txtFullName.Text.Trim() != "")
                //{
                //    personSearch = personSearch.FindAll(item => item.FullName.Contains(txtFullName.Text.Trim()));
                //}
                //if (cbxTypeFostering.Text.Trim() != "" && cbxTypeFostering.Text.Trim() != "Tất cả")
                //{
                //    if (cbxTypeFostering.Text == "Bồi dưỡng PLNV")
                //    {
                //        personSearch = personSearch.FindAll(item => Checking.CheckNullString(item.FosteringPLNV) != "");
                //    }
                //    else if (cbxTypeFostering.Text == "Bồi dưỡng chức danh")
                //    {
                //        personSearch = personSearch.FindAll(item => Checking.CheckNullString(item.TittleTraning) != "");
                //    }
                //    else if (cbxTypeFostering.Text == "Bồi dưỡng quy hoạch chức danh")
                //    {
                //        personSearch = personSearch.FindAll(item => Checking.CheckNullString(item.TittleTraningPlanning) != "");
                //    }
                //    else if (cbxTypeFostering.Text == "Bồi dưỡng QPAN")
                //    {
                //        personSearch = personSearch.FindAll(item => Checking.CheckNullString(item.FosteringQPA) != "");
                //    }
                //    // personSearch = personSearch.FindAll(item => item.TittleTraning.Contains(txtTittleTraning.Text.Trim()) || item.FosteringPLNV.Contains(txtTittleTraning.Text.Trim()) || item.FosteringQPA.Contains(txtTittleTraning.Text.Trim()) || item.TittleTraningPlanning.Contains(txtTittleTraning.Text.Trim()));
                //}
                //if (cbxUnit.Text.Trim() != "" && cbxUnit.Text.Trim() != "Tất cả")
                //{
                //    personSearch = personSearch.FindAll(item => item.UnitCode.Contains(cbxUnit.Text));
                //}
                //if (cbxAcademicLevel.Text.Trim() != "" && cbxAcademicLevel.Text.Trim() != "Tất cả")
                //{
                //    if (cbxType.Text != "Tất cả")
                //    {
                //        if (cbxType.Text == "Tốt nghiệp trong CAND")
                //        {
                //            personSearch = personSearch.FindAll(item => item.InternalAcademicLevelName == cbxAcademicLevel.Text.Trim());
                //        }
                //        else if (cbxType.Text == "Tốt nghiệp trường ngoài CAND")
                //        {
                //            personSearch = personSearch.FindAll(item => item.AcademicLevelName == cbxAcademicLevel.Text.Trim());
                //        }
                //        else if (cbxType.Text == "Đang học các lớp trong CAND")
                //        {
                //            personSearch = personSearch.FindAll(item => item.CurInternalAcademicLevelName == cbxAcademicLevel.Text.Trim());
                //        }
                //    }
                //    else
                //    {
                //        personSearch = personSearch.FindAll(item => item.AcademicLevelName == cbxAcademicLevel.Text.Trim() || item.InternalAcademicLevelName == cbxAcademicLevel.Text.Trim() || item.CurInternalAcademicLevelName == cbxAcademicLevel.Text.Trim());
                //    }
                //}
                //if (cbxDepartment.Text.Trim() != "" && cbxDepartment.Text.Trim() != "Tất cả")
                //{
                //    personSearch = personSearch.FindAll(item => item.Department.Contains(cbxDepartment.Text));
                //}
                //personSearch = personSearch.OrderBy(p => p.FullName).ToList();
                //if (cbxArrange.SelectedItem != null)
                //{
                //    var selectedProperty = ((dynamic)cbxArrange.SelectedItem).Value;

                //    // Sắp xếp danh sách theo thuộc tính được chọn

                //    switch (selectedProperty)
                //    {
                //        case "Code":
                //            personSearch = personSearch.OrderBy(p => p.Code).ToList();
                //            break;
                //        case "FullName":
                //            personSearch = personSearch.OrderBy(p => p.FullName).ToList();
                //            break;
                //        case "UnitCode":
                //            personSearch = personSearch.OrderBy(p => p.UnitCode).ToList();
                //            break;
                //        case "LevelCode":
                //            personSearch = personSearch.OrderBy(p => p.LevelCode).ToList();
                //            break;
                //        case "AcademicLevelName":
                //            personSearch = personSearch.OrderBy(p => p.AcademicLevelName).ToList();
                //            break;
                //        case "Hometown":
                //            personSearch = personSearch.OrderBy(p => p.Hometown).ToList();
                //            break;
                //        case "Address":
                //            personSearch = personSearch.OrderBy(p => p.Address).ToList();
                //            break;
                //    }
                //}
               // personSearch = personSearch.Select .GroupBy(p => p.FullName).ToList();


                var internalAcademicLevelName = personSearch
                                        .Where(person => person.UnitCode == "Phòng Tổ chức cán bộ")
                                        .GroupBy(person => new { person.UnitCode, person.InternalAcademicLevelName })
                                        .Select(group => new
                                        {
                                            CurInternalAcademicLevelName = group.Key.UnitCode,
                                            UnitCode = group.Key.InternalAcademicLevelName,
                                            Count = group.Count()
                                        }).ToList();
                var academicLevelName = personSearch
                                       .Where(person => person.UnitCode == "Phòng Tổ chức cán bộ")
                                       .GroupBy(person => new { person.UnitCode, person.AcademicLevelName })
                                       .Select(group => new
                                       {
                                           CurInternalAcademicLevelName = group.Key.UnitCode,
                                           UnitCode = group.Key.AcademicLevelName,
                                           Count = group.Count()
                                       }).ToList();

                var curInternalAcademicLevelName = personSearch
                                       .Where(person => person.UnitCode == "Phòng Tổ chức cán bộ")
                                       .GroupBy(person => new { person.UnitCode, person.CurInternalAcademicLevelName })
                                       .Select(group => new
                                       {
                                           CurInternalAcademicLevelName = group.Key.UnitCode,
                                           UnitCode = group.Key.CurInternalAcademicLevelName,
                                           Count = group.Count()
                                       }).ToList();

               
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = internalAcademicLevelName;
                //if (personSearch != null) { lblTotal.Text = "Tổng số cán bộ: " + personSearch.Count(); }

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
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = headerFont;
          
            if (dataGridView1.Columns["id"] != null)
            {
                cbxCheckAll.Visible = true;
                dataGridView1.Columns["STT"].Visible = true;
                dataGridView1.Columns["CHECK"].Visible = true;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                dataGridView1.Columns["Code"].Frozen = true;
                dataGridView1.Columns["FullName"].Frozen = true;

                dataGridView1.Columns["id"].Visible = false;
                dataGridView1.Columns["CreatedBy"].Visible = false;
                dataGridView1.Columns["CreatedTime"].Visible = false;
                dataGridView1.Columns["ModifiedBy"].Visible = false;
                dataGridView1.Columns["ModifiedBy"].Visible = false;
                dataGridView1.Columns["ModifiedTime"].Visible = false;
                dataGridView1.Columns["Sex"].Visible = false;
                dataGridView1.Columns["FullName"].HeaderText = "Họ tên";
                dataGridView1.Columns["Code"].HeaderText = "Mã";
                dataGridView1.Columns["Note"].HeaderText = "Ghi chú";
                dataGridView1.Columns["DateOfBird"].HeaderText = "Ngày sinh";
                dataGridView1.Columns["Address"].HeaderText = "Địa chỉ";
                dataGridView1.Columns["Hometown"].HeaderText = "Quê quán";
                dataGridView1.Columns["Department"].HeaderText = "Phòng ban trực thuộc";
                dataGridView1.Columns["Levelcode"].HeaderText = "Cấp bậc";
                //dataGridView1.Columns["AcademicLevelName"].HeaderText = "Trình độ";
                dataGridView1.Columns["ResponsibleName"].HeaderText = "Chuyên trách";
                dataGridView1.Columns["YearBegin"].HeaderText = "Năm bắt đầu";
                dataGridView1.Columns["OfficialStartYear"].HeaderText = "Năm chính thức";

                dataGridView1.Columns["InternalAcademicLevelName"].HeaderText = "Trình độ đào tạo lớp trong CAND";
                dataGridView1.Columns["InternalMajor"].HeaderText = "Chuyên ngành đào tạo lớp trong CAND";
                dataGridView1.Columns["InternalSchool"].HeaderText = "Lớp trong CAND";
                dataGridView1.Columns["InternalSchoolYear"].HeaderText = "Năm tốt nghiệp lớp trong CAND";
                dataGridView1.Columns["InternalTraningType"].HeaderText = "Hình thức đào tạo lớp trong CAND";

                dataGridView1.Columns["CurInternalAcademicLevelName"].HeaderText = "Trình độ đang đào tạo lớp trong CAND";
                dataGridView1.Columns["CurInternalMajor"].HeaderText = "Chuyên ngành đang đào tạo lớp trong CAND";
                dataGridView1.Columns["CurInternalSchool"].HeaderText = "Lớp đang đào tạo trong CAND";
                dataGridView1.Columns["CurInternalSchoolYear"].HeaderText = "Năm tốt nghiệp lớp đang đào tạo trong CAND";
                dataGridView1.Columns["CurInternalTraningType"].HeaderText = "Hình thức đang đào tạo lớp trong CAND";

                dataGridView1.Columns["AcademicLevelName"].HeaderText = "Trình độ đào tạo ngoài CAND";
                dataGridView1.Columns["Major"].HeaderText = "Chuyên ngành đào tạo ngoài CAND";
                dataGridView1.Columns["SchoolName"].HeaderText = "Tên trường ngoài CAND";
                dataGridView1.Columns["SchoolYear"].HeaderText = "Năm tốt nghiệp trường ngoài CAND";
                dataGridView1.Columns["TraningType"].HeaderText = "Hình thức đang đào tạo  ngoài CAND";

                dataGridView1.Columns["Position"].HeaderText = "Chức danh";

                //dataGridView1.Columns["OtherSchool"].HeaderText = "Đào tạo ngoài ngành";
                dataGridView1.Columns["FosteringPLNV"].HeaderText = "Bồi dưỡng PLNV";
                dataGridView1.Columns["TittleTraning"].HeaderText = "Bồi dưỡng chức danh";
                dataGridView1.Columns["TittleTraningPlanning"].HeaderText = "Bồi dưỡng quy hoạch chức danh";
                dataGridView1.Columns["FosteringQPA"].HeaderText = "Bồi dưỡng QP&AN";
                dataGridView1.Columns["PoliticalLevel"].HeaderText = "Trình độ LLCT";
                dataGridView1.Columns["PoliticalLevelForm"].HeaderText = "Hình thức LLCT";
                //dataGridView1.Columns["SchoolYear"].HeaderText = "Năm tốt nghiệp";
                dataGridView1.Columns["CommunistPartyBegin"].HeaderText = "Ngày vào đảng";
                dataGridView1.Columns["Classify"].HeaderText = "Phân loại cán bộ";
                dataGridView1.Columns["Competition"].HeaderText = "Phân loại thi đua";
                dataGridView1.Columns["Tittle"].HeaderText = "Chức vụ";
                dataGridView1.Columns["UnitCode"].HeaderText = "Đơn vị";
                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            else
            {
                cbxCheckAll.Visible = false;
                dataGridView1.Columns["STT"].Visible = false;
                dataGridView1.Columns["CHECK"].Visible = false;
            }
            // dataGridView1.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            // dataGridView1.Columns["Note"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
      
        static string selectedFilePath = String.Empty;

        static void ExportToExcel(List<Person> data, List<TranningProcess> trainning, List<FosteringProcess> fostering)
        {
            try
            {
                selectedFilePath = "" ;
                SpreadsheetInfo.SetLicense(Common.excelLicence);
                string filePath = QLNSCommon.path + "Template\\BieuMau.xlsx";
                // Load file Excel đã có sẵn
                ExcelFile workbook = ExcelFile.Load(filePath);
                ExcelWorksheet worksheet = workbook.Worksheets[0];
                ExcelWorksheet worksheetTranning = workbook.Worksheets[1];
                ExcelWorksheet worksheetFostering = workbook.Worksheets[2];

                int startRow = 2;
               // int startRowTranning = 2;
               // int startRowFostering = 2;

                int stt = 0;
                for (int row = 0; row < data.Count; row++)
                {
                    stt = stt + 1;
                    worksheet.Cells[startRow + row + 1, 0].Value = stt;
                    worksheet.Cells[startRow + row + 1, 1].Value = data[row].Code;
                    worksheet.Cells[startRow + row + 1, 2].Value = data[row].FullName;
                    worksheet.Cells[startRow + row + 1, 3].Value = data[row].DateOfBird;
                    worksheet.Cells[startRow + row + 1, 4].Value = data[row].Sex;
                    worksheet.Cells[startRow + row + 1, 5].Value = data[row].Hometown;
                    worksheet.Cells[startRow + row + 1, 6].Value = data[row].Address;
                    worksheet.Cells[startRow + row + 1, 7].Value = data[row].ResponsibleName;
                    worksheet.Cells[startRow + row + 1, 8].Value = data[row].YearBegin;
                    worksheet.Cells[startRow + row + 1, 9].Value = data[row].OfficialStartYear;
                    worksheet.Cells[startRow + row + 1, 10].Value = data[row].CommunistPartyBegin;
                    worksheet.Cells[startRow + row + 1, 11].Value = data[row].LevelCode;
                    worksheet.Cells[startRow + row + 1, 12].Value = data[row].Position;
                    worksheet.Cells[startRow + row + 1, 13].Value = data[row].Tittle;

                    worksheet.Cells[startRow + row + 1, 14].Value = data[row].InternalSchool;
                    worksheet.Cells[startRow + row + 1, 15].Value = data[row].InternalMajor;
                    worksheet.Cells[startRow + row + 1, 16].Value = data[row].InternalSchoolYear;
                    worksheet.Cells[startRow + row + 1, 17].Value = data[row].InternalAcademicLevelName;
                    worksheet.Cells[startRow + row + 1, 18].Value = data[row].InternalTraningType;

                    worksheet.Cells[startRow + row + 1, 19].Value = data[row].SchoolName;
                    worksheet.Cells[startRow + row + 1, 20].Value = data[row].Major;
                    worksheet.Cells[startRow + row + 1, 21].Value = data[row].SchoolYear;
                    worksheet.Cells[startRow + row + 1, 22].Value = data[row].AcademicLevelName;
                    worksheet.Cells[startRow + row + 1, 23].Value = data[row].TraningType;

                    worksheet.Cells[startRow + row + 1, 24].Value = data[row].CurInternalSchool;
                    worksheet.Cells[startRow + row + 1, 25].Value = data[row].CurInternalMajor;
                    worksheet.Cells[startRow + row + 1, 26].Value = data[row].CurInternalSchoolYear;
                    worksheet.Cells[startRow + row + 1, 27].Value = data[row].CurInternalAcademicLevelName;
                    worksheet.Cells[startRow + row + 1, 28].Value = data[row].CurInternalTraningType;

                    worksheet.Cells[startRow + row + 1, 29].Value = data[row].FosteringPLNV;
                    worksheet.Cells[startRow + row + 1, 30].Value = data[row].TittleTraning;
                    worksheet.Cells[startRow + row + 1, 31].Value = data[row].TittleTraningPlanning;
                    worksheet.Cells[startRow + row + 1, 32].Value = data[row].FosteringQPA;
                    worksheet.Cells[startRow + row + 1, 33].Value = data[row].PoliticalLevel;
                    worksheet.Cells[startRow + row + 1, 34].Value = data[row].PoliticalLevelForm;
                    worksheet.Cells[startRow + row + 1, 35].Value = data[row].Classify;
                    worksheet.Cells[startRow + row + 1, 36].Value = data[row].Competition;
                    worksheet.Cells[startRow + row + 1, 37].Value = data[row].UnitCode;
                    worksheet.Cells[startRow + row + 1, 38].Value = data[row].Department;
                    worksheet.Cells[startRow + row + 1, 39].Value = data[row].Note;
                }
                stt = 0;
                for (int row = 0; row < trainning.Count; row++)
                {
                    stt = stt + 1;
                    worksheetTranning.Cells[startRow + row + 1, 0].Value = stt;
                    worksheetTranning.Cells[startRow + row + 1, 1].Value = trainning[row].PersonCode;
                    worksheetTranning.Cells[startRow + row + 1, 2].Value = trainning[row].Type;
                    worksheetTranning.Cells[startRow + row + 1, 3].Value = trainning[row].SchoolName;
                    worksheetTranning.Cells[startRow + row + 1, 4].Value = trainning[row].Major;
                    worksheetTranning.Cells[startRow + row + 1, 5].Value = trainning[row].BeginYear;
                    worksheetTranning.Cells[startRow + row + 1, 6].Value = trainning[row].EndYear;
                    worksheetTranning.Cells[startRow + row + 1, 7].Value = trainning[row].Level;
                    worksheetTranning.Cells[startRow + row + 1, 8].Value = trainning[row].TraningType;
                    worksheetTranning.Cells[startRow + row + 1, 9].Value = trainning[row].DecisionNumber;
                    worksheetTranning.Cells[startRow + row + 1, 10].Value = trainning[row].Note;
                }
                stt = 0;
                for (int row = 0; row < fostering.Count; row++)
                {
                    stt = stt + 1;
                    worksheetFostering.Cells[startRow + row + 1, 0].Value = stt;
                    worksheetFostering.Cells[startRow + row + 1, 1].Value = fostering[row].PersonCode;
                    worksheetFostering.Cells[startRow + row + 1, 2].Value = fostering[row].Type;
                    worksheetFostering.Cells[startRow + row + 1, 3].Value = fostering[row].SchoolName;
                    //worksheetFostering.Cells[startRow + row + 1, 3].Value = fostering[row].Major;
                    worksheetFostering.Cells[startRow + row + 1, 5].Value = fostering[row].BeginYear;
                    worksheetFostering.Cells[startRow + row + 1, 6].Value = fostering[row].EndYear;
                    // worksheetFostering.Cells[startRow + row + 1, 7].Value = fostering[row].Level;
                    worksheetFostering.Cells[startRow + row + 1, 8].Value = fostering[row].FosteringContent;
                    worksheetFostering.Cells[startRow + row + 1, 9].Value = fostering[row].DecisionNumber;
                    worksheetFostering.Cells[startRow + row + 1, 10].Value = fostering[row].Note;
                }

                // Lưu tập tin Excel
                //workbook.Save(selectedFilePath);
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    saveFileDialog.FilterIndex = 1;
                    saveFileDialog.RestoreDirectory = true;

                    // Show the dialog and get the result.
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Get the selected file path.
                        string filePathName = saveFileDialog.FileName;
                        selectedFilePath = filePathName;
                        // Save the Excel file to the selected path.
                        workbook.Save(filePathName);

                        //Console.WriteLine("File saved successfully to " + filePath);
                    }
                }

                if (MessageBox.Show("Lưu dữ liệu thành công. Bạn có muốn mở báo cáo không.", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (Checking.CheckNullString(selectedFilePath) == "")
                    {
                        return;
                    }
                    Process.Start(selectedFilePath);
                }
            }
            catch (Exception ex)
            {
                if (ex.ToString().Contains("being used by another process"))
                {
                    MessageBox.Show("File đang được mở, vui lòng đóng file trước khi xuất dữ liệu.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

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
                List<string> lstStr = new List<string>();
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
                        lstStr.Add(personCode);
                    }
                }

                //TranningProcess tranningProcess = allTranningProcess.FindAll(item.);
                // List<TranningProcess> selectedPeople = allTranningProcess.Where(p => p.PersonCode ).ToList();
                var tranningProcess = allTranningProcess.Where(p => lstStr.Contains(p.PersonCode)).ToList();
                var fosteringProcess = allFosteringProcess.Where(p => lstStr.Contains(p.PersonCode)).ToList();
                var perSearch = personSearch.Where(p => lstStr.Contains(p.Code)).ToList();
                ExportToExcel(perSearch, tranningProcess, fosteringProcess);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void ReadExcelFile()
        {

            ExcelFile workbook;
            SpreadsheetInfo.SetLicense(Common.excelLicence);
            string filePath = string.Empty;
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Lấy đường dẫn tệp Excel được chọn
                    filePath = openFileDialog.FileName;
                }
                else
                {
                    return;
                }
                string fileTemplatePath = QLNSCommon.path + "Template\\BieuMau.xlsx";
                string error = "";
                if (!Common.ValidateExcelFile(fileTemplatePath, filePath, ref error))
                {
                    MessageBox.Show(error, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                // Mở tệp Excel từ đường dẫn
                workbook = ExcelFile.Load(filePath);

                var worksheet = workbook.Worksheets[0];
                var worksheetTranning = workbook.Worksheets[1];
                int countError = 0;
                string message = string.Empty;
                int columnIndex = worksheetTranning.CalculateMaxUsedColumns();
                // do du lieu TranningProcess
                List<TranningProcess> excelTranningProcess = new List<TranningProcess>();
                for (int rowIndex = 3; rowIndex < worksheetTranning.Rows.Count; rowIndex++)
                {
                    ExcelRow row = worksheetTranning.Rows[rowIndex];
                    TranningProcess data = new TranningProcess
                    {
                        PersonCode = Checking.CheckNullString(row.Cells[1].Value),
                        Type = Checking.CheckNullString(row.Cells[2].Value),
                        SchoolName = Checking.CheckNullString(row.Cells[3].Value),
                        //Sex = Checking.CheckNullString(row.Cells[3].Value),
                        Major = Checking.CheckNullString(row.Cells[4].Value),
                        BeginYear = Checking.CheckNullString(row.Cells[5].Value),
                        EndYear = Checking.CheckNullString(row.Cells[6].Value),
                        Level = Checking.CheckNullString(row.Cells[7].Value),
                        TraningType = Checking.CheckNullString(row.Cells[8].Value),
                        DecisionNumber = Checking.CheckNullString(row.Cells[9].Value),
                        Note = Checking.CheckNullString(row.Cells[10].Value)
                    };
                    message = string.Empty;
                    if (!validTranning(data, ref message))
                    {
                        countError = 1;
                        // Đặt tiêu đề cho cột mới.
                        worksheetTranning.Cells[0, columnIndex].Value = "Chi tiết lỗi";
                        // Đặt giá trị cho từng ô trong cột mới.
                        worksheetTranning.Cells[rowIndex, columnIndex].Value = message;
                        // Lưu tệp Excel đã chỉnh sửa.
                        continue;
                    }
                    else { excelTranningProcess.Add(data); }
                   
                }

                var worksheetFostering = workbook.Worksheets[2];
                List<FosteringProcess> excelFosteringProcess = new List<FosteringProcess>();
                columnIndex = worksheetFostering.CalculateMaxUsedColumns();
                message = string.Empty;
                for (int rowIndex = 3; rowIndex < worksheetFostering.Rows.Count; rowIndex++)
                {
                    ExcelRow row = worksheetFostering.Rows[rowIndex];
                    FosteringProcess data = new FosteringProcess
                    { 
                        PersonCode = Checking.CheckNullString(row.Cells[1].Value),
                        Type = Checking.CheckNullString(row.Cells[2].Value),
                        SchoolName = Checking.CheckNullString(row.Cells[3].Value),
                        //Sex = Checking.CheckNullString(row.Cells[3].Value),
                        //Major = Checking.CheckNullString(row.Cells[3].Value),
                        BeginYear = Checking.CheckNullString(row.Cells[5].Value),
                        EndYear = Checking.CheckNullString(row.Cells[6].Value),
                        //Level = Checking.CheckNullString(row.Cells[6].Value),
                        FosteringContent =Checking.CheckNullString(row.Cells[8].Value),
                        DecisionNumber = Checking.CheckNullString(row.Cells[9].Value),
                        Note = Checking.CheckNullString(row.Cells[10].Value)
                    };
                    message = string.Empty;
                    if (!validFostering(data, ref message))
                    {
                        countError = 1;
                        // Đặt tiêu đề cho cột mới.
                        worksheetFostering.Cells[0, columnIndex].Value = "Chi tiết lỗi";
                        // Đặt giá trị cho từng ô trong cột mới.
                        worksheetFostering.Cells[rowIndex, columnIndex].Value = message;
                        // Lưu tệp Excel đã chỉnh sửa.
                        continue;
                    }
                    else { excelFosteringProcess.Add(data); }
                    
                }

                 columnIndex = worksheet.CalculateMaxUsedColumns();
                 //countError = 0;

                for (int rowIndex = 3; rowIndex < worksheet.Rows.Count; rowIndex++)
                {
                    // Đọc dữ liệu từ từng ô trong dòng

                    ExcelRow row = worksheet.Rows[rowIndex];
                   // string depart = "";
                    //if (Checking.CheckNullString(row.Cells[34].Value) != "" && Checking.CheckNullString(row.Cells[34].Value).Contains("-"))
                    //{
                    //    string[] items = Checking.CheckNullString(row.Cells[34].Value).Split('-');
                    //    depart = items[1];
                    //}
                  
                    //Unit existingObject = allUnits.FirstOrDefault(obj => obj.Name == items[0]);

                    Person data = new Person
                    {
                        Code = Checking.CheckNullString(row.Cells[1].Value),
                        FullName = Checking.CheckNullString(row.Cells[2].Value),
                        DateOfBird = Checking.CheckNullString(row.Cells[3].Value),
                        Sex = Checking.CheckNullString(row.Cells[4].Value),
                        Hometown = Checking.CheckNullString(row.Cells[5].Value),
                        Address = Checking.CheckNullString(row.Cells[6].Value),
                        ResponsibleName = Checking.CheckNullString(row.Cells[7].Value),
                        YearBegin = Checking.CheckNullString(row.Cells[8].Value),
                        OfficialStartYear = Checking.CheckNullString(row.Cells[9].Value),
                        CommunistPartyBegin = Checking.CheckNullString(row.Cells[10].Value),
                        LevelCode = Checking.CheckNullString(row.Cells[11].Value),
                        Position = Checking.CheckNullString(row.Cells[12].Value),
                        Tittle = Checking.CheckNullString(row.Cells[13].Value),

                        InternalSchool = Checking.CheckNullString(row.Cells[14].Value),
                        InternalMajor = Checking.CheckNullString(row.Cells[15].Value),
                        InternalSchoolYear = Checking.CheckNullString(row.Cells[16].Value),
                        InternalAcademicLevelName = Checking.CheckNullString(row.Cells[17].Value),
                        InternalTraningType = Checking.CheckNullString(row.Cells[18].Value),

                        SchoolName = Checking.CheckNullString(row.Cells[19].Value),
                        Major = Checking.CheckNullString(row.Cells[20].Value),
                        SchoolYear = Checking.CheckNullString(row.Cells[21].Value),
                        AcademicLevelName = Checking.CheckNullString(row.Cells[22].Value),
                        TraningType = Checking.CheckNullString(row.Cells[23].Value),

                        CurInternalSchool = Checking.CheckNullString(row.Cells[24].Value),
                        CurInternalMajor = Checking.CheckNullString(row.Cells[25].Value),
                        CurInternalSchoolYear = Checking.CheckNullString(row.Cells[26].Value),
                        CurInternalAcademicLevelName = Checking.CheckNullString(row.Cells[27].Value),
                        CurInternalTraningType = Checking.CheckNullString(row.Cells[28].Value),

                        FosteringPLNV = Checking.CheckNullString(row.Cells[29].Value),
                        TittleTraning = Checking.CheckNullString(row.Cells[30].Value),
                        TittleTraningPlanning = Checking.CheckNullString(row.Cells[31].Value),
                        FosteringQPA = Checking.CheckNullString(row.Cells[32].Value),
                        PoliticalLevel = Checking.CheckNullString(row.Cells[33].Value),
                        PoliticalLevelForm = Checking.CheckNullString(row.Cells[34].Value),
                        Classify = Checking.CheckNullString(row.Cells[35].Value),
                        Competition = Checking.CheckNullString(row.Cells[36].Value),
                        UnitCode = Checking.CheckNullString(row.Cells[37].Value),
                        Department = Checking.CheckNullString(row.Cells[38].Value),
                        Note = Checking.CheckNullString(row.Cells[39].Value)
                    };
                     message = string.Empty;
                    if (!valid(data, ref message))
                    {
                        countError = 1;
                        // Đặt tiêu đề cho cột mới.
                        worksheet.Cells[0, columnIndex].Value = "Chi tiết lỗi";
                        // Đặt giá trị cho từng ô trong cột mới.
                        worksheet.Cells[rowIndex, columnIndex].Value = message;
                        // Lưu tệp Excel đã chỉnh sửa.
                        continue;
                    }
                    //kiem tra thong tin co phu hop khong
                    // Kiểm tra xem đối tượng đã tồn tại trong danh sách hay không
                    Person existingObject = allperson.Find(obj => obj.Code == data.Code);
                    if (existingObject != null)
                    {
                        existingObject = data;
                        data.Id = existingObject.Id;
                        allperson.RemoveAll(obj => obj.Code == data.Code);
                        // Thêm đối tượng mới vào danh sách
                        allperson.Add(data);
                    }
                    else
                    {
                        //int maxID = allperson.Max(obj => obj.Id);
                        //data.Id = maxID + 1;
                        allperson.Add(data);
                    }

                    //tim worksheetTranning
                    allTranningProcess.RemoveAll(obj => obj.PersonCode == data.Code);
                    List<TranningProcess> existingTranning = excelTranningProcess.FindAll(obj => obj.PersonCode == data.Code);
                    if(existingTranning != null && existingTranning.Count > 0)
                    allTranningProcess.AddRange(existingTranning);

                    //tim worksheetFostering
                    allFosteringProcess.RemoveAll(obj => obj.PersonCode == data.Code);
                    List<FosteringProcess> existingFostering = excelFosteringProcess.FindAll(obj => obj.PersonCode == data.Code);
                    if (existingFostering != null && existingFostering.Count > 0)
                        allFosteringProcess.AddRange(existingFostering);
                }

              
                if (countError == 0)
                {
                    string str = Newtonsoft.Json.JsonConvert.SerializeObject(allperson);
                    Common.SaveFileContent(QLNSCommon.pathManagerment + fileName, str);

                    string strTranning = Newtonsoft.Json.JsonConvert.SerializeObject(allTranningProcess);
                    Common.SaveFileContent(QLNSCommon.pathManagerment + fileTranningProcess, strTranning);

                    string strFostering = Newtonsoft.Json.JsonConvert.SerializeObject(allFosteringProcess);
                    Common.SaveFileContent(QLNSCommon.pathManagerment + fileFosteringProcess, strFostering);

                    MessageBox.Show("Lưu dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Search();
                }
                else
                {
                    workbook.Save(filePath);
                    MessageBox.Show("Dữ liệu chưa đúng, vui lòng kiểm tra chi tiết trong file excel.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                if (ex.ToString().Contains("being used by another process"))
                {
                    MessageBox.Show("File đang được mở, vui lòng đóng file trước khi xuất dữ liệu.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else 
                {
                    MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ReadExcelFile();
        }
        private bool validTranning(TranningProcess traning, ref string message)
        {
            try
            {
                if (cbxValid.Checked)
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
                }
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
                if (cbxValid.Checked)
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
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        private bool valid(Person personValid, ref string message)
        {
            try
            {
                
                message = string.Empty;
                if (Checking.CheckNullString(personValid.Code) == "")
                {
                    message = "Thiếu số hiệu.,";
                    //return false;
                };
                if (Checking.CheckNullString(personValid.FullName) == "")
                {
                    message = message + "Thiếu họ tên cán bộ.,";
                    // return false;
                };
                if (Checking.CheckNullString(personValid.DateOfBird) == "")
                {
                    message = message + "Thiếu ngày tháng năm sinh.,";
                    // return false;
                }
                else
                {
                    if (!QLNSCommon.IsValidDate(Checking.CheckNullString(personValid.DateOfBird), "dd/MM/yyyy"))
                    {
                        message = message + "Ngày tháng năm sinh không đúng định dạng (dd/MM/yyyy),";
                    };
                }
                if (Checking.CheckNullString(personValid.YearBegin) != "")
                {
                    if (!QLNSCommon.IsValidDate(Checking.CheckNullString(personValid.YearBegin), "dd/MM/yyyy"))
                    {
                        message = message + "Ngày tháng năm vào CAND không đúng định dạng(dd/MM/yyyy),";
                    };
                }
                if (Checking.CheckNullString(personValid.OfficialStartYear) != "")
                {
                    if (!QLNSCommon.IsValidDate(Checking.CheckNullString(personValid.OfficialStartYear), "dd/MM/yyyy"))
                    {
                        message = message + "Ngày tháng năm vào CAND chính thức không đúng định dạng (dd/MM/yyyy),";
                    };
                }
                if (Checking.CheckNullString(personValid.CommunistPartyBegin) != "")
                {
                    if (!QLNSCommon.IsValidDate(Checking.CheckNullString(personValid.CommunistPartyBegin), "dd/MM/yyyy"))
                    {
                        message = message + "Ngày tháng năm vào đảng không đúng định dạng (dd/MM/yyyy),";
                    };
                }

                if (Checking.CheckNullString(personValid.Hometown) == "")
                {
                    message = message + "Thiếu quê quán.,";
                    //return false;
                };
                if (Checking.CheckNullString(personValid.UnitCode) == "")
                {
                    message = message + "Bạn phải nhập đơn vị, phòng ban.,";
                    return false;
                }
                else
                {
                    // don vi phu hop
                    //string[] items = personValid.UnitCode.Split('-');
                    Unit existingObject = allUnits.FirstOrDefault(obj => obj.Name == personValid.UnitCode);
                    if (existingObject == null)
                    {
                        message = message + "Không tồn tại đơn vị.,";
                        //  return false;
                    }
                };


                if (cbxValid.Checked)
                {
                    if (Checking.CheckNullString(personValid.Address) == "")
                    {
                        message = message + "Bạn phải nhập hộ khẩu thường trú.,";
                        // return false;
                    };
                    if (Checking.CheckNullString(personValid.YearBegin) == "")
                    {
                        message = message + "Bạn phải nhập năm vào CAND.,";
                        // return false;
                    };

                    if (Checking.CheckNullString(personValid.OfficialStartYear) == "")
                    {
                        message = message + "Bạn phải nhập năm vào CAND chính thức.,";
                        // return false;
                    };

                    if (Checking.CheckNullString(personValid.LevelCode) == "")
                    {
                        message = message + "Bạn phải nhập cấp bậc.,";
                        // return false;
                    }
                    else
                    {
                        // cap bac phu hop
                        Level existingObject = allLevel.FirstOrDefault(obj => obj.Name == personValid.LevelCode);
                        if (existingObject == null)
                        {
                            message = message + "Cấp bậc không đúng.,";
                            //  return false;
                        }
                    };
                    // trình độ
                    if (Checking.CheckNullString(personValid.AcademicLevelName) != "")
                    {
                        AcademicLevel politicalLevel = allAcademicLevel.FirstOrDefault(obj => obj.Name == personValid.AcademicLevelName);
                        if (politicalLevel == null)
                        {
                            message = message + "Trình độ không đúng.,";
                            //  return false;
                        }
                    }
                    // truong
                    if (Checking.CheckNullString(personValid.SchoolName) != "")
                    {
                        School politicalLevel = allSchool.FirstOrDefault(obj => obj.Name == personValid.SchoolName);
                        if (politicalLevel == null)
                        {
                            message = message + "Tên trường không đúng.,";
                            //  return false;
                        }
                    }
                    if (Checking.CheckNullString(personValid.InternalSchool) != "")
                    {
                        School politicalLevel = allSchool.FirstOrDefault(obj => obj.Name == personValid.SchoolName);
                        if (politicalLevel == null)
                        {
                            message = message + "Tên trường nội bộ không đúng.,";
                            //  return false;
                        }
                    }
                    if (Checking.CheckNullString(personValid.CurInternalSchool) != "")
                    {
                        School politicalLevel = allSchool.FirstOrDefault(obj => obj.Name == personValid.SchoolName);
                        if (politicalLevel == null)
                        {
                            message = message + "Tên trường đang đào tạo không đúng.,";
                            //  return false;
                        }
                    }
                    //if (Checking.CheckNullString(personValid.Position) == "")
                    //{
                    //    message = message + "Bạn phải nhập chức vụ.,";
                    //    //  return false;
                    //};
                    //trinh do LLCT
                    if (Checking.CheckNullString(personValid.PoliticalLevel) != "")
                    {
                        PoliticalLevel politicalLevel = allPoliticalLevel.FirstOrDefault(obj => obj.Name == personValid.PoliticalLevel);
                        if (politicalLevel == null)
                        {
                            message = message + "Trình độ LLCT không đúng.,";
                            //  return false;
                        }
                    }
                    // chuc vu phu hop
                    
                }
                

                if (message != "") { return false; }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        //{
        //    if (e.RowIndex % 2 == 0)
        //    {

        //        dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGray;
        //    }
        //    else
        //    {
        //        //dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightYellow;
        //    }
        //}

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

        private void cbxDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtTittleTraning_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cbxArrange_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void cbxAcademicLevel_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void cbxUnit_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Unit objUnit = new Unit()    ;
                if (Common.glbUnit != "Tất cả")
                {
                    objUnit = allUnits.FindAll(item => item.Name.Contains(Common.glbUnit.Trim())).FirstOrDefault();
                }

                if (Checking.CheckNullInt(objUnit.Id) <= 0) { return; }
                List<Department> depSearch = allDepartment.FindAll(item => item.UnitId == objUnit.Id);

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
    }
}

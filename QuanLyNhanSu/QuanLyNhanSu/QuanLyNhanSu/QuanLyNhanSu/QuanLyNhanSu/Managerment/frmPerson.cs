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

namespace QuanLyNhanSu.Category
{
    public partial class frmPerson : Form
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

        //ETZX-IT28-33Q6-1HA2
        public frmPerson()
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
                string contentLevel = Common.ReadFileContent(Common.pathCategory + fileNameLevel);
                allLevel = new List<Level>();
                allLevel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Level>>(contentLevel);
                this.WindowState = FormWindowState.Maximized;

                string contentAcademicLevel = Common.ReadFileContent(Common.pathCategory + fileNameAcademicLevel);
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

                string contentSchool = Common.ReadFileContent(Common.pathCategory + fileSchoolName);
                allSchool = new List<School>();
                allSchool = Newtonsoft.Json.JsonConvert.DeserializeObject<List<School>>(contentSchool);

                string contentDepartment = Common.ReadFileContent(Common.pathCategory + fileDepartmentName);
                allDepartment = new List<Department>();
                allDepartment = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Department>>(contentDepartment);

                string unit = Common.ReadFileContent(Common.pathCategory + fileUnitName);
                allUnits = new List<Unit>();
                allUnits = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Unit>>(unit);
                if (allUnits.Count > 1) 
                {
                    Unit unitAll = new Unit();
                    unitAll.Name = "Tất cả";
                    unitAll.Id = 900000;
                    allUnits.Add(unitAll);
                }
               
                cbxUnit.DataSource = allUnits;
                cbxUnit.DisplayMember = "Name";
                cbxUnit.ValueMember = "Id";
                cbxUnit.Text = "Tất cả";
                cbxUnit.DropDownStyle = ComboBoxStyle.DropDownList;
                allUnits.RemoveAll(obj => obj.Id == 0);

               

                string contentPoliticalLevel = Common.ReadFileContent(Common.pathCategory + fileNamePoliticalLevel);
                allPoliticalLevel = new List<PoliticalLevel>();
                allPoliticalLevel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<PoliticalLevel>>(contentPoliticalLevel);

                //cbxUnit.DropDownStyle = ComboBoxStyle.DropDownList;
                string content = Common.ReadFileContent(Common.pathManagerment + fileName);
                allperson = new List<Person>();
                allperson = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Person>>(content);
                dataGridView1.DataSource = allperson;
                personSearch = allperson;
               
                string contentTranningProcess = Common.ReadFileContent(Common.pathManagerment + fileTranningProcess);
                allTranningProcess = new List<TranningProcess>();
                //string abc = contentTranningProcess;
                if (contentTranningProcess.ToString() != "" && !contentTranningProcess.ToString().Contains("Bad")) { allTranningProcess = Newtonsoft.Json.JsonConvert.DeserializeObject<List<TranningProcess>>(contentTranningProcess); }
                
                string contentFosteringProcess = Checking.CheckNullString(Common.ReadFileContent(Common.pathManagerment + fileFosteringProcess));
                allFosteringProcess = new List<FosteringProcess>();
                if (contentFosteringProcess != "" & !contentFosteringProcess.Contains("Bad")) { allFosteringProcess = Newtonsoft.Json.JsonConvert.DeserializeObject<List<FosteringProcess>>(contentFosteringProcess); }
                   
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
                if (txtTittleTraning.Text.Trim() != "")
                {
                    personSearch = personSearch.FindAll(item => item.TittleTraning.Contains(txtTittleTraning.Text.Trim()) || item.FosteringPLNV.Contains(txtTittleTraning.Text.Trim()) || item.FosteringQPA.Contains(txtTittleTraning.Text.Trim()) || item.TittleTraningPlanning.Contains(txtTittleTraning.Text.Trim()));
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
                    Common.SaveFileContent(Common.pathManagerment + fileName, str);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = allperson;
                    Resize();
                    //MessageBox.Show("Lưu dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            allFosteringProcess = frmDetail.allFosteringProcess;
            allTranningProcess = frmDetail.allTranningProcess;
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                DataGridViewRow clickedRow = dataGridView1.Rows[e.RowIndex];
                string value = clickedRow.Cells["Code"].Value.ToString();
                Edit(value);
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
                    Common.SaveFileContent(Common.pathManagerment + fileName, str);
                    //xoa bang con
                    string strallTranningProcess = Newtonsoft.Json.JsonConvert.SerializeObject(allTranningProcess);
                    Common.SaveFileContent(Common.pathManagerment + fileTranningProcess, strallTranningProcess);

                    string strallFosteringProcess = Newtonsoft.Json.JsonConvert.SerializeObject(allFosteringProcess);
                    Common.SaveFileContent(Common.pathManagerment + fileFosteringProcess, strallFosteringProcess);

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
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns["CreatedBy"].Visible = false;
            dataGridView1.Columns["CreatedTime"].Visible = false;
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
            dataGridView1.Columns["AcademicLevelName"].HeaderText = "Trình độ";
            dataGridView1.Columns["ResponsibleName"].HeaderText = "Chuyên trách";
            dataGridView1.Columns["YearBegin"].HeaderText = "Năm bắt đầu";
            dataGridView1.Columns["OfficialStartYear"].HeaderText = "Năm chính thức";
            dataGridView1.Columns["InternalSchool"].HeaderText = "Lớp trong CAND";
            dataGridView1.Columns["Position"].HeaderText = "Chức vụ";
            dataGridView1.Columns["SchoolName"].HeaderText = "Tên trường";
            dataGridView1.Columns["OtherSchool"].HeaderText = "Đào tạo ngoài ngành";
            dataGridView1.Columns["FosteringPLNV"].HeaderText = "Bồi dưỡng PLNV";
            dataGridView1.Columns["TittleTraning"].HeaderText = "Bồi dưỡng chức danh";
            dataGridView1.Columns["TittleTraningPlanning"].HeaderText = "Bồi dưỡng quy hoạch chức danh";
            dataGridView1.Columns["FosteringQPA"].HeaderText = "Bồi dưỡng QP&AN";
            dataGridView1.Columns["PoliticalLevel"].HeaderText = "Trình độ LLCT";
            dataGridView1.Columns["SchoolYear"].HeaderText = "Năm tốt nghiệp";
            dataGridView1.Columns["CommunistPartyBegin"].HeaderText = "Ngày vào đảng";
            dataGridView1.Columns["UnitCode"].HeaderText = "Đơn vị";
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

        static void ExportToExcel(List<Person> data, List<TranningProcess> trainning, List<FosteringProcess> fostering)
        {
            try
            {
                selectedFilePath = Common.GetFolderPath() + "\\BieuMau.xlsx";
                SpreadsheetInfo.SetLicense("ETZX-IT28-33Q6-1HA2");
                string filePath = Common.path + "Template\\BieuMau.xlsx";
                // Load file Excel đã có sẵn
                ExcelFile workbook = ExcelFile.Load(filePath);
                ExcelWorksheet worksheet = workbook.Worksheets[0];
                ExcelWorksheet worksheetTranning = workbook.Worksheets[1];
                ExcelWorksheet worksheetFostering = workbook.Worksheets[2];

                int startRow = 2;
                int startRowTranning = 2;
                int startRowFostering = 2;

                int stt = 0;
                for (int row = 0; row < data.Count; row++)
                {
                    stt = stt + 1;
                    worksheet.Cells[startRow + row + 1, 0].Value = stt;
                    worksheet.Cells[startRow + row + 1, 1].Value = data[row].Code;
                    worksheet.Cells[startRow + row + 1, 2].Value = data[row].FullName;
                    worksheet.Cells[startRow + row + 1, 3].Value = data[row].DateOfBird;
                    worksheet.Cells[startRow + row + 1, 4].Value = data[row].Hometown;
                    worksheet.Cells[startRow + row + 1, 5].Value = data[row].Address;
                    worksheet.Cells[startRow + row + 1, 6].Value = data[row].ResponsibleName;
                    worksheet.Cells[startRow + row + 1, 7].Value = data[row].YearBegin;
                    worksheet.Cells[startRow + row + 1, 8].Value = data[row].OfficialStartYear;
                    worksheet.Cells[startRow + row + 1, 9].Value = data[row].LevelCode;
                    worksheet.Cells[startRow + row + 1, 10].Value = data[row].AcademicLevelName;
                    worksheet.Cells[startRow + row + 1, 11].Value = data[row].SchoolName;
                    worksheet.Cells[startRow + row + 1, 12].Value = data[row].SchoolYear;
                    worksheet.Cells[startRow + row + 1, 13].Value = data[row].InternalSchool;
                    worksheet.Cells[startRow + row + 1, 14].Value = data[row].OtherSchool;
                    worksheet.Cells[startRow + row + 1, 15].Value = data[row].FosteringPLNV;
                    worksheet.Cells[startRow + row + 1, 16].Value = data[row].TittleTraning;
                    worksheet.Cells[startRow + row + 1, 17].Value = data[row].TittleTraningPlanning;
                    worksheet.Cells[startRow + row + 1, 18].Value = data[row].FosteringQPA;
                    worksheet.Cells[startRow + row + 1, 19].Value = data[row].PoliticalLevel;
                    worksheet.Cells[startRow + row + 1, 20].Value = data[row].UnitCode;
                    worksheet.Cells[startRow + row + 1, 21].Value = data[row].CommunistPartyBegin;
                    worksheet.Cells[startRow + row + 1, 22].Value = data[row].Note;
                }
                stt = 0;
                for (int row = 0; row < trainning.Count; row++)
                {
                    stt = stt + 1;
                    worksheetTranning.Cells[startRow + row + 1, 0].Value = stt;
                    worksheetTranning.Cells[startRow + row + 1, 1].Value = trainning[row].PersonCode;
                    worksheetTranning.Cells[startRow + row + 1, 2].Value = trainning[row].SchoolName;
                    worksheetTranning.Cells[startRow + row + 1, 3].Value = trainning[row].Major;
                    worksheetTranning.Cells[startRow + row + 1, 4].Value = trainning[row].BeginYear;
                    worksheetTranning.Cells[startRow + row + 1, 5].Value = trainning[row].EndYear;
                    worksheetTranning.Cells[startRow + row + 1, 6].Value = trainning[row].Level;
                    worksheetTranning.Cells[startRow + row + 1, 7].Value = trainning[row].DecisionNumber;
                    worksheetTranning.Cells[startRow + row + 1, 8].Value = trainning[row].Note;
                }
                stt = 0;
                for (int row = 0; row < fostering.Count; row++)
                {
                    stt = stt + 1;
                    worksheetFostering.Cells[startRow + row + 1, 0].Value = stt;
                    worksheetFostering.Cells[startRow + row + 1, 1].Value = fostering[row].PersonCode;
                    worksheetFostering.Cells[startRow + row + 1, 2].Value = fostering[row].SchoolName;
                    worksheetFostering.Cells[startRow + row + 1, 3].Value = fostering[row].Major;
                    worksheetFostering.Cells[startRow + row + 1, 4].Value = fostering[row].BeginYear;
                    worksheetFostering.Cells[startRow + row + 1, 5].Value = fostering[row].EndYear;
                    worksheetFostering.Cells[startRow + row + 1, 6].Value = fostering[row].Level;
                    worksheetFostering.Cells[startRow + row + 1, 7].Value = fostering[row].DecisionNumber;
                    worksheetFostering.Cells[startRow + row + 1, 8].Value = fostering[row].Note;
                }

                // Lưu tập tin Excel
                workbook.Save(selectedFilePath);
                if (MessageBox.Show("Lưu dữ liệu thành công. Bạn có muốn mở báo cáo không.", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
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
                //TranningProcess tranningProcess = allTranningProcess.FindAll(item.);
                // List<TranningProcess> selectedPeople = allTranningProcess.Where(p => p.PersonCode ).ToList();
                var tranningProcess = allTranningProcess.Where(p => personSearch.Any(pf => pf.Code == p.PersonCode)).ToList();
                var fosteringProcess = allFosteringProcess.Where(p => personSearch.Any(pf => pf.Code == p.PersonCode)).ToList();
                ExportToExcel(personSearch, tranningProcess, fosteringProcess);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void ReadExcelFile()
        {

            ExcelFile workbook;
            SpreadsheetInfo.SetLicense("ETZX-IT28-33Q6-1HA2");
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
                string fileTemplatePath = Common.path + "Template\\BieuMau.xlsx";
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
                        SchoolName = Checking.CheckNullString(row.Cells[2].Value),
                        //Sex = Checking.CheckNullString(row.Cells[3].Value),
                        Major = Checking.CheckNullString(row.Cells[3].Value),
                        BeginYear = Checking.CheckNullString(row.Cells[4].Value),
                        EndYear = Checking.CheckNullString(row.Cells[5].Value),
                        Level = Checking.CheckNullString(row.Cells[6].Value),
                        DecisionNumber = Checking.CheckNullString(row.Cells[7].Value),
                        Note = Checking.CheckNullString(row.Cells[8].Value)
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
                        SchoolName = Checking.CheckNullString(row.Cells[2].Value),
                        //Sex = Checking.CheckNullString(row.Cells[3].Value),
                        Major = Checking.CheckNullString(row.Cells[3].Value),
                        BeginYear = Checking.CheckNullString(row.Cells[4].Value),
                        EndYear = Checking.CheckNullString(row.Cells[5].Value),
                        Level = Checking.CheckNullString(row.Cells[6].Value),
                        DecisionNumber = Checking.CheckNullString(row.Cells[7].Value),
                        Note = Checking.CheckNullString(row.Cells[8].Value)
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
                    Person data = new Person
                    {
                        Code = Checking.CheckNullString(row.Cells[1].Value),
                        FullName = Checking.CheckNullString(row.Cells[2].Value),
                        //Sex = Checking.CheckNullString(row.Cells[3].Value),
                        DateOfBird = Checking.CheckNullString(row.Cells[3].Value),
                        Hometown = Checking.CheckNullString(row.Cells[4].Value),
                        Address = Checking.CheckNullString(row.Cells[5].Value),
                        ResponsibleName = Checking.CheckNullString(row.Cells[6].Value),
                        YearBegin = Checking.CheckNullString(row.Cells[7].Value),
                        OfficialStartYear = Checking.CheckNullString(row.Cells[8].Value),
                        LevelCode = Checking.CheckNullString(row.Cells[9].Value),
                        AcademicLevelName = Checking.CheckNullString(row.Cells[10].Value),
                        SchoolName = Checking.CheckNullString(row.Cells[11].Value),
                        SchoolYear = Checking.CheckNullString(row.Cells[12].Value),
                        InternalSchool = Checking.CheckNullString(row.Cells[13].Value),
                        OtherSchool = Checking.CheckNullString(row.Cells[14].Value),
                        FosteringPLNV = Checking.CheckNullString(row.Cells[15].Value),

                        TittleTraning = Checking.CheckNullString(row.Cells[16].Value),
                        TittleTraningPlanning = Checking.CheckNullString(row.Cells[17].Value),

                        FosteringQPA = Checking.CheckNullString(row.Cells[18].Value),
                        //Position = Checking.CheckNullString(row.Cells[19].Value),
                        PoliticalLevel = Checking.CheckNullString(row.Cells[19].Value),

                        UnitCode = Checking.CheckNullString(row.Cells[20].Value),
                        CommunistPartyBegin = Checking.CheckNullString(row.Cells[21].Value),
                        Note = Checking.CheckNullString(row.Cells[22].Value)
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
                    Common.SaveFileContent(Common.pathManagerment + fileName, str);

                    string strTranning = Newtonsoft.Json.JsonConvert.SerializeObject(allTranningProcess);
                    Common.SaveFileContent(Common.pathManagerment + fileTranningProcess, strTranning);

                    string strFostering = Newtonsoft.Json.JsonConvert.SerializeObject(allFosteringProcess);
                    Common.SaveFileContent(Common.pathManagerment + fileFosteringProcess, strFostering);

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
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (Checking.CheckNullString(traning.SchoolName) != "")
                {
                    School politicalLevel = allSchool.FirstOrDefault(obj => obj.Name == traning.SchoolName);
                    if (politicalLevel == null)
                    {
                        message = message + "Tên trường không đúng.,";
                        //  return false;
                    }
                }

                if (Checking.CheckNullString(traning.Level) != "")
                {
                    AcademicLevel level = allAcademicLevel.FirstOrDefault(obj => obj.Name == traning.Level);
                    if (level == null)
                    {
                        message = message + "Trình độ không đúng.,";
                        //  return false;
                    }
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

                if (Checking.CheckNullString(fostering.Level) != "")
                {
                    AcademicLevel level = allAcademicLevel.FirstOrDefault(obj => obj.Name == fostering.Level);
                    if (level == null)
                    {
                        message = message + "Trình độ không đúng.,";
                        //  return false;
                    }
                }
                if (message != "") { return false; }
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

                if (Checking.CheckNullString(personValid.Hometown) == "")
                {
                    message = message + "Thiếu quê quán.,";
                    //return false;
                };

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
                if (Checking.CheckNullString(personValid.UnitCode) == "")
                {
                    message = message + "Bạn phải nhập đơn vị, phòng ban.,";
                    return false;
                }
                else
                {
                    // don vi phu hop
                    string[] items = personValid.UnitCode.Split('-');
                    Unit existingObject = allUnits.FirstOrDefault(obj => obj.Name == items[0]);
                    if (existingObject == null)
                    {
                        message = message + "Không tồn tại đơn vị.,";
                        //  return false;
                    }
                };

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
                cbxDepartment.DataSource = depSearch;
                cbxDepartment.DisplayMember = "Name";
                cbxDepartment.ValueMember = "Id";
                cbxDepartment.DropDownStyle = ComboBoxStyle.DropDownList;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

using GemBox.Spreadsheet;
using Newtonsoft.Json.Linq;
using QuanLyNhanSu.Entity;
using QuanLyTrinhDo.Entity;
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

namespace QuanLyNhanSu.HuanLuyenDauKhoa
{
    public partial class frmDanhSachHuanLuyen : Form
    {

        string fileName = "Trainee\\Trainee.txt";
        // List<Person> person;
        List<Trainee> allTrainee;
        List<Trainee> TraineeSearch = new List<Trainee>();

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


        public frmDanhSachHuanLuyen()
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
            string content = Common.ReadFileContent(QLNSCommon.pathTrainee + fileName);
            allTrainee = new List<Trainee>();
            if (content != "Bad Data.\r\n")
            {
                allTrainee = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Trainee>>(content);
                //dataGridView1.DataSource = allperson;
                //personSearch = allperson;
            }
           
            

          
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

                //string contentPoliticalLevel = Common.ReadFileContent(QLNSCommon.pathCategory + fileNamePoliticalLevel);
                //allPoliticalLevel = new List<PoliticalLevel>();
                //allPoliticalLevel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<PoliticalLevel>>(contentPoliticalLevel);
                GetData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi trong quá trình xử lý dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Search()
        {
            try
            {
                //personSearch = new List<Person>();
                TraineeSearch = allTrainee;
                if (txtCode.Text.Trim() != "")
                {
                    TraineeSearch = TraineeSearch.FindAll(item => item.Ma.Contains(txtCode.Text.Trim()));
                }
                if (txtFullName.Text.Trim() != "")
                {
                    TraineeSearch = TraineeSearch.FindAll(item => item.HoTen.Contains(txtFullName.Text.Trim()));
                }
                
                if (cbxUnit.Text.Trim() != "" && cbxUnit.Text.Trim() != "Tất cả")
                {
                    TraineeSearch = TraineeSearch.FindAll(item => item.DonViThamGiaHuanLuyen.Contains(cbxUnit.Text));
                }
                
                //if (cbxDepartment.Text.Trim() != "" && cbxDepartment.Text.Trim() != "Tất cả")
                //{
                //    TraineeSearch = TraineeSearch.FindAll(item => item.Department.Contains(cbxDepartment.Text));
                //}
                //personSearch = personSearch.OrderBy(p => p.FullName).ToList();
                
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = TraineeSearch;
                if (TraineeSearch != null) { lblTotal.Text = "Tổng số cán bộ: " + TraineeSearch.Count(); }

                Resize();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi trong quá trình xử lý dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Lỗi trong quá trình xử lý dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Edit(string value)
        {
            Trainee person = allTrainee.FirstOrDefault(obj => obj.Ma == value);
            frmDanhSachHuanLuyen frmDetail = new frmDanhSachHuanLuyen();
            //frmDetail.personId = person.Id;
            //frmDetail.person = person;
            //frmDetail.allperson = allperson;
            //frmDetail.allUnits = allUnits;
            //frmDetail.allFosteringProcess = allFosteringProcess;
            //frmDetail.allTranningProcess = allTranningProcess;

            //frmDetail.ShowDialog();
            //if (frmDetail.succesed)
            //{
            //    if (frmDetail.personId == person.Id)
            //    {
            //        string str = Newtonsoft.Json.JsonConvert.SerializeObject(allperson);
            //        Common.SaveFileContent(QLNSCommon.pathManagerment + fileName, str);
            //        //GetData();
            //        dataGridView1.DataSource = null;
            //        dataGridView1.DataSource = allperson;
            //        Resize();
            //        //MessageBox.Show("Lưu dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //allFosteringProcess = frmDetail.allFosteringProcess;
            //allTranningProcess = frmDetail.allTranningProcess;
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
                MessageBox.Show("Lỗi trong quá trình xử lý dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            //allTranningProcess.RemoveAll(obj => obj.PersonCode == personCode);
                            //allFosteringProcess.RemoveAll(obj => obj.PersonCode == personCode);
                           // allperson.RemoveAll(obj => obj.Code == personCode);
                        }
                    }
                   // string str = Newtonsoft.Json.JsonConvert.SerializeObject(allperson);
                   // Common.SaveFileContent(QLNSCommon.pathManagerment + fileName, str);
                    //xoa bang con
                   // ileFosteringProcess, strallFosteringProcess);

                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = allTrainee;
                    Resize();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi trong quá trình xử lý dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Resize()
        {
            System.Drawing.Font headerFont = new System.Drawing.Font(dataGridView1.Font, System.Drawing.FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = headerFont;
          
            if (dataGridView1.Columns["id"] != null)
            {
                //dataGridView1.Columns["OtherSchool"].HeaderText = "Đào tạo ngoài ngành";
                dataGridView1.Columns["Ma"].HeaderText = "Số hiệu";
                dataGridView1.Columns["HoTen"].HeaderText = "Họ tên";
                dataGridView1.Columns["NgaySinh"].HeaderText = "Ngày sinh";
                dataGridView1.Columns["QueQuan"].HeaderText = "Quê quán";
                dataGridView1.Columns["SoCCCD"].HeaderText = "Số CCCD";
                dataGridView1.Columns["NgayCap"].HeaderText = "Ngày cấp";
                //dataGridView1.Columns["SchoolYear"].HeaderText = "Năm tốt nghiệp";
                dataGridView1.Columns["NoiCap"].HeaderText = "Nơi cấp";
                dataGridView1.Columns["Truong"].HeaderText = "Trường";
                dataGridView1.Columns["Khoa"].HeaderText = "Khóa";
                dataGridView1.Columns["DonViThamGiaHuanLuyen"].HeaderText = "Đơn vị tham gia";
                dataGridView1.Columns["DieuLenhCAND"].HeaderText = "Điều lệnh CAND";

                dataGridView1.Columns["VoThuatCAND"].HeaderText = "Võ thuật CAND";
                dataGridView1.Columns["KienThucBoTro"].HeaderText = "Kiến thức bổ trợ";
                dataGridView1.Columns["SungNganHS9"].HeaderText = "Súng ngắn HS9";
                dataGridView1.Columns["SungAK"].HeaderText = "Súng AK";
                dataGridView1.Columns["KyThuatChienDau"].HeaderText = "KT chiến đấu";
                dataGridView1.Columns["KyThuatVanDongDuoiNuoc"].HeaderText = "KT vận động dưới nước";
                dataGridView1.Columns["ChienThuatChienDau"].HeaderText = "Chiến thuật chiến đấu";
                dataGridView1.Columns["RenTheLuc"].HeaderText = "Rèn thể lực";
                dataGridView1.Columns["DiemTB"].HeaderText = "Điểm TB";
                dataGridView1.Columns["XepLoai"].HeaderText = "Xếp loại";

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
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //int maxID = 0;
                //if (allperson != null && allperson.Count > 0) { maxID = allperson.Max(obj => obj.Id); }
                //else
                //{
                //    allperson = new List<Person>();
                //    maxID = 1;
                //}

                frmChiTietHuanLuyen frmDetail = new frmChiTietHuanLuyen();
               // frmDetail.maxpersonId = maxID;
               // frmDetail.allUnits = allUnits;
               // frmDetail.allFosteringProcess = allFosteringProcess;
                //frmDetail.allTranningProcess = allTranningProcess;
               // frmDetail.allperson = allperson;
                frmDetail.ShowDialog();
                if (frmDetail.succesed)
                {

                    if (frmDetail.personId > 0)
                    {
                        GetData();
                        // allperson = frmDetail.allperson;
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = allTrainee;
                        Resize();
                    }
                }
                //allFosteringProcess = frmDetail.allFosteringProcess;
                // allTranningProcess = frmDetail.allTranningProcess;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi trong quá trình xử lý dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Lỗi trong quá trình xử lý dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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
                    worksheet.Cells[startRow + row + 1, 2].Value = data[row].IdentityCard;
                    worksheet.Cells[startRow + row + 1, 3].Value = data[row].FullName;
                    worksheet.Cells[startRow + row + 1, 4].Value = data[row].DateOfBird;
                    worksheet.Cells[startRow + row + 1, 5].Value = data[row].Sex;
                    worksheet.Cells[startRow + row + 1, 6].Value = data[row].Hometown;
                    worksheet.Cells[startRow + row + 1, 7].Value = data[row].Address;
                    worksheet.Cells[startRow + row + 1, 8].Value = data[row].ResponsibleName;
                    worksheet.Cells[startRow + row + 1, 9].Value = data[row].YearBegin;
                    worksheet.Cells[startRow + row + 1, 10].Value = data[row].OfficialStartYear;
                    worksheet.Cells[startRow + row + 1, 11].Value = data[row].CommunistPartyBegin;
                    worksheet.Cells[startRow + row + 1, 12].Value = data[row].LevelCode;
                    worksheet.Cells[startRow + row + 1, 13].Value = data[row].Position;
                    worksheet.Cells[startRow + row + 1, 14].Value = data[row].Tittle;

                    worksheet.Cells[startRow + row + 1, 15].Value = data[row].InternalSchool;
                    worksheet.Cells[startRow + row + 1, 16].Value = data[row].InternalMajor;
                    worksheet.Cells[startRow + row + 1, 17].Value = data[row].InternalSchoolYear;
                    worksheet.Cells[startRow + row + 1, 18].Value = data[row].InternalAcademicLevelName;
                    worksheet.Cells[startRow + row + 1, 19].Value = data[row].InternalTraningType;

                    worksheet.Cells[startRow + row + 1, 20].Value = data[row].SchoolName;
                    worksheet.Cells[startRow + row + 1, 21].Value = data[row].Major;
                    worksheet.Cells[startRow + row + 1, 22].Value = data[row].SchoolYear;
                    worksheet.Cells[startRow + row + 1, 23].Value = data[row].AcademicLevelName;
                    worksheet.Cells[startRow + row + 1, 24].Value = data[row].TraningType;

                    worksheet.Cells[startRow + row + 1, 25].Value = data[row].CurInternalSchool;
                    worksheet.Cells[startRow + row + 1, 26].Value = data[row].CurInternalMajor;
                    worksheet.Cells[startRow + row + 1, 27].Value = data[row].CurInternalSchoolYear;
                    worksheet.Cells[startRow + row + 1, 28].Value = data[row].CurInternalAcademicLevelName;
                    worksheet.Cells[startRow + row + 1, 29].Value = data[row].CurInternalTraningType;

                    worksheet.Cells[startRow + row + 1, 30].Value = data[row].FosteringPLNV;
                    worksheet.Cells[startRow + row + 1, 31].Value = data[row].TittleTraning;
                    worksheet.Cells[startRow + row + 1, 32].Value = data[row].TittleTraningPlanning;
                    worksheet.Cells[startRow + row + 1, 33].Value = data[row].FosteringQPA;
                    worksheet.Cells[startRow + row + 1, 34].Value = data[row].PoliticalLevel;
                    worksheet.Cells[startRow + row + 1, 35].Value = data[row].PoliticalLevelForm;
                    worksheet.Cells[startRow + row + 1, 36].Value = data[row].Classify;
                    worksheet.Cells[startRow + row + 1, 37].Value = data[row].Competition;
                    worksheet.Cells[startRow + row + 1, 38].Value = data[row].UnitCode;
                    worksheet.Cells[startRow + row + 1, 39].Value = data[row].Department;
                    worksheet.Cells[startRow + row + 1, 40].Value = data[row].Note;
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
                if ("Lỗi trong quá trình xử lý dữ liệu.".Contains("being used by another process"))
                {
                    MessageBox.Show("File đang được mở, vui lòng đóng file trước khi xuất dữ liệu.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Lỗi trong quá trình xử lý dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                //var tranningProcess = allTranningProcess.Where(p => lstStr.Contains(p.PersonCode)).ToList();
                //var fosteringProcess = allFosteringProcess.Where(p => lstStr.Contains(p.PersonCode)).ToList();
                var perSearch = TraineeSearch.Where(p => lstStr.Contains(p.Ma)).ToList();
                //ExportToExcel(perSearch, tranningProcess, fosteringProcess);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi trong quá trình xử lý dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void ReadExcelFile()
        {

            
        }
        private void button1_Click(object sender, EventArgs e)
        {
           // ReadExcelFile();
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
                //if (Checking.CheckNullString(personValid.IdentityCard) == "")
                //{
                //    message = "Thiếu số căn cước công dân.,";
                //    //return false;
                //};
                //if (Checking.CheckNullString(personValid.IdentityCard) != "" && Checking.CheckNullString(personValid.IdentityCard).Length != 12)
                //{
                //    message = "Số căn cước công dân phải đủ 12 ký tự.,";
                //    //return false;
                //};
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
                    //if (Checking.CheckNullString(personValid.PoliticalLevel) != "")
                    //{
                    //    PoliticalLevel politicalLevel = allPoliticalLevel.FirstOrDefault(obj => obj.Name == personValid.PoliticalLevel);
                    //    if (politicalLevel == null)
                    //    {
                    //        message = message + "Trình độ LLCT không đúng.,";
                    //        //  return false;
                    //    }
                    //}
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

                MessageBox.Show("Lỗi trong quá trình xử lý dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Lỗi trong quá trình xử lý dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                MessageBox.Show("Lỗi trong quá trình xử lý dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

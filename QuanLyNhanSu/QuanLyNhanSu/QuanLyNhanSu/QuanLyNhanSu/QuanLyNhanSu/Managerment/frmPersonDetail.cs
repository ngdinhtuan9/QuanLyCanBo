using Newtonsoft.Json.Linq;
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

namespace QuanLyNhanSu.Category
{
    public partial class frmPersonDetail : Form
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

        List<AcademicLevel> allAcademicLevel;
        string fileNameAcademicLevel = "AcademicLevel\\AcademicLevel.txt";


        List<Position> allPosition;
        string fileNamePosition = "Position\\Position.txt";


        public List<TranningProcess> allTranningProcess;
        string fileTranningProcess = "TranningProcess\\TranningProcess.txt";

        public List<FosteringProcess> allFosteringProcess;
        string fileFosteringProcess = "FosteringProcess\\FosteringProcess.txt";
        public frmPersonDetail()
        {
            InitializeComponent();
        }

        private void frmUnitDetail_Load(object sender, EventArgs e)
        {
            try
            {
                txtCode.Focus();
                DtDateOfBird.Value = DateTime.Now.AddYears(-15);

                DataTable dataTable = new DataTable();
                DataColumn columnGender = new DataColumn("Gender", typeof(string));
                dataTable.Columns.Add(columnGender);
                dataTable.Rows.Add("Nam");
                dataTable.Rows.Add("Nữ");

                cbxGender.DataSource = dataTable;
                cbxGender.DisplayMember = "Gender";
                cbxGender.DropDownStyle = ComboBoxStyle.DropDownList;

                //don vi
                cbxUnit.DataSource = allUnits;
                cbxUnit.DisplayMember = "Name";
                cbxUnit.ValueMember = "Id";
                cbxUnit.DropDownStyle = ComboBoxStyle.DropDownList;

                //phong
                string contentDepartment = Common.ReadFileContent(Common.pathCategory + fileDepartmentName);
                allDepartment = new List<Department>();
                allDepartment = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Department>>(contentDepartment);
                cbxDepartment.DataSource = allDepartment;
                cbxDepartment.DisplayMember = "Name";
                cbxDepartment.ValueMember = "Id";
                cbxDepartment.DropDownStyle = ComboBoxStyle.DropDownList;

                //chuc vu
                string contentResponsible = Common.ReadFileContent(Common.pathCategory + fileResponsibleName);
                allResponsible = new List<Responsible>();
                allResponsible = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Responsible>>(contentResponsible);
                cbxResponsible.DataSource = allResponsible;
                cbxResponsible.DisplayMember = "Name";
                cbxResponsible.ValueMember = "Id";
                cbxResponsible.DropDownStyle = ComboBoxStyle.DropDownList;

                //cap bac
                string contentLevel = Common.ReadFileContent(Common.pathCategory + fileNameLevel);
                allLevel = new List<Level>();
                allLevel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Level>>(contentLevel);
                cbxLevel.DataSource = allLevel;
                cbxLevel.DisplayMember = "Name";
                cbxLevel.ValueMember = "Id";
                cbxLevel.DropDownStyle = ComboBoxStyle.DropDownList;

                //trinh do LLCT
                string contentPoliticalLevel = Common.ReadFileContent(Common.pathCategory + fileNamePoliticalLevel);
                allPoliticalLevel = new List<PoliticalLevel>();
                allPoliticalLevel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<PoliticalLevel>>(contentPoliticalLevel);
                cbxPoliticalLevel.DataSource = allPoliticalLevel;
                cbxPoliticalLevel.DisplayMember = "Name";
                cbxPoliticalLevel.ValueMember = "Id";
                cbxPoliticalLevel.DropDownStyle = ComboBoxStyle.DropDownList;

               
                string contentPosition = Common.ReadFileContent(Common.pathCategory + fileNamePosition);
                allPosition = new List<Position>();
                allPosition = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Position>>(contentPosition);
                cbxPosition.DataSource = allPosition;
                cbxPosition.DisplayMember = "Name";
                cbxPosition.ValueMember = "Id";
                cbxPosition.DropDownStyle = ComboBoxStyle.DropDownList;



                if (person != null)
                {
                    personId = person.Id;
                    txtCode.Text = person.Code;
                    txtCode.ReadOnly = true;
                    txtFullName.Text = person.FullName;
                    cbxGender.Text = person.Sex;
                    DtDateOfBird.Value = Common.ConvertStringToDate(person.DateOfBird);
                    txtAddress.Text = person.Address;
                    txtHometown.Text = person.Hometown;
                    cbxDepartment.Text = person.Department;
                    cbxUnit.Text = person.UnitCode;
                    
                    cbxPosition.Text = person.Position;
                    cbxLevel.Text = person.LevelCode;
                    cbxSchoolName.Text = person.SchoolName;
                    cbxPoliticalLevel.Text = person.PoliticalLevel;
                    cbxResponsible.Text = person.ResponsibleName;
                    rtbNote.Text = person.Note;
                    person.OfficialStartYear = Common.ConvertDateToString(dteOfficialStartYear.Value);
                    txtInternalSchool.Text = person.InternalSchool;
                    txtOtherSchool.Text = person.OtherSchool;
                    txtFosteringPLNV.Text = person.FosteringPLNV;
                    txtTittleTraning.Text = person.TittleTraning;
                    txtTittleTraningPlanning.Text = person.TittleTraningPlanning;
                    txtFosteringQPA.Text = person.FosteringQPA;
                    dataGridView1.DataSource = allTranningProcess;
                    dataGridView2.DataSource = allFosteringProcess;
                }
                else
                {
                    person = new Person();
                    txtCode.Text = "";
                    txtFullName.Text = "";
                    txtAddress.Text = "";
                  
                    cbxGender.Text = "Nam";
                    //DtDateOfBird.Value = Common.ConvertStringToDate(person.DateOfBird);
                    txtAddress.Text = "";
                    txtHometown.Text = "";
                    //cbxUnit.Text = ;
                   // cbxDepartment.Text = person.Department;
                    cbxPosition.Text = ""; 
                    cbxLevel.Text = "";
                    cbxSchoolName.Text = "";
                    cbxPoliticalLevel.Text = "";
                    cbxResponsible.Text = "";
                    rtbNote.Text = "";
                   // person.OfficialStartYear = Common.ConvertDateToString(dteOfficialStartYear.Value);
                    txtInternalSchool.Text = "";
                    txtOtherSchool.Text = "";
                    txtFosteringPLNV.Text = "";
                    txtTittleTraning.Text = "";
                    txtTittleTraningPlanning.Text = "";
                    txtFosteringQPA.Text = "";
                    // dataGridView1.DataSource = allTranningProcess;
                    // dataGridView2.DataSource = allFosteringProcess;

                }

                if (person != null && Checking.CheckNullString(person.Code) != "")
                {
                    if (allTranningProcess != null)
                    {
                        var trainingrocess = allTranningProcess.FindAll(item => item.PersonCode == person.Code);
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = trainingrocess;

                        cbxSchoolName.DataSource = trainingrocess;
                        cbxSchoolName.DisplayMember = "SchoolName";
                        cbxSchoolName.ValueMember = "Id";
                        cbxSchoolName.DropDownStyle = ComboBoxStyle.DropDownList;
                    }
                    if (allFosteringProcess != null)
                    {
                        var fosteringProcess = allFosteringProcess.FindAll(item => item.PersonCode == person.Code);
                        dataGridView2.DataSource = null;
                        dataGridView2.DataSource = fosteringProcess;
                    }
                    Resize();
                }
            }
            catch (Exception ex)
            {
                succesed = false;
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void save(bool savebtn)
        {

            person.Code = txtCode.Text.Trim();
            person.FullName = txtFullName.Text;
            person.Sex = cbxGender.Text;
            person.DateOfBird = Common.ConvertDateToString(DtDateOfBird.Value.Date);
            person.Address = txtAddress.Text;
            person.Hometown = txtHometown.Text;
            person.YearBegin = Common.ConvertDateToString(dteYearBegin.Value);
            person.OfficialStartYear = Common.ConvertDateToString(dteOfficialStartYear.Value);
            person.ResponsibleName = cbxResponsible.Text;
            person.InternalSchool = txtInternalSchool.Text;
            person.OtherSchool = txtOtherSchool.Text;
            person.FosteringPLNV = txtFosteringPLNV.Text;
            person.TittleTraning = txtTittleTraning.Text;
            person.TittleTraningPlanning = txtTittleTraningPlanning.Text;
            person.FosteringQPA = txtFosteringQPA.Text;
            person.Position = cbxPosition.Text;
            person.LevelCode = cbxLevel.Text;
            //chon truong de ra trinh do
            //person.AcademicLevelName = cbxSchoolName.Text;
            person.PoliticalLevel = cbxPoliticalLevel.Text;
            person.UnitCode = cbxUnit.Text + "-" + cbxDepartment.Text; 
            person.Department = cbxDepartment.Text;
            person.Note = rtbNote.Text;
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
                Common.SaveFileContent(Common.pathManagerment + fileNameAllperson, str);
            txtCode.ReadOnly = true;
            // }
            if (savebtn) { MessageBox.Show("Lưu dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!valid()) { succesed = true; return; }
                save(true);
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

        private void btnAddTranningProcess_Click(object sender, EventArgs e)
        {
            try
            {
                //ghi data truoc 
                if (!valid()) { succesed = true; return; }
                save(false);

                int maxID = 0;
                if (allTranningProcess != null && allTranningProcess.Count > 0)
                {
                    maxID = allTranningProcess.Max(obj => obj.Id);
                }
                else
                {
                    maxID = 1;
                    allTranningProcess = new List<TranningProcess>();
                }
                frmTraningProcessDetails frmDetail = new frmTraningProcessDetails();
                frmDetail.allTranningProcess = allTranningProcess;
                frmDetail.personCode = person.Code;
                frmDetail.maxTraningProcessId = maxID;
                frmDetail.ShowDialog();
                if (frmDetail.succesed)
                {
                    if (frmDetail.traningProcessId > 0)
                    {
                        allTranningProcess = frmDetail.allTranningProcess;
                        var trainingrocess = allTranningProcess.FindAll(item => item.PersonCode == person.Code);
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = trainingrocess;
                        Resize();
                        cbxSchoolName.DataSource = trainingrocess;
                        cbxSchoolName.DisplayMember = "SchoolName";
                        cbxSchoolName.ValueMember = "Id";
                        cbxSchoolName.DropDownStyle = ComboBoxStyle.DropDownList;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Resize()
        {
            if (dataGridView1 != null)
            {
                dataGridView1.Columns["id"].Visible = false;
                dataGridView1.Columns["CreatedBy"].Visible = false;
                dataGridView1.Columns["CreatedTime"].Visible = false;
                dataGridView1.Columns["ModifiedBy"].Visible = false;
                dataGridView1.Columns["ModifiedTime"].Visible = false;
                dataGridView1.Columns["PersonCode"].HeaderText = "Số hiệu";
                dataGridView1.Columns["SchoolName"].HeaderText = "Trường";
                dataGridView1.Columns["Major"].HeaderText = "Chuyên ngành";
                dataGridView1.Columns["Level"].HeaderText = "Trình độ";
                dataGridView1.Columns["DecisionNumber"].HeaderText = "Số quyết định";
                dataGridView1.Columns["BeginYear"].HeaderText = "Năm bắt đầu";
                dataGridView1.Columns["EndYear"].HeaderText = "Năm tốt nghiệp";
                dataGridView1.Columns["Note"].HeaderText = "Ghi chú";
                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
             
            if (dataGridView2.Columns["id"] != null)
            {
                dataGridView2.Columns["id"].Visible = false;
                dataGridView2.Columns["CreatedBy"].Visible = false;
                dataGridView2.Columns["CreatedTime"].Visible = false;
                dataGridView2.Columns["ModifiedBy"].Visible = false;
                dataGridView2.Columns["ModifiedTime"].Visible = false;
                dataGridView2.Columns["PersonCode"].HeaderText = "Số hiệu";
                dataGridView2.Columns["SchoolName"].HeaderText = "Trường";
                dataGridView2.Columns["Major"].HeaderText = "Chuyên ngành";
                dataGridView2.Columns["Level"].HeaderText = "Trình độ";
                dataGridView2.Columns["DecisionNumber"].HeaderText = "Số quyết định";
                dataGridView2.Columns["BeginYear"].HeaderText = "Năm bắt đầu";
                dataGridView2.Columns["EndYear"].HeaderText = "Năm tốt nghiệp";
                dataGridView2.Columns["Note"].HeaderText = "Ghi chú";
                //dataGridView1.Columns["YearBegin"].HeaderText = "Năm bắt đầu";
                dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
           
            // dataGridView1.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            // dataGridView1.Columns["Note"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btnAddFosteringProcess_Click(object sender, EventArgs e)
        {
            try
            {
                //ghi data truoc 
                if (!valid()) { succesed = false; return; }
                save(false);
                int maxID = 0;
                if (allFosteringProcess != null && allFosteringProcess.Count > 0)
                {
                    maxID = allFosteringProcess.Max(obj => obj.Id);
                }
                else
                {
                    maxID = 1;
                    allFosteringProcess = new List<FosteringProcess>();
                }
                frmFosteringProcessDetails frmDetail = new frmFosteringProcessDetails();
                frmDetail.allFosteringProcess = allFosteringProcess;
                frmDetail.personCode = person.Code;
                frmDetail.maxFosteringProcessId = maxID;
                frmDetail.ShowDialog();
                if (frmDetail.succesed)
                {
                    if (frmDetail.fosteringProcessId > 0)
                    {
                        allFosteringProcess = frmDetail.allFosteringProcess;
                        var fosteringrocess = allFosteringProcess.FindAll(item => item.PersonCode == person.Code);
                        dataGridView2.DataSource = null;
                        dataGridView2.DataSource = fosteringrocess;
                        Resize();
                    }
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
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (person != null && maxpersonId != 0 ) 
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
                if (cbxGender.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập giới tính.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbxGender.Focus();
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

                if (txtAddress.Text == "")
                {
                    MessageBox.Show("Bạn phải nhập hộ khẩu thường trú.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAddress.Focus();
                    return false;
                };
                if (dteYearBegin.Text == "")
                {
                    MessageBox.Show("Bạn phải nhập năm vào CAND.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dteYearBegin.Focus();
                    return false;
                };
                if (dteOfficialStartYear.Text == "")
                {
                    MessageBox.Show("Bạn phải nhập năm vào CAND chính thức.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dteOfficialStartYear.Focus();
                    return false;
                };
                if (cbxLevel.Text == "")
                {
                    MessageBox.Show("Bạn phải nhập cấp bậc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbxLevel.Focus();
                    return false;
                };
                if (cbxPosition.Text == "")
                {
                    MessageBox.Show("Bạn phải nhập chức vụ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbxPosition.Focus();
                    return false;
                };
                if (cbxUnit.Text == "" || cbxDepartment.Text == "")
                {
                    MessageBox.Show("Bạn phải nhập đơn vị, phòng ban.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbxUnit.Focus();
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
        private void EditTranningProcess(int value)
        {
            TranningProcess tranningProcess = allTranningProcess.FirstOrDefault(obj => obj.Id == value);
            frmTraningProcessDetails frmDetail = new frmTraningProcessDetails();
            frmDetail.allTranningProcess = allTranningProcess;
            frmDetail.personCode = person.Code;
            frmDetail.traningProcess = tranningProcess;
            frmDetail.ShowDialog();
            if (frmDetail.succesed)
            {
                if (frmDetail.personCode == person.Code)
                {
                    allTranningProcess = frmDetail.allTranningProcess;
                    var trainingrocess = allTranningProcess.FindAll(item => item.PersonCode == person.Code);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = trainingrocess;
                    Resize();
                    cbxSchoolName.DataSource = trainingrocess;
                    cbxSchoolName.DisplayMember = "SchoolName";
                    cbxSchoolName.ValueMember = "Id";
                    cbxSchoolName.DropDownStyle = ComboBoxStyle.DropDownList;
                }
            }
        }
        private void EditFosteringProcess(int value)
        {
            FosteringProcess fosteringProcess = allFosteringProcess.FirstOrDefault(obj => obj.Id == value);
            frmFosteringProcessDetails frmDetail = new frmFosteringProcessDetails();
            frmDetail.allFosteringProcess = allFosteringProcess;
            frmDetail.personCode = person.Code;
            frmDetail.fosteringProcess = fosteringProcess;
            frmDetail.ShowDialog();
            if (frmDetail.succesed)
            {
                if (frmDetail.personCode == person.Code)
                {
                    allFosteringProcess = frmDetail.allFosteringProcess;
                    var fosteringrocess = allTranningProcess.FindAll(item => item.PersonCode == person.Code);
                    dataGridView2.DataSource = null;
                    dataGridView2.DataSource = fosteringrocess;
                    Resize();
                }
            }
        }
        private void btnEditTranningProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    int cellValue = Checking.CheckNullInt( selectedRow.Cells["id"].Value);
                    EditTranningProcess(cellValue);
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

        private void btnDeleteTranningProcess_Click(object sender, EventArgs e)
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
                            int tranId = Checking.CheckNullInt(row.Cells["id"].Value);
                            string personCode = Checking.CheckNullString(row.Cells["PersonCode"].Value);
                            string school = Checking.CheckNullString(row.Cells["SchoolName"].Value);
                            allTranningProcess.RemoveAll(obj => obj.Id == tranId && obj.PersonCode == personCode && obj.SchoolName == school);
                           
                            //string personCode = Checking.CheckNullString( row.Cells["PersonCode"].Value);
                            //allTranningProcess.RemoveAll(obj => obj.PersonCode == personCode);
                        }
                        //xoa bang con
                        
                    }
                    string strallTranningProcess = Newtonsoft.Json.JsonConvert.SerializeObject(allTranningProcess);
                    Common.SaveFileContent(Common.pathManagerment + fileTranningProcess, strallTranningProcess);
                    var trainingrocess = allTranningProcess.FindAll(item => item.PersonCode == person.Code);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = trainingrocess;
                    Resize();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                DataGridViewRow clickedRow = dataGridView1.Rows[e.RowIndex];
                int value = Checking.CheckNullInt((clickedRow.Cells["Id"].Value));
                EditTranningProcess(value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //try
            //{
            //    if (dataGridView1.SelectedRows.Count > 0)
            //    {
            //        DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            //        int cellValue = Checking.CheckNullInt( selectedRow.Cells["Id"].Value);
            //        EditTranningProcess(cellValue);
            //    }
            //    else
            //    {
            //        MessageBox.Show("Chưa có thông tin nào được chọn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                DataGridViewRow clickedRow = dataGridView2.Rows[e.RowIndex];
                int value = Checking.CheckNullInt((clickedRow.Cells["Id"].Value));
                EditFosteringProcess(value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditFosteringProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];
                    int cellValue = Checking.CheckNullInt(selectedRow.Cells["id"].Value);
                  
                    EditFosteringProcess(cellValue);
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

        //private void txtCode_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //kiem tra trung 
                
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void cbxSchoolName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string schoolName = cbxSchoolName.Text;
                var trainingrocess = allTranningProcess.FirstOrDefault(item => item.PersonCode == person.Code && item.SchoolName == schoolName);
                if (trainingrocess != null)
                {
                    person.SchoolName = Checking.CheckNullString(trainingrocess.SchoolName);
                    person.AcademicLevelName = Checking.CheckNullString(trainingrocess.Level);
                    person.SchoolYear = Checking.CheckNullString(trainingrocess.EndYear);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void dataGridView2_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                string columnName = dataGridView2.Columns[e.ColumnIndex].Name;
                if (columnName == "CHECKBD")
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

        private void btnDeleteFosteringProcess_Click(object sender, EventArgs e)
        {
            try
            {
                int count = 0;
                for (int i = dataGridView2.Rows.Count - 1; i >= 0; i--)
                {
                    DataGridViewRow row = dataGridView2.Rows[i];
                    DataGridViewCheckBoxCell cell = row.Cells["CHECKBD"] as DataGridViewCheckBoxCell;
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
                    for (int i = dataGridView2.Rows.Count - 1; i >= 0; i--)
                    {
                        DataGridViewRow row = dataGridView2.Rows[i];
                        DataGridViewCheckBoxCell cell = row.Cells["CHECKBD"] as DataGridViewCheckBoxCell;
                        bool isChecked = Convert.ToBoolean(cell.Value);
                        if (isChecked)
                        {
                            int tranId = Checking.CheckNullInt(row.Cells["id"].Value);
                            string personCode = Checking.CheckNullString(row.Cells["PersonCode"].Value);
                            string school = Checking.CheckNullString(row.Cells["SchoolName"].Value);
                            allFosteringProcess.RemoveAll(obj => obj.Id == tranId && obj.PersonCode == personCode && obj.SchoolName == school);
                        }
                        //xoa bang con
                       
                    }
                    string strallFosteringProcess = Newtonsoft.Json.JsonConvert.SerializeObject(allFosteringProcess);
                    Common.SaveFileContent(Common.pathManagerment + fileFosteringProcess, strallFosteringProcess);
                    var fosteringProcess = allFosteringProcess.FindAll(item => item.PersonCode == person.Code);
                    dataGridView2.DataSource = null;
                    dataGridView2.DataSource = fosteringProcess;
                    Resize();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void dataGridView2_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {

                dataGridView2.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGray;
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
                if(Checking.CheckNullInt(cbxUnit.SelectedValue) <= 0) { return; }
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

        private void cbxUnit_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Checking.CheckNullInt(cbxUnit.SelectedValue) <= 0) { return; }
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

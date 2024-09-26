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
        public frmPersonDetail()
        {
            InitializeComponent();
        }

        private void frmUnitDetail_Load(object sender, EventArgs e)
        {
            try
            {
                panel2.Dock = DockStyle.Fill; // Panel sẽ chiếm toàn bộ form
                panel2.AutoScroll = true;

                mtbYearBegin.Mask = "00/00/0000";
                mtbCommunistPartyBegin.Mask = "00/00/0000";
                mtbOfficialStartYear.Mask = "00/00/0000";

                foreach (Control control in this.Controls)
                {
                    control.Width = (int)(this.Width * (control.Width / (double)this.ClientSize.Width));
                    control.Height = (int)(this.Height * (control.Height / (double)this.ClientSize.Height));
                    control.Left = (int)(this.Width * (control.Left / (double)this.ClientSize.Width));
                    control.Top = (int)(this.Height * (control.Top / (double)this.ClientSize.Height));
                }

                load = true;
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

                //phong
                string contentDepartment = Common.ReadFileContent(QLNSCommon.pathCategory + fileDepartmentName);
                allDepartment = new List<Department>();
                allDepartment = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Department>>(contentDepartment);
                //cbxDepartment.DataSource = allDepartment;
                //cbxDepartment.DisplayMember = "Name";
                //cbxDepartment.ValueMember = "Id";
                cbxDepartment.DropDownWidth = 400;
                // cbxDepartment.DropDownStyle = ComboBoxStyle.DropDownList;

                List<Unit> unitRole = allUnits;
                if (Common.glbUnit != "Tất cả")
                {
                    unitRole = allUnits.FindAll(item => item.Name.Contains(Common.glbUnit.Trim()));
                }
                //don vi
                cbxUnit.DataSource = unitRole;
                cbxUnit.DisplayMember = "Name";
                cbxUnit.ValueMember = "Id";
                cbxUnit.DropDownWidth = 400;
                if (Common.glbUnit != "Tất cả")
                {
                    cbxUnit.Text = Common.glbUnit;
                }
                    cbxUnit.DropDownStyle = ComboBoxStyle.DropDownList;

              

                //chuc vu
                string contentResponsible = Common.ReadFileContent(QLNSCommon.pathCategory + fileResponsibleName);
                allResponsible = new List<Responsible>();
                allResponsible = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Responsible>>(contentResponsible);
                cbxResponsible.DataSource = allResponsible;
                cbxResponsible.DisplayMember = "Name";
                cbxResponsible.ValueMember = "Id";
               // cbxResponsible.DropDownStyle = ComboBoxStyle.DropDownList;

                //cap bac
                string contentLevel = Common.ReadFileContent(QLNSCommon.pathCategory + fileNameLevel);
                allLevel = new List<Level>();
                allLevel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Level>>(contentLevel);
                cbxLevel.DataSource = allLevel;
                cbxLevel.DisplayMember = "Name";
                cbxLevel.ValueMember = "Id";
               // cbxLevel.DropDownStyle = ComboBoxStyle.DropDownList;

                //trinh do LLCT
                string contentPoliticalLevel = Common.ReadFileContent(QLNSCommon.pathCategory + fileNamePoliticalLevel);
                allPoliticalLevel = new List<PoliticalLevel>();
                allPoliticalLevel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<PoliticalLevel>>(contentPoliticalLevel);
                //for (int i = 0; i < allPoliticalLevel.Count; i++)
                //{
                //    clbPoliticalLevel.Items.Add(allPoliticalLevel[i].Name);
                //}
                //allPoliticalLevel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<PoliticalLevel>>(contentPoliticalLevel);
                cbxPoliticalLevel.DataSource = allPoliticalLevel;
                cbxPoliticalLevel.DisplayMember = "Name";
                cbxPoliticalLevel.ValueMember = "Id";
               // cbxPoliticalLevel.DropDownStyle = ComboBoxStyle.DropDownList;

                string contentPoliticalLevelForm = Common.ReadFileContent(QLNSCommon.pathCategory + fileNamePoliticalLevelForm);
                allPoliticalLevelForm = new List<PoliticalLevelForm>();
                allPoliticalLevelForm = Newtonsoft.Json.JsonConvert.DeserializeObject<List<PoliticalLevelForm>>(contentPoliticalLevelForm);

                cbxPoliticalLevelForm.DataSource = allPoliticalLevelForm;
                cbxPoliticalLevelForm.DisplayMember = "Name";
                cbxPoliticalLevelForm.ValueMember = "Id";
               // cbxPoliticalLevelForm.DropDownStyle = ComboBoxStyle.DropDownList;


                string contentPosition = Common.ReadFileContent(QLNSCommon.pathCategory + fileNamePosition);
                allPosition = new List<Position>();
                allPosition = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Position>>(contentPosition);
                cbxPosition.DataSource = allPosition;
                cbxPosition.DisplayMember = "Name";
                cbxPosition.ValueMember = "Id";
              //  cbxPosition.DropDownStyle = ComboBoxStyle.DropDownList;

                string contentClassify = Common.ReadFileContent(QLNSCommon.pathCategory + fileNameClassify);
                allClassify = new List<Classify>();
                allClassify = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Classify>>(contentClassify);
                cbxClassify.DataSource = allClassify;
                cbxClassify.DisplayMember = "Name";
                cbxClassify.ValueMember = "Id";
              //  cbxClassify.DropDownStyle = ComboBoxStyle.DropDownList;

                string contentCompetition = Common.ReadFileContent(QLNSCommon.pathCategory + fileNameCompetition);
                allCompetition = new List<Competition>();
                allCompetition = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Competition>>(contentCompetition);
                cbxCompetition.DataSource = allCompetition;
                cbxCompetition.DisplayMember = "Name";
                cbxCompetition.ValueMember = "Id";
               // cbxCompetition.DropDownStyle = ComboBoxStyle.DropDownList;

                string contentTittle = Common.ReadFileContent(QLNSCommon.pathCategory + fileNameTittle);
                allTittle = new List<Tittle>();
                allTittle = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Tittle>>(contentTittle);
                cbxTittle.DataSource = allTittle;
                cbxTittle.DisplayMember = "Name";
                cbxTittle.ValueMember = "Id";
                //cbxTittle.DropDownStyle = ComboBoxStyle.DropDownList;

                //dteOfficialStartYear.CustomFormat = " ";
               // dteYearBegin.CustomFormat = " ";
                dteInternalSchoolYear.CustomFormat = " ";
                dteSchoolYear.CustomFormat = " ";
                //dteCommunistPartyBegin.CustomFormat = " ";
                dteCurInternalSchoolYear.CustomFormat = " ";

                if (person != null)
                {
                    personId = person.Id;
                    txtCode.Text = person.Code;
                    setValue(true, true);
                    txtCode.ReadOnly = true;
                    txtFullName.Text = person.FullName;
                    cbxGender.Text = person.Sex;
                    DtDateOfBird.Value = Common.ConvertStringToDate(person.DateOfBird);
                    txtAddress.Text = person.Address;
                    txtHometown.Text = person.Hometown;
                   // string[] items = person.UnitCode.Split('-');
                    cbxUnit.Text = person.UnitCode;
                    cbxDepartment.Text = person.Department;

                    //if (Checking.CheckNullString(person.YearBegin) != "")
                    //{
                    //    dteYearBegin.Value = Common.ConvertStringToDate(person.YearBegin);
                    //    dteYearBegin.Format = DateTimePickerFormat.Short;
                    //}
                    if (Checking.CheckNullString(person.YearBegin) != "")
                    {
                        mtbYearBegin.Text = person.YearBegin;
                        //dtBeginYear.Format = DateTimePickerFormat.Short;
                    }
                    // person.CommunistPartyBegin = Common.ConvertDateToString(dteCommunistPartyBegin.Value);
                    //if (Checking.CheckNullString(person.CommunistPartyBegin) != "")
                    //{
                    //    dteCommunistPartyBegin.Value = Common.ConvertStringToDate(person.CommunistPartyBegin);
                    //    dteCommunistPartyBegin.Format = DateTimePickerFormat.Short;
                    //}
                    if (Checking.CheckNullString(person.CommunistPartyBegin) != "")
                    {
                        mtbCommunistPartyBegin.Text = person.CommunistPartyBegin;
                        //dtBeginYear.Format = DateTimePickerFormat.Short;
                    }

                    if (Checking.CheckNullString(person.InternalSchoolYear) != "")
                    {
                        dteInternalSchoolYear.Value = Common.ConvertStringToDate(person.InternalSchoolYear);
                        dteInternalSchoolYear.Format = DateTimePickerFormat.Short;
                    }
                    //dteInternalSchoolYear.Value = Common.ConvertStringToDate(person.InternalSchoolYear);
                    if (Checking.CheckNullString(person.SchoolYear) != "")
                    {
                        dteSchoolYear.Value = Common.ConvertStringToDate(person.SchoolYear);
                        dteSchoolYear.Format = DateTimePickerFormat.Short;
                    }
                    //dteSchoolYear.Value = Common.ConvertStringToDate(person.SchoolYear);
                    if (Checking.CheckNullString(person.CurInternalSchoolYear) != "")
                    {
                        dteCurInternalSchoolYear.Value = Common.ConvertStringToDate(person.CurInternalSchoolYear);
                        dteCurInternalSchoolYear.Format = DateTimePickerFormat.Short;
                    }
                    //dteCurInternalSchoolYear.Value = Common.ConvertStringToDate(person.CurInternalSchoolYear);

                    cbxPosition.Text = person.Tittle;
                    cbxLevel.Text = person.LevelCode;

                    cbxSchoolName.Text =  person.SchoolName + "-" + person.Major + "-" + person.AcademicLevelName;

                    cbxInternalSchool.Text =  person.InternalSchool + "-" + person.InternalMajor + "-" + person.InternalAcademicLevelName;


                    cbxCurInternalSchool.Text =  person.CurInternalSchool + "-" + person.CurInternalMajor + "-" + person.CurInternalAcademicLevelName;

                    //cbxCurInternalSchool.Text = person.CurInternalSchool;

                    cbxPoliticalLevel.Text = person.PoliticalLevel;
                    cbxPoliticalLevelForm.Text = person.PoliticalLevelForm;

                    cbxResponsible.Text = person.ResponsibleName;
                    cbxClassify.Text = person.Classify;
                    cbxCompetition.Text = person.Competition;
                    cbxTittle.Text = person.Position;
                    rtbNote.Text = person.Note;
                    //if (Checking.CheckNullString(person.OfficialStartYear) != "")
                    //{
                    //    dteOfficialStartYear.Value = Common.ConvertStringToDate(person.OfficialStartYear);
                    //    dteOfficialStartYear.Format = DateTimePickerFormat.Short;
                    //}
                    if (Checking.CheckNullString(person.OfficialStartYear) != "")
                    {
                        mtbOfficialStartYear.Text = person.OfficialStartYear;
                        //dtBeginYear.Format = DateTimePickerFormat.Short;
                    }
                    cbxFosteringPLNV.Text = person.FosteringPLNV;
                    cbxTittleTraning.Text = person.TittleTraning;
                    cbxTittleTraningPlanning.Text = person.TittleTraningPlanning;
                    cbxFosteringQPA.Text = person.FosteringQPA;
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
                    cbxPoliticalLevelForm.Text = "";
                    cbxResponsible.Text = "";
                    rtbNote.Text = "";
                    cbxClassify.Text = "";
                    cbxCompetition.Text = "";
                    cbxTittle.Text = "";
                    //dteOfficialStartYear.Text = "";
                    // person.OfficialStartYear = Common.ConvertDateToString(dteOfficialStartYear.Value);
                    // txtInternalSchool.Text = "";
                    // txtOtherSchool.Text = "";
                    cbxFosteringPLNV.Text = "";
                    cbxTittleTraning.Text = "";
                    cbxTittleTraningPlanning.Text = "";
                    cbxFosteringQPA.Text = "";
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

                        //cbxSchoolName.DataSource = trainingrocess;
                        //cbxSchoolName.DisplayMember = "SchoolName";
                        //cbxSchoolName.ValueMember = "Id";
                        //cbxSchoolName.DropDownStyle = ComboBoxStyle.DropDownList;
                    }
                    if (allFosteringProcess != null)
                    {
                        var fosteringProcess = allFosteringProcess.FindAll(item => item.PersonCode == person.Code);
                        dataGridView2.DataSource = null;
                        dataGridView2.DataSource = fosteringProcess;
                    }
                    Resize();
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
            person.FullName = txtFullName.Text;
            person.Sex = cbxGender.Text;
            person.DateOfBird = Common.ConvertDateToString(DtDateOfBird.Value.Date);
            person.Address = txtAddress.Text;
            person.Hometown = txtHometown.Text;

            //if (dteYearBegin.Text != " ")
            //    person.YearBegin = Common.ConvertDateToString(dteYearBegin.Value);
            if (mtbYearBegin.Text != "  /  /")
            {
                person.YearBegin = mtbYearBegin.Text;
            }
            else
            {
                person.YearBegin  = "";
            }
            //if (dteOfficialStartYear.Text != " ")
            //    person.OfficialStartYear = Common.ConvertDateToString(dteOfficialStartYear.Value);
            if (mtbOfficialStartYear.Text != "  /  /")
            {
                person.OfficialStartYear = mtbOfficialStartYear.Text;
            }
            else
            {
                person.OfficialStartYear = "";
            }
            //if (dteCommunistPartyBegin.Text != " ")
            //    person.CommunistPartyBegin = Common.ConvertDateToString(dteCommunistPartyBegin.Value);
            if (mtbCommunistPartyBegin.Text != "  /  /")
            {
                person.CommunistPartyBegin = mtbCommunistPartyBegin.Text;
            }
            else
            {
                person.CommunistPartyBegin = "";
            }

            person.ResponsibleName = cbxResponsible.Text;
            if (Checking.CheckNullString(cbxSchoolName.Text) != "")
            {
                List<string> result = new List<string>(cbxSchoolName.Text.Split('-'));
                person.SchoolName = result[0];
                person.Major = txtIMajor.Text;
                person.AcademicLevelName = txtAcademicLevelName.Text;
                person.SchoolYear = Common.ConvertDateToString(dteSchoolYear.Value);
                person.TraningType = txtTraningType.Text;
            }
            else
            {
                person.SchoolName = "";
                person.Major = "";
                person.AcademicLevelName = "";
                person.SchoolYear = "";
                person.TraningType = "";
            }

            if (Checking.CheckNullString(cbxInternalSchool.Text) != "")
            {
                List<string> result = new List<string>(cbxInternalSchool.Text.Split('-'));
                person.InternalSchool = result[0];
               // person.InternalSchool = cbxInternalSchool.Text;
                person.InternalMajor = txtInternalMajor.Text;
                person.InternalAcademicLevelName = txtInternalAcademicLevelName.Text;
                person.InternalSchoolYear = Common.ConvertDateToString(dteInternalSchoolYear.Value);
                person.InternalTraningType = txtInternalTraningType.Text;
            }
            else
            {
                person.InternalSchool = "";
                person.InternalMajor = "";
                person.InternalAcademicLevelName = "";
                person.InternalSchoolYear = "";
                person.InternalTraningType = "";
            }
            if (Checking.CheckNullString(cbxCurInternalSchool.Text) != "")
            {
                List<string> result = new List<string>(cbxCurInternalSchool.Text.Split('-'));
                person.CurInternalSchool = result[0];
               // person.CurInternalSchool = cbxCurInternalSchool.Text;
                person.CurInternalMajor = txtCurInternalMajor.Text; 
                person.CurInternalAcademicLevelName = txtCurInternalAcademicLevelName.Text;
                person.CurInternalSchoolYear = Common.ConvertDateToString(dteCurInternalSchoolYear.Value);
                person.CurInternalTraningType = txtCurInternalTraningType.Text;
            }
            else
            {
                person.CurInternalSchool = "";
                person.CurInternalMajor = "";
                person.CurInternalAcademicLevelName = "";
                person.CurInternalSchoolYear = "";
                person.CurInternalTraningType = "";
            }
            // person.OtherSchool = txtOtherSchool.Text;
            person.FosteringPLNV = cbxFosteringPLNV.Text;
            person.TittleTraning = cbxTittleTraning.Text;
            person.TittleTraningPlanning = cbxTittleTraningPlanning.Text;
            person.FosteringQPA = cbxFosteringQPA.Text;
            person.Position = cbxTittle.Text;
            person.LevelCode = cbxLevel.Text;

            //chon truong de ra trinh do
            //person.AcademicLevelName = cbxSchoolName.Text;
            person.PoliticalLevel = cbxPoliticalLevel.Text;
            person.PoliticalLevelForm = cbxPoliticalLevelForm.Text;
            //string checkedItems = String.Empty;
            //foreach (var item in checkedListBox1.CheckedItems)
            //{
            //    //checkedItems.AppendLine(item.ToString());
            //    checkedItems = checkedItems + item.ToString() + "-";
            //}
            //person.PoliticalLevel = checkedItems;
            person.UnitCode = cbxUnit.Text;
            person.Department = cbxDepartment.Text;
            person.Classify = cbxClassify.Text;
            person.Competition = cbxCompetition.Text;
            person.Tittle = cbxPosition.Text;
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
                        setValue(true, false);
                    }
                    edit = true;
                    btnSave.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi trong quá trình xử lý dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Resize()
        {
            if (dataGridView1 != null)
            {
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView1.Columns["id"].Visible = false;
                dataGridView1.Columns["CreatedBy"].Visible = false;
                dataGridView1.Columns["CreatedTime"].Visible = false;
                dataGridView1.Columns["ModifiedBy"].Visible = false;
                dataGridView1.Columns["ModifiedTime"].Visible = false;
                dataGridView1.Columns["Type"].HeaderText = "Loại hình đào tạo";
                dataGridView1.Columns["PersonCode"].HeaderText = "Số hiệu";
                dataGridView1.Columns["SchoolName"].HeaderText = "Trường";
                dataGridView1.Columns["Major"].HeaderText = "Chuyên ngành";
                dataGridView1.Columns["Level"].HeaderText = "Trình độ";
                dataGridView1.Columns["DecisionNumber"].HeaderText = "Số quyết định";
                dataGridView1.Columns["BeginYear"].HeaderText = "Năm bắt đầu";
                dataGridView1.Columns["EndYear"].HeaderText = "Năm tốt nghiệp";
                dataGridView1.Columns["Note"].HeaderText = "Ghi chú";
                dataGridView1.Columns["TraningType"].HeaderText = "Hình thức đào tạo";
                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dataGridView2.Columns["id"] != null)
            {
                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView2.Columns["id"].Visible = false;
                dataGridView2.Columns["CreatedBy"].Visible = false;
                dataGridView2.Columns["CreatedTime"].Visible = false;
                dataGridView2.Columns["ModifiedBy"].Visible = false;
                dataGridView2.Columns["ModifiedTime"].Visible = false;
                dataGridView2.Columns["Type"].HeaderText = "Loại hình bồi dưỡng";
                dataGridView2.Columns["FosteringContent"].HeaderText = "Nội dung";
                dataGridView2.Columns["PersonCode"].HeaderText = "Số hiệu";
                dataGridView2.Columns["SchoolName"].HeaderText = "Trường";
                // dataGridView2.Columns["Major"].HeaderText = "Chuyên ngành";
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
                        setValue(false, true);
                    }
                    edit = true;
                    btnSave.Enabled = true;
                }
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

                if (mtbYearBegin.Text != "  /  /")
                {
                    if (DateTime.TryParseExact(mtbYearBegin.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime result))
                    {

                    }
                    else
                    {
                        MessageBox.Show("Ngày tháng bắt đầu không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        mtbYearBegin.Focus();
                        return false;
                    }
                }
                if (mtbOfficialStartYear.Text != "  /  /")
                {
                    if (DateTime.TryParseExact(mtbOfficialStartYear.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime result))
                    {

                    }
                    else
                    {
                        MessageBox.Show("Ngày tháng năm chính thức không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        mtbOfficialStartYear.Focus();
                        return false;
                    }
                }
                if (mtbCommunistPartyBegin.Text != "  /  /")
                {
                    if (DateTime.TryParseExact(mtbCommunistPartyBegin.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime result))
                    {

                    }
                    else
                    {
                        MessageBox.Show("Ngày tháng năm vào đảng không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        mtbCommunistPartyBegin.Focus();
                        return false;
                    }
                }


                //if (dteYearBegin.Text == "")
                //{
                //    MessageBox.Show("Bạn phải nhập năm vào CAND.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    dteYearBegin.Focus();
                //    return false;
                //};
                //if (dteOfficialStartYear.Text == "")
                //{
                //    MessageBox.Show("Bạn phải nhập năm vào CAND chính thức.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    dteOfficialStartYear.Focus();
                //    return false;
                //};
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
                //if (cbxClassify.Text == "")
                //{
                //    MessageBox.Show("Bạn phải nhập chức danh.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    cbxClassify.Focus();
                //    return false;
                //};


                if (cbxUnit.Text == "")
                {
                    MessageBox.Show("Bạn phải nhập đơn vị chủ quản", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    setValue(true, false);
                }
                edit = true;
                btnSave.Enabled = true;
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
                    var fosteringrocess = allFosteringProcess.FindAll(item => item.PersonCode == person.Code);
                    dataGridView2.DataSource = null;
                    dataGridView2.DataSource = fosteringrocess;
                    Resize();
                    setValue(false, true);
                }
                edit = true;
                btnSave.Enabled = true;
            }
        }
        private void btnEditTranningProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    int cellValue = Checking.CheckNullInt(selectedRow.Cells["id"].Value);
                    EditTranningProcess(cellValue);
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
                    Common.SaveFileContent(QLNSCommon.pathManagerment + fileTranningProcess, strallTranningProcess);
                    var trainingrocess = allTranningProcess.FindAll(item => item.PersonCode == person.Code);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = trainingrocess;
                    Resize();
                    setValue(true, false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi trong quá trình xử lý dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Lỗi trong quá trình xử lý dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            //    MessageBox.Show("Lỗi trong quá trình xử lý dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Lỗi trong quá trình xử lý dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Lỗi trong quá trình xử lý dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        //        MessageBox.Show("Lỗi trong quá trình xử lý dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void cbxSchoolName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!load)
            {
                edit = true;
                btnSave.Enabled = true;
            }
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
                MessageBox.Show("Lỗi trong quá trình xử lý dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Lỗi trong quá trình xử lý dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Lỗi trong quá trình xử lý dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    Common.SaveFileContent(QLNSCommon.pathManagerment + fileFosteringProcess, strallFosteringProcess);
                    var fosteringProcess = allFosteringProcess.FindAll(item => item.PersonCode == person.Code);
                    dataGridView2.DataSource = null;
                    dataGridView2.DataSource = fosteringProcess;
                    Resize();
                    setValue(false, true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi trong quá trình xử lý dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (!load)
            {
                edit = true;
                btnSave.Enabled = true;
            }
           
            try
            {
                if (Common.glbUnit != "Tất cả")
                {
                    Unit unitSearch = allUnits.FindAll(item => item.Name.ToLower() == Common.glbUnit.ToLower()).FirstOrDefault();
                    if (unitSearch != null)
                    {
                        List<Department> depSearch = allDepartment.FindAll(item => item.UnitId == unitSearch.Id);
                        cbxDepartment.DataSource = depSearch;
                        cbxDepartment.DisplayMember = "Name";
                        cbxDepartment.ValueMember = "Id";
                    }
                    
                }
                else
                {
                    if (Checking.CheckNullInt(cbxUnit.SelectedValue) <= 0) { return; }
                    // if (Checking.CheckNullString(cbxUnit.Text) != "") { string textstr = cbxUnit.Text; }
                    List<Department> depSearch = allDepartment.FindAll(item => item.UnitId == Checking.CheckNullInt(cbxUnit.SelectedValue));
                    cbxDepartment.DataSource = depSearch;
                    cbxDepartment.DisplayMember = "Name";
                    cbxDepartment.ValueMember = "Id";
                    //cbxDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
                }
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
                if (Common.glbUnit != "Tất cả")
                {
                    Unit unitSearch = allUnits.FindAll(item => item.Name.ToLower() == Common.glbUnit.ToLower()).FirstOrDefault();
                    if (unitSearch != null)
                    {
                        List<Department> depSearch = allDepartment.FindAll(item => item.UnitId == unitSearch.Id);
                        cbxDepartment.DataSource = depSearch;
                        cbxDepartment.DisplayMember = "Name";
                        cbxDepartment.ValueMember = "Id";
                    }
                }
                else
                {
                    if (Checking.CheckNullInt(cbxUnit.SelectedValue) <= 0) { return; }
                    // if (Checking.CheckNullString(cbxUnit.Text) != "") { string textstr = cbxUnit.Text; }

                    List<Department> depSearch = allDepartment.FindAll(item => item.UnitId == Checking.CheckNullInt(cbxUnit.SelectedValue));
                    cbxDepartment.DataSource = depSearch;
                    cbxDepartment.DisplayMember = "Name";
                    cbxDepartment.ValueMember = "Id";
                    //cbxDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi trong quá trình xử lý dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        private void setValue(bool train, bool fostering)
        {
            if (txtCode.Text.Trim() != "")
            {
                //cbxType.Items.Add("Tốt nghiệp trong CAND");
                // cbxType.Items.Add("Tốt nghiệp trường ngoài CAND");
                // cbxType.Items.Add("Đang học các lớp trong CAND");
                    if (train)
                     {
                    cbxInternalSchool.DataSource = allTranningProcess.FindAll(p => p.PersonCode == txtCode.Text && p.Type == "Tốt nghiệp trong CAND");
                    cbxInternalSchool.DisplayMember = "ToString";
                    //cbxInternalSchool.ValueMember = "SchoolName";
                    //cbxInternalSchool.DropDownWidth = Auto
                    cbxInternalSchool.DropDownStyle = ComboBoxStyle.DropDownList;
                    QLNSCommon.SetComboBoxDropDownWidth(cbxInternalSchool);
                    if (Checking.CheckNullString(cbxInternalSchool.Text) == "")
                    {
                        txtInternalAcademicLevelName.Text = "";
                        txtInternalTraningType.Text = "";
                        dteInternalSchoolYear.Format = DateTimePickerFormat.Custom;

                    }

                    List<TranningProcess> test = allTranningProcess.FindAll(p => p.PersonCode == txtCode.Text && p.Type == "Tốt nghiệp trường ngoài CAND");
                    cbxSchoolName.DataSource = allTranningProcess.FindAll(p => p.PersonCode == txtCode.Text && p.Type == "Tốt nghiệp trường ngoài CAND");
                    cbxSchoolName.DisplayMember = "ToString";
                    //cbxSchoolName.ValueMember = "SchoolName";
                    cbxSchoolName.DropDownStyle = ComboBoxStyle.DropDownList;
                    QLNSCommon.SetComboBoxDropDownWidth(cbxSchoolName);
                    if (Checking.CheckNullString(cbxSchoolName.Text) == "")
                    {
                        txtAcademicLevelName.Text = "";
                        txtTraningType.Text = "";
                        dteSchoolYear.Format = DateTimePickerFormat.Custom;
                    }

                    cbxCurInternalSchool.DataSource = allTranningProcess.FindAll(p => p.PersonCode == txtCode.Text && p.Type == "Đang học các lớp trong CAND");
                    cbxCurInternalSchool.DisplayMember = "ToString";
                    //cbxCurInternalSchool.ValueMember = "SchoolName";
                    cbxCurInternalSchool.DropDownStyle = ComboBoxStyle.DropDownList;
                    QLNSCommon.SetComboBoxDropDownWidth(cbxCurInternalSchool);
                    if (Checking.CheckNullString(cbxCurInternalSchool.Text) == "")
                    {
                        txtCurInternalAcademicLevelName.Text = "";
                        txtCurInternalTraningType.Text = "";
                        dteCurInternalSchoolYear.Format = DateTimePickerFormat.Custom;
                    }
                }
                if (fostering)
                {
                    cbxFosteringPLNV.DataSource = allFosteringProcess.FindAll(p => p.PersonCode == txtCode.Text && p.Type == "Bồi dưỡng PLNV");
                    cbxFosteringPLNV.DisplayMember = "FosteringContent";
                    cbxFosteringPLNV.ValueMember = "FosteringContent";
                    cbxFosteringPLNV.DropDownStyle = ComboBoxStyle.DropDownList;
                    cbxTittleTraning.DataSource = allFosteringProcess.FindAll(p => p.PersonCode == txtCode.Text && p.Type == "Bồi dưỡng chức danh");
                    cbxTittleTraning.DisplayMember = "FosteringContent";
                    cbxTittleTraning.ValueMember = "FosteringContent";
                    cbxTittleTraning.DropDownStyle = ComboBoxStyle.DropDownList;
                    cbxTittleTraningPlanning.DataSource = allFosteringProcess.FindAll(p => p.PersonCode == txtCode.Text && p.Type == "Bồi dưỡng quy hoạch chức danh");
                    cbxTittleTraningPlanning.DisplayMember = "FosteringContent";
                    cbxTittleTraningPlanning.ValueMember = "FosteringContent";
                    cbxTittleTraningPlanning.DropDownStyle = ComboBoxStyle.DropDownList;
                    cbxFosteringQPA.DataSource = allFosteringProcess.FindAll(p => p.PersonCode == txtCode.Text && p.Type == "Bồi dưỡng QPAN");
                    cbxFosteringQPA.DisplayMember = "FosteringContent";
                    cbxFosteringQPA.ValueMember = "FosteringContent";
                    cbxFosteringQPA.DropDownStyle = ComboBoxStyle.DropDownList;
                }
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

       
        private void cbxInternalSchool_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Checking.CheckNullString(cbxInternalSchool.Text) == "") 
                {
                    txtInternalAcademicLevelName.Text = "";
                    txtInternalTraningType.Text = "";
                    dteInternalSchoolYear.Format = DateTimePickerFormat.Custom; 
                    return; 
                }
                List<string> result = new List<string>(cbxInternalSchool.Text.Split('-'));

                TranningProcess trainInternal = allTranningProcess.Find(item => 
                item.SchoolName == Checking.CheckNullString(result[0]) 
                && item.PersonCode == txtCode.Text
                && item.Type == "Tốt nghiệp trong CAND"
                && item.Major == Checking.CheckNullString(result[1])
                && item.Level == Checking.CheckNullString(result[2])
                );
               
                
                if (trainInternal != null)
                {
                    if(Checking.CheckNullString(trainInternal.EndYear) != ""){
                        dteInternalSchoolYear.Value = Common.ConvertStringToDate(trainInternal.EndYear);
                    }
                    
                    txtInternalMajor.Text = trainInternal.Major;
                    txtInternalAcademicLevelName.Text = trainInternal.Level;
                    txtInternalTraningType.Text = trainInternal.TraningType;
                }
                if (!load)
                {
                    edit = true;
                    btnSave.Enabled = true;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi trong quá trình xử lý dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbxSchoolName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Checking.CheckNullString(cbxSchoolName.Text) == "") {
                    txtAcademicLevelName.Text = "";
                    txtTraningType.Text = "";
                    dteSchoolYear.Format = DateTimePickerFormat.Custom;
                    return; 
                }
                List<string> result = new List<string>(cbxSchoolName.Text.Split('-'));

                TranningProcess trainInternal = allTranningProcess.Find(item =>
                item.SchoolName == Checking.CheckNullString(result[0])
                && item.PersonCode == txtCode.Text
                && item.Type == "Tốt nghiệp trường ngoài CAND"
                && item.Major == Checking.CheckNullString(result[1])
                && item.Level == Checking.CheckNullString(result[2])
                );

                //TranningProcess trainInternal = allTranningProcess.Find(item => item.SchoolName == Checking.CheckNullString(cbxSchoolName.Text) && item.PersonCode == txtCode.Text.Trim() && item.PersonCode == txtCode.Text.Trim() && item.Type == "Tốt nghiệp trường ngoài CAND");

                if (trainInternal != null)
                {
                    if (Checking.CheckNullString(trainInternal.EndYear) != "")
                    {
                        dteSchoolYear.Value = Common.ConvertStringToDate(trainInternal.EndYear);
                        dteSchoolYear.Format = DateTimePickerFormat.Short;
                    }
                    txtIMajor.Text = trainInternal.Major;
                    txtAcademicLevelName.Text = trainInternal.Level;
                    txtTraningType.Text = trainInternal.TraningType;
                }
                if (!load)
                {
                    edit = true;
                    btnSave.Enabled = true;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi trong quá trình xử lý dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbxCurInternalSchool_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Checking.CheckNullString(cbxCurInternalSchool.Text) == "") {
                    txtCurInternalAcademicLevelName.Text = "";
                    txtCurInternalTraningType.Text = "";
                    dteCurInternalSchoolYear.Format = DateTimePickerFormat.Custom;
                    return;
                }
                List<string> result = new List<string>(cbxCurInternalSchool.Text.Split('-'));

                TranningProcess trainInternal = allTranningProcess.Find(item =>
                item.SchoolName == Checking.CheckNullString(result[0])
                && item.PersonCode == txtCode.Text
                && item.Type == "Đang học các lớp trong CAND"
                && item.Major == Checking.CheckNullString(result[1])
                && item.Level == Checking.CheckNullString(result[2])
                );
                //TranningProcess trainInternal = allTranningProcess.Find(item => item.SchoolName == Checking.CheckNullString(cbxCurInternalSchool.Text) && item.PersonCode == txtCode.Text.Trim() && item.PersonCode == txtCode.Text.Trim() && item.Type == "Đang học các lớp trong CAND");
                if (trainInternal != null)
                {
                    if(trainInternal.EndYear != "")
                    {
                        dteCurInternalSchoolYear.Value = Common.ConvertStringToDate(trainInternal.EndYear);
                        dteCurInternalSchoolYear.Format = DateTimePickerFormat.Short;
                    }
                    txtCurInternalMajor.Text = trainInternal.Major;
                    txtCurInternalAcademicLevelName.Text = trainInternal.Level;
                    txtCurInternalTraningType.Text = trainInternal.TraningType;
                }
                if (!load)
                {
                    edit = true;
                    btnSave.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi trong quá trình xử lý dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (!load)
            {
                edit = true;
                btnSave.Enabled = true;
            }
        }

        private void rtbNote_TextChanged(object sender, EventArgs e)
        {
            if (!load)
            {
                edit = true;
                btnSave.Enabled = true;
            }
        }

       

        private void dteSchoolYear_ValueChanged(object sender, EventArgs e)
        {

            if (!load)
            {
                edit = true;
                btnSave.Enabled = true;
                dteSchoolYear.Format = DateTimePickerFormat.Short;
                // dteCommunistPartyBegin.Value = Common.ConvertStringToDate(person.CommunistPartyBegin);
            }
        }

        private void dteCurInternalSchoolYear_ValueChanged(object sender, EventArgs e)
        {

            if (!load)
            {
                edit = true;
                btnSave.Enabled = true;
                dteCurInternalSchoolYear.Format = DateTimePickerFormat.Short;
                // dteCommunistPartyBegin.Value = Common.ConvertStringToDate(person.CommunistPartyBegin);
            }
        }

        private void dteInternalSchoolYear_ValueChanged(object sender, EventArgs e)
        {

            if (!load)
            {
                edit = true;
                btnSave.Enabled = true;
                dteInternalSchoolYear.Format = DateTimePickerFormat.Short;
                // dteCommunistPartyBegin.Value = Common.ConvertStringToDate(person.CommunistPartyBegin);
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

        private void DtDateOfBird_ValueChanged(object sender, EventArgs e)
        {
            if (!load)
            {
                edit = true;
                btnSave.Enabled = true;
                dteCurInternalSchoolYear.Format = DateTimePickerFormat.Short;
                // dteCommunistPartyBegin.Value = Common.ConvertStringToDate(person.CommunistPartyBegin);
            }
        }

        private void cbxGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!load)
            {
                edit = true;
                btnSave.Enabled = true;
                dteCurInternalSchoolYear.Format = DateTimePickerFormat.Short;
                // dteCommunistPartyBegin.Value = Common.ConvertStringToDate(person.CommunistPartyBegin);
            }
        }

        private void cbxCompetition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!load)
            {
                edit = true;
                btnSave.Enabled = true;
                dteCurInternalSchoolYear.Format = DateTimePickerFormat.Short;
                // dteCommunistPartyBegin.Value = Common.ConvertStringToDate(person.CommunistPartyBegin);
            }
        }

        private void cbxClassify_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!load)
            {
                edit = true;
                btnSave.Enabled = true;
                dteCurInternalSchoolYear.Format = DateTimePickerFormat.Short;
                // dteCommunistPartyBegin.Value = Common.ConvertStringToDate(person.CommunistPartyBegin);
            }
        }

        private void cbxPoliticalLevelForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!load)
            {
                edit = true;
                btnSave.Enabled = true;
                dteCurInternalSchoolYear.Format = DateTimePickerFormat.Short;
                // dteCommunistPartyBegin.Value = Common.ConvertStringToDate(person.CommunistPartyBegin);
            }
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            if (!load)
            {
                edit = true;
                btnSave.Enabled = true;
                dteCurInternalSchoolYear.Format = DateTimePickerFormat.Short;
                // dteCommunistPartyBegin.Value = Common.ConvertStringToDate(person.CommunistPartyBegin);
            }
        }

        private void txtIMajor_TextChanged(object sender, EventArgs e)
        {
            if (!load)
            {
                edit = true;
                btnSave.Enabled = true;
                dteCurInternalSchoolYear.Format = DateTimePickerFormat.Short;
                // dteCommunistPartyBegin.Value = Common.ConvertStringToDate(person.CommunistPartyBegin);
            }
        }

        private void mtbYearBegin_TextChanged(object sender, EventArgs e)
        {
            if (!load)
            {
                edit = true;
                btnSave.Enabled = true;
                dteCurInternalSchoolYear.Format = DateTimePickerFormat.Short;
                // dteCommunistPartyBegin.Value = Common.ConvertStringToDate(person.CommunistPartyBegin);
            }
        }

        private void mtbOfficialStartYear_TextChanged(object sender, EventArgs e)
        {
            if (!load)
            {
                edit = true;
                btnSave.Enabled = true;
                dteCurInternalSchoolYear.Format = DateTimePickerFormat.Short;
                // dteCommunistPartyBegin.Value = Common.ConvertStringToDate(person.CommunistPartyBegin);
            }
        }

        private void mtbCommunistPartyBegin_TextChanged(object sender, EventArgs e)
        {
            if (!load)
            {
                edit = true;
                btnSave.Enabled = true;
                dteCurInternalSchoolYear.Format = DateTimePickerFormat.Short;
                // dteCommunistPartyBegin.Value = Common.ConvertStringToDate(person.CommunistPartyBegin);
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

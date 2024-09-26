using GemBox.Spreadsheet;
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

namespace QuanLyNhanSu.Category
{
    public partial class frmSchool : Form
    {

        string fileName = "School\\School.txt";
        List<School> school;
        List<School> allSchool;

        public frmSchool()
        {
            InitializeComponent();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmUnits_Load(object sender, EventArgs e)
        {
            Search();
            dataGridView1.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        }
        private void Search()
        {
            try
            {
                string content = Common.ReadFileContent(QLNSCommon.pathCategory + fileName);
                allSchool = new List<School>();
                allSchool = Newtonsoft.Json.JsonConvert.DeserializeObject<List<School>>(content);
                dataGridView1.DataSource = allSchool;
                Resize();
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
            // dataGridView1.Columns["DisplayName"].Visible = false;
            dataGridView1.Columns["Type"].Visible = false;
            dataGridView1.Columns["CreatedBy"].Visible = false;
            dataGridView1.Columns["CreatedTime"].Visible = false;
            dataGridView1.Columns["ModifiedBy"].Visible = false;
            dataGridView1.Columns["ModifiedTime"].Visible = false;

            dataGridView1.Columns["Name"].HeaderText = "Tên trường";
            dataGridView1.Columns["Code"].HeaderText = "Mã trường";
            dataGridView1.Columns["Note"].HeaderText = "Ghi chú";
            dataGridView1.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Note"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCode.Text.Trim() != "" && txtName.Text.Trim() != "")
                {
                    school = allSchool.FindAll(item => item.Code.StartsWith(txtCode.Text.Trim()) && item.Name.StartsWith(txtName.Text.Trim()));
                }
                else if (txtCode.Text.Trim() != "")
                {
                    school = allSchool.FindAll(item => item.Code.StartsWith(txtCode.Text.Trim()));
                }
                else if (txtName.Text.Trim() != "")
                {
                    school = allSchool.FindAll(item => item.Name.StartsWith(txtName.Text.Trim()));
                }
                else
                {
                    school = allSchool;
                }

                dataGridView1.DataSource = school;
                Resize();
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
        private void Edit(Decimal value)
        {
            School school = allSchool.FirstOrDefault(obj => obj.Id == value);
            frmSchoolDetail frmDetail = new frmSchoolDetail();
            frmDetail.schoolId = school.Id;
            frmDetail.school = school;
            frmDetail.ShowDialog();
            if (frmDetail.succesed)
            {
                if (frmDetail.schoolId == school.Id)
                {
                    string str = Newtonsoft.Json.JsonConvert.SerializeObject(allSchool);
                    Common.SaveFileContent(QLNSCommon.pathCategory + fileName, str);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = allSchool;
                    Resize();
                    MessageBox.Show("Lưu dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                DataGridViewRow clickedRow = dataGridView1.Rows[e.RowIndex];
                decimal value = decimal.Parse(clickedRow.Cells["Id"].Value.ToString());
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
                            decimal targetID = decimal.Parse(row.Cells["Id"].Value.ToString());
                            allSchool.RemoveAll(obj => obj.Id == targetID);
                        }
                    }
                    string str = Newtonsoft.Json.JsonConvert.SerializeObject(allSchool);
                    Common.SaveFileContent(QLNSCommon.pathCategory + fileName, str);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = allSchool;
                    Resize();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int maxID = 0;
                if (allSchool != null && allSchool.Count > 0) { maxID = allSchool.Max(obj => obj.Id); }
                else
                {
                    maxID = 1;
                    Level allLevel = new Level();
                }


                frmSchoolDetail frmDetail = new frmSchoolDetail();
                frmDetail.maxschoolId = maxID;
                frmDetail.ShowDialog();
                if (frmDetail.succesed)
                {
                    if (frmDetail.schoolId > 0)
                    {
                        allSchool.Add(frmDetail.school);
                        string str = Newtonsoft.Json.JsonConvert.SerializeObject(allSchool);
                        Common.SaveFileContent(QLNSCommon.pathCategory + fileName, str);
                        MessageBox.Show("Lưu dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = allSchool;
                        Resize();
                    }
                }
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
                    decimal cellValue = decimal.Parse(selectedRow.Cells["id"].Value.ToString());
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SpreadsheetInfo.SetLicense(Common.excelLicence);
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "Excel Files|*.xls;*.xlsx;*.xlsm",
                    Title = "Select an Excel File"
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    //var myClassList = new List<School>();

                    var workbook = ExcelFile.Load(filePath);
                    var worksheet = workbook.Worksheets[0]; 

                    int maxID = 0;
                    if (allSchool != null && allSchool.Count > 0) { maxID = allSchool.Max(obj => obj.Id); }
                    else
                    {
                        maxID = 1;
                        //Level allLevel = new Level();
                    }
                    for (int row = 1; row < worksheet.Rows.Count; row++)
                    {
                        maxID = maxID + 1;
                        var school = new School
                        {
                            Id = maxID,
                            Code = worksheet.Cells[row, 1].Value.ToString(),
                            Name = worksheet.Cells[row, 2].Value.ToString()
                        };
                        allSchool.Add(school);
                    }
                    string str = Newtonsoft.Json.JsonConvert.SerializeObject(allSchool);
                    Common.SaveFileContent(QLNSCommon.pathCategory + fileName, str);
                    MessageBox.Show("Lưu dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = allSchool;
                    Resize();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        } 
    }
}

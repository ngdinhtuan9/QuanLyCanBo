using Newtonsoft.Json.Linq;
using QuanLyNhanSu.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyNhanSu.Category
{
    public partial class frmDepartment : Form
    {
        
        string fileName = "Department\\Department.txt";
        List<Department> allDepartment;
        string fileNameUnit = "Units\\Units.txt";
        List<Department> department;
        
        List<Unit> allUnits;
        public frmDepartment()
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
                string contentUnit = Common.ReadFileContent(Common.pathCategory + fileNameUnit);
                List<Unit> units = new List<Unit>();
                allUnits = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Unit>>(contentUnit);
               
                Unit unit = new Unit();
                unit.Id = 0;
                unit.Name = "Tất cả";
                allUnits.Add(unit);

                cbxUnit.DataSource = allUnits;
                cbxUnit.DisplayMember = "Name";
                cbxUnit.ValueMember = "Id";
                cbxUnit.DropDownStyle = ComboBoxStyle.DropDownList;
                cbxUnit.SelectedValue = 0;

                string content =  Common.ReadFileContent(Common.pathCategory + fileName);
                allDepartment = new List<Department>();
                allDepartment = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Department>>(content);

                var result = from item1 in allDepartment
                             join item2 in allUnits on item1.UnitId equals item2.Id into joined
                             from subItem2 in joined.DefaultIfEmpty()
                             select new
                             {
                                 ID = item1.Id,
                                 Code = item1.Code,
                                 DepName = item1.Name,
                                 //DisplayName = item1.DisplayName,
                                 UnitName = subItem2 != null ? subItem2.Name : null
                             };

                dataGridView1.DataSource = result.ToList();
                Resize();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ReSearch()
        {
            if (txtDepName.Text.Trim() != "" && int.Parse(cbxUnit.SelectedValue.ToString()) != 0)
            {
                department = allDepartment.FindAll(item => item.Name.StartsWith(txtDepName.Text.Trim()) && item.UnitId == int.Parse(cbxUnit.SelectedValue.ToString()));
            }
            else if (txtDepName.Text.Trim() != "")
            {
                department = allDepartment.FindAll(item => item.Name.StartsWith(txtDepName.Text.Trim()));
            }
            else if (int.Parse(cbxUnit.SelectedValue.ToString()) != 0)
            {
                department = allDepartment.FindAll(item => item.UnitId == int.Parse(cbxUnit.SelectedValue.ToString()));
            }
            else
            {
                department = allDepartment;
            }
            var result = from item1 in department
                         join item2 in allUnits on item1.UnitId equals item2.Id into joined
                         from subItem2 in joined.DefaultIfEmpty()
                         select new
                         {
                             ID = item1.Id,
                             Code = item1.Code,
                             DepName = item1.Name,
                             //DisplayName = item1.DisplayName,
                             UnitName = subItem2 != null ? subItem2.Name : null
                         };

            dataGridView1.DataSource = result.ToList();
            Resize();
            // dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.ColumnHeader);
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                ReSearch();
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
            Department department = allDepartment.FirstOrDefault(obj => obj.Id == value);
            frmDepartmentDetail frmDetail = new frmDepartmentDetail();
            frmDetail.departmentDetailId = department.Id;
            frmDetail.dep = department;
            frmDetail.ShowDialog();
            if (frmDetail.successed)
            {
                if (frmDetail.departmentDetailId == department.Id)
                {
                    string str = Newtonsoft.Json.JsonConvert.SerializeObject(allDepartment);
                    Common.SaveFileContent(Common.pathCategory + fileName, str);
                    dataGridView1.DataSource = null;
                    ReSearch();
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
                if(count == 0) { MessageBox.Show("Không có dữ liệu được chọn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa các dữ liệu đã chọn?","Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--)
                    {
                        DataGridViewRow row = dataGridView1.Rows[i];
                        DataGridViewCheckBoxCell cell = row.Cells["CHECK"] as DataGridViewCheckBoxCell;
                        bool isChecked = Convert.ToBoolean(cell.Value);
                        if (isChecked)
                        {
                            decimal targetID = decimal.Parse(row.Cells["Id"].Value.ToString());
                            allDepartment.RemoveAll(obj => obj.Id == targetID);
                        }
                    }
                    dataGridView1.DataSource = null;
                    string str = Newtonsoft.Json.JsonConvert.SerializeObject(allDepartment);
                    Common.SaveFileContent(Common.pathCategory + fileName, str);
                    ReSearch();
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
                if (allDepartment != null && allDepartment.Count > 0) {
                    
                    maxID = allDepartment.Max(obj => obj.Id);
                }
                else
                {
                   // allDepartment = new List<Department>();
                    maxID = 0;
                }
                frmDepartmentDetail frmDetail = new frmDepartmentDetail();
                frmDetail.maxDepartmentDetailId = maxID;
                frmDetail.ShowDialog();
                if (frmDetail.successed)
                {
                    if (frmDetail.departmentDetailId > 0)
                    {
                        allDepartment.Add(frmDetail.dep);
                        string str = Newtonsoft.Json.JsonConvert.SerializeObject(allDepartment);
                        Common.SaveFileContent(Common.pathCategory + fileName, str);
                        MessageBox.Show("Lưu dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = allDepartment;
                        ReSearch();
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
            catch (Exception ex )
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
        private void Resize()
        {
            try
            {
                System.Drawing.Font headerFont = new System.Drawing.Font(dataGridView1.Font, System.Drawing.FontStyle.Bold);
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = headerFont;
                dataGridView1.Columns["id"].Visible = false;
                dataGridView1.Columns["UnitName"].HeaderText = "Tên đơn vị";
                //dataGridView1.Columns["UnitName"].Width = 340;
                dataGridView1.Columns["Code"].HeaderText = "Mã phòng ban";
                dataGridView1.Columns["DepName"].HeaderText = "Tên phòng ban";
                //dataGridView1.Columns["DepName"].Width = 340;
                dataGridView1.Columns["UnitName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns["DepName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            }
            catch (Exception)
            {

                throw;
            }
           
        }
    }
}

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
using System.Xml.Linq;

namespace QuanLyNhanSu.Category
{
    public partial class frmUnits : Form
    {

        string fileName = "Units\\Units.txt";
        string fileNameDep = "Department\\Department.txt";
        List<Unit> units;
        List<Unit> allUnits;
        public frmUnits()
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
        }
        private void Search()
        {
            try
            {
                string content = Common.ReadFileContent(Common.pathCategory + fileName);
                allUnits = new List<Unit>();
                allUnits = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Unit>>(content);
                dataGridView1.DataSource = allUnits;
                Resize();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Resize()
        {
            dataGridView1.Columns["id"].Visible = false;
           // dataGridView1.Columns["DisplayName"].Visible = false;
            dataGridView1.Columns["Type"].Visible = false;
            dataGridView1.Columns["CreatedBy"].Visible = false;
            dataGridView1.Columns["CreatedTime"].Visible = false;
            dataGridView1.Columns["ModifiedBy"].Visible = false;
            dataGridView1.Columns["ModifiedTime"].Visible = false;

            dataGridView1.Columns["Name"].HeaderText = "Tên đơn vị";
            dataGridView1.Columns["Code"].HeaderText = "Mã đơn vị";
            dataGridView1.Columns["Note"].HeaderText = "Ghi chú";
            dataGridView1.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Note"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void ReSearch()
        {
            if (txtUnitCode.Text.Trim() != "" && txtUnitName.Text.Trim() != "")
            {
                units = allUnits.FindAll(item => item.Code.StartsWith(txtUnitCode.Text.Trim()) && item.Name.StartsWith(txtUnitName.Text.Trim()));
            }
            else if (txtUnitCode.Text.Trim() != "")
            {
                units = allUnits.FindAll(item => item.Code.StartsWith(txtUnitCode.Text.Trim()));
            }
            else if (txtUnitName.Text.Trim() != "")
            {
                units = allUnits.FindAll(item => item.Name.StartsWith(txtUnitName.Text.Trim()));
            }
            else
            {
                units = allUnits;
            }

            dataGridView1.DataSource = units;
            Resize();
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
            Unit unit = allUnits.FirstOrDefault(obj => obj.Id == value);
            frmUnitDetail frmDetail = new frmUnitDetail();
            frmDetail.unitId = unit.Id;
            frmDetail.unit = unit;
            frmDetail.ShowDialog();
            if (frmDetail.succesed)
            {
                if (frmDetail.unitId == unit.Id)
                {
                    string str = Newtonsoft.Json.JsonConvert.SerializeObject(allUnits);
                    Common.SaveFileContent(Common.pathCategory + fileName, str);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = allUnits;
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
                List<int> count = new List<int>();
                for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--)
                {
                    DataGridViewRow row = dataGridView1.Rows[i];
                    DataGridViewCheckBoxCell cell = row.Cells["CHECK"] as DataGridViewCheckBoxCell;
                    bool isChecked = Convert.ToBoolean(cell.Value);
                    if (isChecked)
                    {
                        count.Add(int.Parse(row.Cells["Id"].Value.ToString()));
                    }
                }
                if (count.Count == 0) { MessageBox.Show("Không có dữ liệu được chọn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                //kiem tra du lieu da duoc su dung chua
                string content = Common.ReadFileContent(Common.pathCategory + fileNameDep);
                var allDepartment = new List<Department>();
                allDepartment = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Department>>(content);
                List<Department> selectedObjects = allDepartment.Where(obj => count.Contains(obj.UnitId)).ToList();
                if(selectedObjects.Count > 0)
                {
                    MessageBox.Show("Đơn vị đang được sử dụng không thể xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

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
                            allUnits.RemoveAll(obj => obj.Id == targetID);
                        }
                    }
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = allUnits;
                    string str = Newtonsoft.Json.JsonConvert.SerializeObject(allUnits);
                    Common.SaveFileContent(Common.pathCategory + fileName, str);
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
                if (allUnits != null && allUnits.Count > 0) { maxID = allUnits.Max(obj => obj.Id); }
                else
                {
                    //allUnits = new List<Unit>();
                    maxID = 1;
                }

                //GeneralCategory unit = units.FirstOrDefault(obj => obj.Id == value);
                frmUnitDetail frmDetail = new frmUnitDetail();
                //frmDetail.unitId = unit.Id;
                //frmDetail.unit = unit;
                frmDetail.maxUnitId = maxID;
                frmDetail.ShowDialog();
                if (frmDetail.succesed)
                {
                    if (frmDetail.unitId > 0)
                    {
                        allUnits.Add(frmDetail.unit);
                        string str = Newtonsoft.Json.JsonConvert.SerializeObject(allUnits);
                        Common.SaveFileContent(Common.pathCategory + fileName, str);
                        MessageBox.Show("Lưu dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = allUnits;
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
    }
}

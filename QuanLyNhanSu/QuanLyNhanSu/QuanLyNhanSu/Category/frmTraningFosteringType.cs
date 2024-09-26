﻿using Newtonsoft.Json.Linq;
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
    public partial class frmTraningFosteringType : Form
    {
        List<TraningFosteringType> allTraningFosteringType;
        string fileName = "TraningFosteringType\\TraningFosteringType.txt";
         List<TraningFosteringType> TraningFosteringType;
         

        public frmTraningFosteringType()
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
                string content =  Common.ReadFileContent(QLNSCommon.pathCategory + fileName);
                allTraningFosteringType = new List<TraningFosteringType>();
                allTraningFosteringType = Newtonsoft.Json.JsonConvert.DeserializeObject<List<TraningFosteringType>>(content);
                dataGridView1.DataSource = allTraningFosteringType;
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

            dataGridView1.Columns["Name"].HeaderText = "Nội dung";
            dataGridView1.Columns["Code"].HeaderText = "Mã ";
            dataGridView1.Columns["Note"].HeaderText = "Ghi chú";
            dataGridView1.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Note"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUnitCode.Text.Trim() != "" && txtUnitName.Text.Trim() != "")
                {
                    TraningFosteringType = allTraningFosteringType.FindAll(item => item.Code.StartsWith(txtUnitCode.Text.Trim()) && item.Name.StartsWith(txtUnitName.Text.Trim()));
                }
                else if (txtUnitCode.Text.Trim() != "")
                {
                    TraningFosteringType = allTraningFosteringType.FindAll(item => item.Code.StartsWith(txtUnitCode.Text.Trim()));
                }
                else if (txtUnitName.Text.Trim() != "")
                {
                    TraningFosteringType = allTraningFosteringType.FindAll(item => item.Name.StartsWith(txtUnitName.Text.Trim()));
                }
                else
                {
                    TraningFosteringType = allTraningFosteringType;
                }

                dataGridView1.DataSource = TraningFosteringType;
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
            TraningFosteringType TraningFosteringType = allTraningFosteringType.FirstOrDefault(obj => obj.Id == value);
            frmTraningFosteringTypeDetail frmDetail = new frmTraningFosteringTypeDetail();
            frmDetail.traningFosteringTypeId = TraningFosteringType.Id;
            frmDetail.traningFosteringType = TraningFosteringType;
            frmDetail.ShowDialog();
            if (frmDetail.succesed)
            {
                if (frmDetail.traningFosteringTypeId == TraningFosteringType.Id)
                {
                    string str = Newtonsoft.Json.JsonConvert.SerializeObject(allTraningFosteringType);
                    Common.SaveFileContent(QLNSCommon.pathCategory + fileName, str);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = allTraningFosteringType;
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
                            allTraningFosteringType.RemoveAll(obj => obj.Id == targetID);
                        }
                    }
                    string str = Newtonsoft.Json.JsonConvert.SerializeObject(allTraningFosteringType);
                    Common.SaveFileContent(QLNSCommon.pathCategory + fileName, str);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = allTraningFosteringType;
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
                if (allTraningFosteringType != null && allTraningFosteringType.Count >0) { maxID = allTraningFosteringType.Max(obj => obj.Id); }
                else
                {
                    maxID = 1;
                     allTraningFosteringType = new List<TraningFosteringType>();
                }


                frmTraningFosteringTypeDetail frmDetail = new frmTraningFosteringTypeDetail();
                frmDetail.maxTraningFosteringTypeId = maxID;
                frmDetail.ShowDialog();
                if (frmDetail.succesed)
                {
                    if (frmDetail.traningFosteringTypeId > 0)
                    {
                        allTraningFosteringType.Add(frmDetail.traningFosteringType);
                        string str = Newtonsoft.Json.JsonConvert.SerializeObject(allTraningFosteringType);
                        Common.SaveFileContent(QLNSCommon.pathCategory + fileName, str);
                        MessageBox.Show("Lưu dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = allTraningFosteringType;
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
            catch (Exception ex )
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
    }
}

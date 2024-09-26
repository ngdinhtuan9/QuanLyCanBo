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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLyNhanSu.Category
{
    public partial class frmAccount : Form
    {
        
        
        string fileName =  "Account.txt";
        List<User> allUser;
        List<User> userSearch;

        List<Unit> allUnits;
        string fileUnitName = "Units\\Units.txt";
        public frmAccount()
        {
            InitializeComponent();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmUnits_Load(object sender, EventArgs e)
        {
            string unit = Common.ReadFileContent(QLNSCommon.pathCategory + fileUnitName);
            allUnits = new List<Unit>();
            allUnits = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Unit>>(unit);
            if (allUnits.Count > 1)
            {
                Unit unitAll = new Unit();
                unitAll.Name = "Tất cả";
                unitAll.Id = 0;
                allUnits.Add(unitAll);
            }
            cbxUnit.DataSource = allUnits;
            cbxUnit.DisplayMember = "Name";
            cbxUnit.ValueMember = "Id";
            cbxUnit.Text = "Tất cả";
            cbxUnit.DropDownStyle = ComboBoxStyle.DropDownList;

            Search();
            dataGridView1.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        }
        private void Search()
        {
            try
            {
                string content =  Common.ReadFileContent(QLNSCommon.pathAccount + fileName);
                allUser = new List<User>();
                allUser = Newtonsoft.Json.JsonConvert.DeserializeObject<List<User>>(content);
                dataGridView1.DataSource = allUser;


                Resize();
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
            dataGridView1.Columns["id"].Visible = false;
            // dataGridView1.Columns["DisplayName"].Visible = false;
            //dataGridView1.Columns["Type"].Visible = false;

            dataGridView1.Columns["CreatedBy"].Visible = false;
            dataGridView1.Columns["CreatedTime"].Visible = false;
            dataGridView1.Columns["ModifiedBy"].Visible = false;
            dataGridView1.Columns["ModifiedTime"].Visible = false;

            dataGridView1.Columns["Password"].Visible = false;
            dataGridView1.Columns["Role"].HeaderText = "Vai trò ";
            dataGridView1.Columns["UserName"].HeaderText = "Tên tài khoản";
             dataGridView1.Columns["UnitName"].HeaderText = "Tên đơn vị";
            if (dataGridView1.Columns.Contains("Function"))
            {
                dataGridView1.Columns["Function"].HeaderText = "Chức năng";
            }
                dataGridView1.Columns["UnitName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dataGridView1.Columns["Note"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                userSearch = allUser;
                if (txtUnitCode.Text.Trim() != "")
                {
                    userSearch = userSearch.FindAll(item => item.UserName.Contains(txtUnitCode.Text.Trim()));
                }
                if (cbxUnit.Text.Trim() != "" && cbxUnit.Text.Trim() != "Tất cả")
                {
                    userSearch = userSearch.FindAll(item => item.UnitName == cbxUnit.Text.Trim());
                }

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = userSearch;
                Resize();
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
        //private void Edit(Decimal value)
        //{
        //    Competition Competition = allCompetition.FirstOrDefault(obj => obj.Id == value);
        //    frmCompetitionDetail frmDetail = new frmCompetitionDetail();
        //    frmDetail.competitionId = Competition.Id;
        //    frmDetail.competition = Competition;
        //    frmDetail.ShowDialog();
        //    if (frmDetail.succesed)
        //    {
        //        if (frmDetail.competitionId == Competition.Id)
        //        {
        //            string str = Newtonsoft.Json.JsonConvert.SerializeObject(allCompetition);
        //            Common.SaveFileContent(QLNSCommon.pathCategory + fileName, str);
        //            dataGridView1.DataSource = null;
        //            dataGridView1.DataSource = allCompetition;
        //            Resize();
        //            MessageBox.Show("Lưu dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //    }
        //}
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                DataGridViewRow clickedRow = dataGridView1.Rows[e.RowIndex];
                string value = clickedRow.Cells["UserName"].Value.ToString();

               // if (dataGridView1.SelectedRows.Count > 0)
              //  {
                   // DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    //decimal cellValue = decimal.Parse(selectedRow.Cells["id"].Value.ToString());
                   // try
                   // {
                        frmChangePass frmDep = new frmChangePass();
                        frmDep.userName = value;
                        frmDep.adminChangePass = true;
                        //frmDep.TopLevel = false;
                        frmDep.ShowDialog();
                   // }
                   // catch (Exception ex)
                   // {
                   // }
              //  }
               // else
               // {
                   // MessageBox.Show("Chưa có thông tin nào được chọn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
              //  }
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

                if (MessageBox.Show("Bạn có chắc chắn muốn xóa các dữ liệu đã chọn?","Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--)
                    {
                        DataGridViewRow row = dataGridView1.Rows[i];
                        DataGridViewCheckBoxCell cell = row.Cells["CHECK"] as DataGridViewCheckBoxCell;
                        bool isChecked = Convert.ToBoolean(cell.Value);
                        if (isChecked)
                        {
                            string targetName=  Checking.CheckNullString( row.Cells["UserName"].Value);
                            allUser.RemoveAll(obj => obj.UserName == targetName);
                        }
                    }
                    string str = Newtonsoft.Json.JsonConvert.SerializeObject(allUser);
                    Common.SaveFileContent(QLNSCommon.pathAccount + fileName, str);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = allUser;
                    Resize();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi trong quá trình xử lý dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var frmCreateAcc = new frmCreateAccount();
                frmCreateAcc.ShowDialog();
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
                    //decimal cellValue = decimal.Parse(selectedRow.Cells["id"].Value.ToString());
                    try
                    {
                        frmChangePass frmDep = new frmChangePass();
                        frmDep.userName = selectedRow.Cells["UserName"].Value.ToString();
                        frmDep.adminChangePass = true;
                        //frmDep.TopLevel = false;
                        frmDep.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi trong quá trình xử lý dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng đang được hoàn thiện.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //try
            //{
            //    frmCreatetoken frmDep = new frmCreatetoken();
            //    // frmDep.TopLevel = false;
            //    frmDep.Show();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Lỗi trong quá trình xử lý dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
    }
}

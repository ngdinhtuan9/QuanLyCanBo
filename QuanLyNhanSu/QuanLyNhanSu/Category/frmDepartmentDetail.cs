using QuanLyNhanSu.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyNhanSu.Category
{
    public partial class frmDepartmentDetail : Form
    {
        public Department dep;
        public Decimal departmentDetailId = 0;
        public int maxDepartmentDetailId = 0;
        public bool successed;
        List<Unit> allUnits;
        string fileUnitName = "Units\\Units.txt";

        public frmDepartmentDetail()
        {
            InitializeComponent();
        }

        private void frmUnitDetail_Load(object sender, EventArgs e)
        {
            try
            {
                string content = Common.ReadFileContent(QLNSCommon.pathCategory + fileUnitName);
                allUnits = new List<Unit>();
                allUnits = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Unit>>(content);
                List<Unit> unitRole = allUnits;
                if (Common.glbUnit != "Tất cả")
                {
                    unitRole = allUnits.FindAll(item => item.Name.Contains(Common.glbUnit.Trim()));
                    cbxUnit.DropDownStyle = ComboBoxStyle.DropDown;
                }
                cbxUnit.DataSource = unitRole;
                cbxUnit.DisplayMember = "Name";
                cbxUnit.ValueMember = "Id";
                cbxUnit.Text = "";
                cbxUnit.DropDownWidth = 400;
                if (Common.glbUnit != "Tất cả")
                {
                    cbxUnit.Text = Common.glbUnit;
                }

                    // cbxUnit.DropDownStyle = ComboBoxStyle.DropDownList;
                    if (dep != null)
                {
                    txtCode.Text = dep.Code;
                    txtName.Text = dep.Name;
                    cbxUnit.SelectedValue = dep.UnitId;
                    rtbNote.Text = dep.Note;
                    departmentDetailId = dep.Id;
                }
                else
                {
                    dep = new Department();
                    txtCode.Text = "";
                    txtName.Text = "";
                    rtbNote.Text = "";

                }
            }
            catch (Exception ex)
            {
                successed = false;
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!valid()) return;
                if (dep.Id == 0 && maxDepartmentDetailId >= 0)
                {
                    dep.Code = txtCode.Text;
                    dep.Name = txtName.Text;
                    dep.UnitId = int.Parse(cbxUnit.SelectedValue.ToString());
                    dep.Note = rtbNote.Text;
                    dep.Id = maxDepartmentDetailId + 1;
                    departmentDetailId = dep.Id;
                }
                else
                {
                    dep.Code = txtCode.Text;
                    dep.Name = txtName.Text;
                    dep.UnitId = int.Parse(cbxUnit.SelectedValue.ToString());
                    dep.Note = rtbNote.Text;
                    
                }
                successed = true;
                this.Close();
            }
            catch (Exception ex)
            {
                successed = false;
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbxUnit_MouseClick(object sender, MouseEventArgs e)
        {
            if (Common.glbUnit != "Tất cả")
            {
                return;
            }
                string searchText = cbxUnit.Text.ToLower().Trim();
            List<Unit> filteredItems = allUnits.Where(item => item.Name.ToLower().Contains(searchText)).ToList();

            cbxUnit.DataSource = null;
            cbxUnit.DataSource = filteredItems;
            cbxUnit.DisplayMember = "Name";
            cbxUnit.ValueMember = "Id";
            cbxUnit.DroppedDown = true;
        }
        private bool valid()
        {
            try
            {
                //if (txtCode.Text == "")
                //{
                //    MessageBox.Show("Bạn phải nhập mã phòng ban.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    txtCode.Focus();
                //    return false;
                //};
                if (cbxUnit.SelectedValue == null)
                {
                    MessageBox.Show("Bạn phải chọn đơn vị.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}

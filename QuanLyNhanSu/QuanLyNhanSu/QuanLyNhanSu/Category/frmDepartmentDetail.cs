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
                string content = Common.ReadFileContent(Common.pathCategory + fileUnitName);
                allUnits = new List<Unit>();
                allUnits = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Unit>>(content);
                cbxUnit.DataSource = allUnits;
                cbxUnit.DisplayMember = "Name";
                cbxUnit.ValueMember = "Id";

                cbxUnit.DropDownStyle = ComboBoxStyle.DropDownList;
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
    }
}

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
    public partial class frmUnitDetail : Form
    {
       public Unit unit;
        public Decimal unitId = 0;
        public int maxUnitId = 0;
        public bool succesed;
        public frmUnitDetail()
        {
            InitializeComponent();
        }

        private void frmUnitDetail_Load(object sender, EventArgs e)
        {
            try
            {
                if (unit != null)
                {
                    txtCode.Text = unit.Code;
                    txtName.Text = unit.Name;
                   
                    rtbNote.Text = unit.Note;
                    unitId = unit.Id;
                }
                else
                {
                    unit = new Unit();
                    txtCode.Text = "";
                    txtName.Text = "";
                    rtbNote.Text = "";
                }
            }
            catch (Exception ex)
            {
                succesed = false;
                MessageBox.Show("Lỗi trong quá trình xử lý dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (unit.Id == 0 && maxUnitId >= 0)
                {
                    unit.Code = txtCode.Text;
                    unit.Name = txtName.Text;
                   
                    unit.Note = rtbNote.Text;
                    unit.Id = maxUnitId + 1;
                    unitId = unit.Id;
                }
                else
                {
                    unit.Code = txtCode.Text;
                    unit.Name = txtName.Text;
                    
                    unit.Note = rtbNote.Text;
                    //unit.Id = maxUnitId + 1;
                }
                succesed = true;
                this.Close();
            }
            catch (Exception ex)
            {
                succesed = false;
                MessageBox.Show("Lỗi trong quá trình xử lý dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

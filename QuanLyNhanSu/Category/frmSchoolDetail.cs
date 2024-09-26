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
    public partial class frmSchoolDetail : Form
    {
         public School school;
        public int schoolId = 0;
        public int maxschoolId = 0;
        public bool succesed;
        public frmSchoolDetail()
        {
            InitializeComponent();
        }

        private void frmUnitDetail_Load(object sender, EventArgs e)
        {
            try
            {
                if (school != null)
                {
                    txtCode.Text = school.Code;
                    txtName.Text = school.Name;
                  
                    rtbNote.Text = school.Note;
                    schoolId = school.Id;
                }
                else
                {
                    school = new School();
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
                if (school.Id == 0 && maxschoolId >= 0)
                {
                    school.Code = txtCode.Text;
                    school.Name = txtName.Text;

                    school.Note = rtbNote.Text;
                    school.Id = maxschoolId + 1;
                    schoolId = school.Id;
                }
                else
                {
                    school.Code = txtCode.Text;
                    school.Name = txtName.Text;
                    school.Note = rtbNote.Text;
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

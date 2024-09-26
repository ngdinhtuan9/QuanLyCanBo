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
    public partial class frmPersonDetail : Form
    {
         public AcademicLevel academicLevel;
        public int academicLevelId = 0;
        public int maxLevelId = 0;
        public bool succesed;
        public frmPersonDetail()
        {
            InitializeComponent();
        }

        private void frmUnitDetail_Load(object sender, EventArgs e)
        {
            try
            {
                if (academicLevel != null)
                {
                    txtLevelCode.Text = academicLevel.Code;
                    txtLevel.Text = academicLevel.Name;
                  
                    rtbNote.Text = academicLevel.Note;
                    academicLevelId = academicLevel.Id;
                }
                else
                {
                    academicLevel = new AcademicLevel();
                    txtLevelCode.Text = "";
                    txtLevel.Text = "";
                    rtbNote.Text = "";
                }
            }
            catch (Exception ex)
            {
                succesed = false;
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (academicLevel.Id == 0 && maxLevelId >= 0)
                {
                    academicLevel.Code = txtLevelCode.Text;
                    academicLevel.Name = txtLevel.Text;
                    academicLevel.Note = rtbNote.Text;
                    academicLevel.Id = maxLevelId + 1;
                    academicLevelId = academicLevel.Id;
                }
                else
                {
                    academicLevel.Code = txtLevelCode.Text;
                    academicLevel.Name = txtLevel.Text;
                    academicLevel.Note = rtbNote.Text;
                    //unit.Id = maxUnitId + 1;
                }
                succesed = true;
                this.Close();
            }
            catch (Exception ex)
            {
                succesed = false;
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}

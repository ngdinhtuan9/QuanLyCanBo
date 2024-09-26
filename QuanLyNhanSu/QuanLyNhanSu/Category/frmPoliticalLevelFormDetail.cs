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
    public partial class frmPoliticalLevelFormDetail : Form
    {
         public PoliticalLevelForm politicalLevelForm;
        public int politicalLevelFormId = 0;
        public int maxLevelFormId = 0;
        public bool succesed;
        public frmPoliticalLevelFormDetail()
        {
            InitializeComponent();
        }

        private void frmUnitDetail_Load(object sender, EventArgs e)
        {
            try
            {
                if (politicalLevelForm != null)
                {
                    txtLevelCode.Text = politicalLevelForm.Code;
                    txtLevel.Text = politicalLevelForm.Name;
                  
                    rtbNote.Text = politicalLevelForm.Note;
                    politicalLevelFormId = politicalLevelForm.Id;
                }
                else
                {
                    politicalLevelForm = new PoliticalLevelForm();
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
                if (politicalLevelForm.Id == 0 && maxLevelFormId >= 0)
                {
                    politicalLevelForm.Code = txtLevelCode.Text;
                    politicalLevelForm.Name = txtLevel.Text;
                    politicalLevelForm.Note = rtbNote.Text;
                    politicalLevelForm.Id = maxLevelFormId + 1;
                    politicalLevelFormId = politicalLevelForm.Id;
                }
                else
                {
                    politicalLevelForm.Code = txtLevelCode.Text;
                    politicalLevelForm.Name = txtLevel.Text;
                    politicalLevelForm.Note = rtbNote.Text;
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

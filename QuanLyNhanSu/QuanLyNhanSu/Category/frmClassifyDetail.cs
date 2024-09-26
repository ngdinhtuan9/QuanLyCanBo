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
    public partial class frmClassifyDetail : Form
    {
         public Classify classify;
        public Decimal classifyId = 0;
        public int maxClassifyId = 0;
        public bool succesed;
        public frmClassifyDetail()
        {
            InitializeComponent();
        }

        private void frmUnitDetail_Load(object sender, EventArgs e)
        {
            try
            {
                if (classify != null)
                {
                    txtLevelCode.Text = classify.Code;
                    txtLevel.Text = classify.Name;
                    rtbNote.Text = classify.Note;
                    classifyId = classify.Id;
                }
                else
                {
                    classify = new Classify();
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
                if (classify.Id == 0 && maxClassifyId >= 0)
                {
                    classify.Code = txtLevelCode.Text;
                    classify.Name = txtLevel.Text;

                    classify.Note = rtbNote.Text;
                    classify.Id = maxClassifyId + 1;
                    classifyId = classify.Id;
                }
                else
                {
                    classify.Code = txtLevelCode.Text;
                    classify.Name = txtLevel.Text;
                    classify.Note = rtbNote.Text;
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

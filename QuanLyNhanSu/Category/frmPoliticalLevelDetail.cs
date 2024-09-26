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
    public partial class frmPoliticalLevelDetail : Form
    {
         public PoliticalLevel politicalLevel;
        public int politicalLevelId = 0;
        public int maxLevelId = 0;
        public bool succesed;
        public frmPoliticalLevelDetail()
        {
            InitializeComponent();
        }

        private void frmUnitDetail_Load(object sender, EventArgs e)
        {
            try
            {
                if (politicalLevel != null)
                {
                    txtLevelCode.Text = politicalLevel.Code;
                    txtLevel.Text = politicalLevel.Name;
                  
                    rtbNote.Text = politicalLevel.Note;
                    politicalLevelId = politicalLevel.Id;
                }
                else
                {
                    politicalLevel = new PoliticalLevel();
                    txtLevelCode.Text = "";
                    txtLevel.Text = "";
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
                if (politicalLevel.Id == 0 && maxLevelId >= 0)
                {
                    politicalLevel.Code = txtLevelCode.Text;
                    politicalLevel.Name = txtLevel.Text;
                    politicalLevel.Note = rtbNote.Text;
                    politicalLevel.Id = maxLevelId + 1;
                    politicalLevelId = politicalLevel.Id;
                }
                else
                {
                    politicalLevel.Code = txtLevelCode.Text;
                    politicalLevel.Name = txtLevel.Text;
                    politicalLevel.Note = rtbNote.Text;
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

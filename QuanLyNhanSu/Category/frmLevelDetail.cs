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
    public partial class frmLevelDetail : Form
    {
         public Level level;
        public Decimal levelId = 0;
        public int maxLevelId = 0;
        public bool succesed;
        public frmLevelDetail()
        {
            InitializeComponent();
        }

        private void frmUnitDetail_Load(object sender, EventArgs e)
        {
            try
            {
                if (level != null)
                {
                    txtLevelCode.Text = level.Code;
                    txtLevel.Text = level.Name;
                  
                    rtbNote.Text = level.Note;
                    levelId = level.Id;
                }
                else
                {
                    level = new Level();
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
                if (level.Id == 0 && maxLevelId >= 0)
                {
                    level.Code = txtLevelCode.Text;
                    level.Name = txtLevel.Text;

                    level.Note = rtbNote.Text;
                    level.Id = maxLevelId + 1;
                    levelId = level.Id;
                }
                else
                {
                    level.Code = txtLevelCode.Text;
                    level.Name = txtLevel.Text;
                    level.Note = rtbNote.Text;
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

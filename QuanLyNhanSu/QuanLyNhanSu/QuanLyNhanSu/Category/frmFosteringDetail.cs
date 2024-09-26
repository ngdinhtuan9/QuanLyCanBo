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
    public partial class frmFosteringDetail : Form
    {
         public Fostering fostering;
        public Decimal fosteringId = 0;
        public int maxfosteringId = 0;
        public bool succesed;
        public frmFosteringDetail()
        {
            InitializeComponent();
        }

        private void frmUnitDetail_Load(object sender, EventArgs e)
        {
            try
            {
                if (fostering != null)
                {
                    txtLevelCode.Text = fostering.Code;
                    txtLevel.Text = fostering.Name;
                  
                    rtbNote.Text = fostering.Note;
                    fosteringId = fostering.Id;
                }
                else
                {
                    fostering = new Fostering();
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
                if (fostering.Id == 0 && maxfosteringId >= 0)
                {
                    fostering.Code = txtLevelCode.Text;
                    fostering.Name = txtLevel.Text;

                    fostering.Note = rtbNote.Text;
                    fostering.Id = maxfosteringId + 1;
                    fosteringId = fostering.Id;
                }
                else
                {
                    fostering.Code = txtLevelCode.Text;
                    fostering.Name = txtLevel.Text;
                    fostering.Note = rtbNote.Text;
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

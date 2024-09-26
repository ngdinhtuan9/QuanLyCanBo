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
    public partial class frmFosteringQPANDetail : Form
    {
         public FosteringQPAN fosteringQPAN;
        public Decimal fosteringQPANId = 0;
        public int maxfosteringQPANId = 0;
        public bool succesed;
        public frmFosteringQPANDetail()
        {
            InitializeComponent();
        }

        private void frmUnitDetail_Load(object sender, EventArgs e)
        {
            try
            {
                if (fosteringQPAN != null)
                {
                    txtLevelCode.Text = fosteringQPAN.Code;
                    txtLevel.Text = fosteringQPAN.Name;
                  
                    rtbNote.Text = fosteringQPAN.Note;
                    fosteringQPANId = fosteringQPAN.Id;
                }
                else
                {
                    fosteringQPAN = new FosteringQPAN();
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
                if (fosteringQPAN.Id == 0 && maxfosteringQPANId >= 0)
                {
                    fosteringQPAN.Code = txtLevelCode.Text;
                    fosteringQPAN.Name = txtLevel.Text;

                    fosteringQPAN.Note = rtbNote.Text;
                    fosteringQPAN.Id = maxfosteringQPANId + 1;
                    fosteringQPANId = fosteringQPAN.Id;
                }
                else
                {
                    fosteringQPAN.Code = txtLevelCode.Text;
                    fosteringQPAN.Name = txtLevel.Text;
                    fosteringQPAN.Note = rtbNote.Text;
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

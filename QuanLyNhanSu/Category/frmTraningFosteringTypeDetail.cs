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
    public partial class frmTraningFosteringTypeDetail : Form
    {
         public TraningFosteringType traningFosteringType;
        public Decimal traningFosteringTypeId = 0;
        public int maxTraningFosteringTypeId = 0;
        public bool succesed;
        public frmTraningFosteringTypeDetail()
        {
            InitializeComponent();
        }

        private void frmUnitDetail_Load(object sender, EventArgs e)
        {
            try
            {
                if (traningFosteringType != null)
                {
                    txtLevelCode.Text = traningFosteringType.Code;
                    txtLevel.Text = traningFosteringType.Name;
                    rtbNote.Text = traningFosteringType.Note;
                    traningFosteringTypeId = traningFosteringType.Id;
                }
                else
                {
                    traningFosteringType = new TraningFosteringType();
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
                if (traningFosteringType.Id == 0 && maxTraningFosteringTypeId >= 0)
                {
                    traningFosteringType.Code = txtLevelCode.Text;
                    traningFosteringType.Name = txtLevel.Text;

                    traningFosteringType.Note = rtbNote.Text;
                    traningFosteringType.Id = maxTraningFosteringTypeId + 1;
                    traningFosteringTypeId = traningFosteringType.Id;
                }
                else
                {
                    traningFosteringType.Code = txtLevelCode.Text;
                    traningFosteringType.Name = txtLevel.Text;
                    traningFosteringType.Note = rtbNote.Text;
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

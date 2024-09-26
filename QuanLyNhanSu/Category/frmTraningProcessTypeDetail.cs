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
    public partial class frmTraningProcessTypeDetail : Form
    {
         public TraningProcessType traningProcessType;
        public Decimal traningProcessTypeId = 0;
        public int maxTraningProcessTypeId = 0;
        public bool succesed;
        public frmTraningProcessTypeDetail()
        {
            InitializeComponent();
        }

        private void frmUnitDetail_Load(object sender, EventArgs e)
        {
            try
            {
                if (traningProcessType != null)
                {
                    txtLevelCode.Text = traningProcessType.Code;
                    txtLevel.Text = traningProcessType.Name;
                    rtbNote.Text = traningProcessType.Note;
                    traningProcessTypeId = traningProcessType.Id;
                }
                else
                {
                    traningProcessType = new TraningProcessType();
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
                if (traningProcessType.Id == 0 && maxTraningProcessTypeId >= 0)
                {
                    traningProcessType.Code = txtLevelCode.Text;
                    traningProcessType.Name = txtLevel.Text;

                    traningProcessType.Note = rtbNote.Text;
                    traningProcessType.Id = maxTraningProcessTypeId + 1;
                    traningProcessTypeId = traningProcessType.Id;
                }
                else
                {
                    traningProcessType.Code = txtLevelCode.Text;
                    traningProcessType.Name = txtLevel.Text;
                    traningProcessType.Note = rtbNote.Text;
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

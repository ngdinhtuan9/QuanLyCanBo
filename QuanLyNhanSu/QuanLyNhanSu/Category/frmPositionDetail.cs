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
    public partial class frmPositionDetail : Form
    {
         public Position position;
        public int positionId = 0;
        public int maxPositionId = 0;
        public bool succesed;
        public frmPositionDetail()
        {
            InitializeComponent();
        }

        private void frmUnitDetail_Load(object sender, EventArgs e)
        {
            try
            {
                if (position != null)
                {
                    txtCode.Text = position.Code;
                    txtName.Text = position.Name;
                  
                    rtbNote.Text = position.Note;
                    positionId = position.Id;
                }
                else
                {
                    position = new Position();
                    txtCode.Text = "";
                    txtName.Text = "";
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
                if (position.Id == 0 && maxPositionId >= 0)
                {
                    position.Code = txtCode.Text;
                    position.Name = txtName.Text;

                    position.Note = rtbNote.Text;
                    position.Id = maxPositionId + 1;
                    positionId = position.Id;
                }
                else
                {
                    position.Code = txtCode.Text;
                    position.Name = txtName.Text;
                    position.Note = rtbNote.Text;
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

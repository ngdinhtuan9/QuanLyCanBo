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
    public partial class frmTittleDetail : Form
    {
         public Tittle tittle;
        public Decimal tittleId = 0;
        public int maxTittleId = 0;
        public bool succesed;
        public frmTittleDetail()
        {
            InitializeComponent();
        }

        private void frmUnitDetail_Load(object sender, EventArgs e)
        {
            try
            {
                if (tittle != null)
                {
                    txtLevelCode.Text = tittle.Code;
                    txtLevel.Text = tittle.Name;
                  
                    rtbNote.Text = tittle.Note;
                    tittleId = tittle.Id;
                }
                else
                {
                    tittle = new Tittle();
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
                if (tittle.Id == 0 && maxTittleId >= 0)
                {
                    tittle.Code = txtLevelCode.Text;
                    tittle.Name = txtLevel.Text;

                    tittle.Note = rtbNote.Text;
                    tittle.Id = maxTittleId + 1;
                    tittleId = tittle.Id;
                }
                else
                {
                    tittle.Code = txtLevelCode.Text;
                    tittle.Name = txtLevel.Text;
                    tittle.Note = rtbNote.Text;
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

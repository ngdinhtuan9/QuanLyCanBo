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
    public partial class frmResponsibleDetail : Form
    {
         public Responsible responsible;
        public int responsibleId = 0;
        public int maxResponsibleId = 0;
        public bool succesed;
        public frmResponsibleDetail()
        {
            InitializeComponent();
        }

        private void frmUnitDetail_Load(object sender, EventArgs e)
        {
            try
            {
                if (responsible != null)
                {
                    txtCode.Text = responsible.Code;
                    txtName.Text = responsible.Name;
                    rtbNote.Text = responsible.Note;
                    responsibleId = responsible.Id;
                }
                else
                {
                    responsible = new Responsible();
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
                if (responsible.Id == 0 && maxResponsibleId >= 0)
                {
                    responsible.Code = txtCode.Text;
                    responsible.Name = txtName.Text;

                    responsible.Note = rtbNote.Text;
                    responsible.Id = maxResponsibleId + 1;
                    responsibleId = responsible.Id;
                }
                else
                {
                    responsible.Code = txtCode.Text;
                    responsible.Name = txtName.Text;
                    responsible.Note = rtbNote.Text;
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

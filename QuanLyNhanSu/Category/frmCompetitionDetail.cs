using QuanLyNhanSu.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;

namespace QuanLyNhanSu.Category
{
    public partial class frmCompetitionDetail : Form
    {
         public Competition competition;
        public Decimal competitionId = 0;
        public int maxCompetitionId = 0;
        public bool succesed;
        public frmCompetitionDetail()
        {
            InitializeComponent();
        }

        private void frmUnitDetail_Load(object sender, EventArgs e)
        {
            try
            {
                if (competition != null)
                {
                    txtLevelCode.Text = competition.Code;
                    txtLevel.Text = competition.Name;
                    rtbNote.Text = competition.Note;
                    competitionId = competition.Id;
                }
                else
                {
                    competition = new Competition();
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
                if (competition.Id == 0 && maxCompetitionId >= 0)
                {
                    competition.Code = txtLevelCode.Text;
                    competition.Name = txtLevel.Text;

                    competition.Note = rtbNote.Text;
                    competition.Id = maxCompetitionId + 1;
                    competitionId = competition.Id;
                }
                else
                {
                    competition.Code = txtLevelCode.Text;
                    competition.Name = txtLevel.Text;
                    competition.Note = rtbNote.Text;
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

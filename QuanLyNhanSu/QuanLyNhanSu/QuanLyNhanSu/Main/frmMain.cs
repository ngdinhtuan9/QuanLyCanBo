using QuanLyNhanSu.Category;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyNhanSu.Main
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            try
            {
                if (Common.glbUserName == "")
                {
                    var frmLogin = new frmLogin();
                    frmLogin.ShowDialog();
                    if (frmLogin.isLogin)
                    {
                        if (frmLogin.role == 1)
                        {
                            mnuSystem.Enabled = true;
                            mnuBussiness.Enabled = true;
                            mnuReport.Enabled = true;
                            MnuLists.Visible = true;
                        }
                        else if (frmLogin.role == 2)
                        {
                            mnuSystem.Enabled = true;
                            mnuBussiness.Enabled = true;
                            mnuReport.Enabled = true;
                            MnuLists.Visible = false;
                        }
                        else { }


                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void mnuRegister_Click(object sender, EventArgs e)
        {
            var frmCreateAcc = new frmCreateAccount();
            frmCreateAcc.ShowDialog();
        }

        private void mnuLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var frmLogin = new frmLogin();
                frmLogin.ShowDialog();
                if (frmLogin.isLogin)
                {
                    if (frmLogin.role == 1)
                    {
                        mnuSystem.Enabled = true;
                        mnuBussiness.Enabled = true;
                        mnuReport.Enabled = true;
                        MnuLists.Visible = true;
                    }
                    else if (frmLogin.role == 2)
                    {
                        mnuSystem.Enabled = true;
                        mnuBussiness.Enabled = true;
                        mnuReport.Enabled = true;
                        MnuLists.Visible = false;
                    }
                    else { }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
              
            }
           
        }

        private void mnuUnits_Click(object sender, EventArgs e)
        {
            try
            {
                frmUnits frmUnit = new frmUnits();
                frmUnit.TopLevel = false;
                pnPanelMain.Controls.Add(frmUnit);
                frmUnit.Location = new Point(
                   (pnPanelMain.Width - frmUnit.Width) / 2,
                   (pnPanelMain.Height - frmUnit.Height) / 2
               );
                frmUnit.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuLevel_Click(object sender, EventArgs e)
        {
            try
            {
                frmLevel frmLevel = new frmLevel();
                frmLevel.TopLevel = false;
                pnPanelMain.Controls.Add(frmLevel);
                frmLevel.Location = new Point(
                   (pnPanelMain.Width - frmLevel.Width) / 2,
                   (pnPanelMain.Height - frmLevel.Height) / 2
               );
                frmLevel.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuDepartment_Click(object sender, EventArgs e)
        {
            try
            {
                frmDepartment frmDep = new frmDepartment();
                frmDep.TopLevel = false;
                pnPanelMain.Controls.Add(frmDep);
                frmDep.Location = new Point(
                   (pnPanelMain.Width - frmDep.Width) / 2,
                   (pnPanelMain.Height - frmDep.Height) / 2
               );
                frmDep.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuPosition_Click(object sender, EventArgs e)
        {
            try
            {
                frmPosition frmDep = new frmPosition();
                frmDep.TopLevel = false;
                pnPanelMain.Controls.Add(frmDep);
                frmDep.Location = new Point(
                   (pnPanelMain.Width - frmDep.Width) / 2,
                   (pnPanelMain.Height - frmDep.Height) / 2
               );
                frmDep.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuAcademicLevel_Click(object sender, EventArgs e)
        {
            try
            {
                frmAcademicLevel frmDep = new frmAcademicLevel();
                frmDep.TopLevel = false;
                pnPanelMain.Controls.Add(frmDep);
                frmDep.Location = new Point(
                   (pnPanelMain.Width - frmDep.Width) / 2,
                   (pnPanelMain.Height - frmDep.Height) / 2
               );
                frmDep.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuResponsible_Click(object sender, EventArgs e)
        {
            try
            {
                frmResponsible frmDep = new frmResponsible();
                frmDep.TopLevel = false;
                pnPanelMain.Controls.Add(frmDep);
                frmDep.Location = new Point(
                   (pnPanelMain.Width - frmDep.Width) / 2,
                   (pnPanelMain.Height - frmDep.Height) / 2
               );
                frmDep.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void trìnhĐộLLCTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmPoliticalLevel frmDep = new frmPoliticalLevel();
                frmDep.TopLevel = false;
                pnPanelMain.Controls.Add(frmDep);
                frmDep.Location = new Point(
                   (pnPanelMain.Width - frmDep.Width) / 2,
                   (pnPanelMain.Height - frmDep.Height) / 2
               );
                frmDep.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            try
            {
                if (Common.glbUserName == "")
                {
                    var frmLogin = new Login();
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

            }
            
        }

        private void mnuRegister_Click(object sender, EventArgs e)
        {
            var frmCreateAcc = new frmCreateAccount();
            frmCreateAcc.ShowDialog();
        }

        private void mnuLogin_Click(object sender, EventArgs e)
        {
           
            var frmLogin = new Login();
            frmLogin.ShowDialog();
            if (frmLogin.isLogin)
            {
                if(frmLogin.role == 1) {
                    mnuSystem.Enabled = true;
                    mnuBussiness.Enabled = true;
                    mnuReport.Enabled = true;
                    MnuLists.Visible = true;
                }else if (frmLogin.role == 2)
                {
                    mnuSystem.Enabled = true;
                    mnuBussiness.Enabled = true;
                    mnuReport.Enabled = true;
                    MnuLists.Visible = false;
                } else { }
                    
                
            }
        }
       
    }
}

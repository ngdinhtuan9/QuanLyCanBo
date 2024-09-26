using QuanLyNhanSu.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyNhanSu
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Main.frmMainNew());
            //    // Application.Run(new Login());
            //Application.Run(new frmCreateAccount());
            //Application.Run(new frmUnits());
            //Application.Run(new frmLevel());
            //Application.Run(new frmDepartment());
            // Application.Run(new frmAcademicLevel());
            // Application.Run(new frmSchool());
            // Application.Run(new frmPosition());
            // Application.Run(new frmResponsible());
            //Application.Run(new frmPoliticalLevel());
             Application.Run(new frmPerson());
            // Application.Run(new frmChangePass());
            // Application.Run(new frmBackupData());
            // Application.Run(new frmRestoreData());
            //Application.Run(new frmFostering());
            //Application.Run(new frmFosteringQPAN());

        }
    }
}

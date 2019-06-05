using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using qlShop.models;
namespace qlShop
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //------------------------------------//
            //Utility.NguoiSuDung = new NguoiDung();
            //Utility.NguoiSuDung.NguoiDungID = "admin";
            //Utility.NguoiSuDung.TenNguoiDung = "quản lý";
            Application.Run(new frmLogin());
            //Application.Run(new frmMain());
            //frmLogin f = new frmLogin();
            //f.Show();
        }
    }
}

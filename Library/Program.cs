using System;
using System.Windows.Forms;

namespace Library
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            using (frmLogin login = new frmLogin())
            {
                if (login.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new frmMain(
                        login.MaNhanVienDangNhap,
                        login.HoTenDangNhap,
                        login.VaiTroDangNhap
                    ));
                }
            }
        }
    }
}
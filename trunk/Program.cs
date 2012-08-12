using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace APP
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LoginForm login = new LoginForm();
            DialogResult result = login.ShowDialog();
            if (login.CancelLogin)
            {
                return;
            }
            if (UserSession.LoginUser == null)
            {

            }
            else
            {
                Application.Run(new MainForm());
            }
        }
    }
}

using SelesApp.DB;
using SelesApp.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SelesApp
{
    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SelesAppEntities db = new SelesAppEntities();
           

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                var result = db.Users.ToList();
                if (result.Count > 0)
                    Application.Run(new FrmLogin());
                else
                    Application.Run(new FrmStart());

            }
            catch
            {
                Application.Run(new FrmStart());
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TWSL.Common;
using TWSL.Forms.history;
using TWSL.Forms.main;
using TWSL.Forms.master;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace TWSL
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
            // init SL
            ImportData.InitSL();
            //Application.Run(new FromMasterWH());

            //AppData.Instance.CurrentUserName = "Admin";

            //Application.Run(new HOME());

            //Application.Run(new HOME());
            //Application.Run(new FromMasterWH());

            Application.Run(new login());



        }
    }
}

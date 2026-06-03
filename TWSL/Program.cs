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
            //Application.Run(new login());



            //Application.Run(new HOME());
            //Application.Run(new FromMasterWH());

            Application.Run(new login());



            // gọi from đăng kí
            //string id_ = "1"; // Example user ID, replace with actual logic to get user ID
            //string username_ = "Thang Quang Lợi"; // Example username, replace with actual logic to get username
            //string role_ = "manager"; // Example role, replace with actual logic to get user role
            //Application.Run(new register_user(id_ , username_));
            //Application.Run(new user_ma(id_, username_));

            //Application.Run(new main_from(id_, username_,role_, "1"));

            //Application.Run(new from_master(id_, username_, role_));

            //Application.Run(new chage_pasword(User_id, user_password));

            //string item = "ABC123"; // Example item, replace with actual logic to get item
            //string lot = "LOT456"; // Example lot, replace with actual logic to get lot
            //Application.Run(new input_from(item,lot));

            //Application.Run(new tra_cuu_log(username_));
            //Application.Run(new his_master());

            //Application.Run(new his_info_users());

            //Application.Run(new input_data());
        }
    }
}

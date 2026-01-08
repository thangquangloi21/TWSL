using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWSL.Common
{
    public class AppData
    {
        private static AppData _instance;
        public static AppData Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AppData();
                return _instance;
            }
        }
        //user info
        public string CurrentUserId { get; set; }
        public string CurrentUserName { get; set; }
        public string CurrentProdLine { get; set; }
        public string CurrentPassw { get; set; }
         public string NewPassw { get; set; }
        public string CurrentRole { get; set; }
        public string CurrentEnv { get; set; }

        //kết nối db
        public string ConnectionString { get; set; }




        private AppData() { } // Ngăn tạo đối tượng bên ngoài
    }
}

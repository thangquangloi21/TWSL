using System;
using System.Collections.Generic;
using System.Data;
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
        // prod
        //public string DBSL = "Server=10.239.1.162;Database=TWSL;User Id=loi_tq;Password=249533;";
        //public string DBGS1 = "Server=10.239.1.162;Database=DB_GS1_GenIII;User Id=loi_tq;Password=249533;";

        //test
        public string DBGS1 = "Server=10.239.1.162;Database=DB_GS1_GenIII;User Id=loi_tq;Password=249533;";
        public string DBSL = "Server=10.239.1.54;Database=TWSL;User Id=sa;Password=123456;";
        public string SAPDWH = "Server=10.239.1.54;Database=DB_SAP_DWH;User Id=sa;Password=123456; ";

        //HOME
        //public string DBGS1 = "Server=10.239.2.58;Database=DB_GS1_GenIII;User Id=loitq;Password=249533;";
        //public string DBSL = "Server=10.239.2.58;Database=TWSL;User Id=loitq;Password=249533;";
        //public string SAPDWH = "Server=10.239.2.58;Database=DB_SAP_DWH;User Id=loitq;Password=249533;";



        //user info
        public string CurrentUserId { get; set; }
        public string CurrentUserName { get; set; }
        public string CurrentProdLine { get; set; }
        public string CurrentPassw { get; set; }
         public string NewPassw { get; set; }
        public string CurrentRole { get; set; }
        public string CurrentEnv { get; set; }

        public string NhomQuyen { get; set; }

        public DataTable Permission { get; set; }


        //kết nối db
        public string ConnectionString { get; set; }

        // version app
        public string AppVersion { get; set; }
        
       
        //SL
        public string GenYearBatch { get; set; }
        public string Batch { get; set; }
        public string MachineNo { get; set; }

        private AppData() { } // Ngăn tạo đối tượng bên ngoài
    }
}

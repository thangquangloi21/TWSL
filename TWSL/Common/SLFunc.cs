using Org.BouncyCastle.Crypto.IO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Windows.Forms.LinkLabel;

namespace TWSL.Common
{
    internal class SLFunc
    {

        public static void InitSL()
        {
            AppData.Instance.GenYearBatch = GetBatchYear();
        }
        public static string GetBatchYear()
        {
            string year = DateTime.Now.ToString("yy");
            return year+="EO -";
        }

        public static string getyearsave()
        {
            string year = DateTime.Now.ToString("yy");
            return year += "EO-";
        }

        public static string getmachine_no(string bathNo) {
            return bathNo.Substring(0, bathNo.Length - 3); 
        }

        public static void InsertDataBatchNo(string batchNo, string productCode, string line, string lot, string quantity, string machine, string id_user, string name, string note, string time)
        {
            string insertQuery = "insert [InfoBatchNoF12] ([BatchNo] ,[ItemCode] ,[ProdLine] ,[ProdLot] ,[Quantity] ,[Machine] ,[DateTime]) " +
                "values (@batch_no, @item_code, @product_line, @lot, @quantity, @machine_no, @inp_time)";
            
            string insertQuery2 = "insert [TrInfoBatchNoF12] ([BatchNo] ,[ItemCode] ,[ProdLine] ,[ProdLot] ,[Quantity] ,[Machine],[DateTime], [IdUser], [NameUser]  ,[note]) " +
                "values (@batch_no, @item_code, @product_line, @lot, @quantity, @machine_no, @inp_time, @id_user, @name, @note)";
            // Tạo mảng SqlParameter để tránh SQL Injection
            SqlParameter[] parameters = new SqlParameter[]
            {
                    new SqlParameter("@batch_no", batchNo),
                    new SqlParameter("@item_code", productCode),
                    new SqlParameter("@product_line", line),
                    new SqlParameter("@lot", lot),
                    new SqlParameter("@quantity", quantity),
                    new SqlParameter("@machine_no", machine),
                    new SqlParameter("@inp_time", time)
  
   
            };
            SqlParameter[] parameters1 = new SqlParameter[]
            {
                    new SqlParameter("@batch_no", batchNo),
                    new SqlParameter("@item_code", productCode),
                    new SqlParameter("@product_line", line),
                    new SqlParameter("@lot", lot),
                    new SqlParameter("@quantity", quantity),
                    new SqlParameter("@machine_no", machine),
                    new SqlParameter("@inp_time", time),
                    new SqlParameter("@id_user", id_user),
                    new SqlParameter("@name", name),
                    new SqlParameter("@note", note)

            };

            DatabaseHelper.ExecuteNonQuery(insertQuery, parameters);
            DatabaseHelper.ExecuteNonQuery(insertQuery2, parameters1);
        }



    }
}

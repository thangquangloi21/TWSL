using Org.BouncyCastle.Crypto.IO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
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
            string insertQuery = "insert [InfoBatchNoF12] ([BatchNo] ,[ItemCode] ,[ProdLine] ,[ProdLot] ,[Quantity] ,[Machine] ,[DateTime], [NameUser], [Status]) " +
                "values (@batch_no, @item_code, @product_line, @lot, @quantity, @machine_no, @inp_time, @name, @status)";
            
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
                    new SqlParameter("@inp_time", time),
                    new SqlParameter("@name", name),
                    new SqlParameter("@status", "Tạo thành công"),



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


        public static int GetTgtk(string item, string lot, string machine)
        {
            int kq = 0;

            // Kiểm tra độ dài lot để tránh lỗi IndexOutOfRangeException
            if (string.IsNullOrEmpty(lot) || lot.Length <= 6) return 0;

            string typelot = lot[6].ToString(); // Ép kiểu string ở đây luôn cho gọn

            // Query nên filter thêm machine để giảm tải dữ liệu lấy về RAM
            var gettime = "SELECT * FROM MASTERF12 WHERE status_item = '1' AND itemcode = @item";
            SqlParameter[] para1 = { new SqlParameter("@item", item) };

            DataTable data1 = DatabaseHelper.ExecuteQuery(gettime, para1);

            foreach (DataRow row1 in data1.Rows)
            {
                string dbMachine = row1["machine"].ToString();
                string dbLot = row1["lot"].ToString();

                // Kiểm tra khớp cả Machine và Loại Lot
                if (dbMachine == machine && dbLot == typelot)
                {
                    kq = Convert.ToInt32(row1["Degassing_time"]); // Giả sử tên cột là tg_dang_ky
                    return kq; // Tìm thấy đúng máy này thì thoát luôn
                }

                // Nếu không khớp machine nhưng khớp Lot (Trường hợp dùng chung cho các máy)
                if (dbMachine == "" && dbLot == typelot)
                {
                    kq = Convert.ToInt32(row1["Degassing_time"]);
                }
                if (dbMachine == machine && dbLot == "")
                {
                    kq = Convert.ToInt32(row1["Degassing_time"]);
                }
            }
            return kq;
        }

        // lấy dữ liệu mẻ tt 
        public static DataTable GetDataTT(string batchNo)
        {
            string sql = "SELECT * FROM InfoBatchNoF12 WHERE BatchNo = @batchNo ORDER BY DateTime DESC";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@batchNo", batchNo)
            };
            DataTable result = DatabaseHelper.ExecuteQuery(sql, parameters);
            return result;
        }

        public static string TaoSoPhieu()
        {
            string year = DateTime.Now.ToString("yy");
            string month = DateTime.Now.ToString("MM");
            var sql = @"
            ;WITH NextNo AS (
            SELECT RIGHT('000' + CAST(COALESCE(MAX(CAST(SoPhieu AS int)), 0) + 1 AS varchar(3)), 3) AS SoPhieuMoi
            FROM BangSophieu WITH (UPDLOCK, HOLDLOCK)
            WHERE Nam = @Nam AND Thang = @Thang
            )
            INSERT INTO BangSophieu (SoPhieu, Nam, Thang)
            OUTPUT inserted.SoPhieu
            SELECT SoPhieuMoi, @Nam, @Thang
            FROM NextNo;";
            var p = new SqlParameter[]
            {
            new SqlParameter("@Nam",   year),
            new SqlParameter("@Thang", month)
            };

            // Dùng ExecuteQuery để lấy DataTable chứa kết quả từ OUTPUT
            DataTable dt = DatabaseHelper.ExecuteQuery(sql, p);
            string soPhieuMoi = dt.Rows[0][0].ToString();

            return $"NKTD-TIS-{year}{month}-{soPhieuMoi}";
        }

    }
}

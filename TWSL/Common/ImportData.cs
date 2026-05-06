using Org.BouncyCastle.Crypto.IO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using TWSL.Forms.main;
using TWSL.Services;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TWSL.Common
{
    internal class ImportData
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
            // lấy 1 đến 2 số từ dấu - và 3 số cuối ví dụ  26EO-12123 thì lấy 12
            int dashIndex = bathNo.IndexOf('-');
            if (dashIndex < 0 || dashIndex >= bathNo.Length - 1) return "";
            string afterDash = bathNo.Substring(dashIndex + 1);
            if (afterDash.Length <= 3) return "";   
            return afterDash.Substring(0, afterDash.Length - 3);
        }

        public static string getproductcode(string sapcode)
        {
            try
            {
                string Query = "SELECT [MANUFACTURER_PART_NUMBER] FROM [DB_SAP_DWH].[dbo].[V_MATERIAL_MASTER_DATA] WHERE MATERIAL_CODE = @sapcode";
                SqlParameter[] parameters = new SqlParameter[]
                {
                new SqlParameter("@sapcode", sapcode)
                };
                DataTable dt = cnn_dwhsap.ExecuteQuery(Query, parameters);
                string MESCODE = dt.Rows[0][0].ToString();
                if (dt is null || dt.Rows.Count == 0)
                {
                    return "Null";
                }
                    return MESCODE;
            }
            catch { 
            return "Null";
            }
            
            
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
        public static DataTable GetDataTT(string MaSp , string LotSp)
        {
            string sql = "SELECT [SoMeTT] as 'Số Mẻ' ,[MaSP] as 'Tên Sản Phẩm' ,[LotSP] as 'Lot' ,[SoLuongSP] as 'Số Lượng' ,[MayTT] as 'Máy' , pl.Qty as 'Max/Pallet'  ,[TrangThai] 'Trạng thái' , [NgayGioUpload] as 'Thời gian' " +
                 "FROM [TWSL].[dbo].[ImportData] dt  " +
                 "Left join [TWSL].[dbo].[users] u on dt.IdUser = u.id " +
                 "left join QtyStandPalet as pl on dt.MaSP = pl.ItemCode " +
                 "where MaSP = @masp and LotSP =  @Lotsp ";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@masp", MaSp),
                new SqlParameter("@Lotsp", LotSp)
            };
            DataTable result = DatabaseHelper.ExecuteQuery(sql, parameters);
            // 1) Thêm cột mới (ví dụ cột "Ghi chú") kiểu string, đặt vị trí cuối bảng
            if (!result.Columns.Contains("Thời gian thoát khí"))
                result.Columns.Add(new DataColumn("Thời gian thoát khí", typeof(string)));
            if (!result.Columns.Contains("Nội Dung"))
                result.Columns.Add(new DataColumn("Nội Dung", typeof(string)));
            // 2) Gán giá trị mặc định cho tất cả dòng (tuỳ bạn thay logic)
            foreach (DataRow row in result.Rows)
            {
                //kiểm tra xem code lot này đã tạo phiếu chưa
                if (TaoPhieu.CheckPhieuDaTao(row["Tên Sản Phẩm"].ToString(), row["Lot"].ToString())) {
                    row["Thời gian thoát khí"] = "0";
                }
                else
                {
                    row["Thời gian thoát khí"] = ImportData.GetTgtk(row["Tên Sản Phẩm"].ToString(), row["Lot"].ToString(), row["Máy"].ToString()); // hoặc tính toán theo từng dòng
                }
                // Ví dụ tính toán: row["Ghi chú"] = (row["Số Lượng"] == DBNull.Value) ? "" : "OK";
            }

            // Sắp xếp thứ tự cột hiển thị
            var columnOrder = new[]
            {
                "Số Mẻ",
                "Tên Sản Phẩm",
                "Lot",
                "Số Lượng",
                "Máy",
                "Thời gian thoát khí",
                "Max/Pallet",
                "Trạng thái",
                "Thời gian",
                "Nội Dung"
            };
            for (int i = 0; i < columnOrder.Length; i++)
            {
                if (result.Columns.Contains(columnOrder[i]))
                    result.Columns[columnOrder[i]].SetOrdinal(i);
            }
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


        private static DateTime ParseDateTimeFlexible(string input)
        {
            if (DateTime.TryParse(input, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime result))
                return result;
            if (DateTime.TryParse(input, new System.Globalization.CultureInfo("vi-VN"), System.Globalization.DateTimeStyles.None, out result))
                return result;
            if (DateTime.TryParse(input, System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None, out result))
                return result;
            throw new FormatException($"Không thể parse ngày giờ: '{input}'");
        }

        public static void InsertSL(string soMe, string maSP, string MaSAP, string LotSP, string SoLuong,string MayTT, string NgayPost,string NgayGioUpLoad, string IdUser, string Status)
        {
            //data: soMe, maSP, MaSAP, LotSP, SoLuong, MayTT, NgayPost, NgayGioUpLoad, IdUser, Status
            string insertQuery = "insert [ImportData] ([SoMeTT],[MaSP] ,[MaSAP] ,[LotSP] ,[SoLuongSP] ,[MayTT] ,[ThoiGianPost] ,[NgayGioUpload] ,[IdUser] ,[TrangThai]) " +
                "values (@soMe, @maSP, @MaSAP, @LotSP, @SoLuong, @MayTT, @NgayPost, @NgayGioUpLoad, @IdUser, @Status)";

            //transection
            //string insertQuery2 = "insert [Tr_ImportData] ([BatchNo] ,[ItemCode] ,[ProdLine] ,[ProdLot] ,[Quantity] ,[Machine],[DateTime], [IdUser], [NameUser]  ,[note]) " +
            //    "values (@batch_no, @item_code, @product_line, @lot, @quantity, @machine_no, @inp_time, @id_user, @name, @note)";
            // Tạo mảng SqlParameter để tránh SQL Injection
            SqlParameter[] parameters = new SqlParameter[]
            {
                    new SqlParameter("@soMe", soMe),
                    new SqlParameter("@maSP", maSP),
                    new SqlParameter("@MaSAP", MaSAP),
                    new SqlParameter("@LotSP", LotSP),
                    new SqlParameter("@SoLuong", SoLuong),
                    new SqlParameter("@MayTT", MayTT),
                    new SqlParameter("@NgayPost", SqlDbType.Date) { Value = ParseDateTimeFlexible(NgayPost).Date },
                    new SqlParameter("@NgayGioUpLoad", SqlDbType.DateTime) { Value = ParseDateTimeFlexible(NgayGioUpLoad) },
                    new SqlParameter("@IdUser", IdUser),
                    new SqlParameter("@Status", Status),

            };

            //SqlParameter[] parameters1 = new SqlParameter[]
            //{
            //        new SqlParameter("@batch_no", batchNo),
            //        new SqlParameter("@item_code", productCode),
            //        new SqlParameter("@product_line", line),
            //        new SqlParameter("@lot", lot),
            //        new SqlParameter("@quantity", quantity),
            //        new SqlParameter("@machine_no", machine),
            //        new SqlParameter("@inp_time", time),
            //        new SqlParameter("@id_user", id_user),
            //        new SqlParameter("@name", name),
            //        new SqlParameter("@note", note)

            //};

            //data
            DatabaseHelper.ExecuteNonQuery(insertQuery, parameters);
            //transection
            //DatabaseHelper.ExecuteNonQuery(insertQuery2, parameters1);
        }



    public static int CheckMeTT(string MeTT, string ItemCode , string Lot)
        {
            string insertQuery = @"select SoMeTT from [ImportData] where SoMeTT = @BatchNo and  MaSAP = @ItemCode and LotSP = @ProdLot";
            var parameters = new List<SqlParameter>
        {
        new SqlParameter("@BatchNo", MeTT),
        new SqlParameter("@ItemCode", ItemCode),
        new SqlParameter("@ProdLot", Lot)
        };
            DataTable dt = DatabaseHelper.ExecuteQuery(insertQuery, parameters.ToArray());
            //MessageBox.Show($"{dt}");
            if (dt.Rows.Count != 0)
            {
                //Console.WriteLine("OK");
                return 1;
            }
            //Console.WriteLine("NG");
            return 0;
            
        }

    public static DataTable GetData()
        {
            string sql = "SELECT TOP (1000) [SoMeTT] ,[MaSP] ,[LotSP] ,[SoLuongSP] ,[MayTT] ,[ThoiGianPost] ,[NgayGioUpload] ,u.username  ,[TrangThai] FROM [TWSL].[dbo].[ImportData] dt  Left join [TWSL].[dbo].[users] u on dt.IdUser = u.id";
            DataTable result = DatabaseHelper.ExecuteQuery(sql);
            return result;
        }
    }
}

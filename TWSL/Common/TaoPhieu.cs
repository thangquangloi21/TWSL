using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TWSL.Forms.main;

namespace TWSL.Common
{
    internal class TaoPhieu
    {
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

            DataTable dt = DatabaseHelper.ExecuteQuery(sql, p);
            string soPhieuMoi = dt.Rows[0][0].ToString();

            return $"NKTD-TIS-{year}{month}-{soPhieuMoi}";
        }

        public static void TaoVaLuuPhieu(DataTable data)
        {
            try
            {
                if (data == null || data.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để tạo phiếu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string soPhieu = TaoSoPhieu();
                string idNguoiLap = AppData.Instance.CurrentUserId;
                string thoiGianLap = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string sql = @"INSERT INTO [TaoPhieu] 
                            ([SoPhieu],[SoMeTT],[MaSP],[LotSP],[SoLuong],[MayTT],[ThoiGianThoatKhi],[MaxPallet],[IdNguoiLap],[ThoiGianLap],[Note])
                           VALUES 
                            (@SoPhieu,@SoMeTT,@MaSP,@LotSP,@SoLuong,@MayTT,@ThoiGianThoatKhi,@MaxPallet,@IdNguoiLap,@ThoiGianLap,@Note)";

                foreach (DataRow row in data.Rows)
                {
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                    new SqlParameter("@SoPhieu",          soPhieu),
                    new SqlParameter("@SoMeTT",           row["Số Mẻ"]?.ToString()               ?? ""),
                    new SqlParameter("@MaSP",             row["Tên Sản Phẩm"]?.ToString()        ?? ""),
                    new SqlParameter("@LotSP",            row["Lot"]?.ToString()                  ?? ""),
                    new SqlParameter("@SoLuong",          row["Số Lượng"]?.ToString()            ?? ""),
                    new SqlParameter("@MayTT",            row["Máy"]?.ToString()                  ?? ""),
                    new SqlParameter("@ThoiGianThoatKhi", row["Thời gian thoát khí"]?.ToString() ?? ""),
                    new SqlParameter("@MaxPallet",        row["Max/Pallet"]?.ToString()           ?? ""),
                    new SqlParameter("@IdNguoiLap",       idNguoiLap),
                    new SqlParameter("@ThoiGianLap",      thoiGianLap),
                    new SqlParameter("@Note",             row["Nội Dung"]?.ToString() ?? ""),
                    };
                    DatabaseHelper.ExecuteNonQuery(sql, parameters);
                    CapNhatTrangThaiMe(row["Số Mẻ"]?.ToString() ?? "", "Tạo Phiếu");
                }
                //cập nhật trạng thái của các mẻ đã chọn
                CapNhatTrangThaiMe(data.Rows[0]["Số Mẻ"]?.ToString(), "Tạo Phiếu");
                MessageBox.Show($"Tạo phiếu {soPhieu} thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo phiếu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void CapNhatTrangThaiMe(string some, string trangthai)
        {
            try
            {
                var sql = "update [ImportData] set TrangThai = @TrangThai where SoMeTT = @Some ";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@TrangThai", trangthai),
                    new SqlParameter("@Some", some)
                };
                DatabaseHelper.ExecuteNonQuery(sql, parameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật trạng thái mẻ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public static bool CheckPhieuDaTao(string MaSP, string LotSP)
        {
            try
            {
                var sql = "SELECT [SoPhieu] FROM [TWSL].[dbo].[TaoPhieu] where MaSP = @masp and LotSP = @LotSP";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@masp", MaSP),
                    new SqlParameter("@LotSP", LotSP)
                };
                var dt = DatabaseHelper.ExecuteQuery(sql, parameters);
                // nếu có kết quả thì đã tồn tại
                if (dt.Rows.Count > 0)
                {
                    //MessageBox.Show($"Phiếu cho sản phẩm {MaSP} và lot {LotSP} đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi kiểm tra phiếu đã tạo: {ex.Message}");
            }
            return false;
        }

        public static DataTable LoadPhieu()
        {
            try
            {
                var sql = "SELECT TOP (1000) [SoPhieu] ,[SoMeTT] ,[MaSP] ,[LotSP] ,[SoLuong] ,[MayTT] ,[ThoiGianThoatKhi] ,[MaxPallet] ,u.username ,[ThoiGianLap] ,[Note] FROM [TWSL].[dbo].[TaoPhieu] left join users u on IdNguoiLap = u.id ";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@soPhieu", "")
                };
                var dt = DatabaseHelper.ExecuteQuery(sql, parameters);
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi load phiếu: {ex.Message}");
            }
            return null;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TWSL.Common
{
    internal class NhapKho
    {
        public static bool CheckSoPhieu(string soPhieu)
        {
            try
            {
                var sql = "SELECT [SoPhieu] FROM [TWSL].[dbo].[TaoPhieu] where SoPhieu = @SoPhieu";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@SoPhieu", soPhieu)
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


        public static string CheckPhieu(string soPhieu)
        {
            try
            {
                var sql = "SELECT * FROM [TWSL].[dbo].[TaoPhieu] where SoPhieu = @SoPhieu";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@SoPhieu", soPhieu)
                };
                var dt = DatabaseHelper.ExecuteQuery(sql, parameters);

                // nếu có kết quả thì đã tồn tại
                if (dt.Rows.Count > 0)
                {
                    var row = dt.Rows[0];
            
                    // Kiểm tra xem cột Note có dữ liệu không
                    bool hasNote = row["Note"] != DBNull.Value && !string.IsNullOrWhiteSpace(row["Note"].ToString());
    
                    // Kiểm tra thời gian thoát khí = 0
                    bool exitTimeIsZero = Convert.ToInt32(row["ThoiGianThoatKhi"]) == 0;
    
                    // Nếu có Note Hoặc thời gian thoát khí = 0
                    if (hasNote || exitTimeIsZero)
                    {
                        return "chuyenkhoc";
                    }
                }

                return "pass";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi kiểm tra phiếu đã tạo: {ex.Message}");
            }
            return "loi";
        }

        public static bool CheckDaTaoChua(string Sophieu)
        {
            try
            {
                var sql = "SELECT [SoPhieu] FROM [TaoFileNhapKho] where SoPhieu = @SoPhieu";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@SoPhieu", Sophieu)
                };
                var dt = conn_db_gs1.ExecuteQuery(sql, parameters);

                // nếu có kết quả thì đã tồn tại
                if (dt.Rows.Count > 0)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi kiểm tra phiếu đã tạo: {ex.Message}");
                return false;
            }   
        }

        public static DataTable GetItemName(string Gs1Code) {
            try
            {
                var sql = "SELECT [category] ,[itemCode] FROM [ItemMaster] where cartonBox = @cartonBox";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@cartonBox", Gs1Code)
                };
                var dt = conn_db_gs1.ExecuteQuery(sql, parameters);

                // nếu có kết quả thì đã tồn tại
                if (dt.Rows.Count > 0)
                {
                    return dt;
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi kiểm tra phiếu đã tạo: {ex.Message}");
                return null;
            }  
        }
        public static void InsertdataNhapKho(string STT, string SoPhieu, string MaPalet, string SoMeTietTrung, string MaSanPham, string BoPhan, string LotSanPham, string SoLuong, string ThoiGianThoatKhi, string KhoThoatKhi, string NguoiTao)
        {
            try
            {
             
            string sql = @"
    INSERT INTO [TWSL].[dbo].[TaoFileNhapKho]
    (
        STT,
        SoPhieu,
        MaPalet,
        SoMeTietTrung,
        MaSanPham,
        BoPhan,
        LotSanPham,
        SoLuong,
        ThoiGianThoatKhi,
        KhoThoatKhi,
        NguoiTao,
        ThoiGianTao
    )
    VALUES
    (
        @STT,
        @SoPhieu,
        @MaPalet,
        @SoMeTietTrung,
        @MaSanPham,
        @BoPhan,
        @LotSanPham,
        @SoLuong,
        @ThoiGianThoatKhi,
        @KhoThoatKhi,
        @NguoiTao,
        GETDATE()
    )";

        SqlParameter[] parameters = {
            new SqlParameter("@STT", STT.Trim()),
            new SqlParameter("@SoPhieu", SoPhieu.Trim()),
            new SqlParameter("@MaPalet", MaPalet.Trim()),
            new SqlParameter("@SoMeTietTrung", SoMeTietTrung.Trim()),
            new SqlParameter("@MaSanPham", MaSanPham.Trim()),
            new SqlParameter("@BoPhan", BoPhan.Trim()),
            new SqlParameter("@LotSanPham", LotSanPham.Trim()),
            new SqlParameter("@SoLuong", SoLuong.Trim()),
            new SqlParameter("@ThoiGianThoatKhi", ThoiGianThoatKhi.Trim()),
            new SqlParameter("@KhoThoatKhi", KhoThoatKhi.Trim()),
            new SqlParameter("@NguoiTao", NguoiTao.Trim())

        };

        DatabaseHelper.ExecuteNonQuery(sql, parameters);
                


            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi kiểm tra phiếu đã tạo: {ex.Message}");
            }
        }


        public static DataTable LoadDataDatao(string sophieu, string idnguoitao, string ngayTao)
        {
            try
            {
                var sql = @"SELECT
    f.SoPhieu AS 'Số Phiếu',
    MAX(f.SoMeTietTrung) AS 'Số Mẻ Tiệt Trùng',
    MAX(f.MaSanPham) AS 'Mã Sản Phẩm',
    MAX(f.BoPhan) AS 'Bộ Phận',
    MAX(f.LotSanPham) AS 'Lot',
    SUM(f.SoLuong) AS 'Số Lượng',
    MAX(f.ThoiGianThoatKhi) AS 'Thời Gian Thoát Khí',
    MAX(f.KhoThoatKhi) AS 'Kho Thoát Khí',
    MAX(usr.username) AS 'Người Tạo',
    MAX(f.ThoiGianTao) AS 'Thời Gian Tạo'
FROM TaoFileNhapKho f
LEFT JOIN users usr
    ON f.NguoiTao = usr.ID
WHERE CAST(f.ThoiGianTao AS date) = @NgayTao ";
                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@NgayTao", ngayTao)
                };
                if (!string.IsNullOrEmpty(sophieu))
                {
                    sql += "AND f.SoPhieu = @sophieu";
                    parameters.Add(new SqlParameter("@sophieu", sophieu));
                }
                if (!string.IsNullOrEmpty(idnguoitao))
                {
                    sql += "AND f.NguoiTao = @idnguoitao";
                    parameters.Add(new SqlParameter("@idnguoitao", idnguoitao));
                }


                sql += "GROUP BY f.SoPhieu ORDER BY MAX(f.ThoiGianTao) DESC ";
                var dt = DatabaseHelper.ExecuteQuery(sql, parameters.ToArray());

                // nếu có kết quả tồn tại
                if (dt.Rows.Count > 0)
                {
                    return dt;
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi load dữ liệu đã tạo: {ex.Message}");
                return null;
            }

        }
        public static DataTable TaoFileCSV(string soPhieu) {
            try
            {
                var sql = @"SELECT 
      [MaPalet],
      [SoMeTietTrung],
      [MaSanPham],
      [BoPhan],
      [LotSanPham],
      [SoLuong],
      CASE WHEN [KhoThoatKhi] = 'A' THEN [ThoiGianThoatKhi] ELSE 0 END AS [A],
      CASE WHEN [KhoThoatKhi] = 'B' THEN [ThoiGianThoatKhi] ELSE 0 END AS [B],
      CASE WHEN [KhoThoatKhi] = 'C' THEN [ThoiGianThoatKhi] ELSE 0 END AS [C]
FROM [TWSL].[dbo].[TaoFileNhapKho]
WHERE [SoPhieu] = @SoPhieu;";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@SoPhieu", soPhieu)
                };
                var dt = DatabaseHelper.ExecuteQuery(sql, parameters);

                // nếu có kết quả tồn tại
                if (dt.Rows.Count > 0)
                {
                    return dt;
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi load dữ liệu đã tạo: {ex.Message}");
                return null;
            }




        }

       


    }



}

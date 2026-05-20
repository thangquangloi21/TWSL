using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


    }



}

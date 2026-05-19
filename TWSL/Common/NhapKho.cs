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


    }



}

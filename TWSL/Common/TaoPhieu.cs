using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TWSL.Forms.main;
using ZXing;
using ZXing.Common;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
// ✅ PHẦN IN (KHÔNG dùng printto nữa)
using Excel = Microsoft.Office.Interop.Excel;

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
                    new SqlParameter("@SoMeTT",           row["Số Mẻ"]?.ToString()?? ""),
                    new SqlParameter("@MaSP",             row["Tên Sản Phẩm"]?.ToString()?? ""),
                    new SqlParameter("@LotSP",            row["Lot"]?.ToString()?? ""),
                    new SqlParameter("@SoLuong",          row["Số Lượng"]?.ToString()?? ""),
                    new SqlParameter("@MayTT",            row["Máy"]?.ToString()?? ""),
                    new SqlParameter("@ThoiGianThoatKhi", row["Thời gian thoát khí"]?.ToString()?? ""),
                    new SqlParameter("@MaxPallet",        row["Max/Pallet"]?.ToString()?? ""),
                    new SqlParameter("@IdNguoiLap",       idNguoiLap),
                    new SqlParameter("@ThoiGianLap",      thoiGianLap),
                    new SqlParameter("@Note",             row["Nội Dung"]?.ToString()?? ""),
                    };
                    DatabaseHelper.ExecuteNonQuery(sql, parameters);
                    CapNhatTrangThaiMe(row["Số Mẻ"]?.ToString() ?? "", "Tạo Phiếu");
                    ImportData.InsertHistory(row["Tên Sản Phẩm"]?.ToString() ?? "", row["Lot"]?.ToString() ?? "", row["Số Mẻ"]?.ToString() ?? "", soPhieu, row["Số Lượng"]?.ToString() ?? "", AppData.Instance.CurrentUserId, "Tạo Phiếu");
                }
                //cập nhật trạng thái của các mẻ đã chọn
                
                CapNhatTrangThaiMe(data.Rows[0]["Số Mẻ"]?.ToString(), "Tạo Phiếu");
                Logger.Log("INFO", $"{AppData.Instance.CurrentUserName} Tạo phiếu {soPhieu} {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
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

       

        public static DataTable LoadPhieu(string item, string lot, string ngaytaoFrom, string ngaytaoTo)
        {
            try
            {
                var sql = @"
            SELECT TOP (1000)
                p.[SoPhieu],
                p.[SoMeTT],
                p.[MaSP],
                p.[LotSP],
                p.[SoLuong],
                p.[MayTT],
                p.[ThoiGianThoatKhi],
                p.[MaxPallet],
                u.username AS NguoiLap,
                p.[ThoiGianLap],
                p.[Note],
                p.[SoLanIn]
            FROM [TWSL].[dbo].[TaoPhieu] p
            LEFT JOIN [users] u ON p.IdNguoiLap = u.id
            WHERE p.ThoiGianLap >= @TuNgay
              AND p.ThoiGianLap < DATEADD(DAY, 1, @DenNgay)
        ";

                var parameters = new List<SqlParameter>
        {
            new SqlParameter("@TuNgay", ngaytaoFrom),
            new SqlParameter("@DenNgay", ngaytaoTo)
        };

                if (!string.IsNullOrWhiteSpace(item))
                {
                    sql += " AND p.MaSP LIKE @Item";
                    parameters.Add(new SqlParameter("@Item", "%" + item.Trim() + "%"));
                }

                if (!string.IsNullOrWhiteSpace(lot))
                {
                    sql += " AND p.LotSP LIKE @Lot";
                    parameters.Add(new SqlParameter("@Lot", "%" + lot.Trim() + "%"));
                }

                sql += " ORDER BY p.ThoiGianLap DESC";

                return DatabaseHelper.ExecuteQuery(sql, parameters.ToArray());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi load phiếu: {ex.Message}");
                return new DataTable();
            }
        }

        public static DataTable TaoDataPhieu(string SoPhieu)
        {
            try
            {
                var sql = "WITH Numbers AS ( SELECT 1 AS n UNION ALL SELECT n + 1 FROM Numbers WHERE n < 10000 ), Split AS ( SELECT t.SoPhieu, t.SoMeTT, t.LotSp, t.MaSP, t.ThoiGianThoatKhi, CAST(t.MaxPallet AS INT) AS MaxPallet, CAST(t.SoLuong AS INT) AS SoLuong, n.n AS PalletNo, CASE WHEN n.n < CEILING(CAST(t.SoLuong AS FLOAT) / CAST(t.MaxPallet AS FLOAT)) THEN CAST(t.MaxPallet AS INT) ELSE CAST(t.SoLuong AS INT) - (CEILING(CAST(t.SoLuong AS FLOAT) / CAST(t.MaxPallet AS FLOAT)) - 1) * CAST(t.MaxPallet AS INT) END AS SoLuongTach FROM dbo.TaoPhieu t INNER JOIN Numbers n ON n.n <= CEILING(CAST(t.SoLuong AS FLOAT) / CAST(t.MaxPallet AS FLOAT))) SELECT PalletNo AS STT_Pallet, MaSP, LotSp, SoMeTT, ThoiGianThoatKhi, SoLuongTach AS SoLuong, SoPhieu FROM Split WHERE SoPhieu = @soPhieu ORDER BY SoPhieu, PalletNo OPTION (MAXRECURSION 10000);";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@soPhieu", SoPhieu)
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


        //in ma vach
        public static Bitmap GenerateBarcode(string data)
        {
            var writer = new BarcodeWriter
            {
                Format = BarcodeFormat.CODE_128,
                Options = new EncodingOptions
                {
                    Width = 300,
                    Height = 50,
                    Margin = 2,
                    //battatcode
                    //PureBarcode = true
                }
            };

            return writer.Write(data);
        }


        public static void InsertBarcodeToExcel(string excelPath, string sheetName, int row, int col, string value)
        {
            var package = new ExcelPackage(new FileInfo(excelPath));
            var ws = package.Workbook.Worksheets[sheetName];

            // Remove existing barcode drawing if it already exists
            string pictureName = $"Barcode_{row}_{col}";
            var existing = ws.Drawings[pictureName];
            if (existing != null)
            {
                ws.Drawings.Remove(existing);
            }

            var barcodeImage = GenerateBarcode(value);
            var stream = new MemoryStream();
            barcodeImage.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            stream.Position = 0;

            var picture = ws.Drawings.AddPicture(pictureName, stream);
            picture.SetPosition(row - 1, 5, col - 1, 5);
            picture.SetSize(100); // 150% so với kích thước gốc của ảnh
            ws.Row(row).Height = 35;

            package.Save();
        }

        public static void WriteDataToExcel(string excelPath, string sheetName, DataTable data)
        {
            var package = new ExcelPackage(new FileInfo(excelPath));
            var ws = package.Workbook.Worksheets[sheetName];

            if (ws == null)
                ws = package.Workbook.Worksheets.Add(sheetName);

            // Xóa dữ liệu cũ từ A2 trở xuống
            if (ws.Dimension != null)
            {
                var clearRange = ws.Cells[2, 1, ws.Dimension.End.Row, ws.Dimension.End.Column];
                clearRange.Clear();
            }

            // Ghi dữ liệu bắt đầu từ A2 (row=2, col=1)
            for (int r = 0; r < data.Rows.Count; r++)
            {
                for (int c = 0; c < data.Columns.Count; c++)
                {
                    ws.Cells[r + 2, c + 1].Value = data.Rows[r][c];
                }
            }

            package.Save();
        }
        public static void SuaThongTinPhieu(string Sophieu ,string SoLuong, string MaxPallet, string ThoiGianTK, string Note)
        {
            try
            {
                var sql = @" update [TWSL].[dbo].[TaoPhieu] 
  set SoLuong = @SoLuong ,MaxPallet = @MaxPallet, ThoiGianThoatKhi = @ThoiGianTK, Note = @Note 
  where SoPhieu = @Sophieu";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Sophieu", Sophieu),
                    new SqlParameter("@SoLuong", SoLuong),
                    new SqlParameter("@MaxPallet", MaxPallet),
                    new SqlParameter("@ThoiGianTK", ThoiGianTK),
                    new SqlParameter("@Note", Note)
                };
                DatabaseHelper.ExecuteNonQuery(sql, parameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật trạng thái mẻ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public static void XoaPhieu(string Sophieu)
        {
            try
            {
                var sql = @" delete from [TWSL].[dbo].[TaoPhieu] where SoPhieu = @Sophieu";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Sophieu", Sophieu)
                };
                DatabaseHelper.ExecuteNonQuery(sql, parameters);
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"Lỗi khi xóa phiếu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.Message );
            }
        }

        public static void CongSoLanIN(string Sophieu)
        {
            try
            {
                var sql = @"update [TaoPhieu] SET SoLanIn = ISNULL(SoLanIn, 0) + 1  Where SoPhieu = @Sophieu";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Sophieu", Sophieu)
                };
                DatabaseHelper.ExecuteNonQuery(sql, parameters);
            }
            catch (Exception ex)
            {   
                //MessageBox.Show($"Lỗi khi cập nhật số lần in: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.Message);
            }
        }
       


        public static void TaoFileIN(string Sophieu, string outputDir)
        {
            string templatePath = @"TEMP\JCQ50-ADM022-1-Rev6.xlsx";
            Directory.CreateDirectory(outputDir);
            string outputPath = System.IO.Path.Combine(outputDir, $"{Sophieu}.xlsx");

            // Copy từ template ra file mới, không chỉnh sửa file gốc
            File.Copy(templatePath, outputPath, overwrite: true);

            //taomavach
            //string barcodeData = $"{SoPhieuDP.Text}"; // Dữ liệu mã vạch là số phiếu

            // Insert mã vạch vào file mới
            InsertBarcodeToExcel(outputPath, "JCQ50-ADM022", 2, 1, Sophieu);

            // Đẩy dữ liệu vào sheet "data" bắt đầu từ A2
            var dulieu = TaoDataPhieu(Sophieu);
            WriteDataToExcel(outputPath, "data", dulieu);

            //PrintPhieu(outputPath);
        }





        public static void InPhieuNhapkho(string folderPath)
        {
            string[] files = Directory
                .GetFiles(folderPath, "*.xlsx")
                .OrderBy(f => Path.GetFileName(f))
                .ToArray();

            Excel.Application excelApp = null;

            try
            {
                excelApp = new Excel.Application();
                excelApp.Visible = false;
                excelApp.DisplayAlerts = false;

                foreach (string file in files)
                {
                    Excel.Workbook wb = null;
                    Excel.Worksheet ws = null;

                    try
                    {
                        wb = excelApp.Workbooks.Open(
                            Filename: file,
                            ReadOnly: true
                        );

                        foreach (Excel.Worksheet sheet in wb.Worksheets)
                        {
                            if (sheet.Name.Trim().Equals(
                                "JCQ50-ADM022",
                                StringComparison.OrdinalIgnoreCase))
                            {
                                ws = sheet;
                                break;
                            }

                            Marshal.ReleaseComObject(sheet);
                        }

                        if (ws != null)
                        {
                            // Chỉ in sheet JCQ50-ADM022
                            ws.PrintOut(
                                Copies: 1,
                                Preview: false
                            );

                            Marshal.ReleaseComObject(ws);
                        }

                        wb.Close(false);
                    }
                    finally
                    {
                        if (wb != null)
                            Marshal.ReleaseComObject(wb);
                    }
                }

                MessageBox.Show($"Đã in xong {files.Length} file!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi");
            }
            finally
            {
                if (excelApp != null)
                {
                    excelApp.Quit();
                    Marshal.ReleaseComObject(excelApp);
                }

                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
    }
}
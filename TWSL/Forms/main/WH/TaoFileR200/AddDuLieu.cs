using Org.BouncyCastle.Math.Field;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TWSL.Common;

namespace TWSL.Forms.main.WH.TaoFileR200
{
    public partial class AddDuLieu : Form
    {
        // Biến toàn class
        private string SoPhieu;
        private string KhoTD;
        private string Mapallet;
        private string SoMeTT;
        private string MaSP;
        private string LotSP;
        private int SoLuong;
        private int ThoiGianTK;
        private string MaxPallet;

        public AddDuLieu(string Sophieu, string KhoTd)
        {
            InitializeComponent();
            SoPhieu = Sophieu;
            KhoTD = KhoTd;
        }

        private void AddDuLieu_Load(object sender, EventArgs e)
        {
           //lấy thời gian rồi gán vào date
           Date_display.Text = DateTime.Now.ToString("dd/MM/yyyy");
           DocDuLieuLBL.Text = $"ĐỌC DỮ LIỆU ({SoPhieu})  KHO {KhoTD}";
           LoadDuLieu();

        }

        private void LoadDuLieu()
        {

            try
            {
                var sql = "SELECT * FROM [TWSL].[dbo].[TaoPhieu] where SoPhieu = @SoPhieu";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@SoPhieu", SoPhieu)
                };
                var dt = DatabaseHelper.ExecuteQuery(sql, parameters);

                // nếu có kết quả thì đã tồn tại
                if (dt.Rows.Count > 0)
                {
                    var row = dt.Rows[0];
                    row["SoMeTT"] = SoMeTT;
                    row["MaSP"] = MaSP;
                    row["LotSP"] = LotSP;
                    row["SoLuong"] = SoLuong;
                    row["ThoiGianThoatKhi"] = ThoiGianTK;
                    row["MaxPallet"] = MaxPallet;
                }

              
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi kiểm tra phiếu đã tạo: {ex.Message}");
            }
     

        }
        private void MaPalletTBX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) {
                Console.WriteLine("Doc ma pallet");

                string mapallet = MaPalletTBX.Text.Trim();

                bool isValid =
                    mapallet.Length >= 5 && mapallet.Length <= 6 &&
                    mapallet.Substring(0, 5).All(char.IsDigit);

                if (isValid)
                {
                    Mapallet = mapallet.Substring(0, 5);
                    Console.WriteLine(Mapallet);
                    MaPalletTBX.Text = Mapallet;
                    MaThungTBX.Focus();
                }
                else
                {
                    Console.WriteLine("Ma Pallet Khong hop le");
                }

            } 
            
        }

        private void MaThungTBX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) {
                Console.WriteLine("Doc ma Thung");
                if (MaThungTBX.Text.Length >= 33 && MaThungTBX.Text.Length <= 35)
                {
                    Console.WriteLine($"Ma palet {Mapallet} OK");
                }
                else { Console.WriteLine("NG") ; }
            }
        }

        private void DocPalletBTN_Click(object sender, EventArgs e)
        {

        }
    }
}

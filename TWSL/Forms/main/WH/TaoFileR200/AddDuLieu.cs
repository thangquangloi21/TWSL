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
        private int MaxPallet;

        public AddDuLieu(string Sophieu, string KhoTd)
        {
            InitializeComponent();
            SoPhieu = Sophieu;
            KhoTD = KhoTd;
            SaveDataBtn.Visible = false;
        }

        private void AddDuLieu_Load(object sender, EventArgs e)
        {
            // Lấy thời gian rồi gán vào date
            Date_display.Text = DateTime.Now.ToString("dd/MM/yyyy");
            DocDuLieuLBL.Text = $"ĐỌC DỮ LIỆU ({SoPhieu})  KHO {KhoTD}";
            
            // ✅ Khởi tạo cột cho DataGridView
            InitializeCheckDataView();
            MaThungTBX.Enabled = false;
           

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
                    SoMeTT = row["SoMeTT"].ToString();
                    MaSP = row["MaSP"].ToString();
                    LotSP = row["LotSP"].ToString();
                    SoLuong = Convert.ToInt32(row["SoLuong"]);
                    ThoiGianTK = Convert.ToInt32(row["ThoiGianThoatKhi"]);
                    MaxPallet = Convert.ToInt32(row["MaxPallet"]);
                }

              
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi kiểm tra phiếu đã tạo: {ex.Message}");
            }
     

        }

        // ✅ Hàm kiểm tra mã pallet có tồn tại trong DataGridView không
        private bool IsPalletExists(string maPallet)
        {
            foreach (DataGridViewRow row in CHECKDATAVIEW.Rows)
            {
                if (row.Cells["MaPallet"].Value != null &&
                    row.Cells["MaPallet"].Value.ToString() == maPallet)
                {
                    return true;
                }
            }
            return false;
        }

        private void MaPalletTBX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) {
                Console.WriteLine("Doc ma pallet");

                string mapallet = MaPalletTBX.Text.Trim();

                bool isValid =
                    mapallet.Length >= 5 && mapallet.Length <= 6 &&
                    mapallet.Substring(0, 5).All(char.IsDigit);

                if (SoLuong <= 0)
                {
                    Console.WriteLine("Đã kết số lượng trên phiếu nhập kho !");
                    MessageBox.Show("Đã hết số lượng trên phiếu nhập kho !", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    MaPalletTBX.SelectAll();
                    return;
                }
                if (IsPalletExists(mapallet.Substring(0, 5)))
                {
                    Console.WriteLine("Mã pallet đã tồn tại trong danh sách");
                    MessageBox.Show("Mã pallet đã tồn tại trong danh sách ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MaPalletTBX.SelectAll();
                    return;
                }

                if (isValid)
                {
                    Mapallet = mapallet.Substring(0, 5);
                    Console.WriteLine(Mapallet);
                    MaPalletTBX.Text = Mapallet;
                    MaPalletTBX.Enabled = false;
                    MaThungTBX.Enabled = true;
                    MaThungTBX.Focus();
                }

                else
                {
                    Console.WriteLine("Ma Pallet Khong hop le");
                    MaPalletTBX.SelectAll();
                    MessageBox.Show("Mã Pallet không hợp lệ ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            } 
            
        }

       

        private void MaThungTBX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Enter)
                return;

            Console.WriteLine("Doc ma Thung");

            string maThung = MaThungTBX.Text.Trim();

            if (maThung.Length < 33 || maThung.Length > 35)
            {
                Console.WriteLine("Mã thùng không hợp lệ");
                MessageBox.Show("Mã thùng không hợp lệ ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MaThungTBX.SelectAll();
                return;
            }

            Console.WriteLine($"Ma pallet {Mapallet} OK");

            // GS1 từ vị trí 2 -> 15 (16 ký tự)
            string gs1Code = maThung.Substring(2, 14);

            // Lot từ vị trí 26 tới cuối
            string lot = maThung.Substring(26);

            DataTable data = NhapKho.GetItemName(gs1Code);

            if (data.Rows.Count == 0)
            {
                Console.WriteLine($"Mã SP chưa được đăng kí trên GS1: {gs1Code}");
                MaThungTBX.SelectAll();
                return;
            }

            DataRow row = data.Rows[0];

            string boPhan = row["category"]?.ToString() ?? "";
            string maSPTrenThung = row["itemCode"]?.ToString() ?? "";

            string sanPhamTrenPhieu = MaSP + LotSP;
            string sanPhamTrenThung = maSPTrenThung + lot;

            // So sánh luôn nếu cần
            if (sanPhamTrenPhieu != sanPhamTrenThung)
            {
                Console.WriteLine("Sai sản phẩm");
                MessageBox.Show("Mã sản phẩm không khớp vui lòng kiểm tra lại ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MaThungTBX.SelectAll();
                return;
            }

            Console.WriteLine("Đúng sản phẩm");
            if (SoLuong <= 0)
            {
                Console.WriteLine("Đã kết số lượng trên phiếu nhập kho !");
                MessageBox.Show("Đã hết số lượng trên phiếu nhập kho !", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MaThungTBX.SelectAll();
                return;
            }

            int SoLuongTudong = 0;

            if (SoLuong <= MaxPallet)
            {
                SaveDataBtn.Visible = true;
                SoLuongTudong = SoLuong;
                SoLuong = 0;
            }
            else
            {
                SoLuongTudong = MaxPallet;
                SoLuong -= MaxPallet;
            }

            // ✅ Thêm dòng vào DataGridView
            AddRowToCheckDataView(Mapallet, SoMeTT, maSPTrenThung, boPhan, lot, SoLuongTudong, ThoiGianTK, KhoTD);

            // Reset textbox để nhập tiếp
            MaPalletTBX.Enabled = true;
            MaPalletTBX.Clear();
            MaThungTBX.Clear();
            MaPalletTBX.Focus();
            MaThungTBX.Enabled = false;
        }

        // Hàm khởi tạo cột cho DataGridView
        private void InitializeCheckDataView()
        {
            CHECKDATAVIEW.Columns.Clear(); // Xóa cột cũ nếu có
            
            CHECKDATAVIEW.Columns.Add("STT", "STT");
            CHECKDATAVIEW.Columns.Add("MaPallet", "Mã Pallet");
            CHECKDATAVIEW.Columns.Add("SoMeTietTrung", "Số Mẻ Tiệt Trùng");
            CHECKDATAVIEW.Columns.Add("MaSP", "Mã Sản Phẩm");
            CHECKDATAVIEW.Columns.Add("Bophan", "Bộ Phận");
            CHECKDATAVIEW.Columns.Add("Lot", "Lot");
            CHECKDATAVIEW.Columns.Add("SoLuong", "Số Lượng");
            CHECKDATAVIEW.Columns.Add("ThoigianThoatkhi", "Thời Gian Thoát khí");
            CHECKDATAVIEW.Columns.Add("KhoThoatKhi", "Kho Thoát Khí");
          
        }

        // Hàm thêm dòng vào DataGridView
        private void AddRowToCheckDataView(string maPallet,string SoMeTietTrung, string maSP,string Bophan, string lot, int soLuong, int ThoiGianThoatKhi, string KhoThoatKhi)
        {

            Console.WriteLine(SoLuong);
            CHECKDATAVIEW.Rows.Add(
                CHECKDATAVIEW.Rows.Count + 1,  // STT
                maPallet,
                SoMeTietTrung,
                maSP,
                Bophan,
                lot,
                soLuong,
                ThoiGianThoatKhi,
                KhoThoatKhi
            );
        }

        private void DocPalletBTN_Click(object sender, EventArgs e)
        {
            MaPalletTBX_KeyPress(sender, new KeyPressEventArgs((char)Keys.Enter));
        }

        private void ClearData(object sender, EventArgs e)
        {
            //hiện thông báo muốn xóa dữ liệu không
            var CoMuonXoaKhong = MessageBox.Show("Bạn có chắc muốn xóa tất cả dữ liệu đã nhập không?", "Xác nhận xóa dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (CoMuonXoaKhong != DialogResult.Yes) { 
            return;
            }
            //Tắt from đi bật lại để xóa hết dữ liệu
            CHECKDATAVIEW.Rows.Clear();
            MaThungTBX.Clear();
            MaPalletTBX.Clear();
            MaThungTBX.Enabled = false;
            MaPalletTBX.Enabled = true;
            MaPalletTBX.Focus();
            LoadDuLieu();
            Console.WriteLine(SoLuong);

        }

        private void DocThungSXBTN_Click(object sender, EventArgs e)
        {
            MaThungTBX_KeyPress(sender, new KeyPressEventArgs((char)Keys.Enter));
        }

        private void LuuDuLieuADD(object sender, EventArgs e)
        {
            if (SoLuong > 0)
            {
                Console.WriteLine("Vẫn còn số lượng chưa được nhập vào pallet, vui lòng nhập đủ số lượng trước khi lưu");
                MessageBox.Show("Vẫn còn số lượng chưa được nhập vào pallet, vui lòng nhập đủ số lượng trước khi lưu ", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //Hiện thông báo xác nhận lưu dữ liệu
            var confirmResult = MessageBox.Show("Bạn có chắc muốn lưu dữ liệu đã nhập không?", "Xác nhận lưu dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult != DialogResult.Yes) {
                return;
            }

            // lấy thông tin trong datagridview CHECKDATAVIEW rồi lưu vào database

            foreach (DataGridViewRow row in CHECKDATAVIEW.Rows)
            {
                if (row.IsNewRow)
                    continue;

                var stt = row.Cells[0].Value?.ToString() ?? string.Empty;
                var maPallet = row.Cells[1].Value?.ToString() ?? string.Empty;
                var soMeTietTrung = row.Cells[2].Value?.ToString() ?? string.Empty;
                var maSP = row.Cells[3].Value?.ToString() ?? string.Empty;
                var boPhan = row.Cells[4].Value?.ToString() ?? string.Empty;
                var lot = row.Cells[5].Value?.ToString() ?? string.Empty;
                var soLuong = row.Cells[6].Value?.ToString() ?? string.Empty;
                var thoiGianThoatKhi = row.Cells[7].Value?.ToString() ?? string.Empty;
                var khoThoatKhi = row.Cells[8].Value?.ToString() ?? string.Empty;

                NhapKho.InsertdataNhapKho(
                    stt,
                    SoPhieu,
                    maPallet,
                    soMeTietTrung,
                    maSP,
                    boPhan,
                    lot,
                    soLuong,
                    thoiGianThoatKhi,
                    khoThoatKhi,
                    AppData.Instance.CurrentUserId
                );
            }
            MessageBox.Show("Dữ liệu đã được lưu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}

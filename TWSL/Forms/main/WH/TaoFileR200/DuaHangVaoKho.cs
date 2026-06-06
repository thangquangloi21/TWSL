using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TWSL.Common;

namespace TWSL.Forms.main.WH.TaoFileR200
{
    public partial class DuaHangVaoKho : Form
    {
        public DuaHangVaoKho()
        {
            InitializeComponent();
            Logger.Log("INFO", $"{AppData.Instance.CurrentUserName} Vào chức năng nhập kho tự động {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var DocSoPhieuDP = new DocSoPhieu();
            DocSoPhieuDP.ShowDialog();
            LoadData();
        }

        private void DuaHangVaoKho_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData() {

            DataTable dt = NhapKho.LoadDataDatao(SoPhieuTbx.Text.Trim(), IDNguoitaoTbx.Text.Trim(), Ngaytaopick.Value.ToString("yyyy-MM-dd"));

            // Kiểm tra null trước khi gán
            if (dt != null && dt.Rows.Count > 0)
            {
                NhapKhoTuDongView.DataSource = dt;
                try
                {
                    NhapKhoTuDongView.Columns["Số Phiếu"].FillWeight = 140;
                    NhapKhoTuDongView.Columns["Số Mẻ Tiệt Trùng"].FillWeight = 120;
                    NhapKhoTuDongView.Columns["Mã Sản Phẩm"].FillWeight = 120;
                    NhapKhoTuDongView.Columns["Thời Gian Tạo"].FillWeight = 150;
                    NhapKhoTuDongView.Columns["Số Lượng"].FillWeight = 70;
                    NhapKhoTuDongView.Columns["Lot"].FillWeight = 80;
                    NhapKhoTuDongView.Columns["Bộ Phận"].FillWeight = 70;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi định dạng cột: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                // Xóa dữ liệu cũ hoặc hiển thị thông báo
                NhapKhoTuDongView.DataSource = null;
                MessageBox.Show("Không có dữ liệu để hiển thị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void NhapKhoTuDongView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = NhapKhoTuDongView.Rows[e.RowIndex];
                //string bat = row.Cells["time_register"].Value.ToString();
                // Gán dữ liệu từ các cột vào label

                SoPhieuLBL.Text = row.Cells["Số Phiếu"].Value?.ToString();
                SoMeTTLBL.Text = row.Cells["Số Mẻ Tiệt Trùng"].Value?.ToString();
                MaSPLBL.Text = row.Cells["Mã Sản Phẩm"].Value?.ToString();
                LotSPLBL.Text = row.Cells["Lot"].Value?.ToString();

                //Console.WriteLine($"{bat}");

            }
        }

        private void TaoFileBtn_Click(object sender, EventArgs e)
        {
            if (SoPhieuLBL.Text == "...")
            {
                MessageBox.Show("Vui lòng chọn một phiếu để tạo file", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataTable dt  = NhapKho.TaoFileCSV(SoPhieuLBL.Text);
          

            SaveFileDialog save = new SaveFileDialog();
            // lưu vào thư mục quy định theo tên file là <Ngày lập><Code>_<Lot>_PLINFO.CSV (để check lại khi cần)
            save.Filter = "CSV File|*.csv";
            save.FileName = $"{DateTime.Now:ddMMyy}_{SoPhieuLBL.Text.Trim()}_{SoMeTTLBL.Text.Trim()}_PLINFO.csv";

            if (save.ShowDialog() != DialogResult.OK)
                return;

            using (StreamWriter sw = new StreamWriter(
                save.FileName,
                false,
                Encoding.UTF8))
            {
                // Header mẫu
                sw.WriteLine(
            "Pallet No.,Batch No,Product Code,Product Name,Lot,Quantity,Degassing time(A),Degassing time(B),Degassing time(C)"
                );
                foreach (DataRow row in dt.Rows)
                {
                    string line =
                        $"{row["MaPalet"]?.ToString()?.Trim()}," +
                        $"{row["SoMeTietTrung"]?.ToString()?.Trim()}," +
                        $"{row["MaSanPham"]?.ToString()?.Trim()}," +
                        $"{row["BoPhan"]?.ToString()?.Trim()}," +
                        $"{row["LotSanPham"]?.ToString()?.Trim()}," +
                        $"{row["SoLuong"]?.ToString()?.Trim()}," +
                        $"{row["A"]?.ToString()?.Trim()}," +
                        $"{row["B"]?.ToString()?.Trim()}," +
                        $"{row["C"]?.ToString()?.Trim()}";

                    line += new string(',', 30);

                    sw.WriteLine(line);
                }
               
            }

            MessageBox.Show("Xuất CSV thành công");


        }

        private void TimKiemBtnFunc(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}

using Org.BouncyCastle.Crypto.Tls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TWSL.Common;
using TWSL.Forms.main.WH.LapPhieu;


namespace TWSL.Forms.main.WH
{
    public partial class TaoPhieuNhapKho : Form
    {
        private loading_wait loading;
        private string Maxpalet { get; set; }
        public TaoPhieuNhapKho()
        {
            InitializeComponent();
            loading = new loading_wait();
            //Logger.Log("INFO", $"{User_id} Vào chức năng quản lý Master {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
            Logger.Log("INFO", $"{AppData.Instance.CurrentUserName} Vào chức năng lập phiếu nhập kho {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
            this.Controls.Add(loading);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var create_from_awm = new DocMaVach();
            create_from_awm.ShowDialog();
            updateData();
        }


        private void updateData()
        {

            DataTable dt = TaoPhieu.LoadPhieu(MaSPTbx.Text.Trim(), LotTbx.Text.Trim(), NgaytaodateFromPick.Value.ToString("yyyy-MM-dd"), NgaytaodateToPick.Value.ToString("yyyy-MM-dd"));

            DataTaoPhieu.AutoGenerateColumns = false;
            DataTaoPhieu.Columns.Clear();

            var columns = new (string dataField, string header, string format)[]
            {
                ("SoPhieu","Số phiếu",null),
                ("SoMeTT","Số Mẻ Tiệt Trùng",null),
                ("MaSP","Mã Sản Phẩm",null),
                ("LotSP","Lot",null),
                ("SoLuong","Số Lượng",null),
                ("MayTT","Máy TT",null),
                 ("ThoiGianThoatKhi","Thời gian thoát khí",null),
                  ("MaxPallet","Max/Pallet",null),
                   ("username","Người tạo",           null),
                ("ThoiGianLap","Thời gian lập phiếu","dd/MM/yyyy HH:mm:ss"),
                ("Note","Note",null),
                ("SoLanIn","Số lần in",null),

            };

            foreach (var (dataField, header, format) in columns)
            {
                var col = new DataGridViewTextBoxColumn
                {
                    Name = dataField,
                    DataPropertyName = dataField,
                    HeaderText = header,
                    ReadOnly = true
                };
                if (format != null)
                    col.DefaultCellStyle.Format = format;
                DataTaoPhieu.Columns.Add(col);
            }

            DataTaoPhieu.DataSource = dt;
        }

        private void TaoPhieuNhapKho_Load(object sender, EventArgs e)
        {
            loading.ShowLoading();
            Task.Run(() =>
            {
                //updateData();
                //upload_master(filePath);
                //MessageBox.Show("đang hoàn thành!");

                this.Invoke(new Action(() =>
                {
                    updateData();
                    loading.HideLoading();
                    //MessageBox.Show("Hoàn thành!");

                    //Update_data();
                }));
            });
        }

        private void InPhieuBTN(object sender, EventArgs e)
        {
            try
            {
                if (SoPhieuDP.Text == "...")
                {
                    MessageBox.Show("Vui lòng chọn một phiếu để in!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string outputDir = Path.Combine(
                    Application.StartupPath,
                    "TEMP/Output/",
                    DateTime.Now.ToString("yyyyMMddHHmmss")
                );

                Directory.CreateDirectory(outputDir);

                var selectedRowIndices = DataTaoPhieu.SelectedCells
                    .Cast<DataGridViewCell>()
                    .Select(cell => cell.RowIndex)
                    .Distinct()
                    .ToList();

                foreach (int rowIndex in selectedRowIndices)
                {
                    string soPhieu = DataTaoPhieu.Rows[rowIndex]
                        .Cells["SoPhieu"].Value?.ToString() ?? "";

                    if (!string.IsNullOrWhiteSpace(soPhieu))
                    {
                        Logger.Log("INFO", $"{AppData.Instance.CurrentUserName} In phiếu nhập kho soPhieu {soPhieu} {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
                        TaoPhieu.TaoFileIN(soPhieu, outputDir);
                        //cập nhật số lần in
                        TaoPhieu.CongSoLanIN(soPhieu);
                    }
                }
                
                TaoPhieu.InPhieuNhapkho(outputDir);
                //Load lại dữ liệu để cập nhật số lần in
                updateData();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi");
            }





        }

        private void DataTaoPhieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = DataTaoPhieu.Rows[e.RowIndex];
                //string bat = row.Cells["time_register"].Value.ToString();
                // Gán dữ liệu từ các cột vào label

                SoPhieuDP.Text = row.Cells["SoPhieu"].Value?.ToString();
                SoMeTTDP.Text = row.Cells["SoMeTT"].Value?.ToString();
                MaSPDP.Text = row.Cells["MaSP"].Value?.ToString();
                LotSPDP.Text = row.Cells["LotSP"].Value?.ToString();
                SoLuongDP.Text = row.Cells["SoLuong"].Value?.ToString();
                ThoiGianTKDP.Text = row.Cells["ThoiGianThoatKhi"].Value?.ToString();
                Maxpalet = row.Cells["MaxPallet"].Value?.ToString();

                //Console.WriteLine($"{bat}");

            }
        }

        private void TimKiemBTNFunc(object sender, EventArgs e)
        {
            updateData();
        }

        private void SuaPhieuBTN_Click(object sender, EventArgs e)
        {
            // in phiếu đã chọn
            if (SoPhieuDP.Text == "...")
            {
                MessageBox.Show("Vui lòng chọn một phiếu để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (var sua_thong_tin = new SuaThongTin(MaSPDP.Text.Trim(),LotSPDP.Text.Trim(),SoMeTTDP.Text.Trim(),SoLuongDP.Text.Trim(), Maxpalet, ThoiGianTKDP.Text.Trim()))
            {
                Logger.Log("INFO", $"{AppData.Instance.CurrentUserName} Vào chức sửa thông tin của phiếu {SoPhieuDP.Text} {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
                if (sua_thong_tin.ShowDialog() == DialogResult.OK)
                {
                    //Cập nhật lại thông tin sau khi sửa
                    TaoPhieu.SuaThongTinPhieu(SoPhieuDP.Text, sua_thong_tin.ResultSoLuong, sua_thong_tin.ResultMaxPallet, sua_thong_tin.ResultThoiGianTK, sua_thong_tin.ResultNoiDung);
                    updateData();
                }
            }

        }



        private void XemChiTietBtn_Click(object sender, EventArgs e)
        {


            // lấy dữ liệu để đổ ra xem
            var Xemchitiet  = TaoPhieu.TaoDataPhieu(SoPhieuDP.Text);
            Xemchitiet.Columns["STT_Pallet"].ColumnName = "STT";
            Xemchitiet.Columns["MaSP"].ColumnName = "Mã SP";
            Xemchitiet.Columns["LotSp"].ColumnName = "Lot SP";
            Xemchitiet.Columns["SoMeTT"].ColumnName = "Số Mẻ";
            Xemchitiet.Columns["ThoiGianThoatKhi"].ColumnName = "Thời gian thoát Khí";
            Xemchitiet.Columns["SoLuong"].ColumnName = "Số Lượng";
            Xemchitiet.Columns["SoPhieu"].ColumnName = "Số Phiếu";

            var dp = new XemChiTiet("DP", Xemchitiet);
            dp.ShowDialog();
        }

        
    }
}

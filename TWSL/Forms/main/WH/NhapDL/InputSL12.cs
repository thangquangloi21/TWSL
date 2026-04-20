using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TWSL.Common;
using TWSL.Forms.main.SL.SL12;


namespace TWSL.Forms.main.SL.SL1
{
    public partial class InputSL12 : Form
    {
        private loading_wait loading;
        //private bool pallet_enter = false;
        public InputSL12()
        {

            InitializeComponent();
            ExcelPackage.License.SetNonCommercialPersonal("Your Name");
            loading = new loading_wait();
            //Logger.Log("INFO", $"{User_id} Vào chức năng quản lý Master {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
            this.Controls.Add(loading);
            TgKetThuc.Value = DateTime.Now.AddDays(1);
            //Barcode.ReadOnly = true;
        }


        private void updateData()
        {
            //DataTable dt = SLFunc.GetData();
            //DataBatchNo.DataSource = dt;
        }

        // đẩy dữ liệu vào db
        private void insert_data_desg_time()
        {
            string time = UtilityFunctions.getdate_time1();
            foreach (DataGridViewRow row in DataBatchNo.Rows)
            {
                if (row.IsNewRow) continue; // Bỏ qua hàng mới
                string batchNo = row.Cells[0].Value?.ToString() ?? "";
                string productCode = row.Cells[1].Value?.ToString() ?? "";
                string line = row.Cells[2].Value?.ToString() ?? "";
                string lot = row.Cells[3].Value?.ToString() ?? "";
                string quantity = row.Cells[4].Value?.ToString() ?? "";
                string machine = row.Cells[5].Value?.ToString() ?? "";
                string id_user = TWSL.Common.AppData.Instance.CurrentUserId;
                string name = TWSL.Common.AppData.Instance.CurrentUserName;
                SLFunc.InsertDataBatchNo(batchNo, productCode, line, lot, quantity, machine, id_user, name, "add", time);
                Console.WriteLine("batchNo, productCode, line, lot, quantity, machine, id_user, name");
            }
            Logger.Log("INFO", $"{AppData.Instance.CurrentUserId} lưu mẻ {AppData.Instance.Batch} lúc: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
            MessageBox.Show("Lưu dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void InfoInp(object sender, EventArgs e)
        {
            var InfoForm = new InfoBathWh12();
            this.Hide();
            InfoForm.ShowDialog();
            this.Show();
        }

        private void ChonFile(object sender, EventArgs e)
        {
            try
            {
                string filePath = "";
                // Mở hộp thoại chọn file Excel
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                   filePath = openFileDialog.FileName;
                   LinkFile.Text = filePath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void UpLoadFileSL12(string filePath)
        {
            // Bạn cần cài đặt thư viện EPPlus để làm việc với file Excel
            using (var package = new OfficeOpenXml.ExcelPackage(new FileInfo(filePath)))
            {
                // Lấy worksheet đầu tiên
                var worksheet = package.Workbook.Worksheets[0];
                int rowCount = worksheet.Dimension.Rows;
                string stt = worksheet.Cells[8, 2].Value?.ToString().Trim(); ;
                string ITEMCODE = worksheet.Cells[8, 4].Value?.ToString().Trim();
                string SOLO = worksheet.Cells[8, 3].Value?.ToString().Trim();
                string SOLUONG = worksheet.Cells[8, 5].Value?.ToString().Trim();
                string TGBATDAUTT = worksheet.Cells[8, 16].Value?.ToString().Trim();
                string TGKETTHUCTT = worksheet.Cells[8, 17].Value?.ToString().Trim();
                string NGAYKETTHUCTT = worksheet.Cells[8, 18].Value?.ToString().Trim();
                string MAYTT = worksheet.Cells[8, 19].Value?.ToString().Trim();
                string METT = worksheet.Cells[8, 20].Value?.ToString().Trim();
                //int colCount = worksheet.Dimension.Columns;
                // kiểm tra xem đúng định dạng file chưa
                //MessageBox.Show($"{ITEMCODE}");
                //Console.WriteLine($"STT: {stt}, ITEMCODE: {ITEMCODE}, SOLO: {SOLO}, SOLUONG: {SOLUONG}, TGBATDAUTT: {TGBATDAUTT}, TGKETTHUCTT: {TGKETTHUCTT}");
                if (stt != "No." || ITEMCODE != "Mã sản phẩm/製品コード"
                    || SOLO != "Số lô/ロット番号" || SOLUONG != "Số lượng xuất hàng/出荷数量" ||
                    TGBATDAUTT != "Bắt đầu tiệt trùng/滅菌開始" || TGKETTHUCTT != "Kết thúc tiệt trùng/滅菌終了" ||
                    NGAYKETTHUCTT != "Ngày kết thúc tiệt trùng/ 滅菌終了日" || MAYTT != "Máy tiệt trùng/ 滅菌機"  ||
                    METT !=  "Mẻ tiệt trùng/ 滅菌バッチ" ) 
                {
                    MessageBox.Show("File chưa đúng định dạng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                // Duyệt qua từng hàng và cột để lấy dữ liệu
                //lấy thời gian ngày tháng hiện tại
                DateTime time = DateTime.Now;
                for (int row = 9; row <= rowCount; row++) // Bỏ qua hàng tiêu đề
                {
                    string MeTT = worksheet.Cells[row, 20].Text.Trim(); // Cột B
                                                                           // *** KIỂM TRA HÀNG CÓ DỮ LIỆU ***
                    if (string.IsNullOrEmpty(MeTT))
                    {
                        // Bỏ qua hàng nếu cột MeTT rỗng
                        continue;
                    }
                    string SoMETT = worksheet.Cells[row, 20].Text.Trim(); // Cột C
                    string MaSanPham = worksheet.Cells[row, 4].Text.Trim(); // Cột D
                    string LotSanPham = worksheet.Cells[row, 3].Text.Trim(); // Cột E
                    string SoLuong = worksheet.Cells[row, 5].Text.Trim(); // Cột F int
                    string TgBatDauTT = worksheet.Cells[row, 16].Text.Trim(); // Cột G time(7)
                    string TgKetThucTT = worksheet.Cells[row, 17].Text.Trim(); // Cột H time(7)
                    string NgayKetThucTT = worksheet.Cells[row, 18].Text.Trim(); // Cột I date
                    string MayTT = worksheet.Cells[row, 19].Text.Trim(); // Cột J


                    if (SLFunc.CheckMeTT(SoMETT, MaSanPham, LotSanPham) == 1)
                    {
                        continue;
                    }
                    
                    //kiểm tra dữ liệu đã tồn tại trong database chưa
                    // lấy dữ liệu trong db ra

                    // Đẩy dữ liệu vào DB
                    SLFunc.InsertSL(MeTT, MaSanPham, LotSanPham, SoLuong, MayTT, TgBatDauTT, TgKetThucTT, NgayKetThucTT, "Đã nhập");


                    //MessageBox.Show($"Mẻ tiệt trùng: {MeTT}\n Mã sản phẩm: {MaSanPham}\n Lot sản phẩm: {LotSanPham}\n Số lượng: {SoLuong}\n Thời gian bắt đầu tiệt trùng: {TgBatDauTT}\n Thời gian kết thúc tiệt trùng: {TgKetThucTT}\n Ngày kết thúc tiệt trùng: {NgayKetThucTT}\n Máy tiệt trùng: {MayTT}", "Dữ liệu đọc từ file", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void StatusBtn_Click(object sender, EventArgs e)
        {
            string filePath = LinkFile.Text;

            if (filePath == "")
            {
                MessageBox.Show("Vui lòng chọn file trước khi tải lên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }    

            loading.ShowLoading();
            Task.Run(() =>
            {
                UpLoadFileSL12(filePath);
                //upload_master(filePath);
                //MessageBox.Show("đang hoàn thành!");

                this.Invoke(new Action(() =>
                {
                    loading.HideLoading();
                    //MessageBox.Show("Hoàn thành!");

                    //Update_data();
                }));
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SLFunc.CheckMeTT(LinkFile.Text);
        }

        private void InputSL12_Load(object sender, EventArgs e)
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
    }
}

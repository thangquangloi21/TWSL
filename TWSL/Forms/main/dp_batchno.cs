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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace TWSL
{
    public partial class info_batchno : Form
    {
        string mett = "";
        //bool status_export = false;
        public info_batchno(string batchno, bool status_export)
        {
            InitializeComponent();
            mett = batchno;
            exportcsv.Enabled = status_export;
        }

        private void info_batchno_Load(object sender, EventArgs e)
        {

            string sql = " select paletno,batch_no ,itemcode ,line,lotnumber ,quantity ,degassing_time_wha,degassing_time_whb,degassing_time_whc from data_degassing_time where batch_no = @batch_no";
            SqlParameter[] data = new SqlParameter[]
      {
                            new SqlParameter("@batch_no", mett),

      };
            DataTable result = DatabaseHelper.ExecuteQuery(sql, data);

            data_view_dp.DataSource = result;
            //// Gán tên hiển thị cho các cột
            data_view_dp.Columns["paletno"].HeaderText = "Mã Pallet";
            data_view_dp.Columns["batch_no"].HeaderText = "Số mẻ tiệt trùng";
            data_view_dp.Columns["itemcode"].HeaderText = "Mã sản phẩm";
            data_view_dp.Columns["line"].HeaderText = "Bộ Phận";
            data_view_dp.Columns["lotnumber"].HeaderText = "Số lot";
            data_view_dp.Columns["quantity"].HeaderText = "Số Lượng";
            data_view_dp.Columns["degassing_time_wha"].HeaderText = "Thời gian thoát khí (A)";
            data_view_dp.Columns["degassing_time_whb"].HeaderText = "Thời gian thoát khí (B)";
            data_view_dp.Columns["degassing_time_whc"].HeaderText = "Thời gian thoát khí (C)";
        }


        private void export_csv()
        {
            try
            {
                string mett1 = "";
                DataGridViewRow firstRow = data_view_dp.Rows[0];
                if (firstRow.IsNewRow && data_view_dp.AllowUserToAddRows)
                {
                    MessageBox.Show("Hàng đầu tiên là hàng trống (New Row). Không có dữ liệu thực sự để in từ hàng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    // Tạo SaveFileDialog
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                        saveFileDialog.Title = "Chọn vị trí lưu file CSV";
                        saveFileDialog.DefaultExt = "csv";
                        saveFileDialog.AddExtension = true;
                        saveFileDialog.FileName = DateTime.Now.ToString("yy") + "EO" + mett + DateTime.Now.ToString("yyMMddHHmmss"); // Tên file mặc định

                        // Hiển thị dialog và kiểm tra nếu người dùng chọn OK
                        if (saveFileDialog.ShowDialog() != DialogResult.OK)
                        {
                            return; // Thoát nếu người dùng hủy
                        }

                        // Lấy đường dẫn file từ SaveFileDialog
                        string outputPath = saveFileDialog.FileName;

                        // Tạo StringBuilder để xây dựng nội dung CSV
                        StringBuilder csvContent = new StringBuilder();

                        // Thêm tiêu đề với 4 nhóm lặp lại
                        csvContent.AppendLine("Pallet No.,Batch No,Product Code,Product Name,Lot,Quantity ,Degassing time(A),Degassing time (B),Degassing time (C)");

                        // Sử dụng Dictionary để gộp các hàng theo Pallet No. và Batch No., hỗ trợ tối đa 3 Lot
                        var palletBatchData = new Dictionary<string, List<string[]>>();
                        foreach (DataGridViewRow row in data_view_dp.Rows)
                        {
                            if (row.IsNewRow) continue; // Bỏ qua hàng mới

                            string palletNo = row.Cells[0].Value?.ToString() ?? "null"; // Pallet No (cột 0)
                            string batchNo = row.Cells[1].Value?.ToString() ?? ""; // Batch No (cột 1)
                            string key = $"{palletNo}_{batchNo}"; // Khóa duy nhất dựa trên Pallet No và Batch No

                            string productCode = row.Cells[2].Value?.ToString() ?? "";
                            string productName = row.Cells[3].Value?.ToString() ?? "";
                            string lot = row.Cells[4].Value?.ToString() ?? "";
                            string quantity = row.Cells[5].Value?.ToString() ?? "0";
                            string degassingA = row.Cells[6].Value?.ToString() ?? "0";
                            string degassingB = row.Cells[7].Value?.ToString() ?? "0";
                            string degassingC = row.Cells[8].Value?.ToString() ?? "0";
                            mett1 = batchNo;    

                            // Khởi tạo danh sách cho pallet/batch nếu chưa tồn tại
                            if (!palletBatchData.ContainsKey(key))
                            {
                                palletBatchData[key] = new List<string[]>();
                            }

                            // Thêm nhóm dữ liệu (tối đa 5 Lot)
                            if (palletBatchData[key].Count < 5) // Giới hạn 5 Lot
                            {
                                palletBatchData[key].Add(new string[] { productCode, productName, lot, quantity, degassingA, degassingB, degassingC });
                            }
                        }

                        // Ghi dữ liệu vào CSV
                        foreach (var entry in palletBatchData)
                        {
                            string[] keyParts = entry.Key.Split('_');
                            string palletNo = keyParts[0];
                            string batchNo = keyParts[1];
                            var groups = entry.Value;

                            // Tạo dòng dữ liệu, điền tối đa 5 nhóm (không thêm nhóm thứ 6 nếu đã có 6 Lot)
                            string line = $"{palletNo},{batchNo}";
                            for (int i = 0; i < Math.Min(5, groups.Count); i++) // Giới hạn 5 nhóm
                            {
                                string[] group = groups[i];
                                line += $",{string.Join(",", group)}";
                            }
                            if (groups.Count < 5)
                            {
                                // Thêm cột trống cho các nhóm thiếu (tối đa 5 nhóm)
                                for (int i = groups.Count; i < 5; i++)
                                {
                                    line += ",,,,,,,"; // 7 cột trống
                                }
                            }
                            csvContent.AppendLine(line);
                        }

                        // Ghi file
                        File.WriteAllText(outputPath, csvContent.ToString());
                        //send_data();
                        MessageBox.Show($"File CSV đã được xuất thành công tại: {outputPath}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //tăng biến đếm lên 1 sau mỗi lần xuất ok
                        Console.WriteLine(mett1);
                        string sql = " update [master_batchno] set number_export = number_export + 1 , status = N'Đã Xuất dữ liệu' where batch_no = @batch_no";
                        SqlParameter[] data = new SqlParameter[]
                        {
                            new SqlParameter("@batch_no", mett1),

                        };
                        DatabaseHelper.ExecuteNonQuery(sql, data);
                        this.Close();
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            export_csv();
        }
    }
}

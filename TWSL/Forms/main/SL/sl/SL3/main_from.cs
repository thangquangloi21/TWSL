using TWSL.Common;
using TWSL.Forms.history;
using TWSL.Forms.main;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
//using ClosedXML.Excel;
//using DocumentFormat.OpenXml.Spreadsheet;
using System.Data.SqlClient;
using System.Drawing;
//using OfficeOpenXml;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Formatters;
using System.Text;
//using System;
//using System.Net.Http;
//using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
//using System.Windows.Forms; // Thêm namespace này cho WinForms

namespace TWSL
{
    //code
    //01589352212000521728013110250827TC
    //01589352212001511728013110250827TC
    //01589352212002121728013110250827TC
    //01589352212000381728013110250827TC
    //01589352212007481728013110250827TE
    public partial class main_from : Form
    {   

        string Nopalet = "0";
        string machineno = "0";
        string batch_no = "";
        string sum_item = "0";
        string getyear = "";
        string user_id = "";
        string name_user = "";
        string user_role = "";
        public string user_password = "";
        private bool batno_enter = true;
        private bool pallet_enter = false;

        //private readonly string connectionString = "Server=pc-tql;Database=DB_GS1_GenIII;User Id=sa;Password=P@ssw0rd2025!;";
        //private readonly string connectionString = "Server=10.239.1.162;Database=DB_GS1_GenIII;User Id=loi_tq;Password=249533;";
        private static readonly HttpClient _httpClient = new HttpClient();
        public main_from()
        {
            InitializeComponent();

            ExcelPackage.License.SetNonCommercialPersonal("Your Name");
            wh_cbx.DropDownStyle = ComboBoxStyle.DropDownList;
            wh_cbx.SelectedIndex = 0;
            barcode_textBox.ReadOnly = true;
            Nopalet_texbox.ReadOnly = true;
            string year = DateTime.Now.Year.ToString();
            getyear = year.Substring(year.Length - 2);
            lbl_eog.Text = getyear + "EO";
            user_lbl.Text = $"Hi: {AppData.Instance.CurrentUserName}";
            //info_user.Text = AppData.Instance.CurrentUserName;
            user_id = AppData.Instance.CurrentUserId;
            name_user = AppData.Instance.CurrentUserName;
            user_role = AppData.Instance.CurrentRole;
            //master_data.Visible = false;
            user_password = AppData.Instance.CurrentPassw;
            palletadd_btn.Enabled = false;


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Console.WriteLine("ahihi");
        }

        
        private async         
        Task
api_send(string json)
        {
            // Hiển thị thông báo đang xử lý
            //MessageBox.Show("Đang gửi dữ liệu...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            try
            {
                // URL API của bạn
                //string apiUrl = "http://127.0.0.1:5000/nhan-json"; // Ví dụ dùng JSONPlaceholder
                //string apiUrl = "http://10.239.2.79:8085/SL_MMDC_API/inputcodesl"; // Ví dụ dùng JSONPlaceholder
                string apiUrl = "http://172.31.9.31:8080/SL_MMDC_API/inputcodesl"; // Ví dụ dùng JSONPlaceholder


                //string jsonPayload = JsonSerializer.Serialize(json);
                //var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync(apiUrl, content);

                
                response.EnsureSuccessStatusCode(); // Ném lỗi nếu không thành công

                string responseBody = await response.Content.ReadAsStringAsync();

                // Hiển thị phản hồi thành công
                //MessageBox.Show($"Done", "Thanh công", MessageBoxButtons.OK);
                //MessageBox.Show($"Dữ liệu đã được gửi thành công!\nMã trạng thái: {response.StatusCode}\nPhản hồi: {responseBody}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (HttpRequestException ex)
            {
                // Xử lý lỗi HTTP
                MessageBox.Show($"Lỗi HTTP: {ex.Message}\nChi tiết: {ex}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Xử lý các lỗi khác
                MessageBox.Show($"Đã xảy ra lỗi không mong muốn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void barcode_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {
                try
                {
                    // item   lot   sl
                    string Get_text_barcode = barcode_textBox.Text;
                    string itemcode = "";
                    string prod_line = "";
                    if (Get_text_barcode.Length > 26 && Get_text_barcode.Length < 35)
                    {
                        // Tách chuỗi theo các đoạn chỉ số
                        string get_gs1_code = Get_text_barcode.Substring(2, 15 - 2 + 1); // Từ index 3 đến 16 code gs1
                        string expiration_date = Get_text_barcode.Substring(17, 23 - 17 + 1); // Từ index 16 đến 24 ngày hết hạn
                        string get_lot = Get_text_barcode.Substring(26); // Từ index 26 đến hết só lot

                        string get_itemandlot = "SELECT [category] ,[itemCode] FROM [ItemMaster] where cartonBox = @cartonBox";
                        SqlParameter[] codegs1 = {
                                new SqlParameter("@cartonBox", get_gs1_code)
                            };

                        DataTable gs1data = conn_db_gs1.ExecuteQuery(get_itemandlot, codegs1);
                        prod_line = gs1data.Rows[0]["category"].ToString();
                        itemcode = gs1data.Rows[0]["itemCode"].ToString();

                        if (get_lot.Length < 7)
                        {
                            MessageBox.Show("Lot không hợp lệ, Vui lòng kiểm tra lại.", "Thông Báo");
                            barcode_textBox.Text = "";
                            return;
                        }
                        // lấy số lot theo thứ tự của lot
                        char type_lot = get_lot[6];
                        string item = itemcode;
                        string lot = get_lot;
                        string get_Degassing_time = $"{Degassing_time(item,machineno, type_lot)}";
                        if (data_view_desg_time.Rows.Count > 1 ||
                                        (data_view_desg_time.Rows.Count == 1 && !data_view_desg_time.Rows[0].IsNewRow))
                        {
                            // Dictionary để nhóm lot theo pallet
                            Dictionary<string, HashSet<string>> palletToLots = new Dictionary<string, HashSet<string>>();
                            Dictionary<string, HashSet<string>> itemclot = new Dictionary<string, HashSet<string>>();

                            foreach (DataGridViewRow row in data_view_desg_time.Rows)
                            {
                                // Không bỏ qua hàng mới
                                string palletValue = row.Cells["no_palet"].Value?.ToString(); // Cột xác định pallet
                                string itemValue = row.Cells["Item"].Value?.ToString(); // Cột item
                                string lotValue = row.Cells["lot"].Value?.ToString(); // Cột lot

                                // Kiểm tra giá trị hợp lệ
                                if (!string.IsNullOrEmpty(palletValue) && !string.IsNullOrEmpty(lotValue))
                                {
                                    // Nếu pallet chưa có trong dictionary, tạo mới HashSet
                                    if (!palletToLots.ContainsKey(palletValue))
                                    {
                                        palletToLots[palletValue] = new HashSet<string>();
                                    }
                                    // Thêm lot vào HashSet của pallet
                                    palletToLots[palletValue].Add(lotValue);
                                }
                                // Kiểm tra giá trị hợp lệ
                                if (!string.IsNullOrEmpty(palletValue) && !string.IsNullOrEmpty(itemValue))
                                {
                                    // Nếu pallet chưa có trong dictionary, tạo mới HashSet
                                    if (!itemclot.ContainsKey(palletValue))
                                    {
                                        itemclot[palletValue] = new HashSet<string>();
                                    }
                                    // Thêm lot vào HashSet của pallet
                                    itemclot[palletValue].Add(itemValue);
                                }
                            }

                            // Kiểm tra từng pallet
                            foreach (var pallet in palletToLots)
                            {
                                if (pallet.Value.Count >= 5 && pallet.Key == Nopalet) // Nếu pallet có quá 5 lot khác nhau
                                {
                                    MessageBox.Show($"Pallet {pallet.Key} đã có {pallet.Value.Count} lot. Một pallet tối đa chỉ được chứa 5 lot khác nhau.",
                                                    "Lưu ý...!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    barcode_textBox.Focus();
                                    barcode_textBox.SelectAll();
                                    return;
                                }
                            }


                            // Kiểm tra từng pallet
                            foreach (var pallet in itemclot)
                            {
                                if (pallet.Value.Count >= 5 && pallet.Key == Nopalet) // Nếu pallet có quá 5 lot khác nhau
                                {
                                    MessageBox.Show($"Pallet {pallet.Key} đã có {pallet.Value.Count} sản phẩm. Một pallet tối đa chỉ được chứa 5 sản phẩm khác nhau.",
                                                    "Lưu ý...!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    barcode_textBox.Focus();
                                    barcode_textBox.SelectAll();
                                    return;
                                }
                            }






                            // Nếu tất cả pallet đều hợp lệ
                            //MessageBox.Show("Tất cả pallet đều có tối đa 3 lot khác nhau.", "Thông Báo");
                            //// Kiểm tra số lượng pallet duy nhất
                            //HashSet<string> uniquelot = new HashSet<string>();
                            //foreach (DataGridViewRow row in dataGridView1.Rows)
                            //{
                            //    if (row.IsNewRow) continue; // Bỏ qua hàng mới
                            //    string palletValue = row.Cells["lot"].Value?.ToString();
                            //    if (!string.IsNullOrEmpty(palletValue))
                            //    {
                            //        uniquelot.Add(palletValue);
                            //    }
                            //}

                            //// Kiểm tra giới hạn 3 lot khác nhau
                            //if (uniquelot.Count >= 3)
                            //{
                            //    MessageBox.Show("Một palet tối đa chỉ được chứa 3 lot  khác nhau. Hiện tại đã có "
                            //                    + uniquelot.Count + " lot khác nhau.", "Lưu ý...!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //    barcode_textBox.Focus();
                            //    barcode_textBox.SelectAll();
                            //    return;
                            //}

                            // Kiểm tra xem có lot khác thời gian thoát khí trong một mẻ không !
                            //bool check_wh = false;
                            //string referenceDegassingTime = dataGridView1.Rows[0].Cells["wh_a"].Value?.ToString();

                            foreach (DataGridViewRow row in data_view_desg_time.Rows)
                            {

                                string wh_A_Value = row.Cells["wh_a"].Value?.ToString();
                                string wh_B_Value = row.Cells["wh_b"].Value?.ToString();
                                string wh_C_Value = row.Cells["wh_c"].Value?.ToString();
                                //MessageBox.Show($"value  = {get_Degassing_time},whA = {wh_A_Value}, whB = {wh_B_Value}, whC = {wh_C_Value}", "Thông Báo.");
                                if (!string.IsNullOrEmpty(wh_A_Value) && wh_A_Value != "0" && wh_A_Value != get_Degassing_time)
                                {
                                    MessageBox.Show("Mã này khác thời gian thoát khí trong mẻ, Vui lòng kiểm tra lại. ", "Thông Báo");
                                    return;
                                }
                                if (!string.IsNullOrEmpty(wh_B_Value) && wh_B_Value != "0" && wh_B_Value != get_Degassing_time)
                                {
                                    MessageBox.Show("Mã này khác thời gian thoát khí trong mẻ, Vui lòng kiểm tra lại. ", "Thông Báo");
                                    return;
                                }
                                if (!string.IsNullOrEmpty(wh_C_Value) && wh_C_Value != "0" && wh_C_Value != get_Degassing_time)
                                {
                                    MessageBox.Show("Mã này khác thời gian thoát khí trong mẻ, Vui lòng kiểm tra lại. ", "Thông Báo");
                                    return;
                                }


                            }

                        }
                        using (var inputForm = new input_from(item, lot))
                        {
                            sum_item = inputForm.SumItem;
                            //MessageBox.Show($"The sum_item value is: {sum_item}", "Result");
                            // Show input_from as a dialog (modal)
                            DialogResult result = inputForm.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                // Retrieve sum_item after the form is closed
                                sum_item = inputForm.SumItem;
                                MessageBox.Show($"The sum_item value is: {sum_item}", "Result");
                            }
                            else
                            {

                                sum_item = inputForm.SumItem;
                                //MessageBox.Show($"The sum_item value is: {sum_item}", "Result");
                                if (!int.TryParse(sum_item, out int number) || number <= 0)
                                {

                                    //inputForm.ShowDialog();
                                    MessageBox.Show($"Số Lượng không hợp lệ vui lòng nhập lại. ", "Lỗi");
                                    barcode_textBox.Text = "";
                                    barcode_textBox.Focus();
                                    return;
                                }
                                else
                                {
                                    //MessageBox.Show($"The sum_item value is: {sum_item}", "Result");
                                    sum_item = inputForm.SumItem;
                                    save_data.Enabled = true;
                                }
                               
                                //MessageBox.Show($"The sum_item value is: {sum_item}", "Result");
                            }
                        }
                        //MessageBox.Show($"The sum_item value 2 is: {sum_item}", "Result");


                        //string item = itemcode;
                        //string lot = get_lot;
                        int sl = int.Parse(sum_item);
                        string bacth_no = $"{getyear}EO-"+batchno_textbox.Text;
                        string kho = wh_cbx.Text;
                        

                        // Kiểm tra và cập nhật DataGridView
                        bool found = false;
                        foreach (DataGridViewRow row in data_view_desg_time.Rows)
                        {
                            //if (!row.IsNewRow && row.Cells["Item"].Value?.ToString() == item && row.Cells["Lot"].Value?.ToString() == lot && Nopalet == row.Cells["no_palet"].Value?.ToString())
                            if (!row.IsNewRow && (row.Cells["no_palet"].Value?.ToString() == Nopalet && row.Cells["Item"].Value?.ToString() == item && row.Cells["Lot"].Value?.ToString() == lot) || (row.Cells["Item"].Value?.ToString() == "0" || row.Cells["Lot"].Value?.ToString() == "0"))
                            {   
                                row.Cells["Item"].Value = item;
                                row.Cells["Batch_No"].Value = bacth_no;
                                row.Cells["Lot"].Value = lot;
                                row.Cells["Line_prod"].Value = prod_line;
                                row.Cells["sl"].Value = sl;

                                found = true;
                                if (kho == "A")
                                {
                                    row.Cells["wh_a"].Value = get_Degassing_time;
                                }
                                if (kho == "B")
                                {
                                    row.Cells["wh_b"].Value = get_Degassing_time;
                                }
                                if (kho == "C")
                                {
                                    row.Cells["wh_c"].Value = get_Degassing_time;
                                }
                                break;
                            }
                        }

                        if (!found)
                        {
                            if (kho == "A")
                            {
                                // Thêm dữ liệu vào DataGridView nếu không tìm thấy hàng trùng
                                data_view_desg_time.Rows.Add(Nopalet, bacth_no, item, prod_line, lot, sl, get_Degassing_time, 0, 0, machineno);

                            }
                            if (kho == "B")
                            {
                                // Thêm dữ liệu vào DataGridView nếu không tìm thấy hàng trùng
                                data_view_desg_time.Rows.Add(Nopalet, bacth_no, item, prod_line, lot, sl, 0, get_Degassing_time, 0, machineno);

                            }
                            if (kho == "C")
                            {
                                // Thêm dữ liệu vào DataGridView nếu không tìm thấy hàng trùng
                                data_view_desg_time.Rows.Add(Nopalet, bacth_no, item, prod_line, lot, sl, 0, 0, get_Degassing_time, machineno);

                            }

                        }
                        barcode_textBox.Text = "";
                    }
                    else if (data_view_desg_time.Rows[0].Cells[1].Value?.ToString() != null && barcode_textBox.Text.Trim() == "null")
                    {
                        
                        // lấy dữ liệu hàng đầu tiên của data gridview để so sánh
                        data_view_desg_time.Rows.Add(Nopalet, data_view_desg_time.Rows[0].Cells[1].Value, "(null)", "(null)", "(null)", "(null)", data_view_desg_time.Rows[0].Cells[6].Value, data_view_desg_time.Rows[0].Cells[7].Value, data_view_desg_time.Rows[0].Cells[8].Value, data_view_desg_time.Rows[0].Cells[9].Value);
                        //MessageBox.Show($"Pallet trống = {data_view_desg_time.Rows[0].Cells[6].Value}", "Thông Báo");
                        barcode_textBox.Text = "";
                    }

                    else if (data_view_desg_time.Rows[0].Cells[1].Value?.ToString() != null && barcode_textBox.Text.Trim() == "dummy")
                    {
                        //data_view_desg_time.Rows.Add(Nopalet, data_view_desg_time.Rows[0].Cells[1].Value, 0, 0, 0, 0, data_view_desg_time.Rows[0].Cells[6].Value, data_view_desg_time.Rows[0].Cells[7].Value, data_view_desg_time.Rows[0].Cells[8].Value, data_view_desg_time.Rows[0].Cells[9].Value);
                        //MessageBox.Show("Paletdumy", "Thông Báo");
                        using (var inputForm = new input_from("dummy", "0"))
                        {
                            sum_item = inputForm.SumItem;
                            //MessageBox.Show($"The sum_item value is: {sum_item}", "Result");
                            // Show input_from as a dialog (modal)
                            DialogResult result = inputForm.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                // Retrieve sum_item after the form is closed
                                sum_item = inputForm.SumItem;
                                MessageBox.Show($"The sum_item value is: {sum_item}", "Result");
                            }
                            else
                            {

                                sum_item = inputForm.SumItem;
                                //MessageBox.Show($"The sum_item value is: {sum_item}", "Result");
                                if (!int.TryParse(sum_item, out int number) || number <= 0)
                                {

                                    //inputForm.ShowDialog();
                                    MessageBox.Show($"Số Lượng không hợp lệ vui lòng nhập lại. ", "Lỗi");
                                    barcode_textBox.Text = "";
                                    barcode_textBox.Focus();
                                    return;
                                }
                                else
                                {
                                    //MessageBox.Show($"The sum_item value is: {sum_item}", "Result");
                                    sum_item = inputForm.SumItem;
                                    save_data.Enabled = true;
                                    data_view_desg_time.Rows.Add(Nopalet, data_view_desg_time.Rows[0].Cells[1].Value, "(dummy)", "null", "(null)", sum_item, data_view_desg_time.Rows[0].Cells[6].Value, data_view_desg_time.Rows[0].Cells[7].Value, data_view_desg_time.Rows[0].Cells[8].Value, data_view_desg_time.Rows[0].Cells[9].Value);
                                    barcode_textBox.Text = "";
                                }

                                //MessageBox.Show($"The sum_item value is: {sum_item}", "Result");
                            }
                        }
                    }
                    else if (data_view_desg_time.Rows[0].Cells[1].Value?.ToString() != null && barcode_textBox.Text.Trim() == "addpalet")
                    {
                        add_palet();
                    }
                    else
                    {
                        MessageBox.Show("Chuỗi không đúng định dạng.", "Thông Báo");
                        barcode_textBox.Text = "";
                    }
                }
                catch
                {
                    //MessageBox.Show("Chuỗi không đúng định dạng.", "Thông Báo 2");
                    barcode_textBox.Text = "";
                }
            }

        }
        private void export_csv()
        {
            try
            {
                DataGridViewRow firstRow = data_view_desg_time.Rows[0];
                if (firstRow.IsNewRow && data_view_desg_time.AllowUserToAddRows)
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
                        saveFileDialog.FileName = DateTime.Now.ToString("yy") + "EO" + batchno_textbox.Text.Trim() + DateTime.Now.ToString("yyMMddHHmmss"); // Tên file mặc định

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
                        foreach (DataGridViewRow row in data_view_desg_time.Rows)
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
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void export_data_btn(object sender, EventArgs e)
        {
            //export_csv();
            using (var input_from = new export_data(user_id))
            {
                this.Hide(); // Ẩn MainForm sau khi mở form quản lý dữ liệu
                input_from.ShowDialog(); // Hiển thị from quản lý dữ liệu
                this.Show(); // Hiển thị lại MainForm sau khi đóng form quản lý dữ liệu
            }
        }

        private void Nopalet_texbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!pallet_enter) return;

            // Chỉ cho phép nhập số và phím Backspace
            else if (Nopalet_texbox.Text.Length >= 7 && e.KeyChar != (char)Keys.Back)
            {
                    // Chặn ký tự đó lại
                    e.Handled = true;
            }

                if (e.KeyChar == (char)Keys.Enter)
                {
                    add_pallet_code();
                }
        
        }

        private void add_pallet_code()
        {
            try
            {
                string get_wh_air = wh_cbx.Text;
                string get_bacthno = $"{getyear}EO-" + batchno_textbox.Text;
                string Nopalets = Nopalet_texbox.Text;
                //string Nopalets = Nopalet_texbox.Text;
                Nopalet = Nopalet_texbox.Text.Length >= 5 ? Nopalet_texbox.Text.Substring(0, 5) : Nopalet_texbox.Text;
                string no_palets = Nopalet_texbox.Text;


                // mã palet phải là số và đúng 6 ký tự
                if (!int.TryParse(Nopalet, out int number) || number <= 0 || no_palets.Length != 6)
                    //if (no_palets.Length != 6)
                    //if (!int.TryParse(no_palets, out int number) || number > 0 || no_palets.Length == 6 || no_palets.Length < 0)
                    {
                    MessageBox.Show("Số palet không hợp lệ.", "Thông Báo");
                }
                else
                {
                    if (data_view_desg_time.Rows.Count > 1 || (data_view_desg_time.Rows.Count == 1 && !data_view_desg_time.Rows[0].IsNewRow))
                    {
                        // Kiểm tra số lượng pallet duy nhất
                        HashSet<string> uniquePallets = new HashSet<string>();
                        foreach (DataGridViewRow row in data_view_desg_time.Rows)
                        {
                            if (row.IsNewRow) continue; // Bỏ qua hàng mới
                            string palletValue = row.Cells["no_palet"].Value?.ToString();
                            if (palletValue != null && palletValue != "0") // Chỉ thêm pallet không phải "0"
                            {
                                uniquePallets.Add(palletValue);
                            }
                        }

                        // Kiểm tra giới hạn 7 pallet khác nhau
                        if (uniquePallets.Count >= 10)
                        {
                            MessageBox.Show("Một mẻ tối đa chỉ được chứa 10 số pallet khác nhau. Hiện tại đã có " + uniquePallets.Count + " pallet khác nhau.");
                            Nopalet_texbox.Focus();
                            Nopalet_texbox.SelectAll();
                            return;
                        }

                        bool isDuplicate = false;
                        foreach (DataGridViewRow row in data_view_desg_time.Rows)
                        {
                            if (row.IsNewRow) continue; // Bỏ qua hàng mới
                            string palletValue = row.Cells["no_palet"].Value?.ToString();
                            if (palletValue == Nopalet && palletValue != "0")
                            {
                                isDuplicate = true;
                                break; // Thoát ngay khi phát hiện trùng lặp
                            }
                        }

                        if (isDuplicate)
                        {
                            MessageBox.Show($"Số pallet {Nopalet} đã tồn tại trong bảng. Chỉ được thêm pallet chưa tồn tại.");
                            Nopalet_texbox.Focus();
                            Nopalet_texbox.SelectAll();
                        }
                        else
                        {
                            // nhập pallet mới thành công
                            barcode_textBox.ReadOnly = false;
                            //data_view_desg_time.Rows.Add(Nopalet, "0", "0", "0", "0", "0", "0", "0", "0", machineno);
                            data_view_desg_time.Focus();
                            barcode_textBox.Focus();
                            Nopalet_texbox.ReadOnly = true;
                            wh_cbx.Enabled = false;
                            batchno_textbox.ReadOnly = true;
                            palletadd_btn.Enabled = true;
                            start_input.Text = "Đang nhập thông tin sản phẩm";
                            start_input.BackColor = Color.Orange;
                            pallet_enter = false;
                            Nopalet_texbox.Text = Nopalet;
                        }
                    }
                    else
                    {
                        barcode_textBox.ReadOnly = false;
                        //data_view_desg_time.Rows.Add(Nopalet, "0", "0", "0", "0", "0", "0", "0", "0", machineno);
                        data_view_desg_time.Focus();
                        barcode_textBox.Focus();
                        Nopalet_texbox.ReadOnly = true;
                        wh_cbx.Enabled = false;
                        batchno_textbox.ReadOnly = true;
                        palletadd_btn.Enabled = true;
                        start_input.Text = "Đang nhập  thông tin sản phẩm";
                        start_input.BackColor = Color.Orange;
                        pallet_enter = false;
                        Nopalet_texbox.Text = Nopalet;
                    }
                   
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string Degassing_time(string item1, string machine, char lot)
        {

            string Degassing_time = "";
            //lấy thời gian thoát khí theo item và máy
            string get_time = "SELECT Degassing_time FROM [MASTER] where itemcode = @itemcode and status_item = @status_item and machine = @machine";
            SqlParameter[] parameters = { 
                new SqlParameter("@itemcode", item1), 
                new SqlParameter("@machine", machine),
                new SqlParameter("@status_item", 1),
            };
            DataTable result = DatabaseHelper.ExecuteQuery(get_time, parameters);
            
            //MessageBox.Show($"{result.Rows.Count}");
            //nếu k có thì báo lỗi
            if (result.Rows.Count == 0)
            {
               MessageBox.Show($"itemcode chưa được đăng kí.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Degassing_time = result.Rows[0]["Degassing_time"].ToString();
            //nếu có nhiều hơn 1 máy thì yêu cầu nhập lot để lấy đúng thời gian thoát khí
            if (result.Rows.Count > 1)
            {
                get_time += " and lot = @lot";
                SqlParameter[] parameters1 =
                { 
                new SqlParameter("@itemcode", item1),
                new SqlParameter("@machine", machine),
                new SqlParameter("@lot", lot),
                new SqlParameter("@status_item", 1),
                };

                DataTable result1 = DatabaseHelper.ExecuteQuery(get_time, parameters1);
                //Degassing_time = result1.Rows[0]["Degassing_time"].ToString();
                // nếu truy vấn ra 1 kết quả thì lấy thời gian thoát khí (trường hợp đặc biệt)

                if (result1.Rows.Count == 1)
                {
                    Degassing_time = result1.Rows[0]["Degassing_time"].ToString();
                }
                else
                {

                    get_time = "SELECT Degassing_time FROM [MASTER] where itemcode = @itemcode and status_item = @status_item and machine = @machine and lot = ''";
                    SqlParameter[] parameters2 = { 
                        new SqlParameter("@itemcode", item1), 
                        new SqlParameter("@machine", machine),
                        new SqlParameter("@status_item", 1),
                    };
                    DataTable result2 = DatabaseHelper.ExecuteQuery(get_time, parameters2);
                    Degassing_time =  result2.Rows[0]["Degassing_time"].ToString();
                }
            }
            return Degassing_time;

        }

        private void add_palet()
        {
            if (data_view_desg_time.Rows[0].Cells[1].Value?.ToString() == null)
            {
                MessageBox.Show("Pallet đang trống", "Lưu ý!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            barcode_textBox.ReadOnly = true;
            Nopalet_texbox.ReadOnly = false;
            Nopalet_texbox.Focus();
            barcode_textBox.Text = "";
            Nopalet_texbox.Text = "";
            start_input.BackColor = Color.Yellow;
            start_input.Text = "Đang nhập Pallet";

            pallet_enter = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
           add_palet();
        }
        private void clear_data()
        {
            // Xóa tất cả dữ liệu trong DataGridView
            data_view_desg_time.Rows.Clear();
            barcode_textBox.ReadOnly = true;
            Nopalet_texbox.ReadOnly = true;
            wh_cbx.Enabled = true;
            batchno_textbox.Focus();
            batchno_textbox.ReadOnly = false;
            Nopalet_texbox.Text = "";
            start_input.BackColor = Color.Lime;
            start_input.Enabled = true;
            save_data.Enabled = false;
            // mở lại sự kiện mẻ tt
            batno_enter = true;
            pallet_enter = false;

            start_input.Text = "Bắt đầu";
        }
        private void Clear_data_btn_Click(object sender, EventArgs e)
        {
            // Xác nhận trước khi xóa
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa tất cả dữ liệu không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult != DialogResult.Yes)
            {
                return; // Nếu người dùng chọn No, thoát khỏi hàm
            }
            Logger.Log("INFO", $"{user_id} reset mẻ {batchno_textbox.Text} lúc: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
            // Xóa tất cả dữ liệu trong DataGridView
            clear_data();
            //data_view_desg_time.Rows.Clear();
            //barcode_textBox.ReadOnly = true;
            //Nopalet_texbox.ReadOnly = true;
            //wh_cbx.Enabled = true;
            //batchno_textbox.Focus();
            //batchno_textbox.ReadOnly = false;
            //Nopalet_texbox.Text = "";
            //start_input.BackColor = Color.Lime;
            //start_input.Enabled = true;
            //save_data.Enabled = false;
            //// mở lại sự kiện mẻ tt
            //batno_enter = true;
            //pallet_enter = false;

            //start_input.Text = "Bắt đầu";
        }

        private void batchno_textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!batno_enter) return;
            if (e.KeyChar == (char)Keys.Enter)
            {
                input_batchno();
            }
            if (batchno_textbox.Text.Length >= 5 && e.KeyChar != (char)Keys.Back)
            {
                // Chặn ký tự đó lại
                e.Handled = true;
            }

        }

        // bắt đầu nhập pallet 
        public void input_batchno()
        {
            string get_bacthno = batchno_textbox.Text;
            batch_no = $"{getyear}EO-" + get_bacthno;

            //Kiểm tra định dạng xem đúng chưa
            if (!int.TryParse(get_bacthno, out int number) || number <= 0 || number >= 99999 || get_bacthno.Length <= 4)
            {
                MessageBox.Show($"Số mẻ tiệt trùng phải là số có dịnh dạng XXXXX ", "Lưu ý!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                batchno_textbox.Text = "";
            }

            
          
            else
            {
                // kiểm tra máy đã tồn tại chưa
                string getmachineno = batchno_textbox.Text.Trim();
                machineno = getmachineno.Substring(0, getmachineno.Length - 3);
                //lấy thời gian thoát khí theo item và máy
                string check_machine = "SELECT * FROM [MASTER] where machine = @machine";
                SqlParameter[] checkmachine = {
                new SqlParameter("@machine", machineno),
                };
                DataTable checkmachines = DatabaseHelper.ExecuteQuery(check_machine, checkmachine);
                if (checkmachines.Rows.Count == 0)
                {
                    MessageBox.Show($"Máy {machineno} chưa được đăng kí.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    batchno_textbox.Text = "";
                }
                else
                {
                    //kiểm tra số mẻ đã tồn tại chưa
                    string check_batchno = "SELECT * FROM [master_batchno] where batch_no = @batch_no";
                    SqlParameter[] data_batch_no = {
                     new SqlParameter("@batch_no", batch_no),
                    };
                    DataTable checkbatchno = DatabaseHelper.ExecuteQuery(check_batchno, data_batch_no);

                    if (checkbatchno.Rows.Count > 0)
                    {
                        MessageBox.Show($"Số mẻ {batch_no} đã tồn tại, Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        batchno_textbox.Text = "";
                        return;
                    }

                    // nếu chưa tồn tại thì cho phép nhập pallet

                    // chuyển sang nhập pallet
                    batchno_textbox.ReadOnly = true;
                    Nopalet_texbox.ReadOnly = false;
                    //batchno_textbox.Enabled = false;
                    Nopalet_texbox.Focus();
                    start_input.Enabled = false;
                    wh_cbx.Enabled = false;
                    start_input.BackColor = Color.Yellow;
                    //batchno_textbox.Enabled = false;
                    start_input.Text = "Đang nhập Pallet";

                    //cập nhật số mẻ vào sql
                    //UtilityFunctions.insert_batch_no(batch_no, name_user, "Mới đăng kí","0");
                    // khóa sự kiện nhập mẻ
                    batno_enter = false;
                    pallet_enter = true;
                    // viết log đang thực hiện:
                    Logger.Log("INFO", $"{user_id} Bắt đầu nhập mẻ {batchno_textbox.Text} vào lúc {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
                }
               


            }
        }
        public class SimpleProductData // Hoặc đặt tên gì đó phù hợp hơn
        {
            // Đảm bảo tên thuộc tính khớp với tên khóa JSON (có phân biệt chữ hoa/thường)
            public string palletNo { get; set; }
            public string batchNo { get; set; }
            public string itemCode { get; set; }
            public string line { get; set; }
            public string lot { get; set; }
            public string qty { get; set; }
            public string wha { get; set; }
            public string whb { get; set; }
            public string whc { get; set; }
            public string machineNo { get; set; }

            public string time { get; set; }
        }
        // Thêm hàm xử lý này vào class hoặc một Utility class nào đó trong dự án của bạn
        public static string ExtractAndTrimMachineNo(string fullBatchNo)
        {
            // Tìm vị trí của dấu '-'
            int indexOfDash = fullBatchNo.IndexOf('-');

            // Đảm bảo có dấu '-' và không nằm ở cuối chuỗi
            if (indexOfDash == -1 || indexOfDash == fullBatchNo.Length - 1)
            {
                // Trả về chuỗi rỗng hoặc giá trị mặc định nếu không hợp lệ
                // Bạn có thể cân nhắc ném ngoại lệ hoặc ghi log tùy theo yêu cầu
                return string.Empty;
            }

            // Lấy phần số sau dấu '-'
            string numberPart = fullBatchNo.Substring(indexOfDash + 1);

            // Bỏ 3 số cuối của phần số
            // Chúng ta không kiểm tra độ dài quá ngắn ở đây như bạn yêu cầu
            // VÌ VẬY, HÃY CẨN THẬN: NẾU numberPart CÓ ĐỘ DÀI DƯỚI 3, SẼ GÂY LỖI ArgumentOutOfRangeException
            if (numberPart.Length >= 3)
            {
                return numberPart.Substring(0, numberPart.Length - 3);
            }
            else
            {
                // Nếu numberPart quá ngắn (ví dụ "12"), bạn sẽ nhận được "" hoặc giá trị numberPart
                // Trong trường hợp này, vì yêu cầu là "bỏ 3 số cuối", nếu không đủ 3 số để bỏ, thì có thể trả về rỗng.
                return string.Empty; // Hoặc numberPart nếu bạn muốn giữ nguyên phần số ngắn này
            }
        }
        // --- Phương thức chuyển đổi DataGridView sang List<SimpleProductData> ---
        public List<SimpleProductData> ConvertDataGridViewToSimpleList(DataGridView dataGridViewSource)
        {
            List<SimpleProductData> simpleDataList = new List<SimpleProductData>();

            if (dataGridViewSource == null)
            {
                MessageBox.Show("DataGridView không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return simpleDataList;
            }

            int actualRowCount = dataGridViewSource.Rows.Count;
            if (dataGridViewSource.AllowUserToAddRows)
            {
                actualRowCount--;
            }

            if (actualRowCount <= 0)
            {
                MessageBox.Show("DataGridView không có dữ liệu để chuyển đổi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return simpleDataList;
            }

            foreach (DataGridViewRow row in dataGridViewSource.Rows)
            {
                if (row.IsNewRow)
                {
                    continue;
                }

                try
                {
                    // Ánh xạ dữ liệu từ DataGridViewCells sang SimpleProductData
                    // Đảm bảo chỉ số cột khớp với dữ liệu bạn muốn lấy
                    SimpleProductData data = new SimpleProductData
                    {
                        // Thay đổi chỉ số cột hoặc tên cột cho phù hợp với DataGridView của bạn
                        palletNo = row.Cells[0].Value?.ToString() ?? "", // Cột PalletNo
                        batchNo = row.Cells[1].Value?.ToString() ?? "",   // Cột BatchNo
                        itemCode = row.Cells[2].Value?.ToString() ?? "", // Cột ProductCode
                        line = row.Cells[3].Value?.ToString() ?? "",   // Cột ProductName
                        lot = row.Cells[4].Value?.ToString() ?? "",    // Cột Lot
                        qty = row.Cells[5].Value?.ToString() ?? "",  // Cột Quantity
                        wha = row.Cells[6].Value?.ToString() ?? "", // Cột wha
                        whb = row.Cells[7].Value?.ToString() ?? "", // Cột whb
                        whc = row.Cells[8].Value?.ToString() ?? "", // Cột whc
                        machineNo = row.Cells[9].Value?.ToString() ?? "", // Cột whc
                        //machineNo = (row.Cells[1].Value?.ToString() ?? "").Substring(0, (row.Cells[1].Value?.ToString() ?? "").Length - 3),
                        //machineNo = ExtractAndTrimMachineNo(row.Cells[1].Value?.ToString() ?? ""), // Áp dụng hàm xử lý
                        time = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") // Gán thời gian hiện tại
                        // Lưu ý: Các trường DegassingTime (6, 7, 8) sẽ không được lấy nếu bạn chỉ muốn cấu trúc này
                    };
                    simpleDataList.Add(data);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi đọc dữ liệu từ hàng: {row.Index + 1}.\nChi tiết: {ex.Message}\nHàng này sẽ bị bỏ qua.", "Lỗi dữ liệu hàng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    continue;
                }
            }

            if (simpleDataList.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu hợp lệ nào được tìm thấy để chuyển đổi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return simpleDataList;
        }
        private async void send_data()
        {
            // 1. Chuyển đổi DataGridView thành List các đối tượng SimpleProductData
            List<SimpleProductData> simpleDataToSend = ConvertDataGridViewToSimpleList(data_view_desg_time); // Thay 'dataGridView1'

            if (simpleDataToSend.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu hợp lệ để gửi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Chuyển List các đối tượng thành chuỗi JSON
            // Nếu bạn muốn gửi một MẢNG các đối tượng như: [{"palet":..}, {"palet":..}]
            string jsonString = JsonSerializer.Serialize(simpleDataToSend, new JsonSerializerOptions { WriteIndented = true });

            // Nếu bạn chỉ muốn gửi MỘT đối tượng đầu tiên (ví dụ, nếu API chỉ nhận 1 đối tượng một lần)
            // string jsonString = JsonSerializer.Serialize(simpleDataToSend[0], new JsonSerializerOptions { WriteIndented = true });

            // 3. Gửi chuỗi JSON qua API
            await api_send(jsonString);
        }
        private async void testapi(object sender, EventArgs e)
        {
            // 1. Chuyển đổi DataGridView thành List các đối tượng SimpleProductData
            List<SimpleProductData> simpleDataToSend = ConvertDataGridViewToSimpleList(data_view_desg_time); // Thay 'dataGridView1'

            if (simpleDataToSend.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu hợp lệ để gửi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Chuyển List các đối tượng thành chuỗi JSON
            // Nếu bạn muốn gửi một MẢNG các đối tượng như: [{"palet":..}, {"palet":..}]
            string jsonString = JsonSerializer.Serialize(simpleDataToSend, new JsonSerializerOptions { WriteIndented = true });

            // Nếu bạn chỉ muốn gửi MỘT đối tượng đầu tiên (ví dụ, nếu API chỉ nhận 1 đối tượng một lần)
            // string jsonString = JsonSerializer.Serialize(simpleDataToSend[0], new JsonSerializerOptions { WriteIndented = true });

            // 3. Gửi chuỗi JSON qua API
            await api_send(jsonString);
        }

        private void User_lbl_MouseEnter(object sender, EventArgs e)
        {
            user_lbl.ForeColor = Color.Red; // Màu chữ khi chuột vào
            user_lbl.BackColor = Color.Yellow; // Màu nền khi chuột vào

        }

        private void User_lbl_MouseLeave(object sender, EventArgs e)
        {
            user_lbl.ForeColor = Color.Black; // Màu chữ khi chuột ra
            user_lbl.BackColor = Color.White;
        }

        private void user_lbl_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                menuuser.Show(user_lbl, e.Location);
            }

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"ID: {user_id}\nHọ và Tên: {name_user} \nQuyền: {user_role}", "Thông Tin Người Dùng", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {

            using (var changePasswordForm = new chage_pasword(user_id, user_password))
            {
                changePasswordForm.ShowDialog(); // Hiển thị form đổi mật khẩu

                if (changePasswordForm.IsPasswordChanged)
                {
                    this.Close(); // Đóng MainForm nếu mật khẩu đã được đổi
                }

            }
            //MessageBox.Show($"Đổi mật khẩu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ĐăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.Close(); // Đóng input_data, quay lại LoginForm
            MessageBox.Show($"Đăng xuất thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"ID: {user_id}\nHọ và Tên: {name_user} \nQuyền: {user_role}", "Thông Tin Người Dùng", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ĐổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var changePasswordForm = new chage_pasword(user_id, user_password))
            {
                changePasswordForm.ShowDialog(); // Hiển thị form đổi mật khẩu

                if (changePasswordForm.IsPasswordChanged)
                {
                   
                    this.Close(); // Đóng MainForm nếu mật khẩu đã được đổi
                    Logger.Log("INFO", $"{user_id} Đổi mật khẩu thành công");

                }

            }
            //MessageBox.Show($"Đổi mật khẩu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ĐăngXuấtToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close(); // Đóng input_data, quay lại LoginForm
            MessageBox.Show($"Đăng xuất thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void quảnLíTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var usetr_ma = new user_ma())
            {
                this.Hide(); // Ẩn MainForm sau khi mở form quản lý tài khoản người dùng
                usetr_ma.ShowDialog(); // Hiển thị from quản lý tài khoản người dùng
                this.Show(); // Hiển thị lại MainForm sau khi đóng form quản lý tài khoản người dùng

            }
        }

        private void quảnLýDữLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var master_data = new from_master())
            {
                this.Hide(); // Ẩn MainForm sau khi mở form quản lý dữ liệu
                master_data.ShowDialog(); // Hiển thị from quản lý dữ liệu
                this.Show(); // Hiển thị lại MainForm sau khi đóng form quản lý dữ liệu


            }
        }

        private void traCứuLịchSửToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void delete1row(object sender, EventArgs e)
        {
            // xóa 1 hàng trong datagridview
            if (data_view_desg_time.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in data_view_desg_time.SelectedRows)
                {
                    if (!row.IsNewRow) // Đảm bảo không xóa hàng mới
                    {
                        data_view_desg_time.Rows.Remove(row);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hàng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            input_batchno();

        }

        private void add_pallet(object sender, EventArgs e)
        {
            add_pallet_code();
        }


     
        private void trans_login(object sender, EventArgs e)
        {
            using (var trans = new tra_cuu_log())
            {
                this.Hide(); // Ẩn MainForm sau khi mở form tra cứu lịch sử
                trans.ShowDialog(); // Hiển thị from tra cứu lịch sử
                this.Show(); // Hiển thị lại MainForm sau khi đóng form tra cứu lịch sử
            }
        }

        private void master_history(object sender, EventArgs e)
        {
            using (var his_master = new his_master())
            {
                this.Hide(); // Ẩn MainForm sau khi mở form quản lý dữ liệu
                his_master.ShowDialog(); // Hiển thị from quản lý dữ liệu
                this.Show(); // Hiển thị lại MainForm sau khi đóng form quản lý dữ liệu
            }
        }

        private void dltk_history(object sender, EventArgs e)
        {
            using (var dltk = new his_data_tgtk())
            {
                this.Hide(); // Ẩn MainForm sau khi mở form quản lý dữ liệu
                dltk.ShowDialog(); // Hiển thị from quản lý dữ liệu
                this.Show(); // Hiển thị lại MainForm sau khi đóng form quản lý dữ liệu
            }
        }

        private void info_history(object sender, EventArgs e)
        {
            using (var info_his = new his_info_users())
            {
                this.Hide(); // Ẩn MainForm sau khi mở form quản lý dữ liệu
                info_his.ShowDialog(); // Hiển thị from quản lý dữ liệu
                this.Show(); // Hiển thị lại MainForm sau khi đóng form quản lý dữ liệu
            }
        }


        private void insert_data_desg_time()
        {
            // lấy dữ liệu của data grview đẩy vào sql
            foreach (DataGridViewRow row in data_view_desg_time.Rows)
            {
                if (row.IsNewRow) continue; // Bỏ qua hàng mới
                string palletNo = row.Cells[0].Value?.ToString() ?? "null"; // Pallet No (cột 0)
                string batchNo = row.Cells[1].Value?.ToString() ?? ""; // Batch No (cột 1)
                string productCode = row.Cells[2].Value?.ToString() ?? "";
                string line = row.Cells[3].Value?.ToString() ?? "";
                string lot = row.Cells[4].Value?.ToString() ?? "";
                string quantity = row.Cells[5].Value?.ToString() ?? "0";
                string degassingA = row.Cells[6].Value?.ToString() ?? "0";
                string degassingB = row.Cells[7].Value?.ToString() ?? "0";
                string degassingC = row.Cells[8].Value?.ToString() ?? "0";
                string machine = row.Cells[8].Value?.ToString() ?? "0";
                // Chuẩn bị câu lệnh SQL để chèn dữ liệu
                //MessageBox.Show($"{palletNo}, {batchNo}");
                UtilityFunctions.insert_data_desg_time(palletNo, batchNo, productCode, line, lot, quantity, degassingA, degassingB, degassingC, machine, user_id, name_user);
                UtilityFunctions.insert_history_data_desg_time(palletNo, batchNo, productCode, line, lot, quantity, degassingA, degassingB, degassingC, machine, user_id, name_user, "add");

            }
        }
        private void button2_Click_2(object sender, EventArgs e)
        {
            //kiểm tra xem có dữ liệu hay không?
            DataGridViewRow firstRow = data_view_desg_time.Rows[0];
            if (firstRow.IsNewRow && data_view_desg_time.AllowUserToAddRows)
            {
                MessageBox.Show("Không có dữ liệu thực sự để lưu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // hiện thông báo xác nhận
            if (MessageBox.Show("Bạn có chắc chắn muốn lưu dữ liệu không? \n Sau khi lưu dữ liệu hiện hành sẽ bị xóa hết", "Xác nhận lưu dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return; // Nếu người dùng chọn No, thoát khỏi hàm
            }
            //lưu số mẻ vào bảng master_batchno
            UtilityFunctions.insert_batch_no(batch_no, name_user, "Mới đăng kí","0");
            insert_data_desg_time();
            clear_data();
            // lấy tất cả dữ liệu trong datagrid view đẩy vào sql

        }

        private void main_from_Load(object sender, EventArgs e)
        {
            save_data.Enabled = false;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Phiên bản hiện tại đang là 1.0.0 ", "Thông tin phiên bản", MessageBoxButtons.OK, MessageBoxIcon.Information );
        }

        private void master_data_Click(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TWSL.Common;
using TWSL.Forms.main.SL.SL12;


namespace TWSL.Forms.main.SL.SL1
{
    public partial class InputSL12 : Form
    {
        private bool batno_enter = true;
        //private bool pallet_enter = false;
        public InputSL12()
        {

            InitializeComponent();
            Barcode.ReadOnly = true;
        }

        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ĐổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ĐăngXuấtToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void quảnLíTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void quảnLýDữLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void trans_login(object sender, EventArgs e)
        {

        }

        private void info_history(object sender, EventArgs e)
        {

        }

        private void master_history(object sender, EventArgs e)
        {

        }

        private void dltk_history(object sender, EventArgs e)
        {

        }

        private void Inputsl1_Load(object sender, EventArgs e)
        {
            Iduser.Text = TWSL.Common.AppData.Instance.CurrentUserId;
            Username.Text = TWSL.Common.AppData.Instance.CurrentUserName;
            BatchYear.Text = TWSL.Common.AppData.Instance.GenYearBatch;
            save_data.Enabled = false;
        }



        private void MoveBarrcode()
        {
            string get_bacthno = BatchNoTbx.Text;

            //Kiểm tra định dạng xem đúng chưa
            if (!int.TryParse(get_bacthno, out int number) || number <= 0 || number >= 99999 || get_bacthno.Length <= 4)
            {
                MessageBox.Show($"Số mẻ tiệt trùng phải là số có dịnh dạng XXXXX ", "Lưu ý!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                BatchNoTbx.Text = "";
                BatchNoTbx.Focus();
                return;
            }

            StatusBtn.Enabled = false;
            StatusBtn.BackColor = Color.LightGreen;
            Barcode.Focus();
            BatchNoTbx.ReadOnly = true;
            batno_enter = false;
            StatusBtn.Text = "Đang nhập mã vạch...";
            Barcode.ReadOnly = false;

            // Lưu số mẻ vào biến toàn cục
            AppData.Instance.Batch = SLFunc.getyearsave() + get_bacthno;
            AppData.Instance.MachineNo = SLFunc.getmachine_no(get_bacthno);
            //MessageBox.Show($"Số mẻ tiệt trùng đã được lưu: {AppData.Instance.Batch}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void StatusBtn_Click(object sender, EventArgs e)
        {
            MoveBarrcode();
        }

        private void BatchNoTbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!batno_enter) return;
            if (e.KeyChar == (char)Keys.Enter)
            {
                MoveBarrcode();
                //MessageBox.Show($"{BatchNoTbx.Text.Trim()}");
            }
            if (BatchNoTbx.Text.Length >= 5 && e.KeyChar != (char)Keys.Back)
            {
                // Chặn ký tự đó lại
                e.Handled = true;
            }
        }

        private void Barcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Get_text_barcode = Barcode.Text.Trim();
            string sum_item = "";
            if (e.KeyChar != (char)Keys.Enter) return;

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
                if (gs1data.Rows.Count == 0)
                {
                    MessageBox.Show("Mã GS1 không tồn tại trong hệ thống, Vui lòng kiểm tra lại.", "Thông Báo");
                    Barcode.Text = "";
                    return;
                }
                string prod_line = gs1data.Rows[0]["category"].ToString();
                string itemcode = gs1data.Rows[0]["itemCode"].ToString();

                if (get_lot.Length < 7)
                {
                    MessageBox.Show("Lot không hợp lệ, Vui lòng kiểm tra lại.", "Thông Báo");
                    Barcode.Text = "";
                    return;
                }

                using (var inputForm = new input_from(itemcode, get_lot))
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
                            Barcode.Text = "";
                            Barcode.Focus();
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
                DataBatchNo.Rows.Add(AppData.Instance.Batch, itemcode, prod_line, get_lot, sum_item, AppData.Instance.MachineNo);
                Barcode.Text = "";

            }
            else {
                MessageBox.Show("Chuỗi không đúng định dạng.", "Thông Báo");
                Barcode.Focus();
            }

        }

        private void Barcode_TextChanged(object sender, EventArgs e)
        {

        }

        private void Reset(object sender, EventArgs e)
        {
            // Xác nhận trước khi xóa
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa tất cả dữ liệu không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult != DialogResult.Yes)
            {
                return; // Nếu người dùng chọn No, thoát khỏi hàm
            }
            Logger.Log("INFO", $"{AppData.Instance.CurrentUserId} reset mẻ {AppData.Instance.Batch} lúc: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
            // Xóa tất cả dữ liệu trong DataGridView
            clear_data();

        }

        private void clear_data() {
            // Xóa tất cả dữ liệu trong DataGridView
            DataBatchNo.Rows.Clear();
            BatchNoTbx.ReadOnly = false;
            BatchNoTbx.Text = "";
            Barcode.ReadOnly = true;
            Barcode.Text = "";
            StatusBtn.Enabled = true;

            BatchNoTbx.Focus();

            batno_enter = true;

            StatusBtn.Text = "Bắt đầu";
        }

        private void Dellete(object sender, EventArgs e)
        {
            // xóa 1 hàng trong datagridview
            if (DataBatchNo.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in DataBatchNo.SelectedRows)
                {
                    if (!row.IsNewRow) // Đảm bảo không xóa hàng mới
                    {
                        DataBatchNo.Rows.Remove(row);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hàng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void save_data_Click(object sender, EventArgs e)
        {

            //kiểm tra xem có dữ liệu hay không?
            DataGridViewRow firstRow = DataBatchNo.Rows[0];
            if (firstRow.IsNewRow && DataBatchNo.AllowUserToAddRows)
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
            //UtilityFunctions.insert_batch_no(batch_no, name_user, "Mới đăng kí", "0");
            insert_data_desg_time();
            clear_data();
            // lấy tất cả dữ liệu trong datagrid view đẩy vào sql
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
    }
}

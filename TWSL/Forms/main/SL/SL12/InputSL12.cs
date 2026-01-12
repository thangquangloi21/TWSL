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
        }



        private void MoveBarrcode()
        {
            string get_bacthno = BatchNoTbx.Text;

            //Kiểm tra định dạng xem đúng chưa
            if (!int.TryParse(get_bacthno, out int number) || number <= 0 || number >= 99999 || get_bacthno.Length <= 4)
            {
                MessageBox.Show($"Số mẻ tiệt trùng phải là số có dịnh dạng XXXXX ", "Lưu ý!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                BatchNoTbx.Text = "";
                return;
            }

            StatusBtn.Enabled = false;
            StatusBtn.BackColor = Color.LightGreen;
            Barcode.Focus();
            BatchNoTbx.ReadOnly = false;
            batno_enter = false;
            StatusBtn.Text = "Đang nhập mã vạch...";
            Barcode.ReadOnly = false;

            // Lưu số mẻ vào biến toàn cục
            AppData.Instance.Batch = SLFunc.getyearsave() + get_bacthno;
            MessageBox.Show($"Số mẻ tiệt trùng đã được lưu: {AppData.Instance.Batch}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);



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
                string prod_line = gs1data.Rows[0]["category"].ToString();
                string itemcode = gs1data.Rows[0]["itemCode"].ToString();

                if (get_lot.Length < 7)
                {
                    MessageBox.Show("Lot không hợp lệ, Vui lòng kiểm tra lại.", "Thông Báo");
                    Barcode.Text = "";
                    return;
                }
            }


        }
    }
}

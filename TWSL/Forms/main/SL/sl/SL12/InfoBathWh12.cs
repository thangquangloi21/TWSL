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

namespace TWSL.Forms.main.SL.SL12
{
    public partial class InfoBathWh12 : Form
    {
        public InfoBathWh12()
        {
            InitializeComponent();
        }



        private void InfoBathWh12_Load(object sender, EventArgs e)
        {
            start_date.Value = DateTime.Now.AddDays(-1);
            updatedata();
        }
        private void updatedata()
        {
            string batch_no = batchno_texbox.Text.Trim();
            string userame = user_name_tbx.Text.Trim();

            string start = start_date.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string end = end_date.Value.ToString("yyyy-MM-dd HH:mm:ss");



            //MessageBox.Show($"Start: {start}, End: {end}");
            string sql_his_master = "SELECT DISTINCT BatchNo AS 'Số Mẻ', NameUser as 'Người tạo', CONVERT(DATE,DateTime) as 'Ngày tạo', FORMAT(DateTime,'HH:mm:ss') as 'Giờ tạo' , Status as 'Trạng Thái'  from InfoBatchNoF12 WHERE [DateTime] >= @start AND [DateTime] < @end ";
            if (!string.IsNullOrEmpty(batch_no))
            {
                sql_his_master += " AND BatchNo = @batch_no";
            }

            if (!string.IsNullOrEmpty(userame))
            {
                sql_his_master += " AND IdUser = @user_register";
            }

            SqlParameter[] data = new SqlParameter[]
        {
                            new SqlParameter("@batch_no", batch_no),
                            new SqlParameter("@user_register", userame),
                            new SqlParameter("@start", start),
                            new SqlParameter("@end", end),

        };
            DataTable result = DatabaseHelper.ExecuteQuery(sql_his_master, data);
            Displaybatch.DataSource = result;
        }

        private void donexoa()
        {
            batchno_dp.Text = "...";
            Userdp.Text = "...";
            Datedp.Text = "...";
            Statusdp.Text = "...";
        }

        private void Delbatch(object sender, EventArgs e)
        {
            string somett = batchno_dp.Text.Trim();
            if (somett == "...")
            {
                MessageBox.Show("Vui lòng chọn 1 mẻ để xóa", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // thông báo có muốn xóa mẻ này không?
            if (MessageBox.Show($"Bạn thực sự muốn xóa mẻ {somett} Không?", "Xác nhận",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                // xóa mẻ
                string update_query = "delete from InfoBatchNoF12 where BatchNo = @batch_no ";
                //MessageBox.Show($"Cập nhật thông tin người dùng với ID: {id_update}, Tên: {save_username_update}, Quyền: {role_update}, Trạng thái: {status_update}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SqlParameter[] updateParameters = new SqlParameter[]
                {
                    new SqlParameter("@batch_no", somett),

                };
                DatabaseHelper.ExecuteNonQuery(update_query, updateParameters);
                MessageBox.Show($"Xóa mẻ {somett} thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Logger.Log("INFO", $"{AppData.Instance.CurrentUserId} Xóa mẻ {somett}");

                updatedata();
                donexoa();
            }
        }

        private void viewData(object sender, EventArgs e)
        {
            string somett = batchno_dp.Text.Trim();
            if (somett == "...")
            {
                MessageBox.Show("Vui lòng chọn 1 mẻ để xem", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var info_batchno_f12 = new DpBatch12(somett);
            info_batchno_f12.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            updatedata();
        }

        private void Displaybatch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = Displaybatch.Rows[e.RowIndex];
                
                //string bat = row.Cells["time_register"].Value.ToString();
                // Gán dữ liệu từ các cột vào label
                DateTime ngayTao = Convert.ToDateTime(row.Cells["Ngày Tạo"].Value);
                batchno_dp.Text = row.Cells["Số Mẻ"].Value.ToString();
                Userdp.Text = row.Cells["Người Tạo"].Value.ToString();
                Datedp.Text = ngayTao.ToString("dd/MM/yyyy");
                Statusdp.Text = row.Cells["Trạng Thái"].Value.ToString();
                //Console.WriteLine($"{bat}");

            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}

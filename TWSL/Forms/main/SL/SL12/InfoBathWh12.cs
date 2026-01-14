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

        }
        private void updatedata()
        {
            string batch_no = batchno_texbox.Text.Trim();
            string userame = user_name_tbx.Text.Trim();

            string start = start_date.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string end = end_date.Value.ToString("yyyy-MM-dd HH:mm:ss");



            //MessageBox.Show($"Start: {start}, End: {end}");
            string sql_his_master = "SELECT [batch_no] ,[user_register] ,[time_register]  ,[status] ,[number_export] FROM [DB_SL].[dbo].[master_batchno] WHERE [time_register] >= @start AND [time_register] < @end ";
            if (!string.IsNullOrEmpty(batch_no))
            {
                sql_his_master += " AND batch_no = @batch_no";
            }

            if (!string.IsNullOrEmpty(userame))
            {
                sql_his_master += " AND [user_register] = @user_register";
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
            // Gán tên hiển thị cho các cột
            Displaybatch.Columns["batch_no"].HeaderText = "Số mẻ";
            Displaybatch.Columns["user_register"].HeaderText = "Người tạo";
            Displaybatch.Columns["time_register"].HeaderText = "Thời gian tạo";
            Displaybatch.Columns["status"].HeaderText = "Trạng Thái";
            Displaybatch.Columns["number_export"].HeaderText = "Số lần đã xuất dữ liệu";
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
                string update_query = "delete from master_batchno where batch_no = @batch_no " +
                    "delete from [data_degassing_time] where batch_no =  @batch_no";
                //MessageBox.Show($"Cập nhật thông tin người dùng với ID: {id_update}, Tên: {save_username_update}, Quyền: {role_update}, Trạng thái: {status_update}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SqlParameter[] updateParameters = new SqlParameter[]
                {
                    new SqlParameter("@batch_no", somett),

                };
                DatabaseHelper.ExecuteNonQuery(update_query, updateParameters);
                MessageBox.Show($"Xóa mẻ {somett} thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Logger.Log("INFO", $"{AppData.Instance.CurrentUserId} Xóa mẻ {somett}");

                updatedata();
                //donexoa();
            }
        }
    }
}

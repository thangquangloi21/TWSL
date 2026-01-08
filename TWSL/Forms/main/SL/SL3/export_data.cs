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

namespace TWSL.Forms.main
{
    public partial class export_data : Form
    {
        string users = "";
        public export_data(string user)
        {
            InitializeComponent();
            users = user;

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
            data_view.DataSource = result;
            // Gán tên hiển thị cho các cột
            data_view.Columns["batch_no"].HeaderText = "Số mẻ";
            data_view.Columns["user_register"].HeaderText = "Người tạo";
            data_view.Columns["time_register"].HeaderText = "Thời gian tạo";
            data_view.Columns["status"].HeaderText = "Trạng Thái";
            data_view.Columns["number_export"].HeaderText = "Số lần đã xuất dữ liệu";

        } 
 
        private void from_load(object sender, EventArgs e)
        {
            start_date.Value = DateTime.Today;
            end_date.Value = end_date.Value = DateTime.Today.AddDays(1);
            updatedata();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            updatedata();
        }

        private void Userdata_view_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (data_view == false)
            //{
            //    return;
            //}
            // Kiểm tra dòng được chọn có hợp lệ không
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = data_view.Rows[e.RowIndex];
               
                string bat = row.Cells["time_register"].Value.ToString();
                // Gán dữ liệu từ các cột vào label
                batchno_dp.Text = row.Cells["batch_no"].Value.ToString();
                user_dp.Text = row.Cells["user_register"].Value.ToString();
                date_dp.Text = row.Cells["time_register"].Value.ToString();
                status_dp.Text = row.Cells["status"].Value.ToString();
                Console.WriteLine($"{bat}");
                
            }
        }

        private  void donexoa()
        {
            batchno_dp.Text = "...";
            user_dp.Text = "...";
            date_dp.Text = "...";
            status_dp.Text = "...";
        }

        private void xoa_mett()
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
                Logger.Log("INFO", $"{users} Xóa mẻ {somett}");

                updatedata();
                donexoa();
            }
            

        }
        private void xoa_me(object sender, EventArgs e)
        {
            xoa_mett();
        }

        private void showinffo(object sender, EventArgs e)
        {
            if (batchno_dp.Text.Trim() == "...")
            {
                MessageBox.Show($"phải chọn 1 mẻ để xem.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using (var infoForm = new info_batchno(batchno_dp.Text.Trim(), false))
            {
                infoForm.Text = $"Thông tin mẻ: {batchno_dp.Text.Trim()}";
                infoForm.ShowDialog();
            }
        }

        private void export_csv(object sender, EventArgs e)
        {
            if (batchno_dp.Text.Trim() == "...")
            {
                MessageBox.Show($"phải chọn 1 mẻ để xuất dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
                using (var infoForm = new info_batchno(batchno_dp.Text.Trim(),true))
            {
                infoForm.Text = $"Xuất dữ liệu mẻ: {batchno_dp.Text.Trim()}";
                infoForm.ShowDialog();
                updatedata();
            }
        }
    }
}

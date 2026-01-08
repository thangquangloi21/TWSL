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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace TWSL.Forms.history
{
    public partial class his_info_users : Form
    {
        public his_info_users()
        {
            InitializeComponent();
            Logger.Log("INFO", $"{AppData.Instance.CurrentUserId} tra cứu history master vào lúc {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
        }
        private void updatedata()
        {
            try
            {
                string id_code = id_user.Text.Trim();
                string name_user = user_name.Text.Trim();

                string start = start_date.Value.ToString("yyyy-MM-dd HH:mm:ss");
                string end = end_date.Value.ToString("yyyy-MM-dd HH:mm:ss");
                //MessageBox.Show($"Start: {start}, End: {end}");
                string sql_his_master = "SELECT [reason] ,[id] ,[username] ,[role] ,[status] ,[performer_id] ,[performer_name] ,[performer_date] ,[note] FROM [history_users] WHERE performer_date >= @start AND performer_date < @end ";
                if (!string.IsNullOrEmpty(id_code))
                {
                    sql_his_master += " AND id_code = @id_code";
                }

                if (!string.IsNullOrEmpty(name_user))
                {
                    sql_his_master += " AND username like @name_user";
                }

                SqlParameter[] data = new SqlParameter[]
            {
                            new SqlParameter("@id_code", id_code),
                            new SqlParameter("@start", start),
                            new SqlParameter("@end", end),
                            new SqlParameter("@name_user", $"%{name_user}%"),
                //new SqlParameter("@lot", ),
            };
                DataTable result = DatabaseHelper.ExecuteQuery(sql_his_master, data);
                dataGridView1.DataSource = result;
                //// Gán tên hiển thị cho các cột
                dataGridView1.Columns["reason"].HeaderText = "Lý do";
                dataGridView1.Columns["id"].HeaderText = "Mã nhân viên";
                dataGridView1.Columns["username"].HeaderText = "Tên nhân viên";
                dataGridView1.Columns["role"].HeaderText = "Quyền";
                dataGridView1.Columns["status"].HeaderText = "Trạng Thái";
                dataGridView1.Columns["performer_id"].HeaderText = "ID người Thay đổi";
                dataGridView1.Columns["performer_name"].HeaderText = "Tên người Đăng kí/Thay đổi";
                dataGridView1.Columns["performer_date"].HeaderText = "Ngày thay đổi";
                dataGridView1.Columns["note"].HeaderText = "Note";

            }
            catch
            {
                MessageBox.Show("Lỗi kết nối dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tim_kiem(object sender, EventArgs e)
        {
            updatedata();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void his_info_users_Load(object sender, EventArgs e)
        {
            start_date.Value = DateTime.Today;
            end_date.Value = end_date.Value = DateTime.Today.AddDays(1);
            updatedata();

        }
    }
}

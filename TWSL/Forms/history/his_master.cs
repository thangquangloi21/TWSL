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

namespace TWSL.Forms.history
{
    public partial class his_master : Form
    {
        public his_master()
        {
            InitializeComponent();
            Logger.Log("INFO", $"{AppData.Instance.CurrentUserId} tra cứu history master vào lúc {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
        }
        private void updatedata()
        {
            string itemcode = itemcode_search.Text.Trim();
            string start = start_date.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string end= end_date.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string machine = machine_search.Text.Trim();
            //MessageBox.Show($"Start: {start}, End: {end}");2025-03-10 08:38:24.000
            string sql_his_master = "SELECT  TOP (100) [reason] ,[itemcode] ,[generic] ,[machine] ,[lot] ,[Degassing_time] ,[registrant] ,[time_of_registration] ,[approver] ,[time_of_approval] ,[status_item] ,[note], [date] FROM [history_master] WHERE date >= @start AND date <= @end ";
            if (!string.IsNullOrEmpty(itemcode))
            {
                sql_his_master += " AND itemcode = @itemcode";
            }

            if (!string.IsNullOrEmpty(machine))
            {
                sql_his_master += " AND machine = @machine";
            }

            SqlParameter[] data = new SqlParameter[]
        {
                            new SqlParameter("@itemcode", itemcode),
                            new SqlParameter("@start", start),
                            new SqlParameter("@end", end),
                            new SqlParameter("@machine", machine)
        };
            DataTable result = DatabaseHelper.ExecuteQuery(sql_his_master, data);
            dataGridView1.DataSource = result;
            // Gán tên hiển thị cho các cột
            dataGridView1.Columns["itemcode"].HeaderText = "Mã sản phẩm";
            dataGridView1.Columns["generic"].HeaderText = "Chủng loại";
            dataGridView1.Columns["machine"].HeaderText = "Máy";
            dataGridView1.Columns["lot"].HeaderText = "Lot";
            dataGridView1.Columns["Degassing_time"].HeaderText = "Thời gian thoát khí(Giờ)";
            dataGridView1.Columns["registrant"].HeaderText = "Người đăng kí";
            dataGridView1.Columns["time_of_registration"].HeaderText = "Thời gian đăng kí";
            dataGridView1.Columns["approver"].HeaderText = "Người phê duyệt";
            dataGridView1.Columns["time_of_approval"].HeaderText = "Thời gian phê duyệt";
            dataGridView1.Columns["status_item"].HeaderText = "Trạng thái";
        }

        private void his_master_Load(object sender, EventArgs e)
        {
            start_date.Value = DateTime.Today;
            end_date.Value = end_date.Value = DateTime.Today.AddDays(1);
            updatedata();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            updatedata();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

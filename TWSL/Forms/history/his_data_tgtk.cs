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

namespace TWSL.Forms.history
{
    public partial class his_data_tgtk : Form
    {
        public his_data_tgtk()
        {
            InitializeComponent();

        }
        private void updatedata()
        {
            string batch_no = some_tt.Text.Trim();
            string userame = id_thaotac.Text.Trim();

            string start = start_date.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string end = end_date.Value.ToString("yyyy-MM-dd HH:mm:ss");



            //MessageBox.Show($"Start: {start}, End: {end}");
            string sql_his_master = "SELECT TOP (1000) [palletno],[batch_no] ,[itemcode] ,[line] ,[lotnumber] ,[quantity] ,[degassing_time_wha] ,[degassing_time_whb] ,[degassing_time_whc] ,[machineno] ,[input_time] ,[id_user] ,[name_user] ,[note]  FROM [history_data_degassing_time] WHERE [input_time] >= @start AND [input_time] < @end ";
            if (!string.IsNullOrEmpty(batch_no))
            {
                sql_his_master += " AND batch_no = @batch_no";
            }

            if (!string.IsNullOrEmpty(userame))
            {
                sql_his_master += " AND [id_user] = @user_register";
            }

            SqlParameter[] data = new SqlParameter[]
        {
                            new SqlParameter("@batch_no", batch_no),
                            new SqlParameter("@user_register", userame),
                            new SqlParameter("@start", start),
                            new SqlParameter("@end", end),

        };
            DataTable result = DatabaseHelper.ExecuteQuery(sql_his_master, data);
            data_tk.DataSource = result;
            // Gán tên hiển thị cho các cột
            data_tk.Columns["palletno"].HeaderText = "Số Pallet";
            data_tk.Columns["batch_no"].HeaderText = "Số mẻ";
            data_tk.Columns["itemcode"].HeaderText = "Mã sản phẩm";
            data_tk.Columns["line"].HeaderText = "Line";
            data_tk.Columns["lotnumber"].HeaderText = "LOT";
            data_tk.Columns["quantity"].HeaderText = "Số Lượng";
            data_tk.Columns["degassing_time_wha"].HeaderText = "Thời gian thoát khí(A)";
            data_tk.Columns["degassing_time_whb"].HeaderText = "Thời gian thoát khí(B)";
            data_tk.Columns["degassing_time_whc"].HeaderText = "Thời gian thoát khí(C)";
            data_tk.Columns["machineno"].HeaderText = "Máy";
            data_tk.Columns["input_time"].HeaderText = "Thời gian nhập";
            data_tk.Columns["id_user"].HeaderText = "ID người thao tác";
            data_tk.Columns["name_user"].HeaderText = "Tên người thao tác";
            data_tk.Columns["note"].HeaderText = "Note";

        }

        private void his_data_tgtk_Load(object sender, EventArgs e)
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
            Close();
        }
    }
}

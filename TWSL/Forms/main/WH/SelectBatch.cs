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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace TWSL.Forms.main.WH
{
    public partial class SelectBatch : Form
    {
        string ItemCode = "";
        string ProdLot = "";
        public SelectBatch(string item, string lot)
        {
            InitializeComponent();
            ItemCode = item;
            ProdLot = lot;
        }

        private void SelectBatch_Load(object sender, EventArgs e)
        {
            string sql_his_master = "  Select DISTINCT [BatchNo] as 'Số Mẻ',[ItemCode] as 'Tên sản phẩm', [ProdLot] as 'Lot',[ProdLine] as 'Bộ Phận',[Quantity] as 'Số Lượng', [Machine] as 'Máy', [DateTime] as 'Thời gian'  from [InfoBatchNoF12] where ItemCode = @ItemCode and ProdLot = @ProdLot";

            SqlParameter[] data = new SqlParameter[]
        {
                            new SqlParameter("@ItemCode", ItemCode),
                            new SqlParameter("@ProdLot", ProdLot),

        };
            DataTable result = DatabaseHelper.ExecuteQuery(sql_his_master, data);
            dataview.DataSource = result;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataview.Rows[e.RowIndex];

                //string bat = row.Cells["time_register"].Value.ToString();
                // Gán dữ liệu từ các cột vào label
                DateTime ngayTao = Convert.ToDateTime(row.Cells["Thời gian"].Value);
                bathno_dp.Text = row.Cells["Số Mẻ"].Value.ToString();
                Item_dp.Text = row.Cells["Tên sản phẩm"].Value.ToString();
                Prod_dp.Text = row.Cells["Bộ Phận"].Value.ToString();
                Lot_dp.Text = row.Cells["Lot"].Value.ToString();
                Machine_dp.Text = row.Cells["Máy"].Value.ToString();
                Date_Create.Text = ngayTao.ToString("HH:mm dd/MM/yyyy");

            }
        }

        private void select_ok(object sender, EventArgs e)
        {
            // lấy mẻ đó ra để xem thời gian thoát khí
            MessageBox.Show($"Bạn đã chọn mẻ {bathno_dp.Text.Trim()}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}

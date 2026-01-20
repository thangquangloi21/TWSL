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
            string sql_his_master = "  Select DISTINCT [BatchNo],[ItemCode],[ProdLine],[ProdLot],[Quantity], [Machine], [DateTime]  from [InfoBatchNoF12] where ItemCode = @ItemCode and ProdLot = @ProdLot";

            SqlParameter[] data = new SqlParameter[]
        {
                            new SqlParameter("@ItemCode", ItemCode),
                            new SqlParameter("@ProdLot", ProdLot),

        };
            DataTable result = DatabaseHelper.ExecuteQuery(sql_his_master, data);
            dataGridView1.DataSource = result;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

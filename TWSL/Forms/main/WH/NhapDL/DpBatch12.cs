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

namespace TWSL.Forms.main.SL.SL12
{
   
    public partial class DpBatch12 : Form
    {
        string batch = "";
        public DpBatch12(string batchno)
        {
            InitializeComponent();
            batch = batchno;
        }

        private void DpBatch12_Load(object sender, EventArgs e)
        {

            string sql = "SELECT [BatchNo] ,[ItemCode] ,[ProdLine] ,[ProdLot] ,[Quantity] ,[Machine] ,[Status] FROM [TWSL].[dbo].[InfoBatchNoF12] where BatchNo = @batch_no";
            SqlParameter[] data = new SqlParameter[]
      {
                            new SqlParameter("@batch_no", batch),

      };
            DataTable result = DatabaseHelper.ExecuteQuery(sql, data);

            data_view_dp.DataSource = result;
        }
    }
}

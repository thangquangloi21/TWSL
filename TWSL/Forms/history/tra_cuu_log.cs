using Org.BouncyCastle.Crypto.IO;
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

namespace TWSL
{
    public partial class tra_cuu_log : Form
    {
        public tra_cuu_log(string username)
        {
            InitializeComponent();
            //this.username = username;
            Logger.Log("INFO", $"{username} tra cứu log vào lúc {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            updatedata();
        }

        private void updatedata()
        {
            string info = info_search.Text.Trim();
            string getdata_login = "SELECT [Id] ,[LogDate] ,[LogLevel] ,[Message] ,[Exception] FROM [DB_SL].[dbo].[LogSystem] WHERE LogDate >= @start AND LogDate < @end";
             if (!string.IsNullOrEmpty(info))
            {
                getdata_login += " AND (Message LIKE @inf OR Exception LIKE @inf)";
            }    

                SqlParameter[] data = new SqlParameter[]
            {
                            new SqlParameter("@inf", $"%{info}%"),
                            new SqlParameter("@start", start_date.Value.ToString("yyyy-MM-dd HH:mm:ss")),
                            new SqlParameter("@end", end_date.Value.ToString("yyyy-MM-dd HH:mm:ss")),
                            //new SqlParameter("@lot", ),
            };
            DataTable result = DatabaseHelper.ExecuteQuery(getdata_login, data);
            dataGridView1.DataSource = result;
        }

        private void tra_cuu_log_Load(object sender, EventArgs e)
        {
            start_date.Value = DateTime.Today;
            end_date.Value = end_date.Value = DateTime.Today.AddDays(1);

        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

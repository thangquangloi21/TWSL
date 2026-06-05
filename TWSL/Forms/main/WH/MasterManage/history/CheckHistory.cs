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

namespace TWSL.Forms.main.WH.MasterManage.history
{
    public partial class CheckHistory : Form
    {
        private static string ChucNangTraCuu = "LogSystem";
        public CheckHistory()
        {
            InitializeComponent();
        }

        private void LogSystemBtn_Click(object sender, EventArgs e)
        {
            ChucNangTraCuuLbl.Text = "TRA CỨU LỊCH SỬ HỆ THỐNG (LOG SYSTEM) ";
            ChucNangTraCuu = "LogSystem";

        }

        private void LichSuGiaoDichBtn_Click(object sender, EventArgs e)
        {
            ChucNangTraCuuLbl.Text = "TRA CỨU LỊCH SỬ GIAO DỊCH";
            ChucNangTraCuu = "TraCuuGiaoDich";

        }

        private void TimKiemDuLieu_Click(object sender, EventArgs e)
        {
            updatedata();
        }

        private void updatedata()
        {
            if(ChucNangTraCuu == "LogSystem")
            {
                // load data log system
                Console.WriteLine("Logsytem");
                Loadlogdata();

            }
            else if (ChucNangTraCuu == "TraCuuGiaoDich")
            {
                // load data lịch sử giao dịch
                Console.WriteLine("Lịch sử giao dịch");

            }
        }

        private void Loadlogdata()
        {
            try
            {
                var sql = "";
                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@ngaytao", '')
                };
                //if (!string.IsNullOrEmpty('id'))
                //{
                //    sql += "AND IdNguoiLap = @id";
                //    parameters.Add(new SqlParameter("@id", id));
                //}
                var dt = DatabaseHelper.ExecuteQuery(sql, parameters.ToArray());
               
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi load phiếu: {ex.Message}");
            }
          
        }



        private void LoadGiaoDichData()
        {

        }

        private void CheckHistory_Load(object sender, EventArgs e)
        {
            updatedata();
        }

        private void ThoatBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

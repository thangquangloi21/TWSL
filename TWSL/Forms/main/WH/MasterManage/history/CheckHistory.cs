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

namespace TWSL.Forms.main.WH.MasterManage.history
{
    public partial class CheckHistory : Form
    {
        private static string ChucNangTraCuu = "LogSystem";
        public CheckHistory()
        {
            InitializeComponent();
        }

        private void CheckLOG() 
        {

            ChucNangTraCuuLbl.Text = "TRA CỨU LỊCH SỬ HỆ THỐNG (LOG SYSTEM) ";
            ChucNangTraCuu = "LogSystem";
            MaSanPhamTbx.Enabled = false;
            LotSpTbx.Enabled = false;
            IdNguoiDungTbx.Enabled = false;
            SoPhieuTbx.Enabled = false;
            ChonNgayPick.Enabled = true;
        }

        private void CHECK_LICH_SU()
        {
            ChucNangTraCuuLbl.Text = "TRA CỨU LỊCH SỬ GIAO DỊCH";
            ChucNangTraCuu = "TraCuuGiaoDich";
            MaSanPhamTbx.Enabled = true;
            LotSpTbx.Enabled = true;
            IdNguoiDungTbx.Enabled = true;
            SoPhieuTbx.Enabled = true;
            ChonNgayPick.Enabled = false;
        }

        private void LogSystemBtn_Click(object sender, EventArgs e)
        {
            MaSanPhamTbx.Text = "";
            LotSpTbx.Text = "";
            IdNguoiDungTbx.Text = "";
            SoPhieuTbx.Text = "";
            NoiDungTbx.Text = "";
            CheckLOG();
            updatedata();
        }

        private void LichSuGiaoDichBtn_Click(object sender, EventArgs e)
        {
            MaSanPhamTbx.Text = "";
            LotSpTbx.Text = "";
            IdNguoiDungTbx.Text = "";
            SoPhieuTbx.Text = "";
            NoiDungTbx.Text = "";
            CHECK_LICH_SU();
            updatedata();
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
                Console.WriteLine(ChucNangTraCuu);
                Console.WriteLine("Logsytem");
                Loadlogdata();

            }
            else if (ChucNangTraCuu == "TraCuuGiaoDich")
            {
                // load data lịch sử giao dịch
                Console.WriteLine("Lịch sử giao dịch");
                Console.WriteLine(ChucNangTraCuu);

                LoadGiaoDichData();
            }
        }

        private void Loadlogdata()
        {
            try
            {
                var sql = @"
        SELECT *
        FROM [TWSL].[dbo].[LogSystem]
        WHERE CAST(LogDate AS DATE) = @ngaytao
    ";

                var conditions = new List<string>();
                var parameters = new List<SqlParameter>();

                parameters.Add(new SqlParameter("@ngaytao", ChonNgayPick.Value.Date));

                if (!string.IsNullOrWhiteSpace(NoiDungTbx.Text))
                {
                    conditions.Add("Message LIKE @NoiDung");
                    parameters.Add(new SqlParameter("@NoiDung", "%" + NoiDungTbx.Text.Trim() + "%"));
                }

                if (conditions.Count > 0)
                {
                    sql += " AND " + string.Join(" AND ", conditions);
                }

                sql += " ORDER BY LogDate DESC";

                var dt = DatabaseHelper.ExecuteQuery(sql, parameters.ToArray());

                DataLogView.DataSource = dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi load log: " + ex.Message);
            }

        }



        private void LoadGiaoDichData()
        {

            //MessageBox.Show("Load Pallet");
            try
            {

                // 1) Câu lệnh nền
                var baseSql = @"SELECT TOP (1000) 
                                [MaSP] as 'Mã Sản Phẩm'
                                ,[LotSP] as 'Lot'
                                ,[SoMeTT] as 'Số Mẻ Tiệt Trùng'
                                ,[SoPhieuDaTao] as 'Số Phiếu Đã Tạo'
                                ,[SoLuong] as 'Số Lượng'
                                ,u.username as 'Người Thực Hiện'
                                ,[ThoiGianThucHien] as 'Thời Gian Thực Hiện'
                                ,[NoiDung] as 'Nội Dung'
                                FROM [TWSL].[dbo].[LichSuGiaoDich] h
                                left join users u on h.NguoiThucHien = u.id
                                
                                ";

                // 2) Gom điều kiện & tham số
                var conditions = new List<string>();
                var parameters = new List<SqlParameter>();

                if (!string.IsNullOrWhiteSpace(MaSanPhamTbx.Text.Trim()))
                {
                    conditions.Add("MaSP = @MaSP");
                    parameters.Add(new SqlParameter("@MaSP", MaSanPhamTbx.Text.Trim()));
                }

                if (!string.IsNullOrWhiteSpace(LotSpTbx.Text.Trim()))
                {
                    conditions.Add("LotSP = @LotSP");
                    parameters.Add(new SqlParameter("@LotSP", LotSpTbx.Text.Trim()));
                }

                if (!string.IsNullOrWhiteSpace(IdNguoiDungTbx.Text.Trim()))
                {
                    conditions.Add("NguoiThucHien = @NguoiThucHien");
                    parameters.Add(new SqlParameter("@NguoiThucHien", IdNguoiDungTbx.Text.Trim()));
                }

               if (!string.IsNullOrWhiteSpace(SoPhieuTbx.Text.Trim()))
                {
                    conditions.Add("SoPhieuDaTao = @SoPhieuDaTao");
                    parameters.Add(new SqlParameter("@SoPhieuDaTao", SoPhieuTbx.Text.Trim()));
                }

                // 3) Lắp WHERE nếu có
                string sql = baseSql;
                if (conditions.Count > 0)
                {
                    sql += " WHERE " + string.Join(" AND ", conditions);
                }

                sql += " order by h.id desc"; // Sắp xếp theo thời gian thực hiện giảm dần


                // 4) Thực thi query: DÙNG parameters.ToArray() thay vì 'checkuser'
                DataTable result = DatabaseHelper.ExecuteQuery(sql, parameters.ToArray());


                // 6) Gán vào DataGridView (đảm bảo đúng tên control)
                DataLogView.DataSource = result; // VD: dataGridView1.DataSource = result;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void CheckHistory_Load(object sender, EventArgs e)
        {
            CheckLOG();
            updatedata();
        }

        private void ThoatBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

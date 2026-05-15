using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TWSL.Common;
using TWSL.Forms.main.WH.LapPhieu;

namespace TWSL.Forms.main.WH
{
    public partial class XemChiTiet : Form
    {
        DataTable DataTable;
        //string TypeView = "";
        public XemChiTiet(string view,DataTable data)
        {
            InitializeComponent();
            DataTable = data;

            if (view == "DP")
            {
                panel2.Visible = false;
            }
            else
            {
                panel2.Visible = true;
            }
           


        }

        private void DP_Load(object sender, EventArgs e)
        {
            viewdata.DataSource = DataTable;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SuaThongTinBtn(object sender, EventArgs e)
        {
            var selectedRow = viewdata.CurrentRow;
            if (selectedRow == null)
            {
                MessageBox.Show("Vui lòng chọn một phiếu để sửa thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string soLuong    = selectedRow.Cells["Số Lượng"].Value?.ToString()            ?? "";
            string maxPallet  = selectedRow.Cells["Max/Pallet"].Value?.ToString()           ?? "";
            string thoiGianTK = selectedRow.Cells["Thời gian thoát khí"].Value?.ToString() ?? "";

            using (var sua_thong_tin = new SuaThongTin(soLuong, maxPallet, thoiGianTK))
            {
                if (sua_thong_tin.ShowDialog() == DialogResult.OK)
                {
                    // Cập nhật lại DataTable (hiển thị ngay không cần query lại DB)
                    int rowIndex = selectedRow.Index;
                    DataTable.Rows[rowIndex]["Số Lượng"]            = sua_thong_tin.ResultSoLuong;
                    DataTable.Rows[rowIndex]["Max/Pallet"]          = sua_thong_tin.ResultMaxPallet;
                    DataTable.Rows[rowIndex]["Thời gian thoát khí"] = sua_thong_tin.ResultThoiGianTK;
                    DataTable.Rows[rowIndex]["Nội Dung"]           = sua_thong_tin.ResultNoiDung;
                }
            }
        }

            private void TaoPhieuBTN(object sender, EventArgs e)
            {
                TaoPhieu.TaoVaLuuPhieu(DataTable);
            }
    }
}

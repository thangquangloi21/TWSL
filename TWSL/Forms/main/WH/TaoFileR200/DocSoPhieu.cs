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

namespace TWSL.Forms.main.WH.TaoFileR200
{
    public partial class DocSoPhieu : Form
    {
        public DocSoPhieu()
        {
            InitializeComponent();
        }



        private void SoPhieuTbx(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                KiemTraSoPhieu();
            }
           
        }

        private void OKSoPhieuBtn_Click(object sender, EventArgs e)
        {
            KiemTraSoPhieu();
        }

        private void KiemTraSoPhieu()
        {

            // kiểm tra nếu số phiếu đã tồn tại rồi thì thông báo.
            if (NhapKho.CheckDaTaoChua(INPSoPhieuTbx.Text.Trim()))
            {
                MessageBox.Show("Phiếu đã được nhập vui lòng kiểm tra lại. !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                INPSoPhieuTbx.SelectAll();
                return;
            }


            // Kiểm tra nếu thời gian thoát khí = 0 thì yêu cầu chọn kho thoát khí
            if (string.IsNullOrEmpty(INPSoPhieuTbx.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập số phiếu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                INPSoPhieuTbx.SelectAll();
                return;
            }

            if (NhapKho.CheckSoPhieu(INPSoPhieuTbx.Text.Trim()) == false) {
                MessageBox.Show("Phiếu đã nhập chưa được tạo hoặc không hợp lệ. ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                INPSoPhieuTbx.SelectAll();
                return;
            }

            if (NhapKho.CheckPhieu(INPSoPhieuTbx.Text) == "chuyenkhoc") 
            {
                var ThemDuLieu = new AddDuLieu(INPSoPhieuTbx.Text, "C");
                this.Close();
                ThemDuLieu.ShowDialog();
                return;
            }


            var ChonKhoTD = new ChonKhoTD(INPSoPhieuTbx.Text);
            this.Close();
            ChonKhoTD.ShowDialog();
            
            //Console.WriteLine(soPhieu);
        }

        private void ThoatBtn(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

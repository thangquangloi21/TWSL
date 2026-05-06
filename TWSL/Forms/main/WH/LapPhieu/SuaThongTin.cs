using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TWSL.Forms.main.WH.LapPhieu
{
    public partial class SuaThongTin : Form
    {
        string ThoiGianTK = "";

        // Properties để XemChiTiet đọc lại sau khi sửa
        public string ResultSoLuong   => SoLuongTbx.Text.Trim();
        public string ResultMaxPallet => MaxpaletTbx.Text.Trim();
        public string ResultThoiGianTK => ThoiGianTKTbx.Text.Trim();
        public string ResultNoiDung => NoiDungSua.Text.Trim();

        public SuaThongTin(string SoLuong, string Maxpallet , string ThoiGianTK)
        {
            InitializeComponent();

            SoLuongTbx.Text = SoLuong;
            MaxpaletTbx.Text = Maxpallet;
            ThoiGianTKTbx.Text = ThoiGianTK;
            this.ThoiGianTK = ThoiGianTK;
        }

        private void ExitFrom(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void SuaOK(object sender, EventArgs e)
        {
            SuaThongTin_Load();
        }

        private void SuaThongTin_Load()
        {
            string LuuSoLuongSP = SoLuongTbx.Text;
            string LuuMaxPallet = MaxpaletTbx.Text;
            string LuuThoiGianTK = ThoiGianTKTbx.Text;
            if (LuuThoiGianTK != this.ThoiGianTK)
            {
                // nếu sửa thời gian thoát khí phải nhập lý do
                if (NoiDungSua.Text == "")
                {
                    MessageBox.Show("Sửa thời gian thoát khí phải nhập lý do", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NoiDungSua.Focus();
                    return;
                }
                //MessageBox.Show("Sửa thời gian thoát khí", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                using (var authenfrom = new authentication_from())
                {
                    if (authenfrom.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show("Sửa thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Sửa thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}

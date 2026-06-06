using Org.BouncyCastle.Math.Field;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TWSL.Common;

namespace TWSL.Forms.main.WH.LapPhieu
{
    public partial class SuaThongTin : Form
    {
        string ThoiGianTK = "";

        // Properties để XemChiTiet đọc lại sau khi sửa
        public string ResultMaSP;
        public string ResultLotSP;
        
        public string ResultSoMeTT;
        public string ResultSoLuong   => SoLuongTbx.Text.Trim();
        public string ResultMaxPallet => MaxpaletTbx.Text.Trim();
        public string ResultThoiGianTK => ThoiGianTKTbx.Text.Trim();
        public string ResultNoiDung => NoiDungSua.Text.Trim();

        public SuaThongTin(string ma, string lot, string soMe, string SoLuong, string Maxpallet , string ThoiGianTK)
        {
            InitializeComponent();
            
            SoLuongTbx.Text = SoLuong;
            MaxpaletTbx.Text = Maxpallet;

            ThoiGianTKTbx.Text = ThoiGianTK;
            this.ThoiGianTK = ThoiGianTK;
            ResultMaSP = ma;
            ResultLotSP = lot;
            ResultSoMeTT = soMe;
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
                        //sửa thời gian thoát khí
                        ImportData.InsertHistory(ResultMaSP, ResultLotSP, ResultSoMeTT, "", ResultSoLuong, AppData.Instance.CurrentUserId, $"Sửa thông thoát khí {ThoiGianTK} => {ThoiGianTKTbx.Text} " );
                        Logger.Log("INFO", $"{AppData.Instance.CurrentUserName} sửa thông tin thoát khí của mã: {ResultMaSP}-{ResultLotSP} {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
                        MessageBox.Show("Sửa thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            else if (LuuSoLuongSP != this.ResultSoLuong || LuuMaxPallet != this.ResultMaxPallet)
            {
                // nếu sửa số lượng hoặc max pallet phải nhập lý do
                if (NoiDungSua.Text == "")
                {
                    MessageBox.Show("Sửa số lượng hoặc max pallet phải nhập lý do", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NoiDungSua.Focus();
                    return;
                }
                //MessageBox.Show("Sửa số lượng hoặc max pallet", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                using (var authenfrom = new authentication_from())
                {
                    if (authenfrom.ShowDialog() == DialogResult.OK)
                    {
                        //sửa số lượng hoặc max pallet
                        ImportData.InsertHistory(ResultMaSP, ResultLotSP, ResultSoMeTT, "", ResultSoLuong, AppData.Instance.CurrentUserId, $"Sửa thông số lượng {ResultSoLuong} => {SoLuongTbx.Text} hoặc max pallet {ResultMaxPallet} => {MaxpaletTbx.Text}");
                        Logger.Log("INFO", $"{AppData.Instance.CurrentUserName} sửa thông tin số lượng hoặc max pallet của mã: {ResultMaSP}-{ResultLotSP} {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
                        MessageBox.Show("Sửa thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }

            else
            {
                if(ResultMaxPallet != MaxpaletTbx.Text.Trim())
                {
                    ImportData.InsertHistory(ResultMaSP, ResultLotSP, ResultSoMeTT, "", ResultSoLuong, AppData.Instance.CurrentUserId, $"Sửa thông tin Maxpallet {ResultMaxPallet} => {MaxpaletTbx.Text.Trim()}");
                }
                if(ResultSoLuong != SoLuongTbx.Text.Trim())
                {
                    ImportData.InsertHistory(ResultMaSP, ResultLotSP, ResultSoMeTT, "", ResultSoLuong, AppData.Instance.CurrentUserId, $"Sửa số lượng {ResultSoLuong} => {SoLuongTbx.Text.Trim()}");
                }
                Logger.Log("INFO", $"{AppData.Instance.CurrentUserName} sửa thông tin của mã: {ResultMaSP}-{ResultLotSP} {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
                MessageBox.Show("Sửa thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                //sửa thông tin
                this.Close();
            }
        }
    }
}

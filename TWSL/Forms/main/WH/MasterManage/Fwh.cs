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
using TWSL.Forms.main.WH.MasterManage.history;
using TWSL.Forms.master;

namespace TWSL.Forms.main
{
    public partial class MasterManage : Form
    {
        public MasterManage()
        {
            InitializeComponent();
            Logger.Log("INFO", $"{AppData.Instance.CurrentUserName} Vào chức năng quản lý master {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
        }

        private void QuanLyTaiKhoanBtn(object sender, EventArgs e)
        {
            //var create_from_awh = new WH.CreateFromAWH();
            //create_from_awh.ShowDialog();
            user_ma Uma = new user_ma();
            Uma.ShowDialog();
        }

        //private void Master_btn(object sender, EventArgs e)
        //{
        //    var From_master_wh = new FromMasterWH();
        //    From_master_wh.ShowDialog();
        //}

        private void MasterWHBtn(object sender, EventArgs e)
        {
            var From_master_wh = new FromMasterWH();
            From_master_wh.ShowDialog();
        }

        private void TraCuuLichSuBtn(object sender, EventArgs e)
        {
            var CheckHistory = new CheckHistory();
            CheckHistory.ShowDialog();
        }
    }
}

using Org.BouncyCastle.Math.Field;
using System;
using System.CodeDom;
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
    public partial class AddDuLieu : Form
    {
        // Biến toàn class
        private string SoPhieu;
        public AddDuLieu(string Sophieu)
        {
            InitializeComponent();
            SoPhieu = Sophieu;
        }

        private void AddDuLieu_Load(object sender, EventArgs e)
        {
           //lấy thời gian rồi gán vào date
           Date_display.Text = DateTime.Now.ToString("dd/MM/yyyy");
            DocDuLieuLBL.Text = $"ĐỌC DỮ LIỆU ({SoPhieu})";

        }

        private void MaPalletTBX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) {
                Console.WriteLine("Doc ma pallet");

            } 
            
        }

        private void MaThungTBX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) {
                Console.WriteLine("Doc ma Thung");

            }
        }
    }
}

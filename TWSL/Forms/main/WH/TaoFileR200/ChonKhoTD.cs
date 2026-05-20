using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TWSL.Forms.main.WH.TaoFileR200
{
    public partial class ChonKhoTD : Form
    {
        private string SoPhieu;
        public ChonKhoTD(string Sophieu)
        {
            InitializeComponent();
            SoPhieu = Sophieu;
        }

        private void KhoA_Click(object sender, EventArgs e)
        {
            var ThemDuLieu = new AddDuLieu(SoPhieu, "A");
            this.Close();
            ThemDuLieu.ShowDialog();
        }

        private void KhoB_Click(object sender, EventArgs e)
        {
            var ThemDuLieu = new AddDuLieu(SoPhieu, "B");
            this.Close();
            ThemDuLieu.ShowDialog();
        }
    }
}

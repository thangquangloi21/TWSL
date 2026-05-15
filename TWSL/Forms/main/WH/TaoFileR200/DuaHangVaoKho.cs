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
    public partial class DuaHangVaoKho : Form
    {
        public DuaHangVaoKho()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var DocSoPhieuDP = new DocSoPhieu();
            DocSoPhieuDP.ShowDialog();
        }
    }
}

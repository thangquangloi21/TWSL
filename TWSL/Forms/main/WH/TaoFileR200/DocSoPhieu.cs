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
            Console.WriteLine(INPSoPhieuTbx.Text);
        }
    }
}

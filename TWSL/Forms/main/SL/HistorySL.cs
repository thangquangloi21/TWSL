using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TWSL.Forms.history;

namespace TWSL.Forms.main
{
    public partial class HistoryFrame : Form
    {
        public HistoryFrame()
        {
            InitializeComponent();
        }

        private void HisMaster(object sender, EventArgs e)
        {
            var HisMaster = new his_master();
            HisMaster.ShowDialog();
        }

        private void Hislogin(object sender, EventArgs e)
        {
            var HisLog = new tra_cuu_log();
            HisLog.ShowDialog();
        }

        private void InfChage(object sender, EventArgs e)
        {
            var HisInf = new his_info_users();
            HisInf.ShowDialog();
        }

        private void Histk(object sender, EventArgs e)
        {
            var HisDltk = new his_data_tgtk();
            HisDltk.ShowDialog();
        }
    }
}

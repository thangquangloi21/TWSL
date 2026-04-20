using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TWSL.Forms.master;

namespace TWSL.Forms.main
{
    public partial class Fwh : Form
    {
        public Fwh()
        {
            InitializeComponent();
        }

        private void CreateAWH(object sender, EventArgs e)
        {
            //var create_from_awh = new WH.CreateFromAWH();
            //create_from_awh.ShowDialog();
            user_ma Uma = new user_ma();
            Uma.ShowDialog();
        }

        private void Master_btn(object sender, EventArgs e)
        {
            var From_master_wh = new FromMasterWH();
            From_master_wh.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var From_master_wh = new FromMasterWH();
            From_master_wh.ShowDialog();
        }
    }
}

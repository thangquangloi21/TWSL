using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            var create_from_awh = new WH.CreateFromAWH();
            create_from_awh.ShowDialog();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TWSL.Forms.main.WH
{
    public partial class DP : Form
    {
        DataTable DataTable;
        string TypeView = "";
        public DP(string view,DataTable data)
        {
            InitializeComponent();
            DataTable = data;

            if (view == "DP")
            {
                panel2.Visible = false;
            }
           


        }

        private void DP_Load(object sender, EventArgs e)
        {
            viewdata.DataSource = DataTable;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

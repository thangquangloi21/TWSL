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
    public partial class AddDuLieu : Form
    {
        public AddDuLieu()
        {
            InitializeComponent();
        }

        private void AddDuLieu_Load(object sender, EventArgs e)
        {
           //lấy thời gian rồi gán vào date
           Date_display.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
    }
}

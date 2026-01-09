using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TWSL.Forms.main.SL.SL1
{
    public partial class InputSL12 : Form
    {
        private bool batno_enter = true;
        //private bool pallet_enter = false;
        public InputSL12()
        {
            InitializeComponent();
        }

        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ĐổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ĐăngXuấtToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void quảnLíTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void quảnLýDữLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void trans_login(object sender, EventArgs e)
        {

        }

        private void info_history(object sender, EventArgs e)
        {

        }

        private void master_history(object sender, EventArgs e)
        {

        }

        private void dltk_history(object sender, EventArgs e)
        {

        }

        private void Inputsl1_Load(object sender, EventArgs e)
        {
            Iduser.Text = TWSL.Common.AppData.Instance.CurrentUserId;
            Username.Text = TWSL.Common.AppData.Instance.CurrentUserName;
            BatchYear.Text = TWSL.Common.AppData.Instance.GenYearBatch;
        }

        private void StatusBtn_Click(object sender, EventArgs e)
        {

        }

        private void BatchNoTbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!batno_enter) return;
            if (e.KeyChar == (char)Keys.Enter)
            {
                MessageBox.Show($"{BatchNoTbx.Text.Trim()}");
            }
            if (BatchNoTbx.Text.Length >= 5 && e.KeyChar != (char)Keys.Back)
            {
                // Chặn ký tự đó lại
                e.Handled = true;
            }
        }
    }
}

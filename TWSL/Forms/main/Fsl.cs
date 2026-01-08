using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TWSL.Forms.main.SL.SL1;

namespace TWSL.Forms.main
{
    public partial class Fsl : Form
    {
        public Fsl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           InputSL12 fsl1 = new InputSL12();
            fsl1.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            main_from main = new main_from();
            main.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            user_ma Uma = new user_ma();
            Uma.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            from_master fm = new from_master();
            fm.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Try to find the parent HOME instance that hosts this child form
            var parentForm = this.FindForm();
            if (parentForm is HOME home)
            {
                home.histrory_user();
                return;
            }

            // Fallback: search open forms for HOME
            var openHome = Application.OpenForms.OfType<HOME>().FirstOrDefault();
            if (openHome != null)
            {
                openHome.histrory_user();
                return;
            }

            // If HOME cannot be found, notify user (do not create a new HOME silently)
            MessageBox.Show("Không tìm thấy form HOME. Vui lòng mở HOME trước khi thực hiện thao tác này.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using TWSL.Common;

namespace TWSL.Forms.main
{
    public partial class HOME : Form
    {
        public HOME()
        {
            
            InitializeComponent();
        }
        private Form curFromChild;
        private void OpenchildFrom(Form childFrom)
        {
            if (curFromChild != null)
            {
                curFromChild.Close();
            }
            curFromChild = childFrom;
            childFrom.TopLevel = false;
            childFrom.FormBorderStyle = FormBorderStyle.None;
            childFrom.Dock = DockStyle.Fill;
            mainview_wh.Controls.Add(childFrom);
            mainview_wh.Tag = childFrom;
            childFrom.BringToFront();
            childFrom.Show();
        }

      
        private void Wh_btn(object sender, EventArgs e)
        {
            if (AppData.Instance.CurrentProdLine == "WH" || AppData.Instance.CurrentUserId == "admin")
            {
                OpenchildFrom(new Fwh());

            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
           

        }

        private void Sl_btn(object sender, EventArgs e)
        {

            if (AppData.Instance.CurrentProdLine == "SL" || AppData.Instance.CurrentUserId == "admin")
            {

                OpenchildFrom(new Fsl());
            }
           
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            
        }

        private void HOME_Load(object sender, EventArgs e)
        {
            UserID.Text = AppData.Instance.CurrentUserId;
            Fname.Text = AppData.Instance.CurrentUserName;
            Role_wh.Text = AppData.Instance.CurrentRole;
            ProdLine.Text = AppData.Instance.CurrentRole;



            if (AppData.Instance.CurrentProdLine == "SL")
            {
                OpenchildFrom(new Fsl());

            }
            else
            {
                OpenchildFrom(new Fwh());
            }
        }
    }
}

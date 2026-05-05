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
using TWSL.Forms.main.SL.SL1;
using TWSL.Forms.main.WH;
using TWSL.test;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TWSL.Forms.main
{
    public partial class HOME : Form
    {
        public HOME()
        {
            
            InitializeComponent();
        }


      
        //01589352212125671728013110260411T

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

      
        private void DataManagementBtn(object sender, EventArgs e)
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
            UtilityFunctions.loadjson();
            UserID.Text = AppData.Instance.CurrentUserId;
            Fname.Text = AppData.Instance.CurrentUserName;
            Role_wh.Text = AppData.Instance.CurrentRole;
            ProdLine.Text = AppData.Instance. CurrentProdLine;
            Version.Text = "Version: " + AppData.Instance.AppVersion;

            OpenchildFrom(new NhapDuLieu());

            //if (AppData.Instance.CurrentProdLine == "WH")
            //{
            //    OpenchildFrom(new Fwh());
            //}
            //else
            //{
            //    OpenchildFrom(new Fsl());
            //}
        }

        private void ChangePw(object sender, EventArgs e)
        {
            Console.WriteLine("Change Password clicked");
            chage_pasword chage_PaswordForm = new chage_pasword(AppData.Instance.CurrentUserId, AppData.Instance.CurrentPassw);
            chage_PaswordForm.ShowDialog();
        }


        private void Info_click(object sender, EventArgs e)
        {
            Console.WriteLine("Info clicked");
        }
        public void histrory_user()
        {
            OpenchildFrom(new HistoryFrame());
        }

        //// hiển thị Usercontrol
        //private void Info_click(object sender, EventArgs e)
        //{
        //    Console.WriteLine("Info clicked");

        //    // ChagePW is a UserControl (not a Form). Add it to the main panel instead
        //    // of calling OpenchildFrom which expects a Form.
        //    if (curFromChild != null)
        //    {
        //        curFromChild.Close();
        //        curFromChild = null;
        //    }

        //    mainview_wh.Controls.Clear();
        //    var changePwControl = new ChagePW();
        //    changePwControl.Dock = DockStyle.Fill;
        //    mainview_wh.Controls.Add(changePwControl);
        //    mainview_wh.Tag = changePwControl;
        //    changePwControl.BringToFront();
        //}


        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            Point p = pictureBox1.PointToClient(Cursor.Position);
            toolTip1.Show(
           "Đổi Mật khẩu",
           pictureBox1,
           p.X + 15,
           p.Y + 15,
           1000
            );
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            toolTip1.Hide(pictureBox1);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (AppData.Instance.CurrentProdLine == "SL" || AppData.Instance.CurrentUserId == "1")
            {

                OpenchildFrom(new Fsl());
            }

            else
            {
                MessageBox.Show("Bạn không có quyền truy cập", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void AddData(object sender, EventArgs e)
        {
            if (AppData.Instance.CurrentProdLine == "SL" || AppData.Instance.CurrentUserId == "1")
            {

                OpenchildFrom(new NhapDuLieu());
            }

            else
            {
                MessageBox.Show("Bạn không có quyền truy cập", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (AppData.Instance.CurrentProdLine == "SL" || AppData.Instance.CurrentUserId == "1")
            {

                OpenchildFrom(new TaoPhieuNhapKho());
            }

            else
            {
                MessageBox.Show("Bạn không có quyền truy cập", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
    }
}

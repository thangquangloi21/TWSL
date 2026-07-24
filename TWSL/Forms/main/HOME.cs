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
using TWSL.Forms.main.WH.TaoFileR200;
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
            HashSet<string> allowedPermissions = new HashSet<string>
            {
            "MASTER_MANAGE",
            "FULL_ACCESS"
            };
            bool hasDataEntry = AppData.Instance.Permission.AsEnumerable()
                .Any(row => allowedPermissions.Contains(row["PermissionCode"].ToString().Trim()));
            if (hasDataEntry)
            {
                OpenchildFrom(new MasterManage());

            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
           

        }

       

        private void HOME_Load(object sender, EventArgs e)
        {
            UtilityFunctions.loadlinkfrom();
            if (AppData.Instance.CurrentUserId != "admin")
            {
                //load quyền vào 1 data table 
                AppData.Instance.Permission = UtilityFunctions.LoadUserPermissions(AppData.Instance.CurrentUserId);
                // lấy thông tin nhóm quyền
                AppData.Instance.NhomQuyen = UtilityFunctions.LayThonTinQuyen(AppData.Instance.CurrentRole).Rows[0]["RoleName"].ToString();
            }
            else
            {
                // Nếu là admin, cấp quyền FULL_ACCESS
                DataTable adminPermissions = new DataTable();
                adminPermissions.Columns.Add("PermissionCode", typeof(string));
                adminPermissions.Rows.Add("FULL_ACCESS");
                AppData.Instance.Permission = adminPermissions;
                AppData.Instance.NhomQuyen = "Admin";
            }
           

            UtilityFunctions.loadjson();
            UserID.Text = AppData.Instance.CurrentUserId;
            Fname.Text = AppData.Instance.CurrentUserName;
            Role_wh.Text = AppData.Instance.NhomQuyen;
            Version.Text = "Version: " + AppData.Instance.AppVersion;

            //OpenchildFrom(new NhapDuLieu());

            if (AppData.Instance.NhomQuyen == "Nhom2")
            {
                OpenchildFrom(new NhapDuLieu());
            }
            else if (AppData.Instance.NhomQuyen == "Nhom1")
            {
                OpenchildFrom(new DuaHangVaoKho());
            }
            else
            {
                OpenchildFrom(new NhapDuLieu());
            }
        }

        private void ChangePw(object sender, EventArgs e)
        {
            Console.WriteLine("Change Password clicked");
            chage_pasword chage_PaswordForm = new chage_pasword(AppData.Instance.CurrentUserId, AppData.Instance.CurrentPassw);
            chage_PaswordForm.ShowDialog();
        }


        private void Info_click(object sender, EventArgs e)
        {
            foreach (DataRow row in AppData.Instance.Permission.Rows)
            {
                Console.WriteLine(row["PermissionCode"]);
            }

        }
      

      


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


        private void AddData(object sender, EventArgs e)
        {
            HashSet<string> allowedPermissions = new HashSet<string>
            {
            "DATA_ENTRY",
            "FULL_ACCESS"
            };
            bool hasDataEntry = AppData.Instance.Permission.AsEnumerable()
                .Any(row => allowedPermissions.Contains(row["PermissionCode"].ToString()));
            if (hasDataEntry)
            {

                OpenchildFrom(new NhapDuLieu());
            }

            else
            {
                MessageBox.Show("Bạn không có quyền truy cập", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void TaoPhieuBtn(object sender, EventArgs e)
        {
            HashSet<string> allowedPermissions = new HashSet<string>
            {
            "CREATE_FORM",
            "FULL_ACCESS"
            };
            bool hasDataEntry = AppData.Instance.Permission.AsEnumerable()
                .Any(row => allowedPermissions.Contains(row["PermissionCode"].ToString()));
            if (hasDataEntry)
            {

                OpenchildFrom(new TaoPhieuNhapKho());
            }

            else
            {
                MessageBox.Show("Bạn không có quyền truy cập", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void DuaHangVaoKhoBtn(object sender, EventArgs e)
        {
            HashSet<string> allowedPermissions = new HashSet<string>
            {
            "EXPORT_CSV",
            "FULL_ACCESS"
            };
            bool hasDataEntry = AppData.Instance.Permission.AsEnumerable()
                .Any(row => allowedPermissions.Contains(row["PermissionCode"].ToString()));
            if (hasDataEntry)
            {
                OpenchildFrom(new DuaHangVaoKho());
            }

            else
            {
                MessageBox.Show("Bạn không có quyền truy cập", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }   
        }
    }
}

using TWSL.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace TWSL
{
    public partial class register_user : Form
    {
        // Biến lưu trữ thông tin người dùng đăng ký
        private string id_Registrant;
        private string username_Registrant;
        public register_user(string id_, string username_)
        {
            id_Registrant = id_; // Lưu ID người dùng đăng ký
            username_Registrant = username_; // Lưu tên người dùng đăng ký
            InitializeComponent();
            

        }


        private void button2_Click(object sender, EventArgs e)
        {
            string id= id_register.Text;
            string name = username_register.Text;
            string pass = passw_register.Text;
            string role = role_register.Text;
            // Mã hóa mật khẩu sử dụng BCrypt
            pass = BCrypt.Net.BCrypt.HashPassword(pass);
            // Quy đổi quyền người dùng
            if (role == "Admin")
            {
                role = "1";
            }
            else if (role == "QuanLy")
            {
                role = "2";
            }
            else if (role == "Nhom1")
            {
                role = "3";
            }
            else if (role == "Nhom2")
            {
                role = "4";
            }
            else if (role == "Nhom3")
            {
                role = "5";
            }

            else
            {
                MessageBox.Show("Vui lòng chọn quyền hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (string.IsNullOrEmpty(id_register.Text) || !int.TryParse(id_register.Text, out _) || id_register.Text.Length != 6)
            {
                MessageBox.Show("ID phải là một số hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(username_register.Text))
            {
                MessageBox.Show("Tên đăng nhập không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(passw_register.Text))
            {
                MessageBox.Show("Mật khẩu không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //MessageBox.Show($"Đăng ký thành công cho id {id} \n Tên: {name} \n pass: {pass}, \n role = {role} \n ngườu đăng kí : {username_Registrant}, id {id_Registrant}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // kiểm tra tài khoản đã được tạo chưa

            string check_user = "SELECT COUNT(*) FROM [users] WHERE id = @UserID";
            SqlParameter[] checkuser = new SqlParameter[]
            {
                new SqlParameter("@UserID", id)
            };
            DataTable result = DatabaseHelper.ExecuteQuery(check_user, checkuser);
            int count = Convert.ToInt32(result.Rows[0][0]);
            //MessageBox.Show($"{count}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (count > 0)
            {
                MessageBox.Show("Tài khoản đã tồn tại. Vui lòng chọn ID khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                // get current date
                DateTime currentDate = DateTime.Now;
                // Chuyển đổi ngày thành định dạng chuỗi "yyyy-MM-dd HH:mm:ss"
                string formattedDate = currentDate.ToString("yyyy-MM-dd HH:mm:ss");
                // Thêm người dùng mới vào cơ sở dữ liệu
                string query = "INSERT INTO [users] (id, username, password, role, time_chage_pasword, status, pass_error, registrant_id, registrant_name, register_date) " +
                               "VALUES (@UserID, @Username, @Password, @Role, @time_chage_pasword,2 , 0, @RegistrantID, @RegistrantUsername, @register_date)";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@UserID", id),
                    new SqlParameter("@Username", name),
                    new SqlParameter("@Password", pass),
                    new SqlParameter("@Role", role),
                    new SqlParameter("@time_chage_pasword", formattedDate),
                    new SqlParameter("@register_date", formattedDate),
                    new SqlParameter("@RegistrantID", id_Registrant),
                    new SqlParameter("@RegistrantUsername", username_Registrant)
                };
                int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);



                    UtilityFunctions.trans_update_user("add", id, name, role, "2", id_Registrant, username_Registrant, formattedDate, "");

                    Logger.Log("INFO", $"User: {username_Registrant} có ID: {id_Registrant} Đăng kí thành công cho người dùng có ID: {id} vào lúc {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
                    this.Close(); // Đóng form sau khi đăng ký thành công
                }
                else
                {
                    MessageBox.Show("Đăng ký không thành công. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void register_user_Load(object sender, EventArgs e)
        {
            DataTable dt = DatabaseHelper.ExecuteQuery("SELECT [RoleName] FROM [TWSL].[dbo].[Roles]");
            role_register.DataSource = dt;
            role_register.DisplayMember = "RoleName";
            role_register.SelectedIndex = 0;
        }
    }
}

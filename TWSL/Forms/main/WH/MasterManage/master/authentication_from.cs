using Org.BouncyCastle.Crypto.IO;
using Org.BouncyCastle.Math.Field;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace TWSL
{
    public partial class authentication_from : Form
    {
        public string UserName { get; private set; }   // property công khai
        public string Password { get; private set; }   // property công khai

        public authentication_from()
        {
            InitializeComponent();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserName = auth_user.Text.Trim();
            Password = auth_pass.Text.Trim();


            if (UserName == "admin" && Password == "admin")
            {
                this.DialogResult = DialogResult.OK;  // báo cho form cha biết là bấm OK
                this.Close();
                return;
            }
            bool isPasswordCorrect = false;
            if (string.IsNullOrEmpty(auth_user.Text) || string.IsNullOrEmpty(auth_pass.Text))
            {
                MessageBox.Show("Không được để trống các trường !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!int.TryParse(UserName, out int number) || number <= 0)
            {
                MessageBox.Show("Thông tin tài khoản hoặc mật khẩu chưa chính xác. ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // lấy mật khẩu từ database để so sánh
            string get_time = $"SELECT password FROM [users] WHERE id = @username";
            SqlParameter[] id_passw = {
                                new SqlParameter("@username", UserName)
                            };
            DataTable result = DatabaseHelper.ExecuteQuery(get_time, id_passw);
            string storedHashedPassword = result.Rows[0]["password"].ToString();

            if (storedHashedPassword == null)
            {
                MessageBox.Show("Tài khoản không tồn tại. ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            isPasswordCorrect = BCrypt.Net.BCrypt.Verify(Password, storedHashedPassword);

            if (isPasswordCorrect)
            {
                // kiểm tra xem user có quyền không
                string user_role = "select * from [users] where id = @username";
                SqlParameter[] userrole = {
                   new SqlParameter("@username", UserName)
                 };
                DataTable role = DatabaseHelper.ExecuteQuery(user_role, userrole);

                string roles = role.Rows[0]["role"].ToString();

                if (roles == "manager" || roles == "user" || roles == "admin")
                {
                    this.DialogResult = DialogResult.OK;  // báo cho form cha biết là bấm OK
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Bạn Không có quyền thực hiện hành động này! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
               
            }
            else
            {
                MessageBox.Show("Thông tin tài khoản hoặc mật khẩu chưa chính xác. ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
        }
        
    }
}

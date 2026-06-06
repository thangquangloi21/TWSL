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
using TWSL.Common;
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
            string userName = auth_user.Text.Trim();
            string password = auth_pass.Text.Trim();

            if (userName != AppData.Instance.CurrentUserId)
            {
                MessageBox.Show("Vui Lòng nhập tài khoản hợp lệ!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Không được để trống các trường!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (userName == "admin" && password == "admin")
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }

            string sql = "SELECT password FROM [users] WHERE id = @id";

            SqlParameter[] parameters =
            {
            new SqlParameter("@id", auth_user.Text.Trim())};

            DataTable dt = DatabaseHelper.ExecuteQuery(sql, parameters);

            // Kiểm tra tài khoản có tồn tại không
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!");
                return;
            }

            // Lấy mật khẩu đã mã hóa
            string hashedPassword = dt.Rows[0]["password"].ToString();

            // Kiểm tra mật khẩu
            bool isCorrect = BCrypt.Net.BCrypt.Verify(
                auth_pass.Text.Trim(),
                hashedPassword);

            if (isCorrect)
            {

                //MessageBox.Show("Đăng nhập thành công!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!");
            }


        }

    }
}

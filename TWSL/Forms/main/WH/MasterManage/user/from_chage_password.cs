using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace TWSL
{
    public partial class chage_pasword : Form
    {
        string id = "";
        string password = "";
        public bool IsPasswordChanged { get; private set; } = false;

        public chage_pasword(string user_id, string user_password)
        {
            Logger.Log("INFO", $"{id} Truy cập chức năng đổi mật khẩu");
            InitializeComponent();
            id = user_id;
            password = user_password;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); // Đóng form hiện tại
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string Passwordold = passwordold_tbx.Text.Trim(); // Lấy giá trị từ ô nhập mật khẩu cũ
            string Passwordnew = passwordnew2_tbx.Text.Trim(); // Lấy giá trị từ ô nhập mật khẩu mới
            string Passwordnew2 = passwordnew_tbx.Text.Trim(); // Lấy giá trị từ ô nhập lại mật khẩu mới
            string specialCharPattern = @"[^a-zA-Z0-9\s]";
            if (string.IsNullOrWhiteSpace(Passwordold) || string.IsNullOrWhiteSpace(Passwordnew) || string.IsNullOrWhiteSpace(Passwordnew2))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (Passwordnew != Passwordnew2 || Passwordold != password || Passwordold == Passwordnew)
            {
                MessageBox.Show("Kiểm tra thông tin và thử lại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (Passwordnew.Length < 8)
            {
                MessageBox.Show("Mật khẩu tối thiểu phải 8 kí tự !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (!Regex.IsMatch(Passwordnew, specialCharPattern)) // Dùng toán tử phủ định (!)
            {
                MessageBox.Show("Mật khẩu phải chứa ít nhất 1 kí tự đặc biệt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DateTime now = DateTime.Now;
                string Passwordnews = BCrypt.Net.BCrypt.HashPassword(Passwordnew2);
                //MessageBox.Show($"Đang cập nhật mật khẩu cho người dùng {id} vào lúc {now.ToString("dd/MM/yyyy HH:mm:ss")}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                string query = "update [users] set status = '1', password = @Password, time_chage_pasword = @datetime where id = @id";

                SqlParameter[] parameters = {
                new SqlParameter("@Password", Passwordnews),
                new SqlParameter("@id", id),
                new SqlParameter("@datetime", now),

                };
                int result = DatabaseHelper.ExecuteNonQuery(query, parameters);

                // Thực hiện thay đổi mật khẩu ở đây
                // Ví dụ: Gọi hàm để cập nhật mật khẩu trong cơ sở dữ liệu hoặc hệ thống
                
                password = Passwordnew2;
                MessageBox.Show("Đổi mật khẩu thành công! \n Vui Lòng Đăng nhập lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                IsPasswordChanged = true; // Đánh dấu đã đổi mật khẩu
                this.Close(); // Đóng form sau khi đổi mật khẩu thành công
                
            }
        }

        private void chage_pasword_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            passwordold_tbx.UseSystemPasswordChar = false;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            passwordold_tbx.UseSystemPasswordChar = true;
        }


        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            passwordnew_tbx.UseSystemPasswordChar = false;
        }

        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            passwordnew_tbx.UseSystemPasswordChar = true;
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            passwordnew2_tbx.UseSystemPasswordChar = false;
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            passwordnew2_tbx.UseSystemPasswordChar = true;
        }
    }
}

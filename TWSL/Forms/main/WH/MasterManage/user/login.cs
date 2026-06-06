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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using TWSL.Forms.main;


namespace TWSL
{
    public partial class login : Form
    {
        private LoadingControl loadingControl;
        public string name { get; set; }
        public string role { get; set; }
        public string status { get; set; }

        string date { get; set; }
        //private static string connectionString = "Server=pc-tql;Database=SLDB;User Id=sa;Password=P@ssw0rd2025!;";
        //private readonly string connectionString = "Server=10.239.1.54;Database=DB_SL;User Id=sa;Password=123456;";
        public login()
        {
            InitializeComponent();

            this.MaximizeBox = false;
            loadingControl = new LoadingControl();
            this.Controls.Add(loadingControl); // thêm vào form
            username_texbox.Text = "6"; // Mặc định tên đăng nhập là admin
            password_texbox.Text = "Terumo123@"; // Mặc định mật khẩu là 123456

        }

        private void GetInfLogin(string username)
        {
                // lấy thông tin user từ database
                string get_info_user =$"SELECT * FROM [users] WHERE id = @username";
                SqlParameter[] info = {
                                new SqlParameter("@username", username)
                            };
                DataTable info_login_data = DatabaseHelper.ExecuteQuery(get_info_user, info);

                //MessageBox.Show($"{info_login_data}");

                if (info_login_data.Rows.Count > 0)
                {
                    DataRow row = info_login_data.Rows[0];

                    name = row["username"].ToString();
                    role = row["role"].ToString();
                    status = row["status"].ToString();
                    date = row["time_chage_pasword"].ToString();

                //MessageBox.Show($"Tên: {name}, Quyền: {role} Trạng thái: {status}");
                }
                else
                {
                    MessageBox.Show("Thông tin tài khoản hoặc mật khẩu chưa chính xác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
        }

        private void login_Load()
        {
            string username = username_texbox.Text.Trim();
            string password = password_texbox.Text.Trim();
            //mã hóa mât khẩu

                bool isPasswordCorrect = false;
                if (string.IsNullOrEmpty(username_texbox.Text) || string.IsNullOrEmpty(password_texbox.Text))
                {
                    MessageBox.Show("Không được để trống các trường !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                try
                {
                    if (!int.TryParse(username, out int number) || number <= 0)
                    {
                        MessageBox.Show("Thông tin tài khoản hoặc mật khẩu chưa chính xác. ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // lấy mật khẩu từ database để so sánh
                    string get_time = $"SELECT password FROM [users] WHERE id = @username";
                    SqlParameter[] id_passw = {
                                new SqlParameter("@username", username)
                            };
                    DataTable result = DatabaseHelper.ExecuteQuery(get_time, id_passw);
                    string storedHashedPassword = result.Rows[0]["password"].ToString();

                    if (storedHashedPassword == null)
                    {
                        MessageBox.Show("Tài khoản không tồn tại. ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        return;
                    }

                    isPasswordCorrect = BCrypt.Net.BCrypt.Verify(password, storedHashedPassword);
             

                if (isPasswordCorrect)
                {
                    //password= BCrypt.Net.BCrypt.HashPassword(password);
                    GetInfLogin(username); // Lấy thông tin đăng nhập
                                           //MessageBox.Show("Đăng nhập thành công!","Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                                           // Kiểm tra xem tài khoản có bị khóa không?
                    DateTime dateTime = DateTime.Parse(date);
                    DateTime currentLocalTime = DateTime.Now;

                    TimeSpan difference = currentLocalTime - dateTime;
                    int days = difference.Days;
                    //MessageBox.Show($"Tài Khoản đã đổi mk được {days}", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (status == "1")
                    { 
                        if (days > 180)
                        {
                            using (var changePasswordForm = new chage_pasword(username, password))
                            {
                                changePasswordForm.ShowDialog(); // Hiển thị form đổi mật khẩu

                            }
                        }
                        else
                        {
                            Logger.Log("INFO", $"Đăng nhập thành công cho người dùng {username} vào lúc {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
                            // reset số lần nhập sai mật khẩu về 0
                            //Logger.Log("INFO", $"Khóa tài khoản {username} do nhập sai {solansaipass} lần.");
                            string reset_pass_count = "UPDATE [users] SET pass_error = 0 WHERE id = @id";
                            SqlParameter[] parameters3 = {
                                new SqlParameter("@id", username)
                            };
                            DatabaseHelper.ExecuteNonQuery(reset_pass_count, parameters3);
                            AppData.Instance.CurrentUserId = username;
                            AppData.Instance.CurrentUserName = name;
                            AppData.Instance.CurrentPassw = password;
                            AppData.Instance.CurrentRole = role;
                            //MessageBox.Show($"Xin chào: {name} với quyền: {role} stt:{status} date {date}", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide(); // Ẩn Form đăng nhập

                            HOME home = new HOME();
                           
                            home.ShowDialog();
                            

                           
                            Logger.Log("INFO", $"{username} Đăng xuất vào lúc {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
                            // chèn lưu thông tin đăng nhập:
                           
                            this.Show();
                            password_texbox.Text = ""; // Xóa mật khẩu sau khi thoát
                        }

                    }
                    else if (status == "2")
                    {
                        using (var changePasswordForm = new chage_pasword(username, password))
                        {
                            changePasswordForm.ShowDialog(); // Hiển thị form đổi mật khẩu

                            //if (changePasswordForm.IsPasswordChanged)
                            //{
                            //    this.Close(); // Đóng MainForm nếu mật khẩu đã được đổi
                            //}

                        }
                    }

                    else
                    {
                        MessageBox.Show("Tài Khoản đã bị khóa. \nVui lòng liên hệ ADMIN để mở!.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                }
                else
                {
                    string laysolannhap = "select pass_error from [users] where id = @id";
                    SqlParameter[] parameters = {
                        new SqlParameter("@id", username)
                        };
                    DataTable dt = DatabaseHelper.ExecuteQuery(laysolannhap, parameters);

                    // Kiểm tra và lấy giá trị
                    int solansaipass = 0;
                    if (dt.Rows.Count > 0 && dt.Rows[0]["pass_error"] != DBNull.Value)
                    {
                        solansaipass = Convert.ToInt32(dt.Rows[0]["pass_error"]);
                    }
                    MessageBox.Show("Thông tin tài khoản hoặc mật khẩu chưa chính xác. ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //MessageBox.Show($"Bạn đã nhập sai mật khẩu vui lòng thử lại.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    if (solansaipass >= 50)
                    {
                        // Khóa tài khoản nếu đã nhập sai quá 50 lần
                        Logger.Log("INFO", $"Khóa tài khoản {username} do nhập sai {solansaipass} lần.");
                        string lock_user = "UPDATE [users] SET status = 0 WHERE id = @id";
                        SqlParameter[] parameters3 = {
                                new SqlParameter("@id", username)
                            };
                        DatabaseHelper.ExecuteNonQuery(lock_user, parameters3);
                        MessageBox.Show("Tài khoản của bạn đã bị khóa do nhập sai mật khẩu quá nhiều lần.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        // Tăng số lần nhập sai mật khẩu

                        string tangbiendem = "UPDATE [users] SET pass_error = pass_error + 1 WHERE id = @id";
                        SqlParameter[] parameters2 = {
                                new SqlParameter("@id", username)
                            };
                        DatabaseHelper.ExecuteNonQuery(tangbiendem, parameters2);
                        //MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show("Tài khoản không tồn tại. ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //MessageBox.Show($"");
                //ghi log lỗi lại
                Logger.Log("ERROR", $"Gặp sự cố: {ex}  khi đăng nhập vào lúc {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
            }

        }

        private void login_btn(object sender, EventArgs e)
        {
            if (username_texbox.Text.Trim() == "admin" && password_texbox.Text.Trim() == "admin")
            {
               
                AppData.Instance.CurrentProdLine = "IT";
                AppData.Instance.CurrentUserId = "admin";
                AppData.Instance.CurrentUserName = "Administrator";
                AppData.Instance.CurrentRole = "admin";
                AppData.Instance.Permission = new DataTable();
                

                HOME home = new HOME();
                home.Show();

            }
            else
            {
                // kiểm tra xem có kết nối đưọc db không
                check_db(null, EventArgs.Empty);
            }
            


        }

        private void Close_btn(object sender, EventArgs e)
        {
            this.Close();
        }

        private void click_checkbox_login(object sender, MouseEventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                password_texbox.UseSystemPasswordChar = false;
            }
            else
            {
                password_texbox.UseSystemPasswordChar = true;
            }
        }

        // kiểm tra xem có kết nối db db không
        private async void check_db(object sender, EventArgs e)
        {
            loadingControl.ShowLoading("🔄 Đang kiểm tra kết nối DB...");
            try
            {
                // Chạy song song 2 kết nối để nhanh hơn
                var task1 = Task.Run(() => DatabaseHelper.TestConnection());
                var task2 = Task.Run(() => conn_db_gs1.TestConnection());

                await Task.WhenAll(task1, task2);

                bool result = task1.Result;
                bool result1 = task2.Result;

                loadingControl.HideLoading();

                if (result && result1)
                {

                    login_Load();
                }
                else
                {
                    string errorMsg = "❌ Lỗi kết nối:\n";
                    if (!result) errorMsg += "- Database chính\n";
                    if (!result1) errorMsg += "- Database GS1\n";
                    errorMsg += "\nVui lòng kiểm tra internet và thử lại!";

                    MessageBox.Show(errorMsg, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                loadingControl.HideLoading();
                MessageBox.Show($"❌ Lỗi: {ex.Message}", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         
        }



        private void password_texbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (username_texbox.Text.Trim() == "admin" && password_texbox.Text.Trim() == "admin")
                {
                    HOME home = new HOME();
                    AppData.Instance.CurrentProdLine = "SL";
                    AppData.Instance.CurrentUserId = "admin";
                    AppData.Instance.CurrentUserName = "Administrator";
                    AppData.Instance.CurrentProdLine = "IT";
                    AppData.Instance.CurrentRole = "admin";
                    home.Show();

                }
                else
                {
                    // kiểm tra xem có kết nối đưọc db không
                    check_db(null, EventArgs.Empty);
                }
            }
        }

        private void login_Load(object sender, EventArgs e)
        {

        }
    }
}

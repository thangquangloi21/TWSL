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
using TWSL.Common;


namespace TWSL
{
    
    public partial class user_ma : Form
    {
        string id_user;
        string username_user;
        private bool clicktable = true;
        public user_ma(string id, string username)
        {
            Logger.Log("INFO", $"{id} Vào chức năng quản lý người dùng {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
            id_user = id; // Lưu ID người dùng
            username_user = username; // Lưu tên người dùng

            InitializeComponent();
            User_ma_Load();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (func_1.Text == "Lưu")
            {
                update_info_user();
            }
            else
            {
                using (var register = new register_user(id_user, username_user))
                {
                    register.ShowDialog(); // Hiển thị from đăng kí
                }
            }
        }
        // Lấy thông tin người dùng và đổ ra data grid view khi load from
        private void User_ma_Load()
        {
            try
            {
                // Cập nhật lại DataGridView sau khi thay đổi thông tin
                string select_query = "SELECT TOP (1000) [id], [username], [role], [time_chage_pasword], [status], [pass_error], [registrant_id], [registrant_name], [register_date] FROM [users]";
                DataTable result = DatabaseHelper.ExecuteQuery(select_query);
                // Quy đổi ngược giá trị cột role từ tiếng Anh sang tiếng Việt
                //DataTable result = DatabaseHelper.ExecuteQuery(check_user, checkuser);
                // Quy đổi ngược giá trị cột role từ tiếng Anh sang tiếng Việt
                foreach (DataRow row in result.Rows)
                {
                    string role = row["role"].ToString();
                    string status = row["status"].ToString();
                    if (role == "admin")
                    {
                        row["role"] = "Quản trị viên";
                    }
                    else if (role == "worker")
                    {
                        row["role"] = "Người dùng";
                    }
                    else if (role == "user")
                    {
                        row["role"] = "Người phụ trách";
                    }
                    else if (role == "manager")
                    {
                        row["role"] = "Quản lý";
                    }
                    if (status == "1")
                    {
                        row["status"] = "Đang Hoạt động";
                    }
                    if (status == "0")
                    {
                        row["status"] = "Vô hiệu hóa";
                    }
                    if (status == "2")
                    {
                        row["status"] = "Đăng nhập đầu";
                    }

                }
                // Gán DataTable làm nguồn dữ liệu cho DataGridView
                userdata_view.DataSource = result;

                // Gán tên hiển thị cho các cột
                userdata_view.Columns["id"].HeaderText = "ID";
                userdata_view.Columns["username"].HeaderText = "Tên người dùng";
                //userdata_view.Columns["password"].HeaderText = "Mật khẩu";
                userdata_view.Columns["role"].HeaderText = "Quyền";
                userdata_view.Columns["time_chage_pasword"].HeaderText = "Thời gian đổi mật khẩu";
                userdata_view.Columns["status"].HeaderText = "Trạng thái";
                userdata_view.Columns["pass_error"].HeaderText = "Số lần nhập sai mật khẩu";
                userdata_view.Columns["registrant_id"].HeaderText = "ID người đăng ký";
                userdata_view.Columns["registrant_name"].HeaderText = "Tên người đăng ký";
                userdata_view.Columns["register_date"].HeaderText = "Ngày đăng ký";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // hàm này sẽ được gọi khi người dùng nhấn nút "Lưu"
        private void update_info_user()
        {
            //MessageBox.Show("đổi thông tin phải là một số hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            string id_update = id_textBox.Text.Trim(); // Lấy ID người dùng từ TextBox và loại bỏ khoảng trắng đầu và cuối
            string save_username_update = username_textBox.Text.Trim(); // Lấy tên người dùng từ TextBox và loại bỏ khoảng trắng đầu và cuối
            string role_update = role_cbb.Text.Trim(); // Lấy quyền người dùng từ ComboBox và loại bỏ khoảng trắng đầu và cuối
            string status_update = status_cbb.Text.Trim(); // Lấy trạng thái người dùng từ ComboBox và loại bỏ khoảng trắng đầu và cuối
            // hiện message box xác nhận có muốn sửa không
            if (MessageBox.Show($"Cập nhật thông tin cho người dùng {id_update} không?", "Xác nhận",
                         MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    if (string.IsNullOrEmpty(save_username_update))
                    {
                        MessageBox.Show("Tên không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    //quy đổi giá trị trước khi update

                    if (role_update == "Người dùng")
                    {
                        role_update = "worker";
                    }
                    else if (role_update == "Người phụ trách")
                    {
                        role_update = "user";
                    }
                    else if (role_update == "Quản lý")
                    {
                        role_update = "manager";
                    }
                    else if (role_update == "Quản trị viên")
                    {
                        role_update = "admin";
                    }
                    if (status_update == "Đang hoạt động")
                    {
                        status_update = "2";
                    }
                    if (status_update == "Vô hiệu hóa")
                    {
                        status_update = "0";
                    }

                    string update_query = "UPDATE [users] SET username = @Username, role = @Role, status = @Status WHERE id = @UserID";

                    //MessageBox.Show($"Cập nhật thông tin người dùng với ID: {id_update}, Tên: {save_username_update}, Quyền: {role_update}, Trạng thái: {status_update}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SqlParameter[] updateParameters = new SqlParameter[]
                    {
                new SqlParameter("@UserID", id_update),
                new SqlParameter("@Username", save_username_update),
                new SqlParameter("@Role", role_update),
                new SqlParameter("@Status", status_update)
                    };
                    DatabaseHelper.ExecuteNonQuery(update_query, updateParameters);

                    MessageBox.Show("Thay đổi thông tin thành công !", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // viết log thay đổi thông tin người dùng
                    Logger.Log("INFO", $"{id_user} Cập nhật thông tin người dùng {id_update} - Tên: {save_username_update}, Quyền: {role_update}, Trạng thái: {status_update}");
                    status_def();
                    update_user();
                    // viết vào history nếu có thay đổi thông tin
                    // Ghi log thay đổi thông tin người dùng vào bảng History
                    UtilityFunctions.trans_update_user("edit", id_update, save_username_update, role_update, status_update, id_user, username_user, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), id_user);
                    User_ma_Load();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi dữ liệu, vui lòng kiểm tra lại thông tin : " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void update_user()
        {
            // Cập nhật lại DataGridView sau khi thay đổi thông tin
            string select_query = "SELECT TOP (1000) [id], [username], [role], [time_chage_pasword], [status], [pass_error], [registrant_id], [registrant_name], [register_date] FROM [users]";
            DataTable result = DatabaseHelper.ExecuteQuery(select_query);
            // Quy đổi ngược giá trị cột role từ tiếng Anh sang tiếng Việt
            //DataTable result = DatabaseHelper.ExecuteQuery(check_user, checkuser);
            // Quy đổi ngược giá trị cột role từ tiếng Anh sang tiếng Việt
            foreach (DataRow row in result.Rows)
            {
                string role = row["role"].ToString();
                string status = row["status"].ToString();
                if (role == "admin")
                {
                    row["role"] = "Quản trị viên";
                }
                else if (role == "worker")
                {
                    row["role"] = "Người dùng";
                }
                else if (role == "user")
                {
                    row["role"] = "Người phụ trách";
                }
                else if (role == "manager")
                {
                    row["role"] = "Quản lý";
                }
                if (status == "1")
                {
                    row["status"] = "Đang Hoạt động";
                }
                if (status == "0")
                {
                    row["status"] = "Vô hiệu hóa";
                }
                if (status == "2")
                {
                    row["status"] = "Đăng nhập đầu";
                }
            }
            // Gán DataTable làm nguồn dữ liệu cho DataGridView
            userdata_view.DataSource = result;

            // Gán tên hiển thị cho các cột
            userdata_view.Columns["id"].HeaderText = "ID";
            userdata_view.Columns["username"].HeaderText = "Tên người dùng";
            //userdata_view.Columns["password"].HeaderText = "Mật khẩu";
            userdata_view.Columns["role"].HeaderText = "Quyền";
            userdata_view.Columns["time_chage_pasword"].HeaderText = "Thời gian đổi mật khẩu";
            userdata_view.Columns["status"].HeaderText = "Trạng thái";
            userdata_view.Columns["pass_error"].HeaderText = "Số lần nhập sai mật khẩu";
            userdata_view.Columns["registrant_id"].HeaderText = "ID người đăng ký";
            userdata_view.Columns["registrant_name"].HeaderText = "Tên người đăng ký";
            userdata_view.Columns["register_date"].HeaderText = "Ngày đăng ký";
        }
        private void search_user(object sender, EventArgs e)
        {
            try
            {
                    string id_search_ = id_search.Text; // Loại bỏ khoảng trắng đầu và cuối
                    string name_search_ = name_search.Text.Trim(); // Loại bỏ khoảng trắng đầu và cuối
                // không cho click khi cả 2 ô trống
                
                if (string.IsNullOrEmpty(id_search_) && string.IsNullOrEmpty(name_search_))
                {
                    MessageBox.Show("Vui lòng nhập ID hoặc tên người dùng để tìm kiếm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string check_user = "SELECT TOP (1000) [id], [username], [role], [time_chage_pasword], [status], [pass_error], [registrant_id], [registrant_name], [register_date] FROM [users] WHERE username like @Username ";

                    if (!string.IsNullOrEmpty(id_search_))
                    {
                        check_user += " and id = @UserID";
                        // Thêm điều kiện tìm kiếm nếu có ID
                        //  where username like N'%' and id like '%'

                    }


                    // kiểm tra chỉ cho nhập số
                    if (!string.IsNullOrEmpty(id_search_) && !int.TryParse(id_search_, out _))
                    {
                        MessageBox.Show("ID phải là một số hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    SqlParameter[] checkuser = new SqlParameter[]
                   {
                    new SqlParameter("@UserID", id_search_),
                    new SqlParameter("@Username", "%" + name_search_ + "%")
                   };
                    DataTable result = DatabaseHelper.ExecuteQuery(check_user, checkuser);
                    // Quy đổi ngược giá trị cột role từ tiếng Anh sang tiếng Việt
                    foreach (DataRow row in result.Rows)
                    {
                        string role = row["role"].ToString();
                        string status = row["status"].ToString();
                        if (role == "admin")
                        {
                            row["role"] = "Quản trị viên";
                        }
                        else if (role == "worker")
                        {
                            row["role"] = "Người dùng";
                        }
                        else if (role == "user")
                        {
                            row["role"] = "Người phụ trách";
                        }
                        else if (role == "manager")
                        {
                            row["role"] = "Quản lý";
                        }
                        if (status == "1")
                        {
                            row["status"] = "Đang Hoạt động";
                        }
                        if (status == "0")
                        {
                            row["status"] = "Vô hiệu hóa";
                        }
                        if (status == "2")
                        {
                            row["status"] = "Đăng nhập đầu";
                        }
                }
                    // Gán DataTable làm nguồn dữ liệu cho DataGridView
                    userdata_view.DataSource = result;

                    // Gán tên hiển thị cho các cột
                    userdata_view.Columns["id"].HeaderText = "ID";
                    userdata_view.Columns["username"].HeaderText = "Tên người dùng";
                    //userdata_view.Columns["password"].HeaderText = "Mật khẩu";
                    userdata_view.Columns["role"].HeaderText = "Quyền";
                    userdata_view.Columns["time_chage_pasword"].HeaderText = "Thời gian đổi mật khẩu";
                    userdata_view.Columns["status"].HeaderText = "Trạng thái";
                    userdata_view.Columns["pass_error"].HeaderText = "Số lần nhập sai mật khẩu";
                    userdata_view.Columns["registrant_id"].HeaderText = "ID người đăng ký";
                    userdata_view.Columns["registrant_name"].HeaderText = "Tên người đăng ký";
                    userdata_view.Columns["register_date"].HeaderText = "Ngày đăng ký";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void status_def()
        {
            func_1.Text = "Thêm";
            func_2.Text = "Sửa";
            func_3.Text = "Xuất dữ liệu";
            // Khóa các ô nhập liệu
            username_textBox.ReadOnly = true;
            role_cbb.Enabled = false;
            status_cbb.Enabled = false;
            clicktable = true;
        }
        private void status_edit()
        {
            func_1.Text = "Lưu";
            // Kiểm tra xem có dòng nào được chọn không
            func_2.Text = "Hủy";
            func_3.Text = "Reset mật khẩu";
            // cho phép chỉnh sửa trên ô nhập.
            username_textBox.ReadOnly = false;
            role_cbb.Enabled = true;
            status_cbb.Enabled = true;
            clicktable = false;
        }


        private void Button3_Click(object sender, EventArgs e)
        {
            if (func_2.Text == "Hủy")
            {
                status_def();
            }
            else
            {
                // Kiểm tra xem có dòng nào được chọn không'
                if(string.IsNullOrEmpty(id_textBox.Text) || string.IsNullOrEmpty(username_textBox.Text) || string.IsNullOrEmpty(role_cbb.Text) || string.IsNullOrEmpty(status_cbb.Text))
                {
                    MessageBox.Show("Vui lòng chọn người dùng để sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    status_edit();
                }
                
            }
        }

        private void Userdata_view_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (clicktable == false)
            {
                return;
            } 
            // Kiểm tra dòng được chọn có hợp lệ không
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = userdata_view.Rows[e.RowIndex];

                // Gán dữ liệu từ các cột vào TextBox
                id_textBox.Text = row.Cells[0].Value.ToString(); // Cột 1
                username_textBox.Text = row.Cells[1].Value.ToString(); // Cột 2
                role_cbb.Text = row.Cells[2].Value.ToString(); // Cột 3
                status_cbb.Text = row.Cells[4].Value.ToString(); // Cột 5
            }
        }

        private void Func_3_Click(object sender, EventArgs e)
        {
            if (func_3.Text == "Reset mật khẩu")
            {
                try
                {
                    // Nếu nhấn Cancel thì tự động bỏ qua
                    string id_reset = id_textBox.Text.Trim(); // Lấy ID người dùng từ TextBox và loại bỏ khoảng trắng đầu và cuối
                    string username_reset = username_textBox.Text.Trim(); // Lấy tên người dùng từ TextBox và loại bỏ khoảng trắng đầu và cuối
                    //mã hóa mât khẩu
                    string id_reset_1 = BCrypt.Net.BCrypt.HashPassword(id_reset);
                    if (MessageBox.Show($"Bạn có muốn khôi phục mật khẩu cho {username_reset} Không?", "Xác nhận",
                     MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        string update_query = "UPDATE [users] SET status = '2', password = @password WHERE id = @UserID";
                        //MessageBox.Show($"Cập nhật thông tin người dùng với ID: {id_update}, Tên: {save_username_update}, Quyền: {role_update}, Trạng thái: {status_update}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SqlParameter[] updateParameters = new SqlParameter[]
                        {
                    new SqlParameter("@UserID", id_reset),
                    new SqlParameter("@password", id_reset_1),
                        };
                        DatabaseHelper.ExecuteNonQuery(update_query, updateParameters);
                        MessageBox.Show($"Reset thành công mật khẩu mặc định sẽ là ID.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Logger.Log("INFO", $"{id_user} reset mật khẩu cho {id_reset}");
                        // reset xong thì  trả về nút ban đầu
                        status_def();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi reset mật khẩu: " + ex.Message + "\n Vui lòng liên hệ admin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            else
            {
                // Xuất dữ liệu ra file Excel

                MessageBox.Show("Xuất dữ liệu tài khoản thành công.", "Xuất dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}

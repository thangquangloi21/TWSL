using TWSL.Common;
using TWSL.Forms;
using OfficeOpenXml;
using Org.BouncyCastle.Crypto.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace TWSL
{

    
    public partial class from_master : Form
    {
        private loading_wait loading;
        //private string User_id = "";
        //private string user_name = "";
        //private string user_role = "";
        private readonly string User_id = "";
        private readonly string user_name = "";
        private readonly string user_role = "";
        public from_master(string userid, string username, string _role)
        {
            User_id = userid; // Lưu ID người dùng
            user_name = username; // Lưu tên người dùng
            user_role = _role; // Lưu vai trò người dùng
            ExcelPackage.License.SetNonCommercialPersonal("Your Name");
            InitializeComponent();
            Update_data();
            loading = new loading_wait();
            Logger.Log("INFO", $"{User_id} Vào chức năng quản lý Master {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
            this.Controls.Add(loading);

        }

        private void upload_master(string filePath) {
            try
            {
                    // Bạn cần cài đặt thư viện EPPlus để làm việc với file Excel
                    using (var package = new OfficeOpenXml.ExcelPackage(new FileInfo(filePath)))
                    {
                        // Lấy worksheet đầu tiên
                        var worksheet = package.Workbook.Worksheets[0];
                        int rowCount = worksheet.Dimension.Rows;
                        string stt = worksheet.Cells[1, 1].Text.Trim();
                        string ITEMCODE = worksheet.Cells[1, 2].Text.Trim();
                        string CHUNGLOAI = worksheet.Cells[1, 3].Text.Trim();
                        string MACHINE = worksheet.Cells[1, 4].Text.Trim();
                        string LOT = worksheet.Cells[1, 5].Text.Trim();
                        string TIME = worksheet.Cells[1, 6].Text.Trim();
                        //int colCount = worksheet.Dimension.Columns;
                        // kiểm tra xem đúng định dạng file chưa
                        Console.WriteLine($"STT: {stt}, ITEMCODE: {itemcode}, CHUNGLOAI: {CHUNGLOAI}, MACHINE: {MACHINE}, LOT: {LOT}, TIME: {TIME}");
                        if (stt != "STT" || ITEMCODE != "ITEMCODE" || CHUNGLOAI != "CHUNGLOAI" || MACHINE != "MACHINE" || LOT != "LOT" || TIME != "TIME")
                        {
                            MessageBox.Show("File chưa đúng định dạng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        // Duyệt qua từng hàng và cột để lấy dữ liệu
                        //lấy thời gian ngày tháng hiện tại
                        DateTime time = DateTime.Now;
                        for (int row = 2; row <= rowCount; row++) // Bỏ qua hàng tiêu đề
                        {
                            string itemcode = worksheet.Cells[row, 2].Text.Trim(); // Cột B
                                                                                   // *** KIỂM TRA HÀNG CÓ DỮ LIỆU ***
                            if (string.IsNullOrEmpty(itemcode))
                            {
                                // Bỏ qua hàng nếu cột B (itemcode) rỗng
                                continue;
                            }
                            string generic = worksheet.Cells[row, 3].Text.Trim(); // Cột C
                            string machine = worksheet.Cells[row, 4].Text.Trim(); // Cột D
                            string lot = worksheet.Cells[row, 5].Text.Trim(); // Cột E
                            string Degassing_time = worksheet.Cells[row, 6].Text.Trim(); // Cột F
                            string itemcode1 = "";
                            string machine1 = "";
                            string lot1 = "";
                            string listdata1 = "";
                            string inp_listdata = $"{itemcode}{machine}{lot}{Degassing_time}{generic}";
                            //kiểm tra dữ liệu đã tồn tại trong database chưa
                            // lấy dữ liệu trong db ra

                            string check_master_data = "SELECT * FROM [MASTER] WHERE itemcode = @itemcode and machine = @machine and lot = @lot";
                            SqlParameter[] checkuser = new SqlParameter[]
                            {
                            new SqlParameter("@itemcode", itemcode),
                            new SqlParameter("@machine", machine),
                            new SqlParameter("@lot", lot),
                            };
                            DataTable result = DatabaseHelper.ExecuteQuery(check_master_data, checkuser);

                            //int count = Convert.ToInt32(result.Rows[0][0]);
                            foreach (DataRow row1 in result.Rows)
                            {
                                itemcode1 = row1["itemcode"].ToString();
                                machine1 = row1["machine"].ToString();
                                lot1 = row1["lot"].ToString();
                                string degassingTime1 = row1["Degassing_time"].ToString();
                                string generic1 = row1["generic"].ToString();
                                // Cộng chuỗi với định dạng tùy ý (ví dụ: ngăn cách bằng dấu gạch ngang)
                                listdata1 = $"{itemcode1}{machine1}{lot1}{degassingTime1}{generic1}";

                            }
                        // nếu chưa có thì thêm mới
                        if (listdata1 == "")
                        {
                            // Nếu chưa tồn tại, thực hiện thêm mới vào database
                            string insertQuery = "INSERT INTO [MASTER] (itemcode, generic,machine, lot, Degassing_time, time_of_registration, registrant, status_item) " +
                              "VALUES (@itemcode, @generic, @machine, @lot, @Degassing_time, @time_of_registration, @registrant, @status)";
                            SqlParameter[] parameters = new SqlParameter[]
                                {
                                        new SqlParameter("@itemcode", itemcode),
                                        new SqlParameter("@machine", machine),
                                        new SqlParameter("@lot", lot),
                                        new SqlParameter("@generic", generic),
                                        new SqlParameter("@time_of_registration", UtilityFunctions.getdate_time1()),
                                        new SqlParameter("@Degassing_time", Degassing_time),
                                        new SqlParameter("@registrant", user_name),
                                        new SqlParameter("@status", '0') // 0 có nghĩa là chưa duyệt, 1 là đã duyệt

                                 };
                            DatabaseHelper.ExecuteNonQuery(insertQuery, parameters);

                            // thêm mới dữ liệu
                            //thêm vào db masster history   
                            UtilityFunctions.trans_master("add", itemcode, generic, machine, lot, Degassing_time, user_name, UtilityFunctions.getdate_time1(), "", "", "0", user_name);
                            //MessageBox.Show("Chưa có mã này");
                            continue;
                        }
                        else if (listdata1 == inp_listdata)
                        {
                            //MessageBox.Show("Đã có mã này và trùng dữ liệu, Bỏ qua");
                            continue;
                        }
                        else if (listdata1 != inp_listdata)
                        {
                            //MessageBox.Show("Đã có mã này và khác dữ liệu, Tiến hành thay đổi");
                            //update dữ liệu theo itemcode, machine, lot
                            string Updatemaster1 = " update [MASTER] set Degassing_time = @Degassing_time, generic = @generic , status_item = '0', time_of_approval = NULL " +
                                "where itemcode = @itemcode and machine = @machine and lot = @lot ";
                            SqlParameter[] update_master1 = new SqlParameter[]
                               {
                                        new SqlParameter("@itemcode", itemcode),
                                        new SqlParameter("@machine", machine),
                                        new SqlParameter("@lot", lot),
                                        new SqlParameter("@generic", generic),
                                        new SqlParameter("@Degassing_time", Degassing_time),
                                };
                            // ghi vào db sửa dữ liệu
                            DatabaseHelper.ExecuteNonQuery(Updatemaster1, update_master1);
                            // sửa dữ liệu

                            UtilityFunctions.trans_master("modify", itemcode, generic, machine, lot, Degassing_time, user_name, UtilityFunctions.getdate_time1(), "", "", "0",user_name);
                            continue;
                            }
                        }
                    }
                MessageBox.Show("Đã tải file: " + filePath, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void up_data_master(object sender, EventArgs e)
        {
            try
            {
                string filePath = "";
                // Mở hộp thoại chọn file Excel
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    loading.ShowLoading();
                    Task.Run(() =>
                    {   
                        filePath = openFileDialog.FileName;
                        upload_master(filePath);
                        
                        this.Invoke(new Action(() =>
                        {
                            loading.HideLoading();
                            //MessageBox.Show("Hoàn thành!");
                            
                            Update_data();
                        }));
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          


        }

        //private void up_data_master(object sender, EventArgs e)
        //{
        //// load hàng loạt bằng file excel và đẩy vào database
        //    try
        //    {

        //        // Mở hộp thoại chọn file Excel
        //        OpenFileDialog openFileDialog = new OpenFileDialog();
        //        openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
        //        if (openFileDialog.ShowDialog() == DialogResult.OK)
        //        {
        //            string filePath = openFileDialog.FileName;
        //            // Gọi hàm để xử lý file Excel và lưu vào database
        //            // Ví dụ: LoadExcelToDatabase(filePath);

        //            //đọc fie excel và lưu vào database theo định dạng đã quy định bằng eplus


        //            // Bạn cần cài đặt thư viện EPPlus để làm việc với file Excel
        //            using (var package = new OfficeOpenXml.ExcelPackage(new FileInfo(filePath)))
        //            {
        //                // Lấy worksheet đầu tiên
        //                var worksheet = package.Workbook.Worksheets[0];
        //                int rowCount = worksheet.Dimension.Rows;
        //                //int colCount = worksheet.Dimension.Columns;


        //                // Duyệt qua từng hàng và cột để lấy dữ liệu
        //                //lấy thời gian ngày tháng hiện tại
        //                DateTime time = DateTime.Now;
        //                for (int row = 2; row <= rowCount; row++) // Bỏ qua hàng tiêu đề
        //                {
        //                    string itemcode = worksheet.Cells[row, 2].Text.Trim(); // Cột B
        //                     // *** KIỂM TRA HÀNG CÓ DỮ LIỆU ***
        //                    if (string.IsNullOrEmpty(itemcode))
        //                    {
        //                        // Bỏ qua hàng nếu cột B (itemcode) rỗng
        //                        continue;
        //                    }
        //                    string generic = worksheet.Cells[row, 3].Text.Trim(); // Cột C
        //                    string machine = worksheet.Cells[row, 4].Text.Trim(); // Cột D
        //                    string lot = worksheet.Cells[row, 5].Text.Trim(); // Cột E
        //                    string Degassing_time = worksheet.Cells[row, 6].Text.Trim(); // Cột F

        //                    // Thêm logic để lưu dữ liệu vào database tại đây

        //                    //kiểm tra dữ liệu đã tồn tại trong database chưa
        //                    string check_user = "SELECT COUNT(*) FROM [MASTER] WHERE itemcode = @itemcode and machine = @machine";
        //                    SqlParameter[] sqldelete = new SqlParameter[]
        //                    {
        //                    new SqlParameter("@itemcode", itemcode),
        //                    new SqlParameter("@machine", machine),
        //                    };
        //                    DataTable result = DatabaseHelper.ExecuteQuery(check_user, sqldelete);
        //                    int count = Convert.ToInt32(result.Rows[0][0]);
        //                    // nếu đã tồn tại thì kiểm tra xem có trùng dữ liệu không
        //                    if (count > 0)
        //                    {
        //                        // nếu chỉ có 1 dữ liệu lấy dữ liệu để so sánh
        //                        if (count == 1)
        //                        {
        //                            string itemcode1 = "";
        //                            string machine1 = "";
        //                            string lot1 = "";
        //                            // kiểm tra xem có khác không nếu khác thì update.
        //                            // Nếu đã tồn tại, bạn có thể chọn bỏ qua hoặc cập nhật dữ liệu tùy theo yêu cầu
        //                            // kiểm tra xem có trùng không nếu trùng thì update dữ liệu mới.
        //                            // Nếu đã tồn tại, bạn có thể chọn bỏ qua hoặc cập nhật dữ liệu tùy theo yêu cầu

        //                            string checkdata1 = "SELECT * FROM [MASTER] WHERE itemcode = @itemcode and machine = @machine";
        //                            SqlParameter[] check_data1 = new SqlParameter[]
        //                            {
        //                        new SqlParameter("@itemcode", itemcode),
        //                        new SqlParameter("@machine", machine),
        //                        new SqlParameter("@lot", lot),
        //                            };
        //                            DataTable data = DatabaseHelper.ExecuteQuery(checkdata1, check_data1);

        //                            string listdata1 = "";
        //                            string inp_listdata1 = $"{itemcode}{machine}{lot}{Degassing_time}{generic}";

        //                            foreach (DataRow row1 in data.Rows)
        //                            {
        //                                itemcode1 = row1["itemcode"].ToString();
        //                                machine1 = row1["machine"].ToString();
        //                                lot1 = row1["lot"].ToString();
        //                                string degassingTime1 = row1["Degassing_time"].ToString();
        //                                string generic1 = row1["generic"].ToString();
        //                                // Cộng chuỗi với định dạng tùy ý (ví dụ: ngăn cách bằng dấu gạch ngang)
        //                                listdata1 = $"{itemcode1}{machine1}{lot1}{degassingTime1}{generic1}";

        //                            }
        //                            //MessageBox.Show($"list data = {listdata1}, inp list data  = {inp_listdata1}");



        //                            // nếu trùng dữ liệu thì bỏ qua
        //                            if (listdata1 == inp_listdata1)
        //                            {
        //                                continue; // Bỏ qua vòng lặp hiện tại và chuyển sang dòng tiếp theo
        //                            }


        //                            // nếu đã tồn tại nhưng dữ liệu không trùng thì tiến hành chỉnh sửa theo dữ liệu mới
        //                            else if (listdata1 != inp_listdata1)
        //                            {

        //                                //Update dữ liệu
        //                                string Updatemaster1 = " update [MASTER] set lot = @lot, Degassing_time = @Degassing_time, generic = @generic " +
        //                                    "where itemcode = @itemcode1 and machine = @machine1 and lot = @lot1 ";
        //                                SqlParameter[] update_master1 = new SqlParameter[]
        //                                {
        //                                    // thông tin cần update
        //                                new SqlParameter("@generic", generic),
        //                                new SqlParameter("@lot", lot),
        //                                new SqlParameter("@Degassing_time", Degassing_time),
        //                                // điều kiện để update
        //                                new SqlParameter("@itemcode1", itemcode1),
        //                                new SqlParameter("@machine1", machine1),
        //                                new SqlParameter("@lot1", lot1),
        //                                };
        //                                DatabaseHelper.ExecuteNonQuery(Updatemaster1, update_master1);
        //                            }

        //                        }

        //                        // trường hợp 1 máy có nhiều lot
        //                        if (count > 1)
        //                        {

        //                            string itemcodes = "";
        //                            string machines = "";
        //                            string lots = "";
        //                            string degassingTimes = "";
        //                            string generics = "";

        //                            // kiểm tra xem có trùng không nếu trùng thì update dữ liệu mới.
        //                            // Nếu đã tồn tại, bạn có thể chọn bỏ qua hoặc cập nhật dữ liệu tùy theo yêu cầu
        //                            string checkdata = "SELECT * FROM [MASTER] WHERE itemcode = @itemcode and machine = @machine and lot = @lot";
        //                            SqlParameter[] check_data = new SqlParameter[]
        //                            {
        //                        new SqlParameter("@itemcode", itemcode),
        //                        new SqlParameter("@machine", machine),
        //                        new SqlParameter("@lot", lot),
        //                            };
        //                            DataTable data = DatabaseHelper.ExecuteQuery(checkdata, check_data);

        //                            string listdata = "";
        //                            string inp_listdata = $"{itemcode}{machine}{lot}{Degassing_time}";

        //                            foreach (DataRow row1 in data.Rows)
        //                            {
        //                                itemcodes = row1["itemcode"].ToString();
        //                                machines = row1["machine"].ToString();
        //                                lots = row1["lot"].ToString();
        //                                degassingTimes = row1["Degassing_time"].ToString();
        //                                generics = row1["generic"].ToString();
        //                                // Cộng chuỗi với định dạng tùy ý (ví dụ: ngăn cách bằng dấu gạch ngang)
        //                                listdata = $"{itemcodes}{machines}{lots}{degassingTimes}{generics}";
        //                            }
        //                            //MessageBox.Show($"list data = {listdata1}, inp list data  = {inp_listdata1}");

        //                            // nếu dữ liệu truy vấn ra == null thì tiến hành thêm mới
        //                            if (listdata == "")
        //                            {
        //                                // Nếu chưa tồn tại, thực hiện thêm mới vào database
        //                                string insertQuery = "INSERT INTO [MASTER] (itemcode, generic,machine, lot, Degassing_time, time_of_registration, registrant, status_item) " +
        //                                  "VALUES (@itemcode, @generic, @machine, @lot, @Degassing_time, @time_of_registration, @registrant, @status)";
        //                                SqlParameter[] parameters = new SqlParameter[]
        //                                {
        //                                new SqlParameter("@itemcode", itemcode),
        //                                new SqlParameter("@generic", generic),
        //                                new SqlParameter("@machine", machine),
        //                                new SqlParameter("@lot", lot),
        //                                new SqlParameter("@Degassing_time", Degassing_time),
        //                                new SqlParameter("@time_of_registration", time),
        //                                new SqlParameter("@registrant", user_name),
        //                                new SqlParameter("@status", '0') // 0 có nghĩa là chưa duyệt, 1 là đã duyệt
        //                                };
        //                                DatabaseHelper.ExecuteNonQuery(insertQuery, parameters);
        //                            }


        //                            // nếu trùng dữ liệu thì bỏ qua
        //                            else if (listdata == inp_listdata)
        //                            {
        //                                continue; // Bỏ qua vòng lặp hiện tại và chuyển sang dòng tiếp theo
        //                            }

        //                            // nếu đã tồn tại nhưng dữ liệu không trùng thì tiến hành chỉnh sửa theo dữ liệu mới
        //                            else if (listdata != inp_listdata)
        //                            {
        //                                //Update dữ liệu
        //                                string Updatemaster1 = " update [MASTER] set lot = @lot, Degassing_time = @Degassing_time, generic = @generic " +
        //                                    "where itemcode = @itemcodes and machine = @machines and lot = @lots ";
        //                                SqlParameter[] update_master1 = new SqlParameter[]
        //                                {
        //                                    // thông tin cần update
        //                                new SqlParameter("@generic", generic),
        //                                new SqlParameter("@lot", lot),
        //                                new SqlParameter("@Degassing_time", Degassing_time),
        //                                // điều kiện để update
        //                                new SqlParameter("@itemcodes", itemcodes),
        //                                new SqlParameter("@machines", machines),
        //                                new SqlParameter("@lots", lots),
        //                                };
        //                                DatabaseHelper.ExecuteNonQuery(Updatemaster1, update_master1);
        //                            }
        //                        }


        //                    }
        //                    else
        //                    {
        //                        // Nếu chưa tồn tại, thực hiện thêm mới vào database
        //                        string insertQuery = "INSERT INTO [MASTER] (itemcode, generic,machine, lot, Degassing_time, time_of_registration, registrant, status_item) " +
        //                          "VALUES (@itemcode, @generic, @machine, @lot, @Degassing_time, @time_of_registration, @registrant, @status)";
        //                        SqlParameter[] parameters = new SqlParameter[]
        //                        {
        //                            new SqlParameter("@itemcode", itemcode),
        //                            new SqlParameter("@generic", generic),
        //                            new SqlParameter("@machine", machine),
        //                            new SqlParameter("@lot", lot),
        //                            new SqlParameter("@Degassing_time", Degassing_time),
        //                            new SqlParameter("@time_of_registration", time),
        //                            new SqlParameter("@registrant", user_name),
        //                            new SqlParameter("@status", '0') // 0 có nghĩa là chưa duyệt, 1 là đã duyệt
        //                        };
        //                        DatabaseHelper.ExecuteNonQuery(insertQuery, parameters);
        //                    }
        //                    // Ví dụ: DatabaseHelper.ExecuteNonQuery("INSERT INTO YourTable (Column1, Column2) VALUES (@data1, @data2)", new SqlParameter[] { new SqlParameter("@data1", data1), new SqlParameter("@data2", data2) });
        //                }
        //            }


        //         MessageBox.Show("Đã tải file: " + filePath, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }

        //    }

        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Lỗi khi tải file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //update datagrid view
        // Load data khi mở form
        private void Update_data()
        {
            try
            {
                string check_user = "SELECT [itemcode],[generic], [machine], [lot] ,[Degassing_time] ,[registrant] ,[time_of_registration] ,[approver] ,[time_of_approval] ,[status_item] FROM [MASTER] where status_item in ('0','1','2')";
                string item_code = itemcode.Text.Trim(); // Loại bỏ khoảng trắng đầu và cuối
                string machine = version_tbx.Text.Trim(); // Loại bỏ khoảng trắng đầu và cuối
                                                          //string name_search_ = id_reg.Text.Trim(); // Loại bỏ khoảng trắng đầu và cuối
                string status_ = statuscbb.Text.Trim();
                if (status_ == "Chưa phê duyệt")
                {
                    status_ = "0";
                }
                else if (status_ == "Đã phê duyệt")
                {
                    status_ = "1";
                }
                else if (status_ == "Vô Hiệu hóa")
                {
                    status_ = "2";
                }

                    if (!string.IsNullOrEmpty(status_))
                {
                    check_user = "SELECT [itemcode],[generic], [machine], [lot] ,[Degassing_time] ,[registrant] ,[time_of_registration] ,[approver] ,[time_of_approval] ,[status_item] FROM [MASTER] where status_item = @status ";
                }

                if (!string.IsNullOrEmpty(item_code))
                {
                    check_user += " and itemcode = @itemcode";
                    // Thêm điều kiện tìm kiếm nếu có ID
                    //  where username like N'%' and id like '%'
                }


                if (!string.IsNullOrEmpty(machine))
                {
                    check_user += " and machine = @machine";
                    // Thêm điều kiện tìm kiếm nếu có ID
                    //  where username like N'%' and id like '%'

                }


                SqlParameter[] checkuser = new SqlParameter[]
               {
                    new SqlParameter("@itemcode", item_code),
                    new SqlParameter("@machine", machine)
                    ,new SqlParameter("@status", status_)
                    //new SqlParameter("@Username", "%" + name_search_ + "%")
               };
                DataTable result = DatabaseHelper.ExecuteQuery(check_user, checkuser);
                // Đổi giá trị để hiển tn trong DataGridView
                foreach (DataRow row in result.Rows)
                {
                    string status = row["status_item"].ToString();
                    if (status == "1")
                    {
                        row["status_item"] = "Đã phê duyệt";
                    }
                    else if (status == "0")
                    {
                        row["status_item"] = "Chưa phê duyệt";
                    }
                    else if (status == "2")
                    {
                        row["status_item"] = "Vô Hiệu hóa";
                    }

                }
                // Gán DataTable làm nguồn dữ liệu cho DataGridView
                masterdata_view.DataSource = result;


                // Gán tên hiển thị cho các cột
                masterdata_view.Columns["itemcode"].HeaderText = "Mã sản phẩm";
                masterdata_view.Columns["generic"].HeaderText = "Chủng loại";
                masterdata_view.Columns["machine"].HeaderText = "Máy";
                masterdata_view.Columns["lot"].HeaderText = "Lot";
                //userdata_view.Columns["password"].HeaderText = "Mật khẩu";
                masterdata_view.Columns["Degassing_time"].HeaderText = "Thời gian thoát khí(Giờ)";
                masterdata_view.Columns["registrant"].HeaderText = "Người đăng kí";
                masterdata_view.Columns["time_of_registration"].HeaderText = "Thời gian đăng kí";
                masterdata_view.Columns["approver"].HeaderText = "Người phê duyệt";
                masterdata_view.Columns["time_of_approval"].HeaderText = "Thời gian phê duyệt";
                masterdata_view.Columns["status_item"].HeaderText = "Trạng thái";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void Button1_Click(object sender, EventArgs e)
        {
            Update_data();
        }

        private void Masterdata_view_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo hit = masterdata_view.HitTest(e.X, e.Y);

                if (hit.RowIndex >= 0 && hit.ColumnIndex >= 0)
                {
                    // Kiểm tra xem có phải đang click vào vùng đã chọn không
                    DataGridViewCell clickedCell = masterdata_view[hit.ColumnIndex, hit.RowIndex];

                    if (!clickedCell.Selected)
                    {
                        // Nếu click vào cell chưa được chọn, thì chọn cell đó
                        masterdata_view.ClearSelection();
                        clickedCell.Selected = true;
                    }
                    // Nếu click vào cell đã được chọn, giữ nguyên selection

                    // Hiển thị context menu tại vị trí click
                    ShowContextMenu(e.Location);
                }
            }
        }
        //private void ShowContextMenu(Point location)
        //{
        //    // Context menu của bạn
        //    ContextMenuStrip contextMenu = new ContextMenuStrip();
        //    contextMenu.Items.Add("Phê Duyệt", null, Appro);
        //    contextMenu.Items.Add("Vô Hiệu Hóa", null, Disable);
        //    contextMenu.Items.Add("-"); // Separator
        //    //ẩn nút chỉnh sửa
        //    contextMenu.Items.Add("Chỉnh sửa", null);
        //    contextMenu.Items.Add("Xóa", null);
        //    contextMenu.Show(masterdata_view, location);

        //}
        private void ShowContextMenu(Point location)
        {
            // Context menu của bạn
            ContextMenuStrip contextMenu = new ContextMenuStrip();
            //contextMenu.Items.Add("Phê Duyệt", null, Appro);
            //contextMenu.Items.Add("Vô Hiệu Hóa", null, Disable);
            

            // Tạo các nút riêng biệt để dễ dàng truy cập và kiểm soát

            ToolStripMenuItem appro_master = new ToolStripMenuItem("Phê Duyệt", null, Appro);
            ToolStripMenuItem disable = new ToolStripMenuItem("Vô hiệu hóa", null, Disable);
            ToolStripMenuItem delete = new ToolStripMenuItem("Xóa", null, Delete);

            // Thêm các nút vào menu
            contextMenu.Items.Add(appro_master);
            contextMenu.Items.Add(disable);
            contextMenu.Items.Add(delete);

            // Lấy trạng thái từ dòng được chọn
            // Giả sử cột thứ 2 (index 1) là cột trạng thái, và giá trị "1" nghĩa là đã phê duyệt
            string status = "";
            if (masterdata_view.SelectedCells.Count > 0)
            {
                int rowIndex = masterdata_view.SelectedCells[0].RowIndex;
                if (rowIndex >= 0)
                {
                    status = masterdata_view.Rows[rowIndex].Cells[9].Value?.ToString() ?? "";
                }
            }

            Console.WriteLine(status);
            // Kiểm tra điều kiện và ẩn/hiện các nút
            // Nếu trạng thái là "1" (đã phê duyệt), ẩn các nút "Chỉnh sửa" và "Xóa"
            if (status == "Đã phê duyệt")
            {
                Console.WriteLine(user_role);
                //editItem.Enabled = false;
                delete.Enabled = false;
                appro_master.Enabled = false;
                //disable.Enabled = false;
                if (user_role == "user")
                {
                    delete.Enabled = false;
                    appro_master.Enabled = false;
                    disable.Enabled = false;
                }
            }
            if (status == "Vô Hiệu hóa")
            {
                disable.Enabled = false;
                if (user_role == "user")
                {
                    delete.Enabled = false;
                    appro_master.Enabled = false;
                    disable.Enabled = false;
                }

            }


            contextMenu.Show(masterdata_view, location);
        }

        // Thêm các phương thức xử lý sự kiện cho "Phê duyệt" và "Xóa"
        
        // xóa dữ liệu
        private void Delete_data(string itemcode, string machine, string Degassing_time, string lot)
        {
            //DateTime getdate = DateTime.Now;
            string deletedata = "delete [MASTER] where itemcode = @itemcode and machine = @machine and lot = @lot and Degassing_time = @Degassing_time";
            SqlParameter[] sqldelete = new SqlParameter[]
           {
                    new SqlParameter("@itemcode", itemcode),
                    new SqlParameter("@machine", machine),
                    new SqlParameter("@Degassing_time", Degassing_time),
                    new SqlParameter("@lot", lot),
           };
            DatabaseHelper.ExecuteNonQuery(deletedata, sqldelete);


        }
        //xóa
        private void Delete(object sender, EventArgs e)
        {
            using (var authenfrom = new authentication_from())
            {
                //authenfrom.ShowDialog();
                if (authenfrom.ShowDialog() == DialogResult.OK)
                {
                    loading.ShowLoading();

                    Task.Run(() =>
                    {
                        Delete_data()
                       ;
                        this.Invoke(new Action(() =>
                        {
                            loading.HideLoading();
                            //MessageBox.Show("Hoàn thành!");
                            Update_data();
                        }));
                    });


                }
            }
        }
        private void Delete_data()
        {
            try
            {

                if (masterdata_view.SelectedCells.Count > 0)
                {
                    // Lấy danh sách các row index duy nhất từ các cells được chọn
                    var selectedRowIndices = masterdata_view.SelectedCells
                        .Cast<DataGridViewCell>()
                        .Select(cell => cell.RowIndex)
                        .Distinct()
                        .ToList();

                    foreach (int rowIndex in selectedRowIndices)
                    {
                        // Lấy dữ liệu từ gridview để xóa
                        string itemcode = masterdata_view.Rows[rowIndex].Cells["itemcode"].Value?.ToString() ?? "";
                        string generic = masterdata_view.Rows[rowIndex].Cells["generic"].Value?.ToString() ?? "";
                        string machine = masterdata_view.Rows[rowIndex].Cells["machine"].Value?.ToString() ?? "";
                        string lot = masterdata_view.Rows[rowIndex].Cells["lot"].Value?.ToString() ?? "";
                        string Degassing_time = masterdata_view.Rows[rowIndex].Cells["Degassing_time"].Value?.ToString() ?? "";
                        string registrant = masterdata_view.Rows[rowIndex].Cells["registrant"].Value?.ToString() ?? "";
                        string time_of_registration = masterdata_view.Rows[rowIndex].Cells["time_of_registration"].Value?.ToString() ?? "";
                        string approver = masterdata_view.Rows[rowIndex].Cells["approver"].Value?.ToString() ?? "";
                        string time_of_approval = masterdata_view.Rows[rowIndex].Cells["time_of_approval"].Value?.ToString() ?? "";
                        string status_item = masterdata_view.Rows[rowIndex].Cells["status_item"].Value?.ToString() ?? "";
                        string formattedDate1 = "";
                        if (!string.IsNullOrWhiteSpace(time_of_registration))
                        {
                            DateTime dt;
                            if (DateTime.TryParse(time_of_registration, out dt))
                            {
                                formattedDate1 = dt.ToString("yyyy-MM-dd HH:mm:ss");
                            }
                        }
                        string formattedDate2 = "";
                        if (!string.IsNullOrWhiteSpace(time_of_approval))
                        {
                            DateTime dt;
                            if (DateTime.TryParse(time_of_approval, out dt))
                            {
                                formattedDate2 = dt.ToString("yyyy-MM-dd HH:mm:ss");
                            }
                        }


                        //Update_status("1", itemcode, machine, Degassing_time, lot);
                        Delete_data(itemcode, machine, Degassing_time, lot);
                        UtilityFunctions.trans_master("delete", itemcode, generic, machine, lot, Degassing_time, registrant, formattedDate1, approver, formattedDate2, status_item, user_name);
                        //MessageBox.Show($"Xóa dữ liệu");
                        //MessageBox.Show($"phê duyệt Row {rowIndex} - Cột 1: {itemcode}, Cột 3: {version}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi Xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        

        // phê duyệt dữ liệu
        private void Appro_data()
        {
            try
            {

                if (masterdata_view.SelectedCells.Count > 0)
                {
                    // Lấy danh sách các row index duy nhất từ các cells được chọn
                    var selectedRowIndices = masterdata_view.SelectedCells
                        .Cast<DataGridViewCell>()
                        .Select(cell => cell.RowIndex)
                        .Distinct()
                        .ToList();

                    foreach (int rowIndex in selectedRowIndices)
                    {
                        // Lấy dữ liệu từ để phê duyệt
                        string itemcode = masterdata_view.Rows[rowIndex].Cells["itemcode"].Value?.ToString() ?? "";
                        string generic = masterdata_view.Rows[rowIndex].Cells["generic"].Value?.ToString() ?? "";
                        string machine = masterdata_view.Rows[rowIndex].Cells["machine"].Value?.ToString() ?? "";
                        string lot = masterdata_view.Rows[rowIndex].Cells["lot"].Value?.ToString() ?? "";
                        string Degassing_time = masterdata_view.Rows[rowIndex].Cells["Degassing_time"].Value?.ToString() ?? "";
                        string registrant = masterdata_view.Rows[rowIndex].Cells["registrant"].Value?.ToString() ?? "";
                        string time_of_registration = masterdata_view.Rows[rowIndex].Cells["time_of_registration"].Value?.ToString() ?? "";
                        string approver = masterdata_view.Rows[rowIndex].Cells["approver"].Value?.ToString() ?? "";
                        string time_of_approval = masterdata_view.Rows[rowIndex].Cells["time_of_approval"].Value?.ToString() ?? "";
                        string status_item = masterdata_view.Rows[rowIndex].Cells["status_item"].Value?.ToString() ?? "";

                        string formattedDate1 = "";
                        if (!string.IsNullOrWhiteSpace(time_of_registration))
                        {
                            DateTime dt;
                            if (DateTime.TryParse(time_of_registration, out dt))
                            {
                                formattedDate1 = dt.ToString("yyyy-MM-dd HH:mm:ss");
                            }
                        }
                        string formattedDate2 = "";
                        if (!string.IsNullOrWhiteSpace(time_of_approval))
                        {
                            DateTime dt;
                            if (DateTime.TryParse(time_of_approval, out dt))
                            {
                                formattedDate2 = dt.ToString("yyyy-MM-dd HH:mm:ss");
                            }
                        }



                        Update_status("1", itemcode, machine, Degassing_time, lot);

                        //UtilityFunctions.trans_master("disable", itemcode, generic, machine, lot, Degassing_time, registrant, time_of_registration, approver, time_of_approval, "2", user_name);

                        UtilityFunctions.trans_master("Appro", itemcode, generic, machine, lot, Degassing_time, registrant, formattedDate1, user_name, UtilityFunctions.getdate_time1(), "1", user_name);
                        //UtilityFunctions.trans_master("Appro", itemcode, generic, machine, lot, Degassing_time, user_name, time_of_registration, null, $"{ DateTime.Now}", "0");
                        //MessageBox.Show($"phê duyệt Row {rowIndex} - Cột 1: {itemcode}, Cột 3: {version}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi phê duyệt: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // phê duyệt
        private void Appro(object sender, EventArgs e)
        {

            using (var authenfrom = new authentication_from())
            {
                //authenfrom.ShowDialog();

                if (authenfrom.ShowDialog() == DialogResult.OK)
                {
                    loading.ShowLoading();

                    Task.Run(() =>
                    {
                        // Giả lập xử lý lâu
                        //System.Threading.Thread.Sleep(3000);
                        Appro_data();
                        this.Invoke(new Action(() =>
                        {
                            loading.HideLoading();
                            //MessageBox.Show("Hoàn thành!");
                            Update_data();
                        }));
                    });
                   
                }


            }

          
        }
        private void Disable_master()
        {
            try
            {
                if (masterdata_view.SelectedCells.Count > 0)
                {
                    // Lấy danh sách các row index duy nhất từ các cells được chọn
                    var selectedRowIndices = masterdata_view.SelectedCells
                        .Cast<DataGridViewCell>()
                        .Select(cell => cell.RowIndex)
                        .Distinct()
                        .ToList();

                    foreach (int rowIndex in selectedRowIndices)
                    {
                        // Lấy dữ liệu từ để vô hiệu hóa
                        string itemcode = masterdata_view.Rows[rowIndex].Cells["itemcode"].Value?.ToString() ?? "";
                        string generic = masterdata_view.Rows[rowIndex].Cells["generic"].Value?.ToString() ?? "";
                        string machine = masterdata_view.Rows[rowIndex].Cells["machine"].Value?.ToString() ?? "";
                        string lot = masterdata_view.Rows[rowIndex].Cells["lot"].Value?.ToString() ?? "";
                        string Degassing_time = masterdata_view.Rows[rowIndex].Cells["Degassing_time"].Value?.ToString() ?? "";
                        string registrant = masterdata_view.Rows[rowIndex].Cells["registrant"].Value?.ToString() ?? "";
                        string time_of_registration = masterdata_view.Rows[rowIndex].Cells["time_of_registration"].Value?.ToString() ?? "";
                        string approver = masterdata_view.Rows[rowIndex].Cells["approver"].Value?.ToString() ?? "";
                        string time_of_approval = masterdata_view.Rows[rowIndex].Cells["time_of_approval"].Value?.ToString() ?? "";
                        string status_item = masterdata_view.Rows[rowIndex].Cells["status_item"].Value?.ToString() ?? "";

                        string formattedDate1 = "";
                        if (!string.IsNullOrWhiteSpace(time_of_registration))
                        {
                            DateTime dt;
                            if (DateTime.TryParse(time_of_registration, out dt))
                            {
                                formattedDate1 = dt.ToString("yyyy-MM-dd HH:mm:ss");
                            }
                        }
                        string formattedDate2 = "";
                        if (!string.IsNullOrWhiteSpace(time_of_approval))
                        {
                            DateTime dt;
                            if (DateTime.TryParse(time_of_approval, out dt))
                            {
                                formattedDate2 = dt.ToString("yyyy-MM-dd HH:mm:ss");
                            }
                        }

                        //string itemcode = masterdata_view.Rows[rowIndex].Cells[0].Value?.ToString() ?? "";
                        //string machine = masterdata_view.Rows[rowIndex].Cells[2].Value?.ToString() ?? "";
                        //string Degassing_time = masterdata_view.Rows[rowIndex].Cells[3].Value?.ToString() ?? "";
                        //string lot = masterdata_view.Rows[rowIndex].Cells[4].Value?.ToString() ?? "";
                        //version = version.Substring(3);
                        Update_status("2", itemcode, machine, Degassing_time, lot);
                        //Console.WriteLine(time_of_approval);
                        //DateTime dt = DateTime.ParseExact(time_of_approval, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                        //string formatted = dt.ToString("yyyy/MM/dd h:mm:ss", CultureInfo.InvariantCulture);

                        // Ghi log và update vào db history
                        UtilityFunctions.trans_master("disable", itemcode, generic, machine, lot, Degassing_time, registrant, formattedDate1, approver, formattedDate2, "2", user_name);
                        //MessageBox.Show($" Vô hiệu hóa Row {rowIndex} - Cột 1: {itemcode}, Cột 3: {version}");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi vô hiệu hóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Disable(object sender, EventArgs e)
        {
            using (var authenfrom = new authentication_from())
            {
                //authenfrom.ShowDialog();
                if (authenfrom.ShowDialog() == DialogResult.OK)
                {
                    loading.ShowLoading();

                    Task.Run(() =>
                    {
                        // Giả lập xử lý lâu
                        //System.Threading.Thread.Sleep(3000);
                        Disable_master();
                        //Appro_data();
                        this.Invoke(new Action(() =>
                        {
                            loading.HideLoading();
                            //MessageBox.Show("Hoàn thành!");
                            Update_data();
                        }));
                    });
                }
            }
           
        }

        private void Update_status(string status_item, string itemcode,string machine,string Degassing_time,string lot)
        {
            DateTime getdate = DateTime.Now;
            string update_status = "update [MASTER] set status_item = @status_item, time_of_approval = @time_of_approval,approver = @approver  where itemcode = @itemcode and machine = @machine and lot = @lot and Degassing_time = @Degassing_time";
            SqlParameter[] checkuser = new SqlParameter[]
           {
                    new SqlParameter("@status_item", status_item),
                    new SqlParameter("@itemcode", itemcode),
                    new SqlParameter("@time_of_approval", getdate),
                    new SqlParameter("@approver", user_name),
                    new SqlParameter("@machine", machine),
                    new SqlParameter("@Degassing_time", Degassing_time),
                    new SqlParameter("@lot", lot),
           };
            DatabaseHelper.ExecuteNonQuery(update_status, checkuser);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
              try
               {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Excel Files|*.xlsx";
                    saveFileDialog.Title = "Lưu file Excel";
                    saveFileDialog.DefaultExt = "xlsx";
                    saveFileDialog.AddExtension = true;
                    saveFileDialog.FileName = "Master" + DateTime.Now.ToString("yyMMddHHmmss");
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        ExportToExcelEPPlus(masterdata_view, saveFileDialog.FileName);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ExportToExcelEPPlus(DataGridView dataGridView, string filePath)
        {
            try
            {
                // Thiết lập giấy phép EPPlus
                //ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                // Tạo file Excel mới
                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    // Tạo một worksheet
                    var worksheet = package.Workbook.Worksheets.Add("Data");

                    // Xuất tiêu đề cột
                    for (int i = 0; i < dataGridView.Columns.Count; i++)
                    {
                        worksheet.Cells[1, i + 1].Value = dataGridView.Columns[i].HeaderText;
                        worksheet.Cells[1, i + 1].Style.Font.Bold = true; // In đậm tiêu đề
                        worksheet.Cells[1, i + 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        worksheet.Cells[1, i + 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray); // Màu nền tiêu đề
                    }

                    // Xuất dữ liệu từ các dòng
                    for (int i = 0; i < dataGridView.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView.Columns.Count; j++)
                        {
                            worksheet.Cells[i + 2, j + 1].Value = dataGridView.Rows[i].Cells[j].Value?.ToString();
                        }
                    }

                    // Tự động điều chỉnh kích thước cột
                    worksheet.Cells.AutoFitColumns();

                    // Lưu file Excel
                    package.Save();
                }

                MessageBox.Show("Xuất file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất file Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void from_master_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void vôHiệuHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}

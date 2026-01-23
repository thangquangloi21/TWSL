using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TWSL.Common;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace TWSL.Forms.master
{
    public partial class FromMasterWH : Form
    {
        string StatusFunc = "";
        private loading_wait loading;
        public FromMasterWH()
        {
            InitializeComponent();
            ExcelPackage.License.SetNonCommercialPersonal("Your Name");
            loading = new loading_wait();
            this.Controls.Add(loading);

        }

        private void Stttk()
        {
            GrFunc.Text = "Master Thoát Khí";
            StatusFunc = "TK";
            MachineTbx.Enabled = true;
            statuscbb.Enabled = true;
            Sttlb.Enabled = true;
            MachineLb.Enabled = true;

        }

        private void SttPallet()
        {
            GrFunc.Text = "Master Pallet";
            StatusFunc = "Pallet";
            MachineTbx.Enabled = false;
            statuscbb.Enabled = false;
            Sttlb.Enabled = false;
            MachineLb.Enabled = false;
            MachineTbx.Text = "";
            statuscbb.SelectedIndex = 0;
        }

        private void MasterThoatKhi(object sender, EventArgs e)
        {
            //cập nhật dữ liệu hiển thị ra view
            Stttk();
            Loaddata();
        }

        private void MasterPallet(object sender, EventArgs e)
        {

            //cập nhật dữ liệu hiển thị ra view
            SttPallet();
            Loaddata();

        }

        private void Loaddatapallet(string Item, String Id)
        {
            MessageBox.Show("Load Pallet");
        }

        private void Loaddatatk(String Item, String Id, String Machine, int Status)
        {
            try
            {

                string check_user = "  SELECT [itemcode],[generic], [machine], [lot] ,[Degassing_time] ,[registrant] ,[time_of_registration] ,[approver] ,[time_of_approval] ," +
                    "CASE WHEN [status_item] = 0 THEN N'Chưa phê duyệt' WHEN [status_item] = 1 THEN N'Đã phê duyệt' WHEN [status_item] = 2 THEN N'Vô hiệu hóa'   END AS [status_item1] " +
                    "FROM [MASTERF12] where status_item in ('0','1','2')";
                                                          //string name_search_ = id_reg.Text.Trim(); // Loại bỏ khoảng trắng đầu và cuối
                //string status_ = statuscbb.Text.Trim();
                //if (status_ == "Chưa phê duyệt")
                //{
                //    status_ = "0";
                //}
                //else if (status_ == "Đã phê duyệt")
                //{
                //    status_ = "1";
                //}
                //else if (status_ == "Vô Hiệu hóa")
                //{
                //    status_ = "2";
                //}

                if (Status != 0)
                {
                    Status -=  1;
                   
                    check_user = "SELECT [itemcode],[generic], [machine], [lot] ,[Degassing_time] ,[registrant] ,[time_of_registration] ,[approver] ,[time_of_approval] ," +
                        "CASE WHEN [status_item] = 0 THEN N'Chưa phê duyệt' WHEN [status_item] = 1 THEN N'Đã phê duyệt' WHEN [status_item] = 2 THEN N'Vô hiệu hóa'  END AS [status_item1] " +
                        "FROM [MASTERF12] where status_item = @status ";
                }

                if (!string.IsNullOrEmpty(Item))
                {
                    check_user += " and itemcode = @itemcode";
                    // Thêm điều kiện tìm kiếm nếu có ID
                    //  where username like N'%' and id like '%'
                }


                if (!string.IsNullOrEmpty(Machine))
                {
                    check_user += " and machine = @machine";
                    // Thêm điều kiện tìm kiếm nếu có ID
                    //  where username like N'%' and id like '%'

                }

                Console.WriteLine(Status);
                SqlParameter[] checkuser = new SqlParameter[]
               {
                    new SqlParameter("@itemcode", Item),
                    new SqlParameter("@machine", Machine)
                    ,new SqlParameter("@status", Status)
                    //new SqlParameter("@Username", "%" + name_search_ + "%")
               };
                DataTable result = DatabaseHelper.ExecuteQuery(check_user, checkuser);
                // Đổi giá trị để hiển tn trong DataGridView
                //foreach (DataRow row in result.Rows)
                //{
                //    string status = row["status_item"].ToString();
                //    if (status == "1")
                //    {
                //        row["status_item"] = "Đã phê duyệt";
                //    }
                //    else if (status == "0")
                //    {
                //        row["status_item"] = "Chưa phê duyệt";
                //    }
                //    else if (status == "2")
                //    {
                //        row["status_item"] = "Vô Hiệu hóa";
                //    }

                //}
                // Gán DataTable làm nguồn dữ liệu cho DataGridView
                DataView.DataSource = result;


                // Gán tên hiển thị cho các cột
                DataView.Columns["itemcode"].HeaderText = "Mã sản phẩm";
                DataView.Columns["generic"].HeaderText = "Chủng loại";
                DataView.Columns["machine"].HeaderText = "Máy";
                DataView.Columns["lot"].HeaderText = "Lot";
                //userdata_view.Columns["password"].HeaderText = "Mật khẩu";
                DataView.Columns["Degassing_time"].HeaderText = "Thời gian thoát khí(Giờ)";
                DataView.Columns["registrant"].HeaderText = "Người đăng kí";
                DataView.Columns["time_of_registration"].HeaderText = "Thời gian đăng kí";
                DataView.Columns["approver"].HeaderText = "Người phê duyệt";
                DataView.Columns["time_of_approval"].HeaderText = "Thời gian phê duyệt";
                DataView.Columns["status_item1"].HeaderText = "Trạng thái";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Loaddata()
        {
            String Item = ItemTbx.Text.Trim();
            String Machine = MachineTbx.Text.Trim();
            int Status = statuscbb.SelectedIndex;
            String Id = IdTbx.Text.Trim();

            if (StatusFunc == "TK")
            {
                Console.WriteLine(Status);
                //String Item, String Id, String Machine, int Status
                Loaddatatk(Item, Id, Machine, Status);
            }
            else if (StatusFunc == "Pallet")
            {
                Loaddatapallet(Item, Id);
            }
        }

        private void updatatk(string filePath)
        {
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
                    //Console.WriteLine($"STT: {stt}, ITEMCODE: {itemcode}, CHUNGLOAI: {CHUNGLOAI}, MACHINE: {MACHINE}, LOT: {LOT}, TIME: {TIME}");
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

                        string check_master_data = "SELECT * FROM MASTERF12 WHERE itemcode = @itemcode and machine = @machine and lot = @lot";
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
                            string insertQuery = "INSERT INTO MASTERF12 (itemcode, generic,machine, lot, Degassing_time, time_of_registration, registrant, status_item) " +
                              "VALUES (@itemcode, @generic, @machine, @lot, @Degassing_time, @time_of_registration, @registrant, @status)";
                            SqlParameter[] parameters = new SqlParameter[]
                                {
                                        new SqlParameter("@itemcode", itemcode),
                                        new SqlParameter("@machine", machine),
                                        new SqlParameter("@lot", lot),
                                        new SqlParameter("@generic", generic),
                                        new SqlParameter("@time_of_registration", UtilityFunctions.getdate_time1()),
                                        new SqlParameter("@Degassing_time", Degassing_time),
                                        new SqlParameter("@registrant", AppData.Instance.CurrentUserId),
                                        new SqlParameter("@status", '0') // 0 có nghĩa là chưa duyệt, 1 là đã duyệt

                                 };
                            DatabaseHelper.ExecuteNonQuery(insertQuery, parameters);

                            // thêm mới dữ liệu
                            //thêm vào db masster history   
                            //UtilityFunctions.trans_master("add", itemcode, generic, machine, lot, Degassing_time, user_name, UtilityFunctions.getdate_time1(), "", "", "0", user_name);
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
                            string Updatemaster1 = "Update MASTERF12 set Degassing_time = @Degassing_time, generic = @generic , status_item = '0', time_of_approval = NULL " +
                                "where itemcode = @itemcode and machine = @machine and lot = @lot ";
                            SqlParameter[] update_master1 = new SqlParameter[]
                               {
                                        new SqlParameter("@itemcode", itemcode),
                                        new SqlParameter("@machine", machine),
                                        new SqlParameter("@lot", lot),
                                        new SqlParameter("@generic", generic),
                                        new SqlParameter("@Degassing_time", Degassing_time)
                                };
                            // ghi vào db sửa dữ liệu
                            DatabaseHelper.ExecuteNonQuery(Updatemaster1, update_master1);
                            // sửa dữ liệu

                            //UtilityFunctions.trans_master("modify", itemcode, generic, machine, lot, Degassing_time, user_name, UtilityFunctions.getdate_time1(), "", "", "0", user_name);
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

        //palet
        private void updatepallet(string filePath)
        {
            try
            {
                string id = "";
                string listdata1 = "";
                string itemcode1 = "";
                string Qty1 = "";
                // Bạn cần cài đặt thư viện EPPlus để làm việc với file Excel
                using (var package = new OfficeOpenXml.ExcelPackage(new FileInfo(filePath)))
                {
                    // Lấy worksheet đầu tiên
                    var worksheet = package.Workbook.Worksheets[0];
                    int rowCount = worksheet.Dimension.Rows;
                    string stt = worksheet.Cells[1, 1].Text.Trim();
                    string ITEMCODE = worksheet.Cells[1, 2].Text.Trim();
                    string Qty = worksheet.Cells[1, 3].Text.Trim();
                    //int colCount = worksheet.Dimension.Columns;
                    // kiểm tra xem đúng định dạng file chưa
                    //Console.WriteLine($"STT: {stt}, ITEMCODE: {itemcode}, CHUNGLOAI: {CHUNGLOAI}, MACHINE: {MACHINE}, LOT: {LOT}, TIME: {TIME}");
                    if (stt != "Stt" || ITEMCODE != "ItemCode" || Qty != "Qty")
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
                        string qty = worksheet.Cells[row, 3].Text.Trim(); // Cột C

                        string inp_listdata = $"{itemcode}{qty}";
                        //kiểm tra dữ liệu đã tồn tại trong database chưa
                        // lấy dữ liệu trong db ra

                        string check_master_data = "SELECT * FROM QtyStandPalet WHERE ItemCode = @itemcode ";
                        SqlParameter[] checkuser = new SqlParameter[]
                        {
                            new SqlParameter("@itemcode", itemcode)
                        };
                        DataTable result = DatabaseHelper.ExecuteQuery(check_master_data, checkuser);

                        // kiểm tra dữ liệu
                        foreach (DataRow row1 in result.Rows)
                        {
                            id = row1["Id"].ToString();
                            itemcode1 = row1["ItemCode"].ToString();
                            Qty1 = row1["Qty"].ToString();
                            // Cộng chuỗi với định dạng tùy ý (ví dụ: ngăn cách bằng dấu gạch ngang)
                            listdata1 = $"{itemcode1}{Qty1}";

                        }
                        // nếu chưa có thì thêm mới
                        if (listdata1 == "")
                        {
                            // Nếu chưa tồn tại, thực hiện thêm mới vào database
                            string insertQuery = "INSERT INTO QtyStandPalet (ItemCode, Qty, IdUser) " +
                              "VALUES (@ItemCode, @Qty , @IdUser)";
                            SqlParameter[] parameters = new SqlParameter[]
                                {
                                        new SqlParameter("@ItemCode", itemcode),
                                        new SqlParameter("@Qty", qty),
                                        new SqlParameter("@IdUser", AppData.Instance.CurrentUserId)

                                 };
                            DatabaseHelper.ExecuteNonQuery(insertQuery, parameters);

                            // thêm mới dữ liệu
                            //thêm vào db masster history   
                            //UtilityFunctions.trans_master("add", itemcode, generic, machine, lot, Degassing_time, user_name, UtilityFunctions.getdate_time1(), "", "", "0", user_name);
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
                            string insertQuery = "Update QtyStandPalet Set Qty = @Qty, IdUser= @IdUser  Where Id = @ID";
                            SqlParameter[] parameters = new SqlParameter[]
                                {
                                        new SqlParameter("@ItemCode", itemcode),
                                        new SqlParameter("@Qty", qty),
                                        new SqlParameter("@ID", id),
                                        new SqlParameter("@IdUser", AppData.Instance.CurrentUserId)

                                 };
                            DatabaseHelper.ExecuteNonQuery(insertQuery, parameters);
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

        private void Adddata(object sender, EventArgs e)
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
                       
                        if (StatusFunc == "TK")
                        {
                            updatatk(filePath);
                            //MessageBox.Show("Chức năng đang phát triển!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (StatusFunc == "Pallet")
                        {
                            updatepallet(filePath);
                            //MessageBox.Show("Chức năng đang phát triển!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        this.Invoke(new Action(() =>
                        {
                            loading.HideLoading();
                            //MessageBox.Show("Hoàn thành!");

                            //Update_data();
                        }));
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Loaddata();
        }

        private void statuscbb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

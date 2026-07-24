using OfficeOpenXml;
using Org.BouncyCastle.Crypto.IO;
using Org.BouncyCastle.Utilities.Zlib;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
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
            //statuscbb.Enabled = false;
            //Sttlb.Enabled = false;
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

        private void Loaddatapallet(string Item, string Id, int Status)
        {
            //MessageBox.Show("Load Pallet");
            try
            {

                // 1) Câu lệnh nền
                var baseSql = @"SELECT id as 'ID',
                [ItemCode] as 'Item Code'
                ,[Qty] as 'Số lượng'
                ,[IdUser] as 'Người đăng kí'
                ,[time_of_registration] as 'Thời gian đăng kí'
                ,[approver] as 'Người phê duyệt'
                ,[time_of_approval] as 'Thời gian phê duyệt'
                ,CASE WHEN [status_item] = 0 THEN N'Chưa phê duyệt' 
                WHEN [status_item] = 1 THEN N'Đã phê duyệt' 
                WHEN [status_item] = 2 THEN N'Vô hiệu hóa'  
                END AS 'Trạng thái'
                  FROM [TWSL].[dbo].[QtyStandPalet]";

                // 2) Gom điều kiện & tham số
                var conditions = new List<string>();
                var parameters = new List<SqlParameter>();

                if (!string.IsNullOrWhiteSpace(Item))
                {
                    conditions.Add("ItemCode = @ItemCode");
                    parameters.Add(new SqlParameter("@ItemCode", Item));
                }

                if (!string.IsNullOrWhiteSpace(Id))
                {
                    conditions.Add("IdUser = @IdUser");
                    parameters.Add(new SqlParameter("@IdUser", Id));
                }

                if (Status != 0)
                {
                    Status -= 1;
                    conditions.Add("status_item = @status");
                    parameters.Add(new SqlParameter("@status", Status));
                }



                // 3) Lắp WHERE nếu có
                string sql = baseSql;
                if (conditions.Count > 0)
                {
                    sql += " WHERE " + string.Join(" AND ", conditions);
                }
               

                // 4) Thực thi query: DÙNG parameters.ToArray() thay vì 'checkuser'
                DataTable result = DatabaseHelper.ExecuteQuery(sql, parameters.ToArray());

                
                // 6) Gán vào DataGridView (đảm bảo đúng tên control)
                DataView.DataSource = result; // VD: dataGridView1.DataSource = result;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Loaddatatk(string Item, string Id, string Machine, int Status)
        {
            try
            {

                string check_user = @" SELECT id as 'ID'
                  ,[itemcode] as 'Mã sản phẩm'
                  ,[generic] as 'Chủng loại'
                  , [machine] as 'Máy'
                  , [lot] as 'Lot'
                  ,[Degassing_time]  as 'Thời gian thoát khí(Giờ)'
                  ,[registrant]  as 'Người đăng kí'
                  ,[time_of_registration]  as 'Thời gian đăng kí'
                  ,[approver]  as 'Người phê duyệt'
                  ,[time_of_approval]  as 'Thời gian phê duyệt'
                  ,CASE WHEN [status_item] = 0 
                  THEN N'Chưa phê duyệt' 
                  WHEN [status_item] = 1 THEN N'Đã phê duyệt' 
                  WHEN [status_item] = 2 THEN N'Vô hiệu hóa'  
                  END AS 'Trạng thái'
                  FROM [MASTERF12] where status_item in ('0','1','2')";
               

                if (Status != 0)
                {
                    Status -=  1;
                   
                    check_user = @"
                  SELECT id as 'ID' 
                  ,[itemcode] as 'Mã sản phẩm'
                  ,[generic] as 'Chủng loại'
                  , [machine] as 'Máy'
                  , [lot] as 'Lot'
                  ,[Degassing_time]  as 'Thời gian thoát khí(Giờ)'
                  ,[registrant]  as 'Người đăng kí'
                  ,[time_of_registration]  as 'Thời gian đăng kí'
                  ,[approver]  as 'Người phê duyệt'
                  ,[time_of_approval]  as 'Thời gian phê duyệt'
                  ,CASE WHEN [status_item] = 0 
                  THEN N'Chưa phê duyệt' 
                  WHEN [status_item] = 1 THEN N'Đã phê duyệt' 
                  WHEN [status_item] = 2 THEN N'Vô hiệu hóa'  
                  END AS 'Trạng thái'
                  FROM [MASTERF12] where status_item = @status";
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

                SqlParameter[] checkuser = new SqlParameter[]
               {
                    new SqlParameter("@itemcode", Item),
                    new SqlParameter("@machine", Machine)
                    ,new SqlParameter("@status", Status)
                    //new SqlParameter("@Username", "%" + name_search_ + "%")
               };
                DataTable result = DatabaseHelper.ExecuteQuery(check_user, checkuser);
              
                DataView.DataSource = result;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Loaddata()
        {
            string Item = ItemTbx.Text.Trim();
            string Machine = MachineTbx.Text.Trim();
            int Status = statuscbb.SelectedIndex;
            string Id = IdTbx.Text.Trim();

            if (StatusFunc == "TK")
            {
                if (Status == -1)
                {
                    Status += 1;
                }
                Console.WriteLine(Status);
                //String Item, String Id, String Machine, int Status
                Loaddatatk(Item, Id, Machine, Status);
            }
            else if (StatusFunc == "Pallet")
            {
                if (Status == -1)
                {
                    Status += 1;
                }
                Console.WriteLine(Status);
                Loaddatapallet(Item, Id, Status);

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
                        string STT = worksheet.Cells[row, 1].Text.Trim(); // Cột A
                        string itemcode = worksheet.Cells[row, 2].Text.Trim(); // Cột B
                        string cgeneric = worksheet.Cells[row, 3].Text.Trim(); // Cột C
                        string ctime = worksheet.Cells[row, 6].Text.Trim(); // Cột D
                        // *** KIỂM TRA HÀNG CÓ DỮ LIỆU ***
                        if (string.IsNullOrEmpty(STT) || string.IsNullOrEmpty(itemcode) || string.IsNullOrEmpty(cgeneric) || string.IsNullOrEmpty(ctime))
                        {
                            // Bỏ qua hàng nếu STT, itemcode, generic hoặc time rỗng
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
                        string Stt = worksheet.Cells[row, 1].Text.Trim(); // Cột A
                        string itemcode = worksheet.Cells[row, 2].Text.Trim(); // Cột B
                        string Qtyc = worksheet.Cells[row, 3].Text.Trim(); // Cột C
                   

                        // *** KIỂM TRA HÀNG CÓ DỮ LIỆU ***
                        if (string.IsNullOrEmpty(Stt) || string.IsNullOrEmpty(itemcode) || string.IsNullOrEmpty(Qty))
                        {
                            // Bỏ qua hàng nếu bất kỳ cột nào rỗng
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
                            string insertQuery = "INSERT INTO QtyStandPalet (ItemCode, Qty, IdUser, time_of_registration) " +
                              "VALUES (@ItemCode, @Qty , @IdUser, @TimeOfRegistration)";
                            SqlParameter[] parameters = new SqlParameter[]
                                {
                                        new SqlParameter("@ItemCode", itemcode),
                                        new SqlParameter("@Qty", qty),
                                        new SqlParameter("@IdUser", AppData.Instance.CurrentUserId),
                                        new SqlParameter("@TimeOfRegistration", UtilityFunctions.getdate_time1())

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
                            string insertQuery = "Update QtyStandPalet Set Qty = @Qty, IdUser= @IdUser, time_of_registration = @TimeOfRegistration,approver = '', time_of_approval = NULL , status_item = @status_item  Where Id = @ID";
                            SqlParameter[] parameters = new SqlParameter[]
                                {
                                        new SqlParameter("@ItemCode", itemcode),
                                        new SqlParameter("@Qty", qty),
                                        new SqlParameter("@ID", id),
                                        new SqlParameter("@IdUser", AppData.Instance.CurrentUserId),
                                        new SqlParameter("@TimeOfRegistration", UtilityFunctions.getdate_time1()),
                                        //new SqlParameter("@time_of_approval", ""),
                                        new SqlParameter("@status_item", "0")

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

                            ////Update_data();
                        }));
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }

        private void SearchBtn(object sender, EventArgs e)
        {
            Loaddata();
        }

        private void statuscbb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FromMasterWH_Load(object sender, EventArgs e)
        {
            Stttk();
            Loaddata();
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
                        Update_status("1", AppData.Instance.CurrentUserName, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                       
                        this.Invoke(new Action(() =>
                        {
                            loading.HideLoading();
                            //MessageBox.Show("Hoàn thành!");
                            //Update_data();
                            Loaddata();
                        }));
                    });

                }


            }


        }

        private void Update_status(string status, string approver, string time_of_approval)
        {
            try
            {

                if (DataView.SelectedCells.Count > 0)
                {
                    // Lấy danh sách các row index duy nhất từ các cells được chọn
                    var selectedRowIndices = DataView.SelectedCells
                        .Cast<DataGridViewCell>()
                        .Select(cell => cell.RowIndex)
                        .Distinct()
                        .ToList();

                    foreach (int rowIndex in selectedRowIndices)
                    {
                        // Lấy dữ liệu từ gridview để xóa
                        string id = DataView.Rows[rowIndex].Cells["ID"].Value?.ToString() ?? "";
                        // Cập nhật trạng thái phê duyệt vào database
                        if (StatusFunc == "TK")
                        {
                            DatabaseHelper.ExecuteNonQuery("update [TWSL].[dbo].[MASTERF12] set status_item = @status, approver = @approver, time_of_approval = @time_of_approval where id = @id", new[] { new SqlParameter("@status", status), new SqlParameter("@approver", approver), new SqlParameter("@time_of_approval", time_of_approval), new SqlParameter("@id", id) });
                        }
                        else
                        {
                            DatabaseHelper.ExecuteNonQuery("update [TWSL].[dbo].[QtyStandPalet] set status_item = @status, approver = @approver, time_of_approval = @time_of_approval where id = @id", new[] { new SqlParameter("@status", status), new SqlParameter("@approver", approver), new SqlParameter("@time_of_approval", time_of_approval), new SqlParameter("@id", id) });
                            //cập nhật vào log xóa dữ liệu 
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi Xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

                        Delete_data();

                        this.Invoke(new Action(() =>
                        {
                            loading.HideLoading();
                            //MessageBox.Show("Hoàn thành!");
                            //Update_data();
                            Loaddata();
                        }));
                    });


                }
            }
        }
      

        private void Delete_data()
        {
            try
            {

                if (DataView.SelectedCells.Count > 0)
                {
                    // Lấy danh sách các row index duy nhất từ các cells được chọn
                    var selectedRowIndices = DataView.SelectedCells
                        .Cast<DataGridViewCell>()
                        .Select(cell => cell.RowIndex)
                        .Distinct()
                        .ToList();

                    foreach (int rowIndex in selectedRowIndices)
                    {
                        // Lấy dữ liệu từ gridview để xóa
                        string id = DataView.Rows[rowIndex].Cells["ID"].Value?.ToString() ?? "";
                        // xóa dữ liệu 
                        if (StatusFunc == "TK")
                        {
                            DatabaseHelper.ExecuteNonQuery("DELETE FROM MASTERF12 WHERE id = @id", new[] { new SqlParameter("@id", id) });
                            
                        }
                        else
                        {
                            DatabaseHelper.ExecuteNonQuery("DELETE FROM QtyStandPalet WHERE id = @id", new[] { new SqlParameter("@id", id) });
                            //cập nhật vào log xóa dữ liệu 
                        }

                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi Xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // vô hiệu hóa
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
                        Update_status("0", "", "NULL");
                        this.Invoke(new Action(() =>
                        {
                            loading.HideLoading();
                            //MessageBox.Show("Hoàn thành!");
                            //Update_data();
                            Loaddata();
                        }));
                    });
                }
            }

        }

        private void ShowContextMenu(Point location)
        {
            // Context menu của bạn
            ContextMenuStrip contextMenu = new ContextMenuStrip();

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
            if (DataView.SelectedCells.Count > 0)
            {
                int rowIndex = DataView.SelectedCells[0].RowIndex;
                if (rowIndex >= 0)
                {
                    status = DataView.Rows[rowIndex].Cells["Trạng thái"].Value?.ToString() ?? "";
                }
            }

            Console.WriteLine(status);
            // Kiểm tra điều kiện và ẩn/hiện các nút
            // Nếu trạng thái là "1" (đã phê duyệt), ẩn các nút "Chỉnh sửa" và "Xóa"
            if (status == "Đã phê duyệt")
            {
                delete.Enabled = false;
                appro_master.Enabled = false;
               
            }

            if (status == "Chưa phê duyệt")
            {
                disable.Enabled = false;
                //if (user_role == "user")
                //{
                //    delete.Enabled = false;
                //    appro_master.Enabled = false;
                //    disable.Enabled = false;
                //}
            }


            contextMenu.Show(DataView, location);
        }

        private void DataView_MouseClick(object sender, MouseEventArgs e)
        {
              if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo hit = DataView.HitTest(e.X, e.Y);

                if (hit.RowIndex >= 0 && hit.ColumnIndex >= 0)
                {
                    // Kiểm tra xem có phải đang click vào vùng đã chọn không
                    DataGridViewCell clickedCell = DataView[hit.ColumnIndex, hit.RowIndex];

                    if (!clickedCell.Selected)
                    {
                        // Nếu click vào cell chưa được chọn, thì chọn cell đó
                        DataView.ClearSelection();
                        clickedCell.Selected = true;
                    }
                    // Nếu click vào cell đã được chọn, giữ nguyên selection

                    // Hiển thị context menu tại vị trí click
                    ShowContextMenu(e.Location);
                }
            }
        }

        private void XuatDataToExcel(object sender, EventArgs e)
        {
            //Xuất dữ liệu ra excel
            try
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Excel Files|*.xlsx";
                    saveFileDialog.Title = "Lưu file Excel";
                    saveFileDialog.DefaultExt = "xlsx";
                    saveFileDialog.AddExtension = true;
                    if (StatusFunc == "TK")
                    {
                        saveFileDialog.FileName = "Master_TK" + DateTime.Now.ToString("yyMMddHHmmss");
                    }
                    else if (StatusFunc == "Pallet")
                    {
                        saveFileDialog.FileName = "Master_Pallet" + DateTime.Now.ToString("yyMMddHHmmss");
                    }
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        ImportData.ExportToExcelEPPlus(DataView, saveFileDialog.FileName);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

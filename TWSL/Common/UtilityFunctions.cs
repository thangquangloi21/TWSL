using Org.BouncyCastle.Crypto.IO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace TWSL.Common
{
    internal class UtilityFunctions
    {
        // Add common utility functions here in the future

        public static void trans_update_user(string reason, string id, string username, string role, string status, string performer_id, string performer_name, string performer_date, string note)
        {
            // add , edit, resetpassword
            string update_query = "INSERT INTO [history_users] ([reason], [id_code], [username], [role], [status], [performer_id], [performer_name], [performer_date],[note] ) " +
                "VALUES (@reason, @id_code, @username, @role, @status, @performer_id, @performer_name, @performer_date, @note)";
            //MessageBox.Show($"Cập nhật thông tin người dùng với ID: {id_update}, Tên: {save_username_update}, Quyền: {role_update}, Trạng thái: {status_update}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            SqlParameter[] updateParameters = new SqlParameter[]
            {
                    new SqlParameter("@reason", reason),
                    new SqlParameter("@id_code", id),
                    new SqlParameter("@username", username),
                    new SqlParameter("@role", role),
                    new SqlParameter("@status", status),
                    new SqlParameter("@performer_id", performer_id),
                    new SqlParameter("@performer_name", performer_name),
                    new SqlParameter("@performer_date", performer_date),
                    new SqlParameter("@note", note),
            };
            DatabaseHelper.ExecuteNonQuery(update_query, updateParameters);
        }


        public static void trans_master(string reason, string itemcode, string generic, string machine, string lot, string Degassing_time, string registrant, string time_of_registration, string approver, string time_of_approval, string status_item, string note)
        {
            string update_query = "INSERT INTO [history_master] ([reason] ,[itemcode] ,[generic],[machine],[lot],[Degassing_time],[registrant],[time_of_registration],[approver],[time_of_approval],[status_item],[note], [date]) " +
                "VALUES (@reason, @itemcode, @generic, @machine, @lot, @Degassing_time, @registrant, @time_of_registration, @approver, @time_of_approval , @status_item, @note, @date);";
            //MessageBox.Show($"Cập nhật thông tin người dùng với ID: {id_update}, Tên: {save_username_update}, Quyền: {role_update}, Trạng thái: {status_update}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            SqlParameter[] updateParameters = new SqlParameter[]
            {
                    new SqlParameter("@reason", reason),
                    new SqlParameter("@itemcode", itemcode),
                    new SqlParameter("@generic", generic),
                    new SqlParameter("@machine",    machine),
                    new SqlParameter("@lot", lot),
                    new SqlParameter("@Degassing_time", Degassing_time),
                    new SqlParameter("@registrant", registrant),
                    new SqlParameter("@time_of_registration", time_of_registration),
                    new SqlParameter("@approver", approver),
                    new SqlParameter("@time_of_approval", time_of_approval),
                    new SqlParameter("@status_item", status_item),
                    new SqlParameter("@note", note),
                    new SqlParameter("@date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
            };    

            DatabaseHelper.ExecuteNonQuery(update_query, updateParameters);

        }

        public static string getdate_time()
        {
            // format dd-mm-yyyy hh:mm:ss
            string getdate = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
        return getdate;
        }

        public static string getdate_time1()
        {
            // format dd-mm-yyyy hh:mm:ss
            string getdate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            return getdate;
        }

        public static void insert_batch_no(string batch_no, string user_register, string status, string numberexport)
        {
            string update_query = "INSERT INTO [master_batchno] ([batch_no] ,[user_register] ,[time_register]  ,[status] ,[number_export]) " +
                "VALUES (@batch_no, @user_register, @time_register , @status, @numberexport);";
            //MessageBox.Show($"Cập nhật thông tin người dùng với ID: {id_update}, Tên: {save_username_update}, Quyền: {role_update}, Trạng thái: {status_update}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            SqlParameter[] updateParameters = new SqlParameter[]
            {
                    new SqlParameter("@batch_no", batch_no),
                    new SqlParameter("@user_register", user_register),
                    new SqlParameter("@time_register", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    new SqlParameter("@status", status),
                    new SqlParameter("@numberexport", numberexport),
            };

            DatabaseHelper.ExecuteNonQuery(update_query, updateParameters);
        }


        public static void insert_data_desg_time(string palletNo, string batchNo, string productCode, string line, string lot, string quantity, string degassingA, string degassingB, string degassingC, string machine, string id_user, string name)
        {
            string insertQuery = "insert [data_degassing_time] ([paletno] ,[batch_no],[itemcode],[line] ,[lotnumber] ,[quantity] ,[degassing_time_wha] ,[degassing_time_whb] ,[degassing_time_whc] ,[machineno] ,[input_time] ,[id_user] ,[name_user]) " +
                "values (@pallet_no , @batch_no, @item_code, @product_name, @lot, @quantity, @degassing_a, @degassing_b, @degassing_c, @machine_no, @inp_time, @id_user, @name)";
            // Tạo mảng SqlParameter để tránh SQL Injection
            SqlParameter[] parameters = new SqlParameter[]
            {
                    new SqlParameter("@pallet_no", palletNo),
                    new SqlParameter("@batch_no", batchNo),
                    new SqlParameter("@item_code", productCode),
                    new SqlParameter("@product_name", line),
                    new SqlParameter("@lot", lot),
                    new SqlParameter("@quantity", quantity),
                    new SqlParameter("@degassing_a", degassingA),
                    new SqlParameter("@degassing_b", degassingB),
                    new SqlParameter("@degassing_c", degassingC),
                    new SqlParameter("@machine_no", machine),
                    new SqlParameter("@inp_time", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    new SqlParameter("@id_user", id_user),
                    new SqlParameter("@name", name)
            };
            DatabaseHelper.ExecuteNonQuery(insertQuery, parameters);
        }

        public static void insert_history_data_desg_time(string palletNo, string batchNo, string productCode, string line, string lot, string quantity, string degassingA, string degassingB, string degassingC, string machine, string id_user, string name, string note)
        {
            string insertQuery = "insert [history_data_degassing_time] ([palletno] ,[batch_no],[itemcode],[line] ,[lotnumber] ,[quantity] ,[degassing_time_wha] ,[degassing_time_whb] ,[degassing_time_whc] ,[machineno] ,[input_time] ,[id_user] ,[name_user], [note]) " +
                "values (@palletno , @batch_no, @item_code, @product_name, @lot, @quantity, @degassing_a, @degassing_b, @degassing_c, @machine_no, @inp_time, @id_user, @name, @note)";
            // Tạo mảng SqlParameter để tránh SQL Injection
            SqlParameter[] parameters = new SqlParameter[]
            {
                    new SqlParameter("@palletno", palletNo),
                    new SqlParameter("@batch_no", batchNo),
                    new SqlParameter("@item_code", productCode),
                    new SqlParameter("@product_name", line),
                    new SqlParameter("@lot", lot),
                    new SqlParameter("@quantity", quantity),
                    new SqlParameter("@degassing_a", degassingA),
                    new SqlParameter("@degassing_b", degassingB),
                    new SqlParameter("@degassing_c", degassingC),
                    new SqlParameter("@machine_no", machine),
                    new SqlParameter("@inp_time", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    new SqlParameter("@id_user", id_user),
                    new SqlParameter("@name", name),
                    new SqlParameter("@note", note)
            };
            DatabaseHelper.ExecuteNonQuery(insertQuery, parameters);
        }

    }
}

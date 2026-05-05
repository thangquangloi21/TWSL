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

namespace TWSL.Forms.main.WH
{
    public partial class DocMaVach : Form
    {
        public DocMaVach()
        {
            InitializeComponent();
        }
        //01589352212000521728013110250827TC
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string MaThungXX = textBox1.Text.Trim();
                string prod_line = "";
                string itemcode = "";
                if (MaThungXX.Length > 26 && MaThungXX.Length < 35)
                {
                    // Tách chuỗi theo các đoạn chỉ số
                    string get_gs1_code = MaThungXX.Substring(2, 15 - 2 + 1); // Từ index 3 đến 16 code gs1
                    string expiration_date = MaThungXX.Substring(17, 23 - 17 + 1); // Từ index 16 đến 24 ngày hết hạn
                    string get_lot = MaThungXX.Substring(26); // Từ index 26 đến hết só lot

                    string get_itemandlot = "SELECT [category] ,[itemCode] FROM [ItemMaster] where cartonBox = @cartonBox";
                    SqlParameter[] codegs1 = {
                                new SqlParameter("@cartonBox", get_gs1_code)
                            };

                    DataTable gs1data = conn_db_gs1.ExecuteQuery(get_itemandlot, codegs1);
                    prod_line = gs1data.Rows[0]["category"].ToString();
                    itemcode = gs1data.Rows[0]["itemCode"].ToString();
                    //MessageBox.Show($"PROD Line: {prod_line} and itemcode = {itemcode}");

                    if (gs1data.Rows.Count < 0) {
                        MessageBox.Show("Mã này chưa được tạo.", "Thông Báo");
                        return;
                    }



                    if (get_lot.Length < 7)
                    {
                        MessageBox.Show("Lot không hợp lệ, Vui lòng kiểm tra lại.", "Thông Báo");
                        //textBox1.Text = "";
                        return;
                    }
                    //Console.WriteLine
                    this.Close();
                    var selectbath = new ChonMe(itemcode, get_lot);
                  
                    selectbath.ShowDialog();
                   

                }
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}

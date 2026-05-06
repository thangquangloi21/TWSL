using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TWSL.Common;

namespace TWSL.Forms.main.WH
{
    public partial class TaoPhieuNhapKho : Form
    {
        private loading_wait loading;
        public TaoPhieuNhapKho()
        {
            InitializeComponent();
            loading = new loading_wait();
            this.Controls.Add(loading);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var create_from_awm = new DocMaVach();
            create_from_awm.ShowDialog();
        }

        private void updateData()
        {
            DataTable dt = ImportData.GetData();

            //DataBatchNo.AutoGenerateColumns = false;
            //DataBatchNo.Columns.Clear();

            var columns = new (string dataField, string header, string format)[]
            {
                ("SoMeTT",        "Số mẻ Tiệt Trùng",   null),
                ("MaSP",          "Mã sản phẩm",         null),
                ("LotSP",         "Lô sản phẩm",         null),
                ("SoLuongSP",     "Số lượng",             null),
                ("MayTT",         "Máy Tiệt Trùng",      null),
                ("ThoiGianPost",  "Ngày post",            "dd/MM/yyyy"),
                ("NgayGioUpload", "Ngày giờ upload",      "dd/MM/yyyy HH:mm:ss"),
                ("username",      "Người upload",         null),
                ("TrangThai",     "Trạng thái",           null),
            };

            foreach (var (dataField, header, format) in columns)
            {
                var col = new DataGridViewTextBoxColumn
                {
                    DataPropertyName = dataField,
                    HeaderText = header,
                    ReadOnly = true
                };
                if (format != null)
                    col.DefaultCellStyle.Format = format;
                DataBatchNo.Columns.Add(col);
            }

            DataBatchNo.DataSource = dt;
        }

        private void TaoPhieuNhapKho_Load(object sender, EventArgs e)
        {
            loading.ShowLoading();
            Task.Run(() =>
            {
                //updateData();
                //upload_master(filePath);
                //MessageBox.Show("đang hoàn thành!");

                this.Invoke(new Action(() =>
                {
                    updateData();
                    loading.HideLoading();
                    //MessageBox.Show("Hoàn thành!");

                    //Update_data();
                }));
            });
        }
    }
}

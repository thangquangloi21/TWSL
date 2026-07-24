using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TWSL.Common;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TWSL.Forms.main.WH.MasterManage.master
{
    public partial class FromTempMaster : Form
    {
        public FromTempMaster()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

        private void FromTempMaster_Load(object sender, EventArgs e)
        {
            label2.Text = AppData.Instance.LinkTemp;
        }

        private void Chon_temp(object sender, EventArgs e)
        {
            
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = "Chọn file";
            openFileDialog.Filter = "All Files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                //MessageBox.Show("Đường dẫn file: " + filePath);
                LinkFile_tbx.Text = filePath;
                // Sử dụng filePath ở đây
            }
        }

        private void Luu_temp_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LinkFile_tbx.Text))
            {
                MessageBox.Show(
                    "Vui lòng chọn đường dẫn file trước khi lưu cấu hình.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            if (!File.Exists(LinkFile_tbx.Text))
            {
                MessageBox.Show(
                    "Đường dẫn file không tồn tại. Vui lòng kiểm tra lại.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!LinkFile_tbx.Text.EndsWith(".xlsx", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(
                    "Đường dẫn file phải là file Excel (.xlsx). Vui lòng chọn lại.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (LinkFile_tbx.Text == AppData.Instance.LinkTemp)
            {
                MessageBox.Show(
                    "Đường dẫn file không thay đổi. Vui lòng chọn lại.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            //copy file vào thư mục FromTEMP
            string sourceFile = LinkFile_tbx.Text; // Đường dẫn file nguồn
            string destFolder = @"FromTEMP";

            // Tạo thư mục nếu chưa tồn tại
            Directory.CreateDirectory(destFolder);


            // Lấy tên file
            string fileName = Path.GetFileName(sourceFile);
            // Đường dẫn đích
            string destFile = Path.Combine(destFolder, fileName);
            // Copy file
            File.Copy(sourceFile, destFile, true); // true = ghi đè nếu file đã tồn tại


            string iniPath = @"config.ini";
            string content = "[Settings]\n";
            content += "FilePath=" + destFile;
            File.WriteAllText(iniPath, content);
            AppData.Instance.LinkTemp = destFile;

            MessageBox.Show(
                "Lưu cấu hình thành công!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            this.Close();
        }

        private void fileSystemWatcher1_Changed(object sender, System.IO.FileSystemEventArgs e)
        {

        }
    }
}

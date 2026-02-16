using System;
using System.Windows.Forms;

namespace TWSL
{
    public partial class input_from : Form
    {
        private string sum_item = "0"; // Private field
        public string SumItem = "0"; // Public read-only property to access sum_item


        public input_from(string item, string lot)
        {
            InitializeComponent();
            // Set the label texts with the passed values
            item_display.Text = item; // Assuming labelItem is the name of the Label control for item
            lot_display.Text = lot;   // Assuming labelLot is the name of the Label control for lot
            InitializeHoldTimer(); // Initialize the hold timer for delete button
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the form
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                sum_item = sum_inp_item();
                //MessageBox.Show($"The sum_item value is: {sum_item}", "Result");
                this.Close(); // Close the form
            }
        }

        public string sum_inp_item()
        {

            sum_item = inp_texbox.Text; // Assuming inp_texbox is the name of the TextBox control
            SumItem = sum_item;
            return SumItem;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sum_item = sum_inp_item();
            this.Close(); // Close the form
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //so1
            inp_texbox.Text = inp_texbox.Text + "1";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //so2
            inp_texbox.Text = inp_texbox.Text + "2";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //so3
            inp_texbox.Text = inp_texbox.Text + "3";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //so4
            inp_texbox.Text = inp_texbox.Text + "4";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //so5
            inp_texbox.Text = inp_texbox.Text + "5";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //so6
            inp_texbox.Text = inp_texbox.Text + "6";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //so7
            inp_texbox.Text = inp_texbox.Text + "7";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //so8
            inp_texbox.Text = inp_texbox.Text + "8";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //so9
            inp_texbox.Text = inp_texbox.Text + "9";
        }
        private void button11_Click_1(object sender, EventArgs e)
        {
            inp_texbox.Text = inp_texbox.Text + "0";
        }


        private void delete_buton_Click(object sender, EventArgs e)
        {
            //xóa từng cái một
            if (inp_texbox.Text.Length > 0)
            {
                inp_texbox.Text = inp_texbox.Text.Substring(0, inp_texbox.Text.Length - 1);
            }
            //nếu nhấn xóa mà textbox đã trống thì báo lỗi
            if (inp_texbox.Text.Length == 0)
            {
                MessageBox.Show("Ô nhập đang trống.", "Info"); // Thông báo nếu textbox đã trống
            }
        }

        // Thêm Timer vào form (khai báo ở cấp độ class)
        private Timer holdTimer;
        private bool isHolding = false;

        // Khởi tạo Timer (đặt trong constructor hoặc Form_Load)
        private void InitializeHoldTimer()
        {
            holdTimer = new Timer();
            holdTimer.Interval = 500; // 800ms - thời gian nhấn giữ để kích hoạt xóa hết
            holdTimer.Tick += HoldTimer_Tick;
        }

        // Sự kiện khi nhấn chuột xuống
        private void delete_button_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isHolding = true;
                holdTimer.Start(); // Bắt đầu đếm thời gian nhấn giữ
            }
        }

        // Sự kiện khi thả chuột
        private void delete_button_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                holdTimer.Stop();

                // Nếu không phải nhấn giữ (thả nhanh), thực hiện xóa từng ký tự
                if (isHolding)
                {
                    DeleteSingleCharacter();
                }

                isHolding = false;
            }
        }

        // Sự kiện khi chuột rời khỏi button
        private void delete_button_MouseLeave(object sender, EventArgs e)
        {
            holdTimer.Stop();
            isHolding = false;
        }

        // Sự kiện khi Timer tick (nhấn giữ đủ lâu)
        private void HoldTimer_Tick(object sender, EventArgs e)
        {
            holdTimer.Stop();
            isHolding = false;

            // Xóa hết nội dung
            if (inp_texbox.Text.Length > 0)
            {
                inp_texbox.Text = "";
                //MessageBox.Show("Đã xóa hết nội dung.", "Info");
            }
           
        }

        // Hàm xóa từng ký tự (code gốc của bạn)
        private void DeleteSingleCharacter()
        {
            if (inp_texbox.Text.Length > 0)
            {
                inp_texbox.Text = inp_texbox.Text.Substring(0, inp_texbox.Text.Length - 1);
            }
            else
            {
                MessageBox.Show("Ô nhập đang trống.", "Info");
            }
        }

    }
}
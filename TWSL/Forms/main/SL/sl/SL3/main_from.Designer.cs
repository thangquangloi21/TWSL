using System.Drawing;
using System.Windows.Forms;

namespace TWSL
{
    partial class main_from
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main_from));
            this.Export_data_btn = new System.Windows.Forms.Button();
            this.barcode_textBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Nopalet_texbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.palletadd_btn = new System.Windows.Forms.Button();
            this.Clear_data_btn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.batchno_textbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.wh_cbx = new System.Windows.Forms.ComboBox();
            this.lbl_eog = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.user_lbl = new System.Windows.Forms.Label();
            this.menuuser = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Infouser = new System.Windows.Forms.ToolStripMenuItem();
            this.chagepassword = new System.Windows.Forms.ToolStripMenuItem();
            this.logout = new System.Windows.Forms.ToolStripMenuItem();
            this.data_view_desg_time = new System.Windows.Forms.DataGridView();
            this.no_palet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Batch_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Line_prod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wh_a = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wh_b = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wh_c = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.machine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.start_input = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.save_data = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuuser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_view_desg_time)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Export_data_btn
            // 
            this.Export_data_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Export_data_btn.Location = new System.Drawing.Point(229, 22);
            this.Export_data_btn.Name = "Export_data_btn";
            this.Export_data_btn.Size = new System.Drawing.Size(132, 62);
            this.Export_data_btn.TabIndex = 4;
            this.Export_data_btn.Text = "Dữ liệu mẻ thoát khí";
            this.Export_data_btn.UseVisualStyleBackColor = true;
            this.Export_data_btn.Click += new System.EventHandler(this.export_data_btn);
            // 
            // barcode_textBox
            // 
            this.barcode_textBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.barcode_textBox.Location = new System.Drawing.Point(289, 68);
            this.barcode_textBox.Name = "barcode_textBox";
            this.barcode_textBox.Size = new System.Drawing.Size(175, 20);
            this.barcode_textBox.TabIndex = 2;
            this.barcode_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.barcode_textBox_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(221, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Barcode:";
            // 
            // Nopalet_texbox
            // 
            this.Nopalet_texbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Nopalet_texbox.Location = new System.Drawing.Point(90, 67);
            this.Nopalet_texbox.Name = "Nopalet_texbox";
            this.Nopalet_texbox.Size = new System.Drawing.Size(100, 20);
            this.Nopalet_texbox.TabIndex = 1;
            this.Nopalet_texbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Nopalet_texbox_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Mã Pallet:";
            // 
            // palletadd_btn
            // 
            this.palletadd_btn.Location = new System.Drawing.Point(15, 26);
            this.palletadd_btn.Name = "palletadd_btn";
            this.palletadd_btn.Size = new System.Drawing.Size(75, 57);
            this.palletadd_btn.TabIndex = 12;
            this.palletadd_btn.Text = "Thêm Pallet";
            this.palletadd_btn.UseVisualStyleBackColor = true;
            this.palletadd_btn.Click += new System.EventHandler(this.button2_Click);
            // 
            // Clear_data_btn
            // 
            this.Clear_data_btn.Location = new System.Drawing.Point(106, 61);
            this.Clear_data_btn.Name = "Clear_data_btn";
            this.Clear_data_btn.Size = new System.Drawing.Size(75, 23);
            this.Clear_data_btn.TabIndex = 13;
            this.Clear_data_btn.Text = "Reset";
            this.Clear_data_btn.UseVisualStyleBackColor = true;
            this.Clear_data_btn.Click += new System.EventHandler(this.Clear_data_btn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(212, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Mẻ Tiệt trùng:";
            // 
            // batchno_textbox
            // 
            this.batchno_textbox.Location = new System.Drawing.Point(337, 43);
            this.batchno_textbox.Name = "batchno_textbox";
            this.batchno_textbox.Size = new System.Drawing.Size(132, 20);
            this.batchno_textbox.TabIndex = 0;
            this.batchno_textbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.batchno_textbox_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Kho thoát khí:";
            // 
            // wh_cbx
            // 
            this.wh_cbx.FormattingEnabled = true;
            this.wh_cbx.IntegralHeight = false;
            this.wh_cbx.Items.AddRange(new object[] {
            "A",
            "B",
            "C"});
            this.wh_cbx.Location = new System.Drawing.Point(95, 42);
            this.wh_cbx.Name = "wh_cbx";
            this.wh_cbx.Size = new System.Drawing.Size(101, 21);
            this.wh_cbx.TabIndex = 20;
            // 
            // lbl_eog
            // 
            this.lbl_eog.AutoSize = true;
            this.lbl_eog.Location = new System.Drawing.Point(291, 46);
            this.lbl_eog.Name = "lbl_eog";
            this.lbl_eog.Size = new System.Drawing.Size(36, 13);
            this.lbl_eog.TabIndex = 21;
            this.lbl_eog.Text = "XXEO";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(326, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(10, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "-";
            // 
            // user_lbl
            // 
            this.user_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.user_lbl.AutoSize = true;
            this.user_lbl.Location = new System.Drawing.Point(32, 481);
            this.user_lbl.Name = "user_lbl";
            this.user_lbl.Size = new System.Drawing.Size(32, 13);
            this.user_lbl.TabIndex = 23;
            this.user_lbl.Text = "Hi: ...";
            this.user_lbl.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.user_lbl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.user_lbl_MouseDown);
            this.user_lbl.MouseEnter += new System.EventHandler(this.User_lbl_MouseEnter);
            this.user_lbl.MouseLeave += new System.EventHandler(this.User_lbl_MouseLeave);
            // 
            // menuuser
            // 
            this.menuuser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Infouser,
            this.chagepassword,
            this.logout});
            this.menuuser.Name = "contextMenuStrip1";
            this.menuuser.Size = new System.Drawing.Size(178, 70);
            // 
            // Infouser
            // 
            this.Infouser.Name = "Infouser";
            this.Infouser.Size = new System.Drawing.Size(177, 22);
            this.Infouser.Text = "Thông tin tài khoản";
            this.Infouser.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // chagepassword
            // 
            this.chagepassword.Name = "chagepassword";
            this.chagepassword.Size = new System.Drawing.Size(177, 22);
            this.chagepassword.Text = "Đổi mật khẩu";
            this.chagepassword.Click += new System.EventHandler(this.ToolStripMenuItem2_Click);
            // 
            // logout
            // 
            this.logout.Name = "logout";
            this.logout.Size = new System.Drawing.Size(177, 22);
            this.logout.Text = "Đăng Xuất";
            this.logout.Click += new System.EventHandler(this.ĐăngXuấtToolStripMenuItem_Click);
            // 
            // data_view_desg_time
            // 
            this.data_view_desg_time.AllowUserToDeleteRows = false;
            this.data_view_desg_time.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.data_view_desg_time.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.data_view_desg_time.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_view_desg_time.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.no_palet,
            this.Batch_No,
            this.Item,
            this.Line_prod,
            this.Lot,
            this.sl,
            this.wh_a,
            this.wh_b,
            this.wh_c,
            this.machine});
            this.data_view_desg_time.Location = new System.Drawing.Point(5, 122);
            this.data_view_desg_time.Name = "data_view_desg_time";
            this.data_view_desg_time.ReadOnly = true;
            this.data_view_desg_time.Size = new System.Drawing.Size(1124, 353);
            this.data_view_desg_time.TabIndex = 4;
            // 
            // no_palet
            // 
            this.no_palet.HeaderText = "Mã Pallet";
            this.no_palet.Name = "no_palet";
            this.no_palet.ReadOnly = true;
            // 
            // Batch_No
            // 
            this.Batch_No.HeaderText = "Số mẻ tiệt trùng";
            this.Batch_No.Name = "Batch_No";
            this.Batch_No.ReadOnly = true;
            // 
            // Item
            // 
            this.Item.HeaderText = "Mã sản phẩm";
            this.Item.Name = "Item";
            this.Item.ReadOnly = true;
            // 
            // Line_prod
            // 
            this.Line_prod.HeaderText = "Bộ Phận";
            this.Line_prod.Name = "Line_prod";
            this.Line_prod.ReadOnly = true;
            // 
            // Lot
            // 
            this.Lot.HeaderText = "Số Lot";
            this.Lot.Name = "Lot";
            this.Lot.ReadOnly = true;
            // 
            // sl
            // 
            this.sl.HeaderText = "Số Lượng";
            this.sl.Name = "sl";
            this.sl.ReadOnly = true;
            // 
            // wh_a
            // 
            this.wh_a.HeaderText = "Thời gian thoát khí (A)";
            this.wh_a.Name = "wh_a";
            this.wh_a.ReadOnly = true;
            // 
            // wh_b
            // 
            this.wh_b.HeaderText = "Thời gian thoát khí (B)";
            this.wh_b.Name = "wh_b";
            this.wh_b.ReadOnly = true;
            // 
            // wh_c
            // 
            this.wh_c.HeaderText = "Thời gian thoát khí (C)";
            this.wh_c.Name = "wh_c";
            this.wh_c.ReadOnly = true;
            // 
            // machine
            // 
            this.machine.HeaderText = "Máy";
            this.machine.Name = "machine";
            this.machine.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.start_input);
            this.groupBox1.Controls.Add(this.barcode_textBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.Nopalet_texbox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(5, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(609, 104);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin";
            // 
            // start_input
            // 
            this.start_input.BackColor = System.Drawing.Color.PaleGreen;
            this.start_input.Location = new System.Drawing.Point(490, 23);
            this.start_input.Name = "start_input";
            this.start_input.Size = new System.Drawing.Size(90, 60);
            this.start_input.TabIndex = 27;
            this.start_input.Text = "Bắt đầu";
            this.start_input.UseVisualStyleBackColor = false;
            this.start_input.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.save_data);
            this.groupBox2.Controls.Add(this.Export_data_btn);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.Clear_data_btn);
            this.groupBox2.Controls.Add(this.palletadd_btn);
            this.groupBox2.Location = new System.Drawing.Point(605, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(518, 104);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chức năng:";
            // 
            // save_data
            // 
            this.save_data.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.save_data.Location = new System.Drawing.Point(394, 22);
            this.save_data.Name = "save_data";
            this.save_data.Size = new System.Drawing.Size(109, 60);
            this.save_data.TabIndex = 15;
            this.save_data.Text = "Lưu dữ liệu";
            this.save_data.UseVisualStyleBackColor = true;
            this.save_data.Click += new System.EventHandler(this.button2_Click_2);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(106, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Xóa";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.delete1row);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(2, 477);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(26, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // main_from
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 499);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lbl_eog);
            this.Controls.Add(this.wh_cbx);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.batchno_textbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.user_lbl);
            this.Controls.Add(this.data_view_desg_time);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "main_from";
            this.Text = "Nhập thời gian thoát khí tự động";
            this.Load += new System.EventHandler(this.main_from_Load);
            this.menuuser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.data_view_desg_time)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DataGridView data_view_desg_time;
        private Button Export_data_btn;
        private TextBox barcode_textBox;
        private Label label4;
        private TextBox Nopalet_texbox;
        private Label label1;
        private Button palletadd_btn;
        private Button Clear_data_btn;
        private Label label2;
        private TextBox batchno_textbox;
        private Label label3;
        private ComboBox wh_cbx;
        private Label lbl_eog;
        private Label label8;
        private Label user_lbl;
        private ContextMenuStrip menuuser;
        private ToolStripMenuItem Infouser;
        private ToolStripMenuItem chagepassword;
        private ToolStripMenuItem logout;
        private PictureBox pictureBox1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button start_input;
        private Button button1;
        private Button save_data;
        private DataGridViewTextBoxColumn no_palet;
        private DataGridViewTextBoxColumn Batch_No;
        private DataGridViewTextBoxColumn Item;
        private DataGridViewTextBoxColumn Line_prod;
        private DataGridViewTextBoxColumn Lot;
        private DataGridViewTextBoxColumn sl;
        private DataGridViewTextBoxColumn wh_a;
        private DataGridViewTextBoxColumn wh_b;
        private DataGridViewTextBoxColumn wh_c;
        private DataGridViewTextBoxColumn machine;
    }
}

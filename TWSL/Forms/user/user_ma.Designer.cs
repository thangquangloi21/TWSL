namespace TWSL
{
    partial class user_ma
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(user_ma));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.status_cbb = new System.Windows.Forms.ComboBox();
            this.role_cbb = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.username_textBox = new System.Windows.Forms.TextBox();
            this.id_textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.userdata_view = new System.Windows.Forms.DataGridView();
            this.func_1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.name_search = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.id_search = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.func_3 = new System.Windows.Forms.Button();
            this.func_2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userdata_view)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.status_cbb);
            this.groupBox1.Controls.Add(this.role_cbb);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.username_textBox);
            this.groupBox1.Controls.Add(this.id_textBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(477, 120);
            this.groupBox1.TabIndex = 99;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin";
            // 
            // status_cbb
            // 
            this.status_cbb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.status_cbb.Enabled = false;
            this.status_cbb.FormattingEnabled = true;
            this.status_cbb.Items.AddRange(new object[] {
            "Đang hoạt động",
            "Vô hiệu hóa"});
            this.status_cbb.Location = new System.Drawing.Point(306, 69);
            this.status_cbb.Name = "status_cbb";
            this.status_cbb.Size = new System.Drawing.Size(131, 21);
            this.status_cbb.TabIndex = 16;
            // 
            // role_cbb
            // 
            this.role_cbb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.role_cbb.Enabled = false;
            this.role_cbb.FormattingEnabled = true;
            this.role_cbb.Items.AddRange(new object[] {
            "Người dùng",
            "Người phụ trách",
            "Quản lý"});
            this.role_cbb.Location = new System.Drawing.Point(63, 72);
            this.role_cbb.Name = "role_cbb";
            this.role_cbb.Size = new System.Drawing.Size(102, 21);
            this.role_cbb.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(218, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Trạng thái:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Quyền:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(218, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Họ và tên:";
            // 
            // username_textBox
            // 
            this.username_textBox.Location = new System.Drawing.Point(306, 27);
            this.username_textBox.Name = "username_textBox";
            this.username_textBox.ReadOnly = true;
            this.username_textBox.Size = new System.Drawing.Size(131, 20);
            this.username_textBox.TabIndex = 12;
            // 
            // id_textBox
            // 
            this.id_textBox.Location = new System.Drawing.Point(63, 24);
            this.id_textBox.Name = "id_textBox";
            this.id_textBox.ReadOnly = true;
            this.id_textBox.Size = new System.Drawing.Size(102, 20);
            this.id_textBox.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID:";
            // 
            // userdata_view
            // 
            this.userdata_view.AllowUserToAddRows = false;
            this.userdata_view.AllowUserToDeleteRows = false;
            this.userdata_view.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userdata_view.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.userdata_view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userdata_view.Location = new System.Drawing.Point(13, 132);
            this.userdata_view.Name = "userdata_view";
            this.userdata_view.ReadOnly = true;
            this.userdata_view.Size = new System.Drawing.Size(1159, 401);
            this.userdata_view.TabIndex = 2;
            this.userdata_view.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Userdata_view_CellClick);
            // 
            // func_1
            // 
            this.func_1.Location = new System.Drawing.Point(26, 22);
            this.func_1.Name = "func_1";
            this.func_1.Size = new System.Drawing.Size(128, 23);
            this.func_1.TabIndex = 0;
            this.func_1.Text = "Thêm";
            this.func_1.UseVisualStyleBackColor = true;
            this.func_1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.name_search);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.id_search);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Location = new System.Drawing.Point(708, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(464, 120);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tìm kiếm";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Image = global::TWSL.Properties.Resources.logout;
            this.button1.Location = new System.Drawing.Point(384, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 90);
            this.button1.TabIndex = 4;
            this.button1.Text = "Thoát";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // name_search
            // 
            this.name_search.Location = new System.Drawing.Point(57, 51);
            this.name_search.Name = "name_search";
            this.name_search.Size = new System.Drawing.Size(179, 20);
            this.name_search.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Họ tên:";
            // 
            // id_search
            // 
            this.id_search.Location = new System.Drawing.Point(57, 20);
            this.id_search.Name = "id_search";
            this.id_search.Size = new System.Drawing.Size(179, 20);
            this.id_search.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "ID:";
            // 
            // button2
            // 
            this.button2.Image = global::TWSL.Properties.Resources.search;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.Location = new System.Drawing.Point(107, 79);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(81, 27);
            this.button2.TabIndex = 0;
            this.button2.Text = "Tìm kiếm";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.search_user);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.func_3);
            this.groupBox3.Controls.Add(this.func_2);
            this.groupBox3.Controls.Add(this.func_1);
            this.groupBox3.Location = new System.Drawing.Point(492, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(197, 120);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chức năng";
            // 
            // func_3
            // 
            this.func_3.Location = new System.Drawing.Point(26, 79);
            this.func_3.Name = "func_3";
            this.func_3.Size = new System.Drawing.Size(128, 23);
            this.func_3.TabIndex = 2;
            this.func_3.Text = "Xuất dữ liệu";
            this.func_3.UseVisualStyleBackColor = true;
            this.func_3.Click += new System.EventHandler(this.Func_3_Click);
            // 
            // func_2
            // 
            this.func_2.Location = new System.Drawing.Point(26, 51);
            this.func_2.Name = "func_2";
            this.func_2.Size = new System.Drawing.Size(128, 22);
            this.func_2.TabIndex = 1;
            this.func_2.Text = "Sửa";
            this.func_2.UseVisualStyleBackColor = true;
            this.func_2.Click += new System.EventHandler(this.Button3_Click);
            // 
            // user_ma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 545);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.userdata_view);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "user_ma";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản Lý Người dùng";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userdata_view)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView userdata_view;
        private System.Windows.Forms.TextBox id_textBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button func_1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox id_search;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox username_textBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button func_3;
        private System.Windows.Forms.Button func_2;
        private System.Windows.Forms.TextBox name_search;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox status_cbb;
        private System.Windows.Forms.ComboBox role_cbb;
        private System.Windows.Forms.Button button1;
    }
}
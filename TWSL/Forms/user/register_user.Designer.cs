namespace TWSL
{
    partial class register_user
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(register_user));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.role_register = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.username_register = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.passw_register = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.id_register = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.role_register);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.username_register);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.passw_register);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.id_register);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(301, 295);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vui lòng nhập thông tin";
            // 
            // role_register
            // 
            this.role_register.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.role_register.FormattingEnabled = true;
            this.role_register.Items.AddRange(new object[] {
            "Người dùng",
            "Người phụ trách",
            "Quản lý"});
            this.role_register.Location = new System.Drawing.Point(137, 183);
            this.role_register.Name = "role_register";
            this.role_register.Size = new System.Drawing.Size(127, 21);
            this.role_register.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 44;
            this.label4.Text = "Quyền:";
            // 
            // username_register
            // 
            this.username_register.Location = new System.Drawing.Point(137, 83);
            this.username_register.Name = "username_register";
            this.username_register.Size = new System.Drawing.Size(127, 20);
            this.username_register.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 98;
            this.label3.Text = "Họ và tên:";
            // 
            // passw_register
            // 
            this.passw_register.Location = new System.Drawing.Point(137, 133);
            this.passw_register.Name = "passw_register";
            this.passw_register.Size = new System.Drawing.Size(127, 20);
            this.passw_register.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 96;
            this.label2.Text = "Mật khẩu:";
            // 
            // id_register
            // 
            this.id_register.Location = new System.Drawing.Point(137, 38);
            this.id_register.Name = "id_register";
            this.id_register.Size = new System.Drawing.Size(127, 20);
            this.id_register.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 99;
            this.label1.Text = "ID:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(172, 243);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(69, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Đăng ký";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(32, 243);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Hủy";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // register_user
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 312);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "register_user";
            this.Text = "Tạo tài khoản";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox id_register;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox role_register;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox username_register;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox passw_register;
        private System.Windows.Forms.Label label2;
    }
}
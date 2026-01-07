namespace TWSL
{
    partial class chage_pasword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(chage_pasword));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.passwordold_tbx = new System.Windows.Forms.TextBox();
            this.passwordnew2_tbx = new System.Windows.Forms.TextBox();
            this.passwordnew_tbx = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Mật Khẩu cũ:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 50;
            this.label2.Text = "Nhập Lại Mật khẩu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 42;
            this.label3.Text = "Mật Khẩu Mới";
            // 
            // passwordold_tbx
            // 
            this.passwordold_tbx.Location = new System.Drawing.Point(116, 42);
            this.passwordold_tbx.Name = "passwordold_tbx";
            this.passwordold_tbx.Size = new System.Drawing.Size(139, 20);
            this.passwordold_tbx.TabIndex = 0;
            this.passwordold_tbx.UseSystemPasswordChar = true;
            // 
            // passwordnew2_tbx
            // 
            this.passwordnew2_tbx.Location = new System.Drawing.Point(116, 127);
            this.passwordnew2_tbx.Name = "passwordnew2_tbx";
            this.passwordnew2_tbx.Size = new System.Drawing.Size(139, 20);
            this.passwordnew2_tbx.TabIndex = 2;
            this.passwordnew2_tbx.UseSystemPasswordChar = true;
            // 
            // passwordnew_tbx
            // 
            this.passwordnew_tbx.Location = new System.Drawing.Point(116, 87);
            this.passwordnew_tbx.Name = "passwordnew_tbx";
            this.passwordnew_tbx.Size = new System.Drawing.Size(139, 20);
            this.passwordnew_tbx.TabIndex = 1;
            this.passwordnew_tbx.UseSystemPasswordChar = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(29, 175);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(167, 175);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Thoát";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 222);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(249, 13);
            this.label4.TabIndex = 51;
            this.label4.Text = "Lưu ý: Mật khẩu tối thiểu 8 kí tự và 1 kí tự đặc biệt";
            // 
            // chage_pasword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 274);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.passwordnew_tbx);
            this.Controls.Add(this.passwordnew2_tbx);
            this.Controls.Add(this.passwordold_tbx);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "chage_pasword";
            this.Text = "Đổi mật khẩu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox passwordold_tbx;
        private System.Windows.Forms.TextBox passwordnew2_tbx;
        private System.Windows.Forms.TextBox passwordnew_tbx;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
    }
}
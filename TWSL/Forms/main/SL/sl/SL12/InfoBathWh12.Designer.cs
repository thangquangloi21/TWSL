namespace TWSL.Forms.main.SL.SL12
{
    partial class InfoBathWh12
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Statusdp = new System.Windows.Forms.Label();
            this.Userdp = new System.Windows.Forms.Label();
            this.Datedp = new System.Windows.Forms.Label();
            this.batchno_dp = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.user_name_tbx = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.end_date = new System.Windows.Forms.DateTimePicker();
            this.batchno_texbox = new System.Windows.Forms.TextBox();
            this.start_date = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Displaybatch = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Displaybatch)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Statusdp);
            this.groupBox1.Controls.Add(this.Userdp);
            this.groupBox1.Controls.Add(this.Datedp);
            this.groupBox1.Controls.Add(this.batchno_dp);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(497, 133);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin";
            // 
            // Statusdp
            // 
            this.Statusdp.AutoSize = true;
            this.Statusdp.Location = new System.Drawing.Point(238, 72);
            this.Statusdp.Name = "Statusdp";
            this.Statusdp.Size = new System.Drawing.Size(16, 16);
            this.Statusdp.TabIndex = 26;
            this.Statusdp.Text = "...";
            this.Statusdp.Click += new System.EventHandler(this.label12_Click);
            // 
            // Userdp
            // 
            this.Userdp.AutoSize = true;
            this.Userdp.Location = new System.Drawing.Point(70, 72);
            this.Userdp.Name = "Userdp";
            this.Userdp.Size = new System.Drawing.Size(16, 16);
            this.Userdp.TabIndex = 25;
            this.Userdp.Text = "...";
            // 
            // Datedp
            // 
            this.Datedp.AutoSize = true;
            this.Datedp.Location = new System.Drawing.Point(238, 28);
            this.Datedp.Name = "Datedp";
            this.Datedp.Size = new System.Drawing.Size(16, 16);
            this.Datedp.TabIndex = 24;
            this.Datedp.Text = "...";
            // 
            // batchno_dp
            // 
            this.batchno_dp.AutoSize = true;
            this.batchno_dp.Location = new System.Drawing.Point(60, 25);
            this.batchno_dp.Name = "batchno_dp";
            this.batchno_dp.Size = new System.Drawing.Size(16, 16);
            this.batchno_dp.TabIndex = 23;
            this.batchno_dp.Text = "...";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(365, 22);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(105, 35);
            this.button4.TabIndex = 22;
            this.button4.Text = "Xóa mẻ";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Delbatch);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(365, 72);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(105, 35);
            this.button3.TabIndex = 21;
            this.button3.Text = "Xem chi tiết";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.viewData);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(170, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "Trạng thái";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(173, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "Ngày tạo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "Người tạo:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Số mẻ:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.user_name_tbx);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.end_date);
            this.groupBox2.Controls.Add(this.batchno_texbox);
            this.groupBox2.Controls.Add(this.start_date);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(580, 133);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tìm Kiếm";
            // 
            // user_name_tbx
            // 
            this.user_name_tbx.Location = new System.Drawing.Point(85, 74);
            this.user_name_tbx.Name = "user_name_tbx";
            this.user_name_tbx.Size = new System.Drawing.Size(145, 22);
            this.user_name_tbx.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(242, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 16);
            this.label5.TabIndex = 22;
            this.label5.Text = "Đến:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 16);
            this.label8.TabIndex = 23;
            this.label8.Text = "Số mẻ:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(244, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 16);
            this.label4.TabIndex = 21;
            this.label4.Text = "Từ:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 76);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 16);
            this.label9.TabIndex = 24;
            this.label9.Text = "Người tạo:";
            // 
            // end_date
            // 
            this.end_date.Location = new System.Drawing.Point(282, 74);
            this.end_date.Name = "end_date";
            this.end_date.Size = new System.Drawing.Size(176, 22);
            this.end_date.TabIndex = 20;
            // 
            // batchno_texbox
            // 
            this.batchno_texbox.Location = new System.Drawing.Point(85, 28);
            this.batchno_texbox.Name = "batchno_texbox";
            this.batchno_texbox.Size = new System.Drawing.Size(145, 22);
            this.batchno_texbox.TabIndex = 15;
            // 
            // start_date
            // 
            this.start_date.Location = new System.Drawing.Point(282, 37);
            this.start_date.Name = "start_date";
            this.start_date.Size = new System.Drawing.Size(176, 22);
            this.start_date.TabIndex = 19;
            // 
            // button1
            // 
            this.button1.Image = global::TWSL.Properties.Resources.search;
            this.button1.Location = new System.Drawing.Point(489, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 70);
            this.button1.TabIndex = 17;
            this.button1.Text = "Tìm Kiếm";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(251, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 16);
            this.label7.TabIndex = 18;
            this.label7.Text = "Thời gian cần tìm:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1077, 133);
            this.panel1.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.groupBox2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(497, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(580, 133);
            this.panel4.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(497, 133);
            this.panel3.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Displaybatch);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 133);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1077, 360);
            this.panel2.TabIndex = 3;
            // 
            // Displaybatch
            // 
            this.Displaybatch.AllowDrop = true;
            this.Displaybatch.AllowUserToAddRows = false;
            this.Displaybatch.AllowUserToDeleteRows = false;
            this.Displaybatch.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Displaybatch.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.Displaybatch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Displaybatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Displaybatch.Location = new System.Drawing.Point(0, 0);
            this.Displaybatch.Name = "Displaybatch";
            this.Displaybatch.ReadOnly = true;
            this.Displaybatch.Size = new System.Drawing.Size(1077, 360);
            this.Displaybatch.TabIndex = 0;
            this.Displaybatch.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Displaybatch_CellClick);
            // 
            // InfoBathWh12
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 493);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "InfoBathWh12";
            this.Text = "Thông tin mẻ tiệt trùng";
            this.Load += new System.EventHandler(this.InfoBathWh12_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Displaybatch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox user_name_tbx;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker end_date;
        private System.Windows.Forms.TextBox batchno_texbox;
        private System.Windows.Forms.DateTimePicker start_date;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView Displaybatch;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label Statusdp;
        private System.Windows.Forms.Label Userdp;
        private System.Windows.Forms.Label Datedp;
        private System.Windows.Forms.Label batchno_dp;
    }
}
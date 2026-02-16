namespace TWSL.Forms.main
{
    partial class export_data
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
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.status_dp = new System.Windows.Forms.Label();
            this.date_dp = new System.Windows.Forms.Label();
            this.user_dp = new System.Windows.Forms.Label();
            this.batchno_dp = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.end_date = new System.Windows.Forms.DateTimePicker();
            this.start_date = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.user_name_tbx = new System.Windows.Forms.TextBox();
            this.batchno_texbox = new System.Windows.Forms.TextBox();
            this.data_view = new System.Windows.Forms.DataGridView();
            this.search = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_view)).BeginInit();
            this.search.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.status_dp);
            this.groupBox1.Controls.Add(this.date_dp);
            this.groupBox1.Controls.Add(this.user_dp);
            this.groupBox1.Controls.Add(this.batchno_dp);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(557, 147);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(419, 18);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(120, 36);
            this.button4.TabIndex = 21;
            this.button4.Text = "Xóa mẻ";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.xoa_me);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button2.Image = global::TWSL.Properties.Resources.excel;
            this.button2.Location = new System.Drawing.Point(419, 72);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 56);
            this.button2.TabIndex = 19;
            this.button2.Text = "Export CSV";
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.export_csv);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(240, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Trạng thái:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(244, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ngày tạo:";
            // 
            // status_dp
            // 
            this.status_dp.AutoSize = true;
            this.status_dp.Location = new System.Drawing.Point(310, 62);
            this.status_dp.Name = "status_dp";
            this.status_dp.Size = new System.Drawing.Size(16, 13);
            this.status_dp.TabIndex = 18;
            this.status_dp.Text = "...";
            // 
            // date_dp
            // 
            this.date_dp.AutoSize = true;
            this.date_dp.Location = new System.Drawing.Point(304, 23);
            this.date_dp.Name = "date_dp";
            this.date_dp.Size = new System.Drawing.Size(16, 13);
            this.date_dp.TabIndex = 17;
            this.date_dp.Text = "...";
            // 
            // user_dp
            // 
            this.user_dp.AutoSize = true;
            this.user_dp.Location = new System.Drawing.Point(68, 66);
            this.user_dp.Name = "user_dp";
            this.user_dp.Size = new System.Drawing.Size(16, 13);
            this.user_dp.TabIndex = 16;
            this.user_dp.Text = "...";
            // 
            // batchno_dp
            // 
            this.batchno_dp.AutoSize = true;
            this.batchno_dp.Location = new System.Drawing.Point(55, 27);
            this.batchno_dp.Name = "batchno_dp";
            this.batchno_dp.Size = new System.Drawing.Size(16, 13);
            this.batchno_dp.TabIndex = 15;
            this.batchno_dp.Text = "...";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Người tạo:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Số mẻ:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Người tạo:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Số mẻ:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(249, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Đến:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(251, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Từ:";
            // 
            // end_date
            // 
            this.end_date.Location = new System.Drawing.Point(289, 65);
            this.end_date.Name = "end_date";
            this.end_date.Size = new System.Drawing.Size(165, 20);
            this.end_date.TabIndex = 7;
            // 
            // start_date
            // 
            this.start_date.Location = new System.Drawing.Point(289, 38);
            this.start_date.Name = "start_date";
            this.start_date.Size = new System.Drawing.Size(165, 20);
            this.start_date.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(250, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Thời gian cần tìm:";
            // 
            // button1
            // 
            this.button1.Image = global::TWSL.Properties.Resources.search;
            this.button1.Location = new System.Drawing.Point(467, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(61, 58);
            this.button1.TabIndex = 2;
            this.button1.Text = "Tìm Kiếm";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // user_name_tbx
            // 
            this.user_name_tbx.Location = new System.Drawing.Point(74, 65);
            this.user_name_tbx.Name = "user_name_tbx";
            this.user_name_tbx.Size = new System.Drawing.Size(145, 20);
            this.user_name_tbx.TabIndex = 1;
            // 
            // batchno_texbox
            // 
            this.batchno_texbox.Location = new System.Drawing.Point(74, 19);
            this.batchno_texbox.Name = "batchno_texbox";
            this.batchno_texbox.Size = new System.Drawing.Size(145, 20);
            this.batchno_texbox.TabIndex = 0;
            // 
            // data_view
            // 
            this.data_view.AllowDrop = true;
            this.data_view.AllowUserToAddRows = false;
            this.data_view.AllowUserToDeleteRows = false;
            this.data_view.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.data_view.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.data_view.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.data_view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_view.Location = new System.Drawing.Point(12, 173);
            this.data_view.Name = "data_view";
            this.data_view.ReadOnly = true;
            this.data_view.Size = new System.Drawing.Size(1105, 302);
            this.data_view.TabIndex = 6;
            this.data_view.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Userdata_view_CellClick);
            // 
            // search
            // 
            this.search.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.search.AutoSize = true;
            this.search.Controls.Add(this.user_name_tbx);
            this.search.Controls.Add(this.label5);
            this.search.Controls.Add(this.label8);
            this.search.Controls.Add(this.label4);
            this.search.Controls.Add(this.label9);
            this.search.Controls.Add(this.end_date);
            this.search.Controls.Add(this.batchno_texbox);
            this.search.Controls.Add(this.start_date);
            this.search.Controls.Add(this.button1);
            this.search.Controls.Add(this.label3);
            this.search.Location = new System.Drawing.Point(575, 12);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(542, 147);
            this.search.TabIndex = 20;
            this.search.TabStop = false;
            this.search.Text = "Tìm Kiếm";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(193, 98);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(90, 30);
            this.button3.TabIndex = 20;
            this.button3.Text = "Xem chi tiết";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.showinffo);
            // 
            // export_data
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 487);
            this.Controls.Add(this.data_view);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.search);
            this.Name = "export_data";
            this.Text = "Xuất File";
            this.Load += new System.EventHandler(this.from_load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_view)).EndInit();
            this.search.ResumeLayout(false);
            this.search.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker end_date;
        private System.Windows.Forms.DateTimePicker start_date;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox user_name_tbx;
        private System.Windows.Forms.TextBox batchno_texbox;
        private System.Windows.Forms.DataGridView data_view;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label status_dp;
        private System.Windows.Forms.Label date_dp;
        private System.Windows.Forms.Label user_dp;
        private System.Windows.Forms.Label batchno_dp;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox search;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
    }
}
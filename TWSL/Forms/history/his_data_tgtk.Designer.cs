namespace TWSL.Forms.history
{
    partial class his_data_tgtk
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
            this.exit = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.end_date = new System.Windows.Forms.DateTimePicker();
            this.start_date = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.id_thaotac = new System.Windows.Forms.TextBox();
            this.some_tt = new System.Windows.Forms.TextBox();
            this.data_tk = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_tk)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.exit);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.end_date);
            this.groupBox1.Controls.Add(this.start_date);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.id_thaotac);
            this.groupBox1.Controls.Add(this.some_tt);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1195, 100);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin";
            // 
            // exit
            // 
            this.exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exit.Image = global::TWSL.Properties.Resources.logout;
            this.exit.Location = new System.Drawing.Point(1092, 18);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(80, 63);
            this.exit.TabIndex = 10;
            this.exit.Text = "Thoát";
            this.exit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(323, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Đến:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(334, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Từ:";
            // 
            // end_date
            // 
            this.end_date.Location = new System.Drawing.Point(363, 67);
            this.end_date.Name = "end_date";
            this.end_date.Size = new System.Drawing.Size(165, 20);
            this.end_date.TabIndex = 7;
            // 
            // start_date
            // 
            this.start_date.Location = new System.Drawing.Point(363, 40);
            this.start_date.Name = "start_date";
            this.start_date.Size = new System.Drawing.Size(165, 20);
            this.start_date.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(336, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Thời gian cần tìm:";
            // 
            // button1
            // 
            this.button1.Image = global::TWSL.Properties.Resources.search;
            this.button1.Location = new System.Drawing.Point(578, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 63);
            this.button1.TabIndex = 2;
            this.button1.Text = "Tìm Kiếm";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "ID người thao tác:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Số mẻ tiệt trùng:";
            // 
            // id_thaotac
            // 
            this.id_thaotac.Location = new System.Drawing.Point(124, 67);
            this.id_thaotac.Name = "id_thaotac";
            this.id_thaotac.Size = new System.Drawing.Size(145, 20);
            this.id_thaotac.TabIndex = 1;
            // 
            // some_tt
            // 
            this.some_tt.Location = new System.Drawing.Point(124, 21);
            this.some_tt.Name = "some_tt";
            this.some_tt.Size = new System.Drawing.Size(145, 20);
            this.some_tt.TabIndex = 0;
            // 
            // data_tk
            // 
            this.data_tk.AllowDrop = true;
            this.data_tk.AllowUserToAddRows = false;
            this.data_tk.AllowUserToDeleteRows = false;
            this.data_tk.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.data_tk.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.data_tk.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.data_tk.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_tk.Location = new System.Drawing.Point(12, 118);
            this.data_tk.Name = "data_tk";
            this.data_tk.ReadOnly = true;
            this.data_tk.Size = new System.Drawing.Size(1195, 362);
            this.data_tk.TabIndex = 6;
            // 
            // his_data_tgtk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1219, 492);
            this.Controls.Add(this.data_tk);
            this.Controls.Add(this.groupBox1);
            this.Name = "his_data_tgtk";
            this.Text = "Lịch sử của mẻ thoát khí";
            this.Load += new System.EventHandler(this.his_data_tgtk_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_tk)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker end_date;
        private System.Windows.Forms.DateTimePicker start_date;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox id_thaotac;
        private System.Windows.Forms.TextBox some_tt;
        private System.Windows.Forms.DataGridView data_tk;
    }
}
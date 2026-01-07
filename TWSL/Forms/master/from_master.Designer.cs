namespace TWSL
{
    partial class from_master
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(from_master));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.statuscbb = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.version_tbx = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.itemcode = new System.Windows.Forms.TextBox();
            this.masterdata_view = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.masterdata_view)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Location = new System.Drawing.Point(12, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(187, 110);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chức năng";
            // 
            // button4
            // 
            this.button4.Image = global::TWSL.Properties.Resources.excel;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button4.Location = new System.Drawing.Point(18, 63);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(126, 33);
            this.button4.TabIndex = 5;
            this.button4.Text = "Xuất dữ liệu";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // button3
            // 
            this.button3.Image = global::TWSL.Properties.Resources.add;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.Location = new System.Drawing.Point(18, 22);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(126, 33);
            this.button3.TabIndex = 4;
            this.button3.Text = "Thêm master";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.up_data_master);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.statuscbb);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.version_tbx);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.itemcode);
            this.groupBox2.Location = new System.Drawing.Point(205, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(805, 110);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tìm kiếm";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Image = global::TWSL.Properties.Resources.logout;
            this.button2.Location = new System.Drawing.Point(725, 18);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(61, 74);
            this.button2.TabIndex = 6;
            this.button2.Text = "Thoát";
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // statuscbb
            // 
            this.statuscbb.AllowDrop = true;
            this.statuscbb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statuscbb.FormattingEnabled = true;
            this.statuscbb.Items.AddRange(new object[] {
            "",
            "Chưa phê duyệt",
            "Đã phê duyệt",
            "Vô Hiệu hóa"});
            this.statuscbb.Location = new System.Drawing.Point(384, 22);
            this.statuscbb.Name = "statuscbb";
            this.statuscbb.Size = new System.Drawing.Size(121, 21);
            this.statuscbb.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Máy:";
            // 
            // version_tbx
            // 
            this.version_tbx.Location = new System.Drawing.Point(94, 70);
            this.version_tbx.Name = "version_tbx";
            this.version_tbx.Size = new System.Drawing.Size(178, 20);
            this.version_tbx.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(308, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Trạng thái";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Image = global::TWSL.Properties.Resources.search;
            this.button1.Location = new System.Drawing.Point(618, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 74);
            this.button1.TabIndex = 2;
            this.button1.Text = "Tìm kiếm";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Item code:";
            // 
            // itemcode
            // 
            this.itemcode.Location = new System.Drawing.Point(94, 26);
            this.itemcode.Name = "itemcode";
            this.itemcode.Size = new System.Drawing.Size(178, 20);
            this.itemcode.TabIndex = 0;
            // 
            // masterdata_view
            // 
            this.masterdata_view.AllowUserToAddRows = false;
            this.masterdata_view.AllowUserToDeleteRows = false;
            this.masterdata_view.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.masterdata_view.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.masterdata_view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.masterdata_view.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.masterdata_view.Location = new System.Drawing.Point(4, 120);
            this.masterdata_view.Name = "masterdata_view";
            this.masterdata_view.ReadOnly = true;
            this.masterdata_view.Size = new System.Drawing.Size(998, 381);
            this.masterdata_view.TabIndex = 2;
            this.masterdata_view.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Masterdata_view_MouseClick);
            // 
            // from_master
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 513);
            this.Controls.Add(this.masterdata_view);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "from_master";
            this.Text = "Quản lý Master";
            this.Load += new System.EventHandler(this.from_master_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.masterdata_view)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView masterdata_view;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox itemcode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox version_tbx;
        private System.Windows.Forms.ComboBox statuscbb;
        private System.Windows.Forms.Button button2;
    }
}
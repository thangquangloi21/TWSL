namespace TWSL.Forms.master
{
    partial class FromMasterWH
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.DataView = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.GrFunc = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.statuscbb = new System.Windows.Forms.ComboBox();
            this.button5 = new System.Windows.Forms.Button();
            this.Sttlb = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.MachineLb = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.IdTbx = new System.Windows.Forms.TextBox();
            this.MachineTbx = new System.Windows.Forms.TextBox();
            this.ItemTbx = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataView)).BeginInit();
            this.panel3.SuspendLayout();
            this.GrFunc.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(153, 544);
            this.panel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 98);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(153, 446);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Master Data";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(9, 108);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(135, 48);
            this.button2.TabIndex = 1;
            this.button2.Text = "Pallet";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.MasterPallet);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 48);
            this.button1.TabIndex = 0;
            this.button1.Text = "Thoát khí";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.MasterThoatKhi);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::TWSL.Properties.Resources.computer;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(153, 98);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.DataView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(153, 98);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1014, 446);
            this.panel2.TabIndex = 1;
            // 
            // DataView
            // 
            this.DataView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.DataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataView.Location = new System.Drawing.Point(0, 0);
            this.DataView.Name = "DataView";
            this.DataView.Size = new System.Drawing.Size(1014, 446);
            this.DataView.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.GrFunc);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(153, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1014, 98);
            this.panel3.TabIndex = 1;
            // 
            // GrFunc
            // 
            this.GrFunc.Controls.Add(this.button4);
            this.GrFunc.Controls.Add(this.button3);
            this.GrFunc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrFunc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrFunc.Location = new System.Drawing.Point(0, 0);
            this.GrFunc.Name = "GrFunc";
            this.GrFunc.Size = new System.Drawing.Size(417, 98);
            this.GrFunc.TabIndex = 1;
            this.GrFunc.TabStop = false;
            this.GrFunc.Text = "Chức năng";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(216, 30);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(95, 52);
            this.button4.TabIndex = 3;
            this.button4.Text = "Export";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(53, 30);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(95, 52);
            this.button3.TabIndex = 2;
            this.button3.Text = "ADD";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Adddata);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.statuscbb);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.Sttlb);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.MachineLb);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.IdTbx);
            this.groupBox1.Controls.Add(this.MachineTbx);
            this.groupBox1.Controls.Add(this.ItemTbx);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(417, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(597, 98);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm Kiếm";
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
            this.statuscbb.Location = new System.Drawing.Point(313, 54);
            this.statuscbb.Name = "statuscbb";
            this.statuscbb.Size = new System.Drawing.Size(174, 28);
            this.statuscbb.TabIndex = 21;
            this.statuscbb.SelectedIndexChanged += new System.EventHandler(this.statuscbb_SelectedIndexChanged);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(503, 21);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(82, 61);
            this.button5.TabIndex = 4;
            this.button5.Text = "Tìm Kiếm";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.SearchBtn);
            // 
            // Sttlb
            // 
            this.Sttlb.AutoSize = true;
            this.Sttlb.Location = new System.Drawing.Point(223, 62);
            this.Sttlb.Name = "Sttlb";
            this.Sttlb.Size = new System.Drawing.Size(84, 20);
            this.Sttlb.TabIndex = 7;
            this.Sttlb.Text = "Trạng thái:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(232, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "ID:";
            // 
            // MachineLb
            // 
            this.MachineLb.AutoSize = true;
            this.MachineLb.Location = new System.Drawing.Point(6, 62);
            this.MachineLb.Name = "MachineLb";
            this.MachineLb.Size = new System.Drawing.Size(73, 20);
            this.MachineLb.TabIndex = 5;
            this.MachineLb.Text = "Machine:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Item:";
            // 
            // IdTbx
            // 
            this.IdTbx.Location = new System.Drawing.Point(313, 22);
            this.IdTbx.Name = "IdTbx";
            this.IdTbx.Size = new System.Drawing.Size(174, 26);
            this.IdTbx.TabIndex = 2;
            // 
            // MachineTbx
            // 
            this.MachineTbx.Location = new System.Drawing.Point(84, 56);
            this.MachineTbx.Name = "MachineTbx";
            this.MachineTbx.Size = new System.Drawing.Size(133, 26);
            this.MachineTbx.TabIndex = 1;
            // 
            // ItemTbx
            // 
            this.ItemTbx.Location = new System.Drawing.Point(84, 21);
            this.ItemTbx.Name = "ItemTbx";
            this.ItemTbx.Size = new System.Drawing.Size(133, 26);
            this.ItemTbx.TabIndex = 0;
            // 
            // FromMasterWH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1167, 544);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "FromMasterWH";
            this.Text = "FromMasterWH";
            this.Load += new System.EventHandler(this.FromMasterWH_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataView)).EndInit();
            this.panel3.ResumeLayout(false);
            this.GrFunc.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView DataView;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox GrFunc;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox IdTbx;
        private System.Windows.Forms.TextBox MachineTbx;
        private System.Windows.Forms.TextBox ItemTbx;
        private System.Windows.Forms.Label Sttlb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label MachineLb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ComboBox statuscbb;
    }
}
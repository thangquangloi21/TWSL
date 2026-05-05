namespace TWSL.Forms.main.WH
{
    partial class ChonMe
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Item_dp = new System.Windows.Forms.Label();
            this.bathno_dp = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.NoBatch = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Machine_dp = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Lot_dp = new System.Windows.Forms.Label();
            this.Date_Create = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataview = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataview)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.Item_dp);
            this.panel1.Controls.Add(this.bathno_dp);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.NoBatch);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1377, 116);
            this.panel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(780, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(597, 116);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chức năng";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(77, 28);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(161, 76);
            this.button2.TabIndex = 9;
            this.button2.Text = "Xem chi tiết";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.XemThongTin);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(319, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 76);
            this.button1.TabIndex = 8;
            this.button1.Text = "Tạo Phiếu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.select_ok);
            // 
            // Item_dp
            // 
            this.Item_dp.AutoSize = true;
            this.Item_dp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Item_dp.Location = new System.Drawing.Point(132, 74);
            this.Item_dp.Name = "Item_dp";
            this.Item_dp.Size = new System.Drawing.Size(21, 20);
            this.Item_dp.TabIndex = 3;
            this.Item_dp.Text = "...";
            // 
            // bathno_dp
            // 
            this.bathno_dp.AutoSize = true;
            this.bathno_dp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bathno_dp.Location = new System.Drawing.Point(78, 28);
            this.bathno_dp.Name = "bathno_dp";
            this.bathno_dp.Size = new System.Drawing.Size(21, 20);
            this.bathno_dp.TabIndex = 2;
            this.bathno_dp.Text = "...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên sản phẩm:";
            // 
            // NoBatch
            // 
            this.NoBatch.AutoSize = true;
            this.NoBatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoBatch.Location = new System.Drawing.Point(13, 28);
            this.NoBatch.Name = "NoBatch";
            this.NoBatch.Size = new System.Drawing.Size(59, 20);
            this.NoBatch.TabIndex = 0;
            this.NoBatch.Text = "Số mẻ:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.Machine_dp);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.Lot_dp);
            this.groupBox1.Controls.Add(this.Date_Create);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(780, 116);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(312, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Lot:";
            // 
            // Machine_dp
            // 
            this.Machine_dp.AutoSize = true;
            this.Machine_dp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Machine_dp.Location = new System.Drawing.Point(578, 74);
            this.Machine_dp.Name = "Machine_dp";
            this.Machine_dp.Size = new System.Drawing.Size(21, 20);
            this.Machine_dp.TabIndex = 12;
            this.Machine_dp.Text = "...";
            this.Machine_dp.Click += new System.EventHandler(this.Machine_dp_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(502, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 20);
            this.label8.TabIndex = 9;
            this.label8.Text = "Máy:";
            // 
            // Lot_dp
            // 
            this.Lot_dp.AutoSize = true;
            this.Lot_dp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lot_dp.Location = new System.Drawing.Point(354, 74);
            this.Lot_dp.Name = "Lot_dp";
            this.Lot_dp.Size = new System.Drawing.Size(21, 20);
            this.Lot_dp.TabIndex = 7;
            this.Lot_dp.Text = "...";
            // 
            // Date_Create
            // 
            this.Date_Create.AutoSize = true;
            this.Date_Create.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Date_Create.Location = new System.Drawing.Point(434, 28);
            this.Date_Create.Name = "Date_Create";
            this.Date_Create.Size = new System.Drawing.Size(21, 20);
            this.Date_Create.TabIndex = 6;
            this.Date_Create.Text = "...";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(312, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Thời gian tạo:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataview);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 116);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1377, 483);
            this.panel2.TabIndex = 1;
            // 
            // dataview
            // 
            this.dataview.AllowDrop = true;
            this.dataview.AllowUserToAddRows = false;
            this.dataview.AllowUserToDeleteRows = false;
            this.dataview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataview.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataview.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataview.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataview.Location = new System.Drawing.Point(0, 0);
            this.dataview.Name = "dataview";
            this.dataview.ReadOnly = true;
            this.dataview.Size = new System.Drawing.Size(1377, 483);
            this.dataview.TabIndex = 0;
            this.dataview.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // ChonMe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1377, 599);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ChonMe";
            this.Text = "Chọn mẻ";
            this.Load += new System.EventHandler(this.SelectBatch_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataview;
        private System.Windows.Forms.Label Item_dp;
        private System.Windows.Forms.Label bathno_dp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label NoBatch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label Lot_dp;
        private System.Windows.Forms.Label Date_Create;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label Machine_dp;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
    }
}
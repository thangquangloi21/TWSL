namespace TWSL.Forms.main.WH
{
    partial class XemChiTiet
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.Exit = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.viewdata = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.viewdata)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.Exit);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 472);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1159, 81);
            this.panel2.TabIndex = 1;
            // 
            // Exit
            // 
            this.Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Exit.Location = new System.Drawing.Point(274, 20);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(166, 40);
            this.Exit.TabIndex = 0;
            this.Exit.Text = "Cancel";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1159, 42);
            this.panel3.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(493, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thông tin chi tiết";
            // 
            // viewdata
            // 
            this.viewdata.AllowUserToAddRows = false;
            this.viewdata.AllowUserToDeleteRows = false;
            this.viewdata.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.viewdata.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.viewdata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.viewdata.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewdata.Location = new System.Drawing.Point(0, 42);
            this.viewdata.Name = "viewdata";
            this.viewdata.ReadOnly = true;
            this.viewdata.Size = new System.Drawing.Size(1159, 430);
            this.viewdata.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(708, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(166, 40);
            this.button1.TabIndex = 1;
            this.button1.Text = "Tạo phiếu";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(498, 20);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(166, 40);
            this.button2.TabIndex = 2;
            this.button2.Text = "Sửa thông tin";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // DP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1159, 553);
            this.Controls.Add(this.viewdata);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DP";
            this.Text = "Thông tin Phiếu";
            this.Load += new System.EventHandler(this.DP_Load);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.viewdata)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView viewdata;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}
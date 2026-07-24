namespace TWSL.Forms.main.WH.MasterManage.master
{
    partial class FromTempMaster
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
            this.button3 = new System.Windows.Forms.Button();
            this.Chon_TEMP = new System.Windows.Forms.Button();
            this.Luu_temp = new System.Windows.Forms.Button();
            this.LinkFile_tbx = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.Chon_TEMP);
            this.groupBox1.Controls.Add(this.Luu_temp);
            this.groupBox1.Controls.Add(this.LinkFile_tbx);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(733, 244);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TEMPLATE MASTER";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(222, 166);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(120, 41);
            this.button3.TabIndex = 6;
            this.button3.Text = "Thoát";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Chon_TEMP
            // 
            this.Chon_TEMP.Location = new System.Drawing.Point(619, 83);
            this.Chon_TEMP.Name = "Chon_TEMP";
            this.Chon_TEMP.Size = new System.Drawing.Size(102, 40);
            this.Chon_TEMP.TabIndex = 5;
            this.Chon_TEMP.Text = "Chọn";
            this.Chon_TEMP.UseVisualStyleBackColor = true;
            this.Chon_TEMP.Click += new System.EventHandler(this.Chon_temp);
            // 
            // Luu_temp
            // 
            this.Luu_temp.Location = new System.Drawing.Point(435, 166);
            this.Luu_temp.Name = "Luu_temp";
            this.Luu_temp.Size = new System.Drawing.Size(120, 41);
            this.Luu_temp.TabIndex = 4;
            this.Luu_temp.Text = "Lưu";
            this.Luu_temp.UseVisualStyleBackColor = true;
            this.Luu_temp.Click += new System.EventHandler(this.Luu_temp_Click);
            // 
            // LinkFile_tbx
            // 
            this.LinkFile_tbx.Location = new System.Drawing.Point(177, 88);
            this.LinkFile_tbx.Name = "LinkFile_tbx";
            this.LinkFile_tbx.Size = new System.Drawing.Size(417, 29);
            this.LinkFile_tbx.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nhập đường dẫn:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(187, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Template hiện tại:";
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            this.fileSystemWatcher1.Changed += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Changed);
            // 
            // FromTempMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 244);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FromTempMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FromTempMaster";
            this.Load += new System.EventHandler(this.FromTempMaster_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button Chon_TEMP;
        private System.Windows.Forms.Button Luu_temp;
        private System.Windows.Forms.TextBox LinkFile_tbx;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
    }
}
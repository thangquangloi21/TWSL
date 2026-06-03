namespace TWSL.Forms.main.WH.TaoFileR200
{
    partial class DocSoPhieu
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
            this.INPSoPhieuTbx = new System.Windows.Forms.TextBox();
            this.OKSoPhieuBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // INPSoPhieuTbx
            // 
            this.INPSoPhieuTbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.INPSoPhieuTbx.Location = new System.Drawing.Point(12, 50);
            this.INPSoPhieuTbx.Name = "INPSoPhieuTbx";
            this.INPSoPhieuTbx.Size = new System.Drawing.Size(437, 38);
            this.INPSoPhieuTbx.TabIndex = 2;
            this.INPSoPhieuTbx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoPhieuTbx);
            // 
            // OKSoPhieuBtn
            // 
            this.OKSoPhieuBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OKSoPhieuBtn.Location = new System.Drawing.Point(474, 50);
            this.OKSoPhieuBtn.Name = "OKSoPhieuBtn";
            this.OKSoPhieuBtn.Size = new System.Drawing.Size(75, 38);
            this.OKSoPhieuBtn.TabIndex = 3;
            this.OKSoPhieuBtn.Text = "OK";
            this.OKSoPhieuBtn.UseVisualStyleBackColor = true;
            this.OKSoPhieuBtn.Click += new System.EventHandler(this.OKSoPhieuBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.INPSoPhieuTbx);
            this.groupBox1.Controls.Add(this.OKSoPhieuBtn);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(719, 118);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nhập Số Phiếu:";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(581, 50);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 38);
            this.button1.TabIndex = 4;
            this.button1.Text = "Thoát";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ThoatBtn);
            // 
            // DocSoPhieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 118);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DocSoPhieu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập số phiếu";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox INPSoPhieuTbx;
        private System.Windows.Forms.Button OKSoPhieuBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
    }
}
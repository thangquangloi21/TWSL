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
            this.label2 = new System.Windows.Forms.Label();
            this.INPSoPhieuTbx = new System.Windows.Forms.TextBox();
            this.OKSoPhieuBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "Số Phiếu:";
            // 
            // INPSoPhieuTbx
            // 
            this.INPSoPhieuTbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.INPSoPhieuTbx.Location = new System.Drawing.Point(157, 20);
            this.INPSoPhieuTbx.Name = "INPSoPhieuTbx";
            this.INPSoPhieuTbx.Size = new System.Drawing.Size(386, 38);
            this.INPSoPhieuTbx.TabIndex = 2;
            this.INPSoPhieuTbx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoPhieuTbx);
            // 
            // OKSoPhieuBtn
            // 
            this.OKSoPhieuBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OKSoPhieuBtn.Location = new System.Drawing.Point(563, 20);
            this.OKSoPhieuBtn.Name = "OKSoPhieuBtn";
            this.OKSoPhieuBtn.Size = new System.Drawing.Size(75, 38);
            this.OKSoPhieuBtn.TabIndex = 3;
            this.OKSoPhieuBtn.Text = "OK";
            this.OKSoPhieuBtn.UseVisualStyleBackColor = true;
            this.OKSoPhieuBtn.Click += new System.EventHandler(this.OKSoPhieuBtn_Click);
            // 
            // DocSoPhieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 89);
            this.Controls.Add(this.OKSoPhieuBtn);
            this.Controls.Add(this.INPSoPhieuTbx);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DocSoPhieu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập số phiếu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox INPSoPhieuTbx;
        private System.Windows.Forms.Button OKSoPhieuBtn;
    }
}
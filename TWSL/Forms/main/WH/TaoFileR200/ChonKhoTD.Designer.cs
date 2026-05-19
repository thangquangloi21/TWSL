namespace TWSL.Forms.main.WH.TaoFileR200
{
    partial class ChonKhoTD
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
            this.KhoA = new System.Windows.Forms.Button();
            this.KhoB = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox1.Controls.Add(this.KhoB);
            this.groupBox1.Controls.Add(this.KhoA);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(582, 263);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CHỌN KHO THOÁT KHÍ";
            // 
            // KhoA
            // 
            this.KhoA.Location = new System.Drawing.Point(51, 83);
            this.KhoA.Name = "KhoA";
            this.KhoA.Size = new System.Drawing.Size(194, 117);
            this.KhoA.TabIndex = 0;
            this.KhoA.Text = "KHO A";
            this.KhoA.UseVisualStyleBackColor = true;
            // 
            // KhoB
            // 
            this.KhoB.Location = new System.Drawing.Point(323, 83);
            this.KhoB.Name = "KhoB";
            this.KhoB.Size = new System.Drawing.Size(194, 117);
            this.KhoB.TabIndex = 1;
            this.KhoB.Text = "KHO B";
            this.KhoB.UseVisualStyleBackColor = true;
            // 
            // ChonKhoTD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 263);
            this.Controls.Add(this.groupBox1);
            this.Name = "ChonKhoTD";
            this.Text = "ChonKhoTD";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button KhoB;
        private System.Windows.Forms.Button KhoA;
    }
}
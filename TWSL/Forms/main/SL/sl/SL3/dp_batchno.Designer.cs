namespace TWSL
{
    partial class info_batchno
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
            this.data_view_dp = new System.Windows.Forms.DataGridView();
            this.exportcsv = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.data_view_dp)).BeginInit();
            this.SuspendLayout();
            // 
            // data_view_dp
            // 
            this.data_view_dp.AllowDrop = true;
            this.data_view_dp.AllowUserToAddRows = false;
            this.data_view_dp.AllowUserToDeleteRows = false;
            this.data_view_dp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.data_view_dp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.data_view_dp.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.data_view_dp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_view_dp.Location = new System.Drawing.Point(1, -2);
            this.data_view_dp.Name = "data_view_dp";
            this.data_view_dp.ReadOnly = true;
            this.data_view_dp.Size = new System.Drawing.Size(1005, 441);
            this.data_view_dp.TabIndex = 7;
            // 
            // exportcsv
            // 
            this.exportcsv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.exportcsv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.exportcsv.Image = global::TWSL.Properties.Resources.excel;
            this.exportcsv.Location = new System.Drawing.Point(876, 450);
            this.exportcsv.Margin = new System.Windows.Forms.Padding(10);
            this.exportcsv.Name = "exportcsv";
            this.exportcsv.Size = new System.Drawing.Size(109, 50);
            this.exportcsv.TabIndex = 20;
            this.exportcsv.Text = "Xuất CSV";
            this.exportcsv.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.exportcsv.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.exportcsv.UseVisualStyleBackColor = false;
            this.exportcsv.Click += new System.EventHandler(this.button2_Click);
            // 
            // info_batchno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 511);
            this.Controls.Add(this.exportcsv);
            this.Controls.Add(this.data_view_dp);
            this.Name = "info_batchno";
            this.Text = "Thông tin: ";
            this.Load += new System.EventHandler(this.info_batchno_Load);
            ((System.ComponentModel.ISupportInitialize)(this.data_view_dp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView data_view_dp;
        private System.Windows.Forms.Button exportcsv;
    }
}
namespace TWSL.Forms.main.WH.TaoFileR200
{
    partial class AddPaleet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPaleet));
            this.topPanel = new System.Windows.Forms.Panel();
            this.enterPanel = new System.Windows.Forms.Panel();
            this.tableInput = new System.Windows.Forms.TableLayoutPanel();
            this.pnlPallet = new System.Windows.Forms.Panel();
            this.lblPallet = new System.Windows.Forms.Label();
            this.txtPallet = new System.Windows.Forms.TextBox();
            this.btnCheckPallet = new System.Windows.Forms.Button();
            this.pnlBox = new System.Windows.Forms.Panel();
            this.lblBox = new System.Windows.Forms.Label();
            this.txtBox = new System.Windows.Forms.TextBox();
            this.btnCheckBox = new System.Windows.Forms.Button();
            this.separator = new System.Windows.Forms.Panel();
            this.savePanel = new System.Windows.Forms.Panel();
            this.pnlSaveInner = new System.Windows.Forms.Panel();
            this.picSave = new System.Windows.Forms.PictureBox();
            this.lblSave = new System.Windows.Forms.Label();
            this.btnSaveNow = new System.Windows.Forms.Button();
            this.dataPanel = new System.Windows.Forms.Panel();
            this.DataTaoFile = new System.Windows.Forms.DataGridView();
            this.colSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPallet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.footerPanel = new System.Windows.Forms.Panel();
            this.panelStats = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblSuccess = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.panelActions = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDeleteSelected = new System.Windows.Forms.Button();
            this.topPanel.SuspendLayout();
            this.enterPanel.SuspendLayout();
            this.tableInput.SuspendLayout();
            this.pnlPallet.SuspendLayout();
            this.pnlBox.SuspendLayout();
            this.savePanel.SuspendLayout();
            this.pnlSaveInner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSave)).BeginInit();
            this.dataPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataTaoFile)).BeginInit();
            this.footerPanel.SuspendLayout();
            this.panelStats.SuspendLayout();
            this.panelActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.enterPanel);
            this.topPanel.Controls.Add(this.separator);
            this.topPanel.Controls.Add(this.savePanel);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Padding = new System.Windows.Forms.Padding(12);
            this.topPanel.Size = new System.Drawing.Size(1200, 140);
            this.topPanel.TabIndex = 2;
            // 
            // enterPanel
            // 
            this.enterPanel.Controls.Add(this.tableInput);
            this.enterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.enterPanel.Location = new System.Drawing.Point(12, 12);
            this.enterPanel.Name = "enterPanel";
            this.enterPanel.Padding = new System.Windows.Forms.Padding(6);
            this.enterPanel.Size = new System.Drawing.Size(916, 116);
            this.enterPanel.TabIndex = 0;
            // 
            // tableInput
            // 
            this.tableInput.ColumnCount = 1;
            this.tableInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableInput.Controls.Add(this.pnlPallet, 0, 0);
            this.tableInput.Controls.Add(this.pnlBox, 0, 1);
            this.tableInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableInput.Location = new System.Drawing.Point(6, 6);
            this.tableInput.Name = "tableInput";
            this.tableInput.RowCount = 2;
            this.tableInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableInput.Size = new System.Drawing.Size(904, 104);
            this.tableInput.TabIndex = 0;
            // 
            // pnlPallet
            // 
            this.pnlPallet.Controls.Add(this.lblPallet);
            this.pnlPallet.Controls.Add(this.txtPallet);
            this.pnlPallet.Controls.Add(this.btnCheckPallet);
            this.pnlPallet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPallet.Location = new System.Drawing.Point(3, 3);
            this.pnlPallet.Name = "pnlPallet";
            this.pnlPallet.Padding = new System.Windows.Forms.Padding(8);
            this.pnlPallet.Size = new System.Drawing.Size(898, 46);
            this.pnlPallet.TabIndex = 0;
            // 
            // lblPallet
            // 
            this.lblPallet.AutoSize = true;
            this.lblPallet.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPallet.Location = new System.Drawing.Point(8, 14);
            this.lblPallet.Name = "lblPallet";
            this.lblPallet.Size = new System.Drawing.Size(76, 19);
            this.lblPallet.TabIndex = 0;
            this.lblPallet.Text = "Mã Pallet:";
            // 
            // txtPallet
            // 
            this.txtPallet.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPallet.Location = new System.Drawing.Point(120, 10);
            this.txtPallet.Name = "txtPallet";
            this.txtPallet.Size = new System.Drawing.Size(600, 25);
            this.txtPallet.TabIndex = 1;
            // 
            // btnCheckPallet
            // 
            this.btnCheckPallet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnCheckPallet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckPallet.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCheckPallet.ForeColor = System.Drawing.Color.White;
            this.btnCheckPallet.Location = new System.Drawing.Point(740, 8);
            this.btnCheckPallet.Name = "btnCheckPallet";
            this.btnCheckPallet.Size = new System.Drawing.Size(110, 34);
            this.btnCheckPallet.TabIndex = 2;
            this.btnCheckPallet.Text = "🔍 Kiểm tra";
            this.btnCheckPallet.UseMnemonic = false;
            this.btnCheckPallet.UseVisualStyleBackColor = false;
            this.btnCheckPallet.Click += new System.EventHandler(this.btnCheckPallet_Click);
            // 
            // pnlBox
            // 
            this.pnlBox.Controls.Add(this.lblBox);
            this.pnlBox.Controls.Add(this.txtBox);
            this.pnlBox.Controls.Add(this.btnCheckBox);
            this.pnlBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBox.Location = new System.Drawing.Point(3, 55);
            this.pnlBox.Name = "pnlBox";
            this.pnlBox.Padding = new System.Windows.Forms.Padding(8);
            this.pnlBox.Size = new System.Drawing.Size(898, 46);
            this.pnlBox.TabIndex = 1;
            // 
            // lblBox
            // 
            this.lblBox.AutoSize = true;
            this.lblBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblBox.Location = new System.Drawing.Point(8, 14);
            this.lblBox.Name = "lblBox";
            this.lblBox.Size = new System.Drawing.Size(79, 19);
            this.lblBox.TabIndex = 0;
            this.lblBox.Text = "Mã Thùng:";
            // 
            // txtBox
            // 
            this.txtBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtBox.Location = new System.Drawing.Point(120, 10);
            this.txtBox.Name = "txtBox";
            this.txtBox.Size = new System.Drawing.Size(600, 25);
            this.txtBox.TabIndex = 1;
            // 
            // btnCheckBox
            // 
            this.btnCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(135)))), ((int)(((byte)(84)))));
            this.btnCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCheckBox.ForeColor = System.Drawing.Color.White;
            this.btnCheckBox.Location = new System.Drawing.Point(740, 8);
            this.btnCheckBox.Name = "btnCheckBox";
            this.btnCheckBox.Size = new System.Drawing.Size(110, 34);
            this.btnCheckBox.TabIndex = 2;
            this.btnCheckBox.Text = "🔍 Kiểm tra";
            this.btnCheckBox.UseMnemonic = false;
            this.btnCheckBox.UseVisualStyleBackColor = false;
            // 
            // separator
            // 
            this.separator.Location = new System.Drawing.Point(0, 0);
            this.separator.Name = "separator";
            this.separator.Size = new System.Drawing.Size(12, 100);
            this.separator.TabIndex = 1;
            // 
            // savePanel
            // 
            this.savePanel.Controls.Add(this.pnlSaveInner);
            this.savePanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.savePanel.Location = new System.Drawing.Point(928, 12);
            this.savePanel.Name = "savePanel";
            this.savePanel.Padding = new System.Windows.Forms.Padding(8);
            this.savePanel.Size = new System.Drawing.Size(260, 116);
            this.savePanel.TabIndex = 2;
            // 
            // pnlSaveInner
            // 
            this.pnlSaveInner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSaveInner.Controls.Add(this.picSave);
            this.pnlSaveInner.Controls.Add(this.lblSave);
            this.pnlSaveInner.Controls.Add(this.btnSaveNow);
            this.pnlSaveInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSaveInner.Location = new System.Drawing.Point(8, 8);
            this.pnlSaveInner.Name = "pnlSaveInner";
            this.pnlSaveInner.Size = new System.Drawing.Size(244, 100);
            this.pnlSaveInner.TabIndex = 0;
            // 
            // picSave
            // 
            this.picSave.Location = new System.Drawing.Point(12, 12);
            this.picSave.Name = "picSave";
            this.picSave.Size = new System.Drawing.Size(64, 64);
            this.picSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picSave.TabIndex = 0;
            this.picSave.TabStop = false;
            // 
            // lblSave
            // 
            this.lblSave.AutoSize = true;
            this.lblSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(135)))), ((int)(((byte)(84)))));
            this.lblSave.Location = new System.Drawing.Point(90, 20);
            this.lblSave.Name = "lblSave";
            this.lblSave.Size = new System.Drawing.Size(94, 19);
            this.lblSave.TabIndex = 1;
            this.lblSave.Text = "LƯU DỮ LIỆU";
            // 
            // btnSaveNow
            // 
            this.btnSaveNow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(135)))), ((int)(((byte)(84)))));
            this.btnSaveNow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveNow.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSaveNow.ForeColor = System.Drawing.Color.White;
            this.btnSaveNow.Location = new System.Drawing.Point(92, 44);
            this.btnSaveNow.Name = "btnSaveNow";
            this.btnSaveNow.Size = new System.Drawing.Size(140, 34);
            this.btnSaveNow.TabIndex = 2;
            this.btnSaveNow.Text = "💾 Lưu ngay";
            this.btnSaveNow.UseVisualStyleBackColor = false;
            // 
            // dataPanel
            // 
            this.dataPanel.Controls.Add(this.DataTaoFile);
            this.dataPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataPanel.Location = new System.Drawing.Point(0, 140);
            this.dataPanel.Name = "dataPanel";
            this.dataPanel.Padding = new System.Windows.Forms.Padding(12);
            this.dataPanel.Size = new System.Drawing.Size(1200, 516);
            this.dataPanel.TabIndex = 0;
            // 
            // DataTaoFile
            // 
            this.DataTaoFile.AllowUserToAddRows = false;
            this.DataTaoFile.AllowUserToDeleteRows = false;
            this.DataTaoFile.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataTaoFile.BackgroundColor = System.Drawing.Color.White;
            this.DataTaoFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataTaoFile.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSTT,
            this.colPallet,
            this.colBox,
            this.colStatus,
            this.colTime,
            this.colNote});
            this.DataTaoFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataTaoFile.Location = new System.Drawing.Point(12, 12);
            this.DataTaoFile.Name = "DataTaoFile";
            this.DataTaoFile.ReadOnly = true;
            this.DataTaoFile.RowHeadersVisible = false;
            this.DataTaoFile.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataTaoFile.Size = new System.Drawing.Size(1176, 492);
            this.DataTaoFile.TabIndex = 0;
            // 
            // colSTT
            // 
            this.colSTT.FillWeight = 40F;
            this.colSTT.HeaderText = "STT";
            this.colSTT.Name = "colSTT";
            this.colSTT.ReadOnly = true;
            // 
            // colPallet
            // 
            this.colPallet.HeaderText = "Mã Pallet";
            this.colPallet.Name = "colPallet";
            this.colPallet.ReadOnly = true;
            // 
            // colBox
            // 
            this.colBox.HeaderText = "Mã Thùng";
            this.colBox.Name = "colBox";
            this.colBox.ReadOnly = true;
            // 
            // colStatus
            // 
            this.colStatus.FillWeight = 120F;
            this.colStatus.HeaderText = "Trạng thái";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // colTime
            // 
            this.colTime.HeaderText = "Thời gian";
            this.colTime.Name = "colTime";
            this.colTime.ReadOnly = true;
            // 
            // colNote
            // 
            this.colNote.FillWeight = 150F;
            this.colNote.HeaderText = "Ghi chú";
            this.colNote.Name = "colNote";
            this.colNote.ReadOnly = true;
            // 
            // footerPanel
            // 
            this.footerPanel.Controls.Add(this.panelStats);
            this.footerPanel.Controls.Add(this.panelActions);
            this.footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footerPanel.Location = new System.Drawing.Point(0, 656);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.Padding = new System.Windows.Forms.Padding(12);
            this.footerPanel.Size = new System.Drawing.Size(1200, 64);
            this.footerPanel.TabIndex = 1;
            // 
            // panelStats
            // 
            this.panelStats.AutoSize = true;
            this.panelStats.Controls.Add(this.lblTotal);
            this.panelStats.Controls.Add(this.lblSuccess);
            this.panelStats.Controls.Add(this.lblError);
            this.panelStats.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelStats.Location = new System.Drawing.Point(12, 12);
            this.panelStats.Name = "panelStats";
            this.panelStats.Size = new System.Drawing.Size(102, 40);
            this.panelStats.TabIndex = 0;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotal.Location = new System.Drawing.Point(6, 18);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(6, 18, 6, 6);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(90, 15);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "Tổng bản ghi: 0";
            // 
            // lblSuccess
            // 
            this.lblSuccess.AutoSize = true;
            this.lblSuccess.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSuccess.ForeColor = System.Drawing.Color.SeaGreen;
            this.lblSuccess.Location = new System.Drawing.Point(12, 57);
            this.lblSuccess.Margin = new System.Windows.Forms.Padding(12, 18, 6, 6);
            this.lblSuccess.Name = "lblSuccess";
            this.lblSuccess.Size = new System.Drawing.Size(83, 15);
            this.lblSuccess.TabIndex = 1;
            this.lblSuccess.Text = "Thành công: 0";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblError.ForeColor = System.Drawing.Color.DarkRed;
            this.lblError.Location = new System.Drawing.Point(12, 96);
            this.lblError.Margin = new System.Windows.Forms.Padding(12, 18, 6, 6);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(35, 15);
            this.lblError.TabIndex = 2;
            this.lblError.Text = "Lỗi: 0";
            // 
            // panelActions
            // 
            this.panelActions.AutoSize = true;
            this.panelActions.Controls.Add(this.btnClearAll);
            this.panelActions.Controls.Add(this.btnRefresh);
            this.panelActions.Controls.Add(this.btnDeleteSelected);
            this.panelActions.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelActions.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.panelActions.Location = new System.Drawing.Point(1072, 12);
            this.panelActions.Name = "panelActions";
            this.panelActions.Size = new System.Drawing.Size(116, 40);
            this.panelActions.TabIndex = 1;
            // 
            // btnClearAll
            // 
            this.btnClearAll.BackColor = System.Drawing.Color.White;
            this.btnClearAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearAll.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClearAll.ForeColor = System.Drawing.Color.DarkRed;
            this.btnClearAll.Location = new System.Drawing.Point(3, 3);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(110, 34);
            this.btnClearAll.TabIndex = 0;
            this.btnClearAll.Text = "❌ Xóa tất cả";
            this.btnClearAll.UseVisualStyleBackColor = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRefresh.Location = new System.Drawing.Point(3, 43);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(110, 34);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "🔄  Làm mới";
            // 
            // btnDeleteSelected
            // 
            this.btnDeleteSelected.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDeleteSelected.Location = new System.Drawing.Point(3, 83);
            this.btnDeleteSelected.Name = "btnDeleteSelected";
            this.btnDeleteSelected.Size = new System.Drawing.Size(110, 34);
            this.btnDeleteSelected.TabIndex = 2;
            this.btnDeleteSelected.Text = "🗑️  Xóa chọn";
            // 
            // AddPaleet
            // 
            this.ClientSize = new System.Drawing.Size(1200, 720);
            this.Controls.Add(this.dataPanel);
            this.Controls.Add(this.footerPanel);
            this.Controls.Add(this.topPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddPaleet";
            this.Text = "Đọc dữ liệu";
            this.topPanel.ResumeLayout(false);
            this.enterPanel.ResumeLayout(false);
            this.tableInput.ResumeLayout(false);
            this.pnlPallet.ResumeLayout(false);
            this.pnlPallet.PerformLayout();
            this.pnlBox.ResumeLayout(false);
            this.pnlBox.PerformLayout();
            this.savePanel.ResumeLayout(false);
            this.pnlSaveInner.ResumeLayout(false);
            this.pnlSaveInner.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSave)).EndInit();
            this.dataPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataTaoFile)).EndInit();
            this.footerPanel.ResumeLayout(false);
            this.footerPanel.PerformLayout();
            this.panelStats.ResumeLayout(false);
            this.panelStats.PerformLayout();
            this.panelActions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Panel enterPanel;
        private System.Windows.Forms.TableLayoutPanel tableInput;
        private System.Windows.Forms.Panel pnlPallet;
        private System.Windows.Forms.Label lblPallet;
        private System.Windows.Forms.TextBox txtPallet;
        private System.Windows.Forms.Button btnCheckPallet;
        private System.Windows.Forms.Panel pnlBox;
        private System.Windows.Forms.Label lblBox;
        private System.Windows.Forms.TextBox txtBox;
        private System.Windows.Forms.Button btnCheckBox;
        private System.Windows.Forms.Panel savePanel;
        private System.Windows.Forms.Panel pnlSaveInner;
        private System.Windows.Forms.PictureBox picSave;
        private System.Windows.Forms.Label lblSave;
        private System.Windows.Forms.Button btnSaveNow;
        private System.Windows.Forms.Panel separator;
        private System.Windows.Forms.Panel dataPanel;
        private System.Windows.Forms.DataGridView DataTaoFile;
        private System.Windows.Forms.Panel footerPanel;
        private System.Windows.Forms.FlowLayoutPanel panelStats;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblSuccess;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.FlowLayoutPanel panelActions;
        private System.Windows.Forms.Button btnDeleteSelected;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPallet;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNote;
    }
}
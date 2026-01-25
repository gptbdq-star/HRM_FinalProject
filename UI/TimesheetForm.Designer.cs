namespace UI
{
    partial class TimesheetForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblEmpId;
        private System.Windows.Forms.TextBox txtEmployeeId;
        private System.Windows.Forms.Button btnCheckIn;
        private System.Windows.Forms.Button btnCheckOut;
        private System.Windows.Forms.DataGridView dgvHistory;
        private System.Windows.Forms.GroupBox grpAction;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblEmpId = new System.Windows.Forms.Label();
            this.txtEmployeeId = new System.Windows.Forms.TextBox();
            this.btnCheckIn = new System.Windows.Forms.Button();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.dgvHistory = new System.Windows.Forms.DataGridView();
            this.grpAction = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.grpAction.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpAction
            // 
            this.grpAction.Controls.Add(this.btnCheckOut);
            this.grpAction.Controls.Add(this.btnCheckIn);
            this.grpAction.Controls.Add(this.txtEmployeeId);
            this.grpAction.Controls.Add(this.lblEmpId);
            this.grpAction.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpAction.Location = new System.Drawing.Point(0, 0);
            this.grpAction.Name = "grpAction";
            this.grpAction.Size = new System.Drawing.Size(800, 80);
            this.grpAction.TabIndex = 0;
            this.grpAction.TabStop = false;
            this.grpAction.Text = "Thao tác chấm công";
            // 
            // lblEmpId
            // 
            this.lblEmpId.AutoSize = true;
            this.lblEmpId.Location = new System.Drawing.Point(20, 35);
            this.lblEmpId.Name = "lblEmpId";
            this.lblEmpId.Size = new System.Drawing.Size(126, 15);
            this.lblEmpId.TabIndex = 0;
            this.lblEmpId.Text = "Nhập ID nhân viên:";
            // 
            // txtEmployeeId
            // 
            this.txtEmployeeId.Location = new System.Drawing.Point(150, 32);
            this.txtEmployeeId.Name = "txtEmployeeId";
            this.txtEmployeeId.Size = new System.Drawing.Size(150, 23);
            this.txtEmployeeId.TabIndex = 1;
            // 
            // btnCheckIn
            // 
            this.btnCheckIn.BackColor = System.Drawing.Color.LightGreen;
            this.btnCheckIn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCheckIn.Location = new System.Drawing.Point(320, 27);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(100, 30);
            this.btnCheckIn.TabIndex = 2;
            this.btnCheckIn.Text = "CHECK IN";
            this.btnCheckIn.UseVisualStyleBackColor = false;
            this.btnCheckIn.Click += new System.EventHandler(this.btnCheckIn_Click);
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.BackColor = System.Drawing.Color.LightSalmon;
            this.btnCheckOut.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCheckOut.Location = new System.Drawing.Point(430, 27);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(100, 30);
            this.btnCheckOut.TabIndex = 3;
            this.btnCheckOut.Text = "CHECK OUT";
            this.btnCheckOut.UseVisualStyleBackColor = false;
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // dgvHistory
            // 
            this.dgvHistory.AllowUserToAddRows = false;
            this.dgvHistory.AllowUserToDeleteRows = false;
            this.dgvHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHistory.Location = new System.Drawing.Point(0, 80);
            this.dgvHistory.Name = "dgvHistory";
            this.dgvHistory.ReadOnly = true;
            this.dgvHistory.RowHeadersVisible = false;
            this.dgvHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistory.Size = new System.Drawing.Size(800, 370);
            this.dgvHistory.TabIndex = 1;
            // 
            // TimesheetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvHistory);
            this.Controls.Add(this.grpAction);
            this.Name = "TimesheetForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý Chấm công";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.grpAction.ResumeLayout(false);
            this.grpAction.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
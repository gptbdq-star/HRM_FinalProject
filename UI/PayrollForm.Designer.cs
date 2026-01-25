namespace UI
{
    partial class PayrollForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.NumericUpDown numMonth;
        private System.Windows.Forms.NumericUpDown numYear;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.DataGridView dgvPayroll;
        private System.Windows.Forms.GroupBox grpAction;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblMonth = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.numMonth = new System.Windows.Forms.NumericUpDown();
            this.numYear = new System.Windows.Forms.NumericUpDown();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.dgvPayroll = new System.Windows.Forms.DataGridView();
            this.grpAction = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.numMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayroll)).BeginInit();
            this.grpAction.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpAction
            // 
            this.grpAction.Controls.Add(this.btnView);
            this.grpAction.Controls.Add(this.btnCalculate);
            this.grpAction.Controls.Add(this.numYear);
            this.grpAction.Controls.Add(this.numMonth);
            this.grpAction.Controls.Add(this.lblYear);
            this.grpAction.Controls.Add(this.lblMonth);
            this.grpAction.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpAction.Location = new System.Drawing.Point(0, 0);
            this.grpAction.Name = "grpAction";
            this.grpAction.Size = new System.Drawing.Size(800, 80);
            this.grpAction.TabIndex = 0;
            this.grpAction.TabStop = false;
            this.grpAction.Text = "Kỳ lương";
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Location = new System.Drawing.Point(20, 30);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(40, 15);
            this.lblMonth.TabIndex = 0;
            this.lblMonth.Text = "Tháng";
            // 
            // numMonth
            // 
            this.numMonth.Location = new System.Drawing.Point(70, 28);
            this.numMonth.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            this.numMonth.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numMonth.Name = "numMonth";
            this.numMonth.Size = new System.Drawing.Size(50, 23);
            this.numMonth.TabIndex = 1;
            this.numMonth.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(140, 30);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(33, 15);
            this.lblYear.TabIndex = 2;
            this.lblYear.Text = "Năm";
            // 
            // numYear
            // 
            this.numYear.Location = new System.Drawing.Point(180, 28);
            this.numYear.Maximum = new decimal(new int[] { 2030, 0, 0, 0 });
            this.numYear.Minimum = new decimal(new int[] { 2020, 0, 0, 0 });
            this.numYear.Name = "numYear";
            this.numYear.Size = new System.Drawing.Size(70, 23);
            this.numYear.TabIndex = 3;
            this.numYear.Value = new decimal(new int[] { 2026, 0, 0, 0 });
            // 
            // btnCalculate
            // 
            this.btnCalculate.BackColor = System.Drawing.Color.Gold;
            this.btnCalculate.Location = new System.Drawing.Point(280, 22);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(120, 35);
            this.btnCalculate.TabIndex = 4;
            this.btnCalculate.Text = "TÍNH LƯƠNG";
            this.btnCalculate.UseVisualStyleBackColor = false;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(410, 22);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(100, 35);
            this.btnView.TabIndex = 5;
            this.btnView.Text = "Xem bảng lương";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // dgvPayroll
            // 
            this.dgvPayroll.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPayroll.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPayroll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPayroll.Location = new System.Drawing.Point(0, 80);
            this.dgvPayroll.Name = "dgvPayroll";
            this.dgvPayroll.ReadOnly = true;
            this.dgvPayroll.RowHeadersVisible = false;
            this.dgvPayroll.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPayroll.Size = new System.Drawing.Size(800, 370);
            this.dgvPayroll.TabIndex = 1;
            // 
            // PayrollForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvPayroll);
            this.Controls.Add(this.grpAction);
            this.Name = "PayrollForm";
            this.Text = "Quản lý Lương";
            ((System.ComponentModel.ISupportInitialize)(this.numMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayroll)).EndInit();
            this.grpAction.ResumeLayout(false);
            this.grpAction.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
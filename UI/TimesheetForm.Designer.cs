namespace UI
{
    partial class TimesheetForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.ComboBox cboEmployee;
        private System.Windows.Forms.DateTimePicker dtpMonth;
        private System.Windows.Forms.Button btnCheckIn;
        private System.Windows.Forms.Button btnCheckOut;

        private System.Windows.Forms.DataGridView dgvCalendar;
        private System.Windows.Forms.DataGridView dgvDetail;

        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Button btnStatistic;
        private System.Windows.Forms.DataGridView dgvStatistic;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.cboEmployee = new System.Windows.Forms.ComboBox();
            this.dtpMonth = new System.Windows.Forms.DateTimePicker();
            this.btnCheckIn = new System.Windows.Forms.Button();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.dgvCalendar = new System.Windows.Forms.DataGridView();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.lblMonth = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvCalendar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();

            // lblEmployee
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.Location = new System.Drawing.Point(20, 15);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(96, 15);
            this.lblEmployee.Text = "Nhân viên:";

            // cboEmployee
            this.cboEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmployee.Location = new System.Drawing.Point(120, 12);
            this.cboEmployee.Size = new System.Drawing.Size(220, 23);
            this.cboEmployee.SelectedIndexChanged += new System.EventHandler(this.cboEmployee_SelectedIndexChanged);

            // lblMonth
            this.lblMonth.AutoSize = true;
            this.lblMonth.Location = new System.Drawing.Point(360, 15);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(44, 15);
            this.lblMonth.Text = "Tháng:";

            // dtpMonth
            this.dtpMonth.CustomFormat = "MM/yyyy";
            this.dtpMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMonth.Location = new System.Drawing.Point(410, 12);
            this.dtpMonth.ShowUpDown = true;
            this.dtpMonth.Size = new System.Drawing.Size(100, 23);
            this.dtpMonth.ValueChanged += new System.EventHandler(this.dtpMonth_ValueChanged);

            // btnCheckIn
            this.btnCheckIn.BackColor = System.Drawing.Color.LightGreen;
            this.btnCheckIn.Location = new System.Drawing.Point(540, 10);
            this.btnCheckIn.Size = new System.Drawing.Size(90, 28);
            this.btnCheckIn.Text = "Check In";
            this.btnCheckIn.UseVisualStyleBackColor = false;
            this.btnCheckIn.Click += new System.EventHandler(this.btnCheckIn_Click);

            // btnCheckOut
            this.btnCheckOut.BackColor = System.Drawing.Color.LightSalmon;
            this.btnCheckOut.Location = new System.Drawing.Point(640, 10);
            this.btnCheckOut.Size = new System.Drawing.Size(90, 28);
            this.btnCheckOut.Text = "Check Out";
            this.btnCheckOut.UseVisualStyleBackColor = false;
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);

            // dgvCalendar
            this.dgvCalendar.AllowUserToAddRows = false;
            this.dgvCalendar.AllowUserToDeleteRows = false;
            this.dgvCalendar.ReadOnly = true;
            this.dgvCalendar.RowHeadersVisible = false;
            this.dgvCalendar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvCalendar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCalendar.Location = new System.Drawing.Point(20, 50);
            this.dgvCalendar.Size = new System.Drawing.Size(740, 300);
            this.dgvCalendar.MultiSelect = false;

            // dgvDetail
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToDeleteRows = false;
            this.dgvDetail.ReadOnly = true;
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetail.Location = new System.Drawing.Point(20, 360);
            this.dgvDetail.Size = new System.Drawing.Size(740, 150);
            // dtpFrom
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(20, 360);
            this.dtpFrom.Size = new System.Drawing.Size(120, 23);

            // dtpTo
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(150, 360);
            this.dtpTo.Size = new System.Drawing.Size(120, 23);

            // btnStatistic
            this.btnStatistic = new System.Windows.Forms.Button();
            this.btnStatistic.Text = "Thống kê đi muộn / về sớm";
            this.btnStatistic.Location = new System.Drawing.Point(290, 358);
            this.btnStatistic.Size = new System.Drawing.Size(220, 27);
            this.btnStatistic.Click += new System.EventHandler(this.btnStatistic_Click);

            // dgvStatistic
            this.dgvStatistic = new System.Windows.Forms.DataGridView();
            this.dgvStatistic.Location = new System.Drawing.Point(20, 395);
            this.dgvStatistic.Size = new System.Drawing.Size(740, 140);
            this.dgvStatistic.ReadOnly = true;
            this.dgvStatistic.AllowUserToAddRows = false;
            this.dgvStatistic.AllowUserToDeleteRows = false;
            this.dgvStatistic.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStatistic.RowHeadersVisible = false;

            // add controls
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.btnStatistic);
            this.Controls.Add(this.dgvStatistic);


            // TimesheetForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 530);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.dgvCalendar);
            this.Controls.Add(this.btnCheckOut);
            this.Controls.Add(this.btnCheckIn);
            this.Controls.Add(this.dtpMonth);
            this.Controls.Add(this.lblMonth);
            this.Controls.Add(this.cboEmployee);
            this.Controls.Add(this.lblEmployee);
            this.Name = "TimesheetForm";
            this.Text = "Chấm công";

            ((System.ComponentModel.ISupportInitialize)(this.dgvCalendar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

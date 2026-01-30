namespace UI
{
    partial class TimesheetForm
    {
        private System.ComponentModel.IContainer components = null;

        private ComboBox cboEmployee;
        private DateTimePicker dtpMonth;
        private Button btnCheckIn;
        private Button btnCheckOut;

        private DataGridView dgvCalendar;
        private DataGridView dgvStatistic;

        private Label lblEmployee;
        private Label lblMonth;
        private DateTimePicker dtpFrom;
        private DateTimePicker dtpTo;
        private Button btnStatistic;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            cboEmployee = new ComboBox();
            dtpMonth = new DateTimePicker();
            btnCheckIn = new Button();
            btnCheckOut = new Button();
            dgvCalendar = new DataGridView();
            dgvStatistic = new DataGridView();
            lblEmployee = new Label();
            lblMonth = new Label();
            dtpFrom = new DateTimePicker();
            dtpTo = new DateTimePicker();
            btnStatistic = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCalendar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvStatistic).BeginInit();
            SuspendLayout();
            // 
            // cboEmployee
            // 
            cboEmployee.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEmployee.Location = new Point(120, 12);
            cboEmployee.Name = "cboEmployee";
            cboEmployee.Size = new Size(202, 23);
            cboEmployee.TabIndex = 1;
            cboEmployee.SelectedIndexChanged += cboEmployee_SelectedIndexChanged;
            // 
            // dtpMonth
            // 
            dtpMonth.CustomFormat = "MM/yyyy";
            dtpMonth.Format = DateTimePickerFormat.Custom;
            dtpMonth.Location = new Point(385, 12);
            dtpMonth.Name = "dtpMonth";
            dtpMonth.ShowUpDown = true;
            dtpMonth.Size = new Size(104, 23);
            dtpMonth.TabIndex = 3;
            dtpMonth.ValueChanged += dtpMonth_ValueChanged;
            // 
            // btnCheckIn
            // 
            btnCheckIn.BackColor = Color.LightGreen;
            btnCheckIn.Location = new Point(540, 10);
            btnCheckIn.Name = "btnCheckIn";
            btnCheckIn.Size = new Size(75, 23);
            btnCheckIn.TabIndex = 4;
            btnCheckIn.Text = "Check In";
            btnCheckIn.UseVisualStyleBackColor = false;
            btnCheckIn.Click += btnCheckIn_Click;
            // 
            // btnCheckOut
            // 
            btnCheckOut.BackColor = Color.LightSalmon;
            btnCheckOut.Location = new Point(640, 10);
            btnCheckOut.Name = "btnCheckOut";
            btnCheckOut.Size = new Size(75, 23);
            btnCheckOut.TabIndex = 5;
            btnCheckOut.Text = "Check Out";
            btnCheckOut.UseVisualStyleBackColor = false;
            btnCheckOut.Click += btnCheckOut_Click;
            // 
            // dgvCalendar
            // 
            dgvCalendar.Location = new Point(20, 50);
            dgvCalendar.Name = "dgvCalendar";
            dgvCalendar.ReadOnly = true;
            dgvCalendar.RowHeadersVisible = false;
            dgvCalendar.Size = new Size(740, 280);
            dgvCalendar.TabIndex = 6;
            // 
            // dgvStatistic
            // 
            dgvStatistic.Location = new Point(20, 380);
            dgvStatistic.Name = "dgvStatistic";
            dgvStatistic.ReadOnly = true;
            dgvStatistic.Size = new Size(740, 150);
            dgvStatistic.TabIndex = 11;
            // 
            // lblEmployee
            // 
            lblEmployee.Location = new Point(20, 15);
            lblEmployee.Name = "lblEmployee";
            lblEmployee.Size = new Size(100, 23);
            lblEmployee.TabIndex = 0;
            lblEmployee.Text = "Nhân viên:";
            // 
            // lblMonth
            // 
            lblMonth.Location = new Point(328, 14);
            lblMonth.Name = "lblMonth";
            lblMonth.Size = new Size(51, 23);
            lblMonth.TabIndex = 2;
            lblMonth.Text = "Tháng:";
            // 
            // dtpFrom
            // 
            dtpFrom.Location = new Point(20, 340);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(200, 23);
            dtpFrom.TabIndex = 7;
            // 
            // dtpTo
            // 
            dtpTo.Location = new Point(160, 340);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(200, 23);
            dtpTo.TabIndex = 8;
            // 
            // btnStatistic
            // 
            btnStatistic.Location = new Point(366, 336);
            btnStatistic.Name = "btnStatistic";
            btnStatistic.Size = new Size(240, 28);
            btnStatistic.TabIndex = 9;
            btnStatistic.Text = "Thống kê đi muộn / về sớm";
            btnStatistic.Click += btnStatistic_Click;
            // 
            // TimesheetForm
            // 
            ClientSize = new Size(800, 720);
            Controls.Add(lblEmployee);
            Controls.Add(cboEmployee);
            Controls.Add(lblMonth);
            Controls.Add(dtpMonth);
            Controls.Add(btnCheckIn);
            Controls.Add(btnCheckOut);
            Controls.Add(dgvCalendar);
            Controls.Add(dtpFrom);
            Controls.Add(dtpTo);
            Controls.Add(btnStatistic);
            Controls.Add(dgvStatistic);
            Name = "TimesheetForm";
            Text = "Chấm công";
            ((System.ComponentModel.ISupportInitialize)dgvCalendar).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvStatistic).EndInit();
            ResumeLayout(false);
        }
    }
}

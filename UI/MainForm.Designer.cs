namespace UI
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuSystem;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.ToolStripMenuItem menuCategory;
        private System.Windows.Forms.ToolStripMenuItem menuDepartment;
        private System.Windows.Forms.ToolStripMenuItem menuPosition;
        private System.Windows.Forms.ToolStripMenuItem menuEmployee;
        // Thêm 2 menu mới
        private System.Windows.Forms.ToolStripMenuItem menuTimesheet;
        private System.Windows.Forms.ToolStripMenuItem menuPayroll;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDepartment = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPosition = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTimesheet = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPayroll = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            // --- BẮT ĐẦU CODE THÊM ---
            System.Windows.Forms.GroupBox grpStats = new System.Windows.Forms.GroupBox();
            System.Windows.Forms.Label lblStatEmployee = new System.Windows.Forms.Label();
            System.Windows.Forms.Label lblStatDept = new System.Windows.Forms.Label();
            System.Windows.Forms.Label lblStatSalary = new System.Windows.Forms.Label();

            grpStats.Location = new System.Drawing.Point(12, 40);
            grpStats.Size = new System.Drawing.Size(760, 100);
            grpStats.Text = "Thống kê tổng quan";
            grpStats.Name = "grpStats";

            lblStatEmployee.Location = new System.Drawing.Point(20, 30);
            lblStatEmployee.Size = new System.Drawing.Size(200, 50);
            lblStatEmployee.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            lblStatEmployee.ForeColor = System.Drawing.Color.Blue;
            lblStatEmployee.Name = "lblStatEmployee";
            lblStatEmployee.Text = "Nhân viên: ...";

            lblStatDept.Location = new System.Drawing.Point(250, 30);
            lblStatDept.Size = new System.Drawing.Size(200, 50);
            lblStatDept.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            lblStatDept.ForeColor = System.Drawing.Color.Green;
            lblStatDept.Name = "lblStatDept";
            lblStatDept.Text = "Phòng ban: ...";

            lblStatSalary.Location = new System.Drawing.Point(500, 30);
            lblStatSalary.Size = new System.Drawing.Size(250, 50);
            lblStatSalary.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            lblStatSalary.ForeColor = System.Drawing.Color.Red;
            lblStatSalary.Name = "lblStatSalary";
            lblStatSalary.Text = "Lương tháng này: ...";

            grpStats.Controls.Add(lblStatEmployee);
            grpStats.Controls.Add(lblStatDept);
            grpStats.Controls.Add(lblStatSalary);
            this.Controls.Add(grpStats);
            // --- KẾT THÚC CODE THÊM ---
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSystem,
            this.menuCategory,
            this.menuEmployee,
            this.menuTimesheet,
            this.menuPayroll});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuSystem
            // 
            this.menuSystem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuExit});
            this.menuSystem.Name = "menuSystem";
            this.menuSystem.Size = new System.Drawing.Size(69, 20);
            this.menuSystem.Text = "Hệ thống";
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(104, 22);
            this.menuExit.Text = "Thoát";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // menuCategory
            // 
            this.menuCategory.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDepartment,
            this.menuPosition});
            this.menuCategory.Name = "menuCategory";
            this.menuCategory.Size = new System.Drawing.Size(74, 20);
            this.menuCategory.Text = "Danh mục";
            // 
            // menuDepartment
            // 
            this.menuDepartment.Name = "menuDepartment";
            this.menuDepartment.Size = new System.Drawing.Size(134, 22);
            this.menuDepartment.Text = "Phòng ban";
            this.menuDepartment.Click += new System.EventHandler(this.menuDepartment_Click);
            // 
            // menuPosition
            // 
            this.menuPosition.Name = "menuPosition";
            this.menuPosition.Size = new System.Drawing.Size(134, 22);
            this.menuPosition.Text = "Chức vụ";
            this.menuPosition.Click += new System.EventHandler(this.menuPosition_Click);
            // 
            // menuEmployee
            // 
            this.menuEmployee.Name = "menuEmployee";
            this.menuEmployee.Size = new System.Drawing.Size(63, 20);
            this.menuEmployee.Text = "Nhân sự";
            this.menuEmployee.Click += new System.EventHandler(this.menuEmployee_Click);
            // 
            // menuTimesheet
            // 
            this.menuTimesheet.Name = "menuTimesheet";
            this.menuTimesheet.Size = new System.Drawing.Size(81, 20);
            this.menuTimesheet.Text = "Chấm công";
            this.menuTimesheet.Click += new System.EventHandler(this.menuTimesheet_Click);
            // 
            // menuPayroll
            // 
            this.menuPayroll.Name = "menuPayroll";
            this.menuPayroll.Size = new System.Drawing.Size(53, 20);
            this.menuPayroll.Text = "Lương";
            this.menuPayroll.Click += new System.EventHandler(this.menuPayroll_Click);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "HRM System";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
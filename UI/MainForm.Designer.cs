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
        private System.Windows.Forms.ToolStripMenuItem menuLaborContract;
        private System.Windows.Forms.ToolStripMenuItem menuTimesheet;
        private System.Windows.Forms.ToolStripMenuItem menuPayroll;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
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
            this.menuLaborContract = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTimesheet = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPayroll = new System.Windows.Forms.ToolStripMenuItem();

            this.menuStrip1.SuspendLayout();

            // Dashboard GroupBox
            System.Windows.Forms.GroupBox grpStats = new System.Windows.Forms.GroupBox();
            System.Windows.Forms.Label lblStatEmployee = new System.Windows.Forms.Label();
            System.Windows.Forms.Label lblStatDept = new System.Windows.Forms.Label();
            System.Windows.Forms.Label lblStatSalary = new System.Windows.Forms.Label();

            grpStats.Name = "grpStats";
            grpStats.Text = "Bảng điều khiển";
            grpStats.Size = new System.Drawing.Size(776, 120);
            grpStats.Location = new System.Drawing.Point(12, 40);
            grpStats.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            lblStatEmployee.Name = "lblStatEmployee";
            lblStatEmployee.Location = new System.Drawing.Point(20, 40);
            lblStatEmployee.Size = new System.Drawing.Size(200, 40);
            lblStatEmployee.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);

            lblStatDept.Name = "lblStatDept";
            lblStatDept.Location = new System.Drawing.Point(250, 40);
            lblStatDept.Size = new System.Drawing.Size(200, 40);
            lblStatDept.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);

            lblStatSalary.Name = "lblStatSalary";
            lblStatSalary.Location = new System.Drawing.Point(480, 40);
            lblStatSalary.Size = new System.Drawing.Size(280, 40);
            lblStatSalary.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);

            grpStats.Controls.Add(lblStatEmployee);
            grpStats.Controls.Add(lblStatDept);
            grpStats.Controls.Add(lblStatSalary);

            // MenuStrip
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.menuSystem, this.menuCategory, this.menuEmployee, this.menuLaborContract, this.menuTimesheet, this.menuPayroll
            });
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);

            // Cấu hình các mục Menu
            this.menuSystem.Text = "Hệ thống";
            this.menuSystem.DropDownItems.Add(this.menuExit);
            this.menuExit.Text = "Thoát";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);

            this.menuCategory.Text = "Danh mục";
            this.menuCategory.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.menuDepartment, this.menuPosition });
            this.menuDepartment.Text = "Phòng ban";
            this.menuDepartment.Click += new System.EventHandler(this.menuDepartment_Click);
            this.menuPosition.Text = "Chức vụ";
            this.menuPosition.Click += new System.EventHandler(this.menuPosition_Click);

            this.menuEmployee.Text = "Nhân sự";
            this.menuEmployee.Click += new System.EventHandler(this.menuEmployee_Click);

            this.menuLaborContract.Text = "Hợp đồng";
            this.menuLaborContract.Click += new System.EventHandler(this.menuLaborContract_Click);

            this.menuTimesheet.Text = "Chấm công";
            this.menuTimesheet.Click += new System.EventHandler(this.menuTimesheet_Click);

            this.menuPayroll.Text = "Lương";
            this.menuPayroll.Click += new System.EventHandler(this.menuPayroll_Click);

            // MainForm
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(grpStats);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Text = "Hệ thống quản trị nhân sự - HRM";
            this.IsMdiContainer = true;

            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
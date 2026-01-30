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

        private System.Windows.Forms.ToolStripMenuItem menuHuman;
        private System.Windows.Forms.ToolStripMenuItem menuEmployee;
        private System.Windows.Forms.ToolStripMenuItem menuLaborContract;
        private System.Windows.Forms.ToolStripMenuItem menuRewardDiscipline;

        private System.Windows.Forms.ToolStripMenuItem menuTimesheet;
        private System.Windows.Forms.ToolStripMenuItem menuPayroll;

        private System.Windows.Forms.ToolStripMenuItem menuUser;

        private System.Windows.Forms.GroupBox grpStats;
        private System.Windows.Forms.Label lblStatEmployee;
        private System.Windows.Forms.Label lblStatDept;
        private System.Windows.Forms.Label lblStatSalary;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            menuStrip1 = new System.Windows.Forms.MenuStrip();

            menuSystem = new System.Windows.Forms.ToolStripMenuItem();
            menuExit = new System.Windows.Forms.ToolStripMenuItem();

            menuCategory = new System.Windows.Forms.ToolStripMenuItem();
            menuDepartment = new System.Windows.Forms.ToolStripMenuItem();
            menuPosition = new System.Windows.Forms.ToolStripMenuItem();

            menuHuman = new System.Windows.Forms.ToolStripMenuItem();
            menuEmployee = new System.Windows.Forms.ToolStripMenuItem();
            menuLaborContract = new System.Windows.Forms.ToolStripMenuItem();
            menuRewardDiscipline = new System.Windows.Forms.ToolStripMenuItem();

            menuTimesheet = new System.Windows.Forms.ToolStripMenuItem();
            menuPayroll = new System.Windows.Forms.ToolStripMenuItem();
            menuUser = new System.Windows.Forms.ToolStripMenuItem();

            grpStats = new System.Windows.Forms.GroupBox();
            lblStatEmployee = new System.Windows.Forms.Label();
            lblStatDept = new System.Windows.Forms.Label();
            lblStatSalary = new System.Windows.Forms.Label();

            menuStrip1.SuspendLayout();

            grpStats.Name = "grpStats";
            grpStats.Text = "Bảng điều khiển";
            grpStats.SetBounds(12, 40, 776, 120);

            lblStatEmployee.Name = "lblStatEmployee";
            lblStatEmployee.SetBounds(20, 40, 220, 40);

            lblStatDept.Name = "lblStatDept";
            lblStatDept.SetBounds(270, 40, 220, 40);

            lblStatSalary.Name = "lblStatSalary";
            lblStatSalary.SetBounds(520, 40, 240, 40);

            grpStats.Controls.Add(lblStatEmployee);
            grpStats.Controls.Add(lblStatDept);
            grpStats.Controls.Add(lblStatSalary);

            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                menuSystem,
                menuCategory,
                menuHuman,
                menuTimesheet,
                menuPayroll,
                menuUser
            });

            menuSystem.Text = "Hệ thống";
            menuSystem.DropDownItems.Add(menuExit);
            menuExit.Text = "Thoát";
            menuExit.Click += menuExit_Click;

            menuCategory.Text = "Danh mục";
            menuCategory.DropDownItems.AddRange(new[] { menuDepartment, menuPosition });
            menuDepartment.Text = "Phòng ban";
            menuDepartment.Click += menuDepartment_Click;
            menuPosition.Text = "Chức vụ";
            menuPosition.Click += menuPosition_Click;

            menuHuman.Text = "Nhân sự";
            menuHuman.DropDownItems.AddRange(new[]
            {
                menuEmployee,
                menuLaborContract,
                menuRewardDiscipline
            });

            menuEmployee.Text = "Danh sách nhân viên";
            menuEmployee.Click += menuEmployee_Click;

            menuLaborContract.Text = "Hợp đồng lao động";
            menuLaborContract.Click += menuLaborContract_Click;

            menuRewardDiscipline.Text = "Thưởng / Kỷ luật";
            menuRewardDiscipline.Click += menuRewardDiscipline_Click;

            menuTimesheet.Text = "Chấm công";
            menuTimesheet.Click += menuTimesheet_Click;

            menuPayroll.Text = "Tiền lương";
            menuPayroll.Click += menuPayroll_Click;

            menuUser.Text = "Quản lý tài khoản";
            menuUser.Click += menuUser_Click;

            Controls.Add(grpStats);
            Controls.Add(menuStrip1);

            MainMenuStrip = menuStrip1;
            Text = "Hệ thống quản trị nhân sự - HRM";
            ClientSize = new System.Drawing.Size(800, 500);
            IsMdiContainer = true;

            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
        }
    }
}

namespace UI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDepartment = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPosition = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHuman = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLaborContract = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRewardDiscipline = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTimesheet = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPayroll = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUser = new System.Windows.Forms.ToolStripMenuItem();
            this.grpStats = new System.Windows.Forms.GroupBox();
            this.lblStatSalary = new System.Windows.Forms.Label();
            this.lblStatDept = new System.Windows.Forms.Label();
            this.lblStatEmployee = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.grpStats.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSystem,
            this.menuCategory,
            this.menuHuman,
            this.menuTimesheet,
            this.menuPayroll,
            this.menuUser});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
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
            this.menuExit.Size = new System.Drawing.Size(105, 22);
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
            // menuHuman
            // 
            this.menuHuman.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuEmployee,
            this.menuLaborContract,
            this.menuRewardDiscipline});
            this.menuHuman.Name = "menuHuman";
            this.menuHuman.Size = new System.Drawing.Size(60, 20);
            this.menuHuman.Text = "Nhân sự";
            // 
            // menuEmployee
            // 
            this.menuEmployee.Name = "menuEmployee";
            this.menuEmployee.Size = new System.Drawing.Size(189, 22);
            this.menuEmployee.Text = "Danh sách nhân viên";
            this.menuEmployee.Click += new System.EventHandler(this.menuEmployee_Click);
            // 
            // menuLaborContract
            // 
            this.menuLaborContract.Name = "menuLaborContract";
            this.menuLaborContract.Size = new System.Drawing.Size(189, 22);
            this.menuLaborContract.Text = "Hợp đồng lao động";
            this.menuLaborContract.Click += new System.EventHandler(this.menuLaborContract_Click);
            // 
            // menuRewardDiscipline
            // 
            this.menuRewardDiscipline.Name = "menuRewardDiscipline";
            this.menuRewardDiscipline.Size = new System.Drawing.Size(189, 22);
            this.menuRewardDiscipline.Text = "Thưởng / Kỷ luật";
            this.menuRewardDiscipline.Click += new System.EventHandler(this.menuRewardDiscipline_Click);
            // 
            // menuTimesheet
            // 
            this.menuTimesheet.Name = "menuTimesheet";
            this.menuTimesheet.Size = new System.Drawing.Size(79, 20);
            this.menuTimesheet.Text = "Chấm công";
            this.menuTimesheet.Click += new System.EventHandler(this.menuTimesheet_Click);
            // 
            // menuPayroll
            // 
            this.menuPayroll.Name = "menuPayroll";
            this.menuPayroll.Size = new System.Drawing.Size(73, 20);
            this.menuPayroll.Text = "Tiền lương";
            this.menuPayroll.Click += new System.EventHandler(this.menuPayroll_Click);
            // 
            // menuUser
            // 
            this.menuUser.Name = "menuUser";
            this.menuUser.Size = new System.Drawing.Size(122, 20);
            this.menuUser.Text = "Quản lý tài khoản";
            this.menuUser.Click += new System.EventHandler(this.menuUser_Click);
            // 
            // grpStats
            // 
            this.grpStats.Controls.Add(this.lblStatSalary);
            this.grpStats.Controls.Add(this.lblStatDept);
            this.grpStats.Controls.Add(this.lblStatEmployee);
            this.grpStats.Location = new System.Drawing.Point(12, 40);
            this.grpStats.Name = "grpStats";
            this.grpStats.Size = new System.Drawing.Size(760, 100);
            this.grpStats.TabIndex = 2;
            this.grpStats.TabStop = false;
            this.grpStats.Text = "Bảng điều khiển";
            // 
            // lblStatSalary
            // 
            this.lblStatSalary.AutoSize = true;
            this.lblStatSalary.Location = new System.Drawing.Point(500, 40);
            this.lblStatSalary.Name = "lblStatSalary";
            this.lblStatSalary.Size = new System.Drawing.Size(89, 15);
            this.lblStatSalary.TabIndex = 2;
            this.lblStatSalary.Text = "💰 Lương: 0 đ";
            // 
            // lblStatDept
            // 
            this.lblStatDept.AutoSize = true;
            this.lblStatDept.Location = new System.Drawing.Point(260, 40);
            this.lblStatDept.Name = "lblStatDept";
            this.lblStatDept.Size = new System.Drawing.Size(102, 15);
            this.lblStatDept.TabIndex = 1;
            this.lblStatDept.Text = "🏢 Phòng ban: 0";
            // 
            // lblStatEmployee
            // 
            this.lblStatEmployee.AutoSize = true;
            this.lblStatEmployee.Location = new System.Drawing.Point(20, 40);
            this.lblStatEmployee.Name = "lblStatEmployee";
            this.lblStatEmployee.Size = new System.Drawing.Size(87, 15);
            this.lblStatEmployee.TabIndex = 0;
            this.lblStatEmployee.Text = "👥 Nhân sự: 0";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.grpStats);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống quản trị nhân sự - HRM";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.grpStats.ResumeLayout(false);
            this.grpStats.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

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
    }
}
using System;
using System.Linq;
using System.Windows.Forms;
using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace UI;

public partial class MainForm : Form
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IUnitOfWork _unitOfWork;

    public MainForm(IServiceProvider serviceProvider, IUnitOfWork unitOfWork)
    {
        _serviceProvider = serviceProvider;
        _unitOfWork = unitOfWork;

        InitializeComponent();
        
        // ✅ GỌI LOAD EVENT
        this.Load += MainForm_Load;
        this.MdiChildActivate += MainForm_MdiChildActivate;
    }

    private void MainForm_Load(object? sender, EventArgs e)
    {
        // ✅ ĐẢM BẢO SESSION ĐÃ READY
        ApplyPermission();
        DebugPermissions();
        LoadDashboardStats();
        
        // ✅ FORCE REFRESH
        this.menuStrip1.Refresh();
    }

    private void ApplyPermission()
    {
        try
        {
            var p = Session.Permissions;
            
            // ✅ LOG RA XEM CÓ PERMISSIONS KHÔNG
            System.Diagnostics.Debug.WriteLine($"[ApplyPermission] Permissions count: {p.Count}");
            System.Diagnostics.Debug.WriteLine($"[ApplyPermission] Permissions: {string.Join(", ", p)}");

            // ===== SET SUB-MENU VISIBILITY =====
            bool hasDept = p.Contains("MENU_DEPARTMENT");
            bool hasPos = p.Contains("MENU_POSITION");
            bool hasEmp = p.Contains("MENU_EMPLOYEE");
            bool hasReward = p.Contains("MENU_REWARD");
            
            menuDepartment.Visible = hasDept;
            menuPosition.Visible = hasPos;
            menuEmployee.Visible = hasEmp;
            menuLaborContract.Visible = hasEmp;
            menuRewardDiscipline.Visible = hasReward;
            
            // ===== SET PARENT MENU VISIBILITY =====
            menuCategory.Visible = hasDept || hasPos;
            menuHuman.Visible = hasEmp || hasReward;
            
            // ===== SET STANDALONE MENU =====
            menuTimesheet.Visible = p.Contains("MENU_TIMESHEET");
            menuPayroll.Visible = p.Contains("MENU_PAYROLL");
            menuUser.Visible = p.Contains("MENU_USER");
            
            // ✅ LOG KẾT QUẢ
            System.Diagnostics.Debug.WriteLine($"[ApplyPermission] menuCategory.Visible = {menuCategory.Visible}");
            System.Diagnostics.Debug.WriteLine($"[ApplyPermission] menuHuman.Visible = {menuHuman.Visible}");
            
            // ✅ FORCE UPDATE UI
            this.menuStrip1.Invalidate();
            this.menuStrip1.Update();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error in ApplyPermission: {ex.Message}\n\n{ex.StackTrace}");
        }
    }

    private void MainForm_MdiChildActivate(object? sender, EventArgs e)
    {
        grpStats.Visible = ActiveMdiChild == null;
        if (grpStats.Visible) LoadDashboardStats();
    }

    private void LoadDashboardStats()
    {
        try
        {
            int empCount = _unitOfWork.Employees.GetAll().Count();
            int deptCount = _unitOfWork.Departments.GetAll().Count();

            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;

            var payslips = _unitOfWork.Payslips.GetAll()
                .Where(x => x.Month == month && x.Year == year);

            decimal totalSalary = payslips.Any()
                ? payslips.Sum(x => x.FinalSalary)
                : 0;

            lblStatEmployee.Text = $"👥 Nhân sự: {empCount}";
            lblStatDept.Text = $"🏢 Phòng ban: {deptCount}";
            lblStatSalary.Text = $"💰 Lương T{month}: {totalSalary:N0} đ";
        }
        catch { }
    }

    private void SwitchForm<T>() where T : Form
    {
        foreach (var child in MdiChildren)
            child.Close();

        var form = (Form)Activator.CreateInstance(typeof(T), ResolveConstructorParams(typeof(T)))!;

        form.MdiParent = this;
        form.Dock = DockStyle.Fill;
        form.FormBorderStyle = FormBorderStyle.None;
        form.Show();
    }

    private object[] ResolveConstructorParams(Type formType)
    {
        var ctor = formType.GetConstructors().First();
        return ctor.GetParameters()
            .Select(p => _serviceProvider.GetRequiredService(p.ParameterType))
            .ToArray();
    }

    private void DebugPermissions()
    {
        try
        {
            var user = Session.CurrentUser;
            var perms = Session.Permissions;

            var debugMsg = $"🔍 DEBUG INFO:\n\n" +
                $"Username: {user?.Username}\n" +
                $"Role: {user?.Role?.Name}\n" +
                $"Permissions count: {perms.Count}\n\n" +
                $"Permissions:\n{string.Join("\n", perms)}\n\n" +
                $"--- MENU VISIBILITY ---\n" +
                $"menuCategory.Visible = {menuCategory.Visible}\n" +
                $"  ├─ menuDepartment.Visible = {menuDepartment.Visible}\n" +
                $"  └─ menuPosition.Visible = {menuPosition.Visible}\n\n" +
                $"menuHuman.Visible = {menuHuman.Visible}\n" +
                $"  ├─ menuEmployee.Visible = {menuEmployee.Visible}\n" +
                $"  ├─ menuLaborContract.Visible = {menuLaborContract.Visible}\n" +
                $"  └─ menuRewardDiscipline.Visible = {menuRewardDiscipline.Visible}\n\n" +
                $"menuTimesheet.Visible = {menuTimesheet.Visible}\n" +
                $"menuPayroll.Visible = {menuPayroll.Visible}\n" +
                $"menuUser.Visible = {menuUser.Visible}\n\n" +
                $"--- IN MENUSTRIP? ---\n" +
                $"Total items: {menuStrip1.Items.Count}\n" +
                $"menuCategory in strip? {menuStrip1.Items.Contains(menuCategory)}\n" +
                $"menuHuman in strip? {menuStrip1.Items.Contains(menuHuman)}";

            MessageBox.Show(debugMsg, "Debug Menu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Debug Error: {ex.Message}\n\n{ex.StackTrace}");
        }

    }
    private void menuLogout_Click(object sender, EventArgs e)
    {
        var confirm = MessageBox.Show(
            "Bạn có chắc chắn muốn đăng xuất?",
            "Đăng xuất",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (confirm != DialogResult.Yes) return;

        this.Close(); // ✅ Program.cs sẽ xử lý phần còn lại
    }


    private void menuChangePassword_Click(object sender, EventArgs e)
    {
        var frm = _serviceProvider.GetRequiredService<ChangePasswordForm>();
        frm.ShowDialog();
    }


    private void menuEmployee_Click(object sender, EventArgs e) => SwitchForm<EmployeeForm>();
    private void menuLaborContract_Click(object sender, EventArgs e) => SwitchForm<LaborContractForm>();
    private void menuRewardDiscipline_Click(object sender, EventArgs e) => SwitchForm<RewardDisciplineForm>();
    private void menuDepartment_Click(object sender, EventArgs e) => SwitchForm<DepartmentForm>();
    private void menuPosition_Click(object sender, EventArgs e) => SwitchForm<PositionForm>();
    private void menuTimesheet_Click(object sender, EventArgs e) => SwitchForm<TimesheetForm>();
    private void menuPayroll_Click(object sender, EventArgs e) => SwitchForm<PayrollForm>();
    private void menuUser_Click(object sender, EventArgs e) => SwitchForm<UserForm>();
    private void menuExit_Click(object sender, EventArgs e) => Close();
}
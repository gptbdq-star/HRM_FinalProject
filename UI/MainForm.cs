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
        MdiChildActivate += MainForm_MdiChildActivate;

        ApplyPermission();
        LoadDashboardStats();
    }

    private void ApplyPermission()
    {
        var p = Session.Permissions;

        menuEmployee.Visible = p.Contains("MENU_EMPLOYEE");
        menuDepartment.Visible = p.Contains("MENU_DEPARTMENT");
        menuPosition.Visible = p.Contains("MENU_POSITION");
        menuTimesheet.Visible = p.Contains("MENU_TIMESHEET");
        menuPayroll.Visible = p.Contains("MENU_PAYROLL");
        menuRewardDiscipline.Visible = p.Contains("MENU_REWARD");
        menuUser.Visible = p.Contains("MENU_USER");

        menuHuman.Visible =
            menuEmployee.Visible ||
            menuRewardDiscipline.Visible;
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

        // ❌ KHÔNG lấy form từ DI nữa
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

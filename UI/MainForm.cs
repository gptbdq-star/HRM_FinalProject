using System;
using System.Linq;
using System.Windows.Forms;
using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Domain.Entities;

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

        // Thiết lập Form cha (MDI)
        this.IsMdiContainer = true;

        // Đăng ký sự kiện ẩn/hiện Dashboard khi mở form con
        this.MdiChildActivate += MainForm_MdiChildActivate;

        LoadDashboardStats();
    }

    private void MainForm_MdiChildActivate(object? sender, EventArgs e)
    {
        if (this.Controls.ContainsKey("grpStats"))
        {
            var grpStats = this.Controls["grpStats"];
            // Nếu có Form con đang mở -> Ẩn Dashboard. Nếu không -> Hiện lại.
            grpStats.Visible = (this.ActiveMdiChild == null);

            if (grpStats.Visible) LoadDashboardStats();
        }
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
            decimal totalSalary = payslips.Any() ? payslips.Sum(x => x.FinalSalary) : 0;

            if (this.Controls.ContainsKey("grpStats"))
            {
                var grp = this.Controls["grpStats"];
                grp.Controls["lblStatEmployee"].Text = $"👥 Nhân sự: {empCount}";
                grp.Controls["lblStatDept"].Text = $"🏢 Phòng ban: {deptCount}";
                grp.Controls["lblStatSalary"].Text = $"💰 Lương T{month}: {totalSalary:N0} đ";
            }
        }
        catch { /* Bỏ qua lỗi khi DB chưa sẵn sàng */ }
    }

    private void SwitchForm<T>() where T : Form
    {
        // Đóng form cũ
        foreach (var child in this.MdiChildren) child.Close();

        // Mở form mới từ DI Container
        var newForm = _serviceProvider.GetRequiredService<T>();
        newForm.MdiParent = this;
        newForm.Dock = DockStyle.Fill;
        newForm.FormBorderStyle = FormBorderStyle.None;
        newForm.Show();
    }

    // --- Sự kiện Menu ---
    private void menuEmployee_Click(object sender, EventArgs e) => SwitchForm<EmployeeForm>();
    private void menuLaborContract_Click(object sender, EventArgs e) => SwitchForm<LaborContractForm>();
    private void menuDepartment_Click(object sender, EventArgs e) => SwitchForm<DepartmentForm>();
    private void menuPosition_Click(object sender, EventArgs e) => SwitchForm<PositionForm>();
    private void menuTimesheet_Click(object sender, EventArgs e) => SwitchForm<TimesheetForm>();
    private void menuPayroll_Click(object sender, EventArgs e) => SwitchForm<PayrollForm>();
    private void menuExit_Click(object sender, EventArgs e) => Close();
}
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

        this.IsMdiContainer = true;

        // --- ĐOẠN MỚI: Đăng ký sự kiện để ẩn/hiện Dashboard ---
        this.MdiChildActivate += MainForm_MdiChildActivate;

        LoadDashboardStats();
    }

    // --- HÀM MỚI: Tự động ẩn hiện Dashboard ---
    private void MainForm_MdiChildActivate(object? sender, EventArgs e)
    {
        // Tìm cái GroupBox thống kê theo tên chúng ta đã đặt
        if (this.Controls.ContainsKey("grpStats"))
        {
            var grpStats = this.Controls["grpStats"];

            if (this.ActiveMdiChild != null)
            {
                // Nếu đang có Form con mở -> Ẩn thống kê đi cho đỡ rối
                grpStats.Visible = false;
            }
            else
            {
                // Nếu không có Form con nào (về trang chủ) -> Hiện thống kê và Load lại số liệu mới
                grpStats.Visible = true;
                LoadDashboardStats(); // Load lại số liệu mới nhất luôn
            }
        }
    }

    private void LoadDashboardStats()
    {
        try
        {
            // Logic lấy số liệu (Giữ nguyên như bạn đã làm)
            int empCount = _unitOfWork.Employees.GetAll().Count();
            int deptCount = _unitOfWork.Departments.GetAll().Count();

            int currentMonth = DateTime.Now.Month;
            int currentYear = DateTime.Now.Year;

            var payslips = _unitOfWork.Payslips.GetAll()
                .Where(x => x.Month == currentMonth && x.Year == currentYear);

            decimal totalSalary = payslips.Sum(x => x.FinalSalary);

            if (this.Controls.ContainsKey("grpStats"))
            {
                var grp = this.Controls["grpStats"];
                // Tìm Label bên trong GroupBox (Sử dụng Find dệ quy hoặc Controls index)
                grp.Controls["lblStatEmployee"].Text = $"👥 Nhân sự: {empCount}";
                grp.Controls["lblStatDept"].Text = $"🏢 Phòng ban: {deptCount}";
                grp.Controls["lblStatSalary"].Text = $"💰 Lương T{currentMonth}: {totalSalary:N0} đ";
            }
        }
        catch (Exception)
        {
            // Bỏ qua lỗi nếu chưa load xong UI
        }
    }

    private void SwitchForm<T>() where T : Form
    {
        // 1. Đóng hết form cũ
        foreach (var child in this.MdiChildren)
        {
            child.Close();
        }

        // 2. Mở form mới
        var newForm = _serviceProvider.GetRequiredService<T>();
        newForm.MdiParent = this;

        // --- QUAN TRỌNG: Dòng này giúp form con lấp đầy form cha, không bị chồng chéo ---
        newForm.Dock = DockStyle.Fill;
        newForm.FormBorderStyle = FormBorderStyle.None; // (Tùy chọn) Bỏ viền để nhìn liền mạch hơn

        newForm.Show();
    }

    // --- CÁC MENU EVENT (Giữ nguyên) ---
    private void menuEmployee_Click(object sender, EventArgs e)
    {
        SwitchForm<EmployeeForm>();
    }

    private void menuDepartment_Click(object sender, EventArgs e)
    {
        SwitchForm<DepartmentForm>();
    }

    private void menuPosition_Click(object sender, EventArgs e)
    {
        SwitchForm<PositionForm>();
    }

    private void menuTimesheet_Click(object sender, EventArgs e)
    {
        SwitchForm<TimesheetForm>();
    }

    private void menuPayroll_Click(object sender, EventArgs e)
    {
        SwitchForm<PayrollForm>();
    }

    private void menuExit_Click(object sender, EventArgs e)
    {
        Close();
    }
}
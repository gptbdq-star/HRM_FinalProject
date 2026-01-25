using Infrastructure.Data;
using Infrastructure.Repositories;

using Application.Interfaces;
using Application.Services;
using Application.Validators;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using UI;

var services = new ServiceCollection();


// =========================
// 1️⃣ Infrastructure layer
// =========================

services.AddDbContext<HRMDbContext>(options =>
    options.UseSqlServer(
        ConfigurationManager
            .ConnectionStrings["DefaultConnection"]
            .ConnectionString));

services.AddScoped<IUnitOfWork, UnitOfWork>();


// =========================
// 2️⃣ Application layer
// =========================

// Business Validators
services.AddScoped<EmployeeBusinessValidator>();
services.AddScoped<DepartmentBusinessValidator>();
services.AddScoped<PositionBusinessValidator>();

// Services
services.AddScoped<IEmployeeService, EmployeeService>();
services.AddScoped<IDepartmentService, DepartmentService>();
services.AddScoped<IPositionService, PositionService>();
services.AddScoped<ITimesheetService, TimesheetService>();
services.AddTransient<TimesheetForm>();
services.AddScoped<IPayrollService, PayrollService>();
services.AddTransient<PayrollForm>();
// Auth
services.AddScoped<IAuthService, AuthService>();


// =========================
// 3️⃣ UI layer (Forms)
// =========================

services.AddTransient<LoginForm>();
services.AddTransient<MainForm>();

services.AddTransient<EmployeeForm>();
services.AddTransient<EmployeeEditForm>();

services.AddTransient<DepartmentForm>();
services.AddTransient<DepartmentEditForm>();

services.AddTransient<PositionForm>();
services.AddTransient<PositionEditForm>();


// =========================
// 4️⃣ Build DI container
// =========================

var serviceProvider = services.BuildServiceProvider();

// 3. Seed Data (Nạp dữ liệu mẫu)
using (var scope = serviceProvider.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<HRMDbContext>();
    try
    {
        // Đảm bảo DB được tạo
        context.Database.Migrate();

        // Gọi hàm Seed
        Infrastructure.Data.DataSeeder.Seed(context);
    }
    catch (Exception ex)
    {
        MessageBox.Show("Lỗi tạo dữ liệu mẫu: " + ex.Message);
    }
}
// --- KẾT THÚC ĐOẠN MỚI ---
// =========================
// 5️⃣ Start WinForms app
// =========================

ApplicationConfiguration.Initialize();

var loginForm = serviceProvider.GetRequiredService<LoginForm>();
if (loginForm.ShowDialog() != DialogResult.OK)
    return;

Session.CurrentUser = loginForm.LoggedInUser;

var mainForm = serviceProvider.GetRequiredService<MainForm>();
System.Windows.Forms.Application.Run(mainForm);

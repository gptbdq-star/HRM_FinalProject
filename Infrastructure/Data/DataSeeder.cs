using Domain.Entities;
using System;

namespace Infrastructure.Data;

public static class DataSeeder
{
    public static void Seed(HRMDbContext context)
    {
        if (context.Employees.Any()) return;

        // ===== MASTER DATA =====
        var deptIT = new Department { DepartmentName = "Phòng CNTT", CreatedAt = DateTime.Now };
        var deptHR = new Department { DepartmentName = "Phòng Nhân sự", CreatedAt = DateTime.Now };
        context.Departments.AddRange(deptIT, deptHR);

        var posManager = new Position { PositionName = "Trưởng phòng", Level = "Manager" };
        var posStaff = new Position { PositionName = "Nhân viên", Level = "Staff" };
        context.Positions.AddRange(posManager, posStaff);

        context.SaveChanges();

        // ===== ROLE =====
        var adminRole = new Role { Name = "Admin", Description = "Toàn quyền" };
        var hrRole = new Role { Name = "HR", Description = "Nhân sự" };
        var employeeRole = new Role { Name = "Employee", Description = "Nhân viên" };

        context.Roles.AddRange(adminRole, hrRole, employeeRole);
        context.SaveChanges();

        // ===== PERMISSION =====
        var permissions = new[]
        {
            new Permission { Code = "MENU_EMPLOYEE", Name = "Nhân sự" },
            new Permission { Code = "MENU_DEPARTMENT", Name = "Phòng ban" },
            new Permission { Code = "MENU_POSITION", Name = "Chức vụ" },
            new Permission { Code = "MENU_TIMESHEET", Name = "Chấm công" },
            new Permission { Code = "MENU_PAYROLL", Name = "Tiền lương" },
            new Permission { Code = "MENU_REWARD", Name = "Thưởng / Kỷ luật" },
            new Permission { Code = "MENU_USER", Name = "Quản lý tài khoản" }
        };

        context.Permissions.AddRange(permissions);
        context.SaveChanges();

        // ===== GÁN FULL QUYỀN CHO ADMIN =====
        foreach (var p in permissions)
        {
            context.RolePermissions.Add(new RolePermission
            {
                RoleId = adminRole.Id,
                PermissionId = p.Id
            });
        }
        context.SaveChanges();

        // ===== ADMIN USER =====
        var adminUser = new User
        {
            Username = "admin",
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("123"),
            RoleId = adminRole.Id,
            CreatedAt = DateTime.Now
        };

        context.Users.Add(adminUser);
        context.SaveChanges();
    }
}

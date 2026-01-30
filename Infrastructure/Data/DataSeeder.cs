using Domain.Entities;
using System;

namespace Infrastructure.Data;

public static class DataSeeder
{
    public static void Seed(HRMDbContext context)
    {
        // ===== ROLE =====
        if (!context.Roles.Any())
        {
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

            // ===== GÁN QUYỀN ADMIN =====
            foreach (var p in permissions)
            {
                context.RolePermissions.Add(new RolePermission
                {
                    RoleId = adminRole.Id,
                    PermissionId = p.Id
                });
            }

            context.SaveChanges();
        }

        // ===== ADMIN USER =====
        if (!context.Users.Any(u => u.Username == "admin"))
        {
            var adminRole = context.Roles.First(r => r.Name == "Admin");

            context.Users.Add(new User
            {
                Username = "admin",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("123"),
                RoleId = adminRole.Id
            });

            context.SaveChanges();
        }
    }

}

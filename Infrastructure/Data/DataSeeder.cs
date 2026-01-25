using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Data;

public static class DataSeeder
{
    public static void Seed(HRMDbContext context)
    {
        // Kiểm tra xem đã có dữ liệu chưa, nếu có rồi thì thôi không seed nữa
        if (context.Employees.Any()) return;

        // 1. TẠO MASTER DATA (Phòng ban, Chức vụ, Ca, Loại nghỉ)
        var deptIT = new Department { DepartmentName = "Phòng CNTT", CreatedAt = DateTime.Now };
        var deptHR = new Department { DepartmentName = "Phòng Nhân sự", CreatedAt = DateTime.Now };
        var deptSale = new Department { DepartmentName = "Phòng Kinh doanh", CreatedAt = DateTime.Now };
        context.Departments.AddRange(deptIT, deptHR, deptSale);

        var posManager = new Position { PositionName = "Trưởng phòng", Level = "Quản lý" };
        var posLeader = new Position { PositionName = "Trưởng nhóm", Level = "Senior" };
        var posStaff = new Position { PositionName = "Nhân viên", Level = "Junior" };
        context.Positions.AddRange(posManager, posLeader, posStaff);

        var shiftMorning = new WorkShift { ShiftName = "Ca Sáng", StartTime = new TimeSpan(8, 0, 0), EndTime = new TimeSpan(12, 0, 0) };
        var shiftAfternoon = new WorkShift { ShiftName = "Ca Chiều", StartTime = new TimeSpan(13, 30, 0), EndTime = new TimeSpan(17, 30, 0) };
        context.WorkShifts.AddRange(shiftMorning, shiftAfternoon);

        var leaveSick = new LeaveType { TypeName = "Nghỉ ốm", IsPaid = true };
        var leaveAnnual = new LeaveType { TypeName = "Nghỉ phép năm", IsPaid = true };
        var leaveUnpaid = new LeaveType { TypeName = "Nghỉ không lương", IsPaid = false };
        context.LeaveTypes.AddRange(leaveSick, leaveAnnual, leaveUnpaid);

        context.SaveChanges(); // Lưu để lấy ID

        // 2. TẠO TÀI KHOẢN ADMIN
        // Mật khẩu là '123456' (Hash BCrypt mẫu)
        var adminUser = new User
        {
            Username = "admin",
            PasswordHash = "$2a$12$dF3A7TNfneRE9BChW3iO1ODCsGzL3M7Mt5sXWQrMzFSjKgQL324IG",
            Role = "Admin",
            CreatedAt = DateTime.Now
        };
        context.Users.Add(adminUser);

        // 3. TẠO NHÂN VIÊN
        var emp1 = new Employee
        {
            EmployeeCode = "NV001",
            FullName = "Nguyễn Văn Trưởng",
            Email = "truongnv@company.com",
            Phone = "0901234567",
            DateOfBirth = new DateTime(1990, 1, 1),
            DepartmentId = deptIT.Id,
            PositionId = posManager.Id
        };

        var emp2 = new Employee
        {
            EmployeeCode = "NV002",
            FullName = "Trần Thị Dev",
            Email = "devtt@company.com",
            Phone = "0909999888",
            DateOfBirth = new DateTime(2000, 5, 15),
            DepartmentId = deptIT.Id,
            PositionId = posStaff.Id
        };

        var emp3 = new Employee
        {
            EmployeeCode = "NV003",
            FullName = "Lê Tuyển Dụng",
            Email = "hr@company.com",
            Phone = "0912333444",
            DateOfBirth = new DateTime(1995, 10, 20),
            DepartmentId = deptHR.Id,
            PositionId = posStaff.Id
        };

        context.Employees.AddRange(emp1, emp2, emp3);
        context.SaveChanges();

        // 4. TẠO HỢP ĐỒNG (QUAN TRỌNG ĐỂ TÍNH LƯƠNG)
        // NV1: Lương 30 triệu
        context.LaborContracts.Add(new LaborContract
        {
            ContractNumber = "HD-001",
            EmployeeId = emp1.Id,
            StartDate = DateTime.Now.AddYears(-2),
            BasicSalary = 30000000,
            ContractType = "Chính thức"
        });

        // NV2: Lương 15 triệu
        context.LaborContracts.Add(new LaborContract
        {
            ContractNumber = "HD-002",
            EmployeeId = emp2.Id,
            StartDate = DateTime.Now.AddYears(-1),
            BasicSalary = 15000000,
            ContractType = "Chính thức"
        });

        // NV3: Lương 12 triệu
        context.LaborContracts.Add(new LaborContract
        {
            ContractNumber = "HD-003",
            EmployeeId = emp3.Id,
            StartDate = DateTime.Now.AddMonths(-6),
            BasicSalary = 12000000,
            ContractType = "Thử việc"
        });

        context.SaveChanges();

        // 5. TẠO DỮ LIỆU CHẤM CÔNG (TIMESHEET) CHO THÁNG NÀY
        // Giả lập nhân viên đi làm từ ngày 1 đến ngày hôm nay
        var employees = new[] { emp1, emp2, emp3 };
        var today = DateTime.Now;
        var firstDayOfMonth = new DateTime(today.Year, today.Month, 1);

        foreach (var emp in employees)
        {
            for (var day = firstDayOfMonth; day <= today; day = day.AddDays(1))
            {
                // Bỏ qua Chủ nhật
                if (day.DayOfWeek == DayOfWeek.Sunday) continue;

                // Random đi trễ về sớm cho tự nhiên
                bool isLate = new Random().Next(0, 10) > 8; // 20% cơ hội đi trễ

                var ts = new Timesheet
                {
                    EmployeeId = emp.Id,
                    Date = day,
                    WorkShiftId = shiftMorning.Id,
                    CheckInTime = isLate ? new TimeSpan(8, 30, 0) : new TimeSpan(7, 55, 0),
                    CheckOutTime = new TimeSpan(17, 30, 0),
                    Status = isLate ? "Đi muộn" : "Đúng giờ"
                };
                context.Timesheets.Add(ts);
            }
        }

        context.SaveChanges();
    }
}
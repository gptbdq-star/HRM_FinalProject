using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services;

public class PayrollService : IPayrollService
{
    private readonly IUnitOfWork _unitOfWork;

    public PayrollService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void CalculatePayroll(int month, int year)
    {
        var employees = _unitOfWork.Employees.GetAll().ToList();
        // Tạo ngày cuối cùng của tháng cần tính để so sánh hợp đồng
        DateTime endOfPeriod = new DateTime(year, month, DateTime.DaysInMonth(year, month));

        foreach (var emp in employees)
        {
            // 1. Lấy hợp đồng: Chỉ cần hợp đồng bắt đầu TRƯỚC khi kết thúc tháng tính lương
            var contract = _unitOfWork.LaborContracts.GetAll()
                .Where(x => x.EmployeeId == emp.Id && x.StartDate <= endOfPeriod)
                .OrderByDescending(x => x.StartDate)
                .FirstOrDefault();

            if (contract == null) continue; // Không có hợp đồng thì bỏ qua

            decimal basicSalary = contract.BasicSalary;

            // 2. Tính ngày công: Đảm bảo bảng Timesheet của bạn đã có dữ liệu CheckIn
            // Nếu muốn test nhanh, bạn có thể bỏ điều kiện "x.CheckInTime != null"
            int workDays = _unitOfWork.Timesheets.GetAll()
                .Count(x => x.EmployeeId == emp.Id &&
                            x.Date.Month == month &&
                            x.Date.Year == year);

            // 3. Tính toán
            decimal salaryPerDay = basicSalary / 26;
            decimal finalSalary = salaryPerDay * workDays;

            // 4. Lưu (Logic xóa cũ thêm mới giữ nguyên...)
            var payslip = new Payslip
            {
                EmployeeId = emp.Id,
                Month = month,
                Year = year,
                BasicSalary = basicSalary,
                FinalSalary = Math.Round(finalSalary, 0),
                CreatedAt = DateTime.Now
            };
            _unitOfWork.Payslips.Add(payslip);
        }
        _unitOfWork.Save();
    }
    public IEnumerable<Payslip> GetPayslips(int month, int year)
    {
        return _unitOfWork.Payslips.GetAll()
            .Where(x => x.Month == month && x.Year == year);
    }
}
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
        DateTime endOfPeriod = new DateTime(year, month, DateTime.DaysInMonth(year, month));

        // --- BƯỚC 1: DỌN DẸP DỮ LIỆU CŨ (Tránh trùng lặp) ---
        var existingSlips = _unitOfWork.Payslips.GetAll()
            .Where(x => x.Month == month && x.Year == year).ToList();

        foreach (var oldSlip in existingSlips)
        {
            _unitOfWork.Payslips.Delete(oldSlip);
        }

        foreach (var emp in employees)
        {
            // 1. Lấy hợp đồng hiệu lực
            var contract = _unitOfWork.LaborContracts.GetAll()
                .Where(x => x.EmployeeId == emp.Id && x.StartDate <= endOfPeriod)
                .OrderByDescending(x => x.StartDate)
                .FirstOrDefault();

            if (contract == null) continue;

            decimal basicSalary = contract.BasicSalary;

            // 2. Tính ngày công thực tế
            int workDays = _unitOfWork.Timesheets.GetAll()
                .Count(x => x.EmployeeId == emp.Id && x.Date.Month == month && x.Date.Year == year);

            // 3. Lấy Thưởng/Phạt (Tích hợp logic RewardDiscipline)
            var rdInMonth = _unitOfWork.RewardDisciplines.GetAll()
                .Where(x => x.EmployeeId == emp.Id && x.DecisionDate.Month == month && x.DecisionDate.Year == year)
                .ToList();

            decimal totalBonus = rdInMonth.Where(x => x.IsReward).Sum(x => x.Amount);
            decimal totalDeduction = rdInMonth.Where(x => !x.IsReward).Sum(x => x.Amount);

            // 4. Công thức tính lương chuyên nghiệp
            decimal salaryPerDay = basicSalary / 26;
            decimal actualSalary = salaryPerDay * workDays;

            // Thực lĩnh = Lương theo công + Thưởng - Phạt
            decimal finalSalary = actualSalary + totalBonus - totalDeduction;

            // 5. Lưu phiếu lương
            var payslip = new Payslip
            {
                EmployeeId = emp.Id,
                Month = month,
                Year = year,
                BasicSalary = basicSalary,
                TotalBonus = totalBonus,
                TotalDeduction = totalDeduction,
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
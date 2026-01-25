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
        var employees = _unitOfWork.Employees.GetAll();

        foreach (var emp in employees)
        {
            var existingSlip = _unitOfWork.Payslips.GetAll()
                .FirstOrDefault(x => x.EmployeeId == emp.Id && x.Month == month && x.Year == year);

            if (existingSlip != null)
            {
               
                _unitOfWork.Payslips.Delete(existingSlip);
            }

            var contract = _unitOfWork.LaborContracts.GetAll()
                .Where(x => x.EmployeeId == emp.Id)
                .OrderByDescending(x => x.StartDate)
                .FirstOrDefault();

            decimal basicSalary = contract != null ? contract.BasicSalary : 0;

            int workDays = _unitOfWork.Timesheets.GetAll()
                .Count(x => x.EmployeeId == emp.Id && x.Date.Month == month && x.Date.Year == year);
            decimal salaryPerDay = basicSalary / 26;
            decimal finalSalary = salaryPerDay * workDays;

            var payslip = new Payslip
            {
                EmployeeId = emp.Id,
                Month = month,
                Year = year,
                BasicSalary = basicSalary,
                TotalBonus = 0,
                TotalDeduction = 0,
                FinalSalary = Math.Round(finalSalary, 0)
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
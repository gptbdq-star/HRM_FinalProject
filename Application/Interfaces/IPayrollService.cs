using Domain.Entities;
using System.Collections.Generic;

namespace Application.Interfaces;

public interface IPayrollService
{
    void CalculatePayroll(int month, int year);
    IEnumerable<Payslip> GetPayslips(int month, int year);
}
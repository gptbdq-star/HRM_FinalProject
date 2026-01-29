using Application.Interfaces;
using Domain.Entities;
using System.Linq;
using System.Text.RegularExpressions;

namespace Application.Validators;

public class EmployeeBusinessValidator
{
    private readonly IUnitOfWork _unitOfWork;

    public EmployeeBusinessValidator(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void ValidateForCreate(Employee employee)
    {
        ValidateEmployeeCode(employee.EmployeeCode);

        bool codeExists = _unitOfWork.Employees.Any(e =>
            e.EmployeeCode == employee.EmployeeCode);

        if (codeExists)
            throw new Exception("Mã nhân viên đã tồn tại.");

        ValidateCommon(employee, isCreate: true);
    }

    public void ValidateForUpdate(Employee employee)
    {
        ValidateCommon(employee, isCreate: false);
    }

    private void ValidateEmployeeCode(string code)
    {
        if (string.IsNullOrWhiteSpace(code))
            throw new Exception("Mã nhân viên không hợp lệ.");

        if (!Regex.IsMatch(code, @"^NV\d{3}$"))
            throw new Exception("Mã nhân viên phải theo định dạng NV001.");
    }

    private void ValidateCommon(Employee employee, bool isCreate)
    {
        bool emailExists = _unitOfWork.Employees.Any(e =>
            e.Email == employee.Email &&
            e.Id != employee.Id);

        if (emailExists)
            throw new Exception("Email đã tồn tại.");

        bool phoneExists = _unitOfWork.Employees.Any(e =>
            e.Phone == employee.Phone &&
            e.Id != employee.Id);

        if (phoneExists)
            throw new Exception("Số điện thoại đã tồn tại.");
    }
}

using Application.Interfaces;
using Domain.Entities;

namespace Application.Validators;

public class EmployeeBusinessValidator
{
    private readonly IUnitOfWork _unitOfWork;

    public EmployeeBusinessValidator(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void Validate(Employee employee)
    {
        if (_unitOfWork.Employees.Any(
            x => x.EmployeeCode == employee.EmployeeCode && x.Id != employee.Id))
            throw new Exception("Mã nhân viên đã tồn tại");

        if (_unitOfWork.Employees.Any(
            x => x.Email == employee.Email && x.Id != employee.Id))
            throw new Exception("Email đã tồn tại");

        if (_unitOfWork.Employees.Any(
            x => x.Phone == employee.Phone && x.Id != employee.Id))
            throw new Exception("Số điện thoại đã tồn tại");
    }
}

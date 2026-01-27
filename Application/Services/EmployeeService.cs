using Application.Interfaces;
using Application.Validators;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly EmployeeBusinessValidator _businessValidator;

    public EmployeeService(IUnitOfWork unitOfWork, EmployeeBusinessValidator businessValidator)
    {
        _unitOfWork = unitOfWork;
        _businessValidator = businessValidator;
    }

    public IEnumerable<Employee> GetAll()
    {
        return _unitOfWork.Employees.GetAll();
    }

    public Employee? GetById(int id)
    {
        return _unitOfWork.Employees.GetById(id);
    }

    public IEnumerable<Employee> Search(string keyword, int? departmentId, int? positionId)
    {
        var query = _unitOfWork.Employees.GetAll();

        // 1. Lọc theo từ khóa (Tên, Mã, SĐT)
        if (!string.IsNullOrWhiteSpace(keyword))
        {
            keyword = keyword.ToLower().Trim();
            query = query.Where(x =>
                x.FullName.ToLower().Contains(keyword) ||
                x.EmployeeCode.ToLower().Contains(keyword) ||
                x.Phone.Contains(keyword)
            );
        }

        // 2. Lọc theo Phòng ban
        if (departmentId.HasValue && departmentId.Value > 0)
        {
            query = query.Where(x => x.DepartmentId == departmentId.Value);
        }

        // 3. Lọc theo Chức vụ
        if (positionId.HasValue && positionId.Value > 0)
        {
            query = query.Where(x => x.PositionId == positionId.Value);
        }

        return query.ToList();
    }

    public void Create(Employee employee)
    {
        EmployeeValidator.Validate(employee);
        _businessValidator.Validate(employee);

        _unitOfWork.Employees.Add(employee);
        _unitOfWork.Save();
    }

    public void Update(Employee employee)
    {
        EmployeeValidator.Validate(employee);
        _businessValidator.Validate(employee);

        _unitOfWork.Employees.Update(employee);
        _unitOfWork.Save();
    }

    public void Delete(int id)
    {
        var employee = _unitOfWork.Employees.GetById(id);
        if (employee != null)
        {
            _unitOfWork.Employees.Delete(employee);
            _unitOfWork.Save();
        }
    }
}
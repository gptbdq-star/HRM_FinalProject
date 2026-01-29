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
        // 1️⃣ Validate dữ liệu người dùng (KHÔNG bao gồm EmployeeCode)
        EmployeeValidator.Validate(employee);

        // 2️⃣ Sinh mã nhân viên
        employee.EmployeeCode = GenerateEmployeeCode();

        // 3️⃣ Validate nghiệp vụ (code + trùng)
        _businessValidator.ValidateForCreate(employee);

        // 4️⃣ Lưu
        _unitOfWork.Employees.Add(employee);
        _unitOfWork.Save();
    }

    private string GenerateEmployeeCode()
    {
        // Lấy mã NV lớn nhất hiện tại (NV001, NV002, ...)
        var lastCode = _unitOfWork.Employees.GetAll()
            .Where(e => e.EmployeeCode.StartsWith("NV"))
            .Select(e => e.EmployeeCode)
            .OrderByDescending(code => code)
            .FirstOrDefault();

        int nextNumber = 1;

        if (!string.IsNullOrEmpty(lastCode))
        {
            // NV001 -> 1
            var numberPart = lastCode.Substring(2);
            int.TryParse(numberPart, out nextNumber);
            nextNumber++;
        }

        return $"NV{nextNumber.ToString("D3")}";
    }


    public void Update(Employee employee)
    {
        // 1️⃣ Validate dữ liệu người dùng
        EmployeeValidator.Validate(employee);

        // 2️⃣ Validate nghiệp vụ cho Update (email trùng, v.v.)
        _businessValidator.ValidateForUpdate(employee);

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
using Application.Interfaces;
using Domain.Entities;
using BCrypt.Net;
using System.Linq;

namespace Application.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IUnitOfWork _unitOfWork;

    public EmployeeService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
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
        var query = _unitOfWork.Employees.GetAll().AsQueryable();

        if (!string.IsNullOrWhiteSpace(keyword))
        {
            keyword = keyword.Trim().ToLower();
            query = query.Where(x =>
                x.EmployeeCode.ToLower().Contains(keyword) ||
                x.FullName.ToLower().Contains(keyword) ||
                x.Phone.Contains(keyword));
        }

        if (departmentId.HasValue && departmentId > 0)
            query = query.Where(x => x.DepartmentId == departmentId);

        if (positionId.HasValue && positionId > 0)
            query = query.Where(x => x.PositionId == positionId);

        return query.ToList();
    }

    public void Create(Employee employee)
    {
        employee.EmployeeCode = GenerateEmployeeCode();

        if (_unitOfWork.Employees.GetAll().Any(x => x.Email == employee.Email))
            throw new Exception("Email đã tồn tại");

        _unitOfWork.Employees.Add(employee);
        _unitOfWork.Save();

        // 🔑 LẤY ROLE EMPLOYEE TỪ DB
        var roleEmployee = _unitOfWork.Roles
            .GetAll()
            .First(r => r.Name == "Employee");

        var user = new User
        {
            Username = employee.EmployeeCode,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("123456"),
            RoleId = roleEmployee.Id,   // ✅ ĐÚNG
            EmployeeId = employee.Id
        };

        _unitOfWork.Users.Add(user);
        _unitOfWork.Save();
    }


    public void Update(Employee employee)
    {
        _unitOfWork.Employees.Update(employee);
        _unitOfWork.Save();
    }

    public void Delete(int id)
    {
        var emp = _unitOfWork.Employees.GetById(id);
        if (emp == null) return;

        _unitOfWork.Employees.Delete(emp);
        _unitOfWork.Save();
    }

    private string GenerateEmployeeCode()
    {
        var lastCode = _unitOfWork.Employees.GetAll()
            .Where(x => x.EmployeeCode.StartsWith("NV"))
            .OrderByDescending(x => x.EmployeeCode)
            .Select(x => x.EmployeeCode)
            .FirstOrDefault();

        int next = 1;
        if (!string.IsNullOrEmpty(lastCode))
        {
            int.TryParse(lastCode.Substring(2), out next);
            next++;
        }

        return $"NV{next:D3}";
    }
}

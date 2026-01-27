using Domain.Entities;
using System.Collections.Generic;

namespace Application.Interfaces;

public interface IEmployeeService
{
    IEnumerable<Employee> GetAll();
    Employee? GetById(int id);

    // Cập nhật: Thêm lọc theo Phòng ban và Chức vụ (để null nếu không lọc)
    IEnumerable<Employee> Search(string keyword, int? departmentId, int? positionId);

    void Create(Employee employee);
    void Update(Employee employee);
    void Delete(int id);
}
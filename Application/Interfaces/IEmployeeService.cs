using Domain.Entities;
using System.Collections.Generic;

namespace Application.Interfaces;

public interface IEmployeeService
{
    IEnumerable<Employee> GetAll();
    Employee? GetById(int id);

    IEnumerable<Employee> Search(string keyword);

    void Create(Employee employee);
    void Update(Employee employee);
    void Delete(int id);
}
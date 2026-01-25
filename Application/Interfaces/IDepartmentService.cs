using Domain.Entities;

namespace Application.Interfaces;

public interface IDepartmentService
{
    IEnumerable<Department> GetAll();
    Department? GetById(int id);

    void Create(Department department);
    void Update(Department department);
    void Delete(int id);
}

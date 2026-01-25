using Application.Interfaces;
using Application.Validators;
using Domain.Entities;

namespace Application.Services;

public class DepartmentService : IDepartmentService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly DepartmentBusinessValidator _businessValidator;

    public DepartmentService(
        IUnitOfWork unitOfWork,
        DepartmentBusinessValidator businessValidator)
    {
        _unitOfWork = unitOfWork;
        _businessValidator = businessValidator;
    }

    public IEnumerable<Department> GetAll()
    {
        return _unitOfWork.Departments.GetAll();
    }

    public Department? GetById(int id)
    {
        return _unitOfWork.Departments.GetById(id);
    }

    public void Create(Department department)
    {
        DepartmentValidator.Validate(department);
        _businessValidator.Validate(department);

        _unitOfWork.Departments.Add(department);
        _unitOfWork.Save();
    }

    public void Update(Department department)
    {
        DepartmentValidator.Validate(department);
        _businessValidator.Validate(department);

        _unitOfWork.Departments.Update(department);
        _unitOfWork.Save();
    }

    public void Delete(int id)
    {
        _businessValidator.ValidateDelete(id);

        var department = _unitOfWork.Departments.GetById(id);
        if (department == null) return;

        _unitOfWork.Departments.Delete(department);
        _unitOfWork.Save();
    }
}

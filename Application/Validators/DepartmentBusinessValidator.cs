using Application.Interfaces;
using Domain.Entities;

namespace Application.Validators;

public class DepartmentBusinessValidator
{
    private readonly IUnitOfWork _unitOfWork;

    public DepartmentBusinessValidator(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void Validate(Department department)
    {
        if (_unitOfWork.Departments.Any(
            x => x.DepartmentName == department.DepartmentName && x.Id != department.Id))
        {
            throw new Exception("Tên phòng ban đã tồn tại");
        }
    }

    public void ValidateDelete(int departmentId)
    {
        if (_unitOfWork.Employees.Any(x => x.DepartmentId == departmentId))
        {
            throw new Exception("Không thể xóa phòng ban đang có nhân viên");
        }
    }
}

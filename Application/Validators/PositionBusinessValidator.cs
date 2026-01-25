using Application.Interfaces;
using Domain.Entities;

namespace Application.Validators;

public class PositionBusinessValidator
{
    private readonly IUnitOfWork _unitOfWork;

    public PositionBusinessValidator(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void Validate(Position position)
    {
        if (_unitOfWork.Positions.Any(
            x => x.PositionName == position.PositionName && x.Id != position.Id))
        {
            throw new Exception("Tên chức vụ đã tồn tại");
        }
    }

    public void ValidateDelete(int positionId)
    {
        if (_unitOfWork.Employees.Any(x => x.PositionId == positionId))
        {
            throw new Exception("Không thể xóa chức vụ đang được sử dụng");
        }
    }
}

using Application.Interfaces;
using Application.Validators;
using Domain.Entities;

namespace Application.Services;

public class PositionService : IPositionService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly PositionBusinessValidator _businessValidator;

    public PositionService(
        IUnitOfWork unitOfWork,
        PositionBusinessValidator businessValidator)
    {
        _unitOfWork = unitOfWork;
        _businessValidator = businessValidator;
    }

    public IEnumerable<Position> GetAll()
    {
        return _unitOfWork.Positions.GetAll();
    }

    public Position? GetById(int id)
    {
        return _unitOfWork.Positions.GetById(id);
    }

    public void Create(Position position)
    {
        PositionValidator.Validate(position);
        _businessValidator.Validate(position);

        _unitOfWork.Positions.Add(position);
        _unitOfWork.Save();
    }

    public void Update(Position position)
    {
        PositionValidator.Validate(position);
        _businessValidator.Validate(position);

        _unitOfWork.Positions.Update(position);
        _unitOfWork.Save();
    }

    public void Delete(int id)
    {
        _businessValidator.ValidateDelete(id);

        var position = _unitOfWork.Positions.GetById(id);
        if (position == null) return;

        _unitOfWork.Positions.Delete(position);
        _unitOfWork.Save();
    }
}

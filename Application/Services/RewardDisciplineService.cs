using Application.Interfaces;
using Application.Validators;
using Domain.Entities;
using System.Collections.Generic;

namespace Application.Services;

public class RewardDisciplineService : IRewardDisciplineService
{
    private readonly IUnitOfWork _unitOfWork;

    public RewardDisciplineService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IEnumerable<RewardDiscipline> GetAll()
    {
        return _unitOfWork.RewardDisciplines.GetAll();
    }

    public RewardDiscipline? GetById(int id)
    {
        return _unitOfWork.RewardDisciplines.GetById(id);
    }

    public void Create(RewardDiscipline item)
    {
        RewardDisciplineValidator.Validate(item);

        _unitOfWork.RewardDisciplines.Add(item);
        _unitOfWork.Save();
    }

    public void Update(RewardDiscipline item)
    {
        RewardDisciplineValidator.Validate(item);

        _unitOfWork.RewardDisciplines.Update(item);
        _unitOfWork.Save();
    }

    public void Delete(int id)
    {
        var item = _unitOfWork.RewardDisciplines.GetById(id);
        if (item != null)
        {
            _unitOfWork.RewardDisciplines.Delete(item);
            _unitOfWork.Save();
        }
    }
}

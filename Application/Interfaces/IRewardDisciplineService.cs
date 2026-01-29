using Domain.Entities;
using System.Collections.Generic;

namespace Application.Interfaces;

public interface IRewardDisciplineService
{
    IEnumerable<RewardDiscipline> GetAll();
    RewardDiscipline? GetById(int id);
    void Create(RewardDiscipline item);
    void Update(RewardDiscipline item);
    void Delete(int id);
}

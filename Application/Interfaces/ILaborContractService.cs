using Domain.Entities;
using System.Collections.Generic;

namespace Application.Interfaces;

public interface ILaborContractService
{
    IEnumerable<LaborContract> GetAll();
    LaborContract? GetById(int id);
    void Create(LaborContract contract);
    void Update(LaborContract contract);
    void Delete(int id);
}

using Domain.Entities;

namespace Application.Interfaces;

public interface IPositionService
{
    IEnumerable<Position> GetAll();
    Position? GetById(int id);

    void Create(Position position);
    void Update(Position position);
    void Delete(int id);
}
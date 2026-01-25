using Domain.Entities;

namespace Application.Interfaces;

public interface IAuthService
{
    User? Login(string username, string password);
}

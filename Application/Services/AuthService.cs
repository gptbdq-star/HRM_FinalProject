using Application.Interfaces;
using Domain.Entities;
using BCrypt.Net;

namespace Application.Services;

public class AuthService : IAuthService
{
    private readonly IUnitOfWork _unitOfWork;

    public AuthService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public User? Login(string username, string password)
    {
        var user = _unitOfWork.Users.GetAll()
            .FirstOrDefault(u => u.Username == username);

        if (user == null)
            return null;

        if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            return null;

        return user;
    }
}

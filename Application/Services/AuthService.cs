using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

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
        // ✅ FIX: Dùng Query() hoặc GetQueryable() thay vì GetAll()
        // Query() trả về IQueryable nên Include() sẽ work
        var user = _unitOfWork.Users
            .Query()  // hoặc .GetQueryable()
            .Include(u => u.Role)
                .ThenInclude(r => r!.RolePermissions)
                    .ThenInclude(rp => rp.Permission)
            .FirstOrDefault(u => u.Username == username);

        if (user == null) return null;

        if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            return null;

        return user;
    }
}
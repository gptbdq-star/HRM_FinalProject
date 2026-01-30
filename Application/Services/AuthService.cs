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
        var user = _unitOfWork.Users
            .GetAll()
            .Where(u => u.Username == username)
            .Select(u => new User
            {
                Id = u.Id,
                Username = u.Username,
                PasswordHash = u.PasswordHash,
                RoleId = u.RoleId,
                Role = u.Role == null ? null : new Role
                {
                    Id = u.Role.Id,
                    Name = u.Role.Name,
                    RolePermissions = u.Role.RolePermissions
                        .Select(rp => new RolePermission
                        {
                            Permission = new Permission
                            {
                                Code = rp.Permission.Code
                            }
                        }).ToList()
                }
            })
            .FirstOrDefault();

        if (user == null)
            return null;

        if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            return null;

        return user;
    }




}

using Domain.Entities;

namespace UI;

public static class Session
{
    public static User? CurrentUser { get; set; }

    public static HashSet<string> Permissions =>
        CurrentUser?.Role.RolePermissions
            .Select(rp => rp.Permission.Code)
            .ToHashSet()
        ?? new HashSet<string>();
}

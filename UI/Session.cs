using Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace UI;

public static class Session
{
    public static User? CurrentUser { get; set; }

    public static HashSet<string> Permissions
    {
        get
        {
            if (CurrentUser?.Role?.RolePermissions == null)
                return new HashSet<string>();

            return CurrentUser.Role.RolePermissions
                .Select(rp => rp.Permission.Code)
                .ToHashSet();
        }
    }

    // ✅ DÙNG CHO ĐĂNG XUẤT
    public static void Clear()
    {
        CurrentUser = null;
    }
}

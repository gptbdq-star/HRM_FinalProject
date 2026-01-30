using Domain.Common;

namespace Domain.Entities;

public class Permission : BaseEntity
{
    public string Code { get; set; } = string.Empty; // VD: MENU_EMPLOYEE
    public string Name { get; set; } = string.Empty; // VD: Nhân sự

    public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
}

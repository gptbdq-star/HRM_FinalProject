using Domain.Common;

namespace Domain.Entities;

public class LeaveType : BaseEntity
{
    public string TypeName { get; set; } = string.Empty;
    public bool IsPaid { get; set; } = true;
}
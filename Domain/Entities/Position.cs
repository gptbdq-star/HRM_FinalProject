using Domain.Common;

namespace Domain.Entities;

public class Position : BaseEntity
{
    public string PositionName { get; set; } = string.Empty;
    public string Level { get; set; } = string.Empty;
}

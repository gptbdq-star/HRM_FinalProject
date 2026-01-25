using Domain.Common;

namespace Domain.Entities;

public class WorkShift : BaseEntity
{
    public string ShiftName { get; set; } = string.Empty; // Ca Sáng, Ca Chiều
    public TimeSpan StartTime { get; set; } // 08:00
    public TimeSpan EndTime { get; set; }   // 17:00
}
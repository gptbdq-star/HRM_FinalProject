using Domain.Common;

namespace Domain.Entities;

public class Timesheet : BaseEntity
{
    public DateTime Date { get; set; } // Ngày chấm công
    public TimeSpan? CheckInTime { get; set; }
    public TimeSpan? CheckOutTime { get; set; }

    public string Status { get; set; } = "Đúng giờ"; // Đi muộn/Về sớm/Vắng

    public int EmployeeId { get; set; }
    public Employee? Employee { get; set; }

    public int? WorkShiftId { get; set; } // Ca nào
}
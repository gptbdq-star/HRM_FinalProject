using Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class RewardDiscipline : BaseEntity
{
    public bool IsReward { get; set; } = true; // True: Thưởng, False: Phạt
    public string Reason { get; set; } = string.Empty;
    public DateTime DecisionDate { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Amount { get; set; } // Số tiền

    public int EmployeeId { get; set; }
    public Employee? Employee { get; set; }
}
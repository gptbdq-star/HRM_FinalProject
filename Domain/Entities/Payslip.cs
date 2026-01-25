using Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Payslip : BaseEntity
{
    public int Month { get; set; }
    public int Year { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal BasicSalary { get; set; } // Lương cứng

    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalBonus { get; set; } // Tổng thưởng

    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalDeduction { get; set; } // Tổng phạt/Trừ

    [Column(TypeName = "decimal(18,2)")]
    public decimal FinalSalary { get; set; } // Thực lĩnh

    public int EmployeeId { get; set; }
    public Employee? Employee { get; set; }
}
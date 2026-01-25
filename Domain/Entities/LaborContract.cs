using Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class LaborContract : BaseEntity
{
    public string ContractNumber { get; set; } = string.Empty; // Số HĐ
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal BasicSalary { get; set; } // Lương cơ bản

    public string ContractType { get; set; } = "Chính thức"; // Thử việc/Chính thức

    public int EmployeeId { get; set; }
    public Employee? Employee { get; set; }
}
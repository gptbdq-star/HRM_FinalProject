using Domain.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class LaborContract : BaseEntity
{
    public string ContractNumber { get; set; } = string.Empty;
    public string ContractType { get; set; } = "Chính thức";
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal BasicSalary { get; set; }

    public string Status { get; set; } = "Active";
    public int EmployeeId { get; set; }
    public virtual Employee? Employee { get; set; }
}

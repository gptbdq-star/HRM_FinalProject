using Domain.Common;

namespace Domain.Entities;

public class Department : BaseEntity
{
    public string DepartmentName { get; set; } = string.Empty;

    public int? ParentDepartmentId { get; set; }
    public Department? ParentDepartment { get; set; }

    public ICollection<Department> SubDepartments { get; set; }
        = new List<Department>();
}

using Application.Interfaces;
using Domain.Entities;

public interface IUnitOfWork
{
    IRepository<Employee> Employees { get; }
    IRepository<Department> Departments { get; }
    IRepository<Position> Positions { get; }
    IRepository<User> Users { get; }

    IRepository<Role> Roles { get; }
    IRepository<Permission> Permissions { get; }
    IRepository<RolePermission> RolePermissions { get; }

    IRepository<LaborContract> LaborContracts { get; }
    IRepository<WorkShift> WorkShifts { get; }
    IRepository<Timesheet> Timesheets { get; }
    IRepository<RewardDiscipline> RewardDisciplines { get; }
    IRepository<Payslip> Payslips { get; }

    int Save();
}

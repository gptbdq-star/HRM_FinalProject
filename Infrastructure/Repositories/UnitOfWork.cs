using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly HRMDbContext _context;

    public UnitOfWork(HRMDbContext context)
    {
        _context = context;

        Employees = new Repository<Employee>(_context);
        Departments = new Repository<Department>(_context);
        Positions = new Repository<Position>(_context);
        Users = new Repository<User>(_context);

        Roles = new Repository<Role>(_context);
        Permissions = new Repository<Permission>(_context);
        RolePermissions = new Repository<RolePermission>(_context);

        LaborContracts = new Repository<LaborContract>(_context);
        WorkShifts = new Repository<WorkShift>(_context);
        Timesheets = new Repository<Timesheet>(_context);
        Payslips = new Repository<Payslip>(_context);
        RewardDiscipline = new Repository<RewardDiscipline>(_context);
    }

    public IRepository<Employee> Employees { get; }
    public IRepository<Department> Departments { get; }
    public IRepository<Position> Positions { get; }
    public IRepository<User> Users { get; }

    public IRepository<Role> Roles { get; }
    public IRepository<Permission> Permissions { get; }
    public IRepository<RolePermission> RolePermissions { get; }

    public IRepository<LaborContract> LaborContracts { get; }
    public IRepository<WorkShift> WorkShifts { get; }
    public IRepository<Timesheet> Timesheets { get; }
    public IRepository<Payslip> Payslips { get; }
    public IRepository<RewardDiscipline> RewardDisciplines { get; }

    public int Save() => _context.SaveChanges();
}

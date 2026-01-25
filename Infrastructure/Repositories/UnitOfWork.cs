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
        LaborContracts = new Repository<LaborContract>(_context);
        WorkShifts = new Repository<WorkShift>(_context);
        Timesheets = new Repository<Timesheet>(_context);
        LeaveTypes = new Repository<LeaveType>(_context);
        LeaveRequests = new Repository<LeaveRequest>(_context);
        RewardDisciplines = new Repository<RewardDiscipline>(_context);
        Payslips = new Repository<Payslip>(_context);
    }

    public IRepository<Employee> Employees { get; }
    public IRepository<Department> Departments { get; }
    public IRepository<Position> Positions { get; }
    public IRepository<User> Users { get; }
    public IRepository<LaborContract> LaborContracts { get; }
    public IRepository<WorkShift> WorkShifts { get; }
    public IRepository<Timesheet> Timesheets { get; }
    public IRepository<LeaveType> LeaveTypes { get; }
    public IRepository<LeaveRequest> LeaveRequests { get; }
    public IRepository<RewardDiscipline> RewardDisciplines { get; }
    public IRepository<Payslip> Payslips { get; }

    public int Save()
    {
        return _context.SaveChanges();
    }
}
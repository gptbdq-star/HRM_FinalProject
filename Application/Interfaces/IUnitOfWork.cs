using Domain.Entities;

namespace Application.Interfaces;

public interface IUnitOfWork
{
    IRepository<Employee> Employees { get; }
    IRepository<Department> Departments { get; }
    IRepository<Position> Positions { get; }
    IRepository<User> Users { get; }
    IRepository<LaborContract> LaborContracts { get; }
    IRepository<WorkShift> WorkShifts { get; }
    IRepository<Timesheet> Timesheets { get; }
    IRepository<LeaveType> LeaveTypes { get; }
    IRepository<LeaveRequest> LeaveRequests { get; }
    IRepository<RewardDiscipline> RewardDisciplines { get; }
    IRepository<Payslip> Payslips { get; }

    int Save();
}
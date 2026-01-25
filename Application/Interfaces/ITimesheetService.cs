using Domain.Entities;
using System.Collections.Generic;

namespace Application.Interfaces;

public interface ITimesheetService
{
    string CheckIn(int employeeCode);
    string CheckOut(int employeeCode);
    IEnumerable<Timesheet> GetHistory(int employeeCode);
    IEnumerable<Timesheet> GetTodayList();
}
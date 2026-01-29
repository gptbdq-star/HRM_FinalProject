using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Application.Interfaces;

public interface ITimesheetService
{
    string CheckIn(int employeeId);
    string CheckOut(int employeeId);

    IEnumerable<Timesheet> GetByEmployeeMonth(int employeeId, int month, int year);
    IEnumerable<Timesheet> GetByDate(DateTime date);
    IEnumerable<Timesheet> GetByRange(DateTime from, DateTime to);

}

using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services;

public class TimesheetService : ITimesheetService
{
    private readonly IUnitOfWork _unitOfWork;

    public TimesheetService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public string CheckIn(int employeeId)
    {
        var today = DateTime.Today;

        var exists = _unitOfWork.Timesheets.GetAll()
            .FirstOrDefault(x => x.EmployeeId == employeeId && x.Date == today);

        if (exists != null)
            return "Nhân viên đã Check-in hôm nay";

        var timesheet = new Timesheet
        {
            EmployeeId = employeeId,
            Date = today,
            CheckInTime = DateTime.Now.TimeOfDay,
            Status = DateTime.Now.Hour > 8 ? "Đi muộn" : "Đúng giờ"
        };

        _unitOfWork.Timesheets.Add(timesheet);
        _unitOfWork.Save();

        return "Check-in thành công";
    }

    public string CheckOut(int employeeId)
    {
        var today = DateTime.Today;

        var timesheet = _unitOfWork.Timesheets.GetAll()
            .FirstOrDefault(x => x.EmployeeId == employeeId && x.Date == today);

        if (timesheet == null)
            return "Chưa Check-in hôm nay";

        timesheet.CheckOutTime = DateTime.Now.TimeOfDay;

        if (DateTime.Now.Hour < 17)
            timesheet.Status = timesheet.Status + " - Về sớm";

        _unitOfWork.Timesheets.Update(timesheet);
        _unitOfWork.Save();

        return "Check-out thành công";
    }

    public IEnumerable<Timesheet> GetByEmployeeMonth(int employeeId, int month, int year)
    {
        return _unitOfWork.Timesheets.GetAll()
            .Where(x =>
                x.EmployeeId == employeeId &&
                x.Date.Month == month &&
                x.Date.Year == year)
            .ToList();
    }

    public IEnumerable<Timesheet> GetByDate(DateTime date)
    {
        return _unitOfWork.Timesheets.GetAll()
            .Where(x => x.Date == date.Date)
            .ToList();
    }
    public IEnumerable<Timesheet> GetByRange(DateTime from, DateTime to)
    {
        return _unitOfWork.Timesheets.GetAll()
            .Where(x => x.Date.Date >= from && x.Date.Date <= to)
            .ToList();
    }

}

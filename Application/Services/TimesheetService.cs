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
        var employee = _unitOfWork.Employees.GetById(employeeId);
        if (employee == null) return "Không tìm thấy nhân viên";

        var today = DateTime.Now.Date;
        var exists = _unitOfWork.Timesheets.GetAll()
            .FirstOrDefault(x => x.EmployeeId == employeeId && x.Date == today);

        if (exists != null) return "Nhân viên đã Check-in hôm nay rồi";

        var timesheet = new Timesheet
        {
            EmployeeId = employeeId,
            Date = today,
            CheckInTime = DateTime.Now.TimeOfDay,
            Status = DateTime.Now.Hour > 8 ? "Đi muộn" : "Đúng giờ"
        };

        _unitOfWork.Timesheets.Add(timesheet);
        _unitOfWork.Save();

        return $"Check-in thành công lúc {DateTime.Now:HH:mm:ss}";
    }

    public string CheckOut(int employeeId)
    {
        var today = DateTime.Now.Date;
        var timesheet = _unitOfWork.Timesheets.GetAll()
            .FirstOrDefault(x => x.EmployeeId == employeeId && x.Date == today);

        if (timesheet == null) return "Chưa Check-in, không thể Check-out";

        timesheet.CheckOutTime = DateTime.Now.TimeOfDay;

        if (DateTime.Now.Hour < 17) timesheet.Status += " - Về sớm";

        _unitOfWork.Timesheets.Update(timesheet);
        _unitOfWork.Save();

        return $"Check-out thành công lúc {DateTime.Now:HH:mm:ss}";
    }

    public IEnumerable<Timesheet> GetHistory(int employeeId)
    {
        return _unitOfWork.Timesheets.GetAll()
            .Where(x => x.EmployeeId == employeeId)
            .OrderByDescending(x => x.Date);
    }

    public IEnumerable<Timesheet> GetTodayList()
    {
        var today = DateTime.Now.Date;
        return _unitOfWork.Timesheets.GetAll()
            .Where(x => x.Date == today)
            .OrderByDescending(x => x.CheckInTime);
    }
}
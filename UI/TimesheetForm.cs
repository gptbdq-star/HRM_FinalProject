using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Application.Interfaces;

namespace UI;

public partial class TimesheetForm : Form
{
    private readonly ITimesheetService _timesheetService;
    private readonly IEmployeeService _employeeService;

    public TimesheetForm(ITimesheetService timesheetService, IEmployeeService employeeService)
    {
        _timesheetService = timesheetService;
        _employeeService = employeeService;
        InitializeComponent();
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        LoadTodayData();
    }

    private void LoadTodayData()
    {
        var data = _timesheetService.GetTodayList();
        var employees = _employeeService.GetAll();

        var query = from t in data
                    join e in employees on t.EmployeeId equals e.Id
                    select new
                    {
                        Mã_NV = e.EmployeeCode,
                        Tên_NV = e.FullName,
                        Ngày = t.Date.ToShortDateString(),
                        Giờ_Vào = t.CheckInTime,
                        Giờ_Ra = t.CheckOutTime,
                        Trạng_Thái = t.Status
                    };

        dgvHistory.DataSource = query.ToList();
    }

    private void btnCheckIn_Click(object sender, EventArgs e)
    {
        if (!int.TryParse(txtEmployeeId.Text, out int empId))
        {
            MessageBox.Show("Vui lòng nhập ID nhân viên (số)");
            return;
        }

        string msg = _timesheetService.CheckIn(empId);
        MessageBox.Show(msg);
        LoadTodayData();
    }

    private void btnCheckOut_Click(object sender, EventArgs e)
    {
        if (!int.TryParse(txtEmployeeId.Text, out int empId))
        {
            MessageBox.Show("Vui lòng nhập ID nhân viên (số)");
            return;
        }

        string msg = _timesheetService.CheckOut(empId);
        MessageBox.Show(msg);
        LoadTodayData();
    }
}
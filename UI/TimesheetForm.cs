using Application.Interfaces;
using Domain.Entities;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace UI;

public partial class TimesheetForm : Form
{
    private readonly ITimesheetService _timesheetService;
    private readonly IEmployeeService _employeeService;

    public TimesheetForm(
        ITimesheetService timesheetService,
        IEmployeeService employeeService)
    {
        _timesheetService = timesheetService;
        _employeeService = employeeService;

        InitializeComponent();
        LoadEmployees();
        InitCalendarGrid();
    }

    private void LoadEmployees()
    {
        cboEmployee.DataSource = _employeeService.GetAll().ToList();
        cboEmployee.DisplayMember = "FullName";
        cboEmployee.SelectedIndex = -1;
    }

    private void InitCalendarGrid()
    {
        dgvCalendar.Columns.Clear();
        dgvCalendar.Rows.Clear();

        string[] days = { "Thứ 2", "Thứ 3", "Thứ 4", "Thứ 5", "Thứ 6", "Thứ 7", "CN" };
        foreach (var d in days)
        {
            dgvCalendar.Columns.Add(d, d);
        }

        dgvCalendar.RowTemplate.Height = 60;
        dgvCalendar.CellClick -= DgvCalendar_CellClick;
        dgvCalendar.CellClick += DgvCalendar_CellClick;
    }

    private void cboEmployee_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadCalendar();
    }

    private void dtpMonth_ValueChanged(object sender, EventArgs e)
    {
        LoadCalendar();
    }

    private void btnCheckIn_Click(object sender, EventArgs e)
    {
        if (cboEmployee.SelectedItem is not Employee emp)
        {
            MessageBox.Show("Vui lòng chọn nhân viên");
            return;
        }

        MessageBox.Show(_timesheetService.CheckIn(emp.Id));
        LoadCalendar();
    }

    private void btnCheckOut_Click(object sender, EventArgs e)
    {
        if (cboEmployee.SelectedItem is not Employee emp)
        {
            MessageBox.Show("Vui lòng chọn nhân viên");
            return;
        }

        MessageBox.Show(_timesheetService.CheckOut(emp.Id));
        LoadCalendar();
    }

    private void LoadCalendar()
    {
        if (dgvCalendar.Columns.Count == 0)
            InitCalendarGrid();

        if (cboEmployee.SelectedItem is not Employee emp)
            return;

        dgvCalendar.Rows.Clear();

        int year = dtpMonth.Value.Year;
        int month = dtpMonth.Value.Month;

        DateTime firstDay = new DateTime(year, month, 1);
        int daysInMonth = DateTime.DaysInMonth(year, month);

        int startCol = ((int)firstDay.DayOfWeek + 6) % 7;
        int rowIndex = dgvCalendar.Rows.Add();

        var timesheets = _timesheetService
            .GetByEmployeeMonth(emp.Id, month, year)
            .ToList();

        for (int day = 1; day <= daysInMonth; day++)
        {
            DateTime date = new DateTime(year, month, day);
            int col = (startCol + day - 1) % 7;

            if (col == 0 && day != 1)
                rowIndex = dgvCalendar.Rows.Add();

            var cell = dgvCalendar.Rows[rowIndex].Cells[col];
            cell.Value = day.ToString();
            cell.Tag = date;

            var ts = timesheets.FirstOrDefault(x => x.Date.Date == date.Date);

            if (ts == null)
                cell.Style.BackColor = Color.White;
            else if (ts.Status.Contains("Về sớm"))
                cell.Style.BackColor = Color.LightCoral;
            else if (ts.Status.Contains("Đi muộn"))
                cell.Style.BackColor = Color.Orange;
            else
                cell.Style.BackColor = Color.LightGreen;
        }
    }

    private void DgvCalendar_CellClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || e.ColumnIndex < 0)
            return;

        var cell = dgvCalendar.Rows[e.RowIndex].Cells[e.ColumnIndex];
        if (cell.Tag is not DateTime date)
            return;

        var list = _timesheetService.GetByDate(date)
            .Select(x => new
            {
                Nhân_viên = x.Employee != null ? x.Employee.FullName : "",
                Giờ_vào = x.CheckInTime,
                Giờ_ra = x.CheckOutTime,
                Trạng_thái = x.Status
            })
            .ToList();
    }

    private void btnStatistic_Click(object sender, EventArgs e)
    {
        DateTime from = dtpFrom.Value.Date;
        DateTime to = dtpTo.Value.Date;

        if (from > to)
        {
            MessageBox.Show("Ngày bắt đầu phải nhỏ hơn ngày kết thúc");
            return;
        }

        var data = _timesheetService.GetByRange(from, to)
            .Where(x => x.Status.Contains("Đi muộn") || x.Status.Contains("Về sớm"))
            .GroupBy(x => x.Employee!.FullName)
            .Select(g => new
            {
                Nhân_viên = g.Key,
                Số_ngày_đi_muộn = g.Count(x => x.Status.Contains("Đi muộn")),
                Số_ngày_về_sớm = g.Count(x => x.Status.Contains("Về sớm")),
                Tổng_vi_phạm = g.Count()
            })
            .OrderByDescending(x => x.Tổng_vi_phạm)
            .ToList();

        dgvStatistic.DataSource = data;

        if (!data.Any())
            MessageBox.Show("Không có dữ liệu vi phạm trong khoảng đã chọn");
    }
}

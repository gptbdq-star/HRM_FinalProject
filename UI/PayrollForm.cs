using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Application.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UI;

public partial class PayrollForm : Form
{
    private readonly IPayrollService _payrollService;
    private readonly IEmployeeService _employeeService;

    public PayrollForm(IPayrollService payrollService, IEmployeeService employeeService)
    {
        _payrollService = payrollService;
        _employeeService = employeeService;
        InitializeComponent();
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        // Mặc định chọn tháng hiện tại
        numMonth.Value = DateTime.Now.Month;
        numYear.Value = DateTime.Now.Year;
    }

    private void btnCalculate_Click(object sender, EventArgs e)
    {
        int month = (int)numMonth.Value;
        int year = (int)numYear.Value;

        try
        {
            // Gọi Service tính toán
            _payrollService.CalculatePayroll(month, year);

            MessageBox.Show("Đã tính lương xong!", "Thành công");

            // Load lại lưới
            LoadData(month, year);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi: " + ex.Message);
        }
    }

    private void LoadData(int month, int year)
    {
        var slips = _payrollService.GetPayslips(month, year);
        var employees = _employeeService.GetAll();
        var query = from s in slips
                    join emp in employees on s.EmployeeId equals emp.Id
                    select new
                    {
                        Mã_NV = emp.EmployeeCode,
                        Tên_NV = emp.FullName,
                        Lương_Cơ_Bản = s.BasicSalary.ToString("N0"),
                        Thực_Lĩnh = s.FinalSalary.ToString("N0")
                    };

        dgvPayroll.DataSource = query.ToList();
    }

    private void btnView_Click(object sender, EventArgs e)
    {
        LoadData((int)numMonth.Value, (int)numYear.Value);
    }
}
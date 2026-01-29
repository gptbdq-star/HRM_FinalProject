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
            // --- BƯỚC VALIDATION UI ---
            var existingData = _payrollService.GetPayslips(month, year);
            if (existingData.Any())
            {
                var confirm = MessageBox.Show(
                    $"Tháng {month}/{year} đã có dữ liệu lương. Bạn có muốn TÍNH LẠI (ghi đè dữ liệu cũ) không?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirm == DialogResult.No) return;
            }

            // Gọi Service tính toán
            _payrollService.CalculatePayroll(month, year);

            MessageBox.Show("Đã tính lương xong!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadData(month, year);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi tính lương: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void LoadData(int month, int year)
    {
        var slips = _payrollService.GetPayslips(month, year).ToList();
        var employees = _employeeService.GetAll().ToList();

        // Dùng Left Join để tránh mất dữ liệu nếu thông tin Employee có vấn đề
        var query = from s in slips
                    join emp in employees on s.EmployeeId equals emp.Id into empGroup
                    from emp in empGroup.DefaultIfEmpty()
                    select new
                    {
                        Mã_NV = emp?.EmployeeCode ?? "N/A",
                        Tên_NV = emp?.FullName ?? "N/A",
                        Lương_CB = s.BasicSalary.ToString("N0"),
                        Thưởng = s.TotalBonus.ToString("N0"),
                        Phạt = s.TotalDeduction.ToString("N0"),
                        Thực_Lĩnh = s.FinalSalary.ToString("N0")
                    };

        dgvPayroll.DataSource = query.ToList();
    }

    private void btnView_Click(object sender, EventArgs e)
    {
        LoadData((int)numMonth.Value, (int)numYear.Value);
    }
}
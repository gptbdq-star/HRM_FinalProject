using Application.Interfaces;
using Domain.Entities;
using System;
using System.Linq;
using System.Windows.Forms;

namespace UI;

public partial class LaborContractEditForm : Form
{
    private readonly ILaborContractService _contractService;
    private readonly IUnitOfWork _unitOfWork;
    private LaborContract? _contract;

    public LaborContractEditForm(ILaborContractService contractService, IUnitOfWork unitOfWork, LaborContract? contract = null)
    {
        _contractService = contractService;
        _unitOfWork = unitOfWork;
        _contract = contract;
        InitializeComponent();
        LoadEmployees();
        if (_contract != null) LoadData();
    }

    private void LoadEmployees()
    {
        cboEmployee.DataSource = _unitOfWork.Employees.GetAll().ToList();
        cboEmployee.DisplayMember = "FullName";
        cboEmployee.ValueMember = "Id";
        cboEmployee.SelectedIndex = -1;
    }

    private void LoadData()
    {
        if (_contract == null) return;
        txtCode.Text = _contract.ContractNumber;
        txtSalary.Text = _contract.BasicSalary.ToString();
        dtpStart.Value = _contract.StartDate;
        dtpEnd.Value = _contract.EndDate;
        cboEmployee.SelectedValue = _contract.EmployeeId;
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            // Kiểm tra null cho ComboBox
            if (cboEmployee.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên!");
                return;
            }

            var item = _contract ?? new LaborContract();

            // SỬA TẠI ĐÂY: Dùng ContractNumber thay vì ContractCode
            item.ContractNumber = txtCode.Text.Trim();
            item.ContractType = "Chính thức";

            item.EmployeeId = (int)cboEmployee.SelectedValue!; // Dấu ! để khẳng định không null
            item.BasicSalary = decimal.Parse(txtSalary.Text);
            item.StartDate = dtpStart.Value;
            item.EndDate = dtpEnd.Value;
            item.Status = "Active";

            if (item.Id == 0) _contractService.Create(item);
            else _contractService.Update(item);

            this.DialogResult = DialogResult.OK;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi: " + ex.Message);
        }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}
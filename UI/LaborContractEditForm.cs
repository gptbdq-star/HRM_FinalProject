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
    private readonly bool _isCreateMode;
    private LaborContract? _contract;

    public LaborContractEditForm(
        ILaborContractService contractService,
        IUnitOfWork unitOfWork,
        LaborContract? contract = null)
    {
        _contractService = contractService;
        _unitOfWork = unitOfWork;
        _contract = contract;
        _isCreateMode = contract == null;

        InitializeComponent();
        LoadEmployees();
        LoadData();
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
        txtCode.ReadOnly = true;
        txtCode.TabStop = false;

        if (_isCreateMode)
        {
            txtCode.Text = "(Tự động sinh)";
            return;
        }

        txtCode.Text = _contract!.ContractNumber;
        txtSalary.Text = _contract.BasicSalary.ToString();
        dtpStart.Value = _contract.StartDate;
        dtpEnd.Value = _contract.EndDate;
        cboEmployee.SelectedValue = _contract.EmployeeId;
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (cboEmployee.SelectedValue == null)
                throw new Exception("Vui lòng chọn nhân viên.");

            var item = _contract ?? new LaborContract();

            item.ContractType = "Chính thức";
            item.EmployeeId = (int)cboEmployee.SelectedValue;
            item.BasicSalary = decimal.Parse(txtSalary.Text);
            item.StartDate = dtpStart.Value;
            item.EndDate = dtpEnd.Value;

            if (_isCreateMode)
                _contractService.Create(item);
            else
                _contractService.Update(item);

            DialogResult = DialogResult.OK;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
    }
}

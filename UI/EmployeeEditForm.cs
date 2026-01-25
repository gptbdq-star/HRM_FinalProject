using System;
using System.Windows.Forms;
using Application.Interfaces;
using Application.Validators;
using Domain.Entities;

namespace UI;

public partial class EmployeeEditForm : Form
{
    private readonly IEmployeeService _employeeService;
    private readonly IUnitOfWork _unitOfWork;
    private Employee? _employee;

    public EmployeeEditForm(
        IEmployeeService employeeService,
        IUnitOfWork unitOfWork,
        Employee? employee = null)
    {
        _employeeService = employeeService;
        _unitOfWork = unitOfWork;
        _employee = employee;

        InitializeComponent();
        LoadCombobox();
        LoadData();

        HookRealtimeValidation();
        btnSave.Enabled = false;
    }

    private void LoadCombobox()
    {
        cboDepartment.DataSource = _unitOfWork.Departments.GetAll();
        cboDepartment.DisplayMember = "DepartmentName";
        cboDepartment.ValueMember = "Id";

        cboPosition.DataSource = _unitOfWork.Positions.GetAll();
        cboPosition.DisplayMember = "PositionName";
        cboPosition.ValueMember = "Id";
    }

    private void LoadData()
    {
        if (_employee == null) return;

        txtCode.Text = _employee.EmployeeCode;
        txtName.Text = _employee.FullName;
        txtEmail.Text = _employee.Email;
        txtPhone.Text = _employee.Phone;

        cboDepartment.SelectedValue = _employee.DepartmentId;
        cboPosition.SelectedValue = _employee.PositionId;
    }

    private void HookRealtimeValidation()
    {
        txtName.TextChanged += InputChanged;
        txtEmail.TextChanged += InputChanged;
        txtPhone.TextChanged += InputChanged;
        cboDepartment.SelectedIndexChanged += InputChanged;
        cboPosition.SelectedIndexChanged += InputChanged;
    }

    private void InputChanged(object? sender, EventArgs e)
    {
        btnSave.Enabled = ValidateSilent();
    }

    private bool ValidateSilent()
    {
        try
        {
            var temp = new Employee
            {
                FullName = txtName.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                DateOfBirth = new DateTime(2000, 1, 1),
                DepartmentId = cboDepartment.SelectedValue != null
                    ? (int)cboDepartment.SelectedValue
                    : 0,
                PositionId = cboPosition.SelectedValue != null
                    ? (int)cboPosition.SelectedValue
                    : 0
            };

            EmployeeValidator.Validate(temp);
            errorProvider1.Clear();
            return true;
        }
        catch (Exception ex)
        {
            ShowValidationError(ex.Message);
            return false;
        }
    }

    private void ShowValidationError(string message)
    {
        errorProvider1.Clear();
        if (message.Contains("Mã nhân viên"))
            errorProvider1.SetError(txtCode, message);
        else if (message.Contains("Tên"))
            errorProvider1.SetError(txtName, message);
        else if (message.Contains("Email"))
            errorProvider1.SetError(txtEmail, message);
        else if (message.Contains("Số điện thoại"))
            errorProvider1.SetError(txtPhone, message);
        else if (message.Contains("phòng ban"))
            errorProvider1.SetError(cboDepartment, message);
        else if (message.Contains("chức vụ"))
            errorProvider1.SetError(cboPosition, message);
        else
            MessageBox.Show(message);
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (_employee == null)
                _employee = new Employee();

            _employee.EmployeeCode = txtCode.Text.Trim();
            _employee.FullName = txtName.Text.Trim();
            _employee.Email = txtEmail.Text.Trim();
            _employee.Phone = txtPhone.Text.Trim();
            _employee.DateOfBirth = new DateTime(2000, 1, 1);
            _employee.DepartmentId = (int)cboDepartment.SelectedValue;
            _employee.PositionId = (int)cboPosition.SelectedValue;

            if (_employee.Id == 0)
                _employeeService.Create(_employee);
            else
                _employeeService.Update(_employee);

            DialogResult = DialogResult.OK;
        }
        catch (Exception ex)
        {
            ShowValidationError(ex.Message);
        }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
    }
}

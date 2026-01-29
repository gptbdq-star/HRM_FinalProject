using System;
using System.Windows.Forms;
using Application.Interfaces;
using Application.Validators;
using Domain.Entities;

namespace UI;

public partial class EmployeeEditForm : Form
{
    private readonly bool _isCreateMode;

    private readonly IEmployeeService _employeeService;
    private readonly IUnitOfWork _unitOfWork;
    private Employee? _employee; // Thêm dấu ? để báo hiệu có thể null

    public EmployeeEditForm(
        IEmployeeService employeeService,
        IUnitOfWork unitOfWork,
        Employee? employee = null)
    {
        _employeeService = employeeService;
        _unitOfWork = unitOfWork;
        _employee = employee;
        _isCreateMode = employee == null;

        InitializeComponent();

        LoadCombobox();
        LoadData(); // Load dữ liệu lên trước khi validate

        HookRealtimeValidation();

        // Kiểm tra validate lần đầu nhưng KHÔNG hiện lỗi đỏ ngay (để form sạch đẹp)
        btnSave.Enabled = ValidateSilent(showError: false);
    }

    private void LoadCombobox()
    {
        cboDepartment.DataSource = _unitOfWork.Departments.GetAll();
        cboDepartment.DisplayMember = "DepartmentName";
        cboDepartment.ValueMember = "Id";

        cboPosition.DataSource = _unitOfWork.Positions.GetAll();
        cboPosition.DisplayMember = "PositionName";
        cboPosition.ValueMember = "Id";

        // Reset về trạng thái chưa chọn
        cboDepartment.SelectedIndex = -1;
        cboPosition.SelectedIndex = -1;
    }

    private void LoadData()
    {
        txtCode.ReadOnly = true;
        txtCode.TabStop = false;

        if (_employee == null) return;

        // Dùng toán tử ?? "" để tránh lỗi nếu dữ liệu trong DB bị null
        txtCode.Text = _employee.EmployeeCode ?? "";
        txtName.Text = _employee.FullName ?? "";
        txtEmail.Text = _employee.Email ?? "";
        txtPhone.Text = _employee.Phone ?? "";

        // [QUAN TRỌNG] Load ngày sinh từ object lên control
        dtpDob.Value = _employee.DateOfBirth;

        cboDepartment.SelectedValue = _employee.DepartmentId;
        cboPosition.SelectedValue = _employee.PositionId;

        // Nếu là sửa thì khóa ô Mã NV
        txtCode.Enabled = false;
    }

    private void HookRealtimeValidation()
    {
        // [ĐÃ SỬA] Thêm bắt sự kiện cho txtCode và dtpDob
        txtCode.TextChanged += InputChanged;
        dtpDob.ValueChanged += InputChanged;

        txtName.TextChanged += InputChanged;
        txtEmail.TextChanged += InputChanged;
        txtPhone.TextChanged += InputChanged;
        cboDepartment.SelectedIndexChanged += InputChanged;
        cboPosition.SelectedIndexChanged += InputChanged;
    }

    private void InputChanged(object? sender, EventArgs e)
    {
        // Khi người dùng nhập thì mới hiện lỗi đỏ
        btnSave.Enabled = ValidateSilent(showError: true);
    }

    // Thêm tham số showError để kiểm soát việc hiện lỗi
    private bool ValidateSilent(bool showError)
    {
        try
        {
            var temp = new Employee
            {
                EmployeeCode = _employee == null
        ? "NV000"               // mã giả hợp lệ cho validation
        : txtCode.Text.Trim(),  // khi sửa thì dùng mã thật

                FullName = txtName.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Phone = txtPhone.Text.Trim(),

                DateOfBirth = dtpDob.Value,

                DepartmentId = cboDepartment.SelectedValue != null? (int)cboDepartment.SelectedValue: 0,
                PositionId = cboPosition.SelectedValue != null? (int)cboPosition.SelectedValue: 0
            };


            EmployeeValidator.Validate(temp);

            // Nếu validate đúng thì xóa lỗi
            errorProvider1.Clear();
            return true;
        }
        catch (Exception ex)
        {
            // Chỉ hiện lỗi nếu cần thiết
            if (showError) ShowValidationError(ex.Message);
            return false;
        }
    }

    private void ShowValidationError(string message)
    {
        errorProvider1.Clear();

        // Bỏ qua lỗi Mã NV nếu đang ở chế độ Sửa (đã bị disable)
        if (!txtCode.Enabled && message.Contains("Mã nhân viên")) return;

        if (message.Contains("Mã nhân viên")) errorProvider1.SetError(txtCode, message);
        else if (message.Contains("Tên")) errorProvider1.SetError(txtName, message);
        else if (message.Contains("Email")) errorProvider1.SetError(txtEmail, message);
        else if (message.Contains("Số điện thoại")) errorProvider1.SetError(txtPhone, message);
        else if (message.Contains("tuổi") || message.Contains("Ngày sinh")) errorProvider1.SetError(dtpDob, message);
        else if (message.Contains("phòng ban")) errorProvider1.SetError(cboDepartment, message);
        else if (message.Contains("chức vụ")) errorProvider1.SetError(cboPosition, message);
        else MessageBox.Show(message);
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (_employee == null)
                _employee = new Employee(); // OK, vì _isCreateMode đã cố định

            _employee.FullName = txtName.Text.Trim();
            _employee.Email = txtEmail.Text.Trim();
            _employee.Phone = txtPhone.Text.Trim();
            _employee.DateOfBirth = dtpDob.Value;

            if (cboDepartment.SelectedValue != null)
                _employee.DepartmentId = (int)cboDepartment.SelectedValue;

            if (cboPosition.SelectedValue != null)
                _employee.PositionId = (int)cboPosition.SelectedValue;

            if (_isCreateMode)
                _employeeService.Create(_employee);
            else
                _employeeService.Update(_employee);

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
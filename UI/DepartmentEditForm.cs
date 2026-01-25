using System;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using Application.Interfaces;
using Application.Validators;
using Domain.Entities;

namespace UI;

public partial class DepartmentEditForm : Form
{
    private readonly IDepartmentService _departmentService;
    private Department? _department;

    public DepartmentEditForm(
        IDepartmentService departmentService,
        Department? department = null)
    {
        _departmentService = departmentService;
        _department = department;

        InitializeComponent();
        LoadParentDepartments();
        LoadData();

        txtName.TextChanged += InputChanged;
        cboParent.SelectedIndexChanged += InputChanged;
        btnSave.Enabled = false;
    }

    private void LoadParentDepartments()
    {
        var list = _departmentService.GetAll().ToList();
        list.Insert(0, new Department { Id = 0, DepartmentName = "--- Không có ---" });

        cboParent.DataSource = list;
        cboParent.DisplayMember = "DepartmentName";
        cboParent.ValueMember = "Id";
    }

    private void LoadData()
    {
        if (_department == null) return;

        txtName.Text = _department.DepartmentName;
        cboParent.SelectedValue = _department.ParentDepartmentId ?? 0;
    }

    private void InputChanged(object? sender, EventArgs e)
    {
        btnSave.Enabled = ValidateSilent();
    }

    private bool ValidateSilent()
    {
        try
        {
            var temp = new Department
            {
                DepartmentName = txtName.Text.Trim(),
                ParentDepartmentId = cboParent.SelectedValue is int id && id > 0
                    ? id
                    : null
            };

            DepartmentValidator.Validate(temp);
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

        if (message.Contains("Tên phòng ban"))
            errorProvider1.SetError(txtName, message);
        else
            MessageBox.Show(message);
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (_department == null)
                _department = new Department();

            _department.DepartmentName = txtName.Text.Trim();
            _department.ParentDepartmentId = cboParent.SelectedValue is int id && id > 0
                ? id
                : null;

            if (_department.Id == 0)
                _departmentService.Create(_department);
            else
                _departmentService.Update(_department);

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

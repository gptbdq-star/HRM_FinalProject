using System;
using System.Windows.Forms;
using System.Xml.Linq;
using Application.Interfaces;
using Application.Validators;
using Domain.Entities;

namespace UI;

public partial class PositionEditForm : Form
{
    private readonly IPositionService _positionService;
    private Position? _position;

    public PositionEditForm(
        IPositionService positionService,
        Position? position = null)
    {
        _positionService = positionService;
        _position = position;

        InitializeComponent();
        LoadData();

        txtName.TextChanged += InputChanged;
        txtLevel.TextChanged += InputChanged;
        btnSave.Enabled = false;
    }

    private void LoadData()
    {
        if (_position == null) return;

        txtName.Text = _position.PositionName;
        txtLevel.Text = _position.Level;
    }

    private void InputChanged(object? sender, EventArgs e)
    {
        btnSave.Enabled = ValidateSilent();
    }

    private bool ValidateSilent()
    {
        try
        {
            var temp = new Position
            {
                PositionName = txtName.Text.Trim(),
                Level = txtLevel.Text.Trim()
            };

            PositionValidator.Validate(temp);
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

        if (message.Contains("Tên chức vụ"))
            errorProvider1.SetError(txtName, message);
        else if (message.Contains("Cấp bậc"))
            errorProvider1.SetError(txtLevel, message);
        else
            MessageBox.Show(message);
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (_position == null)
                _position = new Position();

            _position.PositionName = txtName.Text.Trim();
            _position.Level = txtLevel.Text.Trim();

            if (_position.Id == 0)
                _positionService.Create(_position);
            else
                _positionService.Update(_position);

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

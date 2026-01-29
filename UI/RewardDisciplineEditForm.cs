using Application.Interfaces;
using Domain.Entities;
using System;
using System.Linq;
using System.Windows.Forms;

namespace UI;

public partial class RewardDisciplineEditForm : Form
{
    private readonly IRewardDisciplineService _service;
    private readonly IUnitOfWork _unitOfWork;
    private RewardDiscipline? _item;

    public RewardDisciplineEditForm(
        IRewardDisciplineService service,
        IUnitOfWork unitOfWork,
        RewardDiscipline? item = null)
    {
        _service = service;
        _unitOfWork = unitOfWork;
        _item = item;

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
        if (_item == null) return;

        cboEmployee.SelectedValue = _item.EmployeeId;
        txtAmount.Text = _item.Amount.ToString();
        txtReason.Text = _item.Reason;
        dtpDate.Value = _item.DecisionDate;
        rdoReward.Checked = _item.IsReward;
        rdoDiscipline.Checked = !_item.IsReward;
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (cboEmployee.SelectedValue == null)
                throw new Exception("Vui lòng chọn nhân viên.");

            var item = _item ?? new RewardDiscipline();

            item.EmployeeId = (int)cboEmployee.SelectedValue;
            item.Amount = decimal.Parse(txtAmount.Text);
            item.Reason = txtReason.Text.Trim();
            item.DecisionDate = dtpDate.Value;
            item.IsReward = rdoReward.Checked;

            if (item.Id == 0) _service.Create(item);
            else _service.Update(item);

            DialogResult = DialogResult.OK;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
    }
}

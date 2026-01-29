using Application.Interfaces;
using Domain.Entities;
using System;
using System.Linq;
using System.Windows.Forms;

namespace UI;

public partial class RewardDisciplineForm : Form
{
    private readonly IRewardDisciplineService _service;
    private readonly IUnitOfWork _unitOfWork;

    public RewardDisciplineForm(
        IRewardDisciplineService service,
        IUnitOfWork unitOfWork)
    {
        _service = service;
        _unitOfWork = unitOfWork;

        InitializeComponent();
        LoadData();
    }

    private void LoadData()
    {
        dgvData.DataSource = _service.GetAll()
            .Select(x => new
            {
                x.Id,
                Employee = x.Employee!.FullName,
                Type = x.IsReward ? "Khen thưởng" : "Kỷ luật",
                x.Amount,
                x.DecisionDate,
                x.Reason
            })
            .ToList();
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        using var f = new RewardDisciplineEditForm(_service, _unitOfWork);
        if (f.ShowDialog() == DialogResult.OK)
            LoadData();
    }

    private void btnEdit_Click(object sender, EventArgs e)
    {
        if (dgvData.CurrentRow == null) return;

        int id = (int)dgvData.CurrentRow.Cells["Id"].Value;
        var item = _service.GetById(id);
        if (item == null) return;

        using var f = new RewardDisciplineEditForm(_service, _unitOfWork, item);
        if (f.ShowDialog() == DialogResult.OK)
            LoadData();
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (dgvData.CurrentRow == null) return;

        int id = (int)dgvData.CurrentRow.Cells["Id"].Value;

        if (MessageBox.Show("Xóa bản ghi này?", "Xác nhận",
            MessageBoxButtons.YesNo) == DialogResult.Yes)
        {
            _service.Delete(id);
            LoadData();
        }
    }
}

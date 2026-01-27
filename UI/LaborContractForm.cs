using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace UI;

public partial class LaborContractForm : Form
{
    private readonly ILaborContractService _contractService;
    private readonly IUnitOfWork _unitOfWork;

    public LaborContractForm(ILaborContractService contractService, IUnitOfWork unitOfWork)
    {
        _contractService = contractService;
        _unitOfWork = unitOfWork;
        InitializeComponent();
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        LoadData();
    }

    private void btnLoad_Click(object sender, EventArgs e)
    {
        LoadData();
    }

    private void LoadData()
    {
        var result = _contractService.GetAll();
        dgvContracts.DataSource = result.Select(x => new
        {
            x.Id,
            Số_HĐ = x.ContractNumber,
            Nhân_Viên = x.Employee?.FullName ?? "N/A",
            Lương_CB = x.BasicSalary.ToString("N0"),
            Bắt_Đầu = x.StartDate.ToShortDateString(),
            Kết_Thúc = x.EndDate.ToShortDateString(),
            Trạng_Thái = x.Status
        }).ToList();
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        // Bạn cần đảm bảo đã tạo LaborContractEditForm và đăng ký trong Program.cs
        // Ở đây tôi dùng cách khởi tạo trực tiếp qua ServiceProvider để đúng chuẩn DI
        var frm = new LaborContractEditForm(_contractService, _unitOfWork);
        if (frm.ShowDialog() == DialogResult.OK)
        {
            LoadData();
        }
    }
    // 1. Sự kiện Double Click vào dòng để Sửa
    private void dgvContracts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;

        var idValue = dgvContracts.Rows[e.RowIndex].Cells["Id"].Value;
        if (idValue == null) return;

        int id = Convert.ToInt32(idValue);
        var contract = _contractService.GetById(id); // Giả sử service đã có hàm GetById

        if (contract != null)
        {
            var frm = new LaborContractEditForm(_contractService, _unitOfWork, contract);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }
    }

    // 2. Sự kiện nút Xóa
    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (dgvContracts.SelectedRows.Count == 0) return;

        int id = Convert.ToInt32(dgvContracts.SelectedRows[0].Cells["Id"].Value);

        if (MessageBox.Show("Xóa hợp đồng này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
        {
            _contractService.Delete(id);
            LoadData();
        }
    }
}
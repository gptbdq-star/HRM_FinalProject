using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Application.Interfaces;
using Domain.Entities;

namespace UI;

public partial class EmployeeForm : Form
{
    private readonly IEmployeeService _employeeService;
    private readonly IUnitOfWork _unitOfWork;

    public EmployeeForm(
        IEmployeeService employeeService,
        IUnitOfWork unitOfWork)
    {
        _employeeService = employeeService;
        _unitOfWork = unitOfWork;
        InitializeComponent();
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        LoadData();
    }

    private void LoadData()
    {
        string keyword = txtSearch.Text;
        var result = _employeeService.Search(keyword);
        dgvEmployees.DataSource = result.Select(x => new
        {
            x.Id,
            Mã_NV = x.EmployeeCode,
            Họ_Tên = x.FullName,
            Email = x.Email,
            SĐT = x.Phone,
            Phòng_Ban = x.Department != null ? x.Department.DepartmentName : "N/A",
            Chức_Vụ = x.Position != null ? x.Position.PositionName : "N/A"
        }).ToList();
    }

    private void btnSearch_Click(object sender, EventArgs e)
    {
        LoadData();
    }

    // --- HÀM CÒN THIẾU GÂY LỖI ĐÂY ---
    // Hàm này cho phép ấn Enter để tìm kiếm thay vì phải click chuột
    private void txtSearch_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            btnSearch.PerformClick(); // Giả lập bấm nút Tìm
            e.SuppressKeyPress = true; // Chặn tiếng "ting" khó chịu của Windows
        }
    }
    // ----------------------------------

    private void btnLoad_Click(object sender, EventArgs e)
    {
        txtSearch.Text = string.Empty;
        LoadData();
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        var frm = new EmployeeEditForm(_employeeService, _unitOfWork);
        if (frm.ShowDialog() == DialogResult.OK)
        {
            LoadData();
        }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (dgvEmployees.SelectedRows.Count == 0)
        {
            MessageBox.Show("Vui lòng chọn nhân viên cần xóa!", "Thông báo");
            return;
        }

        var value = dgvEmployees.SelectedRows[0].Cells["Id"].Value;
        if (value == null) return;

        int id = Convert.ToInt32(value);

        if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
        {
            try
            {
                _employeeService.Delete(id);
                LoadData();
                MessageBox.Show("Xóa thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }

    private void dgvEmployees_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;

        var idValue = dgvEmployees.Rows[e.RowIndex].Cells["Id"].Value;
        if (idValue == null) return;

        int id = Convert.ToInt32(idValue);
        var employee = _employeeService.GetById(id);

        if (employee != null)
        {
            var frm = new EmployeeEditForm(_employeeService, _unitOfWork, employee);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }
    }
}
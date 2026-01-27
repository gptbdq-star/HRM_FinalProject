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

    public EmployeeForm(IEmployeeService employeeService, IUnitOfWork unitOfWork)
    {
        _employeeService = employeeService;
        _unitOfWork = unitOfWork;
        InitializeComponent();
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        LoadFilterData(); // Nạp dữ liệu vào Combobox lọc
        LoadData();
    }

    private void LoadFilterData()
    {
        // 1. Nạp Phòng ban vào bộ lọc
        var depts = _unitOfWork.Departments.GetAll().ToList();
        depts.Insert(0, new Department { Id = 0, DepartmentName = "-- Tất cả --" });
        cboFilterDept.DataSource = depts;
        cboFilterDept.DisplayMember = "DepartmentName";
        cboFilterDept.ValueMember = "Id";

        // 2. Nạp Chức vụ vào bộ lọc
        var positions = _unitOfWork.Positions.GetAll().ToList();
        positions.Insert(0, new Position { Id = 0, PositionName = "-- Tất cả --" });
        cboFilterPos.DataSource = positions;
        cboFilterPos.DisplayMember = "PositionName";
        cboFilterPos.ValueMember = "Id";
    }

    private void LoadData()
    {
        string keyword = txtSearch.Text.Trim();

        // Lấy giá trị từ các ô lọc nâng cao
        int? deptId = (cboFilterDept.SelectedValue is int dId && dId > 0) ? dId : null;
        int? posId = (cboFilterPos.SelectedValue is int pId && pId > 0) ? pId : null;

        var result = _employeeService.Search(keyword, deptId, posId);

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

    // Sự kiện khi thay đổi Combobox -> Tự động tìm kiếm luôn
    private void OnFilterChanged(object sender, EventArgs e)
    {
        LoadData();
    }

    private void btnSearch_Click(object sender, EventArgs e)
    {
        LoadData();
    }

    private void txtSearch_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            btnSearch.PerformClick();
            e.SuppressKeyPress = true;
        }
    }

    private void btnLoad_Click(object sender, EventArgs e)
    {
        txtSearch.Text = string.Empty;
        cboFilterDept.SelectedIndex = 0;
        cboFilterPos.SelectedIndex = 0;
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

        if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        {
            try
            {
                _employeeService.Delete(id);
                LoadData();
                MessageBox.Show("Xóa thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

    private void btnExport_Click(object sender, EventArgs e)
    {
        using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "CSV File|*.csv", FileName = "DanhSachNhanVien.csv" })
        {
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(sfd.FileName, false, System.Text.Encoding.UTF8))
                    {
                        sw.WriteLine("Mã NV,Họ Tên,Email,SĐT,Phòng Ban,Chức Vụ,Ngày Sinh");

                        // Lấy danh sách đang hiển thị hiện tại (đã lọc)
                        string keyword = txtSearch.Text.Trim();
                        int? deptId = (cboFilterDept.SelectedValue is int dId && dId > 0) ? dId : null;
                        int? posId = (cboFilterPos.SelectedValue is int pId && pId > 0) ? pId : null;
                        var list = _employeeService.Search(keyword, deptId, posId);

                        foreach (var emp in list)
                        {
                            string line = $"{emp.EmployeeCode},\"{emp.FullName}\",{emp.Email},{emp.Phone},\"{emp.Department?.DepartmentName}\",\"{emp.Position?.PositionName}\",{emp.DateOfBirth:dd/MM/yyyy}";
                            sw.WriteLine(line);
                        }
                    }
                    MessageBox.Show("Xuất file thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lưu file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
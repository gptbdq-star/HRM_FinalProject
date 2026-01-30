using Application.Interfaces;
using Domain.Entities;
using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;  // ✅ THÊM DÒNG NÀY

namespace UI;

public partial class UserForm : Form
{
    private readonly IUnitOfWork _unitOfWork;

    public UserForm(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        InitializeComponent();
        LoadData();
        LoadRoles();
    }

    private void LoadData()
    {
        try
        {
            // ✅ FIX: Dùng Query() với Include() thay vì GetAll()
            var users = _unitOfWork.Users
                .Query()  // hoặc .GetQueryable()
                .Include(u => u.Role)
                .Include(u => u.Employee)
                .ToList();

            dgvUsers.DataSource = users
                .Select(u => new
                {
                    u.Id,
                    u.Username,
                    Role = u.Role?.Name ?? "N/A",  // ✅ Null-safe với ??
                    Employee = u.Employee?.FullName ?? "Admin"
                })
                .ToList();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi load dữ liệu: {ex.Message}\n\n{ex.StackTrace}",
                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void LoadRoles()
    {
        try
        {
            cboRole.DataSource = _unitOfWork.Roles.GetAll().ToList();
            cboRole.DisplayMember = "Name";
            cboRole.ValueMember = "Id";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi load roles: {ex.Message}",
                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnResetPassword_Click(object sender, EventArgs e)
    {
        if (dgvUsers.CurrentRow == null)
        {
            MessageBox.Show("Vui lòng chọn user cần reset", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        int id = (int)dgvUsers.CurrentRow.Cells["Id"].Value;

        // ✅ THÊM CONFIRMATION
        var result = MessageBox.Show(
            "Bạn có chắc muốn reset mật khẩu về 123456?",
            "Xác nhận",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (result != DialogResult.Yes) return;

        try
        {
            var user = _unitOfWork.Users.GetById(id);
            if (user == null)
            {
                MessageBox.Show("User không tồn tại", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword("123456");
            _unitOfWork.Users.Update(user);
            _unitOfWork.Save();

            MessageBox.Show("Reset mật khẩu thành công! Mật khẩu mới: 123456",
                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi reset password: {ex.Message}",
                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnChangeRole_Click(object sender, EventArgs e)
    {
        if (dgvUsers.CurrentRow == null)
        {
            MessageBox.Show("Vui lòng chọn user cần đổi quyền", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (cboRole.SelectedValue == null)
        {
            MessageBox.Show("Vui lòng chọn role", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        int id = (int)dgvUsers.CurrentRow.Cells["Id"].Value;

        try
        {
            var user = _unitOfWork.Users.GetById(id);
            if (user == null)
            {
                MessageBox.Show("User không tồn tại", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int roleId = (int)cboRole.SelectedValue;

            // ✅ THÊM VALIDATION: Không cho đổi role của chính mình
            if (user.Id == Session.CurrentUser?.Id)
            {
                MessageBox.Show("Không thể đổi quyền của chính mình!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            user.RoleId = roleId;
            _unitOfWork.Users.Update(user);
            _unitOfWork.Save();

            MessageBox.Show("Đổi quyền thành công!", "Thành công",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadData();  // Refresh grid
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi đổi quyền: {ex.Message}",
                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
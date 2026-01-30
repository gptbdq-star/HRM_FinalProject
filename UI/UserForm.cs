using Application.Interfaces;
using Domain.Entities;
using System;
using System.Linq;
using System.Windows.Forms;

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
        dgvUsers.DataSource = _unitOfWork.Users.GetAll()
            .Select(u => new
            {
                u.Id,
                u.Username,
                Role = u.Role.Name,
                Employee = u.Employee != null ? u.Employee.FullName : "Admin"
            })
            .ToList();
    }

    private void LoadRoles()
    {
        cboRole.DataSource = _unitOfWork.Roles.GetAll().ToList();
        cboRole.DisplayMember = "Name";
        cboRole.ValueMember = "Id";
    }

    private void btnResetPassword_Click(object sender, EventArgs e)
    {
        if (dgvUsers.CurrentRow == null) return;

        int id = (int)dgvUsers.CurrentRow.Cells["Id"].Value;
        var user = _unitOfWork.Users.GetById(id);

        if (user == null)
        {
            MessageBox.Show("User không tồn tại");
            return;
        }

        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword("123456");
        _unitOfWork.Users.Update(user);
        _unitOfWork.Save();

        MessageBox.Show("Reset mật khẩu về 123456");
    }

    private void btnChangeRole_Click(object sender, EventArgs e)
    {
        if (dgvUsers.CurrentRow == null) return;

        int id = (int)dgvUsers.CurrentRow.Cells["Id"].Value;
        var user = _unitOfWork.Users.GetById(id);

        if (user == null)
        {
            MessageBox.Show("User không tồn tại");
            return;
        }

        int roleId = (int)cboRole.SelectedValue;
        user.RoleId = roleId;

        _unitOfWork.Users.Update(user);
        _unitOfWork.Save();

        LoadData();
    }
}

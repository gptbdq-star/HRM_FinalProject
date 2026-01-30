using System;
using System.Windows.Forms;
using Application.Interfaces;
using BCrypt.Net;

namespace UI;

public partial class ChangePasswordForm : Form
{
    private readonly IUnitOfWork _unitOfWork;

    public ChangePasswordForm(IUnitOfWork unitOfWork)
    {
        InitializeComponent();
        _unitOfWork = unitOfWork;
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        var user = Session.CurrentUser;
        if (user == null)
        {
            MessageBox.Show("Phiên đăng nhập đã hết hạn");
            Close();
            return;
        }

        if (string.IsNullOrWhiteSpace(txtOldPassword.Text) ||
            string.IsNullOrWhiteSpace(txtNewPassword.Text) ||
            string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
        {
            MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            return;
        }

        if (txtNewPassword.Text != txtConfirmPassword.Text)
        {
            MessageBox.Show("Xác nhận mật khẩu không khớp");
            return;
        }

        // ✅ KIỂM TRA MẬT KHẨU CŨ (HASH)
        if (!BCrypt.Net.BCrypt.Verify(txtOldPassword.Text, user.PasswordHash))
        {
            MessageBox.Show("Mật khẩu cũ không đúng");
            return;
        }

        // ✅ HASH MẬT KHẨU MỚI
        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(txtNewPassword.Text);

        _unitOfWork.Users.Update(user);
        _unitOfWork.Save();

        MessageBox.Show("Đổi mật khẩu thành công");
        Close();
    }
}

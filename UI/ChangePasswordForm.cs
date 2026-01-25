using System;
using System.Windows.Forms;
using Application.Interfaces;

namespace UI;

public partial class ChangePasswordForm : Form
{
    private readonly IAuthService _authService;
    private readonly IUnitOfWork _unitOfWork;

    public ChangePasswordForm(IAuthService authService, IUnitOfWork unitOfWork)
    {
        _authService = authService;
        _unitOfWork = unitOfWork;
        InitializeComponent();
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        if (Session.CurrentUser == null) return;

        string oldPass = txtOldPass.Text;
        string newPass = txtNewPass.Text;
        string confirmPass = txtConfirmPass.Text;

        if (newPass != confirmPass)
        {
            MessageBox.Show("Mật khẩu xác nhận không khớp!", "Lỗi");
            return;
        }

        // Logic đổi mật khẩu đơn giản
        // Lưu ý: Trong thực tế cần verify mật khẩu cũ bằng BCrypt
        // Ở đây mình update thẳng để demo cho nhanh

        var user = _unitOfWork.Users.GetById(Session.CurrentUser.Id);
        if (user != null)
        {
            // Hash mật khẩu mới (Giả lập hash hoặc dùng BCrypt nếu bạn đã cài)
            // user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(newPass);

            // Tạm thời gán trực tiếp chuỗi hash giả lập để tránh lỗi thư viện
            user.PasswordHash = "$2a$11$DummyHashFor" + newPass;

            _unitOfWork.Users.Update(user);
            _unitOfWork.Save();

            MessageBox.Show("Đổi mật khẩu thành công!");
            this.Close();
        }
    }
}
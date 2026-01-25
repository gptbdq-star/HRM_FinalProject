using System;
using System.Windows.Forms;
using Application.Interfaces;
using Domain.Entities;

namespace UI;

public partial class LoginForm : Form
{
    private readonly IAuthService _authService;

    public User? LoggedInUser { get; private set; }

    public LoginForm(IAuthService authService)
    {
        _authService = authService;
        InitializeComponent();
    }

    private void btnLogin_Click(object sender, EventArgs e)
    {
        var user = _authService.Login(
            txtUsername.Text.Trim(),
            txtPassword.Text.Trim());

        if (user == null)
        {
            MessageBox.Show("Sai tài khoản hoặc mật khẩu");
            return;
        }

        LoggedInUser = user;
        DialogResult = DialogResult.OK;
    }
}

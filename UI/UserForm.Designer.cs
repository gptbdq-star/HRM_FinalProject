namespace UI
{
    partial class UserForm
    {
        private System.ComponentModel.IContainer components = null;

        private DataGridView dgvUsers;
        private GroupBox grpAction;
        private Label lblRole;
        private ComboBox cboRole;
        private Button btnChangeRole;
        private Button btnResetPassword;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvUsers = new DataGridView();
            grpAction = new GroupBox();
            lblRole = new Label();
            cboRole = new ComboBox();
            btnChangeRole = new Button();
            btnResetPassword = new Button();

            // ===== DATAGRID =====
            dgvUsers.Dock = DockStyle.Top;
            dgvUsers.Height = 280;
            dgvUsers.ReadOnly = true;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.MultiSelect = false;

            // ===== GROUP ACTION =====
            grpAction.Text = "Phân quyền & Bảo mật";
            grpAction.Dock = DockStyle.Fill;

            // Label Role
            lblRole.Text = "Role:";
            lblRole.Location = new Point(30, 40);
            lblRole.AutoSize = true;

            // Combo Role
            cboRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRole.Location = new Point(80, 36);
            cboRole.Width = 180;

            // Button Change Role
            btnChangeRole.Text = "Đổi quyền";
            btnChangeRole.Location = new Point(280, 34);
            btnChangeRole.Width = 120;
            btnChangeRole.Click += btnChangeRole_Click;

            // Button Reset Password
            btnResetPassword.Text = "Reset mật khẩu (123456)";
            btnResetPassword.Location = new Point(80, 80);
            btnResetPassword.Width = 200;
            btnResetPassword.BackColor = System.Drawing.Color.LightSalmon;
            btnResetPassword.Click += btnResetPassword_Click;

            // Add controls
            grpAction.Controls.Add(lblRole);
            grpAction.Controls.Add(cboRole);
            grpAction.Controls.Add(btnChangeRole);
            grpAction.Controls.Add(btnResetPassword);

            Controls.Add(grpAction);
            Controls.Add(dgvUsers);

            Text = "Quản lý tài khoản";
            ClientSize = new Size(700, 420);
            StartPosition = FormStartPosition.CenterScreen;
        }
    }
}

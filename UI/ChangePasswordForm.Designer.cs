namespace UI
{
    partial class ChangePasswordForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOldPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Button btnSave;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOldPassword = new System.Windows.Forms.TextBox();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.label1.Text = "Mật khẩu cũ";
            this.label1.Location = new System.Drawing.Point(20, 20);

            this.label2.Text = "Mật khẩu mới";
            this.label2.Location = new System.Drawing.Point(20, 60);

            this.label3.Text = "Xác nhận mật khẩu";
            this.label3.Location = new System.Drawing.Point(20, 100);

            this.txtOldPassword.Location = new System.Drawing.Point(160, 20);
            this.txtOldPassword.PasswordChar = '*';

            this.txtNewPassword.Location = new System.Drawing.Point(160, 60);
            this.txtNewPassword.PasswordChar = '*';

            this.txtConfirmPassword.Location = new System.Drawing.Point(160, 100);
            this.txtConfirmPassword.PasswordChar = '*';

            this.btnSave.Text = "Lưu";
            this.btnSave.Location = new System.Drawing.Point(160, 140);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.ClientSize = new System.Drawing.Size(360, 190);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                label1, label2, label3,
                txtOldPassword, txtNewPassword, txtConfirmPassword,
                btnSave
            });

            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đổi mật khẩu";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

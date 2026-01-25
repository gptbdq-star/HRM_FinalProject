namespace UI
{
    partial class PositionEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtLevel;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ErrorProvider errorProvider1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtLevel = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(20, 20);
            this.lblName.Text = "Tên chức vụ";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(140, 17);
            this.txtName.Size = new System.Drawing.Size(250, 23);
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Location = new System.Drawing.Point(20, 60);
            this.lblLevel.Text = "Cấp bậc";
            // 
            // txtLevel
            // 
            this.txtLevel.Location = new System.Drawing.Point(140, 57);
            this.txtLevel.Size = new System.Drawing.Size(250, 23);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(140, 100);
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(240, 100);
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // PositionEditForm
            // 
            this.ClientSize = new System.Drawing.Size(420, 150);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtLevel);
            this.Controls.Add(this.lblLevel);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Text = "Chức vụ";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

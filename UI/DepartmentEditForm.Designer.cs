namespace UI
{
    partial class DepartmentEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ComboBox cboParent;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblParent;
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
            this.cboParent = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.lblParent = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(20, 20);
            this.lblName.Text = "Tên phòng ban";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(140, 17);
            this.txtName.Size = new System.Drawing.Size(250, 23);
            // 
            // lblParent
            // 
            this.lblParent.AutoSize = true;
            this.lblParent.Location = new System.Drawing.Point(20, 60);
            this.lblParent.Text = "Phòng ban cha";
            // 
            // cboParent
            // 
            this.cboParent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboParent.Location = new System.Drawing.Point(140, 57);
            this.cboParent.Size = new System.Drawing.Size(250, 23);
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
            // DepartmentEditForm
            // 
            this.ClientSize = new System.Drawing.Size(420, 150);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cboParent);
            this.Controls.Add(this.lblParent);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Text = "Phòng ban";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

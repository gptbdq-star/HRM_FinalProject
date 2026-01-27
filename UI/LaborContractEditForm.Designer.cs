namespace UI
{
    partial class LaborContractEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.ComboBox cboEmployee;
        private System.Windows.Forms.Label lblSalary;
        private System.Windows.Forms.TextBox txtSalary;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblCode = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.cboEmployee = new System.Windows.Forms.ComboBox();
            this.lblSalary = new System.Windows.Forms.Label();
            this.txtSalary = new System.Windows.Forms.TextBox();
            this.lblStart = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.lblEnd = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCode
            // 
            this.lblCode.Location = new System.Drawing.Point(30, 25);
            this.lblCode.Size = new System.Drawing.Size(100, 23);
            this.lblCode.Text = "Số hợp đồng:";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(140, 22);
            this.txtCode.Size = new System.Drawing.Size(200, 23);
            // 
            // lblEmployee
            // 
            this.lblEmployee.Location = new System.Drawing.Point(30, 65);
            this.lblEmployee.Size = new System.Drawing.Size(100, 23);
            this.lblEmployee.Text = "Nhân viên:";
            // 
            // cboEmployee
            // 
            this.cboEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmployee.Location = new System.Drawing.Point(140, 62);
            this.cboEmployee.Size = new System.Drawing.Size(200, 23);
            // 
            // lblSalary
            // 
            this.lblSalary.Location = new System.Drawing.Point(30, 105);
            this.lblSalary.Size = new System.Drawing.Size(100, 23);
            this.lblSalary.Text = "Lương cơ bản:";
            // 
            // txtSalary
            // 
            this.txtSalary.Location = new System.Drawing.Point(140, 102);
            this.txtSalary.Size = new System.Drawing.Size(200, 23);
            // 
            // lblStart
            // 
            this.lblStart.Location = new System.Drawing.Point(30, 145);
            this.lblStart.Size = new System.Drawing.Size(100, 23);
            this.lblStart.Text = "Ngày bắt đầu:";
            // 
            // dtpStart
            // 
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStart.Location = new System.Drawing.Point(140, 142);
            this.dtpStart.Size = new System.Drawing.Size(200, 23);
            // 
            // lblEnd
            // 
            this.lblEnd.Location = new System.Drawing.Point(30, 185);
            this.lblEnd.Size = new System.Drawing.Size(100, 23);
            this.lblEnd.Text = "Ngày kết thúc:";
            // 
            // dtpEnd
            // 
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnd.Location = new System.Drawing.Point(140, 182);
            this.dtpEnd.Size = new System.Drawing.Size(200, 23);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(140, 230);
            this.btnSave.Size = new System.Drawing.Size(90, 35);
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(250, 230);
            this.btnCancel.Size = new System.Drawing.Size(90, 35);
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // LaborContractEditForm
            // 
            this.ClientSize = new System.Drawing.Size(380, 290);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.lblEnd);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.txtSalary);
            this.Controls.Add(this.lblSalary);
            this.Controls.Add(this.cboEmployee);
            this.Controls.Add(this.lblEmployee);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.lblCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LaborContractEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thông tin Hợp đồng";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
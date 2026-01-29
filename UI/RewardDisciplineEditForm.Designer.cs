namespace UI
{
    partial class RewardDisciplineEditForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.ComboBox cboEmployee;

        private System.Windows.Forms.RadioButton rdoReward;
        private System.Windows.Forms.RadioButton rdoDiscipline;

        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.TextBox txtAmount;

        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDate;

        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.TextBox txtReason;

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblEmployee = new System.Windows.Forms.Label();
            this.cboEmployee = new System.Windows.Forms.ComboBox();
            this.rdoReward = new System.Windows.Forms.RadioButton();
            this.rdoDiscipline = new System.Windows.Forms.RadioButton();
            this.lblAmount = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblReason = new System.Windows.Forms.Label();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblEmployee
            // 
            this.lblEmployee.Location = new System.Drawing.Point(30, 30);
            this.lblEmployee.Size = new System.Drawing.Size(100, 23);
            this.lblEmployee.Text = "Nhân viên:";
            // 
            // cboEmployee
            // 
            this.cboEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmployee.Location = new System.Drawing.Point(140, 27);
            this.cboEmployee.Size = new System.Drawing.Size(220, 23);
            // 
            // rdoReward
            // 
            this.rdoReward.Location = new System.Drawing.Point(140, 65);
            this.rdoReward.Size = new System.Drawing.Size(100, 23);
            this.rdoReward.Text = "Khen thưởng";
            // 
            // rdoDiscipline
            // 
            this.rdoDiscipline.Location = new System.Drawing.Point(260, 65);
            this.rdoDiscipline.Size = new System.Drawing.Size(80, 23);
            this.rdoDiscipline.Text = "Kỷ luật";
            // 
            // lblAmount
            // 
            this.lblAmount.Location = new System.Drawing.Point(30, 105);
            this.lblAmount.Size = new System.Drawing.Size(100, 23);
            this.lblAmount.Text = "Số tiền:";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(140, 102);
            this.txtAmount.Size = new System.Drawing.Size(220, 23);
            // 
            // lblDate
            // 
            this.lblDate.Location = new System.Drawing.Point(30, 145);
            this.lblDate.Size = new System.Drawing.Size(100, 23);
            this.lblDate.Text = "Ngày quyết định:";
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(140, 142);
            this.dtpDate.Size = new System.Drawing.Size(220, 23);
            // 
            // lblReason
            // 
            this.lblReason.Location = new System.Drawing.Point(30, 185);
            this.lblReason.Size = new System.Drawing.Size(100, 23);
            this.lblReason.Text = "Lý do:";
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(140, 182);
            this.txtReason.Multiline = true;
            this.txtReason.Size = new System.Drawing.Size(220, 60);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(140, 260);
            this.btnSave.Size = new System.Drawing.Size(100, 35);
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(260, 260);
            this.btnCancel.Size = new System.Drawing.Size(100, 35);
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // RewardDisciplineEditForm
            // 
            this.ClientSize = new System.Drawing.Size(400, 320);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtReason);
            this.Controls.Add(this.lblReason);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.rdoDiscipline);
            this.Controls.Add(this.rdoReward);
            this.Controls.Add(this.cboEmployee);
            this.Controls.Add(this.lblEmployee);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Khen thưởng - Kỷ luật";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

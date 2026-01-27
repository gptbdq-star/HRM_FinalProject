namespace UI
{
    partial class LaborContractForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvContracts;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnAdd;

        // --- THÊM NÚT XÓA ---
        private System.Windows.Forms.Button btnDelete;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.dgvContracts = new System.Windows.Forms.DataGridView();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button(); // Khởi tạo nút xóa
            ((System.ComponentModel.ISupportInitialize)(this.dgvContracts)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvContracts
            // 
            this.dgvContracts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvContracts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvContracts.BackgroundColor = System.Drawing.Color.White;
            this.dgvContracts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContracts.Location = new System.Drawing.Point(12, 54);
            this.dgvContracts.MultiSelect = false;
            this.dgvContracts.Name = "dgvContracts";
            this.dgvContracts.ReadOnly = true;
            this.dgvContracts.RowHeadersVisible = false;
            this.dgvContracts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvContracts.Size = new System.Drawing.Size(760, 365);
            this.dgvContracts.TabIndex = 3;

            // --- ĐĂNG KÝ SỰ KIỆN DOUBLE CLICK ĐỂ SỬA ---
            this.dgvContracts.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvContracts_CellDoubleClick);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(12, 12);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(94, 29);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Làm mới";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(112, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(120, 29);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Thêm hợp đồng";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(238, 12); // Đặt cạnh nút Thêm
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(120, 29);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Xóa hợp đồng";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click); // Đăng ký sự kiện Click
            // 
            // LaborContractForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 431);
            this.Controls.Add(this.btnDelete); // Thêm nút xóa vào Form
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.dgvContracts);
            this.Name = "LaborContractForm";
            this.Text = "Danh sách Hợp đồng lao động";
            ((System.ComponentModel.ISupportInitialize)(this.dgvContracts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
namespace UI
{
    partial class EmployeeForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvEmployees;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnExport;

        // Thêm các control mới cho tìm kiếm nâng cao
        private System.Windows.Forms.ComboBox cboFilterDept;
        private System.Windows.Forms.ComboBox cboFilterPos;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Label lblDept;
        private System.Windows.Forms.Label lblPos;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.dgvEmployees = new System.Windows.Forms.DataGridView();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.cboFilterDept = new System.Windows.Forms.ComboBox();
            this.cboFilterPos = new System.Windows.Forms.ComboBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.lblDept = new System.Windows.Forms.Label();
            this.lblPos = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEmployees
            // 
            this.dgvEmployees.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEmployees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEmployees.Location = new System.Drawing.Point(12, 85);
            this.dgvEmployees.MultiSelect = false;
            this.dgvEmployees.RowHeadersVisible = false;
            this.dgvEmployees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmployees.Size = new System.Drawing.Size(760, 334);
            this.dgvEmployees.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmployees_CellDoubleClick);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(12, 12);
            this.btnLoad.Size = new System.Drawing.Size(90, 29);
            this.btnLoad.Text = "Làm mới";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(108, 12);
            this.btnAdd.Size = new System.Drawing.Size(90, 29);
            this.btnAdd.Text = "Thêm mới";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(204, 12);
            this.btnDelete.Size = new System.Drawing.Size(90, 29);
            this.btnDelete.Text = "Xóa";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(300, 12);
            this.btnExport.Size = new System.Drawing.Size(90, 29);
            this.btnExport.Text = "Xuất Excel";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // lblSearch
            // 
            this.lblSearch.Location = new System.Drawing.Point(12, 53);
            this.lblSearch.Size = new System.Drawing.Size(60, 23);
            this.lblSearch.Text = "Từ khóa:";
            this.lblSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(75, 53);
            this.txtSearch.Size = new System.Drawing.Size(150, 23);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(235, 53);
            this.lblDept.Size = new System.Drawing.Size(70, 23);
            this.lblDept.Text = "Phòng ban:";
            this.lblDept.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboFilterDept
            // 
            this.cboFilterDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterDept.Location = new System.Drawing.Point(305, 53);
            this.cboFilterDept.Size = new System.Drawing.Size(140, 23);
            this.cboFilterDept.SelectedIndexChanged += new System.EventHandler(this.OnFilterChanged);
            // 
            // lblPos
            // 
            this.lblPos.Location = new System.Drawing.Point(455, 53);
            this.lblPos.Size = new System.Drawing.Size(60, 23);
            this.lblPos.Text = "Chức vụ:";
            this.lblPos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboFilterPos
            // 
            this.cboFilterPos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterPos.Location = new System.Drawing.Point(515, 53);
            this.cboFilterPos.Size = new System.Drawing.Size(140, 23);
            this.cboFilterPos.SelectedIndexChanged += new System.EventHandler(this.OnFilterChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(670, 50);
            this.btnSearch.Size = new System.Drawing.Size(102, 29);
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // EmployeeForm
            // 
            this.ClientSize = new System.Drawing.Size(784, 431);
            this.Controls.Add(this.lblPos);
            this.Controls.Add(this.cboFilterPos);
            this.Controls.Add(this.lblDept);
            this.Controls.Add(this.cboFilterDept);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.dgvEmployees);
            this.Text = "Quản lý nhân viên - Tìm kiếm nâng cao";
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
using System;
using System.Linq;
using System.Windows.Forms;
using Application.Interfaces;

namespace UI;

public partial class DepartmentForm : Form
{
    private readonly IDepartmentService _departmentService;

    public DepartmentForm(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
        InitializeComponent();
    }

    private void btnLoad_Click(object sender, EventArgs e)
    {
        LoadDepartments();
    }

    private void LoadDepartments()
    {
        dgvDepartments.DataSource = _departmentService.GetAll()
            .Select(d => new
            {
                d.Id,
                d.DepartmentName,
                Parent = d.ParentDepartment != null
                    ? d.ParentDepartment.DepartmentName
                    : string.Empty
            })
            .ToList();
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        var frm = new DepartmentEditForm(_departmentService);
        if (frm.ShowDialog() == DialogResult.OK)
            LoadDepartments();
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (dgvDepartments.SelectedRows.Count == 0)
            return;

        var value = dgvDepartments.SelectedRows[0].Cells["Id"].Value;
        if (value is not int id)
            return;

        try
        {
            _departmentService.Delete(id);
            LoadDepartments();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void dgvDepartments_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0)
            return;

        var value = dgvDepartments.Rows[e.RowIndex].Cells["Id"].Value;
        if (value is not int id)
            return;

        var department = _departmentService.GetById(id);
        if (department == null)
            return;

        var frm = new DepartmentEditForm(_departmentService, department);
        if (frm.ShowDialog() == DialogResult.OK)
            LoadDepartments();
    }
}

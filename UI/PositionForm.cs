using System;
using System.Linq;
using System.Windows.Forms;
using Application.Interfaces;

namespace UI;

public partial class PositionForm : Form
{
    private readonly IPositionService _positionService;

    public PositionForm(IPositionService positionService)
    {
        _positionService = positionService;
        InitializeComponent();
    }

    private void btnLoad_Click(object sender, EventArgs e)
    {
        LoadPositions();
    }

    private void LoadPositions()
    {
        dgvPositions.DataSource = _positionService.GetAll()
            .Select(p => new
            {
                p.Id,
                p.PositionName,
                p.Level
            })
            .ToList();
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        var frm = new PositionEditForm(_positionService);
        if (frm.ShowDialog() == DialogResult.OK)
            LoadPositions();
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (dgvPositions.SelectedRows.Count == 0)
            return;

        var value = dgvPositions.SelectedRows[0].Cells["Id"].Value;
        if (value is not int id)
            return;

        try
        {
            _positionService.Delete(id);
            LoadPositions();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void dgvPositions_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0)
            return;

        var value = dgvPositions.Rows[e.RowIndex].Cells["Id"].Value;
        if (value is not int id)
            return;

        var position = _positionService.GetById(id);
        if (position == null)
            return;

        var frm = new PositionEditForm(_positionService, position);
        if (frm.ShowDialog() == DialogResult.OK)
            LoadPositions();
    }
}

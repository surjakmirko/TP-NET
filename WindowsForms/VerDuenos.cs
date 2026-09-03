using API;
using DTOs;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class VerDuenos : Form
    {
        public VerDuenos()
        {
            InitializeComponent();
        }
        private async void VerDuenos_Load(object sender, EventArgs e)
        {
            dgvDuenos.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvDuenos.ReadOnly = false;
            await CargarDuenosAsync();
            if (dgvDuenos.Columns["colEliminar"] != null)
            {
                dgvDuenos.Columns["colEliminar"].DisplayIndex = dgvDuenos.Columns.Count - 1;
            }
        }
        private async Task CargarDuenosAsync()
        {
            try
            {
                var listaDuenos = await UsuarioApiClient.GetAllDueno();
                dgvDuenos.DataSource = null;
                dgvDuenos.DataSource = listaDuenos;
                if (dgvDuenos.Columns["colEliminar"] != null)
                {
                    dgvDuenos.Columns["colEliminar"].DisplayIndex = dgvDuenos.Columns.Count - 1;
                }
                dgvDuenos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los dueños: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void dgvDuenos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (dgvDuenos.Columns[e.ColumnIndex].Name == "colEliminar")
            {
                int idDueno = 0;
                var row = dgvDuenos.Rows[e.RowIndex];
                if (row.DataBoundItem is UsuarioDTO usuarioDto)
                {
                    idDueno = usuarioDto.Id;
                }
                else if (row.Cells["Id"].Value != null)
                {
                    idDueno = Convert.ToInt32(row.Cells["Id"].Value);
                }
                if (idDueno == 0) return;
                DialogResult result = MessageBox.Show(
                    "¿Estás seguro de eliminar este dueño?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        await UsuarioApiClient.EliminarUsuarioAsync(idDueno);
                        MessageBox.Show("Dueño eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await CargarDuenosAsync();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al eliminar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private async void btnAgregarDueno_Click(object sender, EventArgs e)
        {
            using (AgregarDueno agregarDueno = new AgregarDueno())
            {
                var result = agregarDueno.ShowDialog();
                if (result == DialogResult.OK)
                {
                    await CargarDuenosAsync();
                }
            }
        }
        private void dgvDuenos_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            e.Cancel = true;
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

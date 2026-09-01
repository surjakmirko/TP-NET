using Data;
using DTOs;
using Modelo.Dominio;

namespace WindowsForms
{
    public partial class VerCanchas : Form
    {
        private readonly int _idComplejo;

        public VerCanchas(int idComplejo)
        {
            InitializeComponent();
            _idComplejo = idComplejo;
        }

        private void VerCanchas_Load(object sender, EventArgs e)
        {
            // Ajuste clave por código para asegurar que los botones reciban el clic
            dgvCanchas.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvCanchas.ReadOnly = false;

            CargarCanchasPorComplejo();
        }

        private async void CargarCanchasPorComplejo()
        {
            try
            {
                var listaCanchas = await CanchaRepositorioProvider.Instance.GetAllAsync(_idComplejo);
                dgvCanchas.AutoGenerateColumns = false;
                dgvCanchas.DataSource = null;
                dgvCanchas.DataSource = listaCanchas;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las canchas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void dgvCanchas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignorar clics en los encabezados
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            string nombreColumna = dgvCanchas.Columns[e.ColumnIndex].Name;

            // Intentamos obtener el objeto mediante DataBoundItem o leyendo la celda directamente
            var row = dgvCanchas.Rows[e.RowIndex];
            int nroCancha = 0;

            if (row.DataBoundItem is CanchaDTO cancha)
            {
                nroCancha = cancha.Nro;
            }
            else if (row.Cells["colNumero"].Value != null)
            {
                nroCancha = Convert.ToInt32(row.Cells["colNumero"].Value);
            }

            if (nroCancha == 0) return;

            // Acciones según la columna presionada
            if (nombreColumna == "colEditar")
            {
                //MessageBox.Show($"Editar Cancha N° {nroCancha}", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                using (var formEditar = new EditarCanchaForm(_idComplejo, nroCancha))
                {
                    var result = formEditar.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        // Si guardó correctamente en la base de datos, recargamos la grilla
                        CargarCanchasPorComplejo();
                    }
                }
            }
            else if (nombreColumna == "colEliminar")
            {
                var confirm = MessageBox.Show(
                    $"¿Estás seguro de que deseas eliminar la Cancha N° {nroCancha}?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirm == DialogResult.Yes)
                {
                    await EliminarCanchaAsync(nroCancha);
                }
            }
        }

        private async Task EliminarCanchaAsync(int nroCancha)
        {
            try
            {
                await CanchaRepositorioProvider.Instance.DeleteAsync(_idComplejo, nroCancha);
                MessageBox.Show($"La Cancha N° {nroCancha} fue eliminada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarCanchasPorComplejo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar eliminar la cancha: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
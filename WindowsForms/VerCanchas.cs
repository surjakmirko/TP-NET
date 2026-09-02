using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using API;
using DTOs;

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
            dgvCanchas.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvCanchas.ReadOnly = false;

            _ = CargarCanchasPorComplejoAsync();
        }
        private async Task CargarCanchasPorComplejoAsync()
        {
            try
            {
                // 1. Obtenemos las canchas y los tipos de cancha a través de la API
                var listaCanchas = await ComplejoApiClient.ObtenerCanchasAsync(_idComplejo);
                var listaTipos = await TipoCanchaApiClient.ObtenerTodosAsync();

                if (listaCanchas != null && listaTipos != null)
                {
                    var listaParaGrilla = listaCanchas.Select(c => new CanchaMostrarDTO
                    {
                        Nro = c.Nro,
                        TipoCanchaId = c.TipoCanchaId,
                        NombreTipoCancha = listaTipos.FirstOrDefault(t => t.Id == c.TipoCanchaId)?.Deporte ?? "Desconocido"
                    }).ToList();

                    dgvCanchas.AutoGenerateColumns = false;
                    dgvCanchas.DataSource = null;
                    dgvCanchas.DataSource = listaParaGrilla;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las canchas: {ex.Message}", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void dgvCanchas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            string nombreColumna = dgvCanchas.Columns[e.ColumnIndex].Name;
            var row = dgvCanchas.Rows[e.RowIndex];
            int nroCancha = 0;

            if (row.DataBoundItem is CanchaMostrarDTO cancha)
            {
                nroCancha = cancha.Nro;
            }
            else if (row.Cells["colNumero"].Value != null)
            {
                nroCancha = Convert.ToInt32(row.Cells["colNumero"].Value);
            }

            if (nroCancha == 0) return;

            if (nombreColumna == "colEditar")
            {
                using (var formEditar = new EditarCanchaForm(_idComplejo, nroCancha))
                {
                    var result = formEditar.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        await CargarCanchasPorComplejoAsync();
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
                    await EjecutarEliminacionCanchaAsync(nroCancha);
                }
            }
        }
        private async Task EjecutarEliminacionCanchaAsync(int nroCancha)
        {
            try
            {
                await ComplejoApiClient.EliminarCanchaAsync(_idComplejo, nroCancha);
                MessageBox.Show($"La Cancha N° {nroCancha} fue eliminada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await CargarCanchasPorComplejoAsync();
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
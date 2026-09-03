using API;
using DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class VerComplejos : Form
    {
        public VerComplejos()
        {
            InitializeComponent();
        }
        private async void VerComplejos_Load(object sender, EventArgs e)
        {

            dgvComplejos.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvComplejos.ReadOnly = false;

            await CargarComplejos();
        }

        private async Task CargarComplejos()
        {
            try
            {
                var listaComplejos = await ComplejoApiClient.ObtenerTodosAsync();
                dgvComplejos.AutoGenerateColumns = false;
                dgvComplejos.DataSource = null;
                dgvComplejos.DataSource = listaComplejos;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los complejos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void dgvComplejos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            string nombreColumna = dgvComplejos.Columns[e.ColumnIndex].Name;
            var row = dgvComplejos.Rows[e.RowIndex];
            int id = 0;

            if (row.DataBoundItem is ComplejoDTO complejo)
            {
                id = complejo.Id;
            }
            else if (row.Cells["colNumero"].Value != null)
            {
                id = Convert.ToInt32(row.Cells["colNumero"].Value);
            }
            if (id == 0) return;
            else if (nombreColumna == "colEliminar")
            {
                var confirm = MessageBox.Show(
                    $"¿Estás seguro de que deseas eliminar el Complejo N° {id}?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirm == DialogResult.Yes)
                {
                    await EliminarComplejoAsync(id);
                }
            }
        }

        private async Task EliminarComplejoAsync(int id)
        {
            try
            {
                await ComplejoApiClient.EliminarComplejoAsync(id);
                MessageBox.Show($"El Complejo N° {id} fue eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

               
                await CargarComplejos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar eliminar el Complejo N° {id}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnAgregarComplejo_Click(object sender, EventArgs e)
        {
            using (AgregarComplejo agregarComplejo = new AgregarComplejo())
            {
                
                var result = agregarComplejo.ShowDialog();

                if (result == DialogResult.OK)
                {
                    await CargarComplejos();
                }
            }
        }
    }
}


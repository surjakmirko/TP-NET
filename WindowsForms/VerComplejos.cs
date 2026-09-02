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
        private void VerComplejos_Load(object sender, EventArgs e)
        {

            dgvComplejos.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvComplejos.ReadOnly = false;

            CargarComplejos();
        }

        private async void CargarComplejos()
        {
            try
            {
                var listaComplejos = await ComplejoRepositorioProvider.Instance.GetAllAsync();
                var listaTipos = await TipoCanchaRepositorioProvider.Instance.GetAllAsync();

                // 3. Cruzamos los datos vinculando el ID con el Nombre
                var listaParaGrilla = listaComplejos.Select(c => new ComplejoDTO
                {
                    Id = c.Id,
                    Nombre = c.Nombre
                }).ToList();
                dgvComplejos.AutoGenerateColumns = false;
                dgvComplejos.DataSource = null;
                dgvComplejos.DataSource = listaParaGrilla;
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
                await ComplejoRepositorioProvider.Instance.DeleteAsync(id);
                MessageBox.Show($"El Complejo N° {id} fue eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarComplejos();
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

        private void btnAgregarComplejo_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (AgregarComplejo agregarComplejo = new AgregarComplejo())
            {
                var result = agregarComplejo.ShowDialog();
                if (result == DialogResult.OK)
                {
                    CargarComplejos();
                }
            }
        }
    }
}


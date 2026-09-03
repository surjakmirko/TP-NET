using System;
using System.Windows.Forms;
using DTOs;
using API;

namespace WindowsForms
{
    public partial class AgregarComplejo : Form
    {
        public AgregarComplejo()
        {
            InitializeComponent();
        }
        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                string.IsNullOrWhiteSpace(txtEncargadoId.Text) ||
                string.IsNullOrWhiteSpace(txtLocalidadId.Text) ||
                string.IsNullOrWhiteSpace(txtDueñoId.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtEncargadoId.Text, out int encargadoId) ||
                !int.TryParse(txtLocalidadId.Text, out int localidadId) ||
                !int.TryParse(txtDueñoId.Text, out int dueñoId))
            {
                MessageBox.Show("Los campos de ID deben ser valores numéricos enteros.", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ComplejoCrearDTO nuevoComplejo = new ComplejoCrearDTO
            {
                Nombre = txtNombre.Text.Trim(),
                Direccion = txtDireccion.Text.Trim(),
                EncargadoId = encargadoId,
                LocalidadId = localidadId,
                DueñoId = dueñoId
            };

            try
            {

                await ComplejoApiClient.CrearComplejoAsync(nuevoComplejo);

                MessageBox.Show("¡Complejo registrado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el complejo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
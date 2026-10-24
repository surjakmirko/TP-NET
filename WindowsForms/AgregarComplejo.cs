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
                int.IsPositive((int)nudIdEncargado.Value) ||
                int.IsPositive((int)nudIdLocalidad.Value) ||
                int.IsPositive((int)nudIdDueno.Value))
            {
                MessageBox.Show("Por favor, completa todos los campos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ComplejoCrearDTO nuevoComplejo = new ComplejoCrearDTO
            {
                Nombre = txtNombre.Text.Trim(),
                Direccion = txtDireccion.Text.Trim(),
                EncargadoId = (int)nudIdEncargado.Value,
                LocalidadId = (int)nudIdLocalidad.Value,
                DueñoId = (int)nudIdDueno.Value
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
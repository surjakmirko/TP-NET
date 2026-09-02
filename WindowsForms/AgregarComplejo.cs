using System;
using System.Windows.Forms;
using DTOs; // Asegúrate de tener el namespace de tu ComplejoDTO

namespace WindowsForms
{
    public partial class AgregarComplejo : Form
    {
        public AgregarComplejo()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validaciones básicas de campos vacíos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                string.IsNullOrWhiteSpace(txtEncargadoId.Text) ||
                string.IsNullOrWhiteSpace(txtLocalidadId.Text) ||
                string.IsNullOrWhiteSpace(txtDueñoId.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar que los IDs sean números enteros válidos
            if (!int.TryParse(txtEncargadoId.Text, out int encargadoId) ||
                !int.TryParse(txtLocalidadId.Text, out int localidadId) ||
                !int.TryParse(txtDueñoId.Text, out int dueñoId))
            {
                MessageBox.Show("Los campos de ID deben ser valores numéricos enteros.", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Crear el objeto ComplejoDTO con los datos capturados
            ComplejoDTO nuevoComplejo = new ComplejoDTO
            {
                Nombre = txtNombre.Text.Trim(),
                Direccion = txtDireccion.Text.Trim(),
                EncargadoId = encargadoId,
                LocalidadId = localidadId,
                DueñoId = dueñoId
            };

            // AQUÍ INVOCAS A TU SERVICIO / CONTROLADOR:
            // _complejoService.Agregar(nuevoComplejo);

            MessageBox.Show("¡Complejo registrado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
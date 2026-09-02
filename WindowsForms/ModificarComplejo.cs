using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using API;
using DTOs;

namespace WindowsForms
{
    public partial class ModificarComplejo : Form
    {
        private int _idComplejoSeleccionado;
        private ComplejoDTO _complejoActual;

        public ModificarComplejo(int idComplejoSeleccionado)
        {
            InitializeComponent();
            _idComplejoSeleccionado = idComplejoSeleccionado;
            this.AcceptButton = btnAceptar;
        }

        private async Task MostrarDatosComplejoAsync()
        {
            try
            {
                _complejoActual = await ComplejoApiClient.ObtenerPorIdAsync(_idComplejoSeleccionado);

                if (_complejoActual != null)
                {
                    nombreActual.Text = $"Nombre actual: {_complejoActual.Nombre}";
                    direccionActual.Text = $"Dirección actual: {_complejoActual.Direccion}";
                }
                else
                {
                    MessageBox.Show("No se encontró el complejo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al cargar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void ModificarComplejo_Load(object sender, EventArgs e)
        {
            await MostrarDatosComplejoAsync();
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_complejoActual == null) return;

                bool huboCambios = false;
                string nombreIngresado = nuevoNombre.Text.Trim();
                string direccionIngresada = nuevaDireccion.Text.Trim();

                if (!string.IsNullOrWhiteSpace(nombreIngresado))
                {
                    _complejoActual.Nombre = nombreIngresado;
                    huboCambios = true;
                }

                if (!string.IsNullOrWhiteSpace(direccionIngresada))
                {
                    _complejoActual.Direccion = direccionIngresada;
                    huboCambios = true;
                }

                if (!huboCambios)
                {
                    MessageBox.Show("No se realizaron cambios.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Enviamos los cambios a la WebAPI
                await ComplejoApiClient.ActualizarComplejoAsync(_complejoActual);

                MessageBox.Show("Complejo actualizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al actualizar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

using System;
using System.Windows.Forms;
using DTOs;
using API;

namespace WindowsForms
{
    public partial class AgregarDueno : Form
    {
        public AgregarDueno()
        {
            InitializeComponent();
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRazonSocial.Text) ||
                string.IsNullOrWhiteSpace(txtCuit.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos obligatorios.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var nuevaPersonaJuridica = new PersonaJuridicaDTO
            {
                Razon_Social = txtRazonSocial.Text.Trim(),
                Cuit = txtCuit.Text.Trim()
            };

            var nuevoUsuario = new UsuarioCrearDTO
            {
                Email = txtEmail.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                Password = txtPassword.Text.Trim(),
                PersonaJuridicaCuit = nuevaPersonaJuridica.Cuit,
                PersonaFisicaDni = null,
                TipoUsuarioId = 4
            };

            try
            {
                await API.PersonaJuridicaApiClient.CrearPersonaJuridicaAsync(nuevaPersonaJuridica);
                await API.UsuarioApiClient.CrearUsuarioAsync(nuevoUsuario);
                MessageBox.Show("¡Dueño registrado exitosamente vía API!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

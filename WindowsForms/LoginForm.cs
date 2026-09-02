using System;
using System.Windows.Forms;
using API;
using DTOs;

namespace WindowsForms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.AcceptButton = iniciarSesión;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
        }

        private async void IniciarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                string usuario = usuarioCaja.Text.Trim();
                string contraseña = contraseñaCaja.Text.Trim();

                if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contraseña))
                {
                    MessageBox.Show(
                        "Por favor, completá ambos campos para iniciar sesión.",
                        "Campos incompletos",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }
                var loginDto = new LoginDTO
                {
                    Email = usuario,
                    Password = contraseña
                };
                var resultadoLogin = await AutenticacionApi.LoginAsync(loginDto);
                if (resultadoLogin != null)
                {
                    int idBuscado = resultadoLogin.Id;
                    this.Hide();
                    MessageBox.Show("Inicio de sesión exitoso", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SeleccionarComplejo formSeleccion = new SeleccionarComplejo(idBuscado);
                    formSeleccion.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos", "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al intentar iniciar sesión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoginForm_Load_1(object sender, EventArgs e)
        {
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool _mostrarContrasena = false;

        private void mostrarPassword_Click(object sender, EventArgs e)
        {
            _mostrarContrasena = !_mostrarContrasena;
            contraseñaCaja.UseSystemPasswordChar = !_mostrarContrasena;
        }
    }
}

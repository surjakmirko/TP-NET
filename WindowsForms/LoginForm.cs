using Data;
using Microsoft.Extensions.Options;
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
                string usuario = usuarioCaja.Text;
                string contraseña = contraseñaCaja.Text;

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
                    int idBuscado = await UsuarioRepositorioProvider.Instance.IniciarSesion(usuario, contraseña);
                if (idBuscado != 0)
                {
                    this.Hide();
                    MessageBox.Show("Inicio de sesión exitoso");
                    SeleccionarComplejo formSeleccion = new SeleccionarComplejo(idBuscado);
                    formSeleccion.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}");
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

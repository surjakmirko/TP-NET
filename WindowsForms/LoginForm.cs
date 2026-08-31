using Data;
using Microsoft.Extensions.Options;
namespace WindowsForms
{
    public partial class LoginForm : Form
    {
        private readonly UsuarioRepositorio usuarioRepositorio;
        public LoginForm()
        {
            InitializeComponent();
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
                // Aquí puedes agregar la lógica para validar el usuario y la contraseña
                if (await UsuarioRepositorioProvider.Instance.IniciarSesion(usuario, contraseña) != 0)
                {
                    MessageBox.Show("Inicio de sesión exitoso");
                    // Aquí puedes abrir el formulario principal de la aplicación
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
    }
}

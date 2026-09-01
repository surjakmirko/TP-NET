using Data;
using Microsoft.Extensions.Options;
namespace WindowsForms
{
    public partial class LoginForm : Form
    {
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
    }
}


using Modelo.Dominio;

namespace Data
{
    public class UsuarioRepositorio: IUsuarioRepositorio
    {
        private static readonly List<Usuario> usuarios = new List<Usuario>();
        public static int ObtenerProximoId()
        {
            if (usuarios.Count() == 0)
            {
                return 1;
            }
            else
                return (usuarios.Max(x => x.Id) + 1);
        }
        public Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<Usuario>>(usuarios.ToList());
        }

        public Task<bool> DeleteAsync(int id)
        {
            var usuario = usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario != null)
            {
                usuarios.Remove(usuario);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        public Task AddAsync(Usuario usuario)
        {
            int id = ObtenerProximoId();
            usuario.SetId(id);

            var tipousuario = new TipoUsuarioRepositorio();
            var tipo = tipousuario.GetAsync(usuario.Id);
            if (tipo != null)
                usuario.SetTipoUsuario(tipo);
            usuarios.Add(usuario);
            return Task.FromResult(true);
        }

        public Task<Usuario?> GetAsync(int id)
        {
            return Task.FromResult(usuarios.FirstOrDefault(u => u.Id == id));
        }

        public Task<bool> UpdateAsync(Usuario usuario)
        {
            var existe = usuarios.FirstOrDefault(u => u.Id == usuario.Id);
            if (existe != null)
            {
                existe.SetEmail(usuario.Email);
                existe.SetTelefono(usuario.Telefono);
                existe.SetPassword(usuario.Password);
                if(usuario.Id== 2)
                {
                    existe.SetNombre(usuario.Nombre);
                    existe.SetApellido(usuario.Apellido);
                    existe.SetFechaNacimiento(usuario.Fecha_Nacimiento);
                }
                if (usuario.Id == 3)
                {
                    existe.SetRazonSocial(usuario.Razon_Social);
                    existe.SetCuit(usuario.Cuit);
                }

                var tipousuario = new TipoUsuarioRepositorio();
                var tipo = tipousuario.GetAsync(usuario.Id);
                if (tipo != null)
                    usuario.SetTipoUsuario(tipo);

                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        public Task<bool> EmailExistsAsync (string email)
        {
            bool existe = usuarios.Any(u => u.Email.ToLower() == email.ToLower());
            return Task.FromResult(existe);
        }

    }
}

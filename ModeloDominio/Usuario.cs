
namespace Modelo.Dominio
{
    public class Usuario
    {
        public int Id { get; private set; }
        public string Email { get; private set; }
        public string Telefono { get; private set; }
        public string Password { get; private set; }
        public string Nombre { get; private set; }
        public string Apellido { get; private set; }
        public string Razon_Social { get; private set; }
        public DateOnly Fecha_Nacimiento { get; private set; }

        private int _tipoUsuarioId;
        private TipoUsuario? _tipoUsuario;
        public int TipoUsuarioId
        {
            get => _tipoUsuario?.Id ?? _tipoUsuarioId;
            private set => _tipoUsuarioId = value;
        }
        public TipoUsuario? TipoUsuario
        {
            get => _tipoUsuario;
            private set
            {
                _tipoUsuario = value;
                if (value != null)
                {
                    _tipoUsuarioId = value.Id;
                }
            }
        }
        public Usuario(int id, string email, string telefono, string password, int tipoUsuarioId)
        {
            SetId(id);
            SetEmail(email);
            SetTelefono(telefono);
            SetPassword(password);
            SetTipoUsuarioId(tipoUsuarioId);
        }
        public Usuario(int id, string email, string telefono, string password, int tipoUsuarioId, string nombre, string apellido, DateOnly fechaNacimiento)
        {
            SetId(id);
            SetEmail(email);
            SetTelefono(telefono);
            SetPassword(password);
            SetTipoUsuarioId(tipoUsuarioId);
            SetNombre(nombre);
            SetApellido(apellido);
            SetFechaNacimiento(fechaNacimiento);
        }
        public Usuario(int id, string email, string telefono, string password, int tipoUsuarioId, string razonSocial)
        {
            SetId(id);
            SetEmail(email);
            SetTelefono(telefono);
            SetPassword(password);
            SetTipoUsuarioId(tipoUsuarioId);
            SetRazonSocial(razonSocial);
        }
        public void SetId(int id)
        {
            if (id < 0)
                throw new ArgumentException("El Id debe ser mayor que 0.", nameof(id));
            Id = id;
        }
        public void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("El email del usuario no puede ser nulo o vacío.", nameof(email));
            Email = email;
        }
        public void SetTelefono(string telefono)
        {
            if (string.IsNullOrWhiteSpace(telefono))
                throw new ArgumentException("El telefono del usuario no puede ser nulo o vacío.", nameof(telefono));
            Telefono = telefono;
        }
        public void SetPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("La contraseña del usuario no puede ser nulo o vacío.", nameof(password));
            Password = password;
        }
        public void SetTipoUsuarioId(int tipoUsuarioId)
        {
            if (tipoUsuarioId < 0)
                throw new ArgumentException("El tipo de usuario debe ser mayor que 0.", nameof(tipoUsuarioId));
            TipoUsuarioId = tipoUsuarioId;
        }
        public void SetTipoUsuario(TipoUsuario tipoUsuario)
        {
            if(tipoUsuario == null)
                ArgumentNullException.ThrowIfNull(tipoUsuario);
            _tipoUsuario = tipoUsuario;
            _tipoUsuarioId = tipoUsuario.Id;
        }
        public void SetNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre del usuario no puede ser nulo o vacío.", nameof(nombre));
            Nombre = nombre;
        }
        public void SetApellido(string apellido)
        {
            if (string.IsNullOrWhiteSpace(apellido))
                throw new ArgumentException("El apellido del usuario no puede ser nulo o vacío.", nameof(apellido));
            Apellido = apellido;
        }
        public void SetRazonSocial(string razonSocial)
        {
            if (string.IsNullOrWhiteSpace(razonSocial))
                throw new ArgumentException("La razón social del usuario no puede ser nula o vacía.", nameof(razonSocial));
            Razon_Social = razonSocial;
        }
        public void SetFechaNacimiento(DateOnly fechaNacimiento)
        {
            Fecha_Nacimiento = fechaNacimiento;
        }
    }
}

namespace Modelo.Dominio
{
    public class Usuario
    {
        public int Id { get; private set; }
        public string Email { get; private set; }
        public string Telefono { get; private set; }
        public string Password { get; private set; }

        //foraing key
        public int TipoUsuarioId { get; set; }
        public TipoUsuario TipoUsuario { get; set; } = null!;

        public string? PersonaFisicaDni { get; set; }

        public PersonaFisica? PersonaFisica { get; set; }

        public string? PersonaJuridicaCuit { get; set; }

        public PersonaJuridica? PersonaJuridica { get; set; }

        //si un usuario tiene varios complejos
        public ICollection<Complejo> Complejos { get; set; } = new List<Complejo>();

        // si un usuario (encargado) 
        public Complejo Complejo { get; set; }

        // si un usuario (cliente)
        public ICollection<Turno> Turnos { get; set; } = new List<Turno>();



        public Usuario(int id, string email, string telefono, string password, int tipoUsuarioId, string personaFisicaDni,string personaJuridicaCuit)
        {
            SetId(id);
            SetEmail(email);
            SetTelefono(telefono);
            SetPassword(password);
            SetTipoUsuarioId(tipoUsuarioId);
            SetPersonaFisicaDni(personaFisicaDni);
            SetPersonaJuridicaCuit(personaJuridicaCuit);


        }


        public void SetId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El Id debe ser mayor que 0.", nameof(id));
            Id = id;
        }
        public void SetEmail(string email)
        {
            if (!EsEmailValido(email))
                throw new ArgumentException("El email no tiene un formato válido.", nameof(email));
            Email = email;
        }

        private static bool EsEmailValido(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
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
            if (tipoUsuarioId <= 0)
                throw new ArgumentException("El tipo de usuario debe ser mayor que 0.", nameof(tipoUsuarioId));
            TipoUsuarioId = tipoUsuarioId;
        }
        public void SetPersonaFisicaDni(string personafisicadni)
        {
            if (personafisicadni.Length < 8)
                throw new ArgumentException("La longitud del dni debe ser mayor a 8 caracteres", nameof(personafisicadni));
            PersonaFisicaDni = personafisicadni;
        }
        public void SetPersonaJuridicaCuit(string personajuridicacuit)
        {
            if (personajuridicacuit.Length <11)
                throw new ArgumentException("La longitud del cuit debe ser mayor a 11 caracteres", nameof(personajuridicacuit));
            PersonaJuridicaCuit = personajuridicacuit;
        }
    }
}
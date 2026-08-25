namespace DTOs
{
    public class UsuarioDTO
    {
        public int Id { get;  set; }
        public string Email { get;  set; }
        public string Telefono { get;  set; }
        public string Password { get;  set; }
        public string? PersonaFisicaDni { get;  set; }
        public string? PersonaJuridicaCuit { get;  set; }
        public int TipoUsuarioId { get;  set; }
        public string? TipoUsuarioNombre { get;  set; }

    }
}

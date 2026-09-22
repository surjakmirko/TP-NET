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
        public int TipoUsuarioId { get; set; }
        public string Rol { get; set; } = string.Empty;
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }


    }

    public class UsuarioCrearDTO
    {
        public string Email { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty; 
        public string Password { get; set; } = string.Empty;
        public string? PersonaFisicaDni { get; set; } = string.Empty;
        public string? PersonaJuridicaCuit { get; set; } = string.Empty;
        public int TipoUsuarioId { get; set; }

    }
}

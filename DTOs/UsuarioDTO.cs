namespace DTOs
{
    public class UsuarioDTO
    {
        public int Id { get;  set; }
        public string Email { get;  set; }
        public string Telefono { get;  set; }
        public string Password { get;  set; }
        public string Nombre { get;  set; }
        public string Apellido { get;  set; }
        public string Razon_Social { get;  set; }
        public string Cuit { get;  set; }
        public DateOnly Fecha_Nacimiento { get;  set; }
        public int TipoUsuarioId { get;  set; }

        public string? TipoUsuarioNombre { get;  set; }

    }
}

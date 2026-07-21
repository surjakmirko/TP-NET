namespace DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; private set; }
        public string Email { get; private set; }
        public string Telefono { get; private set; }
        public string Password { get; private set; }
        public string Nombre { get; private set; }
        public string Apellido { get; private set; }
        public string Razon_Social { get; private set; }
        public DateOnly Fecha_Nacimiento { get; private set; }
        public int TipoUsuarioId { get; private set; }

        public string? TipoUsuarioNombre { get; private set; }

    }
}

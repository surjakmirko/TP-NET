namespace DTOs
{
    public class TurnoDTO
    {
        public int Id { get;  set; }
        public TimeOnly HoraInicio { get;  set; }
        public TimeOnly HoraFin { get;  set; }
        public string Estado { get;  set; }
        public string? MotivoCancelacion { get;  set; }

        public int? ClienteId { get;  set; }
        public int TipoTurnoId { get;  set; }
        public int ComplejoId { get;  set; }
        public int CanchaNro { get;  set; }
        public DateOnly Fecha { get; set; }
        public UsuarioDTO? Cliente { get; set; } = null;
        public ComplejoDTO? Complejo { get; set; }
        public CanchaDTO? Cancha { get; set; }

        // Cliente externo (para turnos creados por encargado)
        public string? NombreClienteExterno { get;  set; }
        public string? ApellidoClienteExterno { get;  set; }
        public bool EsClienteExterno => !string.IsNullOrWhiteSpace(NombreClienteExterno);
        public string NombreCompletoCliente => EsClienteExterno 
            ? $"{NombreClienteExterno} {ApellidoClienteExterno}" 
            : (Cliente != null 
                ? (!string.IsNullOrEmpty(Cliente.Nombre) || !string.IsNullOrEmpty(Cliente.Apellido) 
                    ? $"{Cliente.Nombre} {Cliente.Apellido}".Trim() 
                    : (Cliente.PersonaFisica != null 
                        ? $"{Cliente.PersonaFisica.Nombre} {Cliente.PersonaFisica.Apellido}" 
                        : Cliente.PersonaJuridica?.Razon_Social ?? "Sin cliente"))
                : "Sin cliente");
    }

    public class TurnoCrearDTO
    {
        public TimeOnly HoraInicio { get; set; }
        public TimeOnly HoraFin { get; set; }
        public string Estado { get; set; }
        public string? MotivoCancelacion { get; set; }

        public int? ClienteId { get; set; }
        public int TipoTurnoId { get; set; }
        public int ComplejoId { get; set; }
        public int CanchaNro { get; set; }
        public DateOnly Fecha { get; set; }
    }

    public class TurnoCrearEncargadoDTO
    {
        public TimeOnly HoraInicio { get; set; }
        public TimeOnly HoraFin { get; set; }
        
        public string NombreCliente { get; set; } = string.Empty;
        public string ApellidoCliente { get; set; } = string.Empty;

        public int TipoTurnoId { get; set; }
        public int ComplejoId { get; set; }
        public int CanchaNro { get; set; }
        public DateOnly Fecha { get; set; }
    }

    public class CancelarTurnoDTO
    {
        public string? MotivoCancelacion { get; set; }
    }
}
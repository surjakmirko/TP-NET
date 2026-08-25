namespace DTOs
{
    public class TurnoDTO
    {
        public int Id { get;  set; }
        public TimeOnly HoraInicio { get;  set; }
        public TimeOnly HoraFin { get;  set; }
        public string Estado { get;  set; }
        public string? MotivoCancelacion { get;  set; }

        public int ClienteId { get;  set; }
        public int TipoTurnoId { get;  set; }
        public int ComplejoId { get;  set; }
        public int CanchaNro { get;  set; }
        public DateOnly Fecha { get; set; }
    }
}

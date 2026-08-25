
namespace DTOs
{
    public class HorarioDTO
    {
        public int ComplejoId { get; set; }
        public int NroDia { get; set; }
        public TimeOnly HoraApertura { get; set; }
        public TimeOnly HoraCierre { get; set; }
    }
}

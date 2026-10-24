namespace DTOs
{
    public class DashboardDuenoDTO
    {
        public decimal IngresosEstimados { get; set; }
        public int CantidadTurnos { get; set; }
        public int CantidadCanchas { get; set; }
        public double OcupacionPorcentaje { get; set; }
        public string? DeporteEstrellaNombre { get; set; }
        public int DeporteEstrellaReservas { get; set; }
    }
}

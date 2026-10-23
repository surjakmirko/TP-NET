namespace DTOs
{
    public class PayloadCanchaModal
    {
        //DTO para el front, en la parte del dueño 
        public string TipoAccion { get; set; } = string.Empty;
        public int CanchaNro { get; set; }
        public CanchaCrearDTO DatosCancha { get; set; } = new();
        public PrecioCrearDTO DatosPrecioCrear { get; set; } = new();
    }
}

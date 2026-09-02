

namespace DTOs
{
    public class CanchaDTO
    {
        public int Nro {  get; set; }
        public int ComplejoId {  get; set; }
        public int TipoCanchaId {  get; set; }
    }

    public class CanchaCrearDTO
    {
        public int Nro { get; set; }
        public int? ComplejoId { get; set; } = null;
        public int TipoCanchaId { get; set; }
    }

    //DTO PARA MOSTRAR EN WINDOWS FORM VER CANCHAS
    public class CanchaMostrarDTO
    {
        public int Nro { get; set; }
        public int TipoCanchaId { get; set; }
        public string NombreTipoCancha { get; set; }
    }
}

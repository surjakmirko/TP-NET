
namespace DTOs
{
    public class ComplejoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int EncargadoId { get; set; }
        public int LocalidadId {  get; set; }
        public int DueñoId {  get; set; }
        
    }

    public class ComplejoCrearDTO
    {
        public string Nombre { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public int EncargadoId { get; set; }
        public int LocalidadId { get; set; }
        public int DueñoId { get; set; }

    }
}

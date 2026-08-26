namespace Modelo.Dominio
{
    public class Localidad
    {
        public int Id { get; private set; }
        public string Nombre { get; private set; }
        public string CodigoPostal { get; private set; }

        public int ProvinciaId { get; private set; }
        public Provincia Provincia { get; set; } = null!;

        public ICollection<Complejo> Complejos { get; set; } = new List<Complejo>();

        public Localidad(int id, string nombre, string codigoPostal, int provinciaId)
        {
            SetId(id);
            SetNombre(nombre);
            setCodigoPostal(codigoPostal);
            SetProvinciaId(provinciaId);
        }

        public void SetId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El Id debe ser mayor que 0.", nameof(id));
            Id = id;
        }

        public void SetNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre de la localidad no puede ser nulo o vacío.", nameof(nombre));
            Nombre = nombre;
        }

        public void setCodigoPostal(string codigopostal)
        {
            if (string.IsNullOrWhiteSpace(codigopostal))
                throw new ArgumentException("El codigo postal no puede ser nulo o vacio", nameof(codigopostal));
            CodigoPostal = codigopostal;
        }

        public void SetProvinciaId(int provinciaId)
        {
            if (provinciaId <= 0)
                throw new ArgumentException("El id de la provincia no puede ser nul o vacio", nameof(provinciaId));
            ProvinciaId = provinciaId;
        }
    }
}

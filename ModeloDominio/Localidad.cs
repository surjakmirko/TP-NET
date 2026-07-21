namespace Modelo.Dominio
{
    public class Localidad
    {
        public int Id { get; private set; }
        public string Nombre { get; private set; }

        public string CodigoPostal { get; private set; }

        private int _provinciaId;
        private Provincia? _provincia;

        public int ProvinciaId
        {
            get => _provincia?.Id ?? _provinciaId;
            private set => _provinciaId = value;
        }

        public Provincia? Provincia
        {
            get => _provincia;
            private set
            {
                _provincia = value;
                if (value != null && _provinciaId != value.Id)
                {
                    _provinciaId = value.Id; // Sincronizar automáticamente
                }
            }
        }

        public Localidad(int id, string nombre, string codigoPostal, int provinciaId)
        {
            SetId(id);
            SetNombre(nombre);
            setCodigoPostal(codigoPostal);
            SetProvinciaId(provinciaId);
        }

        public void SetId(int id)
        {
            if (id < 0)
                throw new ArgumentException("El Id debe ser mayor que 0.", nameof(id));
            Id = id;
        }

        public void SetNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre del país no puede ser nulo o vacío.", nameof(nombre));
            Nombre = Nombre;
        }
        public void setCodigoPostal(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre del país no puede ser nulo o vacío.", nameof(nombre));
        Nombre = Nombre;
        }

        public void SetProvinciaId(int provinciaId)
        {
            if (provinciaId < 0)
                throw new ArgumentException("El email del usuario no puede ser nulo o vacío.", nameof(provinciaId));
            ProvinciaId = provinciaId;
        }
    }
}

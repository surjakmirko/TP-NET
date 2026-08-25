namespace Modelo.Dominio
{
    public class Complejo
    {
        public int Id { get; private set; }
        public string Direccion { get; private set; }
        public string Nombre { get; private set; }
        public int LocalidadId { get; private set; }
        public Localidad Localidad { get; set; } = null!;
        public int EncargadoId { get; private set; }
        public Usuario Encargado { get; set; } = null!;
        public int DueñoId { get; private set; }
        public Usuario Dueño { get; set; } = null!;

        public Complejo(int id, string direccion, string nombre, int idDueño, int idEncargado, int idLocalidad)
        {
            SetId(id);
            SetDireccion(direccion);
            SetNombre(nombre);
            SetDueñoId(idDueño);
            SetEncargadoId(idEncargado);
            SetLocalidadId(idLocalidad);
        }

        public void SetId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El Id debe ser mayor que 0.", nameof(id));
            Id = id;

        }

        public void SetDireccion(string direccion)
        {
            if (string.IsNullOrWhiteSpace(direccion))
                throw new ArgumentException("La dirección del complejo no puede ser nula o vacía.", nameof(direccion));
            Direccion = direccion;
        }

        public void SetNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre del complejo no puede ser nulo o vacío.", nameof(nombre));
            Nombre = nombre;
        }

        public void SetDueñoId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El Id debe ser mayor que 0.", nameof(id));
            DueñoId = id;
        }

        public void SetEncargadoId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El Id debe ser mayor que 0.", nameof(id));
            EncargadoId = id;

        }

        public void SetLocalidadId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El Id debe ser mayor que 0.", nameof(id));
            LocalidadId = id;

        }
    }
}
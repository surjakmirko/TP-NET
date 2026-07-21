namespace Modelo.Dominio
{
    public class Complejo
    {
        public int Id { get; private set; }
        public string Direccion { get; private set; }
        public string Nombre { get; private set; }

        //id dueno
        private int _dueñoId;
        private Usuario? _dueño;

        public int DueñoId
        {
            get => _dueño?.Id ?? _dueñoId;
            private set => _dueñoId = value;
        }

        public Usuario? Dueño
        {
            get => _dueño;
            private set
            {
                _dueño = value;
                if (value != null && _dueñoId != value.Id)
                {
                    _dueñoId = value.Id; // Sincronizar automáticamente
                }
            }
        }
        //id localidad
        private int _localidadId;
        private Localidad? _localidad;

        public int LocalidadId
        {
            get => _localidad?.Id ?? _localidadId;
            private set => _localidadId = value;
        }

        public Localidad? Localidad

        {
            get => _localidad;
            private set
            {
                _localidad = value;
                if (value != null && _localidadId != value.Id)
                {
                    _localidadId = value.Id;
                }
            }
        }
        ////id encargado
        private int _encargadoId;
        private Usuario? _encargado;

        public int EncargadoId
        {
            get => _encargado?.Id ?? _encargadoId;
            private set => _encargadoId = value;
        }

        public Usuario? Encargado
        {
            get => _encargado;
            private set
            {
                _encargado = value;
                if (value != null && _encargadoId != value.Id)
                {
                    _encargadoId = value.Id; // Sincronizar automáticamente
                }
            }
        }

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
            if (id < 0)
                throw new ArgumentException("El Id debe ser mayor que 0.", nameof(id));

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
                throw new ArgumentException("El nombre del país no puede ser nulo o vacío.", nameof(nombre));
            Nombre = Nombre;
        }

        public void SetDueñoId(int id)
        {
            if (id < 0)
                throw new ArgumentException("El Id debe ser mayor que 0.", nameof(id));

        }
        public void SetDueño(Usuario dueño)
        {
            ArgumentNullException.ThrowIfNull(dueño);
            _dueño = dueño;
            _dueñoId = dueño.Id;
        }
        public void SetEncargadoId(int id)
        {
            if (id < 0)
                throw new ArgumentException("El Id debe ser mayor que 0.", nameof(id));

        }
        public void SetEncargado(Usuario encargado)
        {
            ArgumentNullException.ThrowIfNull(encargado);
            _encargado = encargado;
            _encargadoId = encargado.Id;
        }
    
        public void SetLocalidadId(int id)
        {
            if (id < 0)
                throw new ArgumentException("El Id debe ser mayor que 0.", nameof(id));

        }
        public void SetLocalidad(Localidad localidad)
        {
            ArgumentNullException.ThrowIfNull(localidad);
            _localidad = localidad;
            _localidadId = localidad.Id;
        }
    }
}
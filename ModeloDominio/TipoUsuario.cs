using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Dominio
{
    public class TipoUsuario
    {
        public int Id { get; private set; }
        public string Descripcion { get; private set; }

        public ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();

        public TipoUsuario(int id, string descripcion)
        {
            SetId(id);
            SetDescripcion(descripcion);
        }

        public void SetId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El Id debe ser mayor que 0.", nameof(id));
            Id = id;
        }

        public void SetDescripcion(string descripcion)
        {
            if (string.IsNullOrWhiteSpace(descripcion))
                throw new ArgumentException("La descripcion del tipo de usuario no puede ser nulo o vacío.", nameof(descripcion));
            Descripcion = descripcion;
        }
    }
}

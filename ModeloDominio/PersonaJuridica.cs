using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Dominio
{
    public class PersonaJuridica
    {
        public string RazonSocial { get; private set; }
        public string Cuit { get; private set; }

        public ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
        public PersonaJuridica(string cuit, string razonSocial)
        {
            SetCuit(cuit);
            SetRazonSocial(razonSocial);
        }
        public void SetRazonSocial(string razonSocial)
        {
            if (string.IsNullOrWhiteSpace(razonSocial))
                throw new ArgumentException("La razón social del usuario no puede ser nula o vacía.", nameof(razonSocial));
            RazonSocial = razonSocial;
        }
        public void SetCuit(string cuit)
        {
            if (cuit.Length < 11)
                throw new ArgumentException("El cuit del usuario no puede ser nula o vacía.", nameof(cuit));
            Cuit = cuit;
        }
    }
}

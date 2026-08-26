using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    public class PersonaFisica
    {
        public string Nombre { get; private set; }
        public string Apellido { get; private set; }
        public string Dni { get; private set; }
        public DateOnly Fecha_Nacimiento { get; private set; }
        public PersonaFisica(string nombre, string apellido, string dni, DateOnly fechaNacimiento)
        {
            SetNombre(nombre);
            SetApellido(apellido);
            SetDni(dni);
            SetFechaNacimiento(fechaNacimiento);
        }
        public void SetNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre del usuario no puede ser nulo o vacío.", nameof(nombre));
            Nombre = nombre;
        }
        public void SetApellido(string apellido)
        {
            if (string.IsNullOrWhiteSpace(apellido))
                throw new ArgumentException("El apellido del usuario no puede ser nulo o vacío.", nameof(apellido));
            Apellido = apellido;
        }
        public void SetDni(string dni)
        {
            if (dni.Length < 7)
                throw new ArgumentException("El dni del usuario no puede ser menor a 8", nameof(dni));
            Dni = dni;
        }
        public void SetFechaNacimiento(DateOnly fechaNacimiento)
        {
            Fecha_Nacimiento = fechaNacimiento;
        }
    }
}


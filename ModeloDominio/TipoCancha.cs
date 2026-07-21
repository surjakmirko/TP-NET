using System;
using System.Collections.Generic;
namespace Modelo.Dominio
{
    public class TipoCancha
    {
        public int Id { get; private set; }
        public string Deporte { get; private set; }

        public TipoCancha(int id, string deporte)
        {
            SetId(id);
            SetDescripcion(deporte);
        }

        public void SetId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El Id debe ser mayor que 0.", nameof(id));
            Id = id;
        }
        
        public void SetDescripcion(string deporte)
        {
            if (string.IsNullOrWhiteSpace(deporte))
                throw new ArgumentException("El deporte no puede ser nulo o vacío.", nameof(deporte));
            Deporte = deporte;
        }
    }
}
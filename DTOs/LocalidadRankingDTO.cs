using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class LocalidadRankingDTO
    {
        public int Posicion { get; set; }
        public string NombreLocalidad { get; set; } = string.Empty;
        public int CantidadComplejos { get; set; }
    }
}

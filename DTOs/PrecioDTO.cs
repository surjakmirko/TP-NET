using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class PrecioDTO
    {
        public int Id { get; set; }
        public decimal PrecioBase { get; set; }
        public decimal PrecioAdicional { get; set; }
        public decimal PrecioSena { get; set; }
        public DateOnly FechaDesde { get; set; }
        public int ComplejoId { get; set; }
        public int CanchaNro { get; set; }
    }
}

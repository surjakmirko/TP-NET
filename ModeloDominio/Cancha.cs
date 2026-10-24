using System.Numerics;

namespace Modelo.Dominio
{
    public class Cancha
    {
        public int Nro { get; private set; }
        public void SetNro(int nro)
        {
            if (nro <= 0)
                throw new ArgumentException("El Nro debe ser mayor que 0.", nameof(nro));
            Nro = nro;
        }
        public int TipoCanchaId { get; private set; }

        public TipoCancha TipoCancha { get;  set; }
        public string Estado { get; private set; } = "Activa";

        public int ComplejoId { get; private set; }
        public Complejo Complejo { get; set; } = null!;
        public ICollection<Turno> Turnos { get; set; } = new List<Turno>();
        public ICollection<Precio> Precios { get; set; } = new List<Precio>();


        public Cancha(int nro, int tipoCanchaId, int complejoId, string estado = "Activa")
        {
            SetNro(nro);
            SetComplejoId(complejoId);
            SetTipoCanchaId(tipoCanchaId);
            SetEstado(estado);


        }

        public void SetTipoCanchaId(int tipoCanchaId)
        {
            if (tipoCanchaId <= 0)
                throw new ArgumentException("El id del tipo de cancha debe ser mayor que 0", nameof(tipoCanchaId));
            TipoCanchaId = tipoCanchaId;
        }
        public void SetEstado(string estado)
        {
            if (string.IsNullOrWhiteSpace(estado))
                throw new ArgumentException("El estado no puede estar vacío.", nameof(estado));

            Estado = estado;
        }
        public void Inavilitar()
        {
            if(this.Estado == "Inactiva")
            {
                return;
            }
            Estado = "Inactiva";
        }


        public void SetComplejoId(int complejoId)
        {
            if (complejoId <= 0)
                throw new ArgumentException("El id del complejo debe ser mayor que 0.", nameof(complejoId));
            ComplejoId = complejoId;
        }
    }
}
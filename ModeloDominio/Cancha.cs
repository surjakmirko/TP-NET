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

        public int ComplejoId { get; private set; }
        public Complejo Complejo { get; set; } = null!;
        public ICollection<Turno> Turnos { get; set; } = new List<Turno>();

        public Cancha(int nro, int tipoCanchaId, int complejoId)
        {
            SetNro(nro);
            SetComplejoId(complejoId);
            SetTipoCanchaId(tipoCanchaId);
        }

        public void SetTipoCanchaId(int tipoCanchaId)
        {
            if (tipoCanchaId <= 0)
                throw new ArgumentException("El id del tipo de cancha debe ser mayor que 0", nameof(tipoCanchaId));
            TipoCanchaId = tipoCanchaId;
        }

    

        public void SetComplejoId(int complejoId)
        {
            if (complejoId <= 0)
                throw new ArgumentException("El id del complejo debe ser mayor que 0.", nameof(complejoId));
            ComplejoId = complejoId;
        }
    }
}
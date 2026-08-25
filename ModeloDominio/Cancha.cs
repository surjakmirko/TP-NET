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

        private int _tipoCanchaId;
        private TipoCancha? _tipoCancha;
        public int TipoCanchaId
        {
            get => _tipoCancha?.Id ?? _tipoCanchaId;
            private set => _tipoCanchaId = value;
        }
        public TipoCancha? TipoCancha
        {
            get => _tipoCancha;
            private set
            {
                _tipoCancha = value;
                if (value != null)
                {
                    _tipoCanchaId = value.Id;
                }
            }
        }

        private int _complejoId;
        private Complejo? _complejo;

        public int ComplejoId
        {
            get => _complejo?.Id ?? _complejoId;
            private set => _complejoId = value;
        }

        public Complejo? Complejo
        {
            get => _complejo;
            private set
            {
                _complejo = value;
                if (value != null)
                {
                    _tipoCanchaId = value.Id;
                }
            }
        }

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

        public void SetTipoCancha(TipoCancha tipoCancha)
        {
            ArgumentNullException.ThrowIfNull(tipoCancha);
            _tipoCancha = tipoCancha;
            _tipoCanchaId = tipoCancha.Id;
        }

        public void SetComplejoId(int complejoId)
        {
            if (complejoId <= 0)
                throw new ArgumentException("El id del complejo debe ser mayor que 0.", nameof(complejoId));
            ComplejoId = complejoId;
        }

        public void SetComplejo(Complejo complejo)
        {
            ArgumentNullException.ThrowIfNull(complejo);
            _complejo = complejo;
            _complejoId = complejo.Id;
        }
    }
}
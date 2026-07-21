using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Dominio
{
    internal class Turno
    {
        public int Id { get; private set; }
        public TimeOnly HoraInicio { get; private set; }
        public TimeOnly HoraFin { get; private set; }
        public string Estado { get; private set; }
        public string MotivoCancelacion { get; private set; }

        private int _clienteId;
        private Usuario? _cliente;

        public int ClienteId
        {
            get => _cliente?.Id ?? _clienteId;
            private set => _clienteId = value;
        }

        public Usuario? Cliente
        {
            get => _cliente;
            private set
            {
                _cliente = value;
                if (value != null && _clienteId != value.Id)
                {
                    _clienteId = value.Id;
                }
            }
        }

        private int _tipoTurnoId;
        private TipoTurno? _tipoTurno;

        public int TipoTurnoId
        {
            get => _tipoTurno?.Id ?? _tipoTurnoId;
            private set => _tipoTurnoId = value;
        }

        public TipoTurno? TipoTurno
        {
            get => _tipoTurno;
            private set
            {
                _tipoTurno = value;
                if (value != null && _tipoTurnoId != value.Id)
                {
                    _tipoTurnoId = value.Id;
                }
            }
        }
        private int _complejoId;
        public int ComplejoId
        {
            get => _cancha?.ComplejoId ?? _complejoId;
            private set => _complejoId = value;
        }

        private int _canchaNro;
        public int CanchaNro
        {
            get => _cancha?.Nro ?? _canchaNro;
            private set => _canchaNro = value;
        }

        private Cancha? _cancha;
        public Cancha? Cancha
        {
            get => _cancha;
            private set
            {
                _cancha = value;
                if (value != null)
                {
                    _canchaNro = value.Nro;
                    _complejoId = value.ComplejoId;
                }
            }
        }
        public Turno(int id, TimeOnly horaInicio, TimeOnly horaFin, int idCliente, int idTipoTurno, int complejoId, int canchaNro)
        {
            SetId(id);
            SetHoraInicio(horaInicio);
            SetHoraFin(horaFin);
            SetEstado("Reservado");
            SetClienteId(idCliente);
            SetTipoTurnoId(idTipoTurno);
            SetCanchaId(complejoId, canchaNro);
        }
        public void SetId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El Id debe ser mayor que 0.", nameof(id));
            Id = id;
        }
        public void SetCancha(Cancha cancha)
        {
            ArgumentNullException.ThrowIfNull(cancha);
            _cancha = cancha;
            _canchaNro = cancha.Nro;
            _complejoId = cancha.ComplejoId;
        }
        public void SetCanchaId(int complejoId, int canchaNro)
        {
            if (complejoId <= 0)
                throw new ArgumentException("El ComplejoId debe ser mayor que 0.", nameof(complejoId));

            if (canchaNro <= 0)
                throw new ArgumentException("El CanchaNro debe ser mayor que 0.", nameof(canchaNro));

            _cancha = null;

            _complejoId = complejoId;
            _canchaNro = canchaNro;
        }

        public void SetHoraInicio(TimeOnly horaInicio)
        {
            HoraInicio = horaInicio;
        }

        public void SetHoraFin(TimeOnly horaFin)
        {
            HoraFin = horaFin;
        }

        public void SetEstado(string estado)
        {
            Estado = estado;
        }

        public void SetMotivoCancelacion(string motivoCancelacion)
        {
            if (string.IsNullOrWhiteSpace(motivoCancelacion))
                throw new ArgumentException("El motivo de cancelación no puede ser nulo o vacío.", nameof(motivoCancelacion));
            MotivoCancelacion = motivoCancelacion;
        }
        public void SetClienteId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El Id debe ser mayor que 0.", nameof(id));
            ClienteId = id;
        }
        public void SetCliente(Usuario cliente)
        {
            ArgumentNullException.ThrowIfNull(cliente);
            _cliente = cliente;
            _clienteId = cliente.Id;
        }

        public void SetTipoTurnoId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El Id debe ser mayor que 0.", nameof(id));

        }

        public void SetTipoTurno(TipoTurno tipoTurno)
        {
            ArgumentNullException.ThrowIfNull(tipoTurno);
            _tipoTurno = tipoTurno;
            _tipoTurnoId = tipoTurno.Id;
        }
    }
}
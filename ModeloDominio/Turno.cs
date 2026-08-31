using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Dominio
{
    public class Turno
    {
        public int Id { get; private set; }
        public TimeOnly HoraInicio { get; private set; }
        public TimeOnly HoraFin { get; private set; }
        public string Estado { get; private set; }
        public string? MotivoCancelacion { get; private set; }

        public int ClienteId { get; private set; }
        public Usuario Cliente { get;  set; }
        public int TipoTurnoId { get; private set; }
        public TipoTurno TipoTurno { get; set; }
        public int ComplejoId { get; private set; }
        public Complejo Complejo { get; set; }
        public int CanchaNro { get; private set; }
        public Cancha Cancha { get; set; }
        public DateOnly Fecha { get; private set; }


        public Turno(TimeOnly horaInicio, TimeOnly horaFin, int clienteId, int tipoTurnoId, int complejoId, int canchaNro, DateOnly fecha)
        {
            SetHoraInicio(horaInicio);
            SetHoraFin(horaFin);
            SetEstado("Reservado");
            SetClienteId(clienteId);
            SetTipoTurnoId(tipoTurnoId);      
            SetCanchaId(complejoId, canchaNro); 
            SetFecha(fecha);
        }

 
        public Turno(int id, TimeOnly horaInicio, TimeOnly horaFin, int clienteId, int tipoTurnoId, int complejoId, int canchaNro, DateOnly fecha)
            : this(horaInicio, horaFin, clienteId, tipoTurnoId, complejoId, canchaNro, fecha)
        {
            SetId(id);
        }
        public void SetId(int id)
        {
            if (id < 0)
                throw new ArgumentException("El Id debe ser mayor que 0.", nameof(id));
            Id = id;
        }
        public void SetCanchaId(int complejoId, int canchaNro)
        {
            if (complejoId <= 0)
                throw new ArgumentException("El ComplejoId debe ser mayor que 0.", nameof(complejoId));

            if (canchaNro <= 0)
                throw new ArgumentException("El CanchaNro debe ser mayor que 0.", nameof(canchaNro));
            ComplejoId = complejoId;
            CanchaNro = canchaNro;
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
            MotivoCancelacion = motivoCancelacion;
        }
        public void SetClienteId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El Id debe ser mayor que 0.", nameof(id));
            ClienteId = id;
        }


        public void SetTipoTurnoId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El Id debe ser mayor que 0.", nameof(id));
            TipoTurnoId = id;

        }

        public void SetFecha(DateOnly fecha)
        {
            Fecha = fecha;
        }
    }
}
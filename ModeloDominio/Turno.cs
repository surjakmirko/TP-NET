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
        public string Estado { get; private set; } = "Reservado";
        public string? MotivoCancelacion { get; private set; }

        public int? ClienteId { get; private set; }
        public Usuario Cliente { get;  set; }
        public int TipoTurnoId { get; private set; }
        public TipoTurno TipoTurno { get; set; }
        public int ComplejoId { get; private set; }
        public Complejo Complejo { get; set; }
        public int CanchaNro { get; private set; }
        public Cancha Cancha { get; set; }
        public DateOnly Fecha { get; private set; }

        // Cliente externo (para turnos creados por encargado)
        public string? NombreClienteExterno { get; private set; }
        public string? ApellidoClienteExterno { get; private set; }

        public bool EsClienteExterno => !string.IsNullOrWhiteSpace(NombreClienteExterno);

        public Turno(TimeOnly HoraInicio, TimeOnly HoraFin, int? ClienteId, int TipoTurnoId, int ComplejoId, int CanchaNro, DateOnly Fecha)
        {
            SetHoraInicio(HoraInicio);
            SetHoraFin(HoraFin);
            SetEstado("Reservado");
            SetClienteId(ClienteId);
            SetTipoTurnoId(TipoTurnoId);      
            SetCanchaId(ComplejoId, CanchaNro); 
            SetFecha(Fecha);
        }
 
        public Turno(int Id, TimeOnly HoraInicio, TimeOnly HoraFin, int? ClienteId, int TipoTurnoId, int ComplejoId, int CanchaNro, DateOnly Fecha)
            : this(HoraInicio, HoraFin, ClienteId, TipoTurnoId, ComplejoId, CanchaNro, Fecha)
        {
            SetId(Id);
        }
        
        // Constructor para turnos de encargado (cliente externo)
        public Turno(TimeOnly HoraInicio, TimeOnly HoraFin, string NombreClienteExterno, string ApellidoClienteExterno, int TipoTurnoId, int ComplejoId, int CanchaNro, DateOnly Fecha)
        {
            SetHoraInicio(HoraInicio);
            SetHoraFin(HoraFin);
            SetEstado("Reservado");
            SetClienteExterno(NombreClienteExterno, ApellidoClienteExterno);
            SetTipoTurnoId(TipoTurnoId);      
            SetCanchaId(ComplejoId, CanchaNro); 
            SetFecha(Fecha);
        }

        public Turno(int Id, TimeOnly HoraInicio, TimeOnly HoraFin, string NombreClienteExterno, string ApellidoClienteExterno, int TipoTurnoId, int ComplejoId, int CanchaNro, DateOnly Fecha)
            : this(HoraInicio, HoraFin, NombreClienteExterno, ApellidoClienteExterno, TipoTurnoId, ComplejoId, CanchaNro, Fecha)
        {
            SetId(Id);
        }
        public void SetId(int id)
        {
            if (id < 0)
                throw new ArgumentException("El Id debe ser mayor que 0.", nameof(id));
            this.Id = id;
        }
        public void SetCanchaId(int complejoId, int canchaNro)
        {
            if (complejoId <= 0)
                throw new ArgumentException("El ComplejoId debe ser mayor que 0.", nameof(complejoId));

            if (canchaNro <= 0)
                throw new ArgumentException("El CanchaNro debe ser mayor que 0.", nameof(canchaNro));
            this.ComplejoId = complejoId;
            this.CanchaNro = canchaNro;
        }

        public void SetHoraInicio(TimeOnly horaInicio)
        {
            this.HoraInicio = horaInicio;
        }

        public void SetHoraFin(TimeOnly horaFin)
        {
            this.HoraFin = horaFin;
        }

        public void SetEstado(string estado)
        {
            this.Estado = estado;
        }

        public void SetMotivoCancelacion(string motivoCancelacion)
        {
            this.MotivoCancelacion = motivoCancelacion;
        }

        public void Cancelar(string? motivoCancelacion = null)
        {
            if (!string.Equals(this.Estado, "Reservado", StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException("Solo se pueden cancelar turnos en estado 'Reservado'.");

            this.Estado = "Cancelado";
            this.MotivoCancelacion = motivoCancelacion;
        }
        public void SetClienteId(int? id)
        {
            if (id.HasValue && id.Value <= 0)
                throw new ArgumentException("El Id debe ser mayor que 0.", nameof(id));
            this.ClienteId = id;
        }

        public void SetClienteExterno(string nombreClienteExterno, string apellidoClienteExterno)
        {
            if (string.IsNullOrWhiteSpace(nombreClienteExterno))
                throw new ArgumentException("El nombre no puede estar vacío.", nameof(nombreClienteExterno));
            if (string.IsNullOrWhiteSpace(apellidoClienteExterno))
                throw new ArgumentException("El apellido no puede estar vacío.", nameof(apellidoClienteExterno));
            this.NombreClienteExterno = nombreClienteExterno.Trim();
            this.ApellidoClienteExterno = apellidoClienteExterno.Trim();
        }


        public void SetTipoTurnoId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El Id debe ser mayor que 0.", nameof(id));
            this.TipoTurnoId = id;

        }

        public void SetFecha(DateOnly fecha)
        {
            this.Fecha = fecha;
        }
    }
}
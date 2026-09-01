using System;

namespace Modelo.Dominio
{
    public class Precio
    {
        public decimal PrecioBase { get; private set; }
        public decimal PrecioAdicional { get; private set; }
        public decimal PrecioSena { get; private set; }
        public DateOnly FechaDesde { get; private set; }
        public int ComplejoId { get; private set; }
        public int CanchaNro { get; private set; }
        public Cancha? Cancha { get; private set; }
        protected Precio() { }
        public Precio(decimal precioBase, decimal precioAdicional, decimal precioSena, DateOnly fechaDesde, int complejoId, int canchaNro)
        {
            SetPrecioBase(precioBase);
            SetPrecioAdicional(precioAdicional);
            SetPrecioSena(precioSena);
            SetFechaDesde(fechaDesde);
            SetCanchaId(complejoId, canchaNro);
        }
        public void SetCancha(Cancha cancha)
        {
            ArgumentNullException.ThrowIfNull(cancha);

            Cancha = cancha;
            ComplejoId = cancha.ComplejoId;
            CanchaNro = cancha.Nro;
        }
        public void SetCanchaId(int complejoId, int canchaNro)
        {
            if (complejoId <= 0)
                throw new ArgumentException("El ComplejoId debe ser mayor que 0.", nameof(complejoId));

            if (canchaNro <= 0)
                throw new ArgumentException("El CanchaNro debe ser mayor que 0.", nameof(canchaNro));

            Cancha = null;
            ComplejoId = complejoId;
            CanchaNro = canchaNro;
        }
        public void SetPrecioBase(decimal precioBase)
        {
            if (precioBase <= 0)
                throw new ArgumentException("El precio base debe ser mayor que 0.", nameof(precioBase));

            PrecioBase = precioBase;
        }
        public void SetPrecioAdicional(decimal precioAdicional)
        {
            if (precioAdicional <= 0)
                throw new ArgumentException("El precio adicional debe ser mayor que 0.", nameof(precioAdicional));

            PrecioAdicional = precioAdicional;
        }
        public void SetPrecioSena(decimal precioSena)
        {
            if (precioSena <= 0)
                throw new ArgumentException("El precio de la seña debe ser mayor que 0.", nameof(precioSena));

            PrecioSena = precioSena;
        }
        public void SetFechaDesde(DateOnly fechaDesde)
        {
            if (fechaDesde > DateOnly.FromDateTime(DateTime.Now))
                throw new ArgumentException("La fecha desde no puede ser mayor a la fecha actual.", nameof(fechaDesde));

            FechaDesde = fechaDesde;
        }
    }
}
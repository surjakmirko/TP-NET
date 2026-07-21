using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Dominio
{
    internal class Precio
    {
        public float PrecioBase { get; private set; }
        public float PrecioAdicional { get; private set; }
        public float PrecioSena { get; private set; }
        public DateOnly FechaDesde { get; private set; }

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

        public Precio(float precioBase, float precioAdicional, float precioSena, DateOnly fechaDesde, int complejoId, int canchaNro)
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

        public void SetPrecioBase(float precioBase)
        {
            if (precioBase <= 0)
                throw new ArgumentException("El precio base debe ser mayor que 0.", nameof(precioBase));
            PrecioBase = precioBase;
        }

        public void SetPrecioAdicional(float precioAdicional)
        {
            if (precioAdicional <= 0)
                throw new ArgumentException("El precio adicional debe ser mayor que 0.", nameof(precioAdicional));
            PrecioAdicional = precioAdicional;
        }

        public void SetPrecioSena(float precioSena)
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
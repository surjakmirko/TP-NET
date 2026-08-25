using Data;
using DTOs;
using Modelo.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDominio;

namespace Servicios
{
    public class TipoTurnoServicio : ITipoTurnoServicio
    {
        public async Task<TipoTurnoDTO?> GetAsync(int id)
        {
            TipoTurno? tipoTurno = await tipoTurnoRepositorio.GetAsync(id);

            if (tipoTurno == null)
                return null;

            return new TipoTurnoDTO
            {
                Id = tipoTurno.Id,
                Nombre = tipoTurno.Nombre,
                Descripcion = tipoTurno.Descripcion
            };
        }

        public async Task<IEnumerable<TipoTurnoDTO>> GetAllAsync()
        {
            var tiposTurno = await tipoTurnoRepositorio.GetAllAsync();

            return tiposTurno.Select(tipoTurno => new TipoTurnoDTO
            {
                Id = tipoTurno.Id,
                Nombre = tipoTurno.Nombre,
                Descripcion = tipoTurno.Descripcion
            }).ToList();
        }
    }
}

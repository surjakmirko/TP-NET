using Data;
using DTOs;
using Modelo.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class TipoCanchaServicio : ITipoCanchaServicio
    {
        private readonly ITipoCanchaRepositorio tipoCanchaRepositorio;

        public TipoCanchaServicio(ITipoCanchaRepositorio tipoCanchaRepositorio)
        {
            this.tipoCanchaRepositorio = tipoCanchaRepositorio;
        }

        public async Task<TipoCanchaDTO> AddAsync(TipoCanchaDTO dto)
        {
            TipoCancha tipoCancha = new TipoCancha(dto.Id, dto.Deporte);

            await tipoCanchaRepositorio.AddAsync(tipoCancha);
            dto.Id = tipoCancha.Id;

            return dto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await tipoCanchaRepositorio.DeleteAsync(id);
        }

        public async Task<TipoCanchaDTO?> GetAsync(int id)
        {
            TipoCancha? tipoCancha = await tipoCanchaRepositorio.GetAsync(id);

            if (tipoCancha == null)
                return null;

            return new TipoCanchaDTO
            {
                Id = tipoCancha.Id,
                Deporte = tipoCancha.Deporte
            };
        }

        public async Task<IEnumerable<TipoCanchaDTO>> GetAllAsync()
        {
            var tiposCancha = await tipoCanchaRepositorio.GetAllAsync();

            return tiposCancha.Select(tipoCancha => new TipoCanchaDTO
            {
                Id = tipoCancha.Id,
                Deporte = tipoCancha.Deporte
            }).ToList();
        }

        public async Task<bool> UpdateAsync(TipoCanchaDTO dto)
        {
            var existing = await tipoCanchaRepositorio.GetAsync(dto.Id);
            if (existing == null)
                return false;

            TipoCancha tipoCancha = new TipoCancha(dto.Id, dto.Deporte);
            return await tipoCanchaRepositorio.UpdateAsync(tipoCancha);
        }

        //public async Task<IEnumerable<TipoUsuarioDTO>> GetByCriteriaAsync(TipoUsuarioCriteriaDTO criteriaDTO)
        //{
        //    // Mapear DTO a Domain Model
        //    var criteria = new TipoUsuarioCriteria(criteriaDTO.Texto);

        //    // Llamar al repositorio
        //    var tiposUsuario = await tipoUsuarioRepositorio.GetByCriteriaAsync(criteria);

        //    // Mapear Domain Model a DTO
        //    return tiposUsuario.Select(tipoUsuario => new TipoUsuarioDTO
        //    {
        //        Id = tipoUsuario.Id,
        //        Descripcion = tipoUsuario.Descripcion
        //    });
        //}
    }
}

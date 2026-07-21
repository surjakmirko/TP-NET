using DTOs;
using Modelo.Dominio;
using Data;

namespace Servicios
{
    public class TipoUsuarioServicio : ITipoUsuarioServicio
    {
        private readonly ITipoUsuarioRepositorio tipoUsuarioRepositorio;

        public TipoUsuarioServicio(ITipoUsuarioRepositorio tipoUsuarioRepositorio)
        {
            this.tipoUsuarioRepositorio = tipoUsuarioRepositorio;
        }

        public async Task<TipoUsuarioDTO> AddAsync(TipoUsuarioDTO dto)
        {
            TipoUsuario tipoUsuario = new TipoUsuario(dto.Id, dto.Descripcion);

            await tipoUsuarioRepositorio.AddAsync(tipoUsuario);

            dto.Id = tipoUsuario.Id;

            return dto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await tipoUsuarioRepositorio.DeleteAsync(id);
        }

        public async Task<TipoUsuarioDTO?> GetAsync(int id)
        {
            TipoUsuario? tipoUsuario = await tipoUsuarioRepositorio.GetAsync(id);

            if (tipoUsuario == null)
                return null;

            return new TipoUsuarioDTO
            {
                Id = tipoUsuario.Id,
                Descripcion = tipoUsuario.Descripcion
            };
        }

        public async Task<IEnumerable<TipoUsuarioDTO>> GetAllAsync()
        {
            var tiposUsuario = await tipoUsuarioRepositorio.GetAllAsync();

            return tiposUsuario.Select(tipoUsuario => new TipoUsuarioDTO
            {
                Id = tipoUsuario.Id,
                Descripcion = tipoUsuario.Descripcion
            }).ToList();
        }

        public async Task<bool> UpdateAsync(TipoUsuarioDTO dto)
        {
            var existing = await tipoUsuarioRepositorio.GetAsync(dto.Id);
            if (existing == null)
                return false;

            TipoUsuario tipoUsuario = new TipoUsuario(dto.Id, dto.Descripcion);
            return await tipoUsuarioRepositorio.UpdateAsync(tipoUsuario);
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
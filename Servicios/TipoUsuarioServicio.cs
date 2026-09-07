using Data;
using DTOs;
using Modelo.Dominio;

namespace Servicios
{
    public class TipoUsuarioServicio : ITipoUsuarioServicio
    {
        private readonly ITipoUsuarioRepositorio tipoUsuarioRepositorio;

        public TipoUsuarioServicio(ITipoUsuarioRepositorio tipoUsuarioRepositorio)
        {
            this.tipoUsuarioRepositorio = tipoUsuarioRepositorio;
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
    }
}
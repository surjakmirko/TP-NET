using Modelo.Dominio;
using Data;       
using DTOs;

namespace Servicios
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly IUsuarioRepositorio usuarioRepositorio;

        public UsuarioServicio(IUsuarioRepositorio usuarioRepositorio)
        {
            this.usuarioRepositorio = usuarioRepositorio;
        }

        public async Task<UsuarioDTO> AddAsync(UsuarioDTO dto)
        {
            if (await usuarioRepositorio.EmailExistsAsync(dto.Email))
            {
                throw new ArgumentException($"Ya existe un usuario con el Email '{dto.Email}'.");
            }
            Usuario usuario = new Usuario(dto.Id, dto.Email, dto.Telefono, dto.Password, dto.TipoUsuarioId, dto.PersonaFisicaDni, dto.PersonaJuridicaCuit);

            await usuarioRepositorio.AddAsync(usuario);

            dto.Id = usuario.Id;

            return dto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await usuarioRepositorio.DeleteAsync(id);
        }

        public async Task<UsuarioDTO?> GetAsync(int id)
        {
            Usuario? usuario = await usuarioRepositorio.GetAsync(id);

            if (usuario == null)
                return null;

            return new UsuarioDTO
            {
                Id = usuario.Id,
                Email = usuario.Email,
                Telefono = usuario.Telefono,
                Password = usuario.Password,
                TipoUsuarioId = usuario.TipoUsuarioId,
                PersonaFisicaDni = usuario.PersonaFisicaDni,
                PersonaJuridicaCuit = usuario.PersonaJuridicaCuit
            };
        }

        public async Task<IEnumerable<UsuarioDTO>> GetAllAsync()
        {
            var usuarios = await usuarioRepositorio.GetAllAsync();

            return usuarios.Select(usuario => new UsuarioDTO
            {
                Id = usuario.Id,
                Email = usuario.Email,
                Telefono = usuario.Telefono,
                Password = usuario.Password, 
                TipoUsuarioId = usuario.TipoUsuarioId,
                PersonaFisicaDni = usuario.PersonaFisicaDni,
                PersonaJuridicaCuit = usuario.PersonaJuridicaCuit
            }).ToList();
        }

        public async Task<bool> UpdateAsync(UsuarioDTO dto)
        {
            if (await usuarioRepositorio.EmailExistsAsync(dto.Email))
            {
                throw new ArgumentException($"Ya existe otro usuario con el Email '{dto.Email}'.");
            }
            Usuario usuario = new Usuario(dto.Id, dto.Email, dto.Telefono, dto.Password, dto.TipoUsuarioId, dto.PersonaFisicaDni, dto.PersonaJuridicaCuit);

            return await usuarioRepositorio.UpdateAsync(usuario);
        }
    }
}

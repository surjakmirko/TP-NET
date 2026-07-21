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

            Usuario usuario = dto.TipoUsuarioId switch
            {
                1 => new Usuario(0, dto.Email, dto.Telefono, dto.Password, dto.TipoUsuarioId),

                2 => new Usuario(0, dto.Email, dto.Telefono, dto.Password, dto.TipoUsuarioId, dto.Nombre, dto.Apellido, dto.Fecha_Nacimiento),
                
                3 => new Usuario(0, dto.Email, dto.Telefono, dto.Password, dto.TipoUsuarioId, dto.Razon_Social, dto.Cuit),

                4 => new Usuario(0, dto.Email, dto.Telefono, dto.Password, dto.TipoUsuarioId)
            };

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
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Razon_Social = usuario.Razon_Social,
                Cuit = usuario.Cuit,
                Fecha_Nacimiento = usuario.Fecha_Nacimiento
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
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Razon_Social = usuario.Razon_Social,
                Cuit = usuario.Cuit,
                Fecha_Nacimiento = usuario.Fecha_Nacimiento
            }).ToList();
        }

        public async Task<bool> UpdateAsync(UsuarioDTO dto)
        {
            if (await usuarioRepositorio.EmailExistsAsync(dto.Email, dto.Id))
            {
                throw new ArgumentException($"Ya existe otro usuario con el Email '{dto.Email}'.");
            }

            var existing = await usuarioRepositorio.GetAsync(dto.Id);
            if (existing == null)
                return false;

            Usuario usuario = dto.TipoUsuarioId switch
            {
                1 => new Usuario(dto.Id, dto.Email, dto.Telefono, dto.Password, dto.TipoUsuarioId),
                2 => new Usuario(dto.Id, dto.Email, dto.Telefono, dto.Password, dto.TipoUsuarioId, dto.Nombre, dto.Apellido, dto.Fecha_Nacimiento),
                3 => new Usuario(dto.Id, dto.Email, dto.Telefono, dto.Password, dto.TipoUsuarioId, dto.Razon_Social),
                4 => new Usuario(dto.Id, dto.Email, dto.Telefono, dto.Password, dto.TipoUsuarioId)
            };

            return await usuarioRepositorio.UpdateAsync(usuario);
        }
        
        public async Task<IEnumerable<UsuarioDTO>> GetByCriteriaAsync(UsuarioCriteriaDTO criteriaDTO)
        {   
            var criteria = new UsuarioCriteria(criteriaDTO.Texto);

            var usuarios = await usuarioRepositorio.GetByCriteriaAsync(criteria);

            return usuarios.Select(usuario => 
            {
                var dto = new UsuarioDTO
                {
                    Id = usuario.Id,
                    Email = usuario.Email,
                    Telefono = usuario.Telefono,
                    Password = usuario.Password,
                    TipoUsuarioId = usuario.TipoUsuarioId,
                    TipoUsuarioNombre = usuario.TipoUsuario?.Descripcion
                };

                switch (usuario.TipoUsuarioId)
                {
                    case 2:
                        dto.Nombre = usuario.Nombre;
                        dto.Apellido = usuario.Apellido;
                        dto.Fecha_Nacimiento = usuario.Fecha_Nacimiento;
                        break;
                    case 3:
                        dto.Razon_Social = usuario.Razon_Social;
                        dto.Cuit = usuario.Cuit;
                        break;
                }

                return dto;
            }).ToList();
        }
    }
}

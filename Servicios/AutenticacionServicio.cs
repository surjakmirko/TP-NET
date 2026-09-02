using Data;
using DTOs;
using BCrypt.Net;
using Microsoft.Extensions.Configuration;

namespace Servicios
{
    public class AutenticacionServicio 
    {
        private readonly IUsuarioRepositorio usuarioRepositorio;
       
        //private readonly IConfiguration configuration;

        public AutenticacionServicio(IUsuarioRepositorio usuarioRepositorio)
        {
            this.usuarioRepositorio = usuarioRepositorio;
            //this.configuration = configuration;
        }

        public async Task<LoginResponseDTO?> LoginAsync(LoginDTO login)
        {
            if (string.IsNullOrWhiteSpace(login.Email) || string.IsNullOrWhiteSpace(login.Password))
                return null;

            var usuario = await usuarioRepositorio.GetByEmailAsync(login.Email);

            if (usuario == null)
                return null;
            bool validacion = BCrypt.Net.BCrypt.Verify(login.Password, usuario.Password);
            if (!validacion)
                return null;
          
            return new LoginResponseDTO
            {
                Id= usuario.Id,
                TipoUsuarioId = usuario.TipoUsuarioId
            };
        }
    }
}

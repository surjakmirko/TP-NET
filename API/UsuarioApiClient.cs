using System.Collections.Generic;
using System.Threading.Tasks;
using DTOs;

namespace API
{
    public class UsuarioApiClient : BaseApiClient
    {
        public static async Task<List<UsuarioDTO>?> GetAllAsync()
        {
            return await GetAsync<List<UsuarioDTO>>("usuarios");
        }
        public static async Task<UsuarioDTO?> GetByIdAsync(int id)
        {
            return await GetAsync<UsuarioDTO>($"usuarios/{id}");
        }
        public static async Task CrearUsuarioAsync(UsuarioCrearDTO dto)
        {
            await PostAsync("usuarios", dto);
        }
        public static async Task EliminarUsuarioAsync(int id)
        {
            await DeleteAsync($"usuarios/{id}");
        }
    }
}
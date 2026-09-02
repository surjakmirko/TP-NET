using System.Collections.Generic;
using System.Threading.Tasks;
using DTOs;

namespace API
{
    public class UsuarioApiClient : BaseApiClient
    {
        public static async Task<List<UsuarioCrearDTO>?> GetAllAsync()
        {
            return await GetAsync<List<UsuarioCrearDTO>>("api/usuario");
        }

        public static async Task CrearUsuarioAsync(UsuarioCrearDTO dto)
        {
            await PostAsync("api/usuario", dto);
        }

        public static async Task EliminarUsuarioAsync(int id)
        {
            await DeleteAsync($"api/usuario/{id}");
        }
    }
}
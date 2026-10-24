using System.Collections.Generic;
using System.Threading.Tasks;
using DTOs;
using Blazor.WebAssembly.Servicios;

namespace Blazor.WebAssembly.Servicios
{
    public class UsuarioApiClient : BlazorApiClient
    {
        public UsuarioApiClient(HttpClient http) : base(http) { }

        public async Task<List<UsuarioDTO>?> GetAllDueno()
        {
            return await GetAsync<List<UsuarioDTO>>("usuarios/duenos");
        }

        public async Task<UsuarioDTO?> GetByIdAsync(int id)
        {
            return await GetAsync<UsuarioDTO>($"usuarios/{id}");
        }

        public async Task<UsuarioDTO?> CrearUsuarioAsync(UsuarioCrearDTO dto)
        {
            return await PostAsync<UsuarioCrearDTO, UsuarioDTO>("usuarios", dto);
        }

        public async Task ActualizarUsuarioAsync(UsuarioDTO dto)
        {
            await PutAsync("usuarios", dto);
        }

        public async Task EliminarUsuarioAsync(int id)
        {
            await DeleteAsync($"usuarios/{id}");
        }
    }
}